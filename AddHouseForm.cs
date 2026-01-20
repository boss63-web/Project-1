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
    public partial class AddHouseForm : Form
    {
        public AddHouseForm()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picHouse.ImageLocation = ofd.FileName; // Show selected image
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string location = txtLocation.Text;
            decimal price;

            if (!decimal.TryParse(txtPrice.Text, out price))
            {
                MessageBox.Show("Please enter a valid price.");
                return;
            }

            string imagePath = picHouse.ImageLocation ?? "";

            // 2. Save to database
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HouseRentalDB;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Houses (Title, Location, Price, ImagePath, Status) VALUES (@Title, @Location, @Price, @ImagePath, 'Available')";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Location", location);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@ImagePath", imagePath);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("House added successfully!");

                    // Clear fields after saving
                    txtTitle.Clear();
                    txtLocation.Clear();
                    txtPrice.Clear();
                    picHouse.Image = null;
                }
            }
        }
    }
}
