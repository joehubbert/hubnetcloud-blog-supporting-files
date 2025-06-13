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
            moduleHomeViewAllButton.Margin = new Padding(5, 5, 5, 5);
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
            moduleHomeCreateButton.Margin = new Padding(5, 5, 5, 5);
            moduleHomeCreateButton.Name = "moduleHomeCreateButton";
            moduleHomeCreateButton.Size = new Size(242, 96);
            moduleHomeCreateButton.TabIndex = 13;
            moduleHomeCreateButton.Text = "Create";
            moduleHomeCreateButton.UseVisualStyleBackColor = true;
            moduleHomeCreateButton.Click += moduleHomeCreateButton_Click;
            // 
            // ModuleHomeSimple
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(613, 261);
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label moduleHomeTitleLabel;
        private Button moduleHomeViewAllButton;
        private Button moduleHomeCreateButton;
    }
}