namespace CRM_WindowsForms.Presentation
{
    partial class ViewAllSalesSubRegion
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
            viewAllSalesSubRegionDataGridView = new DataGridView();
            viewAllSalesSubRegionTitleLabel = new Label();
            databaseConnectionSettingsBindingSource = new BindingSource(components);
            viewAllSalesSubRegionRefreshDataButton = new Button();
            ((System.ComponentModel.ISupportInitialize)viewAllSalesSubRegionDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).BeginInit();
            SuspendLayout();
            // 
            // viewAllSalesSubRegionDataGridView
            // 
            viewAllSalesSubRegionDataGridView.AllowUserToAddRows = false;
            viewAllSalesSubRegionDataGridView.AllowUserToDeleteRows = false;
            viewAllSalesSubRegionDataGridView.AllowUserToOrderColumns = true;
            viewAllSalesSubRegionDataGridView.AllowUserToResizeRows = false;
            viewAllSalesSubRegionDataGridView.BackgroundColor = Color.LemonChiffon;
            viewAllSalesSubRegionDataGridView.BorderStyle = BorderStyle.Fixed3D;
            viewAllSalesSubRegionDataGridView.ColumnHeadersHeight = 34;
            viewAllSalesSubRegionDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            viewAllSalesSubRegionDataGridView.Location = new Point(22, 66);
            viewAllSalesSubRegionDataGridView.Margin = new Padding(2);
            viewAllSalesSubRegionDataGridView.Name = "viewAllSalesSubRegionDataGridView";
            viewAllSalesSubRegionDataGridView.ReadOnly = true;
            viewAllSalesSubRegionDataGridView.RowHeadersWidth = 62;
            viewAllSalesSubRegionDataGridView.ShowEditingIcon = false;
            viewAllSalesSubRegionDataGridView.Size = new Size(1119, 303);
            viewAllSalesSubRegionDataGridView.TabIndex = 14;
            // 
            // viewAllSalesSubRegionTitleLabel
            // 
            viewAllSalesSubRegionTitleLabel.AutoSize = true;
            viewAllSalesSubRegionTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewAllSalesSubRegionTitleLabel.Location = new Point(12, 9);
            viewAllSalesSubRegionTitleLabel.Name = "viewAllSalesSubRegionTitleLabel";
            viewAllSalesSubRegionTitleLabel.Size = new Size(319, 32);
            viewAllSalesSubRegionTitleLabel.TabIndex = 13;
            viewAllSalesSubRegionTitleLabel.Text = "View All Sales Sub Regions";
            // 
            // databaseConnectionSettingsBindingSource
            // 
            databaseConnectionSettingsBindingSource.DataSource = typeof(Model.DatabaseConnectionSettings);
            // 
            // viewAllSalesSubRegionRefreshDataButton
            // 
            viewAllSalesSubRegionRefreshDataButton.FlatStyle = FlatStyle.Flat;
            viewAllSalesSubRegionRefreshDataButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            viewAllSalesSubRegionRefreshDataButton.Location = new Point(336, 7);
            viewAllSalesSubRegionRefreshDataButton.Margin = new Padding(2);
            viewAllSalesSubRegionRefreshDataButton.Name = "viewAllSalesSubRegionRefreshDataButton";
            viewAllSalesSubRegionRefreshDataButton.Size = new Size(201, 44);
            viewAllSalesSubRegionRefreshDataButton.TabIndex = 15;
            viewAllSalesSubRegionRefreshDataButton.Text = "Refresh Data";
            viewAllSalesSubRegionRefreshDataButton.UseVisualStyleBackColor = true;
            viewAllSalesSubRegionRefreshDataButton.Click += ViewAllSalesSubRegionRefreshDataButton_Click;
            // 
            // ViewAllSalesSubRegion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1152, 401);
            Controls.Add(viewAllSalesSubRegionDataGridView);
            Controls.Add(viewAllSalesSubRegionTitleLabel);
            Controls.Add(viewAllSalesSubRegionRefreshDataButton);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "ViewAllSalesSubRegion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - View All Sales Sub Regions";
            ((System.ComponentModel.ISupportInitialize)viewAllSalesSubRegionDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView viewAllSalesSubRegionDataGridView;
        private Label viewAllSalesSubRegionTitleLabel;
        private BindingSource databaseConnectionSettingsBindingSource;
        private Button viewAllSalesSubRegionRefreshDataButton;
    }
}