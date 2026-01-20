namespace HouseRentalSystem
{
    partial class PaymentForm
    {
        private System.ComponentModel.IContainer components = null;

        // Labels
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Label lblOwner;
        private System.Windows.Forms.Label lblRentDate;
        private System.Windows.Forms.Label lblNextPay;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblTestMode;
        private System.Windows.Forms.Label lblApiKeyStatus;
        private System.Windows.Forms.Label lblTxRef;
        private System.Windows.Forms.Label lblCheckoutUrl;
        private System.Windows.Forms.Label lblDebugInfo;

        // TextBoxes
        private System.Windows.Forms.TextBox txtTxRef;
        private System.Windows.Forms.TextBox txtCheckoutUrl;
        private System.Windows.Forms.TextBox txtDebugInfo;

        // Buttons
        private System.Windows.Forms.Button btnPayChapa;
        private System.Windows.Forms.Button btnOpenBrowser;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCopyTxRef;
        private System.Windows.Forms.Button btnCopyUrl;
        private System.Windows.Forms.Button btnClearDebug;
        private System.Windows.Forms.Button btnGetNewKey;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentForm));
            this.lblInstruction = new System.Windows.Forms.Label();
            this.lblAccount = new System.Windows.Forms.Label();
            this.lblOwner = new System.Windows.Forms.Label();
            this.lblRentDate = new System.Windows.Forms.Label();
            this.lblNextPay = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblTestMode = new System.Windows.Forms.Label();
            this.lblApiKeyStatus = new System.Windows.Forms.Label();
            this.btnPayChapa = new System.Windows.Forms.Button();
            this.lblTxRef = new System.Windows.Forms.Label();
            this.txtTxRef = new System.Windows.Forms.TextBox();
            this.btnCopyTxRef = new System.Windows.Forms.Button();
            this.lblCheckoutUrl = new System.Windows.Forms.Label();
            this.txtCheckoutUrl = new System.Windows.Forms.TextBox();
            this.btnCopyUrl = new System.Windows.Forms.Button();
            this.btnOpenBrowser = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDebugInfo = new System.Windows.Forms.Label();
            this.txtDebugInfo = new System.Windows.Forms.TextBox();
            this.btnClearDebug = new System.Windows.Forms.Button();
            this.btnGetNewKey = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction.ForeColor = System.Drawing.Color.Navy;
            this.lblInstruction.Location = new System.Drawing.Point(20, 20);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(222, 24);
            this.lblInstruction.TabIndex = 0;
            this.lblInstruction.Text = "Chapa Payment Gateway";
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccount.Location = new System.Drawing.Point(20, 60);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(251, 15);
            this.lblAccount.TabIndex = 1;
            this.lblAccount.Text = "Test Mode: Using Chapa Test Environment";
            // 
            // lblOwner
            // 
            this.lblOwner.AutoSize = true;
            this.lblOwner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwner.Location = new System.Drawing.Point(20, 80);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Size = new System.Drawing.Size(438, 15);
            this.lblOwner.TabIndex = 2;
            this.lblOwner.Text = "Note: This is a test payment - no real money will be deducted from accounts";
            // 
            // lblRentDate
            // 
            this.lblRentDate.AutoSize = true;
            this.lblRentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRentDate.Location = new System.Drawing.Point(20, 110);
            this.lblRentDate.Name = "lblRentDate";
            this.lblRentDate.Size = new System.Drawing.Size(64, 15);
            this.lblRentDate.TabIndex = 3;
            this.lblRentDate.Text = "Rent Date:";
            // 
            // lblNextPay
            // 
            this.lblNextPay.AutoSize = true;
            this.lblNextPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextPay.Location = new System.Drawing.Point(20, 130);
            this.lblNextPay.Name = "lblNextPay";
            this.lblNextPay.Size = new System.Drawing.Size(96, 15);
            this.lblNextPay.TabIndex = 4;
            this.lblNextPay.Text = "Next Payment on:";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.ForeColor = System.Drawing.Color.Green;
            this.lblAmount.Location = new System.Drawing.Point(20, 160);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(134, 26);
            this.lblAmount.TabIndex = 5;
            this.lblAmount.Text = "Amount: 0.00";
            // 
            // lblTestMode
            // 
            this.lblTestMode.AutoSize = true;
            this.lblTestMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestMode.ForeColor = System.Drawing.Color.Red;
            this.lblTestMode.Location = new System.Drawing.Point(350, 20);
            this.lblTestMode.Name = "lblTestMode";
            this.lblTestMode.Size = new System.Drawing.Size(92, 17);
            this.lblTestMode.TabIndex = 6;
            this.lblTestMode.Text = "TEST MODE";
            this.lblTestMode.Visible = false;
            // 
            // lblApiKeyStatus
            // 
            this.lblApiKeyStatus.AutoSize = true;
            this.lblApiKeyStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApiKeyStatus.Location = new System.Drawing.Point(20, 195);
            this.lblApiKeyStatus.Name = "lblApiKeyStatus";
            this.lblApiKeyStatus.Size = new System.Drawing.Size(121, 15);
            this.lblApiKeyStatus.TabIndex = 7;
            this.lblApiKeyStatus.Text = "API Key Status: ...";
            // 
            // btnPayChapa
            // 
            this.btnPayChapa.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnPayChapa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayChapa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayChapa.ForeColor = System.Drawing.Color.White;
            this.btnPayChapa.Location = new System.Drawing.Point(20, 220);
            this.btnPayChapa.Name = "btnPayChapa";
            this.btnPayChapa.Size = new System.Drawing.Size(180, 40);
            this.btnPayChapa.TabIndex = 8;
            this.btnPayChapa.Text = "&1. Initialize Payment";
            this.btnPayChapa.UseVisualStyleBackColor = false;
            this.btnPayChapa.Click += new System.EventHandler(this.btnPayChapa_Click);
            // 
            // lblTxRef
            // 
            this.lblTxRef.AutoSize = true;
            this.lblTxRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxRef.Location = new System.Drawing.Point(20, 280);
            this.lblTxRef.Name = "lblTxRef";
            this.lblTxRef.Size = new System.Drawing.Size(139, 15);
            this.lblTxRef.TabIndex = 9;
            this.lblTxRef.Text = "Transaction Reference:";
            // 
            // txtTxRef
            // 
            this.txtTxRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTxRef.Location = new System.Drawing.Point(165, 277);
            this.txtTxRef.Name = "txtTxRef";
            this.txtTxRef.ReadOnly = true;
            this.txtTxRef.Size = new System.Drawing.Size(250, 21);
            this.txtTxRef.TabIndex = 10;
            // 
            // btnCopyTxRef
            // 
            this.btnCopyTxRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyTxRef.Location = new System.Drawing.Point(421, 277);
            this.btnCopyTxRef.Name = "btnCopyTxRef";
            this.btnCopyTxRef.Size = new System.Drawing.Size(60, 23);
            this.btnCopyTxRef.TabIndex = 11;
            this.btnCopyTxRef.Text = "Copy";
            this.btnCopyTxRef.UseVisualStyleBackColor = true;
            this.btnCopyTxRef.Click += new System.EventHandler(this.btnCopyTxRef_Click);
            // 
            // lblCheckoutUrl
            // 
            this.lblCheckoutUrl.AutoSize = true;
            this.lblCheckoutUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckoutUrl.Location = new System.Drawing.Point(20, 310);
            this.lblCheckoutUrl.Name = "lblCheckoutUrl";
            this.lblCheckoutUrl.Size = new System.Drawing.Size(83, 15);
            this.lblCheckoutUrl.TabIndex = 12;
            this.lblCheckoutUrl.Text = "Checkout URL:";
            // 
            // txtCheckoutUrl
            // 
            this.txtCheckoutUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckoutUrl.Location = new System.Drawing.Point(165, 307);
            this.txtCheckoutUrl.Name = "txtCheckoutUrl";
            this.txtCheckoutUrl.ReadOnly = true;
            this.txtCheckoutUrl.Size = new System.Drawing.Size(250, 21);
            this.txtCheckoutUrl.TabIndex = 13;
            // 
            // btnCopyUrl
            // 
            this.btnCopyUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyUrl.Location = new System.Drawing.Point(421, 307);
            this.btnCopyUrl.Name = "btnCopyUrl";
            this.btnCopyUrl.Size = new System.Drawing.Size(60, 23);
            this.btnCopyUrl.TabIndex = 14;
            this.btnCopyUrl.Text = "Copy";
            this.btnCopyUrl.UseVisualStyleBackColor = true;
            this.btnCopyUrl.Click += new System.EventHandler(this.btnCopyUrl_Click);
            // 
            // btnOpenBrowser
            // 
            this.btnOpenBrowser.BackColor = System.Drawing.Color.Orange;
            this.btnOpenBrowser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenBrowser.ForeColor = System.Drawing.Color.White;
            this.btnOpenBrowser.Location = new System.Drawing.Point(20, 340);
            this.btnOpenBrowser.Name = "btnOpenBrowser";
            this.btnOpenBrowser.Size = new System.Drawing.Size(180, 35);
            this.btnOpenBrowser.TabIndex = 15;
            this.btnOpenBrowser.Text = "&2. Open Payment Page";
            this.btnOpenBrowser.UseVisualStyleBackColor = false;
            this.btnOpenBrowser.Enabled = false;
            this.btnOpenBrowser.Click += new System.EventHandler(this.btnOpenBrowser_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.Green;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(210, 340);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(180, 35);
            this.btnConfirm.TabIndex = 16;
            this.btnConfirm.Text = "&3. Confirm Payment";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(400, 340);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 35);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblDebugInfo
            // 
            this.lblDebugInfo.AutoSize = true;
            this.lblDebugInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebugInfo.Location = new System.Drawing.Point(20, 390);
            this.lblDebugInfo.Name = "lblDebugInfo";
            this.lblDebugInfo.Size = new System.Drawing.Size(124, 15);
            this.lblDebugInfo.TabIndex = 18;
            this.lblDebugInfo.Text = "Debug Information:";
            // 
            // txtDebugInfo
            // 
            this.txtDebugInfo.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDebugInfo.Location = new System.Drawing.Point(20, 410);
            this.txtDebugInfo.Multiline = true;
            this.txtDebugInfo.Name = "txtDebugInfo";
            this.txtDebugInfo.ReadOnly = true;
            this.txtDebugInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDebugInfo.Size = new System.Drawing.Size(460, 120);
            this.txtDebugInfo.TabIndex = 19;
            // 
            // btnClearDebug
            // 
            this.btnClearDebug.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearDebug.Location = new System.Drawing.Point(400, 535);
            this.btnClearDebug.Name = "btnClearDebug";
            this.btnClearDebug.Size = new System.Drawing.Size(80, 25);
            this.btnClearDebug.TabIndex = 20;
            this.btnClearDebug.Text = "Clear Debug";
            this.btnClearDebug.UseVisualStyleBackColor = true;
            this.btnClearDebug.Click += new System.EventHandler(this.btnClearDebug_Click);
            // 
            // btnGetNewKey
            // 
            this.btnGetNewKey.BackColor = System.Drawing.Color.Purple;
            this.btnGetNewKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetNewKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetNewKey.ForeColor = System.Drawing.Color.White;
            this.btnGetNewKey.Location = new System.Drawing.Point(210, 220);
            this.btnGetNewKey.Name = "btnGetNewKey";
            this.btnGetNewKey.Size = new System.Drawing.Size(120, 40);
            this.btnGetNewKey.TabIndex = 21;
            this.btnGetNewKey.Text = "Get New API Key";
            this.btnGetNewKey.UseVisualStyleBackColor = false;
            this.btnGetNewKey.Click += new System.EventHandler(this.btnGetNewKey_Click);
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 570);
            this.Controls.Add(this.btnGetNewKey);
            this.Controls.Add(this.btnClearDebug);
            this.Controls.Add(this.txtDebugInfo);
            this.Controls.Add(this.lblDebugInfo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnOpenBrowser);
            this.Controls.Add(this.btnCopyUrl);
            this.Controls.Add(this.txtCheckoutUrl);
            this.Controls.Add(this.lblCheckoutUrl);
            this.Controls.Add(this.btnCopyTxRef);
            this.Controls.Add(this.txtTxRef);
            this.Controls.Add(this.lblTxRef);
            this.Controls.Add(this.btnPayChapa);
            this.Controls.Add(this.lblApiKeyStatus);
            this.Controls.Add(this.lblTestMode);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblNextPay);
            this.Controls.Add(this.lblRentDate);
            this.Controls.Add(this.lblOwner);
            this.Controls.Add(this.lblAccount);
            this.Controls.Add(this.lblInstruction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chapa Payment - House Rental System";
            this.Load += new System.EventHandler(this.PaymentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}