namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    partial class CreateMasterDataSimple
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateMasterDataSimple));
            createMasterDataSimpleTitleLabel = new Label();
            createMasterDataSimpleMasterDataTypeTextbox = new TextBox();
            createMasterDataSimpleMasterDataTypeTextboxLabel = new Label();
            createMasterDataSimpleSubmitButton = new Button();
            createMasterDataSimpleActiveStatusCheckbox = new CheckBox();
            createMasterDataSimpleStatusStrip = new StatusStrip();
            createMasterDataSimpleStatusStripCompanyConfigurationPlaceholder = new ToolStripSplitButton();
            changeActiveCompanyConfigurationToolStripMenuItem = new ToolStripMenuItem();
            createMasterDataSimpleStatusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // createMasterDataSimpleTitleLabel
            // 
            createMasterDataSimpleTitleLabel.AutoSize = true;
            createMasterDataSimpleTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createMasterDataSimpleTitleLabel.Location = new Point(14, 9);
            createMasterDataSimpleTitleLabel.Margin = new Padding(5, 0, 5, 0);
            createMasterDataSimpleTitleLabel.Name = "createMasterDataSimpleTitleLabel";
            createMasterDataSimpleTitleLabel.Size = new Size(366, 32);
            createMasterDataSimpleTitleLabel.TabIndex = 8;
            createMasterDataSimpleTitleLabel.Text = "{MasterData Type Placeholder}";
            // 
            // createMasterDataSimpleMasterDataTypeTextbox
            // 
            createMasterDataSimpleMasterDataTypeTextbox.Location = new Point(225, 59);
            createMasterDataSimpleMasterDataTypeTextbox.Margin = new Padding(3, 4, 3, 4);
            createMasterDataSimpleMasterDataTypeTextbox.MaxLength = 50;
            createMasterDataSimpleMasterDataTypeTextbox.Name = "createMasterDataSimpleMasterDataTypeTextbox";
            createMasterDataSimpleMasterDataTypeTextbox.Size = new Size(271, 27);
            createMasterDataSimpleMasterDataTypeTextbox.TabIndex = 0;
            // 
            // createMasterDataSimpleMasterDataTypeTextboxLabel
            // 
            createMasterDataSimpleMasterDataTypeTextboxLabel.AutoSize = true;
            createMasterDataSimpleMasterDataTypeTextboxLabel.Font = new Font("Segoe UI", 11F);
            createMasterDataSimpleMasterDataTypeTextboxLabel.Location = new Point(12, 62);
            createMasterDataSimpleMasterDataTypeTextboxLabel.Name = "createMasterDataSimpleMasterDataTypeTextboxLabel";
            createMasterDataSimpleMasterDataTypeTextboxLabel.Size = new Size(213, 20);
            createMasterDataSimpleMasterDataTypeTextboxLabel.TabIndex = 23;
            createMasterDataSimpleMasterDataTypeTextboxLabel.Text = "{MasterData Type Placeholder}";
            createMasterDataSimpleMasterDataTypeTextboxLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // createMasterDataSimpleSubmitButton
            // 
            createMasterDataSimpleSubmitButton.FlatStyle = FlatStyle.Flat;
            createMasterDataSimpleSubmitButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createMasterDataSimpleSubmitButton.Location = new Point(166, 165);
            createMasterDataSimpleSubmitButton.Margin = new Padding(4);
            createMasterDataSimpleSubmitButton.Name = "createMasterDataSimpleSubmitButton";
            createMasterDataSimpleSubmitButton.Size = new Size(198, 66);
            createMasterDataSimpleSubmitButton.TabIndex = 2;
            createMasterDataSimpleSubmitButton.Text = "Submit";
            createMasterDataSimpleSubmitButton.UseVisualStyleBackColor = true;
            createMasterDataSimpleSubmitButton.Click += createMasterDataSimpleSubmitButton_Click;
            // 
            // createMasterDataSimpleActiveStatusCheckbox
            // 
            createMasterDataSimpleActiveStatusCheckbox.Checked = true;
            createMasterDataSimpleActiveStatusCheckbox.CheckState = CheckState.Checked;
            createMasterDataSimpleActiveStatusCheckbox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createMasterDataSimpleActiveStatusCheckbox.Location = new Point(136, 117);
            createMasterDataSimpleActiveStatusCheckbox.Margin = new Padding(5);
            createMasterDataSimpleActiveStatusCheckbox.Name = "createMasterDataSimpleActiveStatusCheckbox";
            createMasterDataSimpleActiveStatusCheckbox.Size = new Size(281, 24);
            createMasterDataSimpleActiveStatusCheckbox.TabIndex = 1;
            createMasterDataSimpleActiveStatusCheckbox.Text = "Active {MasterData Type Placeholder}";
            createMasterDataSimpleActiveStatusCheckbox.UseVisualStyleBackColor = true;
            // 
            // createMasterDataSimpleStatusStrip
            // 
            createMasterDataSimpleStatusStrip.Items.AddRange(new ToolStripItem[] { createMasterDataSimpleStatusStripCompanyConfigurationPlaceholder });
            createMasterDataSimpleStatusStrip.Location = new Point(0, 246);
            createMasterDataSimpleStatusStrip.Name = "createMasterDataSimpleStatusStrip";
            createMasterDataSimpleStatusStrip.Size = new Size(524, 22);
            createMasterDataSimpleStatusStrip.TabIndex = 3;
            createMasterDataSimpleStatusStrip.Text = "Create Master Data Simple Status Strip";
            createMasterDataSimpleStatusStrip.Visible = true;
            // 
            // createMasterDataSimpleStatusStripCompanyConfigurationPlaceholder
            // 
            createMasterDataSimpleStatusStripCompanyConfigurationPlaceholder.DisplayStyle = ToolStripItemDisplayStyle.Text;
            createMasterDataSimpleStatusStripCompanyConfigurationPlaceholder.DropDownItems.AddRange(new ToolStripItem[] { changeActiveCompanyConfigurationToolStripMenuItem });
            createMasterDataSimpleStatusStripCompanyConfigurationPlaceholder.Image = (Image)resources.GetObject("createMasterDataSimpleStatusStripCompanyConfigurationPlaceholder.Image");
            createMasterDataSimpleStatusStripCompanyConfigurationPlaceholder.ImageTransparentColor = Color.Magenta;
            createMasterDataSimpleStatusStripCompanyConfigurationPlaceholder.Name = "createMasterDataSimpleStatusStripCompanyConfigurationPlaceholder";
            createMasterDataSimpleStatusStripCompanyConfigurationPlaceholder.Size = new Size(225, 20);
            createMasterDataSimpleStatusStripCompanyConfigurationPlaceholder.Text = "{Company Configuration Placeholder}";
            createMasterDataSimpleStatusStripCompanyConfigurationPlaceholder.ToolTipText = "You can change Active Company Configuration here";
            createMasterDataSimpleStatusStripCompanyConfigurationPlaceholder.Visible = true;
            // 
            // changeActiveCompanyConfigurationToolStripMenuItem
            // 
            changeActiveCompanyConfigurationToolStripMenuItem.Name = "changeActiveCompanyConfigurationToolStripMenuItem";
            changeActiveCompanyConfigurationToolStripMenuItem.Size = new Size(283, 22);
            changeActiveCompanyConfigurationToolStripMenuItem.Text = "Change Active Company Configuration";
            changeActiveCompanyConfigurationToolStripMenuItem.Click += changeActiveCompanyConfigurationToolStripMenuItem_Click;
            // 
            // CreateMasterDataSimple
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(524, 268);
            Controls.Add(createMasterDataSimpleStatusStrip);
            Controls.Add(createMasterDataSimpleMasterDataTypeTextbox);
            Controls.Add(createMasterDataSimpleMasterDataTypeTextboxLabel);
            Controls.Add(createMasterDataSimpleSubmitButton);
            Controls.Add(createMasterDataSimpleActiveStatusCheckbox);
            Controls.Add(createMasterDataSimpleTitleLabel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "CreateMasterDataSimple";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CreateMasterDataSimple";
            createMasterDataSimpleStatusStrip.ResumeLayout(false);
            createMasterDataSimpleStatusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label createMasterDataSimpleTitleLabel;
        private TextBox createMasterDataSimpleMasterDataTypeTextbox;
        private Label createMasterDataSimpleMasterDataTypeTextboxLabel;
        private Button createMasterDataSimpleSubmitButton;
        private CheckBox createMasterDataSimpleActiveStatusCheckbox;
        private StatusStrip createMasterDataSimpleStatusStrip;
        private ToolStripSplitButton createMasterDataSimpleStatusStripCompanyConfigurationPlaceholder;
        private ToolStripMenuItem changeActiveCompanyConfigurationToolStripMenuItem;
    }
}