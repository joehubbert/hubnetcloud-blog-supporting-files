namespace CRM_WindowsForms.Presentation
{
    partial class ViewAllCustomerType
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
            viewAllCustomerTypeDataGridView = new DataGridView();
            viewAllCustomerTypeTitleLabel = new Label();
            databaseConnectionSettingsBindingSource = new BindingSource(components);
            viewAllCustomerTypeRefreshDataButton = new Button();
            ((System.ComponentModel.ISupportInitialize)viewAllCustomerTypeDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).BeginInit();
            SuspendLayout();
            // 
            // viewAllCustomerTypeDataGridView
            // 
            viewAllCustomerTypeDataGridView.AllowUserToAddRows = false;
            viewAllCustomerTypeDataGridView.AllowUserToDeleteRows = false;
            viewAllCustomerTypeDataGridView.AllowUserToOrderColumns = true;
            viewAllCustomerTypeDataGridView.AllowUserToResizeRows = false;
            viewAllCustomerTypeDataGridView.BackgroundColor = Color.Khaki;
            viewAllCustomerTypeDataGridView.BorderStyle = BorderStyle.Fixed3D;
            viewAllCustomerTypeDataGridView.ColumnHeadersHeight = 34;
            viewAllCustomerTypeDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            viewAllCustomerTypeDataGridView.Location = new Point(22, 66);
            viewAllCustomerTypeDataGridView.Margin = new Padding(2);
            viewAllCustomerTypeDataGridView.Name = "viewAllCustomerTypeDataGridView";
            viewAllCustomerTypeDataGridView.ReadOnly = true;
            viewAllCustomerTypeDataGridView.RowHeadersWidth = 62;
            viewAllCustomerTypeDataGridView.ShowEditingIcon = false;
            viewAllCustomerTypeDataGridView.Size = new Size(1017, 303);
            viewAllCustomerTypeDataGridView.TabIndex = 14;
            // 
            // viewAllCustomerTypeTitleLabel
            // 
            viewAllCustomerTypeTitleLabel.AutoSize = true;
            viewAllCustomerTypeTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewAllCustomerTypeTitleLabel.Location = new Point(12, 9);
            viewAllCustomerTypeTitleLabel.Name = "viewAllCustomerTypeTitleLabel";
            viewAllCustomerTypeTitleLabel.Size = new Size(296, 32);
            viewAllCustomerTypeTitleLabel.TabIndex = 13;
            viewAllCustomerTypeTitleLabel.Text = "View All Customer Types";
            // 
            // databaseConnectionSettingsBindingSource
            // 
            databaseConnectionSettingsBindingSource.DataSource = typeof(Model.DatabaseConnectionSettings);
            // 
            // viewAllCustomerTypeRefreshDataButton
            // 
            viewAllCustomerTypeRefreshDataButton.FlatStyle = FlatStyle.Flat;
            viewAllCustomerTypeRefreshDataButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            viewAllCustomerTypeRefreshDataButton.Location = new Point(326, 7);
            viewAllCustomerTypeRefreshDataButton.Margin = new Padding(2);
            viewAllCustomerTypeRefreshDataButton.Name = "viewAllCustomerTypeRefreshDataButton";
            viewAllCustomerTypeRefreshDataButton.Size = new Size(201, 44);
            viewAllCustomerTypeRefreshDataButton.TabIndex = 15;
            viewAllCustomerTypeRefreshDataButton.Text = "Refresh Data";
            viewAllCustomerTypeRefreshDataButton.UseVisualStyleBackColor = true;
            // 
            // ViewAllCustomerType
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Khaki;
            ClientSize = new Size(1060, 401);
            Controls.Add(viewAllCustomerTypeDataGridView);
            Controls.Add(viewAllCustomerTypeTitleLabel);
            Controls.Add(viewAllCustomerTypeRefreshDataButton);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "ViewAllCustomerType";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - View All Customer Types";
            ((System.ComponentModel.ISupportInitialize)viewAllCustomerTypeDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView viewAllCustomerTypeDataGridView;
        private Label viewAllCustomerTypeTitleLabel;
        private BindingSource databaseConnectionSettingsBindingSource;
        private Button viewAllCustomerTypeRefreshDataButton;
    }
}