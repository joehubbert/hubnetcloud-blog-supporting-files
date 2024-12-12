namespace CRM_WindowsForms.Presentation
{
    partial class Home
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
            homeNavOrderManagement = new Button();
            homeNavAppConfiguration = new Button();
            homeNavProductManagement = new Button();
            homeNavCompanyAdministration = new Button();
            homeNavCustomerManagement = new Button();
            homeTitleLabel = new Label();
            SuspendLayout();
            // 
            // homeNavOrderManagement
            // 
            homeNavOrderManagement.BackColor = Color.Salmon;
            homeNavOrderManagement.FlatStyle = FlatStyle.Flat;
            homeNavOrderManagement.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            homeNavOrderManagement.ForeColor = Color.Black;
            homeNavOrderManagement.Location = new Point(320, 167);
            homeNavOrderManagement.Margin = new Padding(4, 4, 4, 4);
            homeNavOrderManagement.Name = "homeNavOrderManagement";
            homeNavOrderManagement.Size = new Size(262, 106);
            homeNavOrderManagement.TabIndex = 0;
            homeNavOrderManagement.Text = "Order Management";
            homeNavOrderManagement.UseVisualStyleBackColor = false;
            homeNavOrderManagement.Click += homeNavOrderManagement_Click;
            // 
            // homeNavAppConfiguration
            // 
            homeNavAppConfiguration.BackColor = Color.MediumPurple;
            homeNavAppConfiguration.FlatStyle = FlatStyle.Flat;
            homeNavAppConfiguration.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            homeNavAppConfiguration.ForeColor = Color.Black;
            homeNavAppConfiguration.Location = new Point(911, 14);
            homeNavAppConfiguration.Margin = new Padding(4, 4, 4, 4);
            homeNavAppConfiguration.Name = "homeNavAppConfiguration";
            homeNavAppConfiguration.Size = new Size(262, 106);
            homeNavAppConfiguration.TabIndex = 1;
            homeNavAppConfiguration.Text = "App Configuration";
            homeNavAppConfiguration.UseVisualStyleBackColor = false;
            homeNavAppConfiguration.Click += homeNavAppConfiguration_Click;
            // 
            // homeNavProductManagement
            // 
            homeNavProductManagement.BackColor = Color.SkyBlue;
            homeNavProductManagement.FlatStyle = FlatStyle.Flat;
            homeNavProductManagement.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            homeNavProductManagement.ForeColor = Color.Black;
            homeNavProductManagement.Location = new Point(320, 311);
            homeNavProductManagement.Margin = new Padding(4, 4, 4, 4);
            homeNavProductManagement.Name = "homeNavProductManagement";
            homeNavProductManagement.Size = new Size(262, 106);
            homeNavProductManagement.TabIndex = 3;
            homeNavProductManagement.Text = "Product Management";
            homeNavProductManagement.UseVisualStyleBackColor = false;
            homeNavProductManagement.Click += homeNavProductManagement_Click;
            // 
            // homeNavCompanyAdministration
            // 
            homeNavCompanyAdministration.BackColor = Color.Khaki;
            homeNavCompanyAdministration.FlatStyle = FlatStyle.Flat;
            homeNavCompanyAdministration.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            homeNavCompanyAdministration.ForeColor = Color.Black;
            homeNavCompanyAdministration.Location = new Point(605, 311);
            homeNavCompanyAdministration.Margin = new Padding(4, 4, 4, 4);
            homeNavCompanyAdministration.Name = "homeNavCompanyAdministration";
            homeNavCompanyAdministration.Size = new Size(262, 106);
            homeNavCompanyAdministration.TabIndex = 4;
            homeNavCompanyAdministration.Text = "Company Administration";
            homeNavCompanyAdministration.UseVisualStyleBackColor = false;
            homeNavCompanyAdministration.Click += homeNavCompanyAdministration_Click;
            // 
            // homeNavCustomerManagement
            // 
            homeNavCustomerManagement.BackColor = Color.LightGreen;
            homeNavCustomerManagement.FlatStyle = FlatStyle.Flat;
            homeNavCustomerManagement.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            homeNavCustomerManagement.ForeColor = Color.Black;
            homeNavCustomerManagement.Location = new Point(605, 167);
            homeNavCustomerManagement.Margin = new Padding(4, 4, 4, 4);
            homeNavCustomerManagement.Name = "homeNavCustomerManagement";
            homeNavCustomerManagement.Size = new Size(262, 106);
            homeNavCustomerManagement.TabIndex = 5;
            homeNavCustomerManagement.Text = "Customer Management";
            homeNavCustomerManagement.UseVisualStyleBackColor = false;
            homeNavCustomerManagement.Click += homeNavCustomerManagement_Click;
            // 
            // homeTitleLabel
            // 
            homeTitleLabel.AutoSize = true;
            homeTitleLabel.Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point, 0);
            homeTitleLabel.Location = new Point(48, 37);
            homeTitleLabel.Margin = new Padding(4, 0, 4, 0);
            homeTitleLabel.Name = "homeTitleLabel";
            homeTitleLabel.Size = new Size(248, 60);
            homeTitleLabel.TabIndex = 6;
            homeTitleLabel.Text = "CRM Home";
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1187, 499);
            Controls.Add(homeTitleLabel);
            Controls.Add(homeNavCustomerManagement);
            Controls.Add(homeNavCompanyAdministration);
            Controls.Add(homeNavProductManagement);
            Controls.Add(homeNavAppConfiguration);
            Controls.Add(homeNavOrderManagement);
            Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4, 4, 4, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Home";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - Home";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button homeNavOrderManagement;
        private Button homeNavAppConfiguration;
        private Button homeNavProductManagement;
        private Button homeNavCompanyAdministration;
        private Button homeNavCustomerManagement;
        private Label homeTitleLabel;
    }
}