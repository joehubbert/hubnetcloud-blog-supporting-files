namespace CRM_WindowsForms.Presentation
{
    partial class CompanyAdministration
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
            companyAdministrationAccountManagementGroupBox = new GroupBox();
            companyAdministrationAddNewAccountManagerButton = new Button();
            companyAdministrationTitleLabel = new Label();
            companyAdministrationViewAllAccountManagersButton = new Button();
            companyAdministrationAccountManagementGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // companyAdministrationAccountManagementGroupBox
            // 
            companyAdministrationAccountManagementGroupBox.AutoSize = true;
            companyAdministrationAccountManagementGroupBox.BackColor = Color.Transparent;
            companyAdministrationAccountManagementGroupBox.Controls.Add(companyAdministrationViewAllAccountManagersButton);
            companyAdministrationAccountManagementGroupBox.Controls.Add(companyAdministrationAddNewAccountManagerButton);
            companyAdministrationAccountManagementGroupBox.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            companyAdministrationAccountManagementGroupBox.Location = new Point(40, 98);
            companyAdministrationAccountManagementGroupBox.Margin = new Padding(4);
            companyAdministrationAccountManagementGroupBox.Name = "companyAdministrationAccountManagementGroupBox";
            companyAdministrationAccountManagementGroupBox.Padding = new Padding(4);
            companyAdministrationAccountManagementGroupBox.Size = new Size(581, 496);
            companyAdministrationAccountManagementGroupBox.TabIndex = 0;
            companyAdministrationAccountManagementGroupBox.TabStop = false;
            companyAdministrationAccountManagementGroupBox.Text = "Account Management";
            // 
            // companyAdministrationAddNewAccountManagerButton
            // 
            companyAdministrationAddNewAccountManagerButton.FlatStyle = FlatStyle.Flat;
            companyAdministrationAddNewAccountManagerButton.Font = new Font("Segoe UI", 11F);
            companyAdministrationAddNewAccountManagerButton.Location = new Point(62, 61);
            companyAdministrationAddNewAccountManagerButton.Margin = new Padding(4);
            companyAdministrationAddNewAccountManagerButton.Name = "companyAdministrationAddNewAccountManagerButton";
            companyAdministrationAddNewAccountManagerButton.Size = new Size(439, 124);
            companyAdministrationAddNewAccountManagerButton.TabIndex = 1;
            companyAdministrationAddNewAccountManagerButton.Text = "Create Account Manager";
            companyAdministrationAddNewAccountManagerButton.UseVisualStyleBackColor = true;
            companyAdministrationAddNewAccountManagerButton.Click += companyAdministrationAddNewAccountManagerButton_Click;
            // 
            // companyAdministrationTitleLabel
            // 
            companyAdministrationTitleLabel.AutoSize = true;
            companyAdministrationTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            companyAdministrationTitleLabel.Location = new Point(40, 24);
            companyAdministrationTitleLabel.Margin = new Padding(4, 0, 4, 0);
            companyAdministrationTitleLabel.Name = "companyAdministrationTitleLabel";
            companyAdministrationTitleLabel.Size = new Size(442, 48);
            companyAdministrationTitleLabel.TabIndex = 6;
            companyAdministrationTitleLabel.Text = "Company Administration";
            // 
            // companyAdministrationViewAllAccountManagersButton
            // 
            companyAdministrationViewAllAccountManagersButton.FlatStyle = FlatStyle.Flat;
            companyAdministrationViewAllAccountManagersButton.Font = new Font("Segoe UI", 11F);
            companyAdministrationViewAllAccountManagersButton.Location = new Point(62, 241);
            companyAdministrationViewAllAccountManagersButton.Margin = new Padding(4);
            companyAdministrationViewAllAccountManagersButton.Name = "companyAdministrationViewAllAccountManagersButton";
            companyAdministrationViewAllAccountManagersButton.Size = new Size(439, 124);
            companyAdministrationViewAllAccountManagersButton.TabIndex = 7;
            companyAdministrationViewAllAccountManagersButton.Text = "View All Account Managers";
            companyAdministrationViewAllAccountManagersButton.UseVisualStyleBackColor = true;
            companyAdministrationViewAllAccountManagersButton.Click += companyAdministrationViewAllAccountManagersButton_Click;
            // 
            // CompanyAdministration
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Khaki;
            ClientSize = new Size(1712, 1212);
            Controls.Add(companyAdministrationTitleLabel);
            Controls.Add(companyAdministrationAccountManagementGroupBox);
            Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "CompanyAdministration";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - Company Administration";
            companyAdministrationAccountManagementGroupBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox companyAdministrationAccountManagementGroupBox;
        private Button companyAdministrationAddNewAccountManagerButton;
        private Label companyAdministrationTitleLabel;
        private Button companyAdministrationViewAllAccountManagersButton;
    }
}