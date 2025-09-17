namespace CRM.Presentation.MasterDataManagement
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
            createMasterDataSimpleMasterDataTypeTextBox = new TextBox();
            createMasterDataSimpleMasterDataTypeTextBoxLabel = new Label();
            createMasterDataSimpleSubmitButton = new Button();
            createMasterDataSimpleActiveStatusCheckBox = new CheckBox();
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
            // createMasterDataSimpleMasterDataTypeTextBox
            // 
            createMasterDataSimpleMasterDataTypeTextBox.Location = new Point(225, 59);
            createMasterDataSimpleMasterDataTypeTextBox.Margin = new Padding(3, 4, 3, 4);
            createMasterDataSimpleMasterDataTypeTextBox.MaxLength = 50;
            createMasterDataSimpleMasterDataTypeTextBox.Name = "createMasterDataSimpleMasterDataTypeTextBox";
            createMasterDataSimpleMasterDataTypeTextBox.Size = new Size(271, 27);
            createMasterDataSimpleMasterDataTypeTextBox.TabIndex = 0;
            // 
            // createMasterDataSimpleMasterDataTypeTextBoxLabel
            // 
            createMasterDataSimpleMasterDataTypeTextBoxLabel.AutoSize = true;
            createMasterDataSimpleMasterDataTypeTextBoxLabel.Font = new Font("Segoe UI", 11F);
            createMasterDataSimpleMasterDataTypeTextBoxLabel.Location = new Point(12, 62);
            createMasterDataSimpleMasterDataTypeTextBoxLabel.Name = "createMasterDataSimpleMasterDataTypeTextBoxLabel";
            createMasterDataSimpleMasterDataTypeTextBoxLabel.Size = new Size(213, 20);
            createMasterDataSimpleMasterDataTypeTextBoxLabel.TabIndex = 23;
            createMasterDataSimpleMasterDataTypeTextBoxLabel.Text = "{MasterData Type Placeholder}";
            createMasterDataSimpleMasterDataTypeTextBoxLabel.TextAlign = ContentAlignment.TopRight;
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
            // createMasterDataSimpleActiveStatusCheckBox
            // 
            createMasterDataSimpleActiveStatusCheckBox.Checked = true;
            createMasterDataSimpleActiveStatusCheckBox.CheckState = CheckState.Checked;
            createMasterDataSimpleActiveStatusCheckBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createMasterDataSimpleActiveStatusCheckBox.Location = new Point(136, 117);
            createMasterDataSimpleActiveStatusCheckBox.Margin = new Padding(5);
            createMasterDataSimpleActiveStatusCheckBox.Name = "createMasterDataSimpleActiveStatusCheckBox";
            createMasterDataSimpleActiveStatusCheckBox.Size = new Size(281, 24);
            createMasterDataSimpleActiveStatusCheckBox.TabIndex = 1;
            createMasterDataSimpleActiveStatusCheckBox.Text = "Active {MasterData Type Placeholder}";
            createMasterDataSimpleActiveStatusCheckBox.UseVisualStyleBackColor = true;
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
            Controls.Add(createMasterDataSimpleMasterDataTypeTextBox);
            Controls.Add(createMasterDataSimpleMasterDataTypeTextBoxLabel);
            Controls.Add(createMasterDataSimpleSubmitButton);
            Controls.Add(createMasterDataSimpleActiveStatusCheckBox);
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
        private TextBox createMasterDataSimpleMasterDataTypeTextBox;
        private Label createMasterDataSimpleMasterDataTypeTextBoxLabel;
        private Button createMasterDataSimpleSubmitButton;
        private CheckBox createMasterDataSimpleActiveStatusCheckBox;
        private StatusStrip createMasterDataSimpleStatusStrip;
        private ToolStripSplitButton createMasterDataSimpleStatusStripCompanyConfigurationPlaceholder;
        private ToolStripMenuItem changeActiveCompanyConfigurationToolStripMenuItem;
    }
}