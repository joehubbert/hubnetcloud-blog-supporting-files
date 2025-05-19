namespace CRM_WindowsForms.Presentation
{
    partial class SupplierManagement
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
            supplierManagementViewAllSuppliersButton = new Button();
            supplierManagementCreateSupplierButton = new Button();
            supplierManagementTitleLabel = new Label();
            SuspendLayout();
            // 
            // supplierManagementViewAllSuppliersButton
            // 
            supplierManagementViewAllSuppliersButton.FlatStyle = FlatStyle.Flat;
            supplierManagementViewAllSuppliersButton.Font = new Font("Segoe UI", 11F);
            supplierManagementViewAllSuppliersButton.Location = new Point(276, 76);
            supplierManagementViewAllSuppliersButton.Margin = new Padding(4);
            supplierManagementViewAllSuppliersButton.Name = "supplierManagementViewAllSuppliersButton";
            supplierManagementViewAllSuppliersButton.Size = new Size(212, 72);
            supplierManagementViewAllSuppliersButton.TabIndex = 12;
            supplierManagementViewAllSuppliersButton.Text = "View All Suppliers";
            supplierManagementViewAllSuppliersButton.UseVisualStyleBackColor = true;
            supplierManagementViewAllSuppliersButton.Click += supplierManagementViewAllSuppliersButton_Click;
            // 
            // supplierManagementCreateSupplierButton
            // 
            supplierManagementCreateSupplierButton.FlatStyle = FlatStyle.Flat;
            supplierManagementCreateSupplierButton.Font = new Font("Segoe UI", 11F);
            supplierManagementCreateSupplierButton.Location = new Point(31, 76);
            supplierManagementCreateSupplierButton.Margin = new Padding(4);
            supplierManagementCreateSupplierButton.Name = "supplierManagementCreateSupplierButton";
            supplierManagementCreateSupplierButton.Size = new Size(212, 72);
            supplierManagementCreateSupplierButton.TabIndex = 11;
            supplierManagementCreateSupplierButton.Text = "Create Supplier";
            supplierManagementCreateSupplierButton.UseVisualStyleBackColor = true;
            supplierManagementCreateSupplierButton.Click += supplierManagementCreateSupplierButton_Click;
            // 
            // supplierManagementTitleLabel
            // 
            supplierManagementTitleLabel.AutoSize = true;
            supplierManagementTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            supplierManagementTitleLabel.Location = new Point(13, 9);
            supplierManagementTitleLabel.Margin = new Padding(4, 0, 4, 0);
            supplierManagementTitleLabel.Name = "supplierManagementTitleLabel";
            supplierManagementTitleLabel.Size = new Size(267, 32);
            supplierManagementTitleLabel.TabIndex = 10;
            supplierManagementTitleLabel.Text = "Supplier Management";
            // 
            // SupplierManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumAquamarine;
            ClientSize = new Size(532, 192);
            Controls.Add(supplierManagementViewAllSuppliersButton);
            Controls.Add(supplierManagementCreateSupplierButton);
            Controls.Add(supplierManagementTitleLabel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "SupplierManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - Supplier Management";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button supplierManagementViewAllSuppliersButton;
        private Button supplierManagementCreateSupplierButton;
        private Label supplierManagementTitleLabel;
    }
}