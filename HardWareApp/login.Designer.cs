namespace HardWareApp
{
    partial class Login // Renamed from 'login' to 'Login' to fix CS8981
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panel1 = new Panel();
            label1 = new Label();
            NameTB = new Guna.UI2.WinForms.Guna2TextBox();
            PasswordTB = new Guna.UI2.WinForms.Guna2TextBox();
            LoginBtn = new Guna.UI2.WinForms.Guna2Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 70, 255);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 421);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F);
            label1.ForeColor = Color.FromArgb(0, 70, 255);
            label1.Location = new Point(291, 9);
            label1.Name = "label1";
            label1.Size = new Size(260, 25);
            label1.TabIndex = 1;
            label1.Text = "Hardware Management System";
            label1.Click += label1_Click;
            // 
            // NameTB
            // 
            NameTB.CustomizableEdges = customizableEdges1;
            NameTB.DefaultText = "";
            NameTB.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            NameTB.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            NameTB.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            NameTB.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            NameTB.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            NameTB.Font = new Font("Segoe UI", 9F);
            NameTB.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            NameTB.Location = new Point(238, 139);
            NameTB.Name = "NameTB";
            NameTB.PlaceholderText = "Enter Username....";
            NameTB.SelectedText = "";
            NameTB.ShadowDecoration.CustomizableEdges = customizableEdges2;
            NameTB.Size = new Size(353, 36);
            NameTB.TabIndex = 2;
            NameTB.TextChanged += guna2TextBox1_TextChanged;
            // 
            // PasswordTB
            // 
            PasswordTB.CustomizableEdges = customizableEdges3;
            PasswordTB.DefaultText = "";
            PasswordTB.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            PasswordTB.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            PasswordTB.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            PasswordTB.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            PasswordTB.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            PasswordTB.Font = new Font("Segoe UI", 9F);
            PasswordTB.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            PasswordTB.Location = new Point(238, 204);
            PasswordTB.Name = "PasswordTB";
            PasswordTB.PasswordChar = '*';
            PasswordTB.PlaceholderText = "Enter Password....";
            PasswordTB.SelectedText = "";
            PasswordTB.ShadowDecoration.CustomizableEdges = customizableEdges4;
            PasswordTB.Size = new Size(353, 36);
            PasswordTB.TabIndex = 3;
            PasswordTB.TextChanged += guna2TextBox2_TextChanged;
            // 
            // LoginBtn
            // 
            LoginBtn.BorderRadius = 14;
            LoginBtn.CustomizableEdges = customizableEdges5;
            LoginBtn.DisabledState.BorderColor = Color.DarkGray;
            LoginBtn.DisabledState.CustomBorderColor = Color.DarkGray;
            LoginBtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            LoginBtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            LoginBtn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LoginBtn.ForeColor = Color.White;
            LoginBtn.Location = new Point(312, 314);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.ShadowDecoration.CustomizableEdges = customizableEdges6;
            LoginBtn.Size = new Size(216, 43);
            LoginBtn.TabIndex = 4;
            LoginBtn.Text = "Login";
            LoginBtn.Click += LoginBtn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(581, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(33, 34);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(401, 60);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(47, 47);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(615, 421);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(LoginBtn);
            Controls.Add(PasswordTB);
            Controls.Add(NameTB);
            Controls.Add(label1);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "Login";
            Text = "login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Guna.UI2.WinForms.Guna2TextBox NameTB;
        private Guna.UI2.WinForms.Guna2TextBox PasswordTB;
        private Guna.UI2.WinForms.Guna2Button LoginBtn;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}