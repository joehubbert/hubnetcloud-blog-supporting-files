namespace CRM_WindowsForms.Presentation
{
    partial class PaymentMethodDetail
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
            paymentMethodDetailTitleLabel = new Label();
            paymentMethodDetailUpdatePaymentMethodButton = new Button();
            paymentMethodDetailActiveStatusCheckbox = new CheckBox();
            paymentMethodDetailToggleEditModeButton = new Button();
            paymentMethodDetailPaymentMethodIdTextbox = new TextBox();
            paymentMethodDetailPaymentMethodTextbox = new TextBox();
            paymentMethodDetailCreatedTimestampTextbox = new TextBox();
            paymentMethodDetailLastUpdatedTimestampTextbox = new TextBox();
            paymentMethodDetailCreatedByTextbox = new TextBox();
            paymentMethodDetailLastUpdatedByTextbox = new TextBox();
            paymentMethodDetailLastUpdatedTimestampLabel = new Label();
            paymentMethodDetailLastUpdatedByLabel = new Label();
            paymentMethodDetailCreatedTimestampLabel = new Label();
            paymentMethodDetailCreatedByLabel = new Label();
            paymentMethodDetailPaymentMethodLabel = new Label();
            paymentMethodDetailPaymentMethodIdLabel = new Label();
            SuspendLayout();
            // 
            // paymentMethodDetailTitleLabel
            // 
            paymentMethodDetailTitleLabel.AutoSize = true;
            paymentMethodDetailTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            paymentMethodDetailTitleLabel.Location = new Point(13, 9);
            paymentMethodDetailTitleLabel.Margin = new Padding(4, 0, 4, 0);
            paymentMethodDetailTitleLabel.Name = "paymentMethodDetailTitleLabel";
            paymentMethodDetailTitleLabel.Size = new Size(283, 32);
            paymentMethodDetailTitleLabel.TabIndex = 8;
            paymentMethodDetailTitleLabel.Text = "Payment Method Detail";
            // 
            // paymentMethodDetailUpdatePaymentMethodButton
            // 
            paymentMethodDetailUpdatePaymentMethodButton.Enabled = false;
            paymentMethodDetailUpdatePaymentMethodButton.FlatStyle = FlatStyle.Flat;
            paymentMethodDetailUpdatePaymentMethodButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            paymentMethodDetailUpdatePaymentMethodButton.Location = new Point(525, 339);
            paymentMethodDetailUpdatePaymentMethodButton.Margin = new Padding(4);
            paymentMethodDetailUpdatePaymentMethodButton.Name = "paymentMethodDetailUpdatePaymentMethodButton";
            paymentMethodDetailUpdatePaymentMethodButton.Size = new Size(237, 70);
            paymentMethodDetailUpdatePaymentMethodButton.TabIndex = 8;
            paymentMethodDetailUpdatePaymentMethodButton.Text = "Update Payment Method";
            paymentMethodDetailUpdatePaymentMethodButton.UseVisualStyleBackColor = true;
            paymentMethodDetailUpdatePaymentMethodButton.Click += paymentMethodDetailUpdatePaymentMethodButton_Click;
            // 
            // paymentMethodDetailActiveStatusCheckbox
            // 
            paymentMethodDetailActiveStatusCheckbox.AutoSize = true;
            paymentMethodDetailActiveStatusCheckbox.Enabled = false;
            paymentMethodDetailActiveStatusCheckbox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            paymentMethodDetailActiveStatusCheckbox.Location = new Point(201, 309);
            paymentMethodDetailActiveStatusCheckbox.Margin = new Padding(4);
            paymentMethodDetailActiveStatusCheckbox.Name = "paymentMethodDetailActiveStatusCheckbox";
            paymentMethodDetailActiveStatusCheckbox.Size = new Size(185, 24);
            paymentMethodDetailActiveStatusCheckbox.TabIndex = 2;
            paymentMethodDetailActiveStatusCheckbox.Text = "Active Payment Method";
            paymentMethodDetailActiveStatusCheckbox.UseVisualStyleBackColor = true;
            // 
            // paymentMethodDetailToggleEditModeButton
            // 
            paymentMethodDetailToggleEditModeButton.FlatStyle = FlatStyle.Flat;
            paymentMethodDetailToggleEditModeButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            paymentMethodDetailToggleEditModeButton.Location = new Point(1111, 13);
            paymentMethodDetailToggleEditModeButton.Margin = new Padding(4);
            paymentMethodDetailToggleEditModeButton.Name = "paymentMethodDetailToggleEditModeButton";
            paymentMethodDetailToggleEditModeButton.Size = new Size(108, 92);
            paymentMethodDetailToggleEditModeButton.TabIndex = 7;
            paymentMethodDetailToggleEditModeButton.Text = "Toggle Edit Mode";
            paymentMethodDetailToggleEditModeButton.UseVisualStyleBackColor = true;
            // 
            // paymentMethodDetailPaymentMethodIdTextbox
            // 
            paymentMethodDetailPaymentMethodIdTextbox.Location = new Point(201, 138);
            paymentMethodDetailPaymentMethodIdTextbox.MaxLength = 36;
            paymentMethodDetailPaymentMethodIdTextbox.Name = "paymentMethodDetailPaymentMethodIdTextbox";
            paymentMethodDetailPaymentMethodIdTextbox.ReadOnly = true;
            paymentMethodDetailPaymentMethodIdTextbox.Size = new Size(370, 27);
            paymentMethodDetailPaymentMethodIdTextbox.TabIndex = 0;
            // 
            // paymentMethodDetailPaymentMethodTextbox
            // 
            paymentMethodDetailPaymentMethodTextbox.Enabled = false;
            paymentMethodDetailPaymentMethodTextbox.Location = new Point(201, 178);
            paymentMethodDetailPaymentMethodTextbox.MaxLength = 50;
            paymentMethodDetailPaymentMethodTextbox.Name = "paymentMethodDetailPaymentMethodTextbox";
            paymentMethodDetailPaymentMethodTextbox.Size = new Size(370, 27);
            paymentMethodDetailPaymentMethodTextbox.TabIndex = 1;
            // 
            // paymentMethodDetailCreatedTimestampTextbox
            // 
            paymentMethodDetailCreatedTimestampTextbox.Enabled = false;
            paymentMethodDetailCreatedTimestampTextbox.Location = new Point(849, 178);
            paymentMethodDetailCreatedTimestampTextbox.MaxLength = 50;
            paymentMethodDetailCreatedTimestampTextbox.Name = "paymentMethodDetailCreatedTimestampTextbox";
            paymentMethodDetailCreatedTimestampTextbox.ReadOnly = true;
            paymentMethodDetailCreatedTimestampTextbox.Size = new Size(370, 27);
            paymentMethodDetailCreatedTimestampTextbox.TabIndex = 4;
            // 
            // paymentMethodDetailLastUpdatedTimestampTextbox
            // 
            paymentMethodDetailLastUpdatedTimestampTextbox.Enabled = false;
            paymentMethodDetailLastUpdatedTimestampTextbox.Location = new Point(849, 258);
            paymentMethodDetailLastUpdatedTimestampTextbox.MaxLength = 50;
            paymentMethodDetailLastUpdatedTimestampTextbox.Name = "paymentMethodDetailLastUpdatedTimestampTextbox";
            paymentMethodDetailLastUpdatedTimestampTextbox.ReadOnly = true;
            paymentMethodDetailLastUpdatedTimestampTextbox.Size = new Size(370, 27);
            paymentMethodDetailLastUpdatedTimestampTextbox.TabIndex = 6;
            // 
            // paymentMethodDetailCreatedByTextbox
            // 
            paymentMethodDetailCreatedByTextbox.Enabled = false;
            paymentMethodDetailCreatedByTextbox.Location = new Point(849, 138);
            paymentMethodDetailCreatedByTextbox.MaxLength = 50;
            paymentMethodDetailCreatedByTextbox.Name = "paymentMethodDetailCreatedByTextbox";
            paymentMethodDetailCreatedByTextbox.ReadOnly = true;
            paymentMethodDetailCreatedByTextbox.Size = new Size(370, 27);
            paymentMethodDetailCreatedByTextbox.TabIndex = 3;
            // 
            // paymentMethodDetailLastUpdatedByTextbox
            // 
            paymentMethodDetailLastUpdatedByTextbox.Enabled = false;
            paymentMethodDetailLastUpdatedByTextbox.Location = new Point(849, 218);
            paymentMethodDetailLastUpdatedByTextbox.MaxLength = 50;
            paymentMethodDetailLastUpdatedByTextbox.Name = "paymentMethodDetailLastUpdatedByTextbox";
            paymentMethodDetailLastUpdatedByTextbox.ReadOnly = true;
            paymentMethodDetailLastUpdatedByTextbox.Size = new Size(370, 27);
            paymentMethodDetailLastUpdatedByTextbox.TabIndex = 5;
            // 
            // paymentMethodDetailLastUpdatedTimestampLabel
            // 
            paymentMethodDetailLastUpdatedTimestampLabel.AutoSize = true;
            paymentMethodDetailLastUpdatedTimestampLabel.Location = new Point(658, 265);
            paymentMethodDetailLastUpdatedTimestampLabel.Name = "paymentMethodDetailLastUpdatedTimestampLabel";
            paymentMethodDetailLastUpdatedTimestampLabel.Size = new Size(175, 20);
            paymentMethodDetailLastUpdatedTimestampLabel.TabIndex = 34;
            paymentMethodDetailLastUpdatedTimestampLabel.Text = "Last Updated Timestamp";
            // 
            // paymentMethodDetailLastUpdatedByLabel
            // 
            paymentMethodDetailLastUpdatedByLabel.AutoSize = true;
            paymentMethodDetailLastUpdatedByLabel.Location = new Point(658, 224);
            paymentMethodDetailLastUpdatedByLabel.Name = "paymentMethodDetailLastUpdatedByLabel";
            paymentMethodDetailLastUpdatedByLabel.Size = new Size(117, 20);
            paymentMethodDetailLastUpdatedByLabel.TabIndex = 33;
            paymentMethodDetailLastUpdatedByLabel.Text = "Last Updated By";
            // 
            // paymentMethodDetailCreatedTimestampLabel
            // 
            paymentMethodDetailCreatedTimestampLabel.AutoSize = true;
            paymentMethodDetailCreatedTimestampLabel.Location = new Point(658, 180);
            paymentMethodDetailCreatedTimestampLabel.Name = "paymentMethodDetailCreatedTimestampLabel";
            paymentMethodDetailCreatedTimestampLabel.Size = new Size(139, 20);
            paymentMethodDetailCreatedTimestampLabel.TabIndex = 32;
            paymentMethodDetailCreatedTimestampLabel.Text = "Created Timestamp";
            // 
            // paymentMethodDetailCreatedByLabel
            // 
            paymentMethodDetailCreatedByLabel.AutoSize = true;
            paymentMethodDetailCreatedByLabel.Location = new Point(658, 141);
            paymentMethodDetailCreatedByLabel.Name = "paymentMethodDetailCreatedByLabel";
            paymentMethodDetailCreatedByLabel.Size = new Size(81, 20);
            paymentMethodDetailCreatedByLabel.TabIndex = 31;
            paymentMethodDetailCreatedByLabel.Text = "Created By";
            // 
            // paymentMethodDetailPaymentMethodLabel
            // 
            paymentMethodDetailPaymentMethodLabel.AutoSize = true;
            paymentMethodDetailPaymentMethodLabel.Location = new Point(74, 181);
            paymentMethodDetailPaymentMethodLabel.Name = "paymentMethodDetailPaymentMethodLabel";
            paymentMethodDetailPaymentMethodLabel.Size = new Size(121, 20);
            paymentMethodDetailPaymentMethodLabel.TabIndex = 30;
            paymentMethodDetailPaymentMethodLabel.Text = "Payment Method";
            // 
            // paymentMethodDetailPaymentMethodIdLabel
            // 
            paymentMethodDetailPaymentMethodIdLabel.AutoSize = true;
            paymentMethodDetailPaymentMethodIdLabel.Location = new Point(57, 141);
            paymentMethodDetailPaymentMethodIdLabel.Name = "paymentMethodDetailPaymentMethodIdLabel";
            paymentMethodDetailPaymentMethodIdLabel.Size = new Size(138, 20);
            paymentMethodDetailPaymentMethodIdLabel.TabIndex = 28;
            paymentMethodDetailPaymentMethodIdLabel.Text = "Payment Method Id";
            // 
            // PaymentMethodDetail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1244, 438);
            Controls.Add(paymentMethodDetailUpdatePaymentMethodButton);
            Controls.Add(paymentMethodDetailActiveStatusCheckbox);
            Controls.Add(paymentMethodDetailToggleEditModeButton);
            Controls.Add(paymentMethodDetailPaymentMethodIdTextbox);
            Controls.Add(paymentMethodDetailPaymentMethodTextbox);
            Controls.Add(paymentMethodDetailCreatedTimestampTextbox);
            Controls.Add(paymentMethodDetailLastUpdatedTimestampTextbox);
            Controls.Add(paymentMethodDetailCreatedByTextbox);
            Controls.Add(paymentMethodDetailLastUpdatedByTextbox);
            Controls.Add(paymentMethodDetailLastUpdatedTimestampLabel);
            Controls.Add(paymentMethodDetailLastUpdatedByLabel);
            Controls.Add(paymentMethodDetailCreatedTimestampLabel);
            Controls.Add(paymentMethodDetailCreatedByLabel);
            Controls.Add(paymentMethodDetailPaymentMethodLabel);
            Controls.Add(paymentMethodDetailPaymentMethodIdLabel);
            Controls.Add(paymentMethodDetailTitleLabel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "PaymentMethodDetail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - Payment Method Detail";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label paymentMethodDetailTitleLabel;
        private Button paymentMethodDetailUpdatePaymentMethodButton;
        private CheckBox paymentMethodDetailActiveStatusCheckbox;
        private Button paymentMethodDetailToggleEditModeButton;
        private TextBox paymentMethodDetailPaymentMethodIdTextbox;
        private TextBox paymentMethodDetailPaymentMethodTextbox;
        private TextBox paymentMethodDetailCreatedTimestampTextbox;
        private TextBox paymentMethodDetailLastUpdatedTimestampTextbox;
        private TextBox paymentMethodDetailCreatedByTextbox;
        private TextBox paymentMethodDetailLastUpdatedByTextbox;
        private Label paymentMethodDetailLastUpdatedTimestampLabel;
        private Label paymentMethodDetailLastUpdatedByLabel;
        private Label paymentMethodDetailCreatedTimestampLabel;
        private Label paymentMethodDetailCreatedByLabel;
        private Label paymentMethodDetailPaymentMethodLabel;
        private Label paymentMethodDetailPaymentMethodIdLabel;
    }
}