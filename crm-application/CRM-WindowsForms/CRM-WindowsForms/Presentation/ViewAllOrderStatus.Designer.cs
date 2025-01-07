namespace CRM_WindowsForms.Presentation
{
    partial class ViewAllOrderStatus
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
            viewAllOrderStatusDataGridView = new DataGridView();
            viewAllOrderStatusTitleLabel = new Label();
            databaseConnectionSettingsBindingSource = new BindingSource(components);
            viewAllOrderStatusRefreshDataButton = new Button();
            ((System.ComponentModel.ISupportInitialize)viewAllOrderStatusDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).BeginInit();
            SuspendLayout();
            // 
            // viewAllOrderStatusDataGridView
            // 
            viewAllOrderStatusDataGridView.AllowUserToAddRows = false;
            viewAllOrderStatusDataGridView.AllowUserToDeleteRows = false;
            viewAllOrderStatusDataGridView.AllowUserToOrderColumns = true;
            viewAllOrderStatusDataGridView.AllowUserToResizeRows = false;
            viewAllOrderStatusDataGridView.BackgroundColor = Color.LemonChiffon;
            viewAllOrderStatusDataGridView.BorderStyle = BorderStyle.Fixed3D;
            viewAllOrderStatusDataGridView.ColumnHeadersHeight = 34;
            viewAllOrderStatusDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            viewAllOrderStatusDataGridView.Location = new Point(22, 66);
            viewAllOrderStatusDataGridView.Margin = new Padding(2);
            viewAllOrderStatusDataGridView.Name = "viewAllOrderStatusDataGridView";
            viewAllOrderStatusDataGridView.ReadOnly = true;
            viewAllOrderStatusDataGridView.RowHeadersWidth = 62;
            viewAllOrderStatusDataGridView.ShowEditingIcon = false;
            viewAllOrderStatusDataGridView.Size = new Size(1017, 303);
            viewAllOrderStatusDataGridView.TabIndex = 14;
            // 
            // viewAllOrderStatusTitleLabel
            // 
            viewAllOrderStatusTitleLabel.AutoSize = true;
            viewAllOrderStatusTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewAllOrderStatusTitleLabel.Location = new Point(12, 9);
            viewAllOrderStatusTitleLabel.Name = "viewAllOrderStatusTitleLabel";
            viewAllOrderStatusTitleLabel.Size = new Size(280, 32);
            viewAllOrderStatusTitleLabel.TabIndex = 13;
            viewAllOrderStatusTitleLabel.Text = "View All Order Statuses";
            // 
            // databaseConnectionSettingsBindingSource
            // 
            databaseConnectionSettingsBindingSource.DataSource = typeof(Model.DatabaseConnectionSettings);
            // 
            // viewAllOrderStatusRefreshDataButton
            // 
            viewAllOrderStatusRefreshDataButton.FlatStyle = FlatStyle.Flat;
            viewAllOrderStatusRefreshDataButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            viewAllOrderStatusRefreshDataButton.Location = new Point(297, 7);
            viewAllOrderStatusRefreshDataButton.Margin = new Padding(2);
            viewAllOrderStatusRefreshDataButton.Name = "viewAllOrderStatusRefreshDataButton";
            viewAllOrderStatusRefreshDataButton.Size = new Size(201, 44);
            viewAllOrderStatusRefreshDataButton.TabIndex = 15;
            viewAllOrderStatusRefreshDataButton.Text = "Refresh Data";
            viewAllOrderStatusRefreshDataButton.UseVisualStyleBackColor = true;
            viewAllOrderStatusRefreshDataButton.Click += new EventHandler(viewAllOrderStatusRefreshDataButton_Click);
            // 
            // ViewAllOrderStatus
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1060, 401);
            Controls.Add(viewAllOrderStatusDataGridView);
            Controls.Add(viewAllOrderStatusTitleLabel);
            Controls.Add(viewAllOrderStatusRefreshDataButton);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "ViewAllOrderStatus";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - View All Order Statuses";
            ((System.ComponentModel.ISupportInitialize)viewAllOrderStatusDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView viewAllOrderStatusDataGridView;
        private Label viewAllOrderStatusTitleLabel;
        private BindingSource databaseConnectionSettingsBindingSource;
        private Button viewAllOrderStatusRefreshDataButton;
    }
}