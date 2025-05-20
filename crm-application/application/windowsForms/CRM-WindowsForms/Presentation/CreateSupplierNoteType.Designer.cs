namespace CRM_WindowsForms.Presentation
{
    partial class CreateSupplierNoteType
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
            createSupplierNoteTypeTitleLabel = new Label();
            createSupplierNoteTypeSupplierNoteTypeTextbox = new TextBox();
            createSupplierNoteTypeSupplierNoteTypeLabel = new Label();
            createSupplierNoteTypeSubmitButton = new Button();
            createSupplierNoteTypeActiveStatusCheckbox = new CheckBox();
            SuspendLayout();
            // 
            // createSupplierNoteTypeTitleLabel
            // 
            createSupplierNoteTypeTitleLabel.AutoSize = true;
            createSupplierNoteTypeTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createSupplierNoteTypeTitleLabel.Location = new Point(15, 12);
            createSupplierNoteTypeTitleLabel.Margin = new Padding(5, 0, 5, 0);
            createSupplierNoteTypeTitleLabel.Name = "createSupplierNoteTypeTitleLabel";
            createSupplierNoteTypeTitleLabel.Size = new Size(313, 32);
            createSupplierNoteTypeTitleLabel.TabIndex = 7;
            createSupplierNoteTypeTitleLabel.Text = "Create Supplier Note Type";
            // 
            // createSupplierNoteTypeSupplierNoteTypeTextbox
            // 
            createSupplierNoteTypeSupplierNoteTypeTextbox.Location = new Point(181, 74);
            createSupplierNoteTypeSupplierNoteTypeTextbox.Margin = new Padding(3, 4, 3, 4);
            createSupplierNoteTypeSupplierNoteTypeTextbox.MaxLength = 50;
            createSupplierNoteTypeSupplierNoteTypeTextbox.Name = "createSupplierNoteTypeSupplierNoteTypeTextbox";
            createSupplierNoteTypeSupplierNoteTypeTextbox.Size = new Size(343, 27);
            createSupplierNoteTypeSupplierNoteTypeTextbox.TabIndex = 0;
            // 
            // createSupplierNoteTypeSupplierNoteTypeLabel
            // 
            createSupplierNoteTypeSupplierNoteTypeLabel.AutoSize = true;
            createSupplierNoteTypeSupplierNoteTypeLabel.Font = new Font("Segoe UI", 11F);
            createSupplierNoteTypeSupplierNoteTypeLabel.Location = new Point(25, 77);
            createSupplierNoteTypeSupplierNoteTypeLabel.Name = "createSupplierNoteTypeSupplierNoteTypeLabel";
            createSupplierNoteTypeSupplierNoteTypeLabel.Size = new Size(136, 20);
            createSupplierNoteTypeSupplierNoteTypeLabel.TabIndex = 19;
            createSupplierNoteTypeSupplierNoteTypeLabel.Text = "Supplier Note Type";
            // 
            // createSupplierNoteTypeSubmitButton
            // 
            createSupplierNoteTypeSubmitButton.FlatStyle = FlatStyle.Flat;
            createSupplierNoteTypeSubmitButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createSupplierNoteTypeSubmitButton.Location = new Point(191, 190);
            createSupplierNoteTypeSubmitButton.Margin = new Padding(4);
            createSupplierNoteTypeSubmitButton.Name = "createSupplierNoteTypeSubmitButton";
            createSupplierNoteTypeSubmitButton.Size = new Size(198, 66);
            createSupplierNoteTypeSubmitButton.TabIndex = 2;
            createSupplierNoteTypeSubmitButton.Text = "Submit";
            createSupplierNoteTypeSubmitButton.UseVisualStyleBackColor = true;
            createSupplierNoteTypeSubmitButton.Click += createSupplierNoteTypeSubmitButton_Click;
            // 
            // createSupplierNoteTypeActiveStatusCheckbox
            // 
            createSupplierNoteTypeActiveStatusCheckbox.AutoSize = true;
            createSupplierNoteTypeActiveStatusCheckbox.Checked = true;
            createSupplierNoteTypeActiveStatusCheckbox.CheckState = CheckState.Checked;
            createSupplierNoteTypeActiveStatusCheckbox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createSupplierNoteTypeActiveStatusCheckbox.Location = new Point(193, 146);
            createSupplierNoteTypeActiveStatusCheckbox.Margin = new Padding(5);
            createSupplierNoteTypeActiveStatusCheckbox.Name = "createSupplierNoteTypeActiveStatusCheckbox";
            createSupplierNoteTypeActiveStatusCheckbox.Size = new Size(200, 24);
            createSupplierNoteTypeActiveStatusCheckbox.TabIndex = 1;
            createSupplierNoteTypeActiveStatusCheckbox.Text = "Active Supplier Note Type";
            createSupplierNoteTypeActiveStatusCheckbox.UseVisualStyleBackColor = true;
            // 
            // CreateSupplierNoteType
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(559, 266);
            Controls.Add(createSupplierNoteTypeSupplierNoteTypeTextbox);
            Controls.Add(createSupplierNoteTypeSupplierNoteTypeLabel);
            Controls.Add(createSupplierNoteTypeSubmitButton);
            Controls.Add(createSupplierNoteTypeActiveStatusCheckbox);
            Controls.Add(createSupplierNoteTypeTitleLabel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "CreateSupplierNoteType";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - Create Supplier Note Type";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label createSupplierNoteTypeTitleLabel;
        private TextBox createSupplierNoteTypeSupplierNoteTypeTextbox;
        private Label createSupplierNoteTypeSupplierNoteTypeLabel;
        private Button createSupplierNoteTypeSubmitButton;
        private CheckBox createSupplierNoteTypeActiveStatusCheckbox;
    }
}