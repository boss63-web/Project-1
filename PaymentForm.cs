using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace HouseRentalSystem
{
    public partial class PaymentForm : Form
    {
        public DateTime RentDate;
        public decimal Amount;
        
        // API Key - Replace with your valid key from Chapa dashboard
        private string chapaApiKey = "CHASECK_TEST-xxxxxxxxxxxxxxxx"; // Get from: https://dashboard.chapa.co/
        
        // Tenant info - Replace with actual data from your system
        public string TenantEmail { get; set; } = "tenant@example.com";
        public string TenantFirstName { get; set; } = "Tenant";
        public string TenantLastName { get; set; } = "User";
        
        private string currentTxRef;
        private bool useTestMode = false; // Set to true for testing without real API calls

        public PaymentForm()
        {
            InitializeComponent();
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            // CRITICAL: Enable TLS 1.2 for Chapa API
            System.Net.ServicePointManager.SecurityProtocol = 
                System.Net.SecurityProtocolType.Tls12 |
                System.Net.SecurityProtocolType.Tls11 |
                System.Net.SecurityProtocolType.Tls;
            
            // Display payment information
            lblInstruction.Text = "Chapa Payment Gateway";
            lblAccount.Text = "Pay your rent securely with Chapa";
            
            if (RentDate != DateTime.MinValue)
            {
                lblRentDate.Text = "Rent Date: " + RentDate.ToString("dd/MM/yyyy");
                lblNextPay.Text = "Next Payment: " + RentDate.AddMonths(1).ToString("dd/MM/yyyy");
            }
            
            lblAmount.Text = "Amount: " + Amount.ToString("N2") + " ETB";
            
            // Initialize UI state
            btnPayChapa.Enabled = true;
            btnOpenBrowser.Enabled = false;
            btnConfirm.Enabled = false;
            txtTxRef.ReadOnly = true;
            txtCheckoutUrl.ReadOnly = true;
            
            // Show API key status
            DisplayApiKeyStatus();
            
            // Setup test mode if enabled
            if (useTestMode)
            {
                lblTestMode.Visible = true;
                lblTestMode.Text = "TEST MODE - No real payments";
                lblTestMode.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void DisplayApiKeyStatus()
        {
            if (string.IsNullOrEmpty(chapaApiKey))
            {
                lblApiKeyStatus.Text = "❌ No API Key Configured";
                lblApiKeyStatus.ForeColor = System.Drawing.Color.Red;
                btnPayChapa.Enabled = false;
            }
            else if (chapaApiKey.Contains("TEST"))
            {
                lblApiKeyStatus.Text = "✅ Test API Key Loaded";
                lblApiKeyStatus.ForeColor = System.Drawing.Color.Orange;
            }
            else if (chapaApiKey.Contains("LIVE"))
            {
                lblApiKeyStatus.Text = "✅ Live API Key Loaded";
                lblApiKeyStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblApiKeyStatus.Text = "⚠️ Unknown API Key Format";
                lblApiKeyStatus.ForeColor = System.Drawing.Color.Yellow;
            }
            
            // Show first and last few characters of API key
            if (chapaApiKey.Length > 10)
            {
                txtDebugInfo.AppendText($"API Key: {chapaApiKey.Substring(0, 10)}...{chapaApiKey.Substring(chapaApiKey.Length - 5)}\n");
            }
        }

        // ================= PAY BUTTON =================
        private async void btnPayChapa_Click(object sender, EventArgs e)
        {
            try
            {
                // Disable button during processing
                btnPayChapa.Enabled = false;
                Cursor = Cursors.WaitCursor;
                
                // Clear previous debug info
                txtDebugInfo.Clear();
                txtDebugInfo.AppendText($"=== Starting Payment Process ===\n");
                txtDebugInfo.AppendText($"Time: {DateTime.Now:HH:mm:ss}\n");
                txtDebugInfo.AppendText($"Amount: {Amount:N2} ETB\n");
                
                if (useTestMode)
                {
                    // Test mode - simulate payment
                    await ProcessTestPayment();
                    return;
                }
                
                // Generate unique transaction reference
                currentTxRef = GenerateTransactionReference();
                txtDebugInfo.AppendText($"Transaction Ref: {currentTxRef}\n");
                
                // Create payment request
                var requestData = new
                {
                    amount = Amount.ToString("0.00"), // Must have 2 decimal places
                    currency = "ETB",
                    email = TenantEmail,
                    first_name = TenantFirstName,
                    last_name = TenantLastName,
                    tx_ref = currentTxRef,
                    callback_url = "https://your-domain.com/chapa/callback", // Replace with your callback URL
                    return_url = "https://your-domain.com/payment-success", // Replace with your success page
                    customization = new
                    {
                        title = "House Rental Payment",
                        description = $"Rent payment for {RentDate:MMMM yyyy}"
                    }
                };
                
                string json = JsonConvert.SerializeObject(requestData, Formatting.Indented);
                txtDebugInfo.AppendText($"\nRequest JSON:\n{json}\n");
                
                using (var client = new HttpClient())
                {
                    // Configure HTTP client
                    client.Timeout = TimeSpan.FromSeconds(30);
                    client.DefaultRequestHeaders.Clear();
                    
                    // Add Authorization header - CRITICAL STEP
                    txtDebugInfo.AppendText($"\nAdding Authorization header...\n");
                    txtDebugInfo.AppendText($"API Key starts with: {chapaApiKey.Substring(0, Math.Min(15, chapaApiKey.Length))}...\n");
                    
                    // Method 1: Try with Bearer prefix (most common)
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {chapaApiKey}");
                    
                    // Also add content type
                    client.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    
                    txtDebugInfo.AppendText($"\nSending POST to: https://api.chapa.co/v1/transaction/initialize\n");
                    
                    HttpResponseMessage response;
                    string responseBody = "";
                    
                    try
                    {
                        response = await client.PostAsync(
                            "https://api.chapa.co/v1/transaction/initialize", 
                            content);
                        
                        responseBody = await response.Content.ReadAsStringAsync();
                    }
                    catch (Exception ex)
                    {
                        txtDebugInfo.AppendText($"\n❌ Network Error: {ex.Message}\n");
                        if (ex.InnerException != null)
                        {
                            txtDebugInfo.AppendText($"Inner Exception: {ex.InnerException.Message}\n");
                        }
                        
                        MessageBox.Show($"Network error: {ex.Message}\n\nCheck your internet connection.",
                            "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    txtDebugInfo.AppendText($"\n=== Response Received ===\n");
                    txtDebugInfo.AppendText($"Status Code: {(int)response.StatusCode} {response.StatusCode}\n");
                    txtDebugInfo.AppendText($"Response Body:\n{responseBody}\n");
                    
                    if (response.IsSuccessStatusCode)
                    {
                        try
                        {
                            dynamic result = JsonConvert.DeserializeObject(responseBody);
                            
                            if (result.status == "success")
                            {
                                string checkoutUrl = result.data.checkout_url;
                                
                                txtTxRef.Text = currentTxRef;
                                txtCheckoutUrl.Text = checkoutUrl;
                                
                                btnOpenBrowser.Enabled = true;
                                btnConfirm.Enabled = true;
                                
                                txtDebugInfo.AppendText($"\n✅ Payment initialized successfully!\n");
                                txtDebugInfo.AppendText($"Checkout URL: {checkoutUrl}\n");
                                
                                MessageBox.Show("Payment initialized successfully!\n\n" +
                                    "Transaction Reference: " + currentTxRef + "\n" +
                                    "Click 'Open Payment Page' to proceed.",
                                    "Success", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                txtDebugInfo.AppendText($"\n❌ API returned error status\n");
                                string errorMsg = result.message ?? "Unknown error";
                                MessageBox.Show($"Payment failed: {errorMsg}", 
                                    "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception jsonEx)
                        {
                            txtDebugInfo.AppendText($"\n❌ JSON Parse Error: {jsonEx.Message}\n");
                            MessageBox.Show($"Error parsing response: {jsonEx.Message}", 
                                "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        // 401 Unauthorized - API key issue
                        txtDebugInfo.AppendText($"\n❌ 401 UNAUTHORIZED - API Key Rejected\n");
                        
                        string detailedError = "⚠️ API KEY ERROR (401 Unauthorized)\n\n" +
                            "Your API key was rejected by Chapa.\n\n" +
                            "POSSIBLE SOLUTIONS:\n" +
                            "1. Get a NEW API key from https://dashboard.chapa.co/\n" +
                            "2. Login → Settings → API Keys → Generate New Key\n" +
                            "3. Select 'Test Key' for testing\n" +
                            "4. Copy the ENTIRE key (starts with CHASECK_TEST-)\n" +
                            "5. Update the 'chapaApiKey' variable in PaymentForm.cs\n\n" +
                            $"Your current key starts with: {chapaApiKey.Substring(0, Math.Min(20, chapaApiKey.Length))}...\n\n" +
                            "NOTE: CHAPUBK_TEST- keys may not work. Get CHASECK_TEST- key instead.";
                        
                        MessageBox.Show(detailedError, 
                            "API Key Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // Other HTTP errors
                        txtDebugInfo.AppendText($"\n❌ HTTP Error: {(int)response.StatusCode}\n");
                        
                        try
                        {
                            dynamic errorObj = JsonConvert.DeserializeObject(responseBody);
                            string errorMsg = errorObj?.message ?? responseBody;
                            MessageBox.Show($"HTTP Error {(int)response.StatusCode}: {errorMsg}", 
                                "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch
                        {
                            MessageBox.Show($"HTTP Error {(int)response.StatusCode}: {responseBody}", 
                                "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                txtDebugInfo.AppendText($"\n❌ Unexpected Error: {ex.Message}\n");
                MessageBox.Show($"Unexpected error: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                if (!useTestMode)
                {
                    btnPayChapa.Enabled = true;
                }
            }
        }

        // ================= TEST PAYMENT MODE =================
        private async Task ProcessTestPayment()
        {
            txtDebugInfo.AppendText("\n=== TEST MODE ACTIVATED ===\n");
            txtDebugInfo.AppendText("Simulating payment process...\n");
            
            await Task.Delay(1000); // Simulate API call delay
            
            currentTxRef = $"TEST_{DateTime.Now:yyyyMMddHHmmss}_{Guid.NewGuid().ToString("N").Substring(0, 6)}";
            txtTxRef.Text = currentTxRef;
            txtCheckoutUrl.Text = "https://sandbox.chapa.co/checkout/test-payment";
            
            btnOpenBrowser.Enabled = true;
            btnConfirm.Enabled = true;
            
            txtDebugInfo.AppendText($"\n✅ Test payment initialized!\n");
            txtDebugInfo.AppendText($"Transaction Ref: {currentTxRef}\n");
            txtDebugInfo.AppendText($"This is a simulation - no real payment will be made.\n");
            
            MessageBox.Show("TEST MODE: Payment simulation created.\n\n" +
                "Transaction Reference: " + currentTxRef + "\n" +
                "Click 'Open Payment Page' then 'Confirm Payment' to simulate success.",
                "Test Mode", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            btnPayChapa.Enabled = false; // Disable pay button in test mode
        }

        // ================= OPEN PAYMENT PAGE =================
        private void btnOpenBrowser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCheckoutUrl.Text))
            {
                MessageBox.Show("No checkout URL available. Please initialize payment first.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                txtDebugInfo.AppendText($"\nOpening browser with URL: {txtCheckoutUrl.Text}\n");
                
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = txtCheckoutUrl.Text,
                    UseShellExecute = true
                });
                
                MessageBox.Show("Payment page opened in your default browser.\n\n" +
                    "INSTRUCTIONS:\n" +
                    "1. Complete the payment in the browser\n" +
                    "2. Use test card: 4242 4242 4242 4242\n" +
                    "3. Any future expiry date\n" +
                    "4. Any 3-digit CVV\n" +
                    "5. OTP: 123456 (if asked)\n" +
                    "6. Return to this window and click 'Confirm Payment'",
                    "Payment Page Opened", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                txtDebugInfo.AppendText($"\n❌ Browser Error: {ex.Message}\n");
                MessageBox.Show($"Could not open browser: {ex.Message}\n\n" +
                    $"Please manually visit:\n{txtCheckoutUrl.Text}",
                    "Browser Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ================= CONFIRM PAYMENT =================
        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTxRef.Text))
            {
                MessageBox.Show("No transaction to verify. Please initialize payment first.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                btnConfirm.Enabled = false;
                Cursor = Cursors.WaitCursor;
                
                txtDebugInfo.AppendText($"\n=== Verifying Payment ===\n");
                txtDebugInfo.AppendText($"Transaction Ref: {txtTxRef.Text}\n");
                txtDebugInfo.AppendText($"Time: {DateTime.Now:HH:mm:ss}\n");
                
                if (useTestMode)
                {
                    // Test mode verification
                    await Task.Delay(1000); // Simulate API delay
                    
                    txtDebugInfo.AppendText($"\n✅ TEST PAYMENT VERIFIED SUCCESSFULLY!\n");
                    txtDebugInfo.AppendText($"Amount: {Amount:N2} ETB\n");
                    txtDebugInfo.AppendText($"Status: Success (Test Mode)\n");
                    
                    MessageBox.Show($"✅ TEST PAYMENT SUCCESSFUL!\n\n" +
                        $"Transaction: {txtTxRef.Text}\n" +
                        $"Amount: {Amount:N2} ETB\n" +
                        $"Status: Simulated Success\n\n" +
                        $"In production, this would verify with Chapa API.",
                        "Test Payment Complete", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Update database
                    UpdatePaymentRecord(txtTxRef.Text, true, Amount, "Test Mode");
                    
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }
                
                // Real verification
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(30);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {chapaApiKey}");
                    
                    txtDebugInfo.AppendText($"Sending GET to: https://api.chapa.co/v1/transaction/verify/{txtTxRef.Text}\n");
                    
                    var response = await client.GetAsync(
                        $"https://api.chapa.co/v1/transaction/verify/{txtTxRef.Text}");
                    
                    string responseBody = await response.Content.ReadAsStringAsync();
                    
                    txtDebugInfo.AppendText($"\n=== Verification Response ===\n");
                    txtDebugInfo.AppendText($"Status Code: {(int)response.StatusCode} {response.StatusCode}\n");
                    txtDebugInfo.AppendText($"Response:\n{responseBody}\n");
                    
                    if (response.IsSuccessStatusCode)
                    {
                        try
                        {
                            dynamic result = JsonConvert.DeserializeObject(responseBody);
                            
                            if (result.status == "success" && result.data.status == "success")
                            {
                                // PAYMENT SUCCESSFUL
                                txtDebugInfo.AppendText($"\n✅ PAYMENT VERIFIED SUCCESSFULLY!\n");
                                
                                string successMessage = $"✅ PAYMENT SUCCESSFUL!\n\n" +
                                    $"Transaction: {result.data.tx_ref}\n" +
                                    $"Amount: {Amount:N2} ETB\n" +
                                    $"Status: {result.data.status}\n" +
                                    $"Date: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n\n" +
                                    $"The payment has been confirmed and verified!";
                                
                                MessageBox.Show(successMessage,
                                    "Payment Verified", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                
                                // Update database
                                UpdatePaymentRecord(txtTxRef.Text, true, Amount, "Paid");
                                
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else if (result.data?.status == "pending")
                            {
                                txtDebugInfo.AppendText($"\n⚠️ Payment still pending\n");
                                MessageBox.Show("Payment is still pending.\n\n" +
                                    "Please complete the payment in the browser and try again.",
                                    "Payment Pending", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                btnConfirm.Enabled = true;
                            }
                            else
                            {
                                txtDebugInfo.AppendText($"\n❌ Payment verification failed\n");
                                string errorMsg = result.message ?? "Unknown error";
                                MessageBox.Show($"Payment verification failed: {errorMsg}",
                                    "Verification Failed", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                btnConfirm.Enabled = true;
                            }
                        }
                        catch (Exception jsonEx)
                        {
                            txtDebugInfo.AppendText($"\n❌ JSON Parse Error: {jsonEx.Message}\n");
                            MessageBox.Show($"Error parsing verification response: {jsonEx.Message}",
                                "Parse Error", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnConfirm.Enabled = true;
                        }
                    }
                    else
                    {
                        txtDebugInfo.AppendText($"\n❌ Verification HTTP Error: {(int)response.StatusCode}\n");
                        MessageBox.Show($"Verification failed with status: {response.StatusCode}\n\n{responseBody}",
                            "Verification Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnConfirm.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                txtDebugInfo.AppendText($"\n❌ Verification Error: {ex.Message}\n");
                MessageBox.Show($"Error verifying payment: {ex.Message}",
                    "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnConfirm.Enabled = true;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // ================= HELPER METHODS =================
        private string GenerateTransactionReference()
        {
            return $"RENT_{DateTime.Now:yyyyMMddHHmmss}_{Guid.NewGuid().ToString("N").Substring(0, 6)}";
        }

        private void UpdatePaymentRecord(string transactionRef, bool isSuccess, decimal amount, string status)
        {
            try
            {
                // TODO: Replace with your actual database update code
                // Example SQL:
                /*
                string connectionString = "YourConnectionString";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sql = @"INSERT INTO Payments 
                                 (TransactionRef, Amount, Status, PaymentDate, TenantId) 
                                 VALUES (@Ref, @Amount, @Status, @Date, @TenantId)";
                    
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ref", transactionRef);
                        cmd.Parameters.AddWithValue("@Amount", amount);
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@TenantId", GetCurrentTenantId());
                        
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                */
                
                // For now, log to file and debug window
                string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {transactionRef} | {amount:N2} ETB | {status}\n";
                
                // Append to log file
                System.IO.File.AppendAllText("payment_log.txt", logEntry);
                
                // Show in debug
                txtDebugInfo.AppendText($"\n📝 Database updated: {transactionRef} - {status}\n");
                txtDebugInfo.AppendText($"Log entry written to payment_log.txt\n");
                
            }
            catch (Exception ex)
            {
                txtDebugInfo.AppendText($"\n⚠️ Database update error: {ex.Message}\n");
                // Don't show error to user for logging failure
            }
        }

        // ================= BUTTON CLICK HANDLERS =================
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel this payment?", 
                "Confirm Cancel", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnCopyTxRef_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTxRef.Text))
            {
                Clipboard.SetText(txtTxRef.Text);
                txtDebugInfo.AppendText($"\n📋 Transaction reference copied to clipboard\n");
                MessageBox.Show("Transaction reference copied to clipboard.",
                    "Copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCopyUrl_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCheckoutUrl.Text))
            {
                Clipboard.SetText(txtCheckoutUrl.Text);
                txtDebugInfo.AppendText($"\n📋 Checkout URL copied to clipboard\n");
                MessageBox.Show("Checkout URL copied to clipboard.",
                    "Copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClearDebug_Click(object sender, EventArgs e)
        {
            txtDebugInfo.Clear();
            txtDebugInfo.AppendText("Debug information cleared.\n");
            txtDebugInfo.AppendText($"Current time: {DateTime.Now:HH:mm:ss}\n");
        }

        private void btnGetNewKey_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will open Chapa dashboard in your browser to get a new API key.\n\n" +
                "Do you want to continue?", 
                "Get New API Key", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    System.Diagnostics.Process.Start("https://dashboard.chapa.co/settings/api-keys");
                    MessageBox.Show("Chapa dashboard opened.\n\n" +
                        "INSTRUCTIONS:\n" +
                        "1. Login to your account\n" +
                        "2. Go to Settings → API Keys\n" +
                        "3. Click 'Generate New Key'\n" +
                        "4. Select 'Test Key'\n" +
                        "5. Copy the ENTIRE key\n" +
                        "6. Update the 'chapaApiKey' variable in PaymentForm.cs\n\n" +
                        "Your new key should start with: CHASECK_TEST-",
                        "Get API Key", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not open browser: {ex.Message}\n\n" +
                        "Please manually visit: https://dashboard.chapa.co/",
                        "Browser Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}