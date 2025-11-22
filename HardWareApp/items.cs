using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardWareApp
{
    public partial class Items : Form
    {

        Functions Con; // Database helper class instance
        int key = 0;   // Stores selected items's ID
        public Items()
        {
            InitializeComponent();
            Con = new Functions();
            LoadItems(); // Load all items on form load
            LoadCategories();
            ItemsList.MultiSelect = false;
            ItemsList.EditMode = DataGridViewEditMode.EditProgrammatically; // Disable direct cell editing
        }

        private void items_Load(object sender, EventArgs e)
        {

        }

        private void LoadItems()
        {
            try
            {
                string query = "SELECT * FROM Items";
                ItemsList.DataSource = Con.GetData(query); // Bind data to DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading items: " + ex.Message);
            }
        }

        private void LoadCategories()
        {
            try
            {
                string query = "SELECT CategoryId, CategoryName FROM Categories";
                DataTable dt = Con.GetData(query); 

                CategoryCB.DataSource = dt;
                CategoryCB.DisplayMember = "CategoryName";
                CategoryCB.ValueMember = "CategoryId";
                CategoryCB.SelectedIndex = -1; // no preselection
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
        }





        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ItemsNameTB.Text)
                || string.IsNullOrWhiteSpace(ItemsDesc.Text)
                || string.IsNullOrWhiteSpace(ItemsPrice.Text)
                || string.IsNullOrWhiteSpace(ItemsQty.Text)
                || CategoryCB.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
                return;
            }

            try
            {
                string itemName = ItemsNameTB.Text.Trim();
                string description = ItemsDesc.Text.Trim();
                int categoryId = Convert.ToInt32(CategoryCB.SelectedValue); // assumes ComboBox is bound to CategoryId
                decimal price = Convert.ToDecimal(ItemsPrice.Text.Trim());
                int stockQty = Convert.ToInt32(ItemsQty.Text.Trim());

                string query = @"
            INSERT INTO Items (ItemName, CategoryId, Price, StockQuantity, ItemDescription) 
            VALUES (@Name, @Category, @Price, @StockQty, @Desc)";

                int result = Con.SetData(query,
                    new SqlParameter("@Name", itemName),
                    new SqlParameter("@Category", categoryId),
                    new SqlParameter("@Price", price),
                    new SqlParameter("@StockQty", stockQty),
                    new SqlParameter("@Desc", description)
                );

                if (result > 0)
                {
                    LoadItems(); // Refresh after insert
                    MessageBox.Show("Item added successfully!");
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("No item added. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding item: " + ex.Message);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select a Items to delete");
                return;
            }

            try
            {
                string query = "DELETE FROM Items WHERE ItemId = @Code";

                int result = Con.SetData(query,
                    new SqlParameter("@Code", key)
                );

                if (result > 0)
                {
                    LoadItems(); // Refresh after delete
                    MessageBox.Show("Items Deleted Successfully!");
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("No items deleted. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting item: " + ex.Message);
            }
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = ItemsList.Rows[e.RowIndex];

                    // Fill textboxes with selected row's data
                    ItemsNameTB.Text = row.Cells[1].Value?.ToString() ?? string.Empty;
                    ItemsDesc.Text = row.Cells[2].Value?.ToString() ?? string.Empty;
                    ItemsPrice.Text = row.Cells[3].Value?.ToString() ?? string.Empty;
                    CategoryCB.SelectedItem = row.Cells[3].Value?.ToString() ?? string.Empty;
                    ItemsQty.Text = row.Cells[5].Value?.ToString() ?? string.Empty;

                    // Store the selected customer's ID
                    key = int.TryParse(row.Cells[0].Value?.ToString(), out int id) ? id : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting items: " + ex.Message);
            }
        }


        private void label3_Click(object sender, EventArgs e)
        {

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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ItemsNameTB.Text)
                || string.IsNullOrWhiteSpace(ItemsDesc.Text)
                || string.IsNullOrWhiteSpace(ItemsPrice.Text)
                || string.IsNullOrWhiteSpace(ItemsQty.Text)
                || CategoryCB.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
                return;
            }

            try
            {
                string itemName = ItemsNameTB.Text.Trim();
                string description = ItemsDesc.Text.Trim();
                int categoryId = Convert.ToInt32(CategoryCB.SelectedValue); // assumes ComboBox is bound to Categories table
                decimal price = Convert.ToDecimal(ItemsPrice.Text.Trim());
                int stockQty = Convert.ToInt32(ItemsQty.Text.Trim());

                string query = @"
            UPDATE Items 
            SET ItemName = @Name, 
                CategoryId = @Category, 
                Price = @Price, 
                StockQuantity = @StockQty, 
                ItemDescription = @Desc 
            WHERE ItemId = @Id";

                int result = Con.SetData(query,
                    new SqlParameter("@Name", itemName),
                    new SqlParameter("@Category", categoryId),
                    new SqlParameter("@Price", price),
                    new SqlParameter("@StockQty", stockQty),
                    new SqlParameter("@Desc", description),
                    new SqlParameter("@Id", key)
                );

                if (result > 0)
                {
                    LoadItems(); // refresh DataGridView or List
                    MessageBox.Show("Item updated successfully!");
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("No item was updated. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating item: " + ex.Message);
            }
        }


        private void ClearFields()
        {
            ItemsNameTB.Clear();
            ItemsDesc.Clear();
            ItemsPrice.Clear();
            ItemsQty.Clear();
            CategoryCB.SelectedIndex = -1;
            key = 0;
        }





        private async void CustomerBtn_Click(object sender, EventArgs e)
        {
            Customers Obj = new Customers();

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

        private void pictureBox3_Click(object sender, EventArgs e)
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

        private void ItemsNameTB_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
