namespace CRM_WindowsForms.Presentation
{
    partial class ProductManagement
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
            productManagementViewAllProductsButton = new Button();
            productManagementCreateProductButton = new Button();
            productManagementTitleLabel = new Label();
            SuspendLayout();
            // 
            // productManagementViewAllProductsButton
            // 
            productManagementViewAllProductsButton.FlatStyle = FlatStyle.Flat;
            productManagementViewAllProductsButton.Font = new Font("Segoe UI", 11F);
            productManagementViewAllProductsButton.Location = new Point(276, 76);
            productManagementViewAllProductsButton.Margin = new Padding(4);
            productManagementViewAllProductsButton.Name = "productManagementViewAllProductsButton";
            productManagementViewAllProductsButton.Size = new Size(212, 72);
            productManagementViewAllProductsButton.TabIndex = 12;
            productManagementViewAllProductsButton.Text = "View All Products";
            productManagementViewAllProductsButton.UseVisualStyleBackColor = true;
            productManagementViewAllProductsButton.Click += productManagementViewAllProductsButton_Click;
            // 
            // productManagementCreateProductButton
            // 
            productManagementCreateProductButton.FlatStyle = FlatStyle.Flat;
            productManagementCreateProductButton.Font = new Font("Segoe UI", 11F);
            productManagementCreateProductButton.Location = new Point(31, 76);
            productManagementCreateProductButton.Margin = new Padding(4);
            productManagementCreateProductButton.Name = "productManagementCreateProductButton";
            productManagementCreateProductButton.Size = new Size(212, 72);
            productManagementCreateProductButton.TabIndex = 11;
            productManagementCreateProductButton.Text = "Create Product";
            productManagementCreateProductButton.UseVisualStyleBackColor = true;
            productManagementCreateProductButton.Click += productManagementCreateProductButton_Click;
            // 
            // productManagementTitleLabel
            // 
            productManagementTitleLabel.AutoSize = true;
            productManagementTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            productManagementTitleLabel.Location = new Point(13, 9);
            productManagementTitleLabel.Margin = new Padding(4, 0, 4, 0);
            productManagementTitleLabel.Name = "productManagementTitleLabel";
            productManagementTitleLabel.Size = new Size(263, 32);
            productManagementTitleLabel.TabIndex = 10;
            productManagementTitleLabel.Text = "Product Management";
            // 
            // ProductManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(532, 192);
            Controls.Add(productManagementViewAllProductsButton);
            Controls.Add(productManagementCreateProductButton);
            Controls.Add(productManagementTitleLabel);
            Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "ProductManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - Product Management";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button productManagementViewAllProductsButton;
        private Button productManagementCreateProductButton;
        private Label productManagementTitleLabel;
    }
}