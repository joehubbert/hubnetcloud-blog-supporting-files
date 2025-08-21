namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    partial class CreateCurrency
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
            createCurrencyTitleLabel = new Label();
            createCurrencyCurrencyCodeMaskedTextBoxLabel = new Label();
            createCurrencyActiveStatusCheckbox = new CheckBox();
            createCurrencySubmitButton = new Button();
            createCurrencyCurrencyNameLabel = new Label();
            createCurrencyCurrencyNameTextBox = new TextBox();
            createCurrencyCurrencyCodeMaskedTextBox = new MaskedTextBox();
            SuspendLayout();
            // 
            // createCurrencyTitleLabel
            // 
            createCurrencyTitleLabel.AutoSize = true;
            createCurrencyTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createCurrencyTitleLabel.Location = new Point(15, 12);
            createCurrencyTitleLabel.Margin = new Padding(5, 0, 5, 0);
            createCurrencyTitleLabel.Name = "createCurrencyTitleLabel";
            createCurrencyTitleLabel.Size = new Size(197, 32);
            createCurrencyTitleLabel.TabIndex = 6;
            createCurrencyTitleLabel.Text = "Create Currency";
            // 
            // createCurrencyCurrencyCodeMaskedTextBoxLabel
            // 
            createCurrencyCurrencyCodeMaskedTextBoxLabel.AutoSize = true;
            createCurrencyCurrencyCodeMaskedTextBoxLabel.Font = new Font("Segoe UI", 11F);
            createCurrencyCurrencyCodeMaskedTextBoxLabel.Location = new Point(91, 74);
            createCurrencyCurrencyCodeMaskedTextBoxLabel.Name = "createCurrencyCurrencyCodeMaskedTextBoxLabel";
            createCurrencyCurrencyCodeMaskedTextBoxLabel.Size = new Size(111, 20);
            createCurrencyCurrencyCodeMaskedTextBoxLabel.TabIndex = 7;
            createCurrencyCurrencyCodeMaskedTextBoxLabel.Text = "Currency Code*";
            createCurrencyCurrencyCodeMaskedTextBoxLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // createCurrencyActiveStatusCheckbox
            // 
            createCurrencyActiveStatusCheckbox.AutoSize = true;
            createCurrencyActiveStatusCheckbox.Checked = true;
            createCurrencyActiveStatusCheckbox.CheckState = CheckState.Checked;
            createCurrencyActiveStatusCheckbox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createCurrencyActiveStatusCheckbox.Location = new Point(202, 180);
            createCurrencyActiveStatusCheckbox.Margin = new Padding(5);
            createCurrencyActiveStatusCheckbox.Name = "createCurrencyActiveStatusCheckbox";
            createCurrencyActiveStatusCheckbox.Size = new Size(136, 24);
            createCurrencyActiveStatusCheckbox.TabIndex = 3;
            createCurrencyActiveStatusCheckbox.Text = "Active Currency*";
            createCurrencyActiveStatusCheckbox.UseVisualStyleBackColor = true;
            // 
            // createCurrencySubmitButton
            // 
            createCurrencySubmitButton.FlatStyle = FlatStyle.Flat;
            createCurrencySubmitButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createCurrencySubmitButton.Location = new Point(173, 223);
            createCurrencySubmitButton.Margin = new Padding(4);
            createCurrencySubmitButton.Name = "createCurrencySubmitButton";
            createCurrencySubmitButton.Size = new Size(198, 66);
            createCurrencySubmitButton.TabIndex = 4;
            createCurrencySubmitButton.Text = "Submit";
            createCurrencySubmitButton.UseVisualStyleBackColor = true;
            createCurrencySubmitButton.Click += createCurrencySubmitButton_Click;
            // 
            // createCurrencyCurrencyNameLabel
            // 
            createCurrencyCurrencyNameLabel.AutoSize = true;
            createCurrencyCurrencyNameLabel.Font = new Font("Segoe UI", 11F);
            createCurrencyCurrencyNameLabel.Location = new Point(86, 114);
            createCurrencyCurrencyNameLabel.Name = "createCurrencyCurrencyNameLabel";
            createCurrencyCurrencyNameLabel.Size = new Size(116, 20);
            createCurrencyCurrencyNameLabel.TabIndex = 50;
            createCurrencyCurrencyNameLabel.Text = "Currency Name*";
            createCurrencyCurrencyNameLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // createCurrencyCurrencyNameTextBox
            // 
            createCurrencyCurrencyNameTextBox.Location = new Point(202, 111);
            createCurrencyCurrencyNameTextBox.Margin = new Padding(3, 4, 3, 4);
            createCurrencyCurrencyNameTextBox.MaxLength = 50;
            createCurrencyCurrencyNameTextBox.Name = "createCurrencyCurrencyNameTextBox";
            createCurrencyCurrencyNameTextBox.Size = new Size(284, 27);
            createCurrencyCurrencyNameTextBox.TabIndex = 1;
            // 
            // createCurrencyCurrencyCodeMaskedTextBox
            // 
            createCurrencyCurrencyCodeMaskedTextBox.Location = new Point(202, 71);
            createCurrencyCurrencyCodeMaskedTextBox.Mask = "LLL";
            createCurrencyCurrencyCodeMaskedTextBox.Name = "createCurrencyCurrencyCodeMaskedTextBox";
            createCurrencyCurrencyCodeMaskedTextBox.RejectInputOnFirstFailure = true;
            createCurrencyCurrencyCodeMaskedTextBox.Size = new Size(46, 27);
            createCurrencyCurrencyCodeMaskedTextBox.TabIndex = 0;
            // 
            // CreateCurrency
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(543, 296);
            Controls.Add(createCurrencyCurrencyCodeMaskedTextBox);
            Controls.Add(createCurrencyCurrencyNameTextBox);
            Controls.Add(createCurrencyCurrencyNameLabel);
            Controls.Add(createCurrencySubmitButton);
            Controls.Add(createCurrencyActiveStatusCheckbox);
            Controls.Add(createCurrencyCurrencyCodeMaskedTextBoxLabel);
            Controls.Add(createCurrencyTitleLabel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "CreateCurrency";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - Create Currency";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label createCurrencyTitleLabel;
        private Label createCurrencyCurrencyCodeMaskedTextBoxLabel;
        private CheckBox createCurrencyActiveStatusCheckbox;
        private Button createCurrencySubmitButton;
        private Label createCurrencyCurrencyNameLabel;
        private TextBox createCurrencyCurrencyNameTextBox;
        private MaskedTextBox createCurrencyCurrencyCodeMaskedTextBox;
    }
}