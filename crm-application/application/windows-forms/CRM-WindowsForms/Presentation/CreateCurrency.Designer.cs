namespace CRM_WindowsForms.Presentation
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
            createCurrencyCurrencyCodeLabel = new Label();
            createCurrencyCurrencyCodeTextbox = new TextBox();
            createCurrencyActiveStatusCheckbox = new CheckBox();
            createCurrencySubmitButton = new Button();
            createCurrencyCurrencyNameLabel = new Label();
            createCurrencyCurrencyNameTextbox = new TextBox();
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
            // createCurrencyCurrencyCodeLabel
            // 
            createCurrencyCurrencyCodeLabel.AutoSize = true;
            createCurrencyCurrencyCodeLabel.Font = new Font("Segoe UI", 11F);
            createCurrencyCurrencyCodeLabel.Location = new Point(75, 74);
            createCurrencyCurrencyCodeLabel.Name = "createCurrencyCurrencyCodeLabel";
            createCurrencyCurrencyCodeLabel.Size = new Size(105, 20);
            createCurrencyCurrencyCodeLabel.TabIndex = 7;
            createCurrencyCurrencyCodeLabel.Text = "Currency Code";
            // 
            // createCurrencyCurrencyCodeTextbox
            // 
            createCurrencyCurrencyCodeTextbox.Location = new Point(202, 71);
            createCurrencyCurrencyCodeTextbox.Margin = new Padding(3, 4, 3, 4);
            createCurrencyCurrencyCodeTextbox.MaxLength = 3;
            createCurrencyCurrencyCodeTextbox.Name = "createCurrencyCurrencyCodeTextbox";
            createCurrencyCurrencyCodeTextbox.Size = new Size(48, 27);
            createCurrencyCurrencyCodeTextbox.TabIndex = 0;
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
            createCurrencyActiveStatusCheckbox.Size = new Size(130, 24);
            createCurrencyActiveStatusCheckbox.TabIndex = 3;
            createCurrencyActiveStatusCheckbox.Text = "Active Currency";
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
            createCurrencyCurrencyNameLabel.Location = new Point(70, 109);
            createCurrencyCurrencyNameLabel.Name = "createCurrencyCurrencyNameLabel";
            createCurrencyCurrencyNameLabel.Size = new Size(110, 20);
            createCurrencyCurrencyNameLabel.TabIndex = 50;
            createCurrencyCurrencyNameLabel.Text = "Currency Name";
            // 
            // createCurrencyCurrencyNameTextbox
            // 
            createCurrencyCurrencyNameTextbox.Location = new Point(202, 106);
            createCurrencyCurrencyNameTextbox.Margin = new Padding(3, 4, 3, 4);
            createCurrencyCurrencyNameTextbox.MaxLength = 50;
            createCurrencyCurrencyNameTextbox.Name = "createCurrencyCurrencyNameTextbox";
            createCurrencyCurrencyNameTextbox.Size = new Size(284, 27);
            createCurrencyCurrencyNameTextbox.TabIndex = 1;
            // 
            // CreateCurrency
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(543, 296);
            Controls.Add(createCurrencyCurrencyNameTextbox);
            Controls.Add(createCurrencyCurrencyNameLabel);
            Controls.Add(createCurrencySubmitButton);
            Controls.Add(createCurrencyActiveStatusCheckbox);
            Controls.Add(createCurrencyCurrencyCodeTextbox);
            Controls.Add(createCurrencyCurrencyCodeLabel);
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
        private Label createCurrencyCurrencyCodeLabel;
        private TextBox createCurrencyCurrencyCodeTextbox;
        private CheckBox createCurrencyActiveStatusCheckbox;
        private Button createCurrencySubmitButton;
        private Label createCurrencyCurrencyNameLabel;
        private TextBox createCurrencyCurrencyNameTextbox;
    }
}