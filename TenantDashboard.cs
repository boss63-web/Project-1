using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HouseRentalSystem
{
    public partial class TenantDashboard : Form
    {
        public int TenantId; // SET THIS AFTER LOGIN

        private string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HouseRentalDB;Integrated Security=True";

        public TenantDashboard()
        {
            InitializeComponent();
        }

        // ================= FORM LOAD =================
        private void TenantDashboard_Load(object sender, EventArgs e)
        {
            LoadAvailableHouses();
        }

        // ================= LOAD AVAILABLE HOUSES =================
        private void LoadAvailableHouses()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = @"SELECT HouseId, Title, Location, Price, Status, ImagePath
                                     FROM Houses
                                     WHERE Status = 'Available'";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvHouses.DataSource = dt;

                    dgvHouses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvHouses.MultiSelect = false;
                    dgvHouses.ReadOnly = true;

                    dgvHouses.Columns["HouseId"].Visible = false;
                    dgvHouses.Columns["ImagePath"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading houses: " + ex.Message);
            }
        }

        // ================= VIEW BUTTON =================
        private void btnViewHouse_Click(object sender, EventArgs e)
        {
            LoadAvailableHouses();
        }

        // ================= SHOW HOUSE DETAILS =================
        private void dgvHouses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvHouses.Rows[e.RowIndex];

            lblTitle.Text = "Title: " + row.Cells["Title"].Value.ToString();
            lblLocation.Text = "Location: " + row.Cells["Location"].Value.ToString();
            lblPrice.Text = "Price: " + row.Cells["Price"].Value.ToString() + " ETB";
            lblStatus.Text = "Status: " + row.Cells["Status"].Value.ToString();

            string imagePath = row.Cells["ImagePath"].Value.ToString();

            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
            {
                using (var bmpTemp = new Bitmap(imagePath))
                {
                    picHouse.Image = new Bitmap(bmpTemp);
                }
                picHouse.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                picHouse.Image = null;
            }
        }

        // ================= RENT HOUSE =================
        private void btnRent_Click(object sender, EventArgs e)
        {
            if (dgvHouses.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a house first.");
                return;
            }

            DataGridViewRow row = dgvHouses.SelectedRows[0];
            int houseId = Convert.ToInt32(row.Cells["HouseId"].Value);

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Insert rental record
                    SqlCommand cmd = new SqlCommand(
                        @"INSERT INTO Rentals (HouseId, UserId, RentDate, PaymentStatus)
                          VALUES (@HouseId, @UserId, GETDATE(), 'Pending')", con);

                    cmd.Parameters.AddWithValue("@HouseId", houseId);
                    cmd.Parameters.AddWithValue("@UserId", TenantId);
                    cmd.ExecuteNonQuery();

                    // Update house status
                    SqlCommand cmd2 = new SqlCommand(
                        "UPDATE Houses SET Status='Rented' WHERE HouseId=@HouseId", con);

                    cmd2.Parameters.AddWithValue("@HouseId", houseId);
                    cmd2.ExecuteNonQuery();
                }

                // Open Payment Form
                PaymentForm pf = new PaymentForm();
                pf.RentDate = DateTime.Now;
                pf.ShowDialog();

                MessageBox.Show("House rented successfully! Please complete payment.");

                // Refresh list
                LoadAvailableHouses();

                // Clear UI
                picHouse.Image = null;
                lblTitle.Text = "Title:";
                lblLocation.Text = "Location:";
                lblPrice.Text = "Price:";
                lblStatus.Text = "Status:";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error renting house: " + ex.Message);
            }
        }

        // ================= LOGOUT =================
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoginForm login = new LoginForm();
                login.Show();
                this.Close();
            }
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
              "Are you sure you want to logout?",
              "Logout",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoginForm login = new LoginForm();
                login.Show();
                this.Close();
                    }
        }
    }
}
