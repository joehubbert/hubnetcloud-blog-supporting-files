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
            viewAllAccountManagerDataGridView = new DataGridView();
            databaseConnectionSettingsBindingSource = new BindingSource(components);
            viewAllAccountManagerRefreshDataButton = new Button();
            ((System.ComponentModel.ISupportInitialize)viewAllAccountManagerDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).BeginInit();
            SuspendLayout();
            // 
            // viewAllAccountManagerTitleLabel
            // 
            viewAllAccountManagerTitleLabel.AutoSize = true;
            viewAllAccountManagerTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewAllAccountManagerTitleLabel.Location = new Point(15, 20);
            viewAllAccountManagerTitleLabel.Name = "viewAllAccountManagerTitleLabel";
            viewAllAccountManagerTitleLabel.Size = new Size(329, 32);
            viewAllAccountManagerTitleLabel.TabIndex = 7;
            viewAllAccountManagerTitleLabel.Text = "View All Account Managers";
            // 
            // viewAllAccountManagerDataGridView
            // 
            viewAllAccountManagerDataGridView.AllowUserToAddRows = false;
            viewAllAccountManagerDataGridView.AllowUserToDeleteRows = false;
            viewAllAccountManagerDataGridView.AllowUserToOrderColumns = true;
            viewAllAccountManagerDataGridView.AllowUserToResizeRows = false;
            viewAllAccountManagerDataGridView.BackgroundColor = Color.LemonChiffon;
            viewAllAccountManagerDataGridView.BorderStyle = BorderStyle.Fixed3D;
            viewAllAccountManagerDataGridView.ColumnHeadersHeight = 34;
            viewAllAccountManagerDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            viewAllAccountManagerDataGridView.Location = new Point(15, 69);
            viewAllAccountManagerDataGridView.Margin = new Padding(2, 2, 2, 2);
            viewAllAccountManagerDataGridView.Name = "viewAllAccountManagerDataGridView";
            viewAllAccountManagerDataGridView.ReadOnly = true;
            viewAllAccountManagerDataGridView.RowHeadersWidth = 62;
            viewAllAccountManagerDataGridView.ShowEditingIcon = false;
            viewAllAccountManagerDataGridView.Size = new Size(1287, 688);
            viewAllAccountManagerDataGridView.TabIndex = 8;
            // 
            // databaseConnectionSettingsBindingSource
            // 
            databaseConnectionSettingsBindingSource.DataSource = typeof(Model.DatabaseConnectionSettings);
            // 
            // viewAllAccountManagerRefreshDataButton
            // 
            viewAllAccountManagerRefreshDataButton.FlatStyle = FlatStyle.Flat;
            viewAllAccountManagerRefreshDataButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            viewAllAccountManagerRefreshDataButton.Location = new Point(381, 17);
            viewAllAccountManagerRefreshDataButton.Margin = new Padding(2, 2, 2, 2);
            viewAllAccountManagerRefreshDataButton.Name = "viewAllAccountManagerRefreshDataButton";
            viewAllAccountManagerRefreshDataButton.Size = new Size(201, 43);
            viewAllAccountManagerRefreshDataButton.TabIndex = 9;
            viewAllAccountManagerRefreshDataButton.Text = "Refresh Data";
            viewAllAccountManagerRefreshDataButton.UseVisualStyleBackColor = true;
            viewAllAccountManagerRefreshDataButton.Click += ViewAllAccountManagerRefreshDataButton_Click;
            // 
            // ViewAllAccountManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1324, 634);
            Controls.Add(viewAllAccountManagerRefreshDataButton);
            Controls.Add(viewAllAccountManagerDataGridView);
            Controls.Add(viewAllAccountManagerTitleLabel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(2, 2, 2, 2);
            MaximizeBox = false;
            Name = "ViewAllAccountManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - View All Account Managers";
            ((System.ComponentModel.ISupportInitialize)viewAllAccountManagerDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label viewAllAccountManagerTitleLabel;
        private DataGridView viewAllAccountManagerDataGridView;
        private BindingSource databaseConnectionSettingsBindingSource;
        private Button viewAllAccountManagerRefreshDataButton;
    }
}