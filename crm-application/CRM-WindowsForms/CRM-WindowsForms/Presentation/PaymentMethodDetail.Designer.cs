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
            paymentMethodDetailUpdateSupplierTypeButton = new Button();
            paymentMethodDetailActiveStatusCheckbox = new CheckBox();
            paymentMethodDetailToggleEditModeButton = new Button();
            paymentMethodDetailSupplierTypeIdTextbox = new TextBox();
            paymentMethodDetailSupplierTypeTextbox = new TextBox();
            paymentMethodDetailCreatedTimestampTextbox = new TextBox();
            paymentMethodDetailLastUpdatedTimestampTextbox = new TextBox();
            paymentMethodDetailCreatedByTextbox = new TextBox();
            paymentMethodDetailLastUpdatedByTextbox = new TextBox();
            paymentMethodDetailLastUpdatedTimestampLabel = new Label();
            paymentMethodDetailLastUpdatedByLabel = new Label();
            paymentMethodDetailCreatedTimestampLabel = new Label();
            paymentMethodDetailCreatedByLabel = new Label();
            paymentMethodDetailSupplierTypeLabel = new Label();
            paymentMethodDetailSupplierTypeIdLabel = new Label();
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
            // paymentMethodDetailUpdateSupplierTypeButton
            // 
            paymentMethodDetailUpdateSupplierTypeButton.Enabled = false;
            paymentMethodDetailUpdateSupplierTypeButton.FlatStyle = FlatStyle.Flat;
            paymentMethodDetailUpdateSupplierTypeButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            paymentMethodDetailUpdateSupplierTypeButton.Location = new Point(525, 339);
            paymentMethodDetailUpdateSupplierTypeButton.Margin = new Padding(4);
            paymentMethodDetailUpdateSupplierTypeButton.Name = "paymentMethodDetailUpdateSupplierTypeButton";
            paymentMethodDetailUpdateSupplierTypeButton.Size = new Size(237, 70);
            paymentMethodDetailUpdateSupplierTypeButton.TabIndex = 8;
            paymentMethodDetailUpdateSupplierTypeButton.Text = "Update Payment Method";
            paymentMethodDetailUpdateSupplierTypeButton.UseVisualStyleBackColor = true;
            paymentMethodDetailUpdateSupplierTypeButton.Click += paymentMethodDetailUpdateSupplierTypeButton_Click;
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
            // paymentMethodDetailSupplierTypeIdTextbox
            // 
            paymentMethodDetailSupplierTypeIdTextbox.Location = new Point(201, 138);
            paymentMethodDetailSupplierTypeIdTextbox.MaxLength = 36;
            paymentMethodDetailSupplierTypeIdTextbox.Name = "paymentMethodDetailSupplierTypeIdTextbox";
            paymentMethodDetailSupplierTypeIdTextbox.ReadOnly = true;
            paymentMethodDetailSupplierTypeIdTextbox.Size = new Size(370, 27);
            paymentMethodDetailSupplierTypeIdTextbox.TabIndex = 0;
            // 
            // paymentMethodDetailSupplierTypeTextbox
            // 
            paymentMethodDetailSupplierTypeTextbox.Enabled = false;
            paymentMethodDetailSupplierTypeTextbox.Location = new Point(201, 178);
            paymentMethodDetailSupplierTypeTextbox.MaxLength = 50;
            paymentMethodDetailSupplierTypeTextbox.Name = "paymentMethodDetailSupplierTypeTextbox";
            paymentMethodDetailSupplierTypeTextbox.Size = new Size(370, 27);
            paymentMethodDetailSupplierTypeTextbox.TabIndex = 1;
            // 
            // paymentMethodDetailCreatedTimestampTextbox
            // 
            paymentMethodDetailCreatedTimestampTextbox.Enabled = false;
            paymentMethodDetailCreatedTimestampTextbox.Location = new Point(849, 178);
            paymentMethodDetailCreatedTimestampTextbox.Name = "paymentMethodDetailCreatedTimestampTextbox";
            paymentMethodDetailCreatedTimestampTextbox.ReadOnly = true;
            paymentMethodDetailCreatedTimestampTextbox.Size = new Size(370, 27);
            paymentMethodDetailCreatedTimestampTextbox.TabIndex = 4;
            // 
            // paymentMethodDetailLastUpdatedTimestampTextbox
            // 
            paymentMethodDetailLastUpdatedTimestampTextbox.Enabled = false;
            paymentMethodDetailLastUpdatedTimestampTextbox.Location = new Point(849, 258);
            paymentMethodDetailLastUpdatedTimestampTextbox.Name = "paymentMethodDetailLastUpdatedTimestampTextbox";
            paymentMethodDetailLastUpdatedTimestampTextbox.ReadOnly = true;
            paymentMethodDetailLastUpdatedTimestampTextbox.Size = new Size(370, 27);
            paymentMethodDetailLastUpdatedTimestampTextbox.TabIndex = 6;
            // 
            // paymentMethodDetailCreatedByTextbox
            // 
            paymentMethodDetailCreatedByTextbox.Enabled = false;
            paymentMethodDetailCreatedByTextbox.Location = new Point(849, 138);
            paymentMethodDetailCreatedByTextbox.Name = "paymentMethodDetailCreatedByTextbox";
            paymentMethodDetailCreatedByTextbox.ReadOnly = true;
            paymentMethodDetailCreatedByTextbox.Size = new Size(370, 27);
            paymentMethodDetailCreatedByTextbox.TabIndex = 3;
            // 
            // paymentMethodDetailLastUpdatedByTextbox
            // 
            paymentMethodDetailLastUpdatedByTextbox.Enabled = false;
            paymentMethodDetailLastUpdatedByTextbox.Location = new Point(849, 218);
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
            // paymentMethodDetailSupplierTypeLabel
            // 
            paymentMethodDetailSupplierTypeLabel.AutoSize = true;
            paymentMethodDetailSupplierTypeLabel.Location = new Point(74, 181);
            paymentMethodDetailSupplierTypeLabel.Name = "paymentMethodDetailSupplierTypeLabel";
            paymentMethodDetailSupplierTypeLabel.Size = new Size(121, 20);
            paymentMethodDetailSupplierTypeLabel.TabIndex = 30;
            paymentMethodDetailSupplierTypeLabel.Text = "Payment Method";
            // 
            // paymentMethodDetailSupplierTypeIdLabel
            // 
            paymentMethodDetailSupplierTypeIdLabel.AutoSize = true;
            paymentMethodDetailSupplierTypeIdLabel.Location = new Point(57, 141);
            paymentMethodDetailSupplierTypeIdLabel.Name = "paymentMethodDetailSupplierTypeIdLabel";
            paymentMethodDetailSupplierTypeIdLabel.Size = new Size(138, 20);
            paymentMethodDetailSupplierTypeIdLabel.TabIndex = 28;
            paymentMethodDetailSupplierTypeIdLabel.Text = "Payment Method Id";
            // 
            // PaymentMethodDetail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1244, 438);
            Controls.Add(paymentMethodDetailUpdateSupplierTypeButton);
            Controls.Add(paymentMethodDetailActiveStatusCheckbox);
            Controls.Add(paymentMethodDetailToggleEditModeButton);
            Controls.Add(paymentMethodDetailSupplierTypeIdTextbox);
            Controls.Add(paymentMethodDetailSupplierTypeTextbox);
            Controls.Add(paymentMethodDetailCreatedTimestampTextbox);
            Controls.Add(paymentMethodDetailLastUpdatedTimestampTextbox);
            Controls.Add(paymentMethodDetailCreatedByTextbox);
            Controls.Add(paymentMethodDetailLastUpdatedByTextbox);
            Controls.Add(paymentMethodDetailLastUpdatedTimestampLabel);
            Controls.Add(paymentMethodDetailLastUpdatedByLabel);
            Controls.Add(paymentMethodDetailCreatedTimestampLabel);
            Controls.Add(paymentMethodDetailCreatedByLabel);
            Controls.Add(paymentMethodDetailSupplierTypeLabel);
            Controls.Add(paymentMethodDetailSupplierTypeIdLabel);
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
        private Button paymentMethodDetailUpdateSupplierTypeButton;
        private CheckBox paymentMethodDetailActiveStatusCheckbox;
        private Button paymentMethodDetailToggleEditModeButton;
        private TextBox paymentMethodDetailSupplierTypeIdTextbox;
        private TextBox paymentMethodDetailSupplierTypeTextbox;
        private TextBox paymentMethodDetailCreatedTimestampTextbox;
        private TextBox paymentMethodDetailLastUpdatedTimestampTextbox;
        private TextBox paymentMethodDetailCreatedByTextbox;
        private TextBox paymentMethodDetailLastUpdatedByTextbox;
        private Label paymentMethodDetailLastUpdatedTimestampLabel;
        private Label paymentMethodDetailLastUpdatedByLabel;
        private Label paymentMethodDetailCreatedTimestampLabel;
        private Label paymentMethodDetailCreatedByLabel;
        private Label paymentMethodDetailSupplierTypeLabel;
        private Label paymentMethodDetailSupplierTypeIdLabel;
    }
}