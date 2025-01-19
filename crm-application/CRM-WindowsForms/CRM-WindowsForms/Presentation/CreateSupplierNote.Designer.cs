namespace CRM_WindowsForms.Presentation
{
    partial class CreateSupplierNote
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
            createSupplierNoteTitleLabel = new Label();
            createSupplierNoteSupplierNoteTypeComboBox = new ComboBox();
            createSupplierNoteSupplierNoteTitleTextbox = new TextBox();
            createSupplierNoteSupplierNoteTextbox = new TextBox();
            createSupplierNoteSupplierNoteTitleLabel = new Label();
            createSupplierNoteSupplierNoteTypeLabel = new Label();
            createSupplierNoteSupplierNoteLabel = new Label();
            createSupplierSubmitButton = new Button();
            SuspendLayout();
            // 
            // createSupplierNoteTitleLabel
            // 
            createSupplierNoteTitleLabel.AutoSize = true;
            createSupplierNoteTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createSupplierNoteTitleLabel.Location = new Point(13, 9);
            createSupplierNoteTitleLabel.Margin = new Padding(4, 0, 4, 0);
            createSupplierNoteTitleLabel.Name = "createSupplierNoteTitleLabel";
            createSupplierNoteTitleLabel.Size = new Size(252, 32);
            createSupplierNoteTitleLabel.TabIndex = 7;
            createSupplierNoteTitleLabel.Text = "Create Supplier Note";
            // 
            // createSupplierNoteSupplierNoteTypeComboBox
            // 
            createSupplierNoteSupplierNoteTypeComboBox.FormattingEnabled = true;
            createSupplierNoteSupplierNoteTypeComboBox.Location = new Point(188, 104);
            createSupplierNoteSupplierNoteTypeComboBox.Name = "createSupplierNoteSupplierNoteTypeComboBox";
            createSupplierNoteSupplierNoteTypeComboBox.Size = new Size(524, 28);
            createSupplierNoteSupplierNoteTypeComboBox.TabIndex = 8;
            // 
            // createSupplierNoteSupplierNoteTitleTextbox
            // 
            createSupplierNoteSupplierNoteTitleTextbox.Location = new Point(188, 65);
            createSupplierNoteSupplierNoteTitleTextbox.MaxLength = 50;
            createSupplierNoteSupplierNoteTitleTextbox.Name = "createSupplierNoteSupplierNoteTitleTextbox";
            createSupplierNoteSupplierNoteTitleTextbox.Size = new Size(524, 27);
            createSupplierNoteSupplierNoteTitleTextbox.TabIndex = 9;
            // 
            // createSupplierNoteSupplierNoteTextbox
            // 
            createSupplierNoteSupplierNoteTextbox.Location = new Point(188, 147);
            createSupplierNoteSupplierNoteTextbox.MaxLength = 1073741823;
            createSupplierNoteSupplierNoteTextbox.Multiline = true;
            createSupplierNoteSupplierNoteTextbox.Name = "createSupplierNoteSupplierNoteTextbox";
            createSupplierNoteSupplierNoteTextbox.Size = new Size(524, 259);
            createSupplierNoteSupplierNoteTextbox.TabIndex = 10;
            // 
            // createSupplierNoteSupplierNoteTitleLabel
            // 
            createSupplierNoteSupplierNoteTitleLabel.AutoSize = true;
            createSupplierNoteSupplierNoteTitleLabel.Location = new Point(40, 68);
            createSupplierNoteSupplierNoteTitleLabel.Name = "createSupplierNoteSupplierNoteTitleLabel";
            createSupplierNoteSupplierNoteTitleLabel.Size = new Size(134, 20);
            createSupplierNoteSupplierNoteTitleLabel.TabIndex = 11;
            createSupplierNoteSupplierNoteTitleLabel.Text = "Supplier Note Title";
            // 
            // createSupplierNoteSupplierNoteTypeLabel
            // 
            createSupplierNoteSupplierNoteTypeLabel.AutoSize = true;
            createSupplierNoteSupplierNoteTypeLabel.Location = new Point(40, 107);
            createSupplierNoteSupplierNoteTypeLabel.Name = "createSupplierNoteSupplierNoteTypeLabel";
            createSupplierNoteSupplierNoteTypeLabel.Size = new Size(136, 20);
            createSupplierNoteSupplierNoteTypeLabel.TabIndex = 12;
            createSupplierNoteSupplierNoteTypeLabel.Text = "Supplier Note Type";
            // 
            // createSupplierNoteSupplierNoteLabel
            // 
            createSupplierNoteSupplierNoteLabel.AutoSize = true;
            createSupplierNoteSupplierNoteLabel.Location = new Point(73, 150);
            createSupplierNoteSupplierNoteLabel.Name = "createSupplierNoteSupplierNoteLabel";
            createSupplierNoteSupplierNoteLabel.Size = new Size(101, 20);
            createSupplierNoteSupplierNoteLabel.TabIndex = 13;
            createSupplierNoteSupplierNoteLabel.Text = "Supplier Note";
            // 
            // createSupplierSubmitButton
            // 
            createSupplierSubmitButton.FlatStyle = FlatStyle.Flat;
            createSupplierSubmitButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createSupplierSubmitButton.Location = new Point(274, 420);
            createSupplierSubmitButton.Margin = new Padding(4);
            createSupplierSubmitButton.Name = "createSupplierSubmitButton";
            createSupplierSubmitButton.Size = new Size(198, 66);
            createSupplierSubmitButton.TabIndex = 51;
            createSupplierSubmitButton.Text = "Submit";
            createSupplierSubmitButton.UseVisualStyleBackColor = true;
            createSupplierSubmitButton.Click += createSupplierSubmitButton_Click;
            // 
            // CreateSupplierNote
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumAquamarine;
            ClientSize = new Size(737, 499);
            Controls.Add(createSupplierSubmitButton);
            Controls.Add(createSupplierNoteSupplierNoteLabel);
            Controls.Add(createSupplierNoteSupplierNoteTypeLabel);
            Controls.Add(createSupplierNoteSupplierNoteTitleLabel);
            Controls.Add(createSupplierNoteSupplierNoteTextbox);
            Controls.Add(createSupplierNoteSupplierNoteTitleTextbox);
            Controls.Add(createSupplierNoteSupplierNoteTypeComboBox);
            Controls.Add(createSupplierNoteTitleLabel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "CreateSupplierNote";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - Create Supplier Note";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label createSupplierNoteTitleLabel;
        private ComboBox createSupplierNoteSupplierNoteTypeComboBox;
        private TextBox createSupplierNoteSupplierNoteTitleTextbox;
        private TextBox createSupplierNoteSupplierNoteTextbox;
        private Label createSupplierNoteSupplierNoteTitleLabel;
        private Label createSupplierNoteSupplierNoteTypeLabel;
        private Label createSupplierNoteSupplierNoteLabel;
        private Button createSupplierSubmitButton;
    }
}