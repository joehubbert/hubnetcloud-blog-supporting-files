namespace CRM_WindowsForms.Presentation
{
    partial class CreateMetadataAdvanced
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
            createMetadataAdvancedTitleLabel = new Label();
            createMetadataAdvancedMetadataTypeTextbox = new TextBox();
            createMetadataAdvancedMetadataTypeTextboxLabel = new Label();
            createMetadataAdvancedSubmitButton = new Button();
            createMetadataAdvancedActiveStatusCheckbox = new CheckBox();
            createMetadataAdvancedDataParentSubjectComboBoxLabel = new Label();
            createMetadataAdvancedDataParentSubjectComboBox = new ComboBox();
            SuspendLayout();
            // 
            // createMetadataAdvancedTitleLabel
            // 
            createMetadataAdvancedTitleLabel.AutoSize = true;
            createMetadataAdvancedTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createMetadataAdvancedTitleLabel.Location = new Point(14, 9);
            createMetadataAdvancedTitleLabel.Margin = new Padding(5, 0, 5, 0);
            createMetadataAdvancedTitleLabel.Name = "createMetadataAdvancedTitleLabel";
            createMetadataAdvancedTitleLabel.Size = new Size(342, 32);
            createMetadataAdvancedTitleLabel.TabIndex = 8;
            createMetadataAdvancedTitleLabel.Text = "{Metadata Type Placeholder}";
            // 
            // createMetadataAdvancedMetadataTypeTextbox
            // 
            createMetadataAdvancedMetadataTypeTextbox.Location = new Point(237, 97);
            createMetadataAdvancedMetadataTypeTextbox.Margin = new Padding(3, 4, 3, 4);
            createMetadataAdvancedMetadataTypeTextbox.MaxLength = 50;
            createMetadataAdvancedMetadataTypeTextbox.Name = "createMetadataAdvancedMetadataTypeTextbox";
            createMetadataAdvancedMetadataTypeTextbox.Size = new Size(272, 27);
            createMetadataAdvancedMetadataTypeTextbox.TabIndex = 20;
            // 
            // createMetadataAdvancedMetadataTypeTextboxLabel
            // 
            createMetadataAdvancedMetadataTypeTextboxLabel.Font = new Font("Segoe UI", 11F);
            createMetadataAdvancedMetadataTypeTextboxLabel.Location = new Point(14, 104);
            createMetadataAdvancedMetadataTypeTextboxLabel.Name = "createMetadataAdvancedMetadataTypeTextboxLabel";
            createMetadataAdvancedMetadataTypeTextboxLabel.Size = new Size(210, 20);
            createMetadataAdvancedMetadataTypeTextboxLabel.TabIndex = 23;
            createMetadataAdvancedMetadataTypeTextboxLabel.Text = "{Metadata Type Placeholder}";
            createMetadataAdvancedMetadataTypeTextboxLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // createMetadataAdvancedSubmitButton
            // 
            createMetadataAdvancedSubmitButton.FlatStyle = FlatStyle.Flat;
            createMetadataAdvancedSubmitButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createMetadataAdvancedSubmitButton.Location = new Point(166, 205);
            createMetadataAdvancedSubmitButton.Margin = new Padding(4);
            createMetadataAdvancedSubmitButton.Name = "createMetadataAdvancedSubmitButton";
            createMetadataAdvancedSubmitButton.Size = new Size(198, 66);
            createMetadataAdvancedSubmitButton.TabIndex = 22;
            createMetadataAdvancedSubmitButton.Text = "Submit";
            createMetadataAdvancedSubmitButton.UseVisualStyleBackColor = true;
            createMetadataAdvancedSubmitButton.Click += createMetadataAdvancedSubmitButton_Click;
            // 
            // createMetadataAdvancedActiveStatusCheckbox
            // 
            createMetadataAdvancedActiveStatusCheckbox.Checked = true;
            createMetadataAdvancedActiveStatusCheckbox.CheckState = CheckState.Checked;
            createMetadataAdvancedActiveStatusCheckbox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createMetadataAdvancedActiveStatusCheckbox.Location = new Point(136, 157);
            createMetadataAdvancedActiveStatusCheckbox.Margin = new Padding(5);
            createMetadataAdvancedActiveStatusCheckbox.Name = "createMetadataAdvancedActiveStatusCheckbox";
            createMetadataAdvancedActiveStatusCheckbox.Size = new Size(265, 24);
            createMetadataAdvancedActiveStatusCheckbox.TabIndex = 21;
            createMetadataAdvancedActiveStatusCheckbox.Text = "Active {Metadata Type Placeholder}";
            createMetadataAdvancedActiveStatusCheckbox.UseVisualStyleBackColor = true;
            // 
            // createMetadataAdvancedDataParentSubjectComboBoxLabel
            // 
            createMetadataAdvancedDataParentSubjectComboBoxLabel.Font = new Font("Segoe UI", 11F);
            createMetadataAdvancedDataParentSubjectComboBoxLabel.Location = new Point(14, 60);
            createMetadataAdvancedDataParentSubjectComboBoxLabel.Name = "createMetadataAdvancedDataParentSubjectComboBoxLabel";
            createMetadataAdvancedDataParentSubjectComboBoxLabel.Size = new Size(210, 20);
            createMetadataAdvancedDataParentSubjectComboBoxLabel.TabIndex = 24;
            createMetadataAdvancedDataParentSubjectComboBoxLabel.Text = "{Metadata Parent Placeholder}";
            createMetadataAdvancedDataParentSubjectComboBoxLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // createMetadataAdvancedDataParentSubjectComboBox
            // 
            createMetadataAdvancedDataParentSubjectComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            createMetadataAdvancedDataParentSubjectComboBox.FormattingEnabled = true;
            createMetadataAdvancedDataParentSubjectComboBox.Location = new Point(237, 57);
            createMetadataAdvancedDataParentSubjectComboBox.Name = "createMetadataAdvancedDataParentSubjectComboBox";
            createMetadataAdvancedDataParentSubjectComboBox.Size = new Size(272, 28);
            createMetadataAdvancedDataParentSubjectComboBox.TabIndex = 25;
            // 
            // CreateMetadataAdvanced
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(537, 298);
            Controls.Add(createMetadataAdvancedDataParentSubjectComboBox);
            Controls.Add(createMetadataAdvancedDataParentSubjectComboBoxLabel);
            Controls.Add(createMetadataAdvancedMetadataTypeTextbox);
            Controls.Add(createMetadataAdvancedMetadataTypeTextboxLabel);
            Controls.Add(createMetadataAdvancedSubmitButton);
            Controls.Add(createMetadataAdvancedActiveStatusCheckbox);
            Controls.Add(createMetadataAdvancedTitleLabel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "CreateMetadataAdvanced";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CreateMetadataAdvanced";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label createMetadataAdvancedTitleLabel;
        private TextBox createMetadataAdvancedMetadataTypeTextbox;
        private Label createMetadataAdvancedMetadataTypeTextboxLabel;
        private Button createMetadataAdvancedSubmitButton;
        private CheckBox createMetadataAdvancedActiveStatusCheckbox;
        private Label createMetadataAdvancedDataParentSubjectComboBoxLabel;
        private ComboBox createMetadataAdvancedDataParentSubjectComboBox;
    }
}