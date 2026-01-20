using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HouseRentalSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HouseRentalDB;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT UserId, Role FROM Users WHERE Username=@Username AND Password=@Password";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = Convert.ToInt32(reader["UserId"]);
                                string role = reader["Role"].ToString();

                                if (role == "Admin")
                                {
                                    AdminDashboard admin = new AdminDashboard();
                                    this.ClearLoginFields();
                                    admin.Show();
                                   
                                }
                                else if (role == "Tenant")
                                {
                                    TenantDashboard tenant = new TenantDashboard();
                                    tenant.TenantId = userId; // Pass tenant ID to dashboard
                                    this.ClearLoginFields();
                                    tenant.Show();

                                    
                                }
                                else
                                {
                                    MessageBox.Show("Unknown role assigned to this user.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting to database: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Optional: clear fields
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }
        public void ClearLoginFields()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus(); // optional, cursor goes to username box
        }
    }
}
