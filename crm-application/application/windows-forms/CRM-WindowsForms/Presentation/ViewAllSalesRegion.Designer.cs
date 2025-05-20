using CRM_WindowsForms.Interface;

namespace CRM_WindowsForms.Presentation
{
    partial class ViewAllSalesRegion
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
            viewAllSalesRegionDataGridView = new DataGridView();
            viewAllSalesRegionTitleLabel = new Label();
            databaseConnectionSettingsBindingSource = new BindingSource(components);
            viewAllSalesRegionRefreshDataButton = new Button();
            ((System.ComponentModel.ISupportInitialize)viewAllSalesRegionDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).BeginInit();
            SuspendLayout();
            // 
            // viewAllSalesRegionDataGridView
            // 
            viewAllSalesRegionDataGridView.AllowUserToAddRows = false;
            viewAllSalesRegionDataGridView.AllowUserToDeleteRows = false;
            viewAllSalesRegionDataGridView.AllowUserToOrderColumns = true;
            viewAllSalesRegionDataGridView.AllowUserToResizeRows = false;
            viewAllSalesRegionDataGridView.BackgroundColor = Color.LemonChiffon;
            viewAllSalesRegionDataGridView.BorderStyle = BorderStyle.Fixed3D;
            viewAllSalesRegionDataGridView.ColumnHeadersHeight = 34;
            viewAllSalesRegionDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            viewAllSalesRegionDataGridView.Location = new Point(22, 66);
            viewAllSalesRegionDataGridView.Margin = new Padding(2);
            viewAllSalesRegionDataGridView.Name = "viewAllSalesRegionDataGridView";
            viewAllSalesRegionDataGridView.ReadOnly = true;
            viewAllSalesRegionDataGridView.RowHeadersWidth = 62;
            viewAllSalesRegionDataGridView.ShowEditingIcon = false;
            viewAllSalesRegionDataGridView.Size = new Size(1017, 303);
            viewAllSalesRegionDataGridView.TabIndex = 14;
            // 
            // viewAllSalesRegionTitleLabel
            // 
            viewAllSalesRegionTitleLabel.AutoSize = true;
            viewAllSalesRegionTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewAllSalesRegionTitleLabel.Location = new Point(12, 9);
            viewAllSalesRegionTitleLabel.Name = "viewAllSalesRegionTitleLabel";
            viewAllSalesRegionTitleLabel.Size = new Size(269, 32);
            viewAllSalesRegionTitleLabel.TabIndex = 13;
            viewAllSalesRegionTitleLabel.Text = "View All Sales Regions";
            // 
            // databaseConnectionSettingsBindingSource
            // 
            databaseConnectionSettingsBindingSource.DataSource = typeof(DatabaseConnectionSettings);
            // 
            // viewAllSalesRegionRefreshDataButton
            // 
            viewAllSalesRegionRefreshDataButton.FlatStyle = FlatStyle.Flat;
            viewAllSalesRegionRefreshDataButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            viewAllSalesRegionRefreshDataButton.Location = new Point(297, 7);
            viewAllSalesRegionRefreshDataButton.Margin = new Padding(2);
            viewAllSalesRegionRefreshDataButton.Name = "viewAllSalesRegionRefreshDataButton";
            viewAllSalesRegionRefreshDataButton.Size = new Size(201, 44);
            viewAllSalesRegionRefreshDataButton.TabIndex = 15;
            viewAllSalesRegionRefreshDataButton.Text = "Refresh Data";
            viewAllSalesRegionRefreshDataButton.UseVisualStyleBackColor = true;
            viewAllSalesRegionRefreshDataButton.Click += new EventHandler(ViewAllSalesRegionRefreshDataButton_Click);
            // 
            // ViewAllSalesRegion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1060, 401);
            Controls.Add(viewAllSalesRegionDataGridView);
            Controls.Add(viewAllSalesRegionTitleLabel);
            Controls.Add(viewAllSalesRegionRefreshDataButton);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "ViewAllSalesRegion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - View All Sales Regions";
            ((System.ComponentModel.ISupportInitialize)viewAllSalesRegionDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView viewAllSalesRegionDataGridView;
        private Label viewAllSalesRegionTitleLabel;
        private BindingSource databaseConnectionSettingsBindingSource;
        private Button viewAllSalesRegionRefreshDataButton;
    }
}