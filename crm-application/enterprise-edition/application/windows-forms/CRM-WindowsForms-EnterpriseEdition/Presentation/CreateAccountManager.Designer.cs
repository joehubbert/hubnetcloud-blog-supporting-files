namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    partial class CreateAccountManager
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
            createAccountManagerTitleLabel = new Label();
            createAccountManagerFirstNameTextBox = new TextBox();
            createAccountManagerTelephoneNumberTextBox = new TextBox();
            createAccountManagerEmailAddressTextBox = new TextBox();
            createAccountManagerLastNameTextBox = new TextBox();
            createAccountManagerSubmitButton = new Button();
            createAccountManagerFirstNameLabel = new Label();
            createAccountManagerLastNameLabel = new Label();
            createAccountManagerEmailAddressLabel = new Label();
            createAccountManagerTelephoneNumberLabel = new Label();
            createAccountManagerActiveStatusCheckbox = new CheckBox();
            createAccountManagerStatusStrip = new StatusStrip();
            createAccountManagerStatusStripCompanyConfigurationPlaceholder = new ToolStripSplitButton();
            changeActiveCompanyConfigurationToolStripMenuItem = new ToolStripMenuItem();
            createAccountManagerStatusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // createAccountManagerTitleLabel
            // 
            createAccountManagerTitleLabel.AutoSize = true;
            createAccountManagerTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createAccountManagerTitleLabel.Location = new Point(13, 9);
            createAccountManagerTitleLabel.Margin = new Padding(4, 0, 4, 0);
            createAccountManagerTitleLabel.Name = "createAccountManagerTitleLabel";
            createAccountManagerTitleLabel.Size = new Size(298, 32);
            createAccountManagerTitleLabel.TabIndex = 5;
            createAccountManagerTitleLabel.Text = "Create Account Manager";
            // 
            // createAccountManagerFirstNameTextBox
            // 
            createAccountManagerFirstNameTextBox.Font = new Font("Segoe UI", 11F);
            createAccountManagerFirstNameTextBox.Location = new Point(165, 61);
            createAccountManagerFirstNameTextBox.Margin = new Padding(4);
            createAccountManagerFirstNameTextBox.MaxLength = 50;
            createAccountManagerFirstNameTextBox.Name = "createAccountManagerFirstNameTextBox";
            createAccountManagerFirstNameTextBox.Size = new Size(340, 27);
            createAccountManagerFirstNameTextBox.TabIndex = 0;
            // 
            // createAccountManagerTelephoneNumberTextBox
            // 
            createAccountManagerTelephoneNumberTextBox.Font = new Font("Segoe UI", 11F);
            createAccountManagerTelephoneNumberTextBox.Location = new Point(164, 184);
            createAccountManagerTelephoneNumberTextBox.Margin = new Padding(4);
            createAccountManagerTelephoneNumberTextBox.MaxLength = 13;
            createAccountManagerTelephoneNumberTextBox.Name = "createAccountManagerTelephoneNumberTextBox";
            createAccountManagerTelephoneNumberTextBox.Size = new Size(340, 27);
            createAccountManagerTelephoneNumberTextBox.TabIndex = 3;
            // 
            // createAccountManagerEmailAddressTextBox
            // 
            createAccountManagerEmailAddressTextBox.Font = new Font("Segoe UI", 11F);
            createAccountManagerEmailAddressTextBox.Location = new Point(165, 143);
            createAccountManagerEmailAddressTextBox.Margin = new Padding(4);
            createAccountManagerEmailAddressTextBox.MaxLength = 50;
            createAccountManagerEmailAddressTextBox.Name = "createAccountManagerEmailAddressTextBox";
            createAccountManagerEmailAddressTextBox.Size = new Size(340, 27);
            createAccountManagerEmailAddressTextBox.TabIndex = 2;
            // 
            // createAccountManagerLastNameTextBox
            // 
            createAccountManagerLastNameTextBox.Font = new Font("Segoe UI", 11F);
            createAccountManagerLastNameTextBox.Location = new Point(165, 101);
            createAccountManagerLastNameTextBox.Margin = new Padding(4);
            createAccountManagerLastNameTextBox.MaxLength = 50;
            createAccountManagerLastNameTextBox.Name = "createAccountManagerLastNameTextBox";
            createAccountManagerLastNameTextBox.Size = new Size(340, 27);
            createAccountManagerLastNameTextBox.TabIndex = 1;
            // 
            // createAccountManagerSubmitButton
            // 
            createAccountManagerSubmitButton.FlatStyle = FlatStyle.Flat;
            createAccountManagerSubmitButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createAccountManagerSubmitButton.Location = new Point(175, 294);
            createAccountManagerSubmitButton.Margin = new Padding(4);
            createAccountManagerSubmitButton.Name = "createAccountManagerSubmitButton";
            createAccountManagerSubmitButton.Size = new Size(198, 66);
            createAccountManagerSubmitButton.TabIndex = 4;
            createAccountManagerSubmitButton.Text = "Submit";
            createAccountManagerSubmitButton.UseVisualStyleBackColor = true;
            createAccountManagerSubmitButton.Click += createAccountManagerSubmitButton_Click;
            // 
            // createAccountManagerFirstNameLabel
            // 
            createAccountManagerFirstNameLabel.AutoSize = true;
            createAccountManagerFirstNameLabel.Font = new Font("Segoe UI", 11F);
            createAccountManagerFirstNameLabel.Location = new Point(77, 64);
            createAccountManagerFirstNameLabel.Margin = new Padding(4, 0, 4, 0);
            createAccountManagerFirstNameLabel.Name = "createAccountManagerFirstNameLabel";
            createAccountManagerFirstNameLabel.Size = new Size(86, 20);
            createAccountManagerFirstNameLabel.TabIndex = 6;
            createAccountManagerFirstNameLabel.Text = "First Name*";
            createAccountManagerFirstNameLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // createAccountManagerLastNameLabel
            // 
            createAccountManagerLastNameLabel.AutoSize = true;
            createAccountManagerLastNameLabel.Font = new Font("Segoe UI", 11F);
            createAccountManagerLastNameLabel.Location = new Point(78, 104);
            createAccountManagerLastNameLabel.Margin = new Padding(4, 0, 4, 0);
            createAccountManagerLastNameLabel.Name = "createAccountManagerLastNameLabel";
            createAccountManagerLastNameLabel.Size = new Size(85, 20);
            createAccountManagerLastNameLabel.TabIndex = 7;
            createAccountManagerLastNameLabel.Text = "Last Name*";
            createAccountManagerLastNameLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // createAccountManagerEmailAddressLabel
            // 
            createAccountManagerEmailAddressLabel.AutoSize = true;
            createAccountManagerEmailAddressLabel.Font = new Font("Segoe UI", 11F);
            createAccountManagerEmailAddressLabel.Location = new Point(54, 146);
            createAccountManagerEmailAddressLabel.Margin = new Padding(4, 0, 4, 0);
            createAccountManagerEmailAddressLabel.Name = "createAccountManagerEmailAddressLabel";
            createAccountManagerEmailAddressLabel.Size = new Size(109, 20);
            createAccountManagerEmailAddressLabel.TabIndex = 8;
            createAccountManagerEmailAddressLabel.Text = "Email Address*";
            createAccountManagerEmailAddressLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // createAccountManagerTelephoneNumberLabel
            // 
            createAccountManagerTelephoneNumberLabel.AutoSize = true;
            createAccountManagerTelephoneNumberLabel.Font = new Font("Segoe UI", 11F);
            createAccountManagerTelephoneNumberLabel.Location = new Point(20, 187);
            createAccountManagerTelephoneNumberLabel.Margin = new Padding(4, 0, 4, 0);
            createAccountManagerTelephoneNumberLabel.Name = "createAccountManagerTelephoneNumberLabel";
            createAccountManagerTelephoneNumberLabel.Size = new Size(142, 20);
            createAccountManagerTelephoneNumberLabel.TabIndex = 9;
            createAccountManagerTelephoneNumberLabel.Text = "Telephone Number*";
            createAccountManagerTelephoneNumberLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // createAccountManagerActiveStatusCheckbox
            // 
            createAccountManagerActiveStatusCheckbox.AutoSize = true;
            createAccountManagerActiveStatusCheckbox.Checked = true;
            createAccountManagerActiveStatusCheckbox.CheckState = CheckState.Checked;
            createAccountManagerActiveStatusCheckbox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createAccountManagerActiveStatusCheckbox.Location = new Point(183, 245);
            createAccountManagerActiveStatusCheckbox.Margin = new Padding(4);
            createAccountManagerActiveStatusCheckbox.Name = "createAccountManagerActiveStatusCheckbox";
            createAccountManagerActiveStatusCheckbox.Size = new Size(190, 24);
            createAccountManagerActiveStatusCheckbox.TabIndex = 10;
            createAccountManagerActiveStatusCheckbox.Text = "Active Account Manager";
            createAccountManagerActiveStatusCheckbox.UseVisualStyleBackColor = true;
            // 
            // createAccountManagerStatusStrip
            // 
            createAccountManagerStatusStrip.BackColor = SystemColors.Control;
            createAccountManagerStatusStrip.Items.AddRange(new ToolStripItem[] { createAccountManagerStatusStripCompanyConfigurationPlaceholder });
            createAccountManagerStatusStrip.Location = new Point(0, 377);
            createAccountManagerStatusStrip.Name = "createAccountManagerStatusStrip";
            createAccountManagerStatusStrip.Size = new Size(551, 22);
            createAccountManagerStatusStrip.TabIndex = 5;
            createAccountManagerStatusStrip.Text = "Create Account Manager Status Strip";
            // 
            // createAccountManagerStatusStripCompanyConfigurationPlaceholder
            // 
            createAccountManagerStatusStripCompanyConfigurationPlaceholder.BackColor = SystemColors.Control;
            createAccountManagerStatusStripCompanyConfigurationPlaceholder.DropDownItems.AddRange(new ToolStripItem[] { changeActiveCompanyConfigurationToolStripMenuItem });
            createAccountManagerStatusStripCompanyConfigurationPlaceholder.Name = "createAccountManagerStatusStripCompanyConfigurationPlaceholder";
            createAccountManagerStatusStripCompanyConfigurationPlaceholder.Size = new Size(225, 20);
            createAccountManagerStatusStripCompanyConfigurationPlaceholder.Text = "{Company Configuration Placeholder}";
            createAccountManagerStatusStripCompanyConfigurationPlaceholder.ToolTipText = "You can change Active Company Configuration here";
            // 
            // changeActiveCompanyConfigurationToolStripMenuItem
            // 
            changeActiveCompanyConfigurationToolStripMenuItem.Name = "changeActiveCompanyConfigurationToolStripMenuItem";
            changeActiveCompanyConfigurationToolStripMenuItem.Size = new Size(283, 22);
            changeActiveCompanyConfigurationToolStripMenuItem.Text = "Change Active Company Configuration";
            changeActiveCompanyConfigurationToolStripMenuItem.Click += changeActiveCompanyConfigurationToolStripMenuItem_Click;
            // 
            // CreateAccountManager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(551, 399);
            Controls.Add(createAccountManagerStatusStrip);
            Controls.Add(createAccountManagerActiveStatusCheckbox);
            Controls.Add(createAccountManagerTelephoneNumberLabel);
            Controls.Add(createAccountManagerEmailAddressLabel);
            Controls.Add(createAccountManagerLastNameLabel);
            Controls.Add(createAccountManagerFirstNameLabel);
            Controls.Add(createAccountManagerSubmitButton);
            Controls.Add(createAccountManagerLastNameTextBox);
            Controls.Add(createAccountManagerEmailAddressTextBox);
            Controls.Add(createAccountManagerTelephoneNumberTextBox);
            Controls.Add(createAccountManagerFirstNameTextBox);
            Controls.Add(createAccountManagerTitleLabel);
            Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "CreateAccountManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - Create Account Manager";
            createAccountManagerStatusStrip.ResumeLayout(false);
            createAccountManagerStatusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label createAccountManagerTitleLabel;
        private TextBox createAccountManagerFirstNameTextBox;
        private TextBox createAccountManagerTelephoneNumberTextBox;
        private TextBox createAccountManagerEmailAddressTextBox;
        private TextBox createAccountManagerLastNameTextBox;
        private Button createAccountManagerSubmitButton;
        private Label createAccountManagerFirstNameLabel;
        private Label createAccountManagerLastNameLabel;
        private Label createAccountManagerEmailAddressLabel;
        private Label createAccountManagerTelephoneNumberLabel;
        private CheckBox createAccountManagerActiveStatusCheckbox;
        private StatusStrip createAccountManagerStatusStrip;
        private ToolStripSplitButton createAccountManagerStatusStripCompanyConfigurationPlaceholder;
        private ToolStripMenuItem changeActiveCompanyConfigurationToolStripMenuItem;
    }
}