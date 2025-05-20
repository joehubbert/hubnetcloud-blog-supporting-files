using CRM_WindowsForms.Interface;

namespace CRM_WindowsForms.Presentation
{
    partial class ViewAllProductNoteType
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
            viewAllProductNoteTypeDataGridView = new DataGridView();
            viewAllProductNoteTypeTitleLabel = new Label();
            databaseConnectionSettingsBindingSource = new BindingSource(components);
            viewAllProductNoteTypeRefreshDataButton = new Button();
            ((System.ComponentModel.ISupportInitialize)viewAllProductNoteTypeDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).BeginInit();
            SuspendLayout();
            // 
            // viewAllProductNoteTypeDataGridView
            // 
            viewAllProductNoteTypeDataGridView.AllowUserToAddRows = false;
            viewAllProductNoteTypeDataGridView.AllowUserToDeleteRows = false;
            viewAllProductNoteTypeDataGridView.AllowUserToOrderColumns = true;
            viewAllProductNoteTypeDataGridView.AllowUserToResizeRows = false;
            viewAllProductNoteTypeDataGridView.BackgroundColor = Color.LemonChiffon;
            viewAllProductNoteTypeDataGridView.BorderStyle = BorderStyle.Fixed3D;
            viewAllProductNoteTypeDataGridView.ColumnHeadersHeight = 34;
            viewAllProductNoteTypeDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            viewAllProductNoteTypeDataGridView.Location = new Point(22, 66);
            viewAllProductNoteTypeDataGridView.Margin = new Padding(2);
            viewAllProductNoteTypeDataGridView.Name = "viewAllProductNoteTypeDataGridView";
            viewAllProductNoteTypeDataGridView.ReadOnly = true;
            viewAllProductNoteTypeDataGridView.RowHeadersWidth = 62;
            viewAllProductNoteTypeDataGridView.ShowEditingIcon = false;
            viewAllProductNoteTypeDataGridView.Size = new Size(1017, 303);
            viewAllProductNoteTypeDataGridView.TabIndex = 14;
            // 
            // viewAllProductNoteTypeTitleLabel
            // 
            viewAllProductNoteTypeTitleLabel.AutoSize = true;
            viewAllProductNoteTypeTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewAllProductNoteTypeTitleLabel.Location = new Point(12, 9);
            viewAllProductNoteTypeTitleLabel.Name = "viewAllProductNoteTypeTitleLabel";
            viewAllProductNoteTypeTitleLabel.Size = new Size(359, 32);
            viewAllProductNoteTypeTitleLabel.TabIndex = 13;
            viewAllProductNoteTypeTitleLabel.Text = "View All Product Note Types";
            // 
            // databaseConnectionSettingsBindingSource
            // 
            databaseConnectionSettingsBindingSource.DataSource = typeof(DatabaseConnectionSettings);
            // 
            // viewAllProductNoteTypeRefreshDataButton
            // 
            viewAllProductNoteTypeRefreshDataButton.FlatStyle = FlatStyle.Flat;
            viewAllProductNoteTypeRefreshDataButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            viewAllProductNoteTypeRefreshDataButton.Location = new Point(387, 7);
            viewAllProductNoteTypeRefreshDataButton.Margin = new Padding(2);
            viewAllProductNoteTypeRefreshDataButton.Name = "viewAllProductNoteTypeRefreshDataButton";
            viewAllProductNoteTypeRefreshDataButton.Size = new Size(201, 44);
            viewAllProductNoteTypeRefreshDataButton.TabIndex = 15;
            viewAllProductNoteTypeRefreshDataButton.Text = "Refresh Data";
            viewAllProductNoteTypeRefreshDataButton.UseVisualStyleBackColor = true;
            viewAllProductNoteTypeRefreshDataButton.Click += new EventHandler(ViewAllProductNoteTypeRefreshDataButton_Click);
            // 
            // ViewAllProductNoteType
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1060, 401);
            Controls.Add(viewAllProductNoteTypeDataGridView);
            Controls.Add(viewAllProductNoteTypeTitleLabel);
            Controls.Add(viewAllProductNoteTypeRefreshDataButton);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "ViewAllProductNoteType";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - View All Product Note Types";
            ((System.ComponentModel.ISupportInitialize)viewAllProductNoteTypeDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)databaseConnectionSettingsBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView viewAllProductNoteTypeDataGridView;
        private Label viewAllProductNoteTypeTitleLabel;
        private BindingSource databaseConnectionSettingsBindingSource;
        private Button viewAllProductNoteTypeRefreshDataButton;
    }
}