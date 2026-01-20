namespace HouseRentalSystem
{
    partial class AdminDashboard
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
            this.btnViewHouse = new System.Windows.Forms.Button();
            this.lblAdmin = new System.Windows.Forms.Label();
            this.btnAddHouse = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnViewHouse
            // 
            this.btnViewHouse.Font = new System.Drawing.Font("Felix Titling", 12.75F, System.Drawing.FontStyle.Bold);
            this.btnViewHouse.Location = new System.Drawing.Point(236, 184);
            this.btnViewHouse.Name = "btnViewHouse";
            this.btnViewHouse.Size = new System.Drawing.Size(120, 50);
            this.btnViewHouse.TabIndex = 0;
            this.btnViewHouse.Text = "View Houses";
            this.btnViewHouse.UseVisualStyleBackColor = true;
            this.btnViewHouse.Click += new System.EventHandler(this.btnViewHouse_Click);
            // 
            // lblAdmin
            // 
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.Font = new System.Drawing.Font("Felix Titling", 19.75F, System.Drawing.FontStyle.Bold);
            this.lblAdmin.Location = new System.Drawing.Point(87, 26);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(309, 32);
            this.lblAdmin.TabIndex = 1;
            this.lblAdmin.Text = "Admin Dashboard";
            // 
            // btnAddHouse
            // 
            this.btnAddHouse.Font = new System.Drawing.Font("Felix Titling", 12.75F, System.Drawing.FontStyle.Bold);
            this.btnAddHouse.Location = new System.Drawing.Point(83, 179);
            this.btnAddHouse.Name = "btnAddHouse";
            this.btnAddHouse.Size = new System.Drawing.Size(123, 55);
            this.btnAddHouse.TabIndex = 2;
            this.btnAddHouse.Text = "Add House";
            this.btnAddHouse.UseVisualStyleBackColor = true;
            this.btnAddHouse.Click += new System.EventHandler(this.btnAddHouse_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Felix Titling", 12.75F, System.Drawing.FontStyle.Bold);
            this.btnLogout.Location = new System.Drawing.Point(340, 346);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(107, 39);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click_1);
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HouseRentalSystem.Properties.Resources.admin;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(471, 397);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnAddHouse);
            this.Controls.Add(this.lblAdmin);
            this.Controls.Add(this.btnViewHouse);
            this.Name = "AdminDashboard";
            this.Text = "AdminDashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnViewHouse;
        private System.Windows.Forms.Label lblAdmin;
        private System.Windows.Forms.Button btnAddHouse;
        private System.Windows.Forms.Button btnLogout;
    }
}