namespace csharp_sandbox
{
    partial class DatabaseQueryEngine
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
            Navigation = new TabControl();
            orderManagement = new TabPage();
            customerManagement = new TabPage();
            productManagement = new TabPage();
            administration = new TabPage();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            Navigation.SuspendLayout();
            orderManagement.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // Navigation
            // 
            Navigation.Appearance = TabAppearance.FlatButtons;
            Navigation.Controls.Add(orderManagement);
            Navigation.Controls.Add(customerManagement);
            Navigation.Controls.Add(productManagement);
            Navigation.Controls.Add(administration);
            Navigation.Location = new Point(24, 12);
            Navigation.Multiline = true;
            Navigation.Name = "Navigation";
            Navigation.RightToLeft = RightToLeft.No;
            Navigation.SelectedIndex = 0;
            Navigation.Size = new Size(1534, 1012);
            Navigation.TabIndex = 0;
            // 
            // orderManagement
            // 
            orderManagement.BackColor = Color.LightSalmon;
            orderManagement.Controls.Add(tabControl1);
            orderManagement.ForeColor = SystemColors.ControlText;
            orderManagement.Location = new Point(4, 37);
            orderManagement.Name = "orderManagement";
            orderManagement.Size = new Size(1526, 971);
            orderManagement.TabIndex = 2;
            orderManagement.Text = "Order Management";
            // 
            // customerManagement
            // 
            customerManagement.BackColor = Color.PowderBlue;
            customerManagement.Location = new Point(4, 37);
            customerManagement.Name = "customerManagement";
            customerManagement.Padding = new Padding(3);
            customerManagement.Size = new Size(1526, 971);
            customerManagement.TabIndex = 0;
            customerManagement.Text = "Customer Management";
            // 
            // productManagement
            // 
            productManagement.BackColor = Color.PaleGreen;
            productManagement.Location = new Point(4, 37);
            productManagement.Name = "productManagement";
            productManagement.Padding = new Padding(3);
            productManagement.Size = new Size(1526, 971);
            productManagement.TabIndex = 1;
            productManagement.Text = "Product Management";
            // 
            // administration
            // 
            administration.BackColor = Color.NavajoWhite;
            administration.Location = new Point(4, 37);
            administration.Name = "administration";
            administration.Size = new Size(1526, 971);
            administration.TabIndex = 4;
            administration.Text = "Administration";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(16, 14);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1490, 938);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1482, 900);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(503, 357);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // DatabaseQueryEngine
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1581, 1036);
            Controls.Add(Navigation);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "DatabaseQueryEngine";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Database Query Engine";
            Navigation.ResumeLayout(false);
            orderManagement.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl Navigation;
        private TabPage customerManagement;
        private TabPage productManagement;
        private TabPage orderManagement;
        private TabPage administration;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
    }
}