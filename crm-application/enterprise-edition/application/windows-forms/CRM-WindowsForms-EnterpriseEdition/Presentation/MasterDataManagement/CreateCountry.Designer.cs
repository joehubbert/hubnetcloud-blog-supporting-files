namespace CRM.Presentation.MasterDataManagement
{
    partial class CreateCountry
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
            createCountrySubmitButton = new Button();
            createCountryActiveStatusCheckBox = new CheckBox();
            createCountryTitleLabel = new Label();
            createCountryCountryEnglishNameTextBox = new TextBox();
            createCountryISO31661A2CountryCodeMaskedTextBoxLabel = new Label();
            createCountryCountryEnglishNameTextBoxLabel = new Label();
            createCountryISO31661A2CountryCodeMaskedTextBox = new MaskedTextBox();
            SuspendLayout();
            // 
            // createCountrySubmitButton
            // 
            createCountrySubmitButton.FlatStyle = FlatStyle.Flat;
            createCountrySubmitButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createCountrySubmitButton.Location = new Point(197, 209);
            createCountrySubmitButton.Margin = new Padding(4);
            createCountrySubmitButton.Name = "createCountrySubmitButton";
            createCountrySubmitButton.Size = new Size(198, 66);
            createCountrySubmitButton.TabIndex = 3;
            createCountrySubmitButton.Text = "Submit";
            createCountrySubmitButton.UseVisualStyleBackColor = true;
            // 
            // createCountryActiveStatusCheckBox
            // 
            createCountryActiveStatusCheckBox.AutoSize = true;
            createCountryActiveStatusCheckBox.Checked = true;
            createCountryActiveStatusCheckBox.CheckState = CheckState.Checked;
            createCountryActiveStatusCheckBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createCountryActiveStatusCheckBox.Location = new Point(232, 166);
            createCountryActiveStatusCheckBox.Margin = new Padding(5);
            createCountryActiveStatusCheckBox.Name = "createCountryActiveStatusCheckBox";
            createCountryActiveStatusCheckBox.Size = new Size(130, 24);
            createCountryActiveStatusCheckBox.TabIndex = 2;
            createCountryActiveStatusCheckBox.Text = "Active Country*";
            createCountryActiveStatusCheckBox.UseVisualStyleBackColor = true;
            // 
            // createCountryTitleLabel
            // 
            createCountryTitleLabel.AutoSize = true;
            createCountryTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createCountryTitleLabel.Location = new Point(14, 9);
            createCountryTitleLabel.Margin = new Padding(5, 0, 5, 0);
            createCountryTitleLabel.Name = "createCountryTitleLabel";
            createCountryTitleLabel.Size = new Size(187, 32);
            createCountryTitleLabel.TabIndex = 9;
            createCountryTitleLabel.Text = "Create Country";
            // 
            // createCountryCountryEnglishNameTextBox
            // 
            createCountryCountryEnglishNameTextBox.Location = new Point(263, 111);
            createCountryCountryEnglishNameTextBox.MaxLength = 100;
            createCountryCountryEnglishNameTextBox.Name = "createCountryCountryEnglishNameTextBox";
            createCountryCountryEnglishNameTextBox.Size = new Size(285, 27);
            createCountryCountryEnglishNameTextBox.TabIndex = 1;
            // 
            // createCountryISO31661A2CountryCodeMaskedTextBoxLabel
            // 
            createCountryISO31661A2CountryCodeMaskedTextBoxLabel.AutoSize = true;
            createCountryISO31661A2CountryCodeMaskedTextBoxLabel.Location = new Point(26, 72);
            createCountryISO31661A2CountryCodeMaskedTextBoxLabel.Name = "createCountryISO31661A2CountryCodeMaskedTextBoxLabel";
            createCountryISO31661A2CountryCodeMaskedTextBoxLabel.Size = new Size(237, 20);
            createCountryISO31661A2CountryCodeMaskedTextBoxLabel.TabIndex = 12;
            createCountryISO31661A2CountryCodeMaskedTextBoxLabel.Text = "ISO 3166-1 Alpha 2 Country Code*";
            createCountryISO31661A2CountryCodeMaskedTextBoxLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // createCountryCountryEnglishNameTextBoxLabel
            // 
            createCountryCountryEnglishNameTextBoxLabel.AutoSize = true;
            createCountryCountryEnglishNameTextBoxLabel.Location = new Point(102, 114);
            createCountryCountryEnglishNameTextBoxLabel.Name = "createCountryCountryEnglishNameTextBoxLabel";
            createCountryCountryEnglishNameTextBoxLabel.Size = new Size(161, 20);
            createCountryCountryEnglishNameTextBoxLabel.TabIndex = 13;
            createCountryCountryEnglishNameTextBoxLabel.Text = "Country English Name*";
            createCountryCountryEnglishNameTextBoxLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // createCountryISO31661A2CountryCodeMaskedTextBox
            // 
            createCountryISO31661A2CountryCodeMaskedTextBox.Location = new Point(263, 69);
            createCountryISO31661A2CountryCodeMaskedTextBox.Mask = "LL";
            createCountryISO31661A2CountryCodeMaskedTextBox.Name = "createCountryISO31661A2CountryCodeMaskedTextBox";
            createCountryISO31661A2CountryCodeMaskedTextBox.RejectInputOnFirstFailure = true;
            createCountryISO31661A2CountryCodeMaskedTextBox.Size = new Size(39, 27);
            createCountryISO31661A2CountryCodeMaskedTextBox.TabIndex = 0;
            // 
            // CreateCountry
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(582, 292);
            Controls.Add(createCountryISO31661A2CountryCodeMaskedTextBox);
            Controls.Add(createCountryCountryEnglishNameTextBoxLabel);
            Controls.Add(createCountryISO31661A2CountryCodeMaskedTextBoxLabel);
            Controls.Add(createCountryCountryEnglishNameTextBox);
            Controls.Add(createCountrySubmitButton);
            Controls.Add(createCountryActiveStatusCheckBox);
            Controls.Add(createCountryTitleLabel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "CreateCountry";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - Create Country";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button createCountrySubmitButton;
        private CheckBox createCountryActiveStatusCheckBox;
        private Label createCountryTitleLabel;
        private TextBox createCountryCountryEnglishNameTextBox;
        private Label createCountryISO31661A2CountryCodeMaskedTextBoxLabel;
        private Label createCountryCountryEnglishNameTextBoxLabel;
        private MaskedTextBox createCountryISO31661A2CountryCodeMaskedTextBox;
    }
}