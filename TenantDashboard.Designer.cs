namespace HouseRentalSystem
{
    partial class TenantDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvHouses = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnRent = new System.Windows.Forms.Button();
            this.btnViewHouse = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.picHouse = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHouses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHouse)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHouses
            // 
            this.dgvHouses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHouses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHouses.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvHouses.Location = new System.Drawing.Point(0, 0);
            this.dgvHouses.MultiSelect = false;
            this.dgvHouses.Name = "dgvHouses";
            this.dgvHouses.ReadOnly = true;
            this.dgvHouses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHouses.Size = new System.Drawing.Size(257, 461);
            this.dgvHouses.TabIndex = 0;
            this.dgvHouses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHouses_CellClick);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(316, 257);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Title";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(316, 287);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(47, 13);
            this.lblLocation.TabIndex = 3;
            this.lblLocation.Text = "Location";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(316, 325);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(30, 13);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "Price";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(316, 361);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 13);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Status";
            // 
            // btnRent
            // 
            this.btnRent.Location = new System.Drawing.Point(368, 396);
            this.btnRent.Name = "btnRent";
            this.btnRent.Size = new System.Drawing.Size(75, 23);
            this.btnRent.TabIndex = 6;
            this.btnRent.Text = "Rent House";
            this.btnRent.UseVisualStyleBackColor = true;
            this.btnRent.Click += new System.EventHandler(this.btnRent_Click);
            // 
            // btnViewHouse
            // 
            this.btnViewHouse.Location = new System.Drawing.Point(635, 336);
            this.btnViewHouse.Name = "btnViewHouse";
            this.btnViewHouse.Size = new System.Drawing.Size(75, 23);
            this.btnViewHouse.TabIndex = 7;
            this.btnViewHouse.Text = "View";
            this.btnViewHouse.UseVisualStyleBackColor = true;
            this.btnViewHouse.Click += new System.EventHandler(this.btnViewHouse_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(662, 396);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click_1);
            // 
            // picHouse
            // 
            this.picHouse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picHouse.Location = new System.Drawing.Point(263, 0);
            this.picHouse.Name = "picHouse";
            this.picHouse.Size = new System.Drawing.Size(350, 250);
            this.picHouse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHouse.TabIndex = 1;
            this.picHouse.TabStop = false;
            // 
            // TenantDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnViewHouse);
            this.Controls.Add(this.btnRent);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.picHouse);
            this.Controls.Add(this.dgvHouses);
            this.Name = "TenantDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TenantDashboard";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHouses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHouse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHouses;
        private System.Windows.Forms.PictureBox picHouse;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnRent;
        private System.Windows.Forms.Button btnViewHouse;
        private System.Windows.Forms.Button btnLogout;
    }
}