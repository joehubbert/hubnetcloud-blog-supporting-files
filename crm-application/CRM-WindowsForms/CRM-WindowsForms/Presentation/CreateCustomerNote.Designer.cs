namespace CRM_WindowsForms.Presentation
{
    partial class CreateCustomerNote
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
            createCustomerNoteTitleLabel = new Label();
            createCustomerNoteCustomerNoteTypeComboBox = new ComboBox();
            createCustomerNoteCustomerNoteTitleTextbox = new TextBox();
            createCustomerNoteCustomerNoteTextbox = new TextBox();
            createCustomerNoteCustomerNoteTitleLabel = new Label();
            createCustomerNoteCustomerNoteTypeLabel = new Label();
            createCustomerNoteCustomerNoteLabel = new Label();
            createCustomerSubmitButton = new Button();
            SuspendLayout();
            // 
            // createCustomerNoteTitleLabel
            // 
            createCustomerNoteTitleLabel.AutoSize = true;
            createCustomerNoteTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createCustomerNoteTitleLabel.Location = new Point(13, 9);
            createCustomerNoteTitleLabel.Margin = new Padding(4, 0, 4, 0);
            createCustomerNoteTitleLabel.Name = "createCustomerNoteTitleLabel";
            createCustomerNoteTitleLabel.Size = new Size(267, 32);
            createCustomerNoteTitleLabel.TabIndex = 7;
            createCustomerNoteTitleLabel.Text = "Create Customer Note";
            // 
            // createCustomerNoteCustomerNoteTypeComboBox
            // 
            createCustomerNoteCustomerNoteTypeComboBox.FormattingEnabled = true;
            createCustomerNoteCustomerNoteTypeComboBox.Location = new Point(188, 104);
            createCustomerNoteCustomerNoteTypeComboBox.Name = "createCustomerNoteCustomerNoteTypeComboBox";
            createCustomerNoteCustomerNoteTypeComboBox.Size = new Size(524, 28);
            createCustomerNoteCustomerNoteTypeComboBox.TabIndex = 1;
            // 
            // createCustomerNoteCustomerNoteTitleTextbox
            // 
            createCustomerNoteCustomerNoteTitleTextbox.Location = new Point(188, 65);
            createCustomerNoteCustomerNoteTitleTextbox.MaxLength = 50;
            createCustomerNoteCustomerNoteTitleTextbox.Name = "createCustomerNoteCustomerNoteTitleTextbox";
            createCustomerNoteCustomerNoteTitleTextbox.Size = new Size(524, 27);
            createCustomerNoteCustomerNoteTitleTextbox.TabIndex = 0;
            // 
            // createCustomerNoteCustomerNoteTextbox
            // 
            createCustomerNoteCustomerNoteTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            createCustomerNoteCustomerNoteTextbox.Location = new Point(188, 147);
            createCustomerNoteCustomerNoteTextbox.MaxLength = 4000;
            createCustomerNoteCustomerNoteTextbox.Multiline = true;
            createCustomerNoteCustomerNoteTextbox.Name = "createCustomerNoteCustomerNoteTextbox";
            createCustomerNoteCustomerNoteTextbox.ScrollBars = ScrollBars.Vertical;
            createCustomerNoteCustomerNoteTextbox.Size = new Size(524, 259);
            createCustomerNoteCustomerNoteTextbox.TabIndex = 2;
            // 
            // createCustomerNoteCustomerNoteTitleLabel
            // 
            createCustomerNoteCustomerNoteTitleLabel.AutoSize = true;
            createCustomerNoteCustomerNoteTitleLabel.Location = new Point(34, 68);
            createCustomerNoteCustomerNoteTitleLabel.Name = "createCustomerNoteCustomerNoteTitleLabel";
            createCustomerNoteCustomerNoteTitleLabel.Size = new Size(148, 20);
            createCustomerNoteCustomerNoteTitleLabel.TabIndex = 11;
            createCustomerNoteCustomerNoteTitleLabel.Text = "Customer Note Title*";
            // 
            // createCustomerNoteCustomerNoteTypeLabel
            // 
            createCustomerNoteCustomerNoteTypeLabel.AutoSize = true;
            createCustomerNoteCustomerNoteTypeLabel.Location = new Point(38, 107);
            createCustomerNoteCustomerNoteTypeLabel.Name = "createCustomerNoteCustomerNoteTypeLabel";
            createCustomerNoteCustomerNoteTypeLabel.Size = new Size(144, 20);
            createCustomerNoteCustomerNoteTypeLabel.TabIndex = 12;
            createCustomerNoteCustomerNoteTypeLabel.Text = "Customer Note Type";
            // 
            // createCustomerNoteCustomerNoteLabel
            // 
            createCustomerNoteCustomerNoteLabel.AutoSize = true;
            createCustomerNoteCustomerNoteLabel.Location = new Point(67, 150);
            createCustomerNoteCustomerNoteLabel.Name = "createCustomerNoteCustomerNoteLabel";
            createCustomerNoteCustomerNoteLabel.Size = new Size(115, 20);
            createCustomerNoteCustomerNoteLabel.TabIndex = 13;
            createCustomerNoteCustomerNoteLabel.Text = "Customer Note*";
            // 
            // createCustomerSubmitButton
            // 
            createCustomerSubmitButton.FlatStyle = FlatStyle.Flat;
            createCustomerSubmitButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createCustomerSubmitButton.Location = new Point(274, 420);
            createCustomerSubmitButton.Margin = new Padding(4);
            createCustomerSubmitButton.Name = "createCustomerSubmitButton";
            createCustomerSubmitButton.Size = new Size(198, 66);
            createCustomerSubmitButton.TabIndex = 3;
            createCustomerSubmitButton.Text = "Submit";
            createCustomerSubmitButton.UseVisualStyleBackColor = true;
            createCustomerSubmitButton.Click += createCustomerSubmitButton_Click;
            // 
            // CreateCustomerNote
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGreen;
            ClientSize = new Size(737, 499);
            Controls.Add(createCustomerSubmitButton);
            Controls.Add(createCustomerNoteCustomerNoteLabel);
            Controls.Add(createCustomerNoteCustomerNoteTypeLabel);
            Controls.Add(createCustomerNoteCustomerNoteTitleLabel);
            Controls.Add(createCustomerNoteCustomerNoteTextbox);
            Controls.Add(createCustomerNoteCustomerNoteTitleTextbox);
            Controls.Add(createCustomerNoteCustomerNoteTypeComboBox);
            Controls.Add(createCustomerNoteTitleLabel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "CreateCustomerNote";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - Create Customer Note";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label createCustomerNoteTitleLabel;
        private ComboBox createCustomerNoteCustomerNoteTypeComboBox;
        private TextBox createCustomerNoteCustomerNoteTitleTextbox;
        private TextBox createCustomerNoteCustomerNoteTextbox;
        private Label createCustomerNoteCustomerNoteTitleLabel;
        private Label createCustomerNoteCustomerNoteTypeLabel;
        private Label createCustomerNoteCustomerNoteLabel;
        private Button createCustomerSubmitButton;
    }
}