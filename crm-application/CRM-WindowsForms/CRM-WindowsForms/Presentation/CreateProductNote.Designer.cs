namespace CRM_WindowsForms.Presentation
{
    partial class CreateProductNote
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
            createProductNoteTitleLabel = new Label();
            createProductNoteProductNoteTypeComboBox = new ComboBox();
            createProductNoteProductNoteTitleTextbox = new TextBox();
            createProductNoteProductNoteTextbox = new TextBox();
            createProductNoteProductNoteTitleLabel = new Label();
            createProductNoteProductNoteTypeLabel = new Label();
            createProductNoteProductNoteLabel = new Label();
            createProductSubmitButton = new Button();
            SuspendLayout();
            // 
            // createProductNoteTitleLabel
            // 
            createProductNoteTitleLabel.AutoSize = true;
            createProductNoteTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createProductNoteTitleLabel.Location = new Point(13, 9);
            createProductNoteTitleLabel.Margin = new Padding(4, 0, 4, 0);
            createProductNoteTitleLabel.Name = "createProductNoteTitleLabel";
            createProductNoteTitleLabel.Size = new Size(248, 32);
            createProductNoteTitleLabel.TabIndex = 7;
            createProductNoteTitleLabel.Text = "Create Product Note";
            // 
            // createProductNoteProductNoteTypeComboBox
            // 
            createProductNoteProductNoteTypeComboBox.FormattingEnabled = true;
            createProductNoteProductNoteTypeComboBox.Location = new Point(188, 104);
            createProductNoteProductNoteTypeComboBox.Name = "createProductNoteProductNoteTypeComboBox";
            createProductNoteProductNoteTypeComboBox.Size = new Size(524, 28);
            createProductNoteProductNoteTypeComboBox.TabIndex = 8;
            // 
            // createProductNoteProductNoteTitleTextbox
            // 
            createProductNoteProductNoteTitleTextbox.Location = new Point(188, 65);
            createProductNoteProductNoteTitleTextbox.MaxLength = 50;
            createProductNoteProductNoteTitleTextbox.Name = "createProductNoteProductNoteTitleTextbox";
            createProductNoteProductNoteTitleTextbox.Size = new Size(524, 27);
            createProductNoteProductNoteTitleTextbox.TabIndex = 9;
            // 
            // createProductNoteProductNoteTextbox
            // 
            createProductNoteProductNoteTextbox.Location = new Point(188, 147);
            createProductNoteProductNoteTextbox.MaxLength = 1073741823;
            createProductNoteProductNoteTextbox.Multiline = true;
            createProductNoteProductNoteTextbox.Name = "createProductNoteProductNoteTextbox";
            createProductNoteProductNoteTextbox.Size = new Size(524, 259);
            createProductNoteProductNoteTextbox.TabIndex = 10;
            // 
            // createProductNoteProductNoteTitleLabel
            // 
            createProductNoteProductNoteTitleLabel.AutoSize = true;
            createProductNoteProductNoteTitleLabel.Location = new Point(40, 68);
            createProductNoteProductNoteTitleLabel.Name = "createProductNoteProductNoteTitleLabel";
            createProductNoteProductNoteTitleLabel.Size = new Size(130, 20);
            createProductNoteProductNoteTitleLabel.TabIndex = 11;
            createProductNoteProductNoteTitleLabel.Text = "Product Note Title";
            // 
            // createProductNoteProductNoteTypeLabel
            // 
            createProductNoteProductNoteTypeLabel.AutoSize = true;
            createProductNoteProductNoteTypeLabel.Location = new Point(40, 107);
            createProductNoteProductNoteTypeLabel.Name = "createProductNoteProductNoteTypeLabel";
            createProductNoteProductNoteTypeLabel.Size = new Size(132, 20);
            createProductNoteProductNoteTypeLabel.TabIndex = 12;
            createProductNoteProductNoteTypeLabel.Text = "Product Note Type";
            // 
            // createProductNoteProductNoteLabel
            // 
            createProductNoteProductNoteLabel.AutoSize = true;
            createProductNoteProductNoteLabel.Location = new Point(73, 150);
            createProductNoteProductNoteLabel.Name = "createProductNoteProductNoteLabel";
            createProductNoteProductNoteLabel.Size = new Size(97, 20);
            createProductNoteProductNoteLabel.TabIndex = 13;
            createProductNoteProductNoteLabel.Text = "Product Note";
            // 
            // createProductSubmitButton
            // 
            createProductSubmitButton.FlatStyle = FlatStyle.Flat;
            createProductSubmitButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createProductSubmitButton.Location = new Point(274, 420);
            createProductSubmitButton.Margin = new Padding(4);
            createProductSubmitButton.Name = "createProductSubmitButton";
            createProductSubmitButton.Size = new Size(198, 66);
            createProductSubmitButton.TabIndex = 51;
            createProductSubmitButton.Text = "Submit";
            createProductSubmitButton.UseVisualStyleBackColor = true;
            createProductSubmitButton.Click += createProductSubmitButton_Click;
            // 
            // CreateProductNote
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(737, 499);
            Controls.Add(createProductSubmitButton);
            Controls.Add(createProductNoteProductNoteLabel);
            Controls.Add(createProductNoteProductNoteTypeLabel);
            Controls.Add(createProductNoteProductNoteTitleLabel);
            Controls.Add(createProductNoteProductNoteTextbox);
            Controls.Add(createProductNoteProductNoteTitleTextbox);
            Controls.Add(createProductNoteProductNoteTypeComboBox);
            Controls.Add(createProductNoteTitleLabel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "CreateProductNote";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - Create Product Note";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label createProductNoteTitleLabel;
        private ComboBox createProductNoteProductNoteTypeComboBox;
        private TextBox createProductNoteProductNoteTitleTextbox;
        private TextBox createProductNoteProductNoteTextbox;
        private Label createProductNoteProductNoteTitleLabel;
        private Label createProductNoteProductNoteTypeLabel;
        private Label createProductNoteProductNoteLabel;
        private Button createProductSubmitButton;
    }
}