namespace CRM_WindowsForms.Presentation
{
    partial class CreateCustomerType
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
            createCustomerTypeTitleLabel = new Label();
            createCustomerTypeCustomerTypeTextbox = new TextBox();
            createCustomerTypeCustomerTypeLabel = new Label();
            createCustomerTypeSubmitButton = new Button();
            createCustomerTypeActiveStatusCheckbox = new CheckBox();
            SuspendLayout();
            // 
            // createCustomerTypeTitleLabel
            // 
            createCustomerTypeTitleLabel.AutoSize = true;
            createCustomerTypeTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createCustomerTypeTitleLabel.Location = new Point(15, 12);
            createCustomerTypeTitleLabel.Margin = new Padding(5, 0, 5, 0);
            createCustomerTypeTitleLabel.Name = "createCustomerTypeTitleLabel";
            createCustomerTypeTitleLabel.Size = new Size(265, 32);
            createCustomerTypeTitleLabel.TabIndex = 7;
            createCustomerTypeTitleLabel.Text = "Create Customer Type";
            // 
            // createCustomerTypeCustomerTypeTextbox
            // 
            createCustomerTypeCustomerTypeTextbox.Location = new Point(144, 70);
            createCustomerTypeCustomerTypeTextbox.Margin = new Padding(3, 4, 3, 4);
            createCustomerTypeCustomerTypeTextbox.MaxLength = 50;
            createCustomerTypeCustomerTypeTextbox.Name = "createCustomerTypeCustomerTypeTextbox";
            createCustomerTypeCustomerTypeTextbox.Size = new Size(284, 27);
            createCustomerTypeCustomerTypeTextbox.TabIndex = 20;
            // 
            // createCustomerTypeCustomerTypeLabel
            // 
            createCustomerTypeCustomerTypeLabel.AutoSize = true;
            createCustomerTypeCustomerTypeLabel.Font = new Font("Segoe UI", 11F);
            createCustomerTypeCustomerTypeLabel.Location = new Point(25, 77);
            createCustomerTypeCustomerTypeLabel.Name = "createCustomerTypeCustomerTypeLabel";
            createCustomerTypeCustomerTypeLabel.Size = new Size(107, 20);
            createCustomerTypeCustomerTypeLabel.TabIndex = 19;
            createCustomerTypeCustomerTypeLabel.Text = "Customer Type";
            // 
            // createCustomerTypeSubmitButton
            // 
            createCustomerTypeSubmitButton.FlatStyle = FlatStyle.Flat;
            createCustomerTypeSubmitButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createCustomerTypeSubmitButton.Location = new Point(131, 199);
            createCustomerTypeSubmitButton.Margin = new Padding(4);
            createCustomerTypeSubmitButton.Name = "createCustomerTypeSubmitButton";
            createCustomerTypeSubmitButton.Size = new Size(198, 66);
            createCustomerTypeSubmitButton.TabIndex = 18;
            createCustomerTypeSubmitButton.Text = "Submit";
            createCustomerTypeSubmitButton.UseVisualStyleBackColor = true;
            // 
            // createCustomerTypeActiveStatusCheckbox
            // 
            createCustomerTypeActiveStatusCheckbox.AutoSize = true;
            createCustomerTypeActiveStatusCheckbox.Checked = true;
            createCustomerTypeActiveStatusCheckbox.CheckState = CheckState.Checked;
            createCustomerTypeActiveStatusCheckbox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createCustomerTypeActiveStatusCheckbox.Location = new Point(144, 151);
            createCustomerTypeActiveStatusCheckbox.Margin = new Padding(5);
            createCustomerTypeActiveStatusCheckbox.Name = "createCustomerTypeActiveStatusCheckbox";
            createCustomerTypeActiveStatusCheckbox.Size = new Size(171, 24);
            createCustomerTypeActiveStatusCheckbox.TabIndex = 17;
            createCustomerTypeActiveStatusCheckbox.Text = "Active Customer Type";
            createCustomerTypeActiveStatusCheckbox.UseVisualStyleBackColor = true;
            // 
            // CreateCustomerType
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(467, 279);
            Controls.Add(createCustomerTypeCustomerTypeTextbox);
            Controls.Add(createCustomerTypeCustomerTypeLabel);
            Controls.Add(createCustomerTypeSubmitButton);
            Controls.Add(createCustomerTypeActiveStatusCheckbox);
            Controls.Add(createCustomerTypeTitleLabel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "CreateCustomerType";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - Create Customer Type";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label createCustomerTypeTitleLabel;
        private TextBox createCustomerTypeCustomerTypeTextbox;
        private Label createCustomerTypeCustomerTypeLabel;
        private Button createCustomerTypeSubmitButton;
        private CheckBox createCustomerTypeActiveStatusCheckbox;
    }
}