namespace CRM_WindowsForms_EnterpriseEdition.Presentation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewAllData));
            viewAllDataTitleLabel = new Label();
            viewAllDataRefreshDataButton = new Button();
            viewAllDataDataGridView = new DataGridView();
            viewAllDataQuickFilterTextbox = new TextBox();
            viewAllDataQuickFilterTextboxLabel = new Label();
            viewAllDataExportCSVButton = new Button();
            viewAllDataStatusStrip = new StatusStrip();
            viewAllDataStatusStripCompanyConfigurationPlaceholder = new ToolStripSplitButton();
            changeActiveCompanyConfigurationToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)viewAllDataDataGridView).BeginInit();
            viewAllDataStatusStrip.SuspendLayout();
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
            viewAllDataRefreshDataButton.Location = new Point(1028, 9);
            viewAllDataRefreshDataButton.Margin = new Padding(2, 3, 2, 3);
            viewAllDataRefreshDataButton.Name = "viewAllDataRefreshDataButton";
            viewAllDataRefreshDataButton.Size = new Size(149, 59);
            viewAllDataRefreshDataButton.TabIndex = 4;
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
            viewAllDataDataGridView.TabIndex = 1;
            // 
            // viewAllDataQuickFilterTextbox
            // 
            viewAllDataQuickFilterTextbox.Location = new Point(104, 75);
            viewAllDataQuickFilterTextbox.Name = "viewAllDataQuickFilterTextbox";
            viewAllDataQuickFilterTextbox.Size = new Size(843, 27);
            viewAllDataQuickFilterTextbox.TabIndex = 0;
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
            // viewAllDataExportCSVButton
            // 
            viewAllDataExportCSVButton.FlatStyle = FlatStyle.Flat;
            viewAllDataExportCSVButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            viewAllDataExportCSVButton.Location = new Point(863, 9);
            viewAllDataExportCSVButton.Margin = new Padding(2, 3, 2, 3);
            viewAllDataExportCSVButton.Name = "viewAllDataExportCSVButton";
            viewAllDataExportCSVButton.Size = new Size(149, 59);
            viewAllDataExportCSVButton.TabIndex = 3;
            viewAllDataExportCSVButton.Text = "Export CSV";
            viewAllDataExportCSVButton.UseVisualStyleBackColor = true;
            viewAllDataExportCSVButton.Click += viewAllDataExportCSVButton_Click;
            // 
            // viewAllDataStatusStrip
            // 
            viewAllDataStatusStrip.Items.AddRange(new ToolStripItem[] { viewAllDataStatusStripCompanyConfigurationPlaceholder });
            viewAllDataStatusStrip.Location = new Point(0, 584);
            viewAllDataStatusStrip.Name = "viewAllDataStatusStrip";
            viewAllDataStatusStrip.Size = new Size(1190, 22);
            viewAllDataStatusStrip.TabIndex = 5;
            viewAllDataStatusStrip.Text = "View All Data Status Strip";
            // 
            // viewAllDataStatusStripCompanyConfigurationPlaceholder
            // 
            viewAllDataStatusStripCompanyConfigurationPlaceholder.DisplayStyle = ToolStripItemDisplayStyle.Text;
            viewAllDataStatusStripCompanyConfigurationPlaceholder.DropDownItems.AddRange(new ToolStripItem[] { changeActiveCompanyConfigurationToolStripMenuItem });
            viewAllDataStatusStripCompanyConfigurationPlaceholder.Image = (Image)resources.GetObject("viewAllDataStatusStripCompanyConfigurationPlaceholder.Image");
            viewAllDataStatusStripCompanyConfigurationPlaceholder.ImageTransparentColor = Color.Magenta;
            viewAllDataStatusStripCompanyConfigurationPlaceholder.Name = "viewAllDataStatusStripCompanyConfigurationPlaceholder";
            viewAllDataStatusStripCompanyConfigurationPlaceholder.Size = new Size(225, 20);
            viewAllDataStatusStripCompanyConfigurationPlaceholder.Text = "{Company Configuration Placeholder}";
            viewAllDataStatusStripCompanyConfigurationPlaceholder.ToolTipText = "You can change Active Company Configuration here";
            // 
            // changeActiveCompanyConfigurationToolStripMenuItem
            // 
            changeActiveCompanyConfigurationToolStripMenuItem.Name = "changeActiveCompanyConfigurationToolStripMenuItem";
            changeActiveCompanyConfigurationToolStripMenuItem.Size = new Size(283, 22);
            changeActiveCompanyConfigurationToolStripMenuItem.Text = "Change Active Company Configuration";
            changeActiveCompanyConfigurationToolStripMenuItem.Click += changeActiveCompanyConfigurationToolStripMenuItem_Click;
            // 
            // ViewAllData
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1190, 606);
            Controls.Add(viewAllDataStatusStrip);
            Controls.Add(viewAllDataExportCSVButton);
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
            viewAllDataStatusStrip.ResumeLayout(false);
            viewAllDataStatusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label viewAllDataTitleLabel;
        private Button viewAllDataRefreshDataButton;
        private DataGridView viewAllDataDataGridView;
        private TextBox viewAllDataQuickFilterTextbox;
        private Label viewAllDataQuickFilterTextboxLabel;
        private Button viewAllDataExportCSVButton;
        private StatusStrip viewAllDataStatusStrip;
        private ToolStripSplitButton viewAllDataStatusStripCompanyConfigurationPlaceholder;
        private ToolStripMenuItem changeActiveCompanyConfigurationToolStripMenuItem;
    }
}