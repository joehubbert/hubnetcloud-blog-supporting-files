namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    partial class NoteDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteDetail));
            noteDetailTitleLabel = new Label();
            noteDetailNoteIdTextBoxLabel = new Label();
            noteDetailNoteTitleTextBoxLabel = new Label();
            noteDetailNoteTextBoxLabel = new Label();
            noteDetailCreatedByTextBoxLabel = new Label();
            noteDetailCreatedTimestampTextBoxLabel = new Label();
            noteDetailLastUpdatedByTextBoxLabel = new Label();
            noteDetailLastUpdatedTimestampTextBoxLabel = new Label();
            noteDetailLastUpdatedByTextBox = new TextBox();
            noteDetailCreatedByTextBox = new TextBox();
            noteDetailLastUpdatedTimestampTextBox = new TextBox();
            noteDetailCreatedTimestampTextBox = new TextBox();
            noteDetailNoteTextBox = new TextBox();
            noteDetailNoteIdTextBox = new TextBox();
            noteDetailNoteTitleTextBox = new TextBox();
            noteDetailToggleEditModeButton = new Button();
            noteDetailUpdateNoteButton = new Button();
            noteDetailNoteTypeComboBoxLabel = new Label();
            noteDetailNoteTypeComboBox = new ComboBox();
            noteDetailStatusStrip = new StatusStrip();
            noteDetailStatusStripDataSubjectPlaceholder = new ToolStripStatusLabel();
            noteDetailStatusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // noteDetailTitleLabel
            // 
            noteDetailTitleLabel.AutoSize = true;
            noteDetailTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            noteDetailTitleLabel.Location = new Point(13, 9);
            noteDetailTitleLabel.Margin = new Padding(4, 0, 4, 0);
            noteDetailTitleLabel.Name = "noteDetailTitleLabel";
            noteDetailTitleLabel.Size = new Size(303, 32);
            noteDetailTitleLabel.TabIndex = 7;
            noteDetailTitleLabel.Text = "{Note Detail Placeholder}";
            // 
            // noteDetailNoteIdTextBoxLabel
            // 
            noteDetailNoteIdTextBoxLabel.AutoSize = true;
            noteDetailNoteIdTextBoxLabel.Location = new Point(6, 145);
            noteDetailNoteIdTextBoxLabel.Name = "noteDetailNoteIdTextBoxLabel";
            noteDetailNoteIdTextBoxLabel.Size = new Size(223, 20);
            noteDetailNoteIdTextBoxLabel.TabIndex = 8;
            noteDetailNoteIdTextBoxLabel.Text = "{Note Type Note Id Placeholder}";
            noteDetailNoteIdTextBoxLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // noteDetailNoteTitleTextBoxLabel
            // 
            noteDetailNoteTitleTextBoxLabel.AutoSize = true;
            noteDetailNoteTitleTextBoxLabel.Location = new Point(62, 181);
            noteDetailNoteTitleTextBoxLabel.Name = "noteDetailNoteTitleTextBoxLabel";
            noteDetailNoteTitleTextBoxLabel.Size = new Size(167, 20);
            noteDetailNoteTitleTextBoxLabel.TabIndex = 9;
            noteDetailNoteTitleTextBoxLabel.Text = "{Note Title Placeholder}";
            noteDetailNoteTitleTextBoxLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // noteDetailNoteTextBoxLabel
            // 
            noteDetailNoteTextBoxLabel.AutoSize = true;
            noteDetailNoteTextBoxLabel.Location = new Point(177, 258);
            noteDetailNoteTextBoxLabel.Name = "noteDetailNoteTextBoxLabel";
            noteDetailNoteTextBoxLabel.Size = new Size(52, 20);
            noteDetailNoteTextBoxLabel.TabIndex = 10;
            noteDetailNoteTextBoxLabel.Text = " Note*";
            noteDetailNoteTextBoxLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // noteDetailCreatedByTextBoxLabel
            // 
            noteDetailCreatedByTextBoxLabel.AutoSize = true;
            noteDetailCreatedByTextBoxLabel.Location = new Point(891, 141);
            noteDetailCreatedByTextBoxLabel.Name = "noteDetailCreatedByTextBoxLabel";
            noteDetailCreatedByTextBoxLabel.Size = new Size(81, 20);
            noteDetailCreatedByTextBoxLabel.TabIndex = 11;
            noteDetailCreatedByTextBoxLabel.Text = "Created By";
            noteDetailCreatedByTextBoxLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // noteDetailCreatedTimestampTextBoxLabel
            // 
            noteDetailCreatedTimestampTextBoxLabel.AutoSize = true;
            noteDetailCreatedTimestampTextBoxLabel.Location = new Point(803, 181);
            noteDetailCreatedTimestampTextBoxLabel.Name = "noteDetailCreatedTimestampTextBoxLabel";
            noteDetailCreatedTimestampTextBoxLabel.Size = new Size(169, 20);
            noteDetailCreatedTimestampTextBoxLabel.TabIndex = 12;
            noteDetailCreatedTimestampTextBoxLabel.Text = "Created Timestamp UTC";
            noteDetailCreatedTimestampTextBoxLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // noteDetailLastUpdatedByTextBoxLabel
            // 
            noteDetailLastUpdatedByTextBoxLabel.AutoSize = true;
            noteDetailLastUpdatedByTextBoxLabel.Location = new Point(855, 221);
            noteDetailLastUpdatedByTextBoxLabel.Name = "noteDetailLastUpdatedByTextBoxLabel";
            noteDetailLastUpdatedByTextBoxLabel.Size = new Size(117, 20);
            noteDetailLastUpdatedByTextBoxLabel.TabIndex = 13;
            noteDetailLastUpdatedByTextBoxLabel.Text = "Last Updated By";
            noteDetailLastUpdatedByTextBoxLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // noteDetailLastUpdatedTimestampTextBoxLabel
            // 
            noteDetailLastUpdatedTimestampTextBoxLabel.AutoSize = true;
            noteDetailLastUpdatedTimestampTextBoxLabel.Location = new Point(767, 261);
            noteDetailLastUpdatedTimestampTextBoxLabel.Name = "noteDetailLastUpdatedTimestampTextBoxLabel";
            noteDetailLastUpdatedTimestampTextBoxLabel.Size = new Size(205, 20);
            noteDetailLastUpdatedTimestampTextBoxLabel.TabIndex = 14;
            noteDetailLastUpdatedTimestampTextBoxLabel.Text = "Last Updated Timestamp UTC";
            noteDetailLastUpdatedTimestampTextBoxLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // noteDetailLastUpdatedByTextBox
            // 
            noteDetailLastUpdatedByTextBox.Location = new Point(978, 218);
            noteDetailLastUpdatedByTextBox.MaxLength = 50;
            noteDetailLastUpdatedByTextBox.Name = "noteDetailLastUpdatedByTextBox";
            noteDetailLastUpdatedByTextBox.ReadOnly = true;
            noteDetailLastUpdatedByTextBox.Size = new Size(370, 27);
            noteDetailLastUpdatedByTextBox.TabIndex = 6;
            // 
            // noteDetailCreatedByTextBox
            // 
            noteDetailCreatedByTextBox.Location = new Point(978, 138);
            noteDetailCreatedByTextBox.MaxLength = 50;
            noteDetailCreatedByTextBox.Name = "noteDetailCreatedByTextBox";
            noteDetailCreatedByTextBox.ReadOnly = true;
            noteDetailCreatedByTextBox.Size = new Size(370, 27);
            noteDetailCreatedByTextBox.TabIndex = 4;
            // 
            // noteDetailLastUpdatedTimestampTextBox
            // 
            noteDetailLastUpdatedTimestampTextBox.Location = new Point(978, 258);
            noteDetailLastUpdatedTimestampTextBox.MaxLength = 50;
            noteDetailLastUpdatedTimestampTextBox.Name = "noteDetailLastUpdatedTimestampTextBox";
            noteDetailLastUpdatedTimestampTextBox.ReadOnly = true;
            noteDetailLastUpdatedTimestampTextBox.Size = new Size(370, 27);
            noteDetailLastUpdatedTimestampTextBox.TabIndex = 7;
            // 
            // noteDetailCreatedTimestampTextBox
            // 
            noteDetailCreatedTimestampTextBox.Location = new Point(978, 178);
            noteDetailCreatedTimestampTextBox.MaxLength = 50;
            noteDetailCreatedTimestampTextBox.Name = "noteDetailCreatedTimestampTextBox";
            noteDetailCreatedTimestampTextBox.ReadOnly = true;
            noteDetailCreatedTimestampTextBox.Size = new Size(370, 27);
            noteDetailCreatedTimestampTextBox.TabIndex = 5;
            // 
            // noteDetailNoteTextBox
            // 
            noteDetailNoteTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            noteDetailNoteTextBox.Location = new Point(235, 258);
            noteDetailNoteTextBox.MaxLength = 4000;
            noteDetailNoteTextBox.Multiline = true;
            noteDetailNoteTextBox.Name = "noteDetailNoteTextBox";
            noteDetailNoteTextBox.ReadOnly = true;
            noteDetailNoteTextBox.ScrollBars = ScrollBars.Vertical;
            noteDetailNoteTextBox.Size = new Size(524, 273);
            noteDetailNoteTextBox.TabIndex = 3;
            // 
            // noteDetailNoteIdTextBox
            // 
            noteDetailNoteIdTextBox.Location = new Point(235, 138);
            noteDetailNoteIdTextBox.MaxLength = 36;
            noteDetailNoteIdTextBox.Name = "noteDetailNoteIdTextBox";
            noteDetailNoteIdTextBox.ReadOnly = true;
            noteDetailNoteIdTextBox.Size = new Size(524, 27);
            noteDetailNoteIdTextBox.TabIndex = 0;
            // 
            // noteDetailNoteTitleTextBox
            // 
            noteDetailNoteTitleTextBox.Location = new Point(235, 177);
            noteDetailNoteTitleTextBox.MaxLength = 50;
            noteDetailNoteTitleTextBox.Name = "noteDetailNoteTitleTextBox";
            noteDetailNoteTitleTextBox.ReadOnly = true;
            noteDetailNoteTitleTextBox.Size = new Size(524, 27);
            noteDetailNoteTitleTextBox.TabIndex = 1;
            // 
            // noteDetailToggleEditModeButton
            // 
            noteDetailToggleEditModeButton.FlatStyle = FlatStyle.Flat;
            noteDetailToggleEditModeButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            noteDetailToggleEditModeButton.Location = new Point(1300, 13);
            noteDetailToggleEditModeButton.Margin = new Padding(4);
            noteDetailToggleEditModeButton.Name = "noteDetailToggleEditModeButton";
            noteDetailToggleEditModeButton.Size = new Size(108, 92);
            noteDetailToggleEditModeButton.TabIndex = 8;
            noteDetailToggleEditModeButton.Text = "Toggle Edit Mode";
            noteDetailToggleEditModeButton.UseVisualStyleBackColor = true;
            noteDetailToggleEditModeButton.Click += noteDetailToggleEditModeButton_Click;
            // 
            // noteDetailUpdateNoteButton
            // 
            noteDetailUpdateNoteButton.Enabled = false;
            noteDetailUpdateNoteButton.FlatStyle = FlatStyle.Flat;
            noteDetailUpdateNoteButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            noteDetailUpdateNoteButton.Location = new Point(623, 548);
            noteDetailUpdateNoteButton.Margin = new Padding(4);
            noteDetailUpdateNoteButton.Name = "noteDetailUpdateNoteButton";
            noteDetailUpdateNoteButton.Size = new Size(185, 70);
            noteDetailUpdateNoteButton.TabIndex = 9;
            noteDetailUpdateNoteButton.Text = "Update {Note Type Placeholder}";
            noteDetailUpdateNoteButton.UseVisualStyleBackColor = true;
            noteDetailUpdateNoteButton.Click += noteDetailUpdateNoteButton_Click;
            // 
            // noteDetailNoteTypeComboBoxLabel
            // 
            noteDetailNoteTypeComboBoxLabel.AutoSize = true;
            noteDetailNoteTypeComboBoxLabel.Font = new Font("Segoe UI", 11F);
            noteDetailNoteTypeComboBoxLabel.Location = new Point(60, 221);
            noteDetailNoteTypeComboBoxLabel.Name = "noteDetailNoteTypeComboBoxLabel";
            noteDetailNoteTypeComboBoxLabel.Size = new Size(169, 20);
            noteDetailNoteTypeComboBoxLabel.TabIndex = 35;
            noteDetailNoteTypeComboBoxLabel.Text = "{Note Type Placeholder}";
            noteDetailNoteTypeComboBoxLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // noteDetailNoteTypeComboBox
            // 
            noteDetailNoteTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            noteDetailNoteTypeComboBox.Enabled = false;
            noteDetailNoteTypeComboBox.FormattingEnabled = true;
            noteDetailNoteTypeComboBox.Location = new Point(235, 218);
            noteDetailNoteTypeComboBox.MaxLength = 50;
            noteDetailNoteTypeComboBox.Name = "noteDetailNoteTypeComboBox";
            noteDetailNoteTypeComboBox.Size = new Size(524, 28);
            noteDetailNoteTypeComboBox.TabIndex = 2;
            // 
            // noteDetailStatusStrip
            // 
            noteDetailStatusStrip.Items.AddRange(new ToolStripItem[] { noteDetailStatusStripDataSubjectPlaceholder });
            noteDetailStatusStrip.Location = new Point(0, 641);
            noteDetailStatusStrip.Name = "noteDetailStatusStrip";
            noteDetailStatusStrip.Size = new Size(1438, 22);
            noteDetailStatusStrip.TabIndex = 10;
            noteDetailStatusStrip.Text = "Note Detail Status Strip";
            // 
            // noteDetailStatusStripDataSubjectPlaceholder
            // 
            noteDetailStatusStripDataSubjectPlaceholder.DisplayStyle = ToolStripItemDisplayStyle.Text;
            noteDetailStatusStripDataSubjectPlaceholder.Image = (Image)resources.GetObject("noteDetailStatusStripDataSubjectPlaceholder.Image");
            noteDetailStatusStripDataSubjectPlaceholder.ImageTransparentColor = Color.Magenta;
            noteDetailStatusStripDataSubjectPlaceholder.Name = "noteDetailStatusStripDataSubjectPlaceholder";
            noteDetailStatusStripDataSubjectPlaceholder.Size = new Size(146, 17);
            noteDetailStatusStripDataSubjectPlaceholder.Text = "{Data Subject Placeholder}";
            // 
            // NoteDetail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1438, 663);
            Controls.Add(noteDetailStatusStrip);
            Controls.Add(noteDetailNoteTypeComboBoxLabel);
            Controls.Add(noteDetailNoteTypeComboBox);
            Controls.Add(noteDetailUpdateNoteButton);
            Controls.Add(noteDetailToggleEditModeButton);
            Controls.Add(noteDetailNoteTitleTextBox);
            Controls.Add(noteDetailNoteIdTextBox);
            Controls.Add(noteDetailNoteTextBox);
            Controls.Add(noteDetailCreatedTimestampTextBox);
            Controls.Add(noteDetailLastUpdatedTimestampTextBox);
            Controls.Add(noteDetailCreatedByTextBox);
            Controls.Add(noteDetailLastUpdatedByTextBox);
            Controls.Add(noteDetailLastUpdatedTimestampTextBoxLabel);
            Controls.Add(noteDetailLastUpdatedByTextBoxLabel);
            Controls.Add(noteDetailCreatedTimestampTextBoxLabel);
            Controls.Add(noteDetailCreatedByTextBoxLabel);
            Controls.Add(noteDetailNoteTextBoxLabel);
            Controls.Add(noteDetailNoteTitleTextBoxLabel);
            Controls.Add(noteDetailNoteIdTextBoxLabel);
            Controls.Add(noteDetailTitleLabel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "NoteDetail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NoteDetail";
            noteDetailStatusStrip.ResumeLayout(false);
            noteDetailStatusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label noteDetailTitleLabel;
        private Label noteDetailNoteIdTextBoxLabel;
        private Label noteDetailNoteTitleTextBoxLabel;
        private Label noteDetailNoteTextBoxLabel;
        private Label noteDetailCreatedByTextBoxLabel;
        private Label noteDetailCreatedTimestampTextBoxLabel;
        private Label noteDetailLastUpdatedByTextBoxLabel;
        private Label noteDetailLastUpdatedTimestampTextBoxLabel;
        private TextBox noteDetailLastUpdatedByTextBox;
        private TextBox noteDetailCreatedByTextBox;
        private TextBox noteDetailLastUpdatedTimestampTextBox;
        private TextBox noteDetailCreatedTimestampTextBox;
        private TextBox noteDetailNoteTextBox;
        private TextBox noteDetailNoteIdTextBox;
        private TextBox noteDetailNoteTitleTextBox;
        private Button noteDetailToggleEditModeButton;
        private Button noteDetailUpdateNoteButton;
        private Label noteDetailNoteTypeComboBoxLabel;
        private ComboBox noteDetailNoteTypeComboBox;
        private StatusStrip noteDetailStatusStrip;
        private ToolStripStatusLabel noteDetailStatusStripDataSubjectPlaceholder;
    }
}