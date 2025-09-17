namespace CRM.Presentation.Contact
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
            createContactEmailAddressTextBox = new TextBox();
            createContactEmailAddressTextBoxLabel = new Label();
            createContactSubmitButton = new Button();
            createContactActiveStatusCheckBox = new CheckBox();
            createContactFirstNameTextBoxLabel = new Label();
            createContactFirstNameTextBox = new TextBox();
            createContactLastNameTextBoxLabel = new Label();
            createContactLastNameTextBox = new TextBox();
            createContactTelephoneNumberTextBoxLabel = new Label();
            createContactTelephoneNumberTextBox = new TextBox();
            createContactRoleTextBoxLabel = new Label();
            createContactRoleTextBox = new TextBox();
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
            // createContactEmailAddressTextBox
            // 
            createContactEmailAddressTextBox.Location = new Point(193, 150);
            createContactEmailAddressTextBox.MaxLength = 50;
            createContactEmailAddressTextBox.Name = "createContactEmailAddressTextBox";
            createContactEmailAddressTextBox.Size = new Size(280, 27);
            createContactEmailAddressTextBox.TabIndex = 2;
            // 
            // createContactEmailAddressTextBoxLabel
            // 
            createContactEmailAddressTextBoxLabel.AutoSize = true;
            createContactEmailAddressTextBoxLabel.Location = new Point(85, 153);
            createContactEmailAddressTextBoxLabel.Name = "createContactEmailAddressTextBoxLabel";
            createContactEmailAddressTextBoxLabel.Size = new Size(109, 20);
            createContactEmailAddressTextBoxLabel.TabIndex = 11;
            createContactEmailAddressTextBoxLabel.Text = "Email Address*";
            createContactEmailAddressTextBoxLabel.TextAlign = ContentAlignment.TopRight;
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
            // createContactActiveStatusCheckBox
            // 
            createContactActiveStatusCheckBox.AutoSize = true;
            createContactActiveStatusCheckBox.Checked = true;
            createContactActiveStatusCheckBox.CheckState = CheckState.Checked;
            createContactActiveStatusCheckBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createContactActiveStatusCheckBox.Location = new Point(190, 295);
            createContactActiveStatusCheckBox.Margin = new Padding(5);
            createContactActiveStatusCheckBox.Name = "createContactActiveStatusCheckBox";
            createContactActiveStatusCheckBox.Size = new Size(175, 24);
            createContactActiveStatusCheckBox.TabIndex = 5;
            createContactActiveStatusCheckBox.Text = "Active {Contact Type}*";
            createContactActiveStatusCheckBox.UseVisualStyleBackColor = true;
            // 
            // createContactFirstNameTextBoxLabel
            // 
            createContactFirstNameTextBoxLabel.AutoSize = true;
            createContactFirstNameTextBoxLabel.Location = new Point(107, 75);
            createContactFirstNameTextBoxLabel.Name = "createContactFirstNameTextBoxLabel";
            createContactFirstNameTextBoxLabel.Size = new Size(86, 20);
            createContactFirstNameTextBoxLabel.TabIndex = 16;
            createContactFirstNameTextBoxLabel.Text = "First Name*";
            createContactFirstNameTextBoxLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // createContactFirstNameTextBox
            // 
            createContactFirstNameTextBox.Location = new Point(193, 72);
            createContactFirstNameTextBox.MaxLength = 30;
            createContactFirstNameTextBox.Name = "createContactFirstNameTextBox";
            createContactFirstNameTextBox.Size = new Size(280, 27);
            createContactFirstNameTextBox.TabIndex = 0;
            // 
            // createContactLastNameTextBoxLabel
            // 
            createContactLastNameTextBoxLabel.AutoSize = true;
            createContactLastNameTextBoxLabel.Location = new Point(107, 114);
            createContactLastNameTextBoxLabel.Name = "createContactLastNameTextBoxLabel";
            createContactLastNameTextBoxLabel.Size = new Size(85, 20);
            createContactLastNameTextBoxLabel.TabIndex = 18;
            createContactLastNameTextBoxLabel.Text = "Last Name*";
            createContactLastNameTextBoxLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // createContactLastNameTextBox
            // 
            createContactLastNameTextBox.Location = new Point(193, 111);
            createContactLastNameTextBox.MaxLength = 30;
            createContactLastNameTextBox.Name = "createContactLastNameTextBox";
            createContactLastNameTextBox.Size = new Size(280, 27);
            createContactLastNameTextBox.TabIndex = 1;
            // 
            // createContactTelephoneNumberTextBoxLabel
            // 
            createContactTelephoneNumberTextBoxLabel.AutoSize = true;
            createContactTelephoneNumberTextBoxLabel.Location = new Point(51, 192);
            createContactTelephoneNumberTextBoxLabel.Name = "createContactTelephoneNumberTextBoxLabel";
            createContactTelephoneNumberTextBoxLabel.Size = new Size(142, 20);
            createContactTelephoneNumberTextBoxLabel.TabIndex = 20;
            createContactTelephoneNumberTextBoxLabel.Text = "Telephone Number*";
            createContactTelephoneNumberTextBoxLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // createContactTelephoneNumberTextBox
            // 
            createContactTelephoneNumberTextBox.Location = new Point(193, 189);
            createContactTelephoneNumberTextBox.MaxLength = 13;
            createContactTelephoneNumberTextBox.Name = "createContactTelephoneNumberTextBox";
            createContactTelephoneNumberTextBox.Size = new Size(280, 27);
            createContactTelephoneNumberTextBox.TabIndex = 3;
            // 
            // createContactRoleTextBoxLabel
            // 
            createContactRoleTextBoxLabel.AutoSize = true;
            createContactRoleTextBoxLabel.Location = new Point(148, 231);
            createContactRoleTextBoxLabel.Name = "createContactRoleTextBoxLabel";
            createContactRoleTextBoxLabel.Size = new Size(45, 20);
            createContactRoleTextBoxLabel.TabIndex = 22;
            createContactRoleTextBoxLabel.Text = "Role*";
            createContactRoleTextBoxLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // createContactRoleTextBox
            // 
            createContactRoleTextBox.Location = new Point(193, 228);
            createContactRoleTextBox.MaxLength = 50;
            createContactRoleTextBox.Name = "createContactRoleTextBox";
            createContactRoleTextBox.Size = new Size(280, 27);
            createContactRoleTextBox.TabIndex = 4;
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
            Controls.Add(createContactRoleTextBoxLabel);
            Controls.Add(createContactRoleTextBox);
            Controls.Add(createContactTelephoneNumberTextBoxLabel);
            Controls.Add(createContactTelephoneNumberTextBox);
            Controls.Add(createContactLastNameTextBoxLabel);
            Controls.Add(createContactLastNameTextBox);
            Controls.Add(createContactFirstNameTextBoxLabel);
            Controls.Add(createContactFirstNameTextBox);
            Controls.Add(createContactActiveStatusCheckBox);
            Controls.Add(createContactSubmitButton);
            Controls.Add(createContactEmailAddressTextBoxLabel);
            Controls.Add(createContactEmailAddressTextBox);
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
        private TextBox createContactEmailAddressTextBox;
        private Label createContactEmailAddressTextBoxLabel;
        private Button createContactSubmitButton;
        private CheckBox createContactActiveStatusCheckBox;
        private Label createContactFirstNameTextBoxLabel;
        private TextBox createContactFirstNameTextBox;
        private Label createContactLastNameTextBoxLabel;
        private TextBox createContactLastNameTextBox;
        private Label createContactTelephoneNumberTextBoxLabel;
        private TextBox createContactTelephoneNumberTextBox;
        private Label createContactRoleTextBoxLabel;
        private TextBox createContactRoleTextBox;
        private StatusStrip createContactStatusStrip;
        private ToolStripStatusLabel createContactStatusStripDataSubjectPlaceholder;
    }
}