using CRM_WindowsForms.Interface;

namespace CRM_WindowsForms.Presentation
{
    partial class ViewAllPaymentMethod
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
            viewAllPaymentMethodDataGridView = new DataGridView();
            viewAllPaymentMethodTitleLabel = new Label();
            databaseConnectionSettingsBindingSource = new BindingSource(components);
            viewAllPaymentMethodRefreshDataButton = new Button();
            ((System.ComponentModel.ISupportInitialize)viewAllPaymentMethodDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).BeginInit();
            SuspendLayout();
            // 
            // viewAllPaymentMethodDataGridView
            // 
            viewAllPaymentMethodDataGridView.AllowUserToAddRows = false;
            viewAllPaymentMethodDataGridView.AllowUserToDeleteRows = false;
            viewAllPaymentMethodDataGridView.AllowUserToOrderColumns = true;
            viewAllPaymentMethodDataGridView.AllowUserToResizeRows = false;
            viewAllPaymentMethodDataGridView.BackgroundColor = Color.LemonChiffon;
            viewAllPaymentMethodDataGridView.BorderStyle = BorderStyle.Fixed3D;
            viewAllPaymentMethodDataGridView.ColumnHeadersHeight = 34;
            viewAllPaymentMethodDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            viewAllPaymentMethodDataGridView.Location = new Point(22, 66);
            viewAllPaymentMethodDataGridView.Margin = new Padding(2);
            viewAllPaymentMethodDataGridView.Name = "viewAllPaymentMethodDataGridView";
            viewAllPaymentMethodDataGridView.ReadOnly = true;
            viewAllPaymentMethodDataGridView.RowHeadersWidth = 62;
            viewAllPaymentMethodDataGridView.ShowEditingIcon = false;
            viewAllPaymentMethodDataGridView.Size = new Size(1017, 303);
            viewAllPaymentMethodDataGridView.TabIndex = 14;
            // 
            // viewAllPaymentMethodTitleLabel
            // 
            viewAllPaymentMethodTitleLabel.AutoSize = true;
            viewAllPaymentMethodTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewAllPaymentMethodTitleLabel.Location = new Point(12, 9);
            viewAllPaymentMethodTitleLabel.Name = "viewAllPaymentMethodTitleLabel";
            viewAllPaymentMethodTitleLabel.Size = new Size(320, 32);
            viewAllPaymentMethodTitleLabel.TabIndex = 13;
            viewAllPaymentMethodTitleLabel.Text = "View All Payment Methods";
            // 
            // databaseConnectionSettingsBindingSource
            // 
            databaseConnectionSettingsBindingSource.DataSource = typeof(DatabaseConnectionSettings);
            // 
            // viewAllPaymentMethodRefreshDataButton
            // 
            viewAllPaymentMethodRefreshDataButton.FlatStyle = FlatStyle.Flat;
            viewAllPaymentMethodRefreshDataButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            viewAllPaymentMethodRefreshDataButton.Location = new Point(337, 7);
            viewAllPaymentMethodRefreshDataButton.Margin = new Padding(2);
            viewAllPaymentMethodRefreshDataButton.Name = "viewAllPaymentMethodRefreshDataButton";
            viewAllPaymentMethodRefreshDataButton.Size = new Size(201, 44);
            viewAllPaymentMethodRefreshDataButton.TabIndex = 15;
            viewAllPaymentMethodRefreshDataButton.Text = "Refresh Data";
            viewAllPaymentMethodRefreshDataButton.UseVisualStyleBackColor = true;
            viewAllPaymentMethodRefreshDataButton.Click += new EventHandler(ViewAllPaymentMethodRefreshDataButton_Click);
            // 
            // ViewAllPaymentMethod
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1060, 401);
            Controls.Add(viewAllPaymentMethodDataGridView);
            Controls.Add(viewAllPaymentMethodTitleLabel);
            Controls.Add(viewAllPaymentMethodRefreshDataButton);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "ViewAllPaymentMethod";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - View All Payment Methods";
            ((System.ComponentModel.ISupportInitialize)viewAllPaymentMethodDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView viewAllPaymentMethodDataGridView;
        private Label viewAllPaymentMethodTitleLabel;
        private BindingSource databaseConnectionSettingsBindingSource;
        private Button viewAllPaymentMethodRefreshDataButton;
    }
}