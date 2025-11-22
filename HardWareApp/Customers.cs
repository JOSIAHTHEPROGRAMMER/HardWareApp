using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HardWareApp
{
    public partial class Customers : Form
    {
        Functions Con; // Database helper class instance
        int key = 0;   // Stores selected customer's ID

        public Customers()
        {
            InitializeComponent();
            Con = new Functions();
            LoadCustomers(); // Load all customers on form load
            CustomersList.MultiSelect = false;
            CustomersList.EditMode = DataGridViewEditMode.EditProgrammatically; // Disable direct cell editing
        }

        // Reload customers manually (for testing or refresh)
        private void TestBtn_Click(object sender, EventArgs e)
        {
            try
            {
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message);
            }
        }

        // Load all customers from database
        private void LoadCustomers()
        {
            try
            {
                string query = "SELECT * FROM Customers";
                CustomersList.DataSource = Con.GetData(query); // Bind data to DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message);
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Currently not used
        }

        // Add new customer
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTB.Text) || string.IsNullOrWhiteSpace(PhoneTB.Text) || GenderCB.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
                return;
            }

            try
            {
                string customerName = NameTB.Text.Trim();
                string phone = PhoneTB.Text.Trim();
                string gender = GenderCB.SelectedItem.ToString();

                string query = "INSERT INTO Customers (CustomerName, Phone, Gender) VALUES (@Name, @Phone, @Gender)";
                int result = Con.SetData(query,
                    new SqlParameter("@Name", customerName),
                    new SqlParameter("@Phone", phone),
                    new SqlParameter("@Gender", gender)
                );

                if (result > 0)
                {
                    LoadCustomers(); // Refresh list
                    MessageBox.Show("Customer Added Successfully!");
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("No customer added. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding customer: " + ex.Message);
            }
        }

        // Handles row selection in DataGridView
        private void CustomersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = CustomersList.Rows[e.RowIndex];

                    // Fill textboxes with selected row's data
                    NameTB.Text = row.Cells[1].Value?.ToString() ?? string.Empty;
                    PhoneTB.Text = row.Cells[2].Value?.ToString() ?? string.Empty;
                    GenderCB.SelectedItem = row.Cells[3].Value?.ToString() ?? string.Empty;

                    // Store the selected customer's ID
                    key = int.TryParse(row.Cells[0].Value?.ToString(), out int id) ? id : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting customer: " + ex.Message);
            }
        }

        // Clears all input fields
        private void ClearFields()
        {
            NameTB.Clear();
            PhoneTB.Clear();
            GenderCB.SelectedIndex = -1;
            key = 0;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Not used
        }

        // Edit existing customer
        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTB.Text) || string.IsNullOrWhiteSpace(PhoneTB.Text) || GenderCB.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
                return;
            }

            try
            {
                string customerName = NameTB.Text.Trim();
                string phone = PhoneTB.Text.Trim();
                string gender = GenderCB.SelectedItem.ToString();

                string query = "UPDATE Customers SET CustomerName = @Name, Phone = @Phone, Gender = @Gender WHERE CustomerId = @Code";

                int result = Con.SetData(query,
                    new SqlParameter("@Name", customerName),
                    new SqlParameter("@Phone", phone),
                    new SqlParameter("@Gender", gender),
                    new SqlParameter("@Code", key)
                );

                if (result > 0)
                {
                    LoadCustomers(); // Refresh after update
                    MessageBox.Show("Customer Updated Successfully!");
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("No customer Updated. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating customer: " + ex.Message);
            }
        }

        // Delete selected customer
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select a customer to delete");
                return;
            }

            try
            {
                string query = "DELETE FROM Customers WHERE CustomerId = @Code";

                int result = Con.SetData(query,
                    new SqlParameter("@Code", key)
                );

                if (result > 0)
                {
                    LoadCustomers(); // Refresh after delete
                    MessageBox.Show("Customer Deleted Successfully!");
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("No customer deleted. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting customer: " + ex.Message);
            }
        }

        private async void label4_Click(object sender, EventArgs e)
        {

            Categories_cs Obj = new Categories_cs();

            Obj.StartPosition = FormStartPosition.Manual;
            Obj.Location = this.Location;
            Obj.Opacity = 0; // start transparent


            Obj.Show();
            this.Hide();

            while (Obj.Opacity < 1)
            {
                await Task.Delay(10);
                Obj.Opacity += 0.05;
            }
        }

        private void Customers_FormClosed_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void LogoutBtn_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.StartPosition = FormStartPosition.Manual;
            Obj.Location = this.Location;
            Obj.Opacity = 0; // start transparent

            Obj.Show();
            this.Hide();

            // Fade in effect
            while (Obj.Opacity < 1)
            {
                await Task.Delay(10);
                Obj.Opacity += 0.05;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private async void ItemsBtn_Click(object sender, EventArgs e)
        {
            Items Obj = new Items();

            Obj.StartPosition = FormStartPosition.Manual;
            Obj.Location = this.Location;
            Obj.Opacity = 0; // start transparent

            Obj.Show();
            this.Hide();

            // Fade in effect
            while (Obj.Opacity < 1)
            {
                await Task.Delay(10);
                Obj.Opacity += 0.05;
            }
        }

        private async void label6_Click(object sender, EventArgs e)
        {
            Billings Obj = new Billings();
            Obj.StartPosition = FormStartPosition.Manual;
            Obj.Location = this.Location;
            Obj.Opacity = 0; // start transparent

            Obj.Show();
            this.Hide();

            // Fade in effect
            while (Obj.Opacity < 1)
            {
                await Task.Delay(10);
                Obj.Opacity += 0.05;
            }
        }
    }
}
