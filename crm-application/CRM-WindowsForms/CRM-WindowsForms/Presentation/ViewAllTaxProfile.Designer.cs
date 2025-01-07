namespace CRM_WindowsForms.Presentation
{
    partial class ViewAllTaxProfile
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
            viewAllTaxProfileDataGridView = new DataGridView();
            viewAllTaxProfileTitleLabel = new Label();
            databaseConnectionSettingsBindingSource = new BindingSource(components);
            viewAllTaxProfileRefreshDataButton = new Button();
            ((System.ComponentModel.ISupportInitialize)viewAllTaxProfileDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).BeginInit();
            SuspendLayout();
            // 
            // viewAllTaxProfileDataGridView
            // 
            viewAllTaxProfileDataGridView.AllowUserToAddRows = false;
            viewAllTaxProfileDataGridView.AllowUserToDeleteRows = false;
            viewAllTaxProfileDataGridView.AllowUserToOrderColumns = true;
            viewAllTaxProfileDataGridView.AllowUserToResizeRows = false;
            viewAllTaxProfileDataGridView.BackgroundColor = Color.LemonChiffon;
            viewAllTaxProfileDataGridView.BorderStyle = BorderStyle.Fixed3D;
            viewAllTaxProfileDataGridView.ColumnHeadersHeight = 34;
            viewAllTaxProfileDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            viewAllTaxProfileDataGridView.Location = new Point(22, 66);
            viewAllTaxProfileDataGridView.Margin = new Padding(2);
            viewAllTaxProfileDataGridView.Name = "viewAllTaxProfileDataGridView";
            viewAllTaxProfileDataGridView.ReadOnly = true;
            viewAllTaxProfileDataGridView.RowHeadersWidth = 62;
            viewAllTaxProfileDataGridView.ShowEditingIcon = false;
            viewAllTaxProfileDataGridView.Size = new Size(1017, 303);
            viewAllTaxProfileDataGridView.TabIndex = 11;
            // 
            // viewAllTaxProfileTitleLabel
            // 
            viewAllTaxProfileTitleLabel.AutoSize = true;
            viewAllTaxProfileTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewAllTaxProfileTitleLabel.Location = new Point(12, 9);
            viewAllTaxProfileTitleLabel.Name = "viewAllTaxProfileTitleLabel";
            viewAllTaxProfileTitleLabel.Size = new Size(246, 32);
            viewAllTaxProfileTitleLabel.TabIndex = 10;
            viewAllTaxProfileTitleLabel.Text = "View All Tax Profiles";
            // 
            // databaseConnectionSettingsBindingSource
            // 
            databaseConnectionSettingsBindingSource.DataSource = typeof(Model.DatabaseConnectionSettings);
            // 
            // viewAllTaxProfileRefreshDataButton
            // 
            viewAllTaxProfileRefreshDataButton.FlatStyle = FlatStyle.Flat;
            viewAllTaxProfileRefreshDataButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            viewAllTaxProfileRefreshDataButton.Location = new Point(263, 7);
            viewAllTaxProfileRefreshDataButton.Margin = new Padding(2);
            viewAllTaxProfileRefreshDataButton.Name = "viewAllTaxProfileRefreshDataButton";
            viewAllTaxProfileRefreshDataButton.Size = new Size(201, 44);
            viewAllTaxProfileRefreshDataButton.TabIndex = 12;
            viewAllTaxProfileRefreshDataButton.Text = "Refresh Data";
            viewAllTaxProfileRefreshDataButton.UseVisualStyleBackColor = true;
            viewAllTaxProfileRefreshDataButton.Click += new EventHandler(viewAllTaxProfileRefreshDataButton_Click);
            // 
            // ViewAllTaxProfile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1060, 401);
            Controls.Add(viewAllTaxProfileDataGridView);
            Controls.Add(viewAllTaxProfileTitleLabel);
            Controls.Add(viewAllTaxProfileRefreshDataButton);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "ViewAllTaxProfile";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - View All Tax Profiles";
            ((System.ComponentModel.ISupportInitialize)viewAllTaxProfileDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView viewAllTaxProfileDataGridView;
        private Label viewAllTaxProfileTitleLabel;
        private BindingSource databaseConnectionSettingsBindingSource;
        private Button viewAllTaxProfileRefreshDataButton;
    }
}