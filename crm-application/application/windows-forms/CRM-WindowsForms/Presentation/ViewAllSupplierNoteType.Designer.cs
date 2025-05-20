namespace CRM_WindowsForms.Presentation
{
    partial class ViewAllSupplierNoteType
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
            viewAllSupplierNoteTypeDataGridView = new DataGridView();
            viewAllSupplierNoteTypeTitleLabel = new Label();
            databaseConnectionSettingsBindingSource = new BindingSource(components);
            viewAllSupplierNoteTypeRefreshDataButton = new Button();
            ((System.ComponentModel.ISupportInitialize)viewAllSupplierNoteTypeDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).BeginInit();
            SuspendLayout();
            // 
            // viewAllSupplierNoteTypeDataGridView
            // 
            viewAllSupplierNoteTypeDataGridView.AllowUserToAddRows = false;
            viewAllSupplierNoteTypeDataGridView.AllowUserToDeleteRows = false;
            viewAllSupplierNoteTypeDataGridView.AllowUserToOrderColumns = true;
            viewAllSupplierNoteTypeDataGridView.AllowUserToResizeRows = false;
            viewAllSupplierNoteTypeDataGridView.BackgroundColor = Color.LemonChiffon;
            viewAllSupplierNoteTypeDataGridView.BorderStyle = BorderStyle.Fixed3D;
            viewAllSupplierNoteTypeDataGridView.ColumnHeadersHeight = 34;
            viewAllSupplierNoteTypeDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            viewAllSupplierNoteTypeDataGridView.Location = new Point(22, 66);
            viewAllSupplierNoteTypeDataGridView.Margin = new Padding(2);
            viewAllSupplierNoteTypeDataGridView.Name = "viewAllSupplierNoteTypeDataGridView";
            viewAllSupplierNoteTypeDataGridView.ReadOnly = true;
            viewAllSupplierNoteTypeDataGridView.RowHeadersWidth = 62;
            viewAllSupplierNoteTypeDataGridView.ShowEditingIcon = false;
            viewAllSupplierNoteTypeDataGridView.Size = new Size(1017, 303);
            viewAllSupplierNoteTypeDataGridView.TabIndex = 14;
            // 
            // viewAllSupplierNoteTypeTitleLabel
            // 
            viewAllSupplierNoteTypeTitleLabel.AutoSize = true;
            viewAllSupplierNoteTypeTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewAllSupplierNoteTypeTitleLabel.Location = new Point(12, 9);
            viewAllSupplierNoteTypeTitleLabel.Name = "viewAllSupplierNoteTypeTitleLabel";
            viewAllSupplierNoteTypeTitleLabel.Size = new Size(359, 32);
            viewAllSupplierNoteTypeTitleLabel.TabIndex = 13;
            viewAllSupplierNoteTypeTitleLabel.Text = "View All Supplier Note Types";
            // 
            // databaseConnectionSettingsBindingSource
            // 
            databaseConnectionSettingsBindingSource.DataSource = typeof(Model.DatabaseConnectionSettings);
            // 
            // viewAllSupplierNoteTypeRefreshDataButton
            // 
            viewAllSupplierNoteTypeRefreshDataButton.FlatStyle = FlatStyle.Flat;
            viewAllSupplierNoteTypeRefreshDataButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            viewAllSupplierNoteTypeRefreshDataButton.Location = new Point(387, 7);
            viewAllSupplierNoteTypeRefreshDataButton.Margin = new Padding(2);
            viewAllSupplierNoteTypeRefreshDataButton.Name = "viewAllSupplierNoteTypeRefreshDataButton";
            viewAllSupplierNoteTypeRefreshDataButton.Size = new Size(201, 44);
            viewAllSupplierNoteTypeRefreshDataButton.TabIndex = 15;
            viewAllSupplierNoteTypeRefreshDataButton.Text = "Refresh Data";
            viewAllSupplierNoteTypeRefreshDataButton.UseVisualStyleBackColor = true;
            viewAllSupplierNoteTypeRefreshDataButton.Click += new EventHandler(ViewAllSupplierNoteTypeRefreshDataButton_Click);
            // 
            // ViewAllSupplierNoteType
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1060, 401);
            Controls.Add(viewAllSupplierNoteTypeDataGridView);
            Controls.Add(viewAllSupplierNoteTypeTitleLabel);
            Controls.Add(viewAllSupplierNoteTypeRefreshDataButton);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "ViewAllSupplierNoteType";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - View All Supplier Note Types";
            ((System.ComponentModel.ISupportInitialize)viewAllSupplierNoteTypeDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView viewAllSupplierNoteTypeDataGridView;
        private Label viewAllSupplierNoteTypeTitleLabel;
        private BindingSource databaseConnectionSettingsBindingSource;
        private Button viewAllSupplierNoteTypeRefreshDataButton;
    }
}