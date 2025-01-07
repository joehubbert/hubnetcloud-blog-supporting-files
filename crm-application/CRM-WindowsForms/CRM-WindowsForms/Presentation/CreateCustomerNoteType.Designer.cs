namespace CRM_WindowsForms.Presentation
{
    partial class CreateCustomerNoteType
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
            createCustomerNoteTypeTitleLabel = new Label();
            createCustomerNoteTypeCustomerNoteTypeTextbox = new TextBox();
            createCustomerNoteTypeCustomerNoteTypeLabel = new Label();
            createCustomerNoteTypeSubmitButton = new Button();
            createCustomerNoteTypeActiveStatusCheckbox = new CheckBox();
            SuspendLayout();
            // 
            // createCustomerNoteTypeTitleLabel
            // 
            createCustomerNoteTypeTitleLabel.AutoSize = true;
            createCustomerNoteTypeTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createCustomerNoteTypeTitleLabel.Location = new Point(15, 12);
            createCustomerNoteTypeTitleLabel.Margin = new Padding(5, 0, 5, 0);
            createCustomerNoteTypeTitleLabel.Name = "createCustomerNoteTypeTitleLabel";
            createCustomerNoteTypeTitleLabel.Size = new Size(328, 32);
            createCustomerNoteTypeTitleLabel.TabIndex = 7;
            createCustomerNoteTypeTitleLabel.Text = "Create Customer Note Type";
            // 
            // createCustomerNoteTypeCustomerNoteTypeTextbox
            // 
            createCustomerNoteTypeCustomerNoteTypeTextbox.Location = new Point(181, 74);
            createCustomerNoteTypeCustomerNoteTypeTextbox.Margin = new Padding(3, 4, 3, 4);
            createCustomerNoteTypeCustomerNoteTypeTextbox.MaxLength = 50;
            createCustomerNoteTypeCustomerNoteTypeTextbox.Name = "createCustomerNoteTypeCustomerNoteTypeTextbox";
            createCustomerNoteTypeCustomerNoteTypeTextbox.Size = new Size(343, 27);
            createCustomerNoteTypeCustomerNoteTypeTextbox.TabIndex = 0;
            // 
            // createCustomerNoteTypeCustomerNoteTypeLabel
            // 
            createCustomerNoteTypeCustomerNoteTypeLabel.AutoSize = true;
            createCustomerNoteTypeCustomerNoteTypeLabel.Font = new Font("Segoe UI", 11F);
            createCustomerNoteTypeCustomerNoteTypeLabel.Location = new Point(25, 77);
            createCustomerNoteTypeCustomerNoteTypeLabel.Name = "createCustomerNoteTypeCustomerNoteTypeLabel";
            createCustomerNoteTypeCustomerNoteTypeLabel.Size = new Size(144, 20);
            createCustomerNoteTypeCustomerNoteTypeLabel.TabIndex = 19;
            createCustomerNoteTypeCustomerNoteTypeLabel.Text = "Customer Note Type";
            // 
            // createCustomerNoteTypeSubmitButton
            // 
            createCustomerNoteTypeSubmitButton.FlatStyle = FlatStyle.Flat;
            createCustomerNoteTypeSubmitButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createCustomerNoteTypeSubmitButton.Location = new Point(191, 190);
            createCustomerNoteTypeSubmitButton.Margin = new Padding(4);
            createCustomerNoteTypeSubmitButton.Name = "createCustomerNoteTypeSubmitButton";
            createCustomerNoteTypeSubmitButton.Size = new Size(198, 66);
            createCustomerNoteTypeSubmitButton.TabIndex = 2;
            createCustomerNoteTypeSubmitButton.Text = "Submit";
            createCustomerNoteTypeSubmitButton.UseVisualStyleBackColor = true;
            createCustomerNoteTypeSubmitButton.Click += createCustomerNoteTypeSubmitButton_Click;
            // 
            // createCustomerNoteTypeActiveStatusCheckbox
            // 
            createCustomerNoteTypeActiveStatusCheckbox.AutoSize = true;
            createCustomerNoteTypeActiveStatusCheckbox.Checked = true;
            createCustomerNoteTypeActiveStatusCheckbox.CheckState = CheckState.Checked;
            createCustomerNoteTypeActiveStatusCheckbox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createCustomerNoteTypeActiveStatusCheckbox.Location = new Point(193, 146);
            createCustomerNoteTypeActiveStatusCheckbox.Margin = new Padding(5);
            createCustomerNoteTypeActiveStatusCheckbox.Name = "createCustomerNoteTypeActiveStatusCheckbox";
            createCustomerNoteTypeActiveStatusCheckbox.Size = new Size(208, 24);
            createCustomerNoteTypeActiveStatusCheckbox.TabIndex = 1;
            createCustomerNoteTypeActiveStatusCheckbox.Text = "Active Customer Note Type";
            createCustomerNoteTypeActiveStatusCheckbox.UseVisualStyleBackColor = true;
            // 
            // CreateCustomerNoteType
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(559, 266);
            Controls.Add(createCustomerNoteTypeCustomerNoteTypeTextbox);
            Controls.Add(createCustomerNoteTypeCustomerNoteTypeLabel);
            Controls.Add(createCustomerNoteTypeSubmitButton);
            Controls.Add(createCustomerNoteTypeActiveStatusCheckbox);
            Controls.Add(createCustomerNoteTypeTitleLabel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "CreateCustomerNoteType";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - Create Customer Note Type";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label createCustomerNoteTypeTitleLabel;
        private TextBox createCustomerNoteTypeCustomerNoteTypeTextbox;
        private Label createCustomerNoteTypeCustomerNoteTypeLabel;
        private Button createCustomerNoteTypeSubmitButton;
        private CheckBox createCustomerNoteTypeActiveStatusCheckbox;
    }
}