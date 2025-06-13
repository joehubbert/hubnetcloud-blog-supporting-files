namespace CRM_WindowsForms.Presentation
{
    partial class SupplierDetail
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
            supplierDetailUpdateSupplierButton = new Button();
            supplierDetailOverviewActiveStatusCheckbox = new CheckBox();
            supplierDetailToggleEditModeButton = new Button();
            supplierDetailOverviewSupplierIdTextbox = new TextBox();
            supplierDetailOverviewCreatedTimestampTextbox = new TextBox();
            supplierDetailOverviewLastUpdatedTimestampTextbox = new TextBox();
            supplierDetailOverviewCreatedByTextbox = new TextBox();
            supplierDetailOverviewLastUpdatedByTextbox = new TextBox();
            supplierDetailOverviewLastUpdatedTimestampLabel = new Label();
            supplierDetailOverviewLastUpdatedByLabel = new Label();
            supplierDetailOverviewCreatedTimestampLabel = new Label();
            supplierDetailOverviewCreatedByLabel = new Label();
            supplierDetailSupplierIdLabel = new Label();
            supplierDetailTitleLabel = new Label();
            supplierDetailTabControl = new TabControl();
            supplierDetailTabControlOverviewPage = new TabPage();
            supplierDetailOverviewAddressLine2Label = new Label();
            supplierDetailOverviewAddressLine3Label = new Label();
            supplierDetailOverviewAddressLine4Label = new Label();
            supplierDetailOverviewAddressLine5Label = new Label();
            supplierDetailOverviewAddressLine1Label = new Label();
            supplierDetailOverviewAddressLine4Textbox = new TextBox();
            supplierDetailOverviewAddressLine5Textbox = new TextBox();
            supplierDetailOverviewAddressLine3Textbox = new TextBox();
            supplierDetailOverviewAddressLine2Textbox = new TextBox();
            supplierDetailOverviewAddressLine1Textbox = new TextBox();
            supplierDetailOverviewEmailAddressLabel = new Label();
            supplierDetailOverviewTelephoneNumberLabel = new Label();
            supplierDetailOverviewEmailAddressTextbox = new TextBox();
            supplierDetailOverviewTelephoneNumberTextbox = new TextBox();
            supplierDetailOverviewSupplierNameLabel = new Label();
            supplierDetailOverviewSupplierNameTextbox = new TextBox();
            supplierDetailTabControlFinancePage = new TabPage();
            supplierDetailFinanceVATNumberTextboxLabel = new Label();
            supplierDetailFinanceVATNumberTextbox = new TextBox();
            supplierDetailFinanceVATRegisteredCheckbox = new CheckBox();
            supplierDetailFinancePaymentDaysTextboxLabel = new Label();
            supplierDetailFinancePaymentCurrencyComboBoxLabel = new Label();
            supplierDetailFinancePaymentDaysTextbox = new TextBox();
            supplierDetailFinancePaymentCurrencyComboBox = new ComboBox();
            supplierDetailTabControlSupplierNotesPage = new TabPage();
            supplierDetailSupplierNotesRefreshDataButton = new Button();
            supplierDetailSupplierNotesCreateNewSupplierNoteButton = new Button();
            supplierDetailSupplierNotesExistingSupplierNotesDataGridView = new DataGridView();
            supplierDetailTabControl.SuspendLayout();
            supplierDetailTabControlOverviewPage.SuspendLayout();
            supplierDetailTabControlFinancePage.SuspendLayout();
            supplierDetailTabControlSupplierNotesPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)supplierDetailSupplierNotesExistingSupplierNotesDataGridView).BeginInit();
            SuspendLayout();
            // 
            // supplierDetailUpdateSupplierButton
            // 
            supplierDetailUpdateSupplierButton.Enabled = false;
            supplierDetailUpdateSupplierButton.FlatStyle = FlatStyle.Flat;
            supplierDetailUpdateSupplierButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            supplierDetailUpdateSupplierButton.Location = new Point(542, 672);
            supplierDetailUpdateSupplierButton.Margin = new Padding(4);
            supplierDetailUpdateSupplierButton.Name = "supplierDetailUpdateSupplierButton";
            supplierDetailUpdateSupplierButton.Size = new Size(185, 70);
            supplierDetailUpdateSupplierButton.TabIndex = 23;
            supplierDetailUpdateSupplierButton.Text = "Update Supplier";
            supplierDetailUpdateSupplierButton.UseVisualStyleBackColor = true;
            supplierDetailUpdateSupplierButton.Click += supplierDetailUpdateSupplierButton_Click;
            // 
            // supplierDetailOverviewActiveStatusCheckbox
            // 
            supplierDetailOverviewActiveStatusCheckbox.AutoSize = true;
            supplierDetailOverviewActiveStatusCheckbox.Enabled = false;
            supplierDetailOverviewActiveStatusCheckbox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            supplierDetailOverviewActiveStatusCheckbox.Location = new Point(171, 395);
            supplierDetailOverviewActiveStatusCheckbox.Margin = new Padding(4);
            supplierDetailOverviewActiveStatusCheckbox.Name = "supplierDetailOverviewActiveStatusCheckbox";
            supplierDetailOverviewActiveStatusCheckbox.Size = new Size(128, 24);
            supplierDetailOverviewActiveStatusCheckbox.TabIndex = 5;
            supplierDetailOverviewActiveStatusCheckbox.Text = "Active Supplier";
            supplierDetailOverviewActiveStatusCheckbox.UseVisualStyleBackColor = true;
            // 
            // supplierDetailToggleEditModeButton
            // 
            supplierDetailToggleEditModeButton.FlatStyle = FlatStyle.Flat;
            supplierDetailToggleEditModeButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            supplierDetailToggleEditModeButton.Location = new Point(1165, 13);
            supplierDetailToggleEditModeButton.Margin = new Padding(4);
            supplierDetailToggleEditModeButton.Name = "supplierDetailToggleEditModeButton";
            supplierDetailToggleEditModeButton.Size = new Size(108, 92);
            supplierDetailToggleEditModeButton.TabIndex = 22;
            supplierDetailToggleEditModeButton.Text = "Toggle Edit Mode";
            supplierDetailToggleEditModeButton.UseVisualStyleBackColor = true;
            supplierDetailToggleEditModeButton.Click += supplierDetailToggleEditModeButton_Click;
            // 
            // supplierDetailOverviewSupplierIdTextbox
            // 
            supplierDetailOverviewSupplierIdTextbox.Location = new Point(171, 28);
            supplierDetailOverviewSupplierIdTextbox.MaxLength = 36;
            supplierDetailOverviewSupplierIdTextbox.Name = "supplierDetailOverviewSupplierIdTextbox";
            supplierDetailOverviewSupplierIdTextbox.ReadOnly = true;
            supplierDetailOverviewSupplierIdTextbox.Size = new Size(370, 27);
            supplierDetailOverviewSupplierIdTextbox.TabIndex = 1;
            // 
            // supplierDetailOverviewCreatedTimestampTextbox
            // 
            supplierDetailOverviewCreatedTimestampTextbox.Location = new Point(818, 305);
            supplierDetailOverviewCreatedTimestampTextbox.MaxLength = 11;
            supplierDetailOverviewCreatedTimestampTextbox.Name = "supplierDetailOverviewCreatedTimestampTextbox";
            supplierDetailOverviewCreatedTimestampTextbox.ReadOnly = true;
            supplierDetailOverviewCreatedTimestampTextbox.Size = new Size(370, 27);
            supplierDetailOverviewCreatedTimestampTextbox.TabIndex = 12;
            // 
            // supplierDetailOverviewLastUpdatedTimestampTextbox
            // 
            supplierDetailOverviewLastUpdatedTimestampTextbox.Location = new Point(818, 396);
            supplierDetailOverviewLastUpdatedTimestampTextbox.MaxLength = 13;
            supplierDetailOverviewLastUpdatedTimestampTextbox.Name = "supplierDetailOverviewLastUpdatedTimestampTextbox";
            supplierDetailOverviewLastUpdatedTimestampTextbox.ReadOnly = true;
            supplierDetailOverviewLastUpdatedTimestampTextbox.Size = new Size(370, 27);
            supplierDetailOverviewLastUpdatedTimestampTextbox.TabIndex = 14;
            // 
            // supplierDetailOverviewCreatedByTextbox
            // 
            supplierDetailOverviewCreatedByTextbox.Location = new Point(818, 260);
            supplierDetailOverviewCreatedByTextbox.MaxLength = 10;
            supplierDetailOverviewCreatedByTextbox.Name = "supplierDetailOverviewCreatedByTextbox";
            supplierDetailOverviewCreatedByTextbox.ReadOnly = true;
            supplierDetailOverviewCreatedByTextbox.Size = new Size(370, 27);
            supplierDetailOverviewCreatedByTextbox.TabIndex = 11;
            // 
            // supplierDetailOverviewLastUpdatedByTextbox
            // 
            supplierDetailOverviewLastUpdatedByTextbox.Location = new Point(818, 350);
            supplierDetailOverviewLastUpdatedByTextbox.MaxLength = 12;
            supplierDetailOverviewLastUpdatedByTextbox.Name = "supplierDetailOverviewLastUpdatedByTextbox";
            supplierDetailOverviewLastUpdatedByTextbox.ReadOnly = true;
            supplierDetailOverviewLastUpdatedByTextbox.Size = new Size(370, 27);
            supplierDetailOverviewLastUpdatedByTextbox.TabIndex = 13;
            // 
            // supplierDetailOverviewLastUpdatedTimestampLabel
            // 
            supplierDetailOverviewLastUpdatedTimestampLabel.AutoSize = true;
            supplierDetailOverviewLastUpdatedTimestampLabel.Location = new Point(627, 399);
            supplierDetailOverviewLastUpdatedTimestampLabel.Name = "supplierDetailOverviewLastUpdatedTimestampLabel";
            supplierDetailOverviewLastUpdatedTimestampLabel.Size = new Size(175, 20);
            supplierDetailOverviewLastUpdatedTimestampLabel.TabIndex = 54;
            supplierDetailOverviewLastUpdatedTimestampLabel.Text = "Last Updated Timestamp";
            // 
            // supplierDetailOverviewLastUpdatedByLabel
            // 
            supplierDetailOverviewLastUpdatedByLabel.AutoSize = true;
            supplierDetailOverviewLastUpdatedByLabel.Location = new Point(685, 353);
            supplierDetailOverviewLastUpdatedByLabel.Name = "supplierDetailOverviewLastUpdatedByLabel";
            supplierDetailOverviewLastUpdatedByLabel.Size = new Size(117, 20);
            supplierDetailOverviewLastUpdatedByLabel.TabIndex = 53;
            supplierDetailOverviewLastUpdatedByLabel.Text = "Last Updated By";
            // 
            // supplierDetailOverviewCreatedTimestampLabel
            // 
            supplierDetailOverviewCreatedTimestampLabel.AutoSize = true;
            supplierDetailOverviewCreatedTimestampLabel.Location = new Point(663, 308);
            supplierDetailOverviewCreatedTimestampLabel.Name = "supplierDetailOverviewCreatedTimestampLabel";
            supplierDetailOverviewCreatedTimestampLabel.Size = new Size(139, 20);
            supplierDetailOverviewCreatedTimestampLabel.TabIndex = 52;
            supplierDetailOverviewCreatedTimestampLabel.Text = "Created Timestamp";
            // 
            // supplierDetailOverviewCreatedByLabel
            // 
            supplierDetailOverviewCreatedByLabel.AutoSize = true;
            supplierDetailOverviewCreatedByLabel.Location = new Point(721, 263);
            supplierDetailOverviewCreatedByLabel.Name = "supplierDetailOverviewCreatedByLabel";
            supplierDetailOverviewCreatedByLabel.Size = new Size(81, 20);
            supplierDetailOverviewCreatedByLabel.TabIndex = 49;
            supplierDetailOverviewCreatedByLabel.Text = "Created By";
            // 
            // supplierDetailSupplierIdLabel
            // 
            supplierDetailSupplierIdLabel.AutoSize = true;
            supplierDetailSupplierIdLabel.Location = new Point(73, 30);
            supplierDetailSupplierIdLabel.Name = "supplierDetailSupplierIdLabel";
            supplierDetailSupplierIdLabel.Size = new Size(81, 20);
            supplierDetailSupplierIdLabel.TabIndex = 43;
            supplierDetailSupplierIdLabel.Text = "Supplier Id";
            // 
            // supplierDetailTitleLabel
            // 
            supplierDetailTitleLabel.AutoSize = true;
            supplierDetailTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            supplierDetailTitleLabel.Location = new Point(13, 9);
            supplierDetailTitleLabel.Margin = new Padding(4, 0, 4, 0);
            supplierDetailTitleLabel.Name = "supplierDetailTitleLabel";
            supplierDetailTitleLabel.Size = new Size(183, 32);
            supplierDetailTitleLabel.TabIndex = 42;
            supplierDetailTitleLabel.Text = "Supplier Detail";
            // 
            // supplierDetailTabControl
            // 
            supplierDetailTabControl.Appearance = TabAppearance.FlatButtons;
            supplierDetailTabControl.Controls.Add(supplierDetailTabControlOverviewPage);
            supplierDetailTabControl.Controls.Add(supplierDetailTabControlFinancePage);
            supplierDetailTabControl.Controls.Add(supplierDetailTabControlSupplierNotesPage);
            supplierDetailTabControl.Location = new Point(13, 121);
            supplierDetailTabControl.Name = "supplierDetailTabControl";
            supplierDetailTabControl.SelectedIndex = 0;
            supplierDetailTabControl.Size = new Size(1264, 521);
            supplierDetailTabControl.TabIndex = 0;
            // 
            // supplierDetailTabControlOverviewPage
            // 
            supplierDetailTabControlOverviewPage.BackColor = Color.MediumAquamarine;
            supplierDetailTabControlOverviewPage.Controls.Add(supplierDetailOverviewAddressLine2Label);
            supplierDetailTabControlOverviewPage.Controls.Add(supplierDetailOverviewAddressLine3Label);
            supplierDetailTabControlOverviewPage.Controls.Add(supplierDetailOverviewActiveStatusCheckbox);
            supplierDetailTabControlOverviewPage.Controls.Add(supplierDetailOverviewAddressLine4Label);
            supplierDetailTabControlOverviewPage.Controls.Add(supplierDetailOverviewAddressLine5Label);
            supplierDetailTabControlOverviewPage.Controls.Add(supplierDetailOverviewCreatedTimestampTextbox);
            supplierDetailTabControlOverviewPage.Controls.Add(supplierDetailOverviewSupplierIdTextbox);
            supplierDetailTabControlOverviewPage.Controls.Add(supplierDetailOverviewLastUpdatedTimestampTextbox);
            supplierDetailTabControlOverviewPage.Controls.Add(supplierDetailOverviewAddressLine1Label);
            supplierDetailTabControlOverviewPage.Controls.Add(supplierDetailOverviewCreatedByTextbox);
            supplierDetailTabControlOverviewPage.Controls.Add(supplierDetailOverviewLastUpdatedByTextbox);
            supplierDetailTabControlOverviewPage.Controls.Add(supplierDetailOverviewAddressLine4Textbox);
            supplierDetailTabControlOverviewPage.Controls.Add(supplierDetailOverviewLastUpdatedTimestampLabel);
            supplierDetailTabControlOverviewPage.Controls.Add(supplierDetailOverviewAddressLine5Textbox);
            supplierDetailTabControlOverviewPage.Controls.Add(supplierDetailOverviewLastUpdatedByLabel);
            supplierDetailTabControlOverviewPage.Controls.Add(supplierDetailOverviewAddressLine3Textbox);
            supplierDetailTabControlOverviewPage.Controls.Add(supplierDetailOverviewCreatedTimestampLabel);
            supplierDetailTabControlOverviewPage.Controls.Add(supplierDetailOverviewAddressLine2Textbox);
            supplierDetailTabControlOverviewPage.Controls.Add(supplierDetailOverviewCreatedByLabel);
            supplierDetailTabControlOverviewPage.Controls.Add(supplierDetailOverviewAddressLine1Textbox);
            supplierDetailTabControlOverviewPage.Controls.Add(supplierDetailOverviewEmailAddressLabel);
            supplierDetailTabControlOverviewPage.Controls.Add(supplierDetailOverviewTelephoneNumberLabel);
            supplierDetailTabControlOverviewPage.Controls.Add(supplierDetailSupplierIdLabel);
            supplierDetailTabControlOverviewPage.Controls.Add(supplierDetailOverviewEmailAddressTextbox);
            supplierDetailTabControlOverviewPage.Controls.Add(supplierDetailOverviewTelephoneNumberTextbox);
            supplierDetailTabControlOverviewPage.Controls.Add(supplierDetailOverviewSupplierNameLabel);
            supplierDetailTabControlOverviewPage.Controls.Add(supplierDetailOverviewSupplierNameTextbox);
            supplierDetailTabControlOverviewPage.Location = new Point(4, 32);
            supplierDetailTabControlOverviewPage.Name = "supplierDetailTabControlOverviewPage";
            supplierDetailTabControlOverviewPage.Padding = new Padding(3);
            supplierDetailTabControlOverviewPage.Size = new Size(1256, 485);
            supplierDetailTabControlOverviewPage.TabIndex = 0;
            supplierDetailTabControlOverviewPage.Text = "Overview";
            // 
            // supplierDetailOverviewAddressLine2Label
            // 
            supplierDetailOverviewAddressLine2Label.AutoSize = true;
            supplierDetailOverviewAddressLine2Label.Location = new Point(697, 78);
            supplierDetailOverviewAddressLine2Label.Name = "supplierDetailOverviewAddressLine2Label";
            supplierDetailOverviewAddressLine2Label.Size = new Size(105, 20);
            supplierDetailOverviewAddressLine2Label.TabIndex = 57;
            supplierDetailOverviewAddressLine2Label.Text = "Address Line 2";
            // 
            // supplierDetailOverviewAddressLine3Label
            // 
            supplierDetailOverviewAddressLine3Label.AutoSize = true;
            supplierDetailOverviewAddressLine3Label.Location = new Point(697, 123);
            supplierDetailOverviewAddressLine3Label.Name = "supplierDetailOverviewAddressLine3Label";
            supplierDetailOverviewAddressLine3Label.Size = new Size(105, 20);
            supplierDetailOverviewAddressLine3Label.TabIndex = 56;
            supplierDetailOverviewAddressLine3Label.Text = "Address Line 3";
            // 
            // supplierDetailOverviewAddressLine4Label
            // 
            supplierDetailOverviewAddressLine4Label.AutoSize = true;
            supplierDetailOverviewAddressLine4Label.Location = new Point(697, 168);
            supplierDetailOverviewAddressLine4Label.Name = "supplierDetailOverviewAddressLine4Label";
            supplierDetailOverviewAddressLine4Label.Size = new Size(105, 20);
            supplierDetailOverviewAddressLine4Label.TabIndex = 55;
            supplierDetailOverviewAddressLine4Label.Text = "Address Line 4";
            // 
            // supplierDetailOverviewAddressLine5Label
            // 
            supplierDetailOverviewAddressLine5Label.AutoSize = true;
            supplierDetailOverviewAddressLine5Label.Location = new Point(697, 213);
            supplierDetailOverviewAddressLine5Label.Name = "supplierDetailOverviewAddressLine5Label";
            supplierDetailOverviewAddressLine5Label.Size = new Size(105, 20);
            supplierDetailOverviewAddressLine5Label.TabIndex = 54;
            supplierDetailOverviewAddressLine5Label.Text = "Address Line 5";
            // 
            // supplierDetailOverviewAddressLine1Label
            // 
            supplierDetailOverviewAddressLine1Label.AutoSize = true;
            supplierDetailOverviewAddressLine1Label.Location = new Point(697, 33);
            supplierDetailOverviewAddressLine1Label.Name = "supplierDetailOverviewAddressLine1Label";
            supplierDetailOverviewAddressLine1Label.Size = new Size(105, 20);
            supplierDetailOverviewAddressLine1Label.TabIndex = 53;
            supplierDetailOverviewAddressLine1Label.Text = "Address Line 1";
            // 
            // supplierDetailOverviewAddressLine4Textbox
            // 
            supplierDetailOverviewAddressLine4Textbox.Location = new Point(818, 165);
            supplierDetailOverviewAddressLine4Textbox.MaxLength = 50;
            supplierDetailOverviewAddressLine4Textbox.Name = "supplierDetailOverviewAddressLine4Textbox";
            supplierDetailOverviewAddressLine4Textbox.ReadOnly = true;
            supplierDetailOverviewAddressLine4Textbox.Size = new Size(370, 27);
            supplierDetailOverviewAddressLine4Textbox.TabIndex = 9;
            // 
            // supplierDetailOverviewAddressLine5Textbox
            // 
            supplierDetailOverviewAddressLine5Textbox.Location = new Point(818, 210);
            supplierDetailOverviewAddressLine5Textbox.MaxLength = 50;
            supplierDetailOverviewAddressLine5Textbox.Name = "supplierDetailOverviewAddressLine5Textbox";
            supplierDetailOverviewAddressLine5Textbox.ReadOnly = true;
            supplierDetailOverviewAddressLine5Textbox.Size = new Size(370, 27);
            supplierDetailOverviewAddressLine5Textbox.TabIndex = 10;
            // 
            // supplierDetailOverviewAddressLine3Textbox
            // 
            supplierDetailOverviewAddressLine3Textbox.Location = new Point(818, 120);
            supplierDetailOverviewAddressLine3Textbox.MaxLength = 50;
            supplierDetailOverviewAddressLine3Textbox.Name = "supplierDetailOverviewAddressLine3Textbox";
            supplierDetailOverviewAddressLine3Textbox.ReadOnly = true;
            supplierDetailOverviewAddressLine3Textbox.Size = new Size(370, 27);
            supplierDetailOverviewAddressLine3Textbox.TabIndex = 8;
            // 
            // supplierDetailOverviewAddressLine2Textbox
            // 
            supplierDetailOverviewAddressLine2Textbox.Location = new Point(818, 75);
            supplierDetailOverviewAddressLine2Textbox.MaxLength = 50;
            supplierDetailOverviewAddressLine2Textbox.Name = "supplierDetailOverviewAddressLine2Textbox";
            supplierDetailOverviewAddressLine2Textbox.ReadOnly = true;
            supplierDetailOverviewAddressLine2Textbox.Size = new Size(370, 27);
            supplierDetailOverviewAddressLine2Textbox.TabIndex = 7;
            // 
            // supplierDetailOverviewAddressLine1Textbox
            // 
            supplierDetailOverviewAddressLine1Textbox.Location = new Point(818, 30);
            supplierDetailOverviewAddressLine1Textbox.MaxLength = 50;
            supplierDetailOverviewAddressLine1Textbox.Name = "supplierDetailOverviewAddressLine1Textbox";
            supplierDetailOverviewAddressLine1Textbox.ReadOnly = true;
            supplierDetailOverviewAddressLine1Textbox.Size = new Size(370, 27);
            supplierDetailOverviewAddressLine1Textbox.TabIndex = 6;
            // 
            // supplierDetailOverviewEmailAddressLabel
            // 
            supplierDetailOverviewEmailAddressLabel.AutoSize = true;
            supplierDetailOverviewEmailAddressLabel.Location = new Point(51, 160);
            supplierDetailOverviewEmailAddressLabel.Name = "supplierDetailOverviewEmailAddressLabel";
            supplierDetailOverviewEmailAddressLabel.Size = new Size(109, 20);
            supplierDetailOverviewEmailAddressLabel.TabIndex = 52;
            supplierDetailOverviewEmailAddressLabel.Text = "Email Address*";
            // 
            // supplierDetailOverviewTelephoneNumberLabel
            // 
            supplierDetailOverviewTelephoneNumberLabel.AutoSize = true;
            supplierDetailOverviewTelephoneNumberLabel.Location = new Point(18, 120);
            supplierDetailOverviewTelephoneNumberLabel.Name = "supplierDetailOverviewTelephoneNumberLabel";
            supplierDetailOverviewTelephoneNumberLabel.Size = new Size(142, 20);
            supplierDetailOverviewTelephoneNumberLabel.TabIndex = 51;
            supplierDetailOverviewTelephoneNumberLabel.Text = "Telephone Number*";
            // 
            // supplierDetailOverviewEmailAddressTextbox
            // 
            supplierDetailOverviewEmailAddressTextbox.Location = new Point(171, 157);
            supplierDetailOverviewEmailAddressTextbox.MaxLength = 50;
            supplierDetailOverviewEmailAddressTextbox.Name = "supplierDetailOverviewEmailAddressTextbox";
            supplierDetailOverviewEmailAddressTextbox.ReadOnly = true;
            supplierDetailOverviewEmailAddressTextbox.Size = new Size(370, 27);
            supplierDetailOverviewEmailAddressTextbox.TabIndex = 4;
            // 
            // supplierDetailOverviewTelephoneNumberTextbox
            // 
            supplierDetailOverviewTelephoneNumberTextbox.Location = new Point(171, 114);
            supplierDetailOverviewTelephoneNumberTextbox.MaxLength = 50;
            supplierDetailOverviewTelephoneNumberTextbox.Name = "supplierDetailOverviewTelephoneNumberTextbox";
            supplierDetailOverviewTelephoneNumberTextbox.ReadOnly = true;
            supplierDetailOverviewTelephoneNumberTextbox.Size = new Size(370, 27);
            supplierDetailOverviewTelephoneNumberTextbox.TabIndex = 3;
            // 
            // supplierDetailOverviewSupplierNameLabel
            // 
            supplierDetailOverviewSupplierNameLabel.AutoSize = true;
            supplierDetailOverviewSupplierNameLabel.Location = new Point(46, 77);
            supplierDetailOverviewSupplierNameLabel.Name = "supplierDetailOverviewSupplierNameLabel";
            supplierDetailOverviewSupplierNameLabel.Size = new Size(114, 20);
            supplierDetailOverviewSupplierNameLabel.TabIndex = 28;
            supplierDetailOverviewSupplierNameLabel.Text = "Supplier Name*";
            // 
            // supplierDetailOverviewSupplierNameTextbox
            // 
            supplierDetailOverviewSupplierNameTextbox.Location = new Point(171, 71);
            supplierDetailOverviewSupplierNameTextbox.MaxLength = 50;
            supplierDetailOverviewSupplierNameTextbox.Name = "supplierDetailOverviewSupplierNameTextbox";
            supplierDetailOverviewSupplierNameTextbox.ReadOnly = true;
            supplierDetailOverviewSupplierNameTextbox.Size = new Size(370, 27);
            supplierDetailOverviewSupplierNameTextbox.TabIndex = 2;
            // 
            // supplierDetailTabControlFinancePage
            // 
            supplierDetailTabControlFinancePage.BackColor = Color.MediumAquamarine;
            supplierDetailTabControlFinancePage.Controls.Add(supplierDetailFinanceVATNumberTextboxLabel);
            supplierDetailTabControlFinancePage.Controls.Add(supplierDetailFinanceVATNumberTextbox);
            supplierDetailTabControlFinancePage.Controls.Add(supplierDetailFinanceVATRegisteredCheckbox);
            supplierDetailTabControlFinancePage.Controls.Add(supplierDetailFinancePaymentDaysTextboxLabel);
            supplierDetailTabControlFinancePage.Controls.Add(supplierDetailFinancePaymentCurrencyComboBoxLabel);
            supplierDetailTabControlFinancePage.Controls.Add(supplierDetailFinancePaymentDaysTextbox);
            supplierDetailTabControlFinancePage.Controls.Add(supplierDetailFinancePaymentCurrencyComboBox);
            supplierDetailTabControlFinancePage.Location = new Point(4, 32);
            supplierDetailTabControlFinancePage.Name = "supplierDetailTabControlFinancePage";
            supplierDetailTabControlFinancePage.Size = new Size(1256, 485);
            supplierDetailTabControlFinancePage.TabIndex = 3;
            supplierDetailTabControlFinancePage.Text = "Finance";
            // 
            // supplierDetailFinanceVATNumberTextboxLabel
            // 
            supplierDetailFinanceVATNumberTextboxLabel.AutoSize = true;
            supplierDetailFinanceVATNumberTextboxLabel.Location = new Point(74, 143);
            supplierDetailFinanceVATNumberTextboxLabel.Name = "supplierDetailFinanceVATNumberTextboxLabel";
            supplierDetailFinanceVATNumberTextboxLabel.Size = new Size(92, 20);
            supplierDetailFinanceVATNumberTextboxLabel.TabIndex = 23;
            supplierDetailFinanceVATNumberTextboxLabel.Text = "VAT Number";
            // 
            // supplierDetailFinanceVATNumberTextbox
            // 
            supplierDetailFinanceVATNumberTextbox.Location = new Point(181, 140);
            supplierDetailFinanceVATNumberTextbox.MaxLength = 50;
            supplierDetailFinanceVATNumberTextbox.Name = "supplierDetailFinanceVATNumberTextbox";
            supplierDetailFinanceVATNumberTextbox.ReadOnly = true;
            supplierDetailFinanceVATNumberTextbox.Size = new Size(208, 27);
            supplierDetailFinanceVATNumberTextbox.TabIndex = 18;
            // 
            // supplierDetailFinanceVATRegisteredCheckbox
            // 
            supplierDetailFinanceVATRegisteredCheckbox.AutoSize = true;
            supplierDetailFinanceVATRegisteredCheckbox.Enabled = false;
            supplierDetailFinanceVATRegisteredCheckbox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            supplierDetailFinanceVATRegisteredCheckbox.Location = new Point(38, 109);
            supplierDetailFinanceVATRegisteredCheckbox.Margin = new Padding(4);
            supplierDetailFinanceVATRegisteredCheckbox.Name = "supplierDetailFinanceVATRegisteredCheckbox";
            supplierDetailFinanceVATRegisteredCheckbox.Size = new Size(128, 24);
            supplierDetailFinanceVATRegisteredCheckbox.TabIndex = 17;
            supplierDetailFinanceVATRegisteredCheckbox.Text = "VAT Registered";
            supplierDetailFinanceVATRegisteredCheckbox.UseVisualStyleBackColor = true;
            // 
            // supplierDetailFinancePaymentDaysTextboxLabel
            // 
            supplierDetailFinancePaymentDaysTextboxLabel.AutoSize = true;
            supplierDetailFinancePaymentDaysTextboxLabel.Location = new Point(65, 69);
            supplierDetailFinancePaymentDaysTextboxLabel.Name = "supplierDetailFinancePaymentDaysTextboxLabel";
            supplierDetailFinancePaymentDaysTextboxLabel.Size = new Size(101, 20);
            supplierDetailFinancePaymentDaysTextboxLabel.TabIndex = 20;
            supplierDetailFinancePaymentDaysTextboxLabel.Text = "Payment Days";
            // 
            // supplierDetailFinancePaymentCurrencyComboBoxLabel
            // 
            supplierDetailFinancePaymentCurrencyComboBoxLabel.AutoSize = true;
            supplierDetailFinancePaymentCurrencyComboBoxLabel.Location = new Point(40, 31);
            supplierDetailFinancePaymentCurrencyComboBoxLabel.Name = "supplierDetailFinancePaymentCurrencyComboBoxLabel";
            supplierDetailFinancePaymentCurrencyComboBoxLabel.Size = new Size(126, 20);
            supplierDetailFinancePaymentCurrencyComboBoxLabel.TabIndex = 19;
            supplierDetailFinancePaymentCurrencyComboBoxLabel.Text = "Payment Currency";
            // 
            // supplierDetailFinancePaymentDaysTextbox
            // 
            supplierDetailFinancePaymentDaysTextbox.Location = new Point(181, 66);
            supplierDetailFinancePaymentDaysTextbox.MaxLength = 3;
            supplierDetailFinancePaymentDaysTextbox.Name = "supplierDetailFinancePaymentDaysTextbox";
            supplierDetailFinancePaymentDaysTextbox.ReadOnly = true;
            supplierDetailFinancePaymentDaysTextbox.Size = new Size(103, 27);
            supplierDetailFinancePaymentDaysTextbox.TabIndex = 16;
            // 
            // supplierDetailFinancePaymentCurrencyComboBox
            // 
            supplierDetailFinancePaymentCurrencyComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            supplierDetailFinancePaymentCurrencyComboBox.Enabled = false;
            supplierDetailFinancePaymentCurrencyComboBox.FormattingEnabled = true;
            supplierDetailFinancePaymentCurrencyComboBox.Location = new Point(181, 28);
            supplierDetailFinancePaymentCurrencyComboBox.Name = "supplierDetailFinancePaymentCurrencyComboBox";
            supplierDetailFinancePaymentCurrencyComboBox.Size = new Size(208, 28);
            supplierDetailFinancePaymentCurrencyComboBox.TabIndex = 15;
            // 
            // supplierDetailTabControlSupplierNotesPage
            // 
            supplierDetailTabControlSupplierNotesPage.BackColor = Color.MediumAquamarine;
            supplierDetailTabControlSupplierNotesPage.Controls.Add(supplierDetailSupplierNotesRefreshDataButton);
            supplierDetailTabControlSupplierNotesPage.Controls.Add(supplierDetailSupplierNotesCreateNewSupplierNoteButton);
            supplierDetailTabControlSupplierNotesPage.Controls.Add(supplierDetailSupplierNotesExistingSupplierNotesDataGridView);
            supplierDetailTabControlSupplierNotesPage.Location = new Point(4, 27);
            supplierDetailTabControlSupplierNotesPage.Name = "supplierDetailTabControlSupplierNotesPage";
            supplierDetailTabControlSupplierNotesPage.Size = new Size(1256, 490);
            supplierDetailTabControlSupplierNotesPage.TabIndex = 4;
            supplierDetailTabControlSupplierNotesPage.Text = "Supplier Notes";
            // 
            // supplierDetailSupplierNotesRefreshDataButton
            // 
            supplierDetailSupplierNotesRefreshDataButton.FlatStyle = FlatStyle.Flat;
            supplierDetailSupplierNotesRefreshDataButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            supplierDetailSupplierNotesRefreshDataButton.Location = new Point(1093, 95);
            supplierDetailSupplierNotesRefreshDataButton.Margin = new Padding(4);
            supplierDetailSupplierNotesRefreshDataButton.Name = "supplierDetailSupplierNotesRefreshDataButton";
            supplierDetailSupplierNotesRefreshDataButton.Size = new Size(151, 70);
            supplierDetailSupplierNotesRefreshDataButton.TabIndex = 21;
            supplierDetailSupplierNotesRefreshDataButton.Text = "Refresh Data";
            supplierDetailSupplierNotesRefreshDataButton.UseVisualStyleBackColor = true;
            supplierDetailSupplierNotesRefreshDataButton.Click += supplierDetailSupplierNotesRefreshDataButton_Click;
            // 
            // supplierDetailSupplierNotesCreateNewSupplierNoteButton
            // 
            supplierDetailSupplierNotesCreateNewSupplierNoteButton.FlatStyle = FlatStyle.Flat;
            supplierDetailSupplierNotesCreateNewSupplierNoteButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            supplierDetailSupplierNotesCreateNewSupplierNoteButton.Location = new Point(1093, 17);
            supplierDetailSupplierNotesCreateNewSupplierNoteButton.Margin = new Padding(4);
            supplierDetailSupplierNotesCreateNewSupplierNoteButton.Name = "supplierDetailSupplierNotesCreateNewSupplierNoteButton";
            supplierDetailSupplierNotesCreateNewSupplierNoteButton.Size = new Size(151, 70);
            supplierDetailSupplierNotesCreateNewSupplierNoteButton.TabIndex = 20;
            supplierDetailSupplierNotesCreateNewSupplierNoteButton.Text = "Create New Supplier Note";
            supplierDetailSupplierNotesCreateNewSupplierNoteButton.UseVisualStyleBackColor = true;
            supplierDetailSupplierNotesCreateNewSupplierNoteButton.Click += supplierDetailSupplierNotesCreateNewSupplierNoteButton_Click;
            // 
            // supplierDetailSupplierNotesExistingSupplierNotesDataGridView
            // 
            supplierDetailSupplierNotesExistingSupplierNotesDataGridView.AllowUserToAddRows = false;
            supplierDetailSupplierNotesExistingSupplierNotesDataGridView.AllowUserToDeleteRows = false;
            supplierDetailSupplierNotesExistingSupplierNotesDataGridView.BackgroundColor = Color.MediumAquamarine;
            supplierDetailSupplierNotesExistingSupplierNotesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            supplierDetailSupplierNotesExistingSupplierNotesDataGridView.Location = new Point(21, 17);
            supplierDetailSupplierNotesExistingSupplierNotesDataGridView.Name = "supplierDetailSupplierNotesExistingSupplierNotesDataGridView";
            supplierDetailSupplierNotesExistingSupplierNotesDataGridView.ReadOnly = true;
            supplierDetailSupplierNotesExistingSupplierNotesDataGridView.Size = new Size(1059, 453);
            supplierDetailSupplierNotesExistingSupplierNotesDataGridView.TabIndex = 19;
            // 
            // SupplierDetail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumAquamarine;
            ClientSize = new Size(1289, 764);
            Controls.Add(supplierDetailTabControl);
            Controls.Add(supplierDetailUpdateSupplierButton);
            Controls.Add(supplierDetailToggleEditModeButton);
            Controls.Add(supplierDetailTitleLabel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "SupplierDetail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - Supplier Detail";
            supplierDetailTabControl.ResumeLayout(false);
            supplierDetailTabControlOverviewPage.ResumeLayout(false);
            supplierDetailTabControlOverviewPage.PerformLayout();
            supplierDetailTabControlFinancePage.ResumeLayout(false);
            supplierDetailTabControlFinancePage.PerformLayout();
            supplierDetailTabControlSupplierNotesPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)supplierDetailSupplierNotesExistingSupplierNotesDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button supplierDetailUpdateSupplierButton;
        private CheckBox supplierDetailOverviewActiveStatusCheckbox;
        private Button supplierDetailToggleEditModeButton;
        private TextBox supplierDetailOverviewSupplierIdTextbox;
        private TextBox supplierDetailOverviewCreatedTimestampTextbox;
        private TextBox supplierDetailOverviewLastUpdatedTimestampTextbox;
        private TextBox supplierDetailOverviewCreatedByTextbox;
        private TextBox supplierDetailOverviewLastUpdatedByTextbox;
        private Label supplierDetailOverviewLastUpdatedTimestampLabel;
        private Label supplierDetailOverviewLastUpdatedByLabel;
        private Label supplierDetailOverviewCreatedTimestampLabel;
        private Label supplierDetailOverviewCreatedByLabel;
        private Label supplierDetailSupplierIdLabel;
        private Label supplierDetailTitleLabel;
        private TabControl supplierDetailTabControl;
        private TabPage supplierDetailTabControlOverviewPage;
        private Label supplierDetailOverviewAddressLine2Label;
        private Label supplierDetailOverviewAddressLine3Label;
        private Label supplierDetailOverviewAddressLine4Label;
        private Label supplierDetailOverviewAddressLine5Label;
        private Label supplierDetailOverviewAddressLine1Label;
        private TextBox supplierDetailOverviewAddressLine4Textbox;
        private TextBox supplierDetailOverviewAddressLine5Textbox;
        private TextBox supplierDetailOverviewAddressLine3Textbox;
        private TextBox supplierDetailOverviewAddressLine2Textbox;
        private TextBox supplierDetailOverviewAddressLine1Textbox;
        private Label supplierDetailOverviewEmailAddressLabel;
        private Label supplierDetailOverviewTelephoneNumberLabel;
        private TextBox supplierDetailOverviewEmailAddressTextbox;
        private TextBox supplierDetailOverviewTelephoneNumberTextbox;
        private Label supplierDetailOverviewSupplierNameLabel;
        private TextBox supplierDetailOverviewSupplierNameTextbox;
        private TabPage supplierDetailTabControlFinancePage;
        private Label supplierDetailFinanceVATNumberTextboxLabel;
        private TextBox supplierDetailFinanceVATNumberTextbox;
        private CheckBox supplierDetailFinanceVATRegisteredCheckbox;
        private Label supplierDetailFinancePaymentDaysTextboxLabel;
        private Label supplierDetailFinancePaymentCurrencyComboBoxLabel;
        private TextBox supplierDetailFinancePaymentDaysTextbox;
        private ComboBox supplierDetailFinancePaymentCurrencyComboBox;
        private TabPage supplierDetailTabControlSupplierNotesPage;
        private Button supplierDetailSupplierNotesCreateNewSupplierNoteButton;
        private DataGridView supplierDetailSupplierNotesExistingSupplierNotesDataGridView;
        private Button supplierDetailSupplierNotesRefreshDataButton;
    }
}