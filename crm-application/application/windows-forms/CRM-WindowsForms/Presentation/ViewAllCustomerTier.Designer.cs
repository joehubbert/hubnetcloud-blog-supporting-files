using CRM_WindowsForms.Interface;

namespace CRM_WindowsForms.Presentation
{
    partial class ViewAllCustomerTier
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
            viewAllCustomerTierDataGridView = new DataGridView();
            viewAllCustomerTierTitleLabel = new Label();
            databaseConnectionSettingsBindingSource = new BindingSource(components);
            viewAllCustomerTierRefreshDataButton = new Button();
            ((System.ComponentModel.ISupportInitialize)viewAllCustomerTierDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).BeginInit();
            SuspendLayout();
            // 
            // viewAllCustomerTierDataGridView
            // 
            viewAllCustomerTierDataGridView.AllowUserToAddRows = false;
            viewAllCustomerTierDataGridView.AllowUserToDeleteRows = false;
            viewAllCustomerTierDataGridView.AllowUserToOrderColumns = true;
            viewAllCustomerTierDataGridView.AllowUserToResizeRows = false;
            viewAllCustomerTierDataGridView.BackgroundColor = Color.LemonChiffon;
            viewAllCustomerTierDataGridView.BorderStyle = BorderStyle.Fixed3D;
            viewAllCustomerTierDataGridView.ColumnHeadersHeight = 34;
            viewAllCustomerTierDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            viewAllCustomerTierDataGridView.Location = new Point(22, 66);
            viewAllCustomerTierDataGridView.Margin = new Padding(2);
            viewAllCustomerTierDataGridView.Name = "viewAllCustomerTierDataGridView";
            viewAllCustomerTierDataGridView.ReadOnly = true;
            viewAllCustomerTierDataGridView.RowHeadersWidth = 62;
            viewAllCustomerTierDataGridView.ShowEditingIcon = false;
            viewAllCustomerTierDataGridView.Size = new Size(1017, 303);
            viewAllCustomerTierDataGridView.TabIndex = 11;
            // 
            // viewAllCustomerTierTitleLabel
            // 
            viewAllCustomerTierTitleLabel.AutoSize = true;
            viewAllCustomerTierTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewAllCustomerTierTitleLabel.Location = new Point(12, 9);
            viewAllCustomerTierTitleLabel.Name = "viewAllCustomerTierTitleLabel";
            viewAllCustomerTierTitleLabel.Size = new Size(286, 32);
            viewAllCustomerTierTitleLabel.TabIndex = 10;
            viewAllCustomerTierTitleLabel.Text = "View All Customer Tiers";
            // 
            // databaseConnectionSettingsBindingSource
            // 
            databaseConnectionSettingsBindingSource.DataSource = typeof(DatabaseConnectionSettings);
            // 
            // viewAllCustomerTierRefreshDataButton
            // 
            viewAllCustomerTierRefreshDataButton.FlatStyle = FlatStyle.Flat;
            viewAllCustomerTierRefreshDataButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            viewAllCustomerTierRefreshDataButton.Location = new Point(326, 7);
            viewAllCustomerTierRefreshDataButton.Margin = new Padding(2);
            viewAllCustomerTierRefreshDataButton.Name = "viewAllCustomerTierRefreshDataButton";
            viewAllCustomerTierRefreshDataButton.Size = new Size(201, 44);
            viewAllCustomerTierRefreshDataButton.TabIndex = 12;
            viewAllCustomerTierRefreshDataButton.Text = "Refresh Data";
            viewAllCustomerTierRefreshDataButton.UseVisualStyleBackColor = true;
            viewAllCustomerTierRefreshDataButton.Click += new EventHandler(ViewAllCustomerTierRefreshDataButton_Click);
            // 
            // ViewAllCustomerTier
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1060, 401);
            Controls.Add(viewAllCustomerTierDataGridView);
            Controls.Add(viewAllCustomerTierTitleLabel);
            Controls.Add(viewAllCustomerTierRefreshDataButton);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "ViewAllCustomerTier";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - View All Customer Tiers";
            ((System.ComponentModel.ISupportInitialize)viewAllCustomerTierDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView viewAllCustomerTierDataGridView;
        private Label viewAllCustomerTierTitleLabel;
        private BindingSource databaseConnectionSettingsBindingSource;
        private Button viewAllCustomerTierRefreshDataButton;
    }
}