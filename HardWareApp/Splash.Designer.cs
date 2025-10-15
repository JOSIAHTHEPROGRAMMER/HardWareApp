namespace HardWareApp
{
    partial class Splash
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            label1 = new Label();
            guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            guna2CircleProgressBar1 = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox1).BeginInit();
            guna2CircleProgressBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 24;
            guna2Elipse1.TargetControl = this;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F);
            label1.Location = new Point(209, 18);
            label1.Name = "label1";
            label1.Size = new Size(260, 25);
            label1.TabIndex = 0;
            label1.Text = "Hardware Management System";
            label1.Click += label1_Click;
            // 
            // guna2CirclePictureBox1
            // 
            guna2CirclePictureBox1.ImageRotate = 0F;
            guna2CirclePictureBox1.Location = new Point(227, 107);
            guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            guna2CirclePictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CirclePictureBox1.Size = new Size(194, 196);
            guna2CirclePictureBox1.TabIndex = 1;
            guna2CirclePictureBox1.TabStop = false;
            // 
            // guna2CircleProgressBar1
            // 
            guna2CircleProgressBar1.Controls.Add(pictureBox1);
            guna2CircleProgressBar1.FillColor = Color.White;
            guna2CircleProgressBar1.Font = new Font("Segoe UI", 12F);
            guna2CircleProgressBar1.ForeColor = Color.White;
            guna2CircleProgressBar1.Location = new Point(227, 107);
            guna2CircleProgressBar1.Minimum = 0;
            guna2CircleProgressBar1.Name = "guna2CircleProgressBar1";
            guna2CircleProgressBar1.ShadowDecoration.CustomizableEdges = customizableEdges1;
            guna2CircleProgressBar1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CircleProgressBar1.Size = new Size(196, 196);
            guna2CircleProgressBar1.TabIndex = 2;
            guna2CircleProgressBar1.Text = "guna2CircleProgressBar1";
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(470, 163);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(8, 8);
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(46, 56);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(106, 91);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // Splash
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 70, 255);
            ClientSize = new Size(636, 375);
            Controls.Add(pictureBox2);
            Controls.Add(guna2CircleProgressBar1);
            Controls.Add(guna2CirclePictureBox1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(245, 241, 220);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "Splash";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Splash_Load;
            ((System.ComponentModel.ISupportInitialize)guna2CirclePictureBox1).EndInit();
            guna2CircleProgressBar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Label label1;
        private Guna.UI2.WinForms.Guna2CircleProgressBar guna2CircleProgressBar1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
    }
}
