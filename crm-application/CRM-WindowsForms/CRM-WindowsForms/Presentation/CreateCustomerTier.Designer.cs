namespace CRM_WindowsForms.Presentation
{
    partial class CreateCustomerTier
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
            createCustomerTierTitleLabel = new Label();
            createCustomerTierCustomerTierCodeLabel = new Label();
            createCustomerTierCustomerTierCodeTextbox = new TextBox();
            createCustomerTierActiveStatusCheckbox = new CheckBox();
            createCustomerTierSubmitButton = new Button();
            createCustomerTierCustomerTierDescriptionLabel = new Label();
            createCustomerTierCustomerTierDescriptionTextbox = new TextBox();
            SuspendLayout();
            // 
            // createCustomerTierTitleLabel
            // 
            createCustomerTierTitleLabel.AutoSize = true;
            createCustomerTierTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createCustomerTierTitleLabel.Location = new Point(15, 12);
            createCustomerTierTitleLabel.Margin = new Padding(5, 0, 5, 0);
            createCustomerTierTitleLabel.Name = "createCustomerTierTitleLabel";
            createCustomerTierTitleLabel.Size = new Size(255, 32);
            createCustomerTierTitleLabel.TabIndex = 6;
            createCustomerTierTitleLabel.Text = "Create Customer Tier";
            // 
            // createCustomerTierCustomerTierCodeLabel
            // 
            createCustomerTierCustomerTierCodeLabel.AutoSize = true;
            createCustomerTierCustomerTierCodeLabel.Font = new Font("Segoe UI", 11F);
            createCustomerTierCustomerTierCodeLabel.Location = new Point(75, 74);
            createCustomerTierCustomerTierCodeLabel.Name = "createCustomerTierCustomerTierCodeLabel";
            createCustomerTierCustomerTierCodeLabel.Size = new Size(140, 20);
            createCustomerTierCustomerTierCodeLabel.TabIndex = 7;
            createCustomerTierCustomerTierCodeLabel.Text = "Customer Tier Code";
            // 
            // createCustomerTierCustomerTierCodeTextbox
            // 
            createCustomerTierCustomerTierCodeTextbox.Location = new Point(236, 71);
            createCustomerTierCustomerTierCodeTextbox.Margin = new Padding(3, 4, 3, 4);
            createCustomerTierCustomerTierCodeTextbox.MaxLength = 1;
            createCustomerTierCustomerTierCodeTextbox.Name = "createCustomerTierCustomerTierCodeTextbox";
            createCustomerTierCustomerTierCodeTextbox.Size = new Size(34, 27);
            createCustomerTierCustomerTierCodeTextbox.TabIndex = 0;
            // 
            // createCustomerTierActiveStatusCheckbox
            // 
            createCustomerTierActiveStatusCheckbox.AutoSize = true;
            createCustomerTierActiveStatusCheckbox.Checked = true;
            createCustomerTierActiveStatusCheckbox.CheckState = CheckState.Checked;
            createCustomerTierActiveStatusCheckbox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createCustomerTierActiveStatusCheckbox.Location = new Point(182, 176);
            createCustomerTierActiveStatusCheckbox.Margin = new Padding(5);
            createCustomerTierActiveStatusCheckbox.Name = "createCustomerTierActiveStatusCheckbox";
            createCustomerTierActiveStatusCheckbox.Size = new Size(165, 24);
            createCustomerTierActiveStatusCheckbox.TabIndex = 2;
            createCustomerTierActiveStatusCheckbox.Text = "Active Customer Tier";
            createCustomerTierActiveStatusCheckbox.UseVisualStyleBackColor = true;
            // 
            // createCustomerTierSubmitButton
            // 
            createCustomerTierSubmitButton.FlatStyle = FlatStyle.Flat;
            createCustomerTierSubmitButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createCustomerTierSubmitButton.Location = new Point(173, 223);
            createCustomerTierSubmitButton.Margin = new Padding(4);
            createCustomerTierSubmitButton.Name = "createCustomerTierSubmitButton";
            createCustomerTierSubmitButton.Size = new Size(198, 66);
            createCustomerTierSubmitButton.TabIndex = 3;
            createCustomerTierSubmitButton.Text = "Submit";
            createCustomerTierSubmitButton.UseVisualStyleBackColor = true;
            createCustomerTierSubmitButton.Click += createCustomerTierSubmitButton_Click;
            // 
            // createCustomerTierCustomerTierDescriptionLabel
            // 
            createCustomerTierCustomerTierDescriptionLabel.AutoSize = true;
            createCustomerTierCustomerTierDescriptionLabel.Font = new Font("Segoe UI", 11F);
            createCustomerTierCustomerTierDescriptionLabel.Location = new Point(34, 109);
            createCustomerTierCustomerTierDescriptionLabel.Name = "createCustomerTierCustomerTierDescriptionLabel";
            createCustomerTierCustomerTierDescriptionLabel.Size = new Size(181, 20);
            createCustomerTierCustomerTierDescriptionLabel.TabIndex = 13;
            createCustomerTierCustomerTierDescriptionLabel.Text = "Customer Tier Description";
            // 
            // createCustomerTierCustomerTierDescriptionTextbox
            // 
            createCustomerTierCustomerTierDescriptionTextbox.Location = new Point(236, 106);
            createCustomerTierCustomerTierDescriptionTextbox.Margin = new Padding(3, 4, 3, 4);
            createCustomerTierCustomerTierDescriptionTextbox.MaxLength = 50;
            createCustomerTierCustomerTierDescriptionTextbox.Name = "createCustomerTierCustomerTierDescriptionTextbox";
            createCustomerTierCustomerTierDescriptionTextbox.Size = new Size(284, 27);
            createCustomerTierCustomerTierDescriptionTextbox.TabIndex = 1;
            // 
            // CreateCustomerTier
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(543, 296);
            Controls.Add(createCustomerTierCustomerTierDescriptionTextbox);
            Controls.Add(createCustomerTierCustomerTierDescriptionLabel);
            Controls.Add(createCustomerTierSubmitButton);
            Controls.Add(createCustomerTierActiveStatusCheckbox);
            Controls.Add(createCustomerTierCustomerTierCodeTextbox);
            Controls.Add(createCustomerTierCustomerTierCodeLabel);
            Controls.Add(createCustomerTierTitleLabel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "CreateCustomerTier";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - Create Customer Tier";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label createCustomerTierTitleLabel;
        private Label createCustomerTierCustomerTierCodeLabel;
        private TextBox createCustomerTierCustomerTierCodeTextbox;
        private CheckBox createCustomerTierActiveStatusCheckbox;
        private Button createCustomerTierSubmitButton;
        private Label createCustomerTierCustomerTierDescriptionLabel;
        private TextBox createCustomerTierCustomerTierDescriptionTextbox;
    }
}