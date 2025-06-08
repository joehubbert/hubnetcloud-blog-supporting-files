namespace CRM_WindowsForms.Presentation
{
    partial class ViewAllData
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
            viewAllDataTitleLabel = new Label();
            viewAllDataRefreshDataButton = new Button();
            viewAllDataDataGridView = new DataGridView();
            viewAllDataQuickFilterTextbox = new TextBox();
            viewAllDataQuickFilterTextboxLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)viewAllDataDataGridView).BeginInit();
            SuspendLayout();
            // 
            // viewAllDataTitleLabel
            // 
            viewAllDataTitleLabel.AutoSize = true;
            viewAllDataTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewAllDataTitleLabel.Location = new Point(15, 18);
            viewAllDataTitleLabel.Name = "viewAllDataTitleLabel";
            viewAllDataTitleLabel.Size = new Size(383, 32);
            viewAllDataTitleLabel.TabIndex = 11;
            viewAllDataTitleLabel.Text = "{View All Data Title Placeholder}";
            // 
            // viewAllDataRefreshDataButton
            // 
            viewAllDataRefreshDataButton.FlatStyle = FlatStyle.Flat;
            viewAllDataRefreshDataButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            viewAllDataRefreshDataButton.Location = new Point(947, 9);
            viewAllDataRefreshDataButton.Margin = new Padding(2, 3, 2, 3);
            viewAllDataRefreshDataButton.Name = "viewAllDataRefreshDataButton";
            viewAllDataRefreshDataButton.Size = new Size(230, 59);
            viewAllDataRefreshDataButton.TabIndex = 13;
            viewAllDataRefreshDataButton.Text = "Refresh Data";
            viewAllDataRefreshDataButton.UseVisualStyleBackColor = true;
            viewAllDataRefreshDataButton.Click += viewAllDataRefreshDataButton_Click;
            // 
            // viewAllDataDataGridView
            // 
            viewAllDataDataGridView.AllowUserToAddRows = false;
            viewAllDataDataGridView.AllowUserToDeleteRows = false;
            viewAllDataDataGridView.AllowUserToOrderColumns = true;
            viewAllDataDataGridView.AllowUserToResizeRows = false;
            viewAllDataDataGridView.BackgroundColor = SystemColors.Control;
            viewAllDataDataGridView.BorderStyle = BorderStyle.Fixed3D;
            viewAllDataDataGridView.ColumnHeadersHeight = 34;
            viewAllDataDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            viewAllDataDataGridView.Location = new Point(15, 122);
            viewAllDataDataGridView.Margin = new Padding(2, 3, 2, 3);
            viewAllDataDataGridView.Name = "viewAllDataDataGridView";
            viewAllDataDataGridView.ReadOnly = true;
            viewAllDataDataGridView.RowHeadersWidth = 62;
            viewAllDataDataGridView.ShowEditingIcon = false;
            viewAllDataDataGridView.Size = new Size(1162, 441);
            viewAllDataDataGridView.TabIndex = 14;
            // 
            // viewAllDataQuickFilterTextbox
            // 
            viewAllDataQuickFilterTextbox.Location = new Point(104, 75);
            viewAllDataQuickFilterTextbox.Name = "viewAllDataQuickFilterTextbox";
            viewAllDataQuickFilterTextbox.Size = new Size(843, 27);
            viewAllDataQuickFilterTextbox.TabIndex = 15;
            // 
            // viewAllDataQuickFilterTextboxLabel
            // 
            viewAllDataQuickFilterTextboxLabel.AutoSize = true;
            viewAllDataQuickFilterTextboxLabel.Location = new Point(15, 78);
            viewAllDataQuickFilterTextboxLabel.Name = "viewAllDataQuickFilterTextboxLabel";
            viewAllDataQuickFilterTextboxLabel.Size = new Size(83, 20);
            viewAllDataQuickFilterTextboxLabel.TabIndex = 16;
            viewAllDataQuickFilterTextboxLabel.Text = "Quick Filter";
            // 
            // ViewAllData
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1190, 583);
            Controls.Add(viewAllDataQuickFilterTextboxLabel);
            Controls.Add(viewAllDataQuickFilterTextbox);
            Controls.Add(viewAllDataDataGridView);
            Controls.Add(viewAllDataRefreshDataButton);
            Controls.Add(viewAllDataTitleLabel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "ViewAllData";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ViewAllData";
            ((System.ComponentModel.ISupportInitialize)viewAllDataDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label viewAllDataTitleLabel;
        private Button viewAllDataRefreshDataButton;
        private DataGridView viewAllDataDataGridView;
        private TextBox viewAllDataQuickFilterTextbox;
        private Label viewAllDataQuickFilterTextboxLabel;
    }
}