using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HouseRentalSystem
{
    public class ChapaService
    {
        private string _apiKey;
        private HttpClient _httpClient;

        public ChapaService(string apiKey)
        {
            _apiKey = apiKey;
            _httpClient = new HttpClient();

            // Configure HTTP client
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            _httpClient.Timeout = TimeSpan.FromSeconds(30);

            // Try different authentication headers
            if (_apiKey.StartsWith("Bearer "))
            {
                _httpClient.DefaultRequestHeaders.Add("Authorization", _apiKey);
            }
            else if (_apiKey.StartsWith("CHASECK_") || _apiKey.StartsWith("CHAPUBK_"))
            {
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
            }
            else
            {
                // Try as is
                _httpClient.DefaultRequestHeaders.Add("Authorization", _apiKey);
            }
        }

        public async Task<bool> ValidateApiKey()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://api.chapa.co/v1");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ChapaPaymentResponse> InitializePayment(decimal amount, string email,
            string firstName, string lastName, string customTxRef = null)
        {
            try
            {
                string txRef = customTxRef ?? $"TXN_{DateTime.Now:yyyyMMddHHmmss}_{Guid.NewGuid().ToString("N").Substring(0, 8)}";

                var request = new
                {
                    amount = amount.ToString("0.00"),
                    currency = "ETB",
                    email = email,
                    first_name = firstName,
                    last_name = lastName,
                    tx_ref = txRef,
                    callback_url = "https://yourdomain.com/callback",
                    return_url = "https://yourdomain.com/return",
                    customization = new
                    {
                        title = "House Rental Payment",
                        description = $"Rent payment - {DateTime.Now:MMMM yyyy}"
                    }
                };

                string json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(
                    "https://api.chapa.co/v1/transaction/initialize",
                    content);

                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<ChapaPaymentResponse>(responseBody);
                }
                else
                {
                    throw new Exception($"API Error ({response.StatusCode}): {responseBody}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Payment initialization failed: {ex.Message}", ex);
            }
        }

        public async Task<ChapaPaymentResponse> VerifyPayment(string transactionRef)
        {
            try
            {
                var response = await _httpClient.GetAsync(
                    $"https://api.chapa.co/v1/transaction/verify/{transactionRef}");

                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<ChapaPaymentResponse>(responseBody);
                }
                else
                {
                    throw new Exception($"Verification failed ({response.StatusCode}): {responseBody}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Payment verification failed: {ex.Message}", ex);
            }
        }
    }

    public class ChapaPaymentResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public PaymentData data { get; set; }
    }

    public class PaymentData
    {
        public string checkout_url { get; set; }
        public string tx_ref { get; set; }
        public string payment_url { get; set; }
        public string status { get; set; }
    }
}