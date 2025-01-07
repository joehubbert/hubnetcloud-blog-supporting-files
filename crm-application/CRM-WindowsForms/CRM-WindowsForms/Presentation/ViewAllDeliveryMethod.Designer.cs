namespace CRM_WindowsForms.Presentation
{
    partial class ViewAllDeliveryMethod
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
            viewAllDeliveryMethodDataGridView = new DataGridView();
            viewAllDeliveryMethodTitleLabel = new Label();
            databaseConnectionSettingsBindingSource = new BindingSource(components);
            viewAllDeliveryMethodRefreshDataButton = new Button();
            ((System.ComponentModel.ISupportInitialize)viewAllDeliveryMethodDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).BeginInit();
            SuspendLayout();
            // 
            // viewAllDeliveryMethodDataGridView
            // 
            viewAllDeliveryMethodDataGridView.AllowUserToAddRows = false;
            viewAllDeliveryMethodDataGridView.AllowUserToDeleteRows = false;
            viewAllDeliveryMethodDataGridView.AllowUserToOrderColumns = true;
            viewAllDeliveryMethodDataGridView.AllowUserToResizeRows = false;
            viewAllDeliveryMethodDataGridView.BackgroundColor = Color.LemonChiffon;
            viewAllDeliveryMethodDataGridView.BorderStyle = BorderStyle.Fixed3D;
            viewAllDeliveryMethodDataGridView.ColumnHeadersHeight = 34;
            viewAllDeliveryMethodDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            viewAllDeliveryMethodDataGridView.Location = new Point(22, 66);
            viewAllDeliveryMethodDataGridView.Margin = new Padding(2);
            viewAllDeliveryMethodDataGridView.Name = "viewAllDeliveryMethodDataGridView";
            viewAllDeliveryMethodDataGridView.ReadOnly = true;
            viewAllDeliveryMethodDataGridView.RowHeadersWidth = 62;
            viewAllDeliveryMethodDataGridView.ShowEditingIcon = false;
            viewAllDeliveryMethodDataGridView.Size = new Size(1017, 303);
            viewAllDeliveryMethodDataGridView.TabIndex = 11;
            // 
            // viewAllDeliveryMethodTitleLabel
            // 
            viewAllDeliveryMethodTitleLabel.AutoSize = true;
            viewAllDeliveryMethodTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewAllDeliveryMethodTitleLabel.Location = new Point(12, 9);
            viewAllDeliveryMethodTitleLabel.Name = "viewAllDeliveryMethodTitleLabel";
            viewAllDeliveryMethodTitleLabel.Size = new Size(316, 32);
            viewAllDeliveryMethodTitleLabel.TabIndex = 10;
            viewAllDeliveryMethodTitleLabel.Text = "View All Delivery Methods";
            // 
            // databaseConnectionSettingsBindingSource
            // 
            databaseConnectionSettingsBindingSource.DataSource = typeof(Model.DatabaseConnectionSettings);
            // 
            // viewAllDeliveryMethodRefreshDataButton
            // 
            viewAllDeliveryMethodRefreshDataButton.FlatStyle = FlatStyle.Flat;
            viewAllDeliveryMethodRefreshDataButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            viewAllDeliveryMethodRefreshDataButton.Location = new Point(333, 7);
            viewAllDeliveryMethodRefreshDataButton.Margin = new Padding(2);
            viewAllDeliveryMethodRefreshDataButton.Name = "viewAllDeliveryMethodRefreshDataButton";
            viewAllDeliveryMethodRefreshDataButton.Size = new Size(201, 44);
            viewAllDeliveryMethodRefreshDataButton.TabIndex = 12;
            viewAllDeliveryMethodRefreshDataButton.Text = "Refresh Data";
            viewAllDeliveryMethodRefreshDataButton.UseVisualStyleBackColor = true;
            viewAllDeliveryMethodRefreshDataButton.Click += new EventHandler(viewAllDeliveryMethodRefreshDataButton_Click);
            // 
            // ViewAllDeliveryMethod
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1060, 401);
            Controls.Add(viewAllDeliveryMethodDataGridView);
            Controls.Add(viewAllDeliveryMethodTitleLabel);
            Controls.Add(viewAllDeliveryMethodRefreshDataButton);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "ViewAllDeliveryMethod";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - View All Delivery Methods";
            ((System.ComponentModel.ISupportInitialize)viewAllDeliveryMethodDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView viewAllDeliveryMethodDataGridView;
        private Label viewAllDeliveryMethodTitleLabel;
        private BindingSource databaseConnectionSettingsBindingSource;
        private Button viewAllDeliveryMethodRefreshDataButton;
    }
}