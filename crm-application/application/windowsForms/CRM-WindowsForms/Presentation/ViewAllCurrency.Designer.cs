namespace CRM_WindowsForms.Presentation
{
    partial class ViewAllCurrency
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
            viewAllCurrencyDataGridView = new DataGridView();
            viewAllCurrencyTitleLabel = new Label();
            databaseConnectionSettingsBindingSource = new BindingSource(components);
            viewAllCurrencyRefreshDataButton = new Button();
            ((System.ComponentModel.ISupportInitialize)viewAllCurrencyDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).BeginInit();
            SuspendLayout();
            // 
            // viewAllCurrencyDataGridView
            // 
            viewAllCurrencyDataGridView.AllowUserToAddRows = false;
            viewAllCurrencyDataGridView.AllowUserToDeleteRows = false;
            viewAllCurrencyDataGridView.AllowUserToOrderColumns = true;
            viewAllCurrencyDataGridView.AllowUserToResizeRows = false;
            viewAllCurrencyDataGridView.BackgroundColor = Color.LemonChiffon;
            viewAllCurrencyDataGridView.BorderStyle = BorderStyle.Fixed3D;
            viewAllCurrencyDataGridView.ColumnHeadersHeight = 34;
            viewAllCurrencyDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            viewAllCurrencyDataGridView.Location = new Point(22, 66);
            viewAllCurrencyDataGridView.Margin = new Padding(2);
            viewAllCurrencyDataGridView.Name = "viewAllCurrencyDataGridView";
            viewAllCurrencyDataGridView.ReadOnly = true;
            viewAllCurrencyDataGridView.RowHeadersWidth = 62;
            viewAllCurrencyDataGridView.ShowEditingIcon = false;
            viewAllCurrencyDataGridView.Size = new Size(1017, 303);
            viewAllCurrencyDataGridView.TabIndex = 11;
            // 
            // viewAllCurrencyTitleLabel
            // 
            viewAllCurrencyTitleLabel.AutoSize = true;
            viewAllCurrencyTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewAllCurrencyTitleLabel.Location = new Point(12, 9);
            viewAllCurrencyTitleLabel.Name = "viewAllCurrencyTitleLabel";
            viewAllCurrencyTitleLabel.Size = new Size(235, 32);
            viewAllCurrencyTitleLabel.TabIndex = 10;
            viewAllCurrencyTitleLabel.Text = "View All Currencies";
            // 
            // databaseConnectionSettingsBindingSource
            // 
            databaseConnectionSettingsBindingSource.DataSource = typeof(Model.DatabaseConnectionSettings);
            // 
            // viewAllCurrencyRefreshDataButton
            // 
            viewAllCurrencyRefreshDataButton.FlatStyle = FlatStyle.Flat;
            viewAllCurrencyRefreshDataButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            viewAllCurrencyRefreshDataButton.Location = new Point(252, 7);
            viewAllCurrencyRefreshDataButton.Margin = new Padding(2);
            viewAllCurrencyRefreshDataButton.Name = "viewAllCurrencyRefreshDataButton";
            viewAllCurrencyRefreshDataButton.Size = new Size(201, 44);
            viewAllCurrencyRefreshDataButton.TabIndex = 12;
            viewAllCurrencyRefreshDataButton.Text = "Refresh Data";
            viewAllCurrencyRefreshDataButton.UseVisualStyleBackColor = true;
            viewAllCurrencyRefreshDataButton.Click += new EventHandler(ViewAllCurrencyRefreshDataButton_Click);
            // 
            // ViewAllCurrency
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1060, 401);
            Controls.Add(viewAllCurrencyDataGridView);
            Controls.Add(viewAllCurrencyTitleLabel);
            Controls.Add(viewAllCurrencyRefreshDataButton);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "ViewAllCurrency";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - View All Currencies";
            ((System.ComponentModel.ISupportInitialize)viewAllCurrencyDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView viewAllCurrencyDataGridView;
        private Label viewAllCurrencyTitleLabel;
        private BindingSource databaseConnectionSettingsBindingSource;
        private Button viewAllCurrencyRefreshDataButton;
    }
}