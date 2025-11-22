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
    public partial class Categories_cs : Form
    {

        Functions Con; // Database helper class instance
        int key = 0;   // Stores selected categories's ID
        public Categories_cs()
        {
            InitializeComponent();
            Con = new Functions();
            LoadCategories(); // Load all categories on form load
            CategoryList.MultiSelect = false;
            CategoryList.EditMode = DataGridViewEditMode.EditProgrammatically; // Disable direct cell editing
        }

        private void LoadCategories()
        {
            try
            {
                string query = "SELECT * FROM Categories";
                CategoryList.DataSource = Con.GetData(query); // Bind data to DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Categories: " + ex.Message);
            }
        }




        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void Categories_cs_Load(object sender, EventArgs e)
        {

        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Handle button click here
        }



        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CatNameTB.Text) || string.IsNullOrWhiteSpace(CatDescTB.Text))
            {
                MessageBox.Show("Missing Information");
                return;
            }

            try
            {
                string categoryName = CatNameTB.Text.Trim();
                string categoryDesc = CatDescTB.Text.Trim();

                string query = "INSERT INTO Categories (CategoryName, CategoryDescription ) VALUES (@Name, @Description)";
                int result = Con.SetData(query,
                    new SqlParameter("@Name", categoryName),
                    new SqlParameter("@Description", categoryDesc)
                );

                if (result > 0)
                {
                    LoadCategories(); // Refresh list
                    MessageBox.Show("Category Added Successfully!");
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("No Category added. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding category: " + ex.Message);
            }
        }




        private void ClearFields()
        {
            CatNameTB.Clear();
            CatDescTB.Clear();
            key = 0;
        }




        private async void label5_Click(object sender, EventArgs e)
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


        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select a category to delete");
                return;
            }

            try
            {
                string query = "DELETE FROM Categories WHERE CategoryId  = @Code";

                int result = Con.SetData(query,
                    new SqlParameter("@Code", key)
                );

                if (result > 0)
                {
                    LoadCategories(); // Refresh after delete
                    MessageBox.Show("Category Deleted Successfully!");
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("No category deleted. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting category: " + ex.Message);
            }
        }

        private void EditBtn_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CatNameTB.Text) || string.IsNullOrWhiteSpace(CatDescTB.Text))
            {
                MessageBox.Show("Missing Information");
                return;
            }

            try
            {
                string categoryName = CatNameTB.Text.Trim();
                string categoryDesc = CatDescTB.Text.Trim();

                string query = "UPDATE Categories SET CategoryName = @Name, CategoryDescription = @Description WHERE CategoryId = @Code";


                int result = Con.SetData(query,
                    new SqlParameter("@Name", categoryName),
                    new SqlParameter("@Description", categoryDesc),
                    new SqlParameter("@Code", key)
                );

                if (result > 0)
                {
                    LoadCategories(); // Refresh after update
                    MessageBox.Show("Category Updated Successfully!");
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("No Category Updated. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating category: " + ex.Message);
            }
        }

        private void CategoryList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = CategoryList.Rows[e.RowIndex];

                    // Fill textboxes with selected row's data
                    CatNameTB.Text = row.Cells[1].Value?.ToString() ?? string.Empty;
                    CatDescTB.Text = row.Cells[2].Value?.ToString() ?? string.Empty;


                    // Store the selected category's ID
                    key = int.TryParse(row.Cells[0].Value?.ToString(), out int id) ? id : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting Category: " + ex.Message);
            }
        }

        private async void label3_Click(object sender, EventArgs e)
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

        private async void BillingBtn_Click(object sender, EventArgs e)
        {
            Billings Obj = new Billings();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
