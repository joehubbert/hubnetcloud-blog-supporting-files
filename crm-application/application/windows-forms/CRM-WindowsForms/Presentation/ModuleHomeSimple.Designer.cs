namespace CRM_WindowsForms.Presentation
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
            moduleHomeTitleLabel = new Label();
            moduleHomeViewAllButton = new Button();
            moduleHomeCreateButton = new Button();
            SuspendLayout();
            // 
            // moduleHomeTitleLabel
            // 
            moduleHomeTitleLabel.AutoSize = true;
            moduleHomeTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            moduleHomeTitleLabel.Location = new Point(13, 9);
            moduleHomeTitleLabel.Margin = new Padding(4, 0, 4, 0);
            moduleHomeTitleLabel.Name = "moduleHomeTitleLabel";
            moduleHomeTitleLabel.Size = new Size(335, 32);
            moduleHomeTitleLabel.TabIndex = 11;
            moduleHomeTitleLabel.Text = "{Module Name Placeholder}";
            // 
            // moduleHomeViewAllButton
            // 
            moduleHomeViewAllButton.FlatStyle = FlatStyle.Flat;
            moduleHomeViewAllButton.Font = new Font("Segoe UI", 11F);
            moduleHomeViewAllButton.Location = new Point(285, 78);
            moduleHomeViewAllButton.Margin = new Padding(4);
            moduleHomeViewAllButton.Name = "moduleHomeViewAllButton";
            moduleHomeViewAllButton.Size = new Size(212, 72);
            moduleHomeViewAllButton.TabIndex = 14;
            moduleHomeViewAllButton.Text = "View All";
            moduleHomeViewAllButton.UseVisualStyleBackColor = true;
            moduleHomeViewAllButton.Click += moduleHomeViewAllButton_Click;
            // 
            // moduleHomeCreateButton
            // 
            moduleHomeCreateButton.FlatStyle = FlatStyle.Flat;
            moduleHomeCreateButton.Font = new Font("Segoe UI", 11F);
            moduleHomeCreateButton.Location = new Point(40, 78);
            moduleHomeCreateButton.Margin = new Padding(4);
            moduleHomeCreateButton.Name = "moduleHomeCreateButton";
            moduleHomeCreateButton.Size = new Size(212, 72);
            moduleHomeCreateButton.TabIndex = 13;
            moduleHomeCreateButton.Text = "Create";
            moduleHomeCreateButton.UseVisualStyleBackColor = true;
            moduleHomeCreateButton.Click += moduleHomeCreateButton_Click;
            // 
            // ModuleHomeSimple
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(536, 196);
            Controls.Add(moduleHomeViewAllButton);
            Controls.Add(moduleHomeCreateButton);
            Controls.Add(moduleHomeTitleLabel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "ModuleHomeSimple";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ModuleHomeSimple";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label moduleHomeTitleLabel;
        private Button moduleHomeViewAllButton;
        private Button moduleHomeCreateButton;
    }
}