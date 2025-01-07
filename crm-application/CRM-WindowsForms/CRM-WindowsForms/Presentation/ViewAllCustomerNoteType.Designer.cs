namespace CRM_WindowsForms.Presentation
{
    partial class ViewAllCustomerNoteType
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
            viewAllCustomerNoteTypeDataGridView = new DataGridView();
            viewAllCustomerNoteTypeTitleLabel = new Label();
            databaseConnectionSettingsBindingSource = new BindingSource(components);
            viewAllCustomerNoteTypeRefreshDataButton = new Button();
            ((System.ComponentModel.ISupportInitialize)viewAllCustomerNoteTypeDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).BeginInit();
            SuspendLayout();
            // 
            // viewAllCustomerNoteTypeDataGridView
            // 
            viewAllCustomerNoteTypeDataGridView.AllowUserToAddRows = false;
            viewAllCustomerNoteTypeDataGridView.AllowUserToDeleteRows = false;
            viewAllCustomerNoteTypeDataGridView.AllowUserToOrderColumns = true;
            viewAllCustomerNoteTypeDataGridView.AllowUserToResizeRows = false;
            viewAllCustomerNoteTypeDataGridView.BackgroundColor = Color.LemonChiffon;
            viewAllCustomerNoteTypeDataGridView.BorderStyle = BorderStyle.Fixed3D;
            viewAllCustomerNoteTypeDataGridView.ColumnHeadersHeight = 34;
            viewAllCustomerNoteTypeDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            viewAllCustomerNoteTypeDataGridView.Location = new Point(22, 66);
            viewAllCustomerNoteTypeDataGridView.Margin = new Padding(2);
            viewAllCustomerNoteTypeDataGridView.Name = "viewAllCustomerNoteTypeDataGridView";
            viewAllCustomerNoteTypeDataGridView.ReadOnly = true;
            viewAllCustomerNoteTypeDataGridView.RowHeadersWidth = 62;
            viewAllCustomerNoteTypeDataGridView.ShowEditingIcon = false;
            viewAllCustomerNoteTypeDataGridView.Size = new Size(1017, 303);
            viewAllCustomerNoteTypeDataGridView.TabIndex = 14;
            // 
            // viewAllCustomerNoteTypeTitleLabel
            // 
            viewAllCustomerNoteTypeTitleLabel.AutoSize = true;
            viewAllCustomerNoteTypeTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewAllCustomerNoteTypeTitleLabel.Location = new Point(12, 9);
            viewAllCustomerNoteTypeTitleLabel.Name = "viewAllCustomerNoteTypeTitleLabel";
            viewAllCustomerNoteTypeTitleLabel.Size = new Size(359, 32);
            viewAllCustomerNoteTypeTitleLabel.TabIndex = 13;
            viewAllCustomerNoteTypeTitleLabel.Text = "View All Customer Note Types";
            // 
            // databaseConnectionSettingsBindingSource
            // 
            databaseConnectionSettingsBindingSource.DataSource = typeof(Model.DatabaseConnectionSettings);
            // 
            // viewAllCustomerNoteTypeRefreshDataButton
            // 
            viewAllCustomerNoteTypeRefreshDataButton.FlatStyle = FlatStyle.Flat;
            viewAllCustomerNoteTypeRefreshDataButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            viewAllCustomerNoteTypeRefreshDataButton.Location = new Point(387, 7);
            viewAllCustomerNoteTypeRefreshDataButton.Margin = new Padding(2);
            viewAllCustomerNoteTypeRefreshDataButton.Name = "viewAllCustomerNoteTypeRefreshDataButton";
            viewAllCustomerNoteTypeRefreshDataButton.Size = new Size(201, 44);
            viewAllCustomerNoteTypeRefreshDataButton.TabIndex = 15;
            viewAllCustomerNoteTypeRefreshDataButton.Text = "Refresh Data";
            viewAllCustomerNoteTypeRefreshDataButton.UseVisualStyleBackColor = true;
            viewAllCustomerNoteTypeRefreshDataButton.Click += new EventHandler(viewAllCustomerNoteTypeRefreshDataButton_Click);
            // 
            // ViewAllCustomerNoteType
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1060, 401);
            Controls.Add(viewAllCustomerNoteTypeDataGridView);
            Controls.Add(viewAllCustomerNoteTypeTitleLabel);
            Controls.Add(viewAllCustomerNoteTypeRefreshDataButton);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "ViewAllCustomerNoteType";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - View All Customer Note Types";
            ((System.ComponentModel.ISupportInitialize)viewAllCustomerNoteTypeDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView viewAllCustomerNoteTypeDataGridView;
        private Label viewAllCustomerNoteTypeTitleLabel;
        private BindingSource databaseConnectionSettingsBindingSource;
        private Button viewAllCustomerNoteTypeRefreshDataButton;
    }
}