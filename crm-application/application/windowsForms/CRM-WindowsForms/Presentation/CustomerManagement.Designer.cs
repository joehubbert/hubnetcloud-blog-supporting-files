namespace CRM_WindowsForms.Presentation
{
    partial class CustomerManagement
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
            customerManagementTitleLabel = new Label();
            customerManagementCreateCustomerButton = new Button();
            customerManagementViewAllCustomersButton = new Button();
            SuspendLayout();
            // 
            // customerManagementTitleLabel
            // 
            customerManagementTitleLabel.AutoSize = true;
            customerManagementTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            customerManagementTitleLabel.Location = new Point(13, 9);
            customerManagementTitleLabel.Margin = new Padding(4, 0, 4, 0);
            customerManagementTitleLabel.Name = "customerManagementTitleLabel";
            customerManagementTitleLabel.Size = new Size(282, 32);
            customerManagementTitleLabel.TabIndex = 7;
            customerManagementTitleLabel.Text = "Customer Management";
            // 
            // customerManagementCreateCustomerButton
            // 
            customerManagementCreateCustomerButton.FlatStyle = FlatStyle.Flat;
            customerManagementCreateCustomerButton.Font = new Font("Segoe UI", 11F);
            customerManagementCreateCustomerButton.Location = new Point(31, 76);
            customerManagementCreateCustomerButton.Margin = new Padding(4);
            customerManagementCreateCustomerButton.Name = "customerManagementCreateCustomerButton";
            customerManagementCreateCustomerButton.Size = new Size(212, 72);
            customerManagementCreateCustomerButton.TabIndex = 8;
            customerManagementCreateCustomerButton.Text = "Create Customer";
            customerManagementCreateCustomerButton.UseVisualStyleBackColor = true;
            customerManagementCreateCustomerButton.Click += customerManagementCreateCustomerButton_Click;
            // 
            // customerManagementViewAllCustomersButton
            // 
            customerManagementViewAllCustomersButton.FlatStyle = FlatStyle.Flat;
            customerManagementViewAllCustomersButton.Font = new Font("Segoe UI", 11F);
            customerManagementViewAllCustomersButton.Location = new Point(276, 76);
            customerManagementViewAllCustomersButton.Margin = new Padding(4);
            customerManagementViewAllCustomersButton.Name = "customerManagementViewAllCustomersButton";
            customerManagementViewAllCustomersButton.Size = new Size(212, 72);
            customerManagementViewAllCustomersButton.TabIndex = 9;
            customerManagementViewAllCustomersButton.Text = "View All Customers";
            customerManagementViewAllCustomersButton.UseVisualStyleBackColor = true;
            customerManagementViewAllCustomersButton.Click += customerManagementViewAllCustomersButton_Click;
            // 
            // CustomerManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGreen;
            ClientSize = new Size(532, 192);
            Controls.Add(customerManagementViewAllCustomersButton);
            Controls.Add(customerManagementCreateCustomerButton);
            Controls.Add(customerManagementTitleLabel);
            Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "CustomerManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - Customer Management";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label customerManagementTitleLabel;
        private Button customerManagementCreateCustomerButton;
        private Button customerManagementViewAllCustomersButton;
    }
}