using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardWareApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.AcceptButton = LoginBtn;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void LoginBtn_Click(object sender, EventArgs e)
        {
            if (NameTB.Text == "" && PasswordTB.Text == "")
            {
                MessageBox.Show("Missing Data");
            }
            else
            {
                try
                {
                    if (NameTB.Text == "Admin" && PasswordTB.Text == "Password")
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
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Username or Password");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }


            }
        }
    }
}