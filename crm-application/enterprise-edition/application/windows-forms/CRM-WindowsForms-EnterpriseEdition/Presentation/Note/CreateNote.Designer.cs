namespace CRM.Presentation.Note
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
            createNoteNoteTitleTextBox = new TextBox();
            createNoteNoteTextBox = new TextBox();
            createNoteNoteTitleTextBoxLabel = new Label();
            createNoteNoteTypeComboBoxLabel = new Label();
            createNoteNoteTextBoxLabel = new Label();
            createNoteSubmitButton = new Button();
            createNoteStatusStrip = new StatusStrip();
            createNoteStatusStripDataSubjectPlaceholder = new ToolStripStatusLabel();
            createNoteStatusStrip.SuspendLayout();
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
            createNoteNoteTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            createNoteNoteTypeComboBox.FormattingEnabled = true;
            createNoteNoteTypeComboBox.Location = new Point(193, 104);
            createNoteNoteTypeComboBox.Name = "createNoteNoteTypeComboBox";
            createNoteNoteTypeComboBox.Size = new Size(558, 28);
            createNoteNoteTypeComboBox.TabIndex = 1;
            // 
            // createNoteNoteTitleTextBox
            // 
            createNoteNoteTitleTextBox.Location = new Point(193, 65);
            createNoteNoteTitleTextBox.MaxLength = 50;
            createNoteNoteTitleTextBox.Name = "createNoteNoteTitleTextBox";
            createNoteNoteTitleTextBox.Size = new Size(558, 27);
            createNoteNoteTitleTextBox.TabIndex = 0;
            // 
            // createNoteNoteTextBox
            // 
            createNoteNoteTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            createNoteNoteTextBox.Location = new Point(193, 147);
            createNoteNoteTextBox.MaxLength = 4000;
            createNoteNoteTextBox.Multiline = true;
            createNoteNoteTextBox.Name = "createNoteNoteTextBox";
            createNoteNoteTextBox.ScrollBars = ScrollBars.Vertical;
            createNoteNoteTextBox.Size = new Size(558, 257);
            createNoteNoteTextBox.TabIndex = 2;
            // 
            // createNoteNoteTitleTextBoxLabel
            // 
            createNoteNoteTitleTextBoxLabel.AutoSize = true;
            createNoteNoteTitleTextBoxLabel.Location = new Point(12, 68);
            createNoteNoteTitleTextBoxLabel.Name = "createNoteNoteTitleTextBoxLabel";
            createNoteNoteTitleTextBoxLabel.Size = new Size(167, 20);
            createNoteNoteTitleTextBoxLabel.TabIndex = 11;
            createNoteNoteTitleTextBoxLabel.Text = "{Note Title Placeholder}";
            createNoteNoteTitleTextBoxLabel.TextAlign = ContentAlignment.TopRight;
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
            // createNoteNoteTextBoxLabel
            // 
            createNoteNoteTextBoxLabel.AutoSize = true;
            createNoteNoteTextBoxLabel.Location = new Point(130, 150);
            createNoteNoteTextBoxLabel.Name = "createNoteNoteTextBoxLabel";
            createNoteNoteTextBoxLabel.Size = new Size(52, 20);
            createNoteNoteTextBoxLabel.TabIndex = 13;
            createNoteNoteTextBoxLabel.Text = " Note*";
            createNoteNoteTextBoxLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // createNoteSubmitButton
            // 
            createNoteSubmitButton.FlatStyle = FlatStyle.Flat;
            createNoteSubmitButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createNoteSubmitButton.Location = new Point(286, 423);
            createNoteSubmitButton.Margin = new Padding(4);
            createNoteSubmitButton.Name = "createNoteSubmitButton";
            createNoteSubmitButton.Size = new Size(198, 66);
            createNoteSubmitButton.TabIndex = 3;
            createNoteSubmitButton.Text = "Submit";
            createNoteSubmitButton.UseVisualStyleBackColor = true;
            createNoteSubmitButton.Click += createNoteSubmitButton_Click;
            // 
            // createNoteStatusStrip
            // 
            createNoteStatusStrip.Items.AddRange(new ToolStripItem[] { createNoteStatusStripDataSubjectPlaceholder });
            createNoteStatusStrip.Location = new Point(0, 510);
            createNoteStatusStrip.Name = "createNoteStatusStrip";
            createNoteStatusStrip.Size = new Size(771, 22);
            createNoteStatusStrip.TabIndex = 4;
            createNoteStatusStrip.Text = "Create Note Status Strip";
            // 
            // createNoteStatusStripDataSubjectPlaceholder
            // 
            createNoteStatusStripDataSubjectPlaceholder.Name = "createNoteStatusStripDataSubjectPlaceholder";
            createNoteStatusStripDataSubjectPlaceholder.Size = new Size(146, 17);
            createNoteStatusStripDataSubjectPlaceholder.Text = "{Data Subject Placeholder}";
            // 
            // CreateNote
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(771, 532);
            Controls.Add(createNoteStatusStrip);
            Controls.Add(createNoteSubmitButton);
            Controls.Add(createNoteNoteTextBoxLabel);
            Controls.Add(createNoteNoteTypeComboBoxLabel);
            Controls.Add(createNoteNoteTitleTextBoxLabel);
            Controls.Add(createNoteNoteTextBox);
            Controls.Add(createNoteNoteTitleTextBox);
            Controls.Add(createNoteNoteTypeComboBox);
            Controls.Add(createNoteTitleLabel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "CreateNote";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CreateNote";
            createNoteStatusStrip.ResumeLayout(false);
            createNoteStatusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label createNoteTitleLabel;
        private ComboBox createNoteNoteTypeComboBox;
        private TextBox createNoteNoteTitleTextBox;
        private TextBox createNoteNoteTextBox;
        private Label createNoteNoteTitleTextBoxLabel;
        private Label createNoteNoteTypeComboBoxLabel;
        private Label createNoteNoteTextBoxLabel;
        private Button createNoteSubmitButton;
        private StatusStrip createNoteStatusStrip;
        private ToolStripStatusLabel createNoteStatusStripDataSubjectPlaceholder;
    }
}