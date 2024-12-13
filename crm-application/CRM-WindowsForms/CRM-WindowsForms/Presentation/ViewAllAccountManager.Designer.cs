namespace CRM_WindowsForms.Presentation
{
    partial class ViewAllAccountManager
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
            viewAllAccountManagerTitleLabel = new Label();
            viewAllAccountManagersDataGridView = new DataGridView();
            databaseConnectionSettingsBindingSource = new BindingSource(components);
            viewAllAccountManagerRefreshDataButton = new Button();
            ((System.ComponentModel.ISupportInitialize)viewAllAccountManagersDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).BeginInit();
            SuspendLayout();
            // 
            // viewAllAccountManagerTitleLabel
            // 
            viewAllAccountManagerTitleLabel.AutoSize = true;
            viewAllAccountManagerTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewAllAccountManagerTitleLabel.Location = new Point(22, 33);
            viewAllAccountManagerTitleLabel.Margin = new Padding(4, 0, 4, 0);
            viewAllAccountManagerTitleLabel.Name = "viewAllAccountManagerTitleLabel";
            viewAllAccountManagerTitleLabel.Size = new Size(481, 48);
            viewAllAccountManagerTitleLabel.TabIndex = 7;
            viewAllAccountManagerTitleLabel.Text = "View All Account Managers";
            // 
            // viewAllAccountManagersDataGridView
            // 
            viewAllAccountManagersDataGridView.AllowUserToAddRows = false;
            viewAllAccountManagersDataGridView.AllowUserToDeleteRows = false;
            viewAllAccountManagersDataGridView.AllowUserToOrderColumns = true;
            viewAllAccountManagersDataGridView.AllowUserToResizeRows = false;
            viewAllAccountManagersDataGridView.BackgroundColor = Color.Khaki;
            viewAllAccountManagersDataGridView.BorderStyle = BorderStyle.Fixed3D;
            viewAllAccountManagersDataGridView.ColumnHeadersHeight = 34;
            viewAllAccountManagersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            viewAllAccountManagersDataGridView.Location = new Point(22, 115);
            viewAllAccountManagersDataGridView.Name = "viewAllAccountManagersDataGridView";
            viewAllAccountManagersDataGridView.ReadOnly = true;
            viewAllAccountManagersDataGridView.RowHeadersWidth = 62;
            viewAllAccountManagersDataGridView.ShowEditingIcon = false;
            viewAllAccountManagersDataGridView.Size = new Size(1839, 1147);
            viewAllAccountManagersDataGridView.TabIndex = 8;
            // 
            // databaseConnectionSettingsBindingSource
            // 
            databaseConnectionSettingsBindingSource.DataSource = typeof(Model.DatabaseConnectionSettings);
            // 
            // viewAllAccountManagerRefreshDataButton
            // 
            viewAllAccountManagerRefreshDataButton.FlatStyle = FlatStyle.Flat;
            viewAllAccountManagerRefreshDataButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            viewAllAccountManagerRefreshDataButton.Location = new Point(544, 28);
            viewAllAccountManagerRefreshDataButton.Name = "viewAllAccountManagerRefreshDataButton";
            viewAllAccountManagerRefreshDataButton.Size = new Size(287, 72);
            viewAllAccountManagerRefreshDataButton.TabIndex = 9;
            viewAllAccountManagerRefreshDataButton.Text = "Refresh Data";
            viewAllAccountManagerRefreshDataButton.UseVisualStyleBackColor = true;
            viewAllAccountManagerRefreshDataButton.Click += viewAllAccountManagerRefreshDataButton_Click;
            // 
            // ViewAllAccountManager
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Khaki;
            ClientSize = new Size(1891, 1285);
            Controls.Add(viewAllAccountManagerRefreshDataButton);
            Controls.Add(viewAllAccountManagersDataGridView);
            Controls.Add(viewAllAccountManagerTitleLabel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "ViewAllAccountManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - View All Account Managers";
            ((System.ComponentModel.ISupportInitialize)viewAllAccountManagersDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label viewAllAccountManagerTitleLabel;
        private DataGridView viewAllAccountManagersDataGridView;
        private BindingSource databaseConnectionSettingsBindingSource;
        private Button viewAllAccountManagerRefreshDataButton;
    }
}