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
    public partial class Billings : Form
    {
        Functions Con; // Database helper class instance
        int key = 0;   // Stores selected billing ID
        int selectedItemId = 0; // Track which item was selected

        public Billings()
        {
            InitializeComponent();
            Con = new Functions();
            LoadBillings();
            GetCustomers();
            LoadItems();

            BillingList.MultiSelect = false;
            BillingList.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        // -----------------------------
        // Load Items
        // -----------------------------
        private void LoadItems()
        {
            try
            {
                string query = "SELECT ItemId, ItemName, Price, StockQuantity FROM Items";
                ItemsList.DataSource = Con.GetData(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading items: " + ex.Message);
            }
        }

        // -----------------------------
        // Load Billings
        // -----------------------------
        private void LoadBillings()
        {
            try
            {
                string query = "SELECT * FROM Billings";
                BillingList.DataSource = Con.GetData(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading billings: " + ex.Message);
            }
        }

        // -----------------------------
        // Load Customers
        // -----------------------------
        private void GetCustomers()
        {
            try
            {
                string query = "SELECT CustomerId, CustomerName FROM Customers";
                DataTable dt = Con.GetData(query);

                CustomerCB.DataSource = dt;
                CustomerCB.DisplayMember = "CustomerName";
                CustomerCB.ValueMember = "CustomerId";
                CustomerCB.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message);
            }
        }

        // -----------------------------
        // Add Billing
        // -----------------------------
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (CustomerCB.SelectedIndex == -1 ||
                selectedItemId == 0 ||
                string.IsNullOrWhiteSpace(ItemNameTB.Text) ||
                string.IsNullOrWhiteSpace(ItemPriceTB.Text) ||
                string.IsNullOrWhiteSpace(StockTB.Text) ||
                PaymentCB.SelectedIndex == -1)
            {
                MessageBox.Show("Missing information. Please fill all required fields.");
                return;
            }

            try
            {
                int customerId = Convert.ToInt32(CustomerCB.SelectedValue);
                decimal itemPrice = Convert.ToDecimal(ItemPriceTB.Text.Trim());
                int quantity = Convert.ToInt32(StockTB.Text.Trim());
                string paymentMethod = PaymentCB.Text.Trim();

                // Check stock before billing
                string stockQuery = "SELECT StockQuantity FROM Items WHERE ItemId = @ItemId";
                DataTable stockDT = Con.GetData(stockQuery, new SqlParameter("@ItemId", selectedItemId));

                if (stockDT.Rows.Count == 0)
                {
                    MessageBox.Show("Item not found in inventory.");
                    return;
                }

                int currentStock = Convert.ToInt32(stockDT.Rows[0]["StockQuantity"]);
                if (quantity > currentStock)
                {
                    MessageBox.Show($"Insufficient stock. Only {currentStock} available.");
                    return;
                }

                // Calculate total
                decimal totalAmount = itemPrice * quantity;

                // Insert billing
                string query = @"
                    INSERT INTO Billings (CustomerId, TotalAmount, PaymentMethod)
                    VALUES (@CustomerId, @TotalAmount, @PaymentMethod)";
                int result = Con.SetData(query,
                    new SqlParameter("@CustomerId", customerId),
                    new SqlParameter("@TotalAmount", totalAmount),
                    new SqlParameter("@PaymentMethod", paymentMethod)
                );

                // Deduct stock if billing was successful
                if (result > 0)
                {
                    string updateStockQuery = "UPDATE Items SET StockQuantity = StockQuantity - @Qty WHERE ItemId = @ItemId";
                    Con.SetData(updateStockQuery,
                        new SqlParameter("@Qty", quantity),
                        new SqlParameter("@ItemId", selectedItemId)
                    );

                    MessageBox.Show($"Billing added successfully! Total = ${totalAmount:F2}\nStock updated successfully.");
                    LoadBillings();
                    LoadItems();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("No billing record added. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding billing: " + ex.Message);
            }
        }

        // -----------------------------
        // Clear Fields
        // -----------------------------
        private void ClearFields()
        {
            CustomerCB.SelectedIndex = -1;
            ItemNameTB.Clear();
            ItemPriceTB.Clear();
            StockTB.Clear();
            PaymentCB.SelectedIndex = -1;
            selectedItemId = 0;
            key = 0;
        }

        // -----------------------------
        // Select Billing Row
        // -----------------------------
        private void BillingList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = BillingList.Rows[e.RowIndex];
                    key = Convert.ToInt32(row.Cells["BillingId"].Value);
                    CustomerCB.SelectedValue = row.Cells["CustomerId"].Value;
                    PaymentCB.Text = row.Cells["PaymentMethod"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting billing record: " + ex.Message);
            }
        }

        // -----------------------------
        // Select Item Row
        // -----------------------------
        private void ItemsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = ItemsList.Rows[e.RowIndex];

                    selectedItemId = Convert.ToInt32(row.Cells["ItemId"].Value);
                    ItemNameTB.Text = row.Cells["ItemName"].Value?.ToString() ?? string.Empty;
                    ItemPriceTB.Text = row.Cells["Price"].Value?.ToString() ?? string.Empty;
                    StockTB.Text = "1"; // default purchase quantity
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting items: " + ex.Message);
            }
        }

        // -----------------------------
        // Navigation and UI Methods
        // -----------------------------
        private void Category_FormClosed_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void ItemsBtn_Click(object sender, EventArgs e)
        {
            Items Obj = new Items();
            Obj.StartPosition = FormStartPosition.Manual;
            Obj.Location = this.Location;
            Obj.Opacity = 0;
            Obj.Show();
            this.Hide();

            while (Obj.Opacity < 1)
            {
                await Task.Delay(10);
                Obj.Opacity += 0.05;
            }
        }

        private async void label4_Click(object sender, EventArgs e)
        {
            Categories_cs Obj = new Categories_cs();
            Obj.StartPosition = FormStartPosition.Manual;
            Obj.Location = this.Location;
            Obj.Opacity = 0;
            Obj.Show();
            this.Hide();

            while (Obj.Opacity < 1)
            {
                await Task.Delay(10);
                Obj.Opacity += 0.05;
            }
        }

        private async void label5_Click(object sender, EventArgs e)
        {
            Customers Obj = new Customers();
            Obj.StartPosition = FormStartPosition.Manual;
            Obj.Location = this.Location;
            Obj.Opacity = 0;
            Obj.Show();
            this.Hide();

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
            Obj.Opacity = 0;
            Obj.Show();
            this.Hide();

            while (Obj.Opacity < 1)
            {
                await Task.Delay(10);
                Obj.Opacity += 0.05;
            }
        }

        private void BillingBtn_Click(object sender, EventArgs e) { }
        private void panel5_Paint(object sender, PaintEventArgs e) { }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void EditBtn_Click(object sender, EventArgs e) { }
        private void DeleteBtn_Click(object sender, EventArgs e) { }
    }
}


