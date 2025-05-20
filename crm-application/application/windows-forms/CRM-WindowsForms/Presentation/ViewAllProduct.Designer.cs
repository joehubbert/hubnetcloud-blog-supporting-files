using CRM_WindowsForms.Interface;

namespace CRM_WindowsForms.Presentation
{
    partial class ViewAllProduct
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
            viewAllProductDataGridView = new DataGridView();
            viewAllProductTitleLabel = new Label();
            databaseConnectionSettingsBindingSource = new BindingSource(components);
            viewAllProductRefreshDataButton = new Button();
            ((System.ComponentModel.ISupportInitialize)viewAllProductDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).BeginInit();
            SuspendLayout();
            // 
            // viewAllProductDataGridView
            // 
            viewAllProductDataGridView.AllowUserToAddRows = false;
            viewAllProductDataGridView.AllowUserToDeleteRows = false;
            viewAllProductDataGridView.AllowUserToOrderColumns = true;
            viewAllProductDataGridView.AllowUserToResizeRows = false;
            viewAllProductDataGridView.BackgroundColor = Color.SkyBlue;
            viewAllProductDataGridView.BorderStyle = BorderStyle.Fixed3D;
            viewAllProductDataGridView.ColumnHeadersHeight = 34;
            viewAllProductDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            viewAllProductDataGridView.Location = new Point(22, 66);
            viewAllProductDataGridView.Margin = new Padding(2);
            viewAllProductDataGridView.Name = "viewAllProductDataGridView";
            viewAllProductDataGridView.ReadOnly = true;
            viewAllProductDataGridView.RowHeadersWidth = 62;
            viewAllProductDataGridView.ShowEditingIcon = false;
            viewAllProductDataGridView.Size = new Size(1017, 303);
            viewAllProductDataGridView.TabIndex = 14;
            // 
            // viewAllProductTitleLabel
            // 
            viewAllProductTitleLabel.AutoSize = true;
            viewAllProductTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewAllProductTitleLabel.Location = new Point(12, 9);
            viewAllProductTitleLabel.Name = "viewAllProductTitleLabel";
            viewAllProductTitleLabel.Size = new Size(216, 32);
            viewAllProductTitleLabel.TabIndex = 13;
            viewAllProductTitleLabel.Text = "View All Products";
            // 
            // databaseConnectionSettingsBindingSource
            // 
            databaseConnectionSettingsBindingSource.DataSource = typeof(DatabaseConnectionSettings);
            // 
            // viewAllProductRefreshDataButton
            // 
            viewAllProductRefreshDataButton.FlatStyle = FlatStyle.Flat;
            viewAllProductRefreshDataButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            viewAllProductRefreshDataButton.Location = new Point(248, 7);
            viewAllProductRefreshDataButton.Margin = new Padding(2);
            viewAllProductRefreshDataButton.Name = "viewAllProductRefreshDataButton";
            viewAllProductRefreshDataButton.Size = new Size(201, 44);
            viewAllProductRefreshDataButton.TabIndex = 15;
            viewAllProductRefreshDataButton.Text = "Refresh Data";
            viewAllProductRefreshDataButton.UseVisualStyleBackColor = true;
            viewAllProductRefreshDataButton.Click += ViewAllProductRefreshDataButton_Click;
            // 
            // ViewAllProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(1060, 401);
            Controls.Add(viewAllProductDataGridView);
            Controls.Add(viewAllProductTitleLabel);
            Controls.Add(viewAllProductRefreshDataButton);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "ViewAllProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - View All Products";
            ((System.ComponentModel.ISupportInitialize)viewAllProductDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView viewAllProductDataGridView;
        private Label viewAllProductTitleLabel;
        private BindingSource databaseConnectionSettingsBindingSource;
        private Button viewAllProductRefreshDataButton;
    }
}