namespace CRM_WindowsForms.Presentation
{
    partial class CreatePaymentMethod
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
            createPaymentMethodTitleLabel = new Label();
            createPaymentMethodPaymentMethodTextbox = new TextBox();
            createPaymentMethodPaymentMethodLabel = new Label();
            createPaymentMethodSubmitButton = new Button();
            createPaymentMethodActiveStatusCheckbox = new CheckBox();
            SuspendLayout();
            // 
            // createPaymentMethodTitleLabel
            // 
            createPaymentMethodTitleLabel.AutoSize = true;
            createPaymentMethodTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createPaymentMethodTitleLabel.Location = new Point(15, 12);
            createPaymentMethodTitleLabel.Margin = new Padding(5, 0, 5, 0);
            createPaymentMethodTitleLabel.Name = "createPaymentMethodTitleLabel";
            createPaymentMethodTitleLabel.Size = new Size(313, 32);
            createPaymentMethodTitleLabel.TabIndex = 7;
            createPaymentMethodTitleLabel.Text = "Create Payment Method";
            // 
            // createPaymentMethodPaymentMethodTextbox
            // 
            createPaymentMethodPaymentMethodTextbox.Location = new Point(181, 74);
            createPaymentMethodPaymentMethodTextbox.Margin = new Padding(3, 4, 3, 4);
            createPaymentMethodPaymentMethodTextbox.MaxLength = 50;
            createPaymentMethodPaymentMethodTextbox.Name = "createPaymentMethodPaymentMethodTextbox";
            createPaymentMethodPaymentMethodTextbox.Size = new Size(343, 27);
            createPaymentMethodPaymentMethodTextbox.TabIndex = 20;
            // 
            // createPaymentMethodPaymentMethodLabel
            // 
            createPaymentMethodPaymentMethodLabel.AutoSize = true;
            createPaymentMethodPaymentMethodLabel.Font = new Font("Segoe UI", 11F);
            createPaymentMethodPaymentMethodLabel.Location = new Point(25, 77);
            createPaymentMethodPaymentMethodLabel.Name = "createPaymentMethodPaymentMethodLabel";
            createPaymentMethodPaymentMethodLabel.Size = new Size(136, 20);
            createPaymentMethodPaymentMethodLabel.TabIndex = 19;
            createPaymentMethodPaymentMethodLabel.Text = "Payment Method";
            // 
            // createPaymentMethodSubmitButton
            // 
            createPaymentMethodSubmitButton.FlatStyle = FlatStyle.Flat;
            createPaymentMethodSubmitButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createPaymentMethodSubmitButton.Location = new Point(191, 190);
            createPaymentMethodSubmitButton.Margin = new Padding(4);
            createPaymentMethodSubmitButton.Name = "createPaymentMethodSubmitButton";
            createPaymentMethodSubmitButton.Size = new Size(198, 66);
            createPaymentMethodSubmitButton.TabIndex = 18;
            createPaymentMethodSubmitButton.Text = "Submit";
            createPaymentMethodSubmitButton.UseVisualStyleBackColor = true;
            // 
            // createPaymentMethodActiveStatusCheckbox
            // 
            createPaymentMethodActiveStatusCheckbox.AutoSize = true;
            createPaymentMethodActiveStatusCheckbox.Checked = true;
            createPaymentMethodActiveStatusCheckbox.CheckState = CheckState.Checked;
            createPaymentMethodActiveStatusCheckbox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createPaymentMethodActiveStatusCheckbox.Location = new Point(193, 146);
            createPaymentMethodActiveStatusCheckbox.Margin = new Padding(5);
            createPaymentMethodActiveStatusCheckbox.Name = "createPaymentMethodActiveStatusCheckbox";
            createPaymentMethodActiveStatusCheckbox.Size = new Size(200, 24);
            createPaymentMethodActiveStatusCheckbox.TabIndex = 17;
            createPaymentMethodActiveStatusCheckbox.Text = "Active Payment Method";
            createPaymentMethodActiveStatusCheckbox.UseVisualStyleBackColor = true;
            // 
            // CreatePaymentMethod
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(559, 266);
            Controls.Add(createPaymentMethodPaymentMethodTextbox);
            Controls.Add(createPaymentMethodPaymentMethodLabel);
            Controls.Add(createPaymentMethodSubmitButton);
            Controls.Add(createPaymentMethodActiveStatusCheckbox);
            Controls.Add(createPaymentMethodTitleLabel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "CreatePaymentMethod";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - Create Payment Method";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label createPaymentMethodTitleLabel;
        private TextBox createPaymentMethodPaymentMethodTextbox;
        private Label createPaymentMethodPaymentMethodLabel;
        private Button createPaymentMethodSubmitButton;
        private CheckBox createPaymentMethodActiveStatusCheckbox;
    }
}