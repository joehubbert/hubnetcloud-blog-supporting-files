namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    partial class ModuleHomeSimple
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModuleHomeSimple));
            moduleHomeTitleLabel = new Label();
            moduleHomeViewAllButton = new Button();
            moduleHomeCreateButton = new Button();
            moduleHomeStatusStrip = new StatusStrip();
            moduleHomeStatusStripCompanyConfigurationPlaceholder = new ToolStripSplitButton();
            changeActiveCompanyConfigurationToolStripMenuItem = new ToolStripMenuItem();
            moduleHomeStatusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // moduleHomeTitleLabel
            // 
            moduleHomeTitleLabel.AutoSize = true;
            moduleHomeTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            moduleHomeTitleLabel.Location = new Point(15, 12);
            moduleHomeTitleLabel.Margin = new Padding(5, 0, 5, 0);
            moduleHomeTitleLabel.Name = "moduleHomeTitleLabel";
            moduleHomeTitleLabel.Size = new Size(335, 32);
            moduleHomeTitleLabel.TabIndex = 11;
            moduleHomeTitleLabel.Text = "{Module Name Placeholder}";
            // 
            // moduleHomeViewAllButton
            // 
            moduleHomeViewAllButton.FlatStyle = FlatStyle.Flat;
            moduleHomeViewAllButton.Font = new Font("Segoe UI", 11F);
            moduleHomeViewAllButton.Location = new Point(326, 104);
            moduleHomeViewAllButton.Margin = new Padding(5);
            moduleHomeViewAllButton.Name = "moduleHomeViewAllButton";
            moduleHomeViewAllButton.Size = new Size(242, 96);
            moduleHomeViewAllButton.TabIndex = 14;
            moduleHomeViewAllButton.Text = "View All";
            moduleHomeViewAllButton.UseVisualStyleBackColor = true;
            moduleHomeViewAllButton.Click += moduleHomeViewAllButton_Click;
            // 
            // moduleHomeCreateButton
            // 
            moduleHomeCreateButton.FlatStyle = FlatStyle.Flat;
            moduleHomeCreateButton.Font = new Font("Segoe UI", 11F);
            moduleHomeCreateButton.Location = new Point(46, 104);
            moduleHomeCreateButton.Margin = new Padding(5);
            moduleHomeCreateButton.Name = "moduleHomeCreateButton";
            moduleHomeCreateButton.Size = new Size(242, 96);
            moduleHomeCreateButton.TabIndex = 13;
            moduleHomeCreateButton.Text = "Create";
            moduleHomeCreateButton.UseVisualStyleBackColor = true;
            moduleHomeCreateButton.Click += moduleHomeCreateButton_Click;
            // 
            // moduleHomeStatusStrip
            // 
            moduleHomeStatusStrip.Items.AddRange(new ToolStripItem[] { moduleHomeStatusStripCompanyConfigurationPlaceholder });
            moduleHomeStatusStrip.Location = new Point(0, 239);
            moduleHomeStatusStrip.Name = "moduleHomeStatusStrip";
            moduleHomeStatusStrip.Size = new Size(613, 22);
            moduleHomeStatusStrip.TabIndex = 15;
            moduleHomeStatusStrip.Text = "Module Home Status Strip";
            // 
            // moduleHomeStatusStripCompanyConfigurationPlaceholder
            // 
            moduleHomeStatusStripCompanyConfigurationPlaceholder.DisplayStyle = ToolStripItemDisplayStyle.Text;
            moduleHomeStatusStripCompanyConfigurationPlaceholder.DropDownItems.AddRange(new ToolStripItem[] { changeActiveCompanyConfigurationToolStripMenuItem });
            moduleHomeStatusStripCompanyConfigurationPlaceholder.Image = (Image)resources.GetObject("moduleHomeStatusStripCompanyConfigurationPlaceholder.Image");
            moduleHomeStatusStripCompanyConfigurationPlaceholder.ImageTransparentColor = Color.Magenta;
            moduleHomeStatusStripCompanyConfigurationPlaceholder.Name = "moduleHomeStatusStripCompanyConfigurationPlaceholder";
            moduleHomeStatusStripCompanyConfigurationPlaceholder.Size = new Size(225, 20);
            moduleHomeStatusStripCompanyConfigurationPlaceholder.Text = "{Company Configuration Placeholder}";
            moduleHomeStatusStripCompanyConfigurationPlaceholder.ToolTipText = "You can change Active Company Configuration here";
            // 
            // changeActiveCompanyConfigurationToolStripMenuItem
            // 
            changeActiveCompanyConfigurationToolStripMenuItem.Name = "changeActiveCompanyConfigurationToolStripMenuItem";
            changeActiveCompanyConfigurationToolStripMenuItem.Size = new Size(283, 22);
            changeActiveCompanyConfigurationToolStripMenuItem.Text = "Change Active Company Configuration";
            changeActiveCompanyConfigurationToolStripMenuItem.Click += changeActiveCompanyConfigurationToolStripMenuItem_Click;
            // 
            // ModuleHomeSimple
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(613, 261);
            Controls.Add(moduleHomeStatusStrip);
            Controls.Add(moduleHomeViewAllButton);
            Controls.Add(moduleHomeCreateButton);
            Controls.Add(moduleHomeTitleLabel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "ModuleHomeSimple";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ModuleHomeSimple";
            moduleHomeStatusStrip.ResumeLayout(false);
            moduleHomeStatusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label moduleHomeTitleLabel;
        private Button moduleHomeViewAllButton;
        private Button moduleHomeCreateButton;
        private StatusStrip moduleHomeStatusStrip;
        private ToolStripSplitButton moduleHomeStatusStripCompanyConfigurationPlaceholder;
        private ToolStripMenuItem changeActiveCompanyConfigurationToolStripMenuItem;
    }
}