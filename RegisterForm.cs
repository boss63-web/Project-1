using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HouseRentalSystem
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (fullName == "" || username == "" || password == "")
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HouseRentalDB;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Check if username exists
                string check = "SELECT COUNT(*) FROM Users WHERE Username=@Username";
                SqlCommand cmdCheck = new SqlCommand(check, con);
                cmdCheck.Parameters.AddWithValue("@Username", username);
                int exists = (int)cmdCheck.ExecuteScalar();
                if (exists > 0)
                {
                    MessageBox.Show("Username already exists. Choose another.");
                    return;
                }

                // Insert new user as Tenant
                string query = "INSERT INTO Users (FullName, Username, Password, Role) VALUES (@FullName, @Username, @Password, 'Tenant')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Registration successful! You can now login.");

                this.Close(); // close register form
            }
        }
    }
}
