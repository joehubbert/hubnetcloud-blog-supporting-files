using CRM_WindowsForms.Interface;

namespace CRM_WindowsForms.Presentation
{
    partial class ViewAllProductCategory
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
            viewAllProductCategoryDataGridView = new DataGridView();
            viewAllProductCategoryTitleLabel = new Label();
            databaseConnectionSettingsBindingSource = new BindingSource(components);
            viewAllProductCategoryRefreshDataButton = new Button();
            ((System.ComponentModel.ISupportInitialize)viewAllProductCategoryDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).BeginInit();
            SuspendLayout();
            // 
            // viewAllProductCategoryDataGridView
            // 
            viewAllProductCategoryDataGridView.AllowUserToAddRows = false;
            viewAllProductCategoryDataGridView.AllowUserToDeleteRows = false;
            viewAllProductCategoryDataGridView.AllowUserToOrderColumns = true;
            viewAllProductCategoryDataGridView.AllowUserToResizeRows = false;
            viewAllProductCategoryDataGridView.BackgroundColor = Color.LemonChiffon;
            viewAllProductCategoryDataGridView.BorderStyle = BorderStyle.Fixed3D;
            viewAllProductCategoryDataGridView.ColumnHeadersHeight = 34;
            viewAllProductCategoryDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            viewAllProductCategoryDataGridView.Location = new Point(22, 66);
            viewAllProductCategoryDataGridView.Margin = new Padding(2);
            viewAllProductCategoryDataGridView.Name = "viewAllProductCategoryDataGridView";
            viewAllProductCategoryDataGridView.ReadOnly = true;
            viewAllProductCategoryDataGridView.RowHeadersWidth = 62;
            viewAllProductCategoryDataGridView.ShowEditingIcon = false;
            viewAllProductCategoryDataGridView.Size = new Size(1017, 303);
            viewAllProductCategoryDataGridView.TabIndex = 14;
            // 
            // viewAllProductCategoryTitleLabel
            // 
            viewAllProductCategoryTitleLabel.AutoSize = true;
            viewAllProductCategoryTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewAllProductCategoryTitleLabel.Location = new Point(12, 9);
            viewAllProductCategoryTitleLabel.Name = "viewAllProductCategoryTitleLabel";
            viewAllProductCategoryTitleLabel.Size = new Size(333, 32);
            viewAllProductCategoryTitleLabel.TabIndex = 13;
            viewAllProductCategoryTitleLabel.Text = "View All Product Categories";
            // 
            // databaseConnectionSettingsBindingSource
            // 
            databaseConnectionSettingsBindingSource.DataSource = typeof(DatabaseConnectionSettings);
            // 
            // viewAllProductCategoryRefreshDataButton
            // 
            viewAllProductCategoryRefreshDataButton.FlatStyle = FlatStyle.Flat;
            viewAllProductCategoryRefreshDataButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            viewAllProductCategoryRefreshDataButton.Location = new Point(350, 7);
            viewAllProductCategoryRefreshDataButton.Margin = new Padding(2);
            viewAllProductCategoryRefreshDataButton.Name = "viewAllProductCategoryRefreshDataButton";
            viewAllProductCategoryRefreshDataButton.Size = new Size(201, 44);
            viewAllProductCategoryRefreshDataButton.TabIndex = 15;
            viewAllProductCategoryRefreshDataButton.Text = "Refresh Data";
            viewAllProductCategoryRefreshDataButton.UseVisualStyleBackColor = true;
            viewAllProductCategoryRefreshDataButton.Click += new EventHandler(ViewAllProductCategoryRefreshDataButton_Click);
            // 
            // ViewAllProductCategory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1060, 401);
            Controls.Add(viewAllProductCategoryDataGridView);
            Controls.Add(viewAllProductCategoryTitleLabel);
            Controls.Add(viewAllProductCategoryRefreshDataButton);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "ViewAllProductCategory";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - View All Product Categories";
            ((System.ComponentModel.ISupportInitialize)viewAllProductCategoryDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView viewAllProductCategoryDataGridView;
        private Label viewAllProductCategoryTitleLabel;
        private BindingSource databaseConnectionSettingsBindingSource;
        private Button viewAllProductCategoryRefreshDataButton;
    }
}