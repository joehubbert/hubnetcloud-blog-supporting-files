namespace CRM_WindowsForms_EnterpriseEdition.Presentation
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
            createCountryActiveStatusCheckbox = new CheckBox();
            createCountryTitleLabel = new Label();
            createCountryISO31661A2CountryCodeTextbox = new TextBox();
            createCountryCountryEnglishNameTextbox = new TextBox();
            createCountryISO31661A2CountryCodeTextboxLabel = new Label();
            createCountryCountryEnglishNameTextboxLabel = new Label();
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
            // createCountryActiveStatusCheckbox
            // 
            createCountryActiveStatusCheckbox.AutoSize = true;
            createCountryActiveStatusCheckbox.Checked = true;
            createCountryActiveStatusCheckbox.CheckState = CheckState.Checked;
            createCountryActiveStatusCheckbox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createCountryActiveStatusCheckbox.Location = new Point(232, 166);
            createCountryActiveStatusCheckbox.Margin = new Padding(5);
            createCountryActiveStatusCheckbox.Name = "createCountryActiveStatusCheckbox";
            createCountryActiveStatusCheckbox.Size = new Size(124, 24);
            createCountryActiveStatusCheckbox.TabIndex = 2;
            createCountryActiveStatusCheckbox.Text = "Active Country";
            createCountryActiveStatusCheckbox.UseVisualStyleBackColor = true;
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
            // createCountryISO31661A2CountryCodeTextbox
            // 
            createCountryISO31661A2CountryCodeTextbox.Location = new Point(263, 69);
            createCountryISO31661A2CountryCodeTextbox.MaxLength = 2;
            createCountryISO31661A2CountryCodeTextbox.Name = "createCountryISO31661A2CountryCodeTextbox";
            createCountryISO31661A2CountryCodeTextbox.Size = new Size(39, 27);
            createCountryISO31661A2CountryCodeTextbox.TabIndex = 0;
            // 
            // createCountryCountryEnglishNameTextbox
            // 
            createCountryCountryEnglishNameTextbox.Location = new Point(263, 111);
            createCountryCountryEnglishNameTextbox.Name = "createCountryCountryEnglishNameTextbox";
            createCountryCountryEnglishNameTextbox.Size = new Size(285, 27);
            createCountryCountryEnglishNameTextbox.TabIndex = 1;
            // 
            // createCountryISO31661A2CountryCodeTextboxLabel
            // 
            createCountryISO31661A2CountryCodeTextboxLabel.AutoSize = true;
            createCountryISO31661A2CountryCodeTextboxLabel.Location = new Point(26, 72);
            createCountryISO31661A2CountryCodeTextboxLabel.Name = "createCountryISO31661A2CountryCodeTextboxLabel";
            createCountryISO31661A2CountryCodeTextboxLabel.Size = new Size(231, 20);
            createCountryISO31661A2CountryCodeTextboxLabel.TabIndex = 12;
            createCountryISO31661A2CountryCodeTextboxLabel.Text = "ISO 3166-1 Alpha 2 Country Code";
            createCountryISO31661A2CountryCodeTextboxLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // createCountryCountryEnglishNameTextboxLabel
            // 
            createCountryCountryEnglishNameTextboxLabel.AutoSize = true;
            createCountryCountryEnglishNameTextboxLabel.Location = new Point(102, 114);
            createCountryCountryEnglishNameTextboxLabel.Name = "createCountryCountryEnglishNameTextboxLabel";
            createCountryCountryEnglishNameTextboxLabel.Size = new Size(155, 20);
            createCountryCountryEnglishNameTextboxLabel.TabIndex = 13;
            createCountryCountryEnglishNameTextboxLabel.Text = "Country English Name";
            createCountryCountryEnglishNameTextboxLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // CreateCountry
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(582, 292);
            Controls.Add(createCountryCountryEnglishNameTextboxLabel);
            Controls.Add(createCountryISO31661A2CountryCodeTextboxLabel);
            Controls.Add(createCountryCountryEnglishNameTextbox);
            Controls.Add(createCountryISO31661A2CountryCodeTextbox);
            Controls.Add(createCountrySubmitButton);
            Controls.Add(createCountryActiveStatusCheckbox);
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
        private CheckBox createCountryActiveStatusCheckbox;
        private Label createCountryTitleLabel;
        private TextBox createCountryISO31661A2CountryCodeTextbox;
        private TextBox createCountryCountryEnglishNameTextbox;
        private Label createCountryISO31661A2CountryCodeTextboxLabel;
        private Label createCountryCountryEnglishNameTextboxLabel;
    }
}