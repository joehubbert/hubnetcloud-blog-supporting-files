namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    partial class CreateNote
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
            createNoteTitleLabel = new Label();
            createNoteNoteTypeComboBox = new ComboBox();
            createNoteNoteTitleTextbox = new TextBox();
            createNoteNoteTextbox = new TextBox();
            createNoteNoteTitleTextboxLabel = new Label();
            createNoteNoteTypeComboBoxLabel = new Label();
            createNoteNoteTextboxLabel = new Label();
            createNoteSubmitButton = new Button();
            SuspendLayout();
            // 
            // createNoteTitleLabel
            // 
            createNoteTitleLabel.AutoSize = true;
            createNoteTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createNoteTitleLabel.Location = new Point(13, 9);
            createNoteTitleLabel.Margin = new Padding(4, 0, 4, 0);
            createNoteTitleLabel.Name = "createNoteTitleLabel";
            createNoteTitleLabel.Size = new Size(366, 32);
            createNoteTitleLabel.TabIndex = 7;
            createNoteTitleLabel.Text = "{Create Note Title Placeholder}";
            // 
            // createNoteNoteTypeComboBox
            // 
            createNoteNoteTypeComboBox.FormattingEnabled = true;
            createNoteNoteTypeComboBox.Location = new Point(193, 104);
            createNoteNoteTypeComboBox.Name = "createNoteNoteTypeComboBox";
            createNoteNoteTypeComboBox.Size = new Size(558, 28);
            createNoteNoteTypeComboBox.TabIndex = 1;
            // 
            // createNoteNoteTitleTextbox
            // 
            createNoteNoteTitleTextbox.Location = new Point(193, 65);
            createNoteNoteTitleTextbox.MaxLength = 50;
            createNoteNoteTitleTextbox.Name = "createNoteNoteTitleTextbox";
            createNoteNoteTitleTextbox.Size = new Size(558, 27);
            createNoteNoteTitleTextbox.TabIndex = 0;
            // 
            // createNoteNoteTextbox
            // 
            createNoteNoteTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            createNoteNoteTextbox.Location = new Point(193, 147);
            createNoteNoteTextbox.MaxLength = 4000;
            createNoteNoteTextbox.Multiline = true;
            createNoteNoteTextbox.Name = "createNoteNoteTextbox";
            createNoteNoteTextbox.ScrollBars = ScrollBars.Vertical;
            createNoteNoteTextbox.Size = new Size(558, 259);
            createNoteNoteTextbox.TabIndex = 2;
            // 
            // createNoteNoteTitleTextboxLabel
            // 
            createNoteNoteTitleTextboxLabel.AutoSize = true;
            createNoteNoteTitleTextboxLabel.Location = new Point(12, 68);
            createNoteNoteTitleTextboxLabel.Name = "createNoteNoteTitleTextboxLabel";
            createNoteNoteTitleTextboxLabel.Size = new Size(167, 20);
            createNoteNoteTitleTextboxLabel.TabIndex = 11;
            createNoteNoteTitleTextboxLabel.Text = "{Note Title Placeholder}";
            createNoteNoteTitleTextboxLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // createNoteNoteTypeComboBoxLabel
            // 
            createNoteNoteTypeComboBoxLabel.AutoSize = true;
            createNoteNoteTypeComboBoxLabel.Location = new Point(12, 107);
            createNoteNoteTypeComboBoxLabel.Name = "createNoteNoteTypeComboBoxLabel";
            createNoteNoteTypeComboBoxLabel.Size = new Size(169, 20);
            createNoteNoteTypeComboBoxLabel.TabIndex = 12;
            createNoteNoteTypeComboBoxLabel.Text = "{Note Type Placeholder}";
            createNoteNoteTypeComboBoxLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // createNoteNoteTextboxLabel
            // 
            createNoteNoteTextboxLabel.AutoSize = true;
            createNoteNoteTextboxLabel.Location = new Point(130, 150);
            createNoteNoteTextboxLabel.Name = "createNoteNoteTextboxLabel";
            createNoteNoteTextboxLabel.Size = new Size(52, 20);
            createNoteNoteTextboxLabel.TabIndex = 13;
            createNoteNoteTextboxLabel.Text = " Note*";
            createNoteNoteTextboxLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // createNoteSubmitButton
            // 
            createNoteSubmitButton.FlatStyle = FlatStyle.Flat;
            createNoteSubmitButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createNoteSubmitButton.Location = new Point(277, 420);
            createNoteSubmitButton.Margin = new Padding(4);
            createNoteSubmitButton.Name = "createNoteSubmitButton";
            createNoteSubmitButton.Size = new Size(198, 66);
            createNoteSubmitButton.TabIndex = 3;
            createNoteSubmitButton.Text = "Submit";
            createNoteSubmitButton.UseVisualStyleBackColor = true;
            createNoteSubmitButton.Click += createNoteSubmitButton_Click;
            // 
            // CreateNote
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(771, 499);
            Controls.Add(createNoteSubmitButton);
            Controls.Add(createNoteNoteTextboxLabel);
            Controls.Add(createNoteNoteTypeComboBoxLabel);
            Controls.Add(createNoteNoteTitleTextboxLabel);
            Controls.Add(createNoteNoteTextbox);
            Controls.Add(createNoteNoteTitleTextbox);
            Controls.Add(createNoteNoteTypeComboBox);
            Controls.Add(createNoteTitleLabel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "CreateNote";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CreateNote";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label createNoteTitleLabel;
        private ComboBox createNoteNoteTypeComboBox;
        private TextBox createNoteNoteTitleTextbox;
        private TextBox createNoteNoteTextbox;
        private Label createNoteNoteTitleTextboxLabel;
        private Label createNoteNoteTypeComboBoxLabel;
        private Label createNoteNoteTextboxLabel;
        private Button createNoteSubmitButton;
    }
}