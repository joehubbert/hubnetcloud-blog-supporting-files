namespace CRM_WindowsForms.Presentation
{
    partial class AccountManagerDetail
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
            accountManagerDetailTitleLabel = new Label();
            accountManagerDetailTabControl = new TabControl();
            accountManagerInformation = new TabPage();
            accountManagerDetailLastUpdatedTimestampLabel = new Label();
            accountManagerDetailCreatedTimestampLabel = new Label();
            accountManagerDetailLastUpdatedByLabel = new Label();
            accountManagerDetailCreatedByLabel = new Label();
            accountManagerDetailLastUpdatedByTextbox = new TextBox();
            accountManagerDetailCreatedTimestampTextbox = new TextBox();
            accountManagerDetailLastUpdatedTimestampTextbox = new TextBox();
            accountManagerDetailCreatedByTextbox = new TextBox();
            accountManagerDetailToggleEditModeButton = new Button();
            accountManagerDetailAccountManagerIdLabel = new Label();
            accountManagerDetailAccountManagerIdTextbox = new TextBox();
            accountManagerDetailUpdateAccountManagerButton = new Button();
            accountManagerDetailActiveStatusCheckbox = new CheckBox();
            accountManagerDetailTelephoneNumberLabel = new Label();
            accountManagerDetailEmailAddressLabel = new Label();
            accountManagerDetailLastNameLabel = new Label();
            accountManagerDetailFirstNameLabel = new Label();
            accountManagerDetailLastNameTextbox = new TextBox();
            accountManagerDetailEmailAddressTextbox = new TextBox();
            accountManagerDetailTelephoneNumberTextbox = new TextBox();
            accountManagerDetailFirstNameTextbox = new TextBox();
            associatedCustomers = new TabPage();
            accountManagerDetailAssociatedCustomerDataGridView = new DataGridView();
            accountManagerDetailTabControl.SuspendLayout();
            accountManagerInformation.SuspendLayout();
            associatedCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)accountManagerDetailAssociatedCustomerDataGridView).BeginInit();
            SuspendLayout();
            // 
            // accountManagerDetailTitleLabel
            // 
            accountManagerDetailTitleLabel.AutoSize = true;
            accountManagerDetailTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            accountManagerDetailTitleLabel.Location = new Point(13, 9);
            accountManagerDetailTitleLabel.Margin = new Padding(4, 0, 4, 0);
            accountManagerDetailTitleLabel.Name = "accountManagerDetailTitleLabel";
            accountManagerDetailTitleLabel.Size = new Size(292, 32);
            accountManagerDetailTitleLabel.TabIndex = 6;
            accountManagerDetailTitleLabel.Text = "Account Manager Detail";
            // 
            // accountManagerDetailTabControl
            // 
            accountManagerDetailTabControl.Appearance = TabAppearance.FlatButtons;
            accountManagerDetailTabControl.Controls.Add(accountManagerInformation);
            accountManagerDetailTabControl.Controls.Add(associatedCustomers);
            accountManagerDetailTabControl.Location = new Point(13, 56);
            accountManagerDetailTabControl.Multiline = true;
            accountManagerDetailTabControl.Name = "accountManagerDetailTabControl";
            accountManagerDetailTabControl.SelectedIndex = 0;
            accountManagerDetailTabControl.Size = new Size(1541, 600);
            accountManagerDetailTabControl.TabIndex = 0;
            // 
            // accountManagerInformation
            // 
            accountManagerInformation.BackColor = Color.LemonChiffon;
            accountManagerInformation.Controls.Add(accountManagerDetailLastUpdatedTimestampLabel);
            accountManagerInformation.Controls.Add(accountManagerDetailCreatedTimestampLabel);
            accountManagerInformation.Controls.Add(accountManagerDetailLastUpdatedByLabel);
            accountManagerInformation.Controls.Add(accountManagerDetailCreatedByLabel);
            accountManagerInformation.Controls.Add(accountManagerDetailLastUpdatedByTextbox);
            accountManagerInformation.Controls.Add(accountManagerDetailCreatedTimestampTextbox);
            accountManagerInformation.Controls.Add(accountManagerDetailLastUpdatedTimestampTextbox);
            accountManagerInformation.Controls.Add(accountManagerDetailCreatedByTextbox);
            accountManagerInformation.Controls.Add(accountManagerDetailToggleEditModeButton);
            accountManagerInformation.Controls.Add(accountManagerDetailAccountManagerIdLabel);
            accountManagerInformation.Controls.Add(accountManagerDetailAccountManagerIdTextbox);
            accountManagerInformation.Controls.Add(accountManagerDetailUpdateAccountManagerButton);
            accountManagerInformation.Controls.Add(accountManagerDetailActiveStatusCheckbox);
            accountManagerInformation.Controls.Add(accountManagerDetailTelephoneNumberLabel);
            accountManagerInformation.Controls.Add(accountManagerDetailEmailAddressLabel);
            accountManagerInformation.Controls.Add(accountManagerDetailLastNameLabel);
            accountManagerInformation.Controls.Add(accountManagerDetailFirstNameLabel);
            accountManagerInformation.Controls.Add(accountManagerDetailLastNameTextbox);
            accountManagerInformation.Controls.Add(accountManagerDetailEmailAddressTextbox);
            accountManagerInformation.Controls.Add(accountManagerDetailTelephoneNumberTextbox);
            accountManagerInformation.Controls.Add(accountManagerDetailFirstNameTextbox);
            accountManagerInformation.Location = new Point(4, 32);
            accountManagerInformation.Name = "accountManagerInformation";
            accountManagerInformation.Padding = new Padding(3);
            accountManagerInformation.Size = new Size(1533, 564);
            accountManagerInformation.TabIndex = 0;
            accountManagerInformation.Text = "Account Manager Information";
            // 
            // accountManagerDetailLastUpdatedTimestampLabel
            // 
            accountManagerDetailLastUpdatedTimestampLabel.AutoSize = true;
            accountManagerDetailLastUpdatedTimestampLabel.Font = new Font("Segoe UI", 11F);
            accountManagerDetailLastUpdatedTimestampLabel.Location = new Point(700, 180);
            accountManagerDetailLastUpdatedTimestampLabel.Margin = new Padding(4, 0, 4, 0);
            accountManagerDetailLastUpdatedTimestampLabel.Name = "accountManagerDetailLastUpdatedTimestampLabel";
            accountManagerDetailLastUpdatedTimestampLabel.Size = new Size(175, 20);
            accountManagerDetailLastUpdatedTimestampLabel.TabIndex = 32;
            accountManagerDetailLastUpdatedTimestampLabel.Text = "Last Updated Timestamp";
            // 
            // accountManagerDetailCreatedTimestampLabel
            // 
            accountManagerDetailCreatedTimestampLabel.AutoSize = true;
            accountManagerDetailCreatedTimestampLabel.Font = new Font("Segoe UI", 11F);
            accountManagerDetailCreatedTimestampLabel.Location = new Point(735, 106);
            accountManagerDetailCreatedTimestampLabel.Margin = new Padding(4, 0, 4, 0);
            accountManagerDetailCreatedTimestampLabel.Name = "accountManagerDetailCreatedTimestampLabel";
            accountManagerDetailCreatedTimestampLabel.Size = new Size(139, 20);
            accountManagerDetailCreatedTimestampLabel.TabIndex = 31;
            accountManagerDetailCreatedTimestampLabel.Text = "Created Timestamp";
            // 
            // accountManagerDetailLastUpdatedByLabel
            // 
            accountManagerDetailLastUpdatedByLabel.AutoSize = true;
            accountManagerDetailLastUpdatedByLabel.Font = new Font("Segoe UI", 11F);
            accountManagerDetailLastUpdatedByLabel.Location = new Point(757, 143);
            accountManagerDetailLastUpdatedByLabel.Margin = new Padding(4, 0, 4, 0);
            accountManagerDetailLastUpdatedByLabel.Name = "accountManagerDetailLastUpdatedByLabel";
            accountManagerDetailLastUpdatedByLabel.Size = new Size(117, 20);
            accountManagerDetailLastUpdatedByLabel.TabIndex = 30;
            accountManagerDetailLastUpdatedByLabel.Text = "Last Updated By";
            // 
            // accountManagerDetailCreatedByLabel
            // 
            accountManagerDetailCreatedByLabel.AutoSize = true;
            accountManagerDetailCreatedByLabel.Font = new Font("Segoe UI", 11F);
            accountManagerDetailCreatedByLabel.Location = new Point(794, 69);
            accountManagerDetailCreatedByLabel.Margin = new Padding(4, 0, 4, 0);
            accountManagerDetailCreatedByLabel.Name = "accountManagerDetailCreatedByLabel";
            accountManagerDetailCreatedByLabel.Size = new Size(81, 20);
            accountManagerDetailCreatedByLabel.TabIndex = 29;
            accountManagerDetailCreatedByLabel.Text = "Created By";
            // 
            // accountManagerDetailLastUpdatedByTextbox
            // 
            accountManagerDetailLastUpdatedByTextbox.Font = new Font("Segoe UI", 11F);
            accountManagerDetailLastUpdatedByTextbox.Location = new Point(894, 140);
            accountManagerDetailLastUpdatedByTextbox.Margin = new Padding(4);
            accountManagerDetailLastUpdatedByTextbox.MaxLength = 50;
            accountManagerDetailLastUpdatedByTextbox.Name = "accountManagerDetailLastUpdatedByTextbox";
            accountManagerDetailLastUpdatedByTextbox.ReadOnly = true;
            accountManagerDetailLastUpdatedByTextbox.Size = new Size(340, 27);
            accountManagerDetailLastUpdatedByTextbox.TabIndex = 9;
            // 
            // accountManagerDetailCreatedTimestampTextbox
            // 
            accountManagerDetailCreatedTimestampTextbox.Font = new Font("Segoe UI", 11F);
            accountManagerDetailCreatedTimestampTextbox.Location = new Point(894, 103);
            accountManagerDetailCreatedTimestampTextbox.Margin = new Padding(4);
            accountManagerDetailCreatedTimestampTextbox.MaxLength = 50;
            accountManagerDetailCreatedTimestampTextbox.Name = "accountManagerDetailCreatedTimestampTextbox";
            accountManagerDetailCreatedTimestampTextbox.ReadOnly = true;
            accountManagerDetailCreatedTimestampTextbox.Size = new Size(340, 27);
            accountManagerDetailCreatedTimestampTextbox.TabIndex = 8;
            // 
            // accountManagerDetailLastUpdatedTimestampTextbox
            // 
            accountManagerDetailLastUpdatedTimestampTextbox.Font = new Font("Segoe UI", 11F);
            accountManagerDetailLastUpdatedTimestampTextbox.Location = new Point(894, 177);
            accountManagerDetailLastUpdatedTimestampTextbox.Margin = new Padding(4);
            accountManagerDetailLastUpdatedTimestampTextbox.MaxLength = 13;
            accountManagerDetailLastUpdatedTimestampTextbox.Name = "accountManagerDetailLastUpdatedTimestampTextbox";
            accountManagerDetailLastUpdatedTimestampTextbox.ReadOnly = true;
            accountManagerDetailLastUpdatedTimestampTextbox.Size = new Size(340, 27);
            accountManagerDetailLastUpdatedTimestampTextbox.TabIndex = 10;
            // 
            // accountManagerDetailCreatedByTextbox
            // 
            accountManagerDetailCreatedByTextbox.Font = new Font("Segoe UI", 11F);
            accountManagerDetailCreatedByTextbox.Location = new Point(894, 66);
            accountManagerDetailCreatedByTextbox.Margin = new Padding(4);
            accountManagerDetailCreatedByTextbox.MaxLength = 50;
            accountManagerDetailCreatedByTextbox.Name = "accountManagerDetailCreatedByTextbox";
            accountManagerDetailCreatedByTextbox.ReadOnly = true;
            accountManagerDetailCreatedByTextbox.Size = new Size(340, 27);
            accountManagerDetailCreatedByTextbox.TabIndex = 7;
            // 
            // accountManagerDetailToggleEditModeButton
            // 
            accountManagerDetailToggleEditModeButton.FlatStyle = FlatStyle.Flat;
            accountManagerDetailToggleEditModeButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            accountManagerDetailToggleEditModeButton.Location = new Point(1403, 22);
            accountManagerDetailToggleEditModeButton.Margin = new Padding(4);
            accountManagerDetailToggleEditModeButton.Name = "accountManagerDetailToggleEditModeButton";
            accountManagerDetailToggleEditModeButton.Size = new Size(108, 92);
            accountManagerDetailToggleEditModeButton.TabIndex = 11;
            accountManagerDetailToggleEditModeButton.Text = "Toggle Edit Mode";
            accountManagerDetailToggleEditModeButton.UseVisualStyleBackColor = true;
            accountManagerDetailToggleEditModeButton.Click += accountManagerDetailToggleEditModeButton_Click;
            // 
            // accountManagerDetailAccountManagerIdLabel
            // 
            accountManagerDetailAccountManagerIdLabel.AutoSize = true;
            accountManagerDetailAccountManagerIdLabel.Font = new Font("Segoe UI", 11F);
            accountManagerDetailAccountManagerIdLabel.Location = new Point(24, 25);
            accountManagerDetailAccountManagerIdLabel.Margin = new Padding(4, 0, 4, 0);
            accountManagerDetailAccountManagerIdLabel.Name = "accountManagerDetailAccountManagerIdLabel";
            accountManagerDetailAccountManagerIdLabel.Size = new Size(143, 20);
            accountManagerDetailAccountManagerIdLabel.TabIndex = 23;
            accountManagerDetailAccountManagerIdLabel.Text = "Account Manager Id";
            // 
            // accountManagerDetailAccountManagerIdTextbox
            // 
            accountManagerDetailAccountManagerIdTextbox.Font = new Font("Segoe UI", 11F);
            accountManagerDetailAccountManagerIdTextbox.Location = new Point(184, 22);
            accountManagerDetailAccountManagerIdTextbox.Margin = new Padding(4);
            accountManagerDetailAccountManagerIdTextbox.MaxLength = 36;
            accountManagerDetailAccountManagerIdTextbox.Name = "accountManagerDetailAccountManagerIdTextbox";
            accountManagerDetailAccountManagerIdTextbox.ReadOnly = true;
            accountManagerDetailAccountManagerIdTextbox.Size = new Size(340, 27);
            accountManagerDetailAccountManagerIdTextbox.TabIndex = 1;
            // 
            // accountManagerDetailUpdateAccountManagerButton
            // 
            accountManagerDetailUpdateAccountManagerButton.Enabled = false;
            accountManagerDetailUpdateAccountManagerButton.FlatStyle = FlatStyle.Flat;
            accountManagerDetailUpdateAccountManagerButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            accountManagerDetailUpdateAccountManagerButton.Location = new Point(630, 395);
            accountManagerDetailUpdateAccountManagerButton.Margin = new Padding(4);
            accountManagerDetailUpdateAccountManagerButton.Name = "accountManagerDetailUpdateAccountManagerButton";
            accountManagerDetailUpdateAccountManagerButton.Size = new Size(214, 67);
            accountManagerDetailUpdateAccountManagerButton.TabIndex = 12;
            accountManagerDetailUpdateAccountManagerButton.Text = "Update Account Manager";
            accountManagerDetailUpdateAccountManagerButton.UseVisualStyleBackColor = true;
            accountManagerDetailUpdateAccountManagerButton.Click += accountManagerDetailUpdateAccountManagerButton_Click;
            // 
            // accountManagerDetailActiveStatusCheckbox
            // 
            accountManagerDetailActiveStatusCheckbox.AutoSize = true;
            accountManagerDetailActiveStatusCheckbox.Enabled = false;
            accountManagerDetailActiveStatusCheckbox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            accountManagerDetailActiveStatusCheckbox.Location = new Point(184, 253);
            accountManagerDetailActiveStatusCheckbox.Margin = new Padding(4);
            accountManagerDetailActiveStatusCheckbox.Name = "accountManagerDetailActiveStatusCheckbox";
            accountManagerDetailActiveStatusCheckbox.Size = new Size(190, 24);
            accountManagerDetailActiveStatusCheckbox.TabIndex = 6;
            accountManagerDetailActiveStatusCheckbox.Text = "Active Account Manager";
            accountManagerDetailActiveStatusCheckbox.UseVisualStyleBackColor = true;
            // 
            // accountManagerDetailTelephoneNumberLabel
            // 
            accountManagerDetailTelephoneNumberLabel.AutoSize = true;
            accountManagerDetailTelephoneNumberLabel.Font = new Font("Segoe UI", 11F);
            accountManagerDetailTelephoneNumberLabel.Location = new Point(31, 180);
            accountManagerDetailTelephoneNumberLabel.Margin = new Padding(4, 0, 4, 0);
            accountManagerDetailTelephoneNumberLabel.Name = "accountManagerDetailTelephoneNumberLabel";
            accountManagerDetailTelephoneNumberLabel.Size = new Size(136, 20);
            accountManagerDetailTelephoneNumberLabel.TabIndex = 18;
            accountManagerDetailTelephoneNumberLabel.Text = "Telephone Number";
            // 
            // accountManagerDetailEmailAddressLabel
            // 
            accountManagerDetailEmailAddressLabel.AutoSize = true;
            accountManagerDetailEmailAddressLabel.Font = new Font("Segoe UI", 11F);
            accountManagerDetailEmailAddressLabel.Location = new Point(64, 106);
            accountManagerDetailEmailAddressLabel.Margin = new Padding(4, 0, 4, 0);
            accountManagerDetailEmailAddressLabel.Name = "accountManagerDetailEmailAddressLabel";
            accountManagerDetailEmailAddressLabel.Size = new Size(103, 20);
            accountManagerDetailEmailAddressLabel.TabIndex = 17;
            accountManagerDetailEmailAddressLabel.Text = "Email Address";
            // 
            // accountManagerDetailLastNameLabel
            // 
            accountManagerDetailLastNameLabel.AutoSize = true;
            accountManagerDetailLastNameLabel.Font = new Font("Segoe UI", 11F);
            accountManagerDetailLastNameLabel.Location = new Point(88, 143);
            accountManagerDetailLastNameLabel.Margin = new Padding(4, 0, 4, 0);
            accountManagerDetailLastNameLabel.Name = "accountManagerDetailLastNameLabel";
            accountManagerDetailLastNameLabel.Size = new Size(79, 20);
            accountManagerDetailLastNameLabel.TabIndex = 16;
            accountManagerDetailLastNameLabel.Text = "Last Name";
            // 
            // accountManagerDetailFirstNameLabel
            // 
            accountManagerDetailFirstNameLabel.AutoSize = true;
            accountManagerDetailFirstNameLabel.Font = new Font("Segoe UI", 11F);
            accountManagerDetailFirstNameLabel.Location = new Point(87, 69);
            accountManagerDetailFirstNameLabel.Margin = new Padding(4, 0, 4, 0);
            accountManagerDetailFirstNameLabel.Name = "accountManagerDetailFirstNameLabel";
            accountManagerDetailFirstNameLabel.Size = new Size(80, 20);
            accountManagerDetailFirstNameLabel.TabIndex = 15;
            accountManagerDetailFirstNameLabel.Text = "First Name";
            // 
            // accountManagerDetailLastNameTextbox
            // 
            accountManagerDetailLastNameTextbox.Enabled = false;
            accountManagerDetailLastNameTextbox.Font = new Font("Segoe UI", 11F);
            accountManagerDetailLastNameTextbox.Location = new Point(184, 140);
            accountManagerDetailLastNameTextbox.Margin = new Padding(4);
            accountManagerDetailLastNameTextbox.MaxLength = 50;
            accountManagerDetailLastNameTextbox.Name = "accountManagerDetailLastNameTextbox";
            accountManagerDetailLastNameTextbox.Size = new Size(340, 27);
            accountManagerDetailLastNameTextbox.TabIndex = 4;
            // 
            // accountManagerDetailEmailAddressTextbox
            // 
            accountManagerDetailEmailAddressTextbox.Enabled = false;
            accountManagerDetailEmailAddressTextbox.Font = new Font("Segoe UI", 11F);
            accountManagerDetailEmailAddressTextbox.Location = new Point(184, 103);
            accountManagerDetailEmailAddressTextbox.Margin = new Padding(4);
            accountManagerDetailEmailAddressTextbox.MaxLength = 50;
            accountManagerDetailEmailAddressTextbox.Name = "accountManagerDetailEmailAddressTextbox";
            accountManagerDetailEmailAddressTextbox.Size = new Size(340, 27);
            accountManagerDetailEmailAddressTextbox.TabIndex = 3;
            // 
            // accountManagerDetailTelephoneNumberTextbox
            // 
            accountManagerDetailTelephoneNumberTextbox.Enabled = false;
            accountManagerDetailTelephoneNumberTextbox.Font = new Font("Segoe UI", 11F);
            accountManagerDetailTelephoneNumberTextbox.Location = new Point(184, 177);
            accountManagerDetailTelephoneNumberTextbox.Margin = new Padding(4);
            accountManagerDetailTelephoneNumberTextbox.MaxLength = 13;
            accountManagerDetailTelephoneNumberTextbox.Name = "accountManagerDetailTelephoneNumberTextbox";
            accountManagerDetailTelephoneNumberTextbox.Size = new Size(340, 27);
            accountManagerDetailTelephoneNumberTextbox.TabIndex = 5;
            // 
            // accountManagerDetailFirstNameTextbox
            // 
            accountManagerDetailFirstNameTextbox.Enabled = false;
            accountManagerDetailFirstNameTextbox.Font = new Font("Segoe UI", 11F);
            accountManagerDetailFirstNameTextbox.Location = new Point(184, 66);
            accountManagerDetailFirstNameTextbox.Margin = new Padding(4);
            accountManagerDetailFirstNameTextbox.MaxLength = 50;
            accountManagerDetailFirstNameTextbox.Name = "accountManagerDetailFirstNameTextbox";
            accountManagerDetailFirstNameTextbox.Size = new Size(340, 27);
            accountManagerDetailFirstNameTextbox.TabIndex = 2;
            // 
            // associatedCustomers
            // 
            associatedCustomers.BackColor = Color.LemonChiffon;
            associatedCustomers.Controls.Add(accountManagerDetailAssociatedCustomerDataGridView);
            associatedCustomers.Location = new Point(4, 27);
            associatedCustomers.Name = "associatedCustomers";
            associatedCustomers.Padding = new Padding(3);
            associatedCustomers.Size = new Size(1533, 569);
            associatedCustomers.TabIndex = 1;
            associatedCustomers.Text = "Associated Customers";
            // 
            // accountManagerDetailAssociatedCustomerDataGridView
            // 
            accountManagerDetailAssociatedCustomerDataGridView.AllowUserToAddRows = false;
            accountManagerDetailAssociatedCustomerDataGridView.AllowUserToDeleteRows = false;
            accountManagerDetailAssociatedCustomerDataGridView.AllowUserToOrderColumns = true;
            accountManagerDetailAssociatedCustomerDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            accountManagerDetailAssociatedCustomerDataGridView.Location = new Point(15, 18);
            accountManagerDetailAssociatedCustomerDataGridView.Name = "accountManagerDetailAssociatedCustomerDataGridView";
            accountManagerDetailAssociatedCustomerDataGridView.ReadOnly = true;
            accountManagerDetailAssociatedCustomerDataGridView.RowHeadersWidth = 62;
            accountManagerDetailAssociatedCustomerDataGridView.Size = new Size(1722, 1005);
            accountManagerDetailAssociatedCustomerDataGridView.TabIndex = 0;
            // 
            // AccountManagerDetail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1579, 679);
            Controls.Add(accountManagerDetailTabControl);
            Controls.Add(accountManagerDetailTitleLabel);
            Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "AccountManagerDetail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - Account Manager Detail";
            accountManagerDetailTabControl.ResumeLayout(false);
            accountManagerInformation.ResumeLayout(false);
            accountManagerInformation.PerformLayout();
            associatedCustomers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)accountManagerDetailAssociatedCustomerDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label accountManagerDetailTitleLabel;
        private TabControl accountManagerDetailTabControl;
        private TabPage accountManagerInformation;
        private TabPage associatedCustomers;
        private DataGridView accountManagerDetailAssociatedCustomerDataGridView;
        private CheckBox accountManagerDetailActiveStatusCheckbox;
        private Label accountManagerDetailTelephoneNumberLabel;
        private Label accountManagerDetailEmailAddressLabel;
        private Label accountManagerDetailLastNameLabel;
        private Label accountManagerDetailFirstNameLabel;
        private TextBox accountManagerDetailLastNameTextbox;
        private TextBox accountManagerDetailEmailAddressTextbox;
        private TextBox accountManagerDetailTelephoneNumberTextbox;
        private TextBox accountManagerDetailFirstNameTextbox;
        private Button accountManagerDetailUpdateAccountManagerButton;
        private Label accountManagerDetailAccountManagerIdLabel;
        private TextBox accountManagerDetailAccountManagerIdTextbox;
        private Button accountManagerDetailToggleEditModeButton;
        private Label accountManagerDetailLastUpdatedTimestampLabel;
        private Label accountManagerDetailCreatedTimestampLabel;
        private Label accountManagerDetailLastUpdatedByLabel;
        private Label accountManagerDetailCreatedByLabel;
        private TextBox accountManagerDetailLastUpdatedByTextbox;
        private TextBox accountManagerDetailCreatedTimestampTextbox;
        private TextBox accountManagerDetailLastUpdatedTimestampTextbox;
        private TextBox accountManagerDetailCreatedByTextbox;
    }
}