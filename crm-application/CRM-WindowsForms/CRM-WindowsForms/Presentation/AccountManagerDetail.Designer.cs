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
            accountManagerDetailAccountManagerIdLabel = new Label();
            accountManagerDetailAccountManagerIdTextbox = new TextBox();
            accountManagerDetailRemoveAccountManagerButton = new Button();
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
            accountManagerDetailTitleLabel.Location = new Point(36, 36);
            accountManagerDetailTitleLabel.Margin = new Padding(4, 0, 4, 0);
            accountManagerDetailTitleLabel.Name = "accountManagerDetailTitleLabel";
            accountManagerDetailTitleLabel.Size = new Size(427, 48);
            accountManagerDetailTitleLabel.TabIndex = 6;
            accountManagerDetailTitleLabel.Text = "Account Manager Detail";
            // 
            // accountManagerDetailTabControl
            // 
            accountManagerDetailTabControl.Appearance = TabAppearance.FlatButtons;
            accountManagerDetailTabControl.Controls.Add(accountManagerInformation);
            accountManagerDetailTabControl.Controls.Add(associatedCustomers);
            accountManagerDetailTabControl.Location = new Point(36, 104);
            accountManagerDetailTabControl.Multiline = true;
            accountManagerDetailTabControl.Name = "accountManagerDetailTabControl";
            accountManagerDetailTabControl.SelectedIndex = 0;
            accountManagerDetailTabControl.Size = new Size(1769, 1096);
            accountManagerDetailTabControl.TabIndex = 7;
            // 
            // accountManagerInformation
            // 
            accountManagerInformation.BackColor = Color.Khaki;
            accountManagerInformation.Controls.Add(accountManagerDetailAccountManagerIdLabel);
            accountManagerInformation.Controls.Add(accountManagerDetailAccountManagerIdTextbox);
            accountManagerInformation.Controls.Add(accountManagerDetailRemoveAccountManagerButton);
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
            accountManagerInformation.Location = new Point(4, 42);
            accountManagerInformation.Name = "accountManagerInformation";
            accountManagerInformation.Padding = new Padding(3);
            accountManagerInformation.Size = new Size(1761, 1050);
            accountManagerInformation.TabIndex = 0;
            accountManagerInformation.Text = "Account Manager Information";
            // 
            // accountManagerDetailAccountManagerIdLabel
            // 
            accountManagerDetailAccountManagerIdLabel.AutoSize = true;
            accountManagerDetailAccountManagerIdLabel.Font = new Font("Segoe UI", 11F);
            accountManagerDetailAccountManagerIdLabel.Location = new Point(32, 295);
            accountManagerDetailAccountManagerIdLabel.Margin = new Padding(4, 0, 4, 0);
            accountManagerDetailAccountManagerIdLabel.Name = "accountManagerDetailAccountManagerIdLabel";
            accountManagerDetailAccountManagerIdLabel.Size = new Size(209, 30);
            accountManagerDetailAccountManagerIdLabel.TabIndex = 23;
            accountManagerDetailAccountManagerIdLabel.Text = "Account Manager Id";
            // 
            // accountManagerDetailAccountManagerIdTextbox
            // 
            accountManagerDetailAccountManagerIdTextbox.Font = new Font("Segoe UI", 11F);
            accountManagerDetailAccountManagerIdTextbox.Location = new Point(249, 292);
            accountManagerDetailAccountManagerIdTextbox.Margin = new Padding(4);
            accountManagerDetailAccountManagerIdTextbox.Name = "accountManagerDetailAccountManagerIdTextbox";
            accountManagerDetailAccountManagerIdTextbox.ReadOnly = true;
            accountManagerDetailAccountManagerIdTextbox.Size = new Size(524, 37);
            accountManagerDetailAccountManagerIdTextbox.TabIndex = 5;
            // 
            // accountManagerDetailRemoveAccountManagerButton
            // 
            accountManagerDetailRemoveAccountManagerButton.BackColor = Color.DarkRed;
            accountManagerDetailRemoveAccountManagerButton.FlatStyle = FlatStyle.Flat;
            accountManagerDetailRemoveAccountManagerButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            accountManagerDetailRemoveAccountManagerButton.ForeColor = SystemColors.ControlLight;
            accountManagerDetailRemoveAccountManagerButton.Location = new Point(1424, 922);
            accountManagerDetailRemoveAccountManagerButton.Margin = new Padding(4);
            accountManagerDetailRemoveAccountManagerButton.Name = "accountManagerDetailRemoveAccountManagerButton";
            accountManagerDetailRemoveAccountManagerButton.Size = new Size(300, 92);
            accountManagerDetailRemoveAccountManagerButton.TabIndex = 21;
            accountManagerDetailRemoveAccountManagerButton.Text = "Remove Account Manager (Irreversible)";
            accountManagerDetailRemoveAccountManagerButton.UseVisualStyleBackColor = false;
            // 
            // accountManagerDetailUpdateAccountManagerButton
            // 
            accountManagerDetailUpdateAccountManagerButton.FlatStyle = FlatStyle.Flat;
            accountManagerDetailUpdateAccountManagerButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            accountManagerDetailUpdateAccountManagerButton.Location = new Point(366, 395);
            accountManagerDetailUpdateAccountManagerButton.Margin = new Padding(4);
            accountManagerDetailUpdateAccountManagerButton.Name = "accountManagerDetailUpdateAccountManagerButton";
            accountManagerDetailUpdateAccountManagerButton.Size = new Size(258, 92);
            accountManagerDetailUpdateAccountManagerButton.TabIndex = 20;
            accountManagerDetailUpdateAccountManagerButton.Text = "Update Account Manager";
            accountManagerDetailUpdateAccountManagerButton.UseVisualStyleBackColor = true;
            accountManagerDetailUpdateAccountManagerButton.Click += accountManagerDetailUpdateAccountManagerButton_Click;
            // 
            // accountManagerDetailActiveStatusCheckbox
            // 
            accountManagerDetailActiveStatusCheckbox.AutoSize = true;
            accountManagerDetailActiveStatusCheckbox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            accountManagerDetailActiveStatusCheckbox.Location = new Point(981, 295);
            accountManagerDetailActiveStatusCheckbox.Margin = new Padding(4);
            accountManagerDetailActiveStatusCheckbox.Name = "accountManagerDetailActiveStatusCheckbox";
            accountManagerDetailActiveStatusCheckbox.Size = new Size(98, 34);
            accountManagerDetailActiveStatusCheckbox.TabIndex = 19;
            accountManagerDetailActiveStatusCheckbox.Text = "Active";
            accountManagerDetailActiveStatusCheckbox.UseVisualStyleBackColor = true;
            // 
            // accountManagerDetailTelephoneNumberLabel
            // 
            accountManagerDetailTelephoneNumberLabel.AutoSize = true;
            accountManagerDetailTelephoneNumberLabel.Font = new Font("Segoe UI", 11F);
            accountManagerDetailTelephoneNumberLabel.Location = new Point(666, 184);
            accountManagerDetailTelephoneNumberLabel.Margin = new Padding(4, 0, 4, 0);
            accountManagerDetailTelephoneNumberLabel.Name = "accountManagerDetailTelephoneNumberLabel";
            accountManagerDetailTelephoneNumberLabel.Size = new Size(200, 30);
            accountManagerDetailTelephoneNumberLabel.TabIndex = 18;
            accountManagerDetailTelephoneNumberLabel.Text = "Telephone Number";
            // 
            // accountManagerDetailEmailAddressLabel
            // 
            accountManagerDetailEmailAddressLabel.AutoSize = true;
            accountManagerDetailEmailAddressLabel.Font = new Font("Segoe UI", 11F);
            accountManagerDetailEmailAddressLabel.Location = new Point(93, 184);
            accountManagerDetailEmailAddressLabel.Margin = new Padding(4, 0, 4, 0);
            accountManagerDetailEmailAddressLabel.Name = "accountManagerDetailEmailAddressLabel";
            accountManagerDetailEmailAddressLabel.Size = new Size(148, 30);
            accountManagerDetailEmailAddressLabel.TabIndex = 17;
            accountManagerDetailEmailAddressLabel.Text = "Email Address";
            // 
            // accountManagerDetailLastNameLabel
            // 
            accountManagerDetailLastNameLabel.AutoSize = true;
            accountManagerDetailLastNameLabel.Font = new Font("Segoe UI", 11F);
            accountManagerDetailLastNameLabel.Location = new Point(752, 73);
            accountManagerDetailLastNameLabel.Margin = new Padding(4, 0, 4, 0);
            accountManagerDetailLastNameLabel.Name = "accountManagerDetailLastNameLabel";
            accountManagerDetailLastNameLabel.Size = new Size(114, 30);
            accountManagerDetailLastNameLabel.TabIndex = 16;
            accountManagerDetailLastNameLabel.Text = "Last Name";
            // 
            // accountManagerDetailFirstNameLabel
            // 
            accountManagerDetailFirstNameLabel.AutoSize = true;
            accountManagerDetailFirstNameLabel.Font = new Font("Segoe UI", 11F);
            accountManagerDetailFirstNameLabel.Location = new Point(124, 69);
            accountManagerDetailFirstNameLabel.Margin = new Padding(4, 0, 4, 0);
            accountManagerDetailFirstNameLabel.Name = "accountManagerDetailFirstNameLabel";
            accountManagerDetailFirstNameLabel.Size = new Size(117, 30);
            accountManagerDetailFirstNameLabel.TabIndex = 15;
            accountManagerDetailFirstNameLabel.Text = "First Name";
            // 
            // accountManagerDetailLastNameTextbox
            // 
            accountManagerDetailLastNameTextbox.Font = new Font("Segoe UI", 11F);
            accountManagerDetailLastNameTextbox.Location = new Point(874, 66);
            accountManagerDetailLastNameTextbox.Margin = new Padding(4);
            accountManagerDetailLastNameTextbox.Name = "accountManagerDetailLastNameTextbox";
            accountManagerDetailLastNameTextbox.Size = new Size(340, 37);
            accountManagerDetailLastNameTextbox.TabIndex = 2;
            // 
            // accountManagerDetailEmailAddressTextbox
            // 
            accountManagerDetailEmailAddressTextbox.Font = new Font("Segoe UI", 11F);
            accountManagerDetailEmailAddressTextbox.Location = new Point(249, 181);
            accountManagerDetailEmailAddressTextbox.Margin = new Padding(4);
            accountManagerDetailEmailAddressTextbox.Name = "accountManagerDetailEmailAddressTextbox";
            accountManagerDetailEmailAddressTextbox.Size = new Size(340, 37);
            accountManagerDetailEmailAddressTextbox.TabIndex = 3;
            // 
            // accountManagerDetailTelephoneNumberTextbox
            // 
            accountManagerDetailTelephoneNumberTextbox.Font = new Font("Segoe UI", 11F);
            accountManagerDetailTelephoneNumberTextbox.Location = new Point(874, 181);
            accountManagerDetailTelephoneNumberTextbox.Margin = new Padding(4);
            accountManagerDetailTelephoneNumberTextbox.Name = "accountManagerDetailTelephoneNumberTextbox";
            accountManagerDetailTelephoneNumberTextbox.Size = new Size(340, 37);
            accountManagerDetailTelephoneNumberTextbox.TabIndex = 4;
            // 
            // accountManagerDetailFirstNameTextbox
            // 
            accountManagerDetailFirstNameTextbox.Font = new Font("Segoe UI", 11F);
            accountManagerDetailFirstNameTextbox.Location = new Point(249, 66);
            accountManagerDetailFirstNameTextbox.Margin = new Padding(4);
            accountManagerDetailFirstNameTextbox.Name = "accountManagerDetailFirstNameTextbox";
            accountManagerDetailFirstNameTextbox.Size = new Size(340, 37);
            accountManagerDetailFirstNameTextbox.TabIndex = 0;
            // 
            // associatedCustomers
            // 
            associatedCustomers.BackColor = Color.Khaki;
            associatedCustomers.Controls.Add(accountManagerDetailAssociatedCustomerDataGridView);
            associatedCustomers.Location = new Point(4, 42);
            associatedCustomers.Name = "associatedCustomers";
            associatedCustomers.Padding = new Padding(3);
            associatedCustomers.Size = new Size(1761, 1050);
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
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Khaki;
            ClientSize = new Size(1851, 1258);
            Controls.Add(accountManagerDetailTabControl);
            Controls.Add(accountManagerDetailTitleLabel);
            Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
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
        private Button accountManagerDetailRemoveAccountManagerButton;
        private Button accountManagerDetailUpdateAccountManagerButton;
        private Label accountManagerDetailAccountManagerIdLabel;
        private TextBox accountManagerDetailAccountManagerIdTextbox;
    }
}