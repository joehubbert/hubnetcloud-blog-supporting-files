namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    partial class CreateContact
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
            createContactTitleLabel = new Label();
            createContactEmailAddressTextbox = new TextBox();
            createContactEmailAddressTextboxLabel = new Label();
            createContactSubmitButton = new Button();
            createContactActiveStatusCheckbox = new CheckBox();
            createContactFirstNameTextboxLabel = new Label();
            createContactFirstNameTextbox = new TextBox();
            createContactLastNameTextboxLabel = new Label();
            createContactLastNameTextbox = new TextBox();
            createContactTelephoneNumberTextboxLabel = new Label();
            createContactTelephoneNumberTextbox = new TextBox();
            createContactRoleTextboxLabel = new Label();
            createContactRoleTextbox = new TextBox();
            createContactStatusStrip = new StatusStrip();
            createContactStatusStripDataSubjectPlaceholder = new ToolStripStatusLabel();
            createContactStatusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // createContactTitleLabel
            // 
            createContactTitleLabel.AutoSize = true;
            createContactTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createContactTitleLabel.Location = new Point(13, 9);
            createContactTitleLabel.Margin = new Padding(4, 0, 4, 0);
            createContactTitleLabel.Name = "createContactTitleLabel";
            createContactTitleLabel.Size = new Size(398, 32);
            createContactTitleLabel.TabIndex = 7;
            createContactTitleLabel.Text = "{Create Contact Title Placeholder}";
            // 
            // createContactEmailAddressTextbox
            // 
            createContactEmailAddressTextbox.Location = new Point(193, 150);
            createContactEmailAddressTextbox.MaxLength = 50;
            createContactEmailAddressTextbox.Name = "createContactEmailAddressTextbox";
            createContactEmailAddressTextbox.Size = new Size(280, 27);
            createContactEmailAddressTextbox.TabIndex = 2;
            // 
            // createContactEmailAddressTextboxLabel
            // 
            createContactEmailAddressTextboxLabel.AutoSize = true;
            createContactEmailAddressTextboxLabel.Location = new Point(85, 153);
            createContactEmailAddressTextboxLabel.Name = "createContactEmailAddressTextboxLabel";
            createContactEmailAddressTextboxLabel.Size = new Size(109, 20);
            createContactEmailAddressTextboxLabel.TabIndex = 11;
            createContactEmailAddressTextboxLabel.Text = "Email Address*";
            createContactEmailAddressTextboxLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // createContactSubmitButton
            // 
            createContactSubmitButton.FlatStyle = FlatStyle.Flat;
            createContactSubmitButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createContactSubmitButton.Location = new Point(172, 328);
            createContactSubmitButton.Margin = new Padding(4);
            createContactSubmitButton.Name = "createContactSubmitButton";
            createContactSubmitButton.Size = new Size(198, 66);
            createContactSubmitButton.TabIndex = 6;
            createContactSubmitButton.Text = "Submit";
            createContactSubmitButton.UseVisualStyleBackColor = true;
            createContactSubmitButton.Click += createContactSubmitButton_Click;
            // 
            // createContactActiveStatusCheckbox
            // 
            createContactActiveStatusCheckbox.AutoSize = true;
            createContactActiveStatusCheckbox.Checked = true;
            createContactActiveStatusCheckbox.CheckState = CheckState.Checked;
            createContactActiveStatusCheckbox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createContactActiveStatusCheckbox.Location = new Point(190, 295);
            createContactActiveStatusCheckbox.Margin = new Padding(5);
            createContactActiveStatusCheckbox.Name = "createContactActiveStatusCheckbox";
            createContactActiveStatusCheckbox.Size = new Size(169, 24);
            createContactActiveStatusCheckbox.TabIndex = 5;
            createContactActiveStatusCheckbox.Text = "Active {Contact Type}";
            createContactActiveStatusCheckbox.UseVisualStyleBackColor = true;
            // 
            // createContactFirstNameTextboxLabel
            // 
            createContactFirstNameTextboxLabel.AutoSize = true;
            createContactFirstNameTextboxLabel.Location = new Point(107, 75);
            createContactFirstNameTextboxLabel.Name = "createContactFirstNameTextboxLabel";
            createContactFirstNameTextboxLabel.Size = new Size(86, 20);
            createContactFirstNameTextboxLabel.TabIndex = 16;
            createContactFirstNameTextboxLabel.Text = "First Name*";
            createContactFirstNameTextboxLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // createContactFirstNameTextbox
            // 
            createContactFirstNameTextbox.Location = new Point(193, 72);
            createContactFirstNameTextbox.MaxLength = 30;
            createContactFirstNameTextbox.Name = "createContactFirstNameTextbox";
            createContactFirstNameTextbox.Size = new Size(280, 27);
            createContactFirstNameTextbox.TabIndex = 0;
            // 
            // createContactLastNameTextboxLabel
            // 
            createContactLastNameTextboxLabel.AutoSize = true;
            createContactLastNameTextboxLabel.Location = new Point(107, 114);
            createContactLastNameTextboxLabel.Name = "createContactLastNameTextboxLabel";
            createContactLastNameTextboxLabel.Size = new Size(85, 20);
            createContactLastNameTextboxLabel.TabIndex = 18;
            createContactLastNameTextboxLabel.Text = "Last Name*";
            createContactLastNameTextboxLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // createContactLastNameTextbox
            // 
            createContactLastNameTextbox.Location = new Point(193, 111);
            createContactLastNameTextbox.MaxLength = 30;
            createContactLastNameTextbox.Name = "createContactLastNameTextbox";
            createContactLastNameTextbox.Size = new Size(280, 27);
            createContactLastNameTextbox.TabIndex = 1;
            // 
            // createContactTelephoneNumberTextboxLabel
            // 
            createContactTelephoneNumberTextboxLabel.AutoSize = true;
            createContactTelephoneNumberTextboxLabel.Location = new Point(51, 192);
            createContactTelephoneNumberTextboxLabel.Name = "createContactTelephoneNumberTextboxLabel";
            createContactTelephoneNumberTextboxLabel.Size = new Size(142, 20);
            createContactTelephoneNumberTextboxLabel.TabIndex = 20;
            createContactTelephoneNumberTextboxLabel.Text = "Telephone Number*";
            createContactTelephoneNumberTextboxLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // createContactTelephoneNumberTextbox
            // 
            createContactTelephoneNumberTextbox.Location = new Point(193, 189);
            createContactTelephoneNumberTextbox.MaxLength = 13;
            createContactTelephoneNumberTextbox.Name = "createContactTelephoneNumberTextbox";
            createContactTelephoneNumberTextbox.Size = new Size(280, 27);
            createContactTelephoneNumberTextbox.TabIndex = 3;
            // 
            // createContactRoleTextboxLabel
            // 
            createContactRoleTextboxLabel.AutoSize = true;
            createContactRoleTextboxLabel.Location = new Point(148, 231);
            createContactRoleTextboxLabel.Name = "createContactRoleTextboxLabel";
            createContactRoleTextboxLabel.Size = new Size(45, 20);
            createContactRoleTextboxLabel.TabIndex = 22;
            createContactRoleTextboxLabel.Text = "Role*";
            createContactRoleTextboxLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // createContactRoleTextbox
            // 
            createContactRoleTextbox.Location = new Point(193, 228);
            createContactRoleTextbox.MaxLength = 50;
            createContactRoleTextbox.Name = "createContactRoleTextbox";
            createContactRoleTextbox.Size = new Size(280, 27);
            createContactRoleTextbox.TabIndex = 4;
            // 
            // createContactStatusStrip
            // 
            createContactStatusStrip.Items.AddRange(new ToolStripItem[] { createContactStatusStripDataSubjectPlaceholder });
            createContactStatusStrip.Location = new Point(0, 415);
            createContactStatusStrip.Name = "createContactStatusStrip";
            createContactStatusStrip.Size = new Size(538, 22);
            createContactStatusStrip.TabIndex = 7;
            createContactStatusStrip.Text = "Create Contact Status Strip";
            // 
            // createContactStatusStripDataSubjectPlaceholder
            // 
            createContactStatusStripDataSubjectPlaceholder.Name = "createContactStatusStripDataSubjectPlaceholder";
            createContactStatusStripDataSubjectPlaceholder.Size = new Size(146, 17);
            createContactStatusStripDataSubjectPlaceholder.Text = "{Data Subject Placeholder}";
            // 
            // CreateContact
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(538, 437);
            Controls.Add(createContactStatusStrip);
            Controls.Add(createContactRoleTextboxLabel);
            Controls.Add(createContactRoleTextbox);
            Controls.Add(createContactTelephoneNumberTextboxLabel);
            Controls.Add(createContactTelephoneNumberTextbox);
            Controls.Add(createContactLastNameTextboxLabel);
            Controls.Add(createContactLastNameTextbox);
            Controls.Add(createContactFirstNameTextboxLabel);
            Controls.Add(createContactFirstNameTextbox);
            Controls.Add(createContactActiveStatusCheckbox);
            Controls.Add(createContactSubmitButton);
            Controls.Add(createContactEmailAddressTextboxLabel);
            Controls.Add(createContactEmailAddressTextbox);
            Controls.Add(createContactTitleLabel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "CreateContact";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CreateContact";
            createContactStatusStrip.ResumeLayout(false);
            createContactStatusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label createContactTitleLabel;
        private TextBox createContactEmailAddressTextbox;
        private Label createContactEmailAddressTextboxLabel;
        private Button createContactSubmitButton;
        private CheckBox createContactActiveStatusCheckbox;
        private Label createContactFirstNameTextboxLabel;
        private TextBox createContactFirstNameTextbox;
        private Label createContactLastNameTextboxLabel;
        private TextBox createContactLastNameTextbox;
        private Label createContactTelephoneNumberTextboxLabel;
        private TextBox createContactTelephoneNumberTextbox;
        private Label createContactRoleTextboxLabel;
        private TextBox createContactRoleTextbox;
        private StatusStrip createContactStatusStrip;
        private ToolStripStatusLabel createContactStatusStripDataSubjectPlaceholder;
    }
}