using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HouseRentalSystem
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        // ================= ADD HOUSE =================
        private void btnAddHouse_Click(object sender, EventArgs e)
        {
            AddHouseForm addHouseForm = new AddHouseForm();
            addHouseForm.ShowDialog();
        }

        // ================= VIEW HOUSES =================
        private void btnViewHouse_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HouseRentalDB;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = "SELECT HouseId, Title, Location, Price, Status, ImagePath FROM Houses";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Create a temporary form to display houses
                    Form viewForm = new Form();
                    viewForm.Text = "All Houses";
                    viewForm.Width = 800;
                    viewForm.Height = 400;

                    DataGridView dgv = new DataGridView();
                    dgv.DataSource = dt;
                    dgv.Dock = DockStyle.Fill;
                    dgv.ReadOnly = true;
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    viewForm.Controls.Add(dgv);
                    viewForm.StartPosition = FormStartPosition.CenterScreen;
                    viewForm.ShowDialog();

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading houses: " + ex.Message);
            }
        }

        // ================= LOGOUT =================
        

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
