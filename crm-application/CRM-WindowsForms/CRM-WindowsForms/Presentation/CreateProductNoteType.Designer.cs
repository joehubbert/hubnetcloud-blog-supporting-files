namespace CRM_WindowsForms.Presentation
{
    partial class CreateProductNoteType
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
            createProductNoteTypeTitleLabel = new Label();
            createProductNoteTypeProductNoteTypeTextbox = new TextBox();
            createProductNoteTypeProductNoteTypeLabel = new Label();
            createProductNoteTypeSubmitButton = new Button();
            createProductNoteTypeActiveStatusCheckbox = new CheckBox();
            SuspendLayout();
            // 
            // createProductNoteTypeTitleLabel
            // 
            createProductNoteTypeTitleLabel.AutoSize = true;
            createProductNoteTypeTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createProductNoteTypeTitleLabel.Location = new Point(15, 12);
            createProductNoteTypeTitleLabel.Margin = new Padding(5, 0, 5, 0);
            createProductNoteTypeTitleLabel.Name = "createProductNoteTypeTitleLabel";
            createProductNoteTypeTitleLabel.Size = new Size(328, 32);
            createProductNoteTypeTitleLabel.TabIndex = 7;
            createProductNoteTypeTitleLabel.Text = "Create Product Note Type";
            // 
            // createProductNoteTypeProductNoteTypeTextbox
            // 
            createProductNoteTypeProductNoteTypeTextbox.Location = new Point(181, 74);
            createProductNoteTypeProductNoteTypeTextbox.Margin = new Padding(3, 4, 3, 4);
            createProductNoteTypeProductNoteTypeTextbox.MaxLength = 50;
            createProductNoteTypeProductNoteTypeTextbox.Name = "createProductNoteTypeProductNoteTypeTextbox";
            createProductNoteTypeProductNoteTypeTextbox.Size = new Size(343, 27);
            createProductNoteTypeProductNoteTypeTextbox.TabIndex = 20;
            // 
            // createProductNoteTypeProductNoteTypeLabel
            // 
            createProductNoteTypeProductNoteTypeLabel.AutoSize = true;
            createProductNoteTypeProductNoteTypeLabel.Font = new Font("Segoe UI", 11F);
            createProductNoteTypeProductNoteTypeLabel.Location = new Point(25, 77);
            createProductNoteTypeProductNoteTypeLabel.Name = "createProductNoteTypeProductNoteTypeLabel";
            createProductNoteTypeProductNoteTypeLabel.Size = new Size(144, 20);
            createProductNoteTypeProductNoteTypeLabel.TabIndex = 19;
            createProductNoteTypeProductNoteTypeLabel.Text = "Product Note Type";
            // 
            // createProductNoteTypeSubmitButton
            // 
            createProductNoteTypeSubmitButton.FlatStyle = FlatStyle.Flat;
            createProductNoteTypeSubmitButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createProductNoteTypeSubmitButton.Location = new Point(191, 190);
            createProductNoteTypeSubmitButton.Margin = new Padding(4);
            createProductNoteTypeSubmitButton.Name = "createProductNoteTypeSubmitButton";
            createProductNoteTypeSubmitButton.Size = new Size(198, 66);
            createProductNoteTypeSubmitButton.TabIndex = 18;
            createProductNoteTypeSubmitButton.Text = "Submit";
            createProductNoteTypeSubmitButton.UseVisualStyleBackColor = true;
            // 
            // createProductNoteTypeActiveStatusCheckbox
            // 
            createProductNoteTypeActiveStatusCheckbox.AutoSize = true;
            createProductNoteTypeActiveStatusCheckbox.Checked = true;
            createProductNoteTypeActiveStatusCheckbox.CheckState = CheckState.Checked;
            createProductNoteTypeActiveStatusCheckbox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createProductNoteTypeActiveStatusCheckbox.Location = new Point(181, 147);
            createProductNoteTypeActiveStatusCheckbox.Margin = new Padding(5);
            createProductNoteTypeActiveStatusCheckbox.Name = "createProductNoteTypeActiveStatusCheckbox";
            createProductNoteTypeActiveStatusCheckbox.Size = new Size(208, 24);
            createProductNoteTypeActiveStatusCheckbox.TabIndex = 17;
            createProductNoteTypeActiveStatusCheckbox.Text = "Active Product Note Type";
            createProductNoteTypeActiveStatusCheckbox.UseVisualStyleBackColor = true;
            // 
            // CreateProductNoteType
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(559, 281);
            Controls.Add(createProductNoteTypeProductNoteTypeTextbox);
            Controls.Add(createProductNoteTypeProductNoteTypeLabel);
            Controls.Add(createProductNoteTypeSubmitButton);
            Controls.Add(createProductNoteTypeActiveStatusCheckbox);
            Controls.Add(createProductNoteTypeTitleLabel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "CreateProductNoteType";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - Create Product Note Type";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label createProductNoteTypeTitleLabel;
        private TextBox createProductNoteTypeProductNoteTypeTextbox;
        private Label createProductNoteTypeProductNoteTypeLabel;
        private Button createProductNoteTypeSubmitButton;
        private CheckBox createProductNoteTypeActiveStatusCheckbox;
    }
}