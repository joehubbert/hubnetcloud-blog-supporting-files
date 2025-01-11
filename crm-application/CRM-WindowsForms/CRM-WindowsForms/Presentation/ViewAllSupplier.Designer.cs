namespace CRM_WindowsForms.Presentation
{
    partial class ViewAllSupplier
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
            components = new System.ComponentModel.Container();
            viewAllSupplierDataGridView = new DataGridView();
            viewAllSupplierTitleLabel = new Label();
            databaseConnectionSettingsBindingSource = new BindingSource(components);
            viewAllSupplierRefreshDataButton = new Button();
            ((System.ComponentModel.ISupportInitialize)viewAllSupplierDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).BeginInit();
            SuspendLayout();
            // 
            // viewAllSupplierDataGridView
            // 
            viewAllSupplierDataGridView.AllowUserToAddRows = false;
            viewAllSupplierDataGridView.AllowUserToDeleteRows = false;
            viewAllSupplierDataGridView.AllowUserToOrderColumns = true;
            viewAllSupplierDataGridView.AllowUserToResizeRows = false;
            viewAllSupplierDataGridView.BackgroundColor = Color.MediumAquamarine;
            viewAllSupplierDataGridView.BorderStyle = BorderStyle.Fixed3D;
            viewAllSupplierDataGridView.ColumnHeadersHeight = 34;
            viewAllSupplierDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            viewAllSupplierDataGridView.Location = new Point(22, 66);
            viewAllSupplierDataGridView.Margin = new Padding(2);
            viewAllSupplierDataGridView.Name = "viewAllSupplierDataGridView";
            viewAllSupplierDataGridView.ReadOnly = true;
            viewAllSupplierDataGridView.RowHeadersWidth = 62;
            viewAllSupplierDataGridView.ShowEditingIcon = false;
            viewAllSupplierDataGridView.Size = new Size(1017, 303);
            viewAllSupplierDataGridView.TabIndex = 14;
            // 
            // viewAllSupplierTitleLabel
            // 
            viewAllSupplierTitleLabel.AutoSize = true;
            viewAllSupplierTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewAllSupplierTitleLabel.Location = new Point(12, 9);
            viewAllSupplierTitleLabel.Name = "viewAllSupplierTitleLabel";
            viewAllSupplierTitleLabel.Size = new Size(220, 32);
            viewAllSupplierTitleLabel.TabIndex = 13;
            viewAllSupplierTitleLabel.Text = "View All Suppliers";
            // 
            // databaseConnectionSettingsBindingSource
            // 
            databaseConnectionSettingsBindingSource.DataSource = typeof(Model.DatabaseConnectionSettings);
            // 
            // viewAllSupplierRefreshDataButton
            // 
            viewAllSupplierRefreshDataButton.FlatStyle = FlatStyle.Flat;
            viewAllSupplierRefreshDataButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            viewAllSupplierRefreshDataButton.Location = new Point(248, 7);
            viewAllSupplierRefreshDataButton.Margin = new Padding(2);
            viewAllSupplierRefreshDataButton.Name = "viewAllSupplierRefreshDataButton";
            viewAllSupplierRefreshDataButton.Size = new Size(201, 44);
            viewAllSupplierRefreshDataButton.TabIndex = 15;
            viewAllSupplierRefreshDataButton.Text = "Refresh Data";
            viewAllSupplierRefreshDataButton.UseVisualStyleBackColor = true;
            viewAllSupplierRefreshDataButton.Click += viewAllSupplierRefreshDataButton_Click;
            // 
            // ViewAllSupplier
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumAquamarine;
            ClientSize = new Size(1060, 401);
            Controls.Add(viewAllSupplierDataGridView);
            Controls.Add(viewAllSupplierTitleLabel);
            Controls.Add(viewAllSupplierRefreshDataButton);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "ViewAllSupplier";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - View All Suppliers";
            ((System.ComponentModel.ISupportInitialize)viewAllSupplierDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView viewAllSupplierDataGridView;
        private Label viewAllSupplierTitleLabel;
        private BindingSource databaseConnectionSettingsBindingSource;
        private Button viewAllSupplierRefreshDataButton;
    }
}