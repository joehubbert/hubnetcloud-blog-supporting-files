namespace CRM_WindowsForms.Presentation
{
    partial class ViewAllCustomer
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
            viewAllCustomerDataGridView = new DataGridView();
            viewAllCustomerTitleLabel = new Label();
            databaseConnectionSettingsBindingSource = new BindingSource(components);
            viewAllCustomerRefreshDataButton = new Button();
            ((System.ComponentModel.ISupportInitialize)viewAllCustomerDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).BeginInit();
            SuspendLayout();
            // 
            // viewAllCustomerDataGridView
            // 
            viewAllCustomerDataGridView.AllowUserToAddRows = false;
            viewAllCustomerDataGridView.AllowUserToDeleteRows = false;
            viewAllCustomerDataGridView.AllowUserToOrderColumns = true;
            viewAllCustomerDataGridView.AllowUserToResizeRows = false;
            viewAllCustomerDataGridView.BackgroundColor = Color.LightGreen;
            viewAllCustomerDataGridView.BorderStyle = BorderStyle.Fixed3D;
            viewAllCustomerDataGridView.ColumnHeadersHeight = 34;
            viewAllCustomerDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            viewAllCustomerDataGridView.Location = new Point(22, 66);
            viewAllCustomerDataGridView.Margin = new Padding(2);
            viewAllCustomerDataGridView.Name = "viewAllCustomerDataGridView";
            viewAllCustomerDataGridView.ReadOnly = true;
            viewAllCustomerDataGridView.RowHeadersWidth = 62;
            viewAllCustomerDataGridView.ShowEditingIcon = false;
            viewAllCustomerDataGridView.Size = new Size(1017, 303);
            viewAllCustomerDataGridView.TabIndex = 14;
            // 
            // viewAllCustomerTitleLabel
            // 
            viewAllCustomerTitleLabel.AutoSize = true;
            viewAllCustomerTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewAllCustomerTitleLabel.Location = new Point(12, 9);
            viewAllCustomerTitleLabel.Name = "viewAllCustomerTitleLabel";
            viewAllCustomerTitleLabel.Size = new Size(235, 32);
            viewAllCustomerTitleLabel.TabIndex = 13;
            viewAllCustomerTitleLabel.Text = "View All Customers";
            // 
            // databaseConnectionSettingsBindingSource
            // 
            databaseConnectionSettingsBindingSource.DataSource = typeof(Model.DatabaseConnectionSettings);
            // 
            // viewAllCustomerRefreshDataButton
            // 
            viewAllCustomerRefreshDataButton.FlatStyle = FlatStyle.Flat;
            viewAllCustomerRefreshDataButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            viewAllCustomerRefreshDataButton.Location = new Point(252, 7);
            viewAllCustomerRefreshDataButton.Margin = new Padding(2);
            viewAllCustomerRefreshDataButton.Name = "viewAllCustomerRefreshDataButton";
            viewAllCustomerRefreshDataButton.Size = new Size(201, 44);
            viewAllCustomerRefreshDataButton.TabIndex = 15;
            viewAllCustomerRefreshDataButton.Text = "Refresh Data";
            viewAllCustomerRefreshDataButton.UseVisualStyleBackColor = true;
            viewAllCustomerRefreshDataButton.Click += viewAllCustomerRefreshDataButton_Click;
            // 
            // ViewAllCustomer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGreen;
            ClientSize = new Size(1060, 401);
            Controls.Add(viewAllCustomerDataGridView);
            Controls.Add(viewAllCustomerTitleLabel);
            Controls.Add(viewAllCustomerRefreshDataButton);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "ViewAllCustomer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - View All Customers";
            ((System.ComponentModel.ISupportInitialize)viewAllCustomerDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView viewAllCustomerDataGridView;
        private Label viewAllCustomerTitleLabel;
        private BindingSource databaseConnectionSettingsBindingSource;
        private Button viewAllCustomerRefreshDataButton;
    }
}