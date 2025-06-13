namespace CRM_WindowsForms.Presentation
{
    partial class CreateMetadataSimple
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
            createMetadataSimpleTitleLabel = new Label();
            createMetadataSimpleMetadataTypeTextbox = new TextBox();
            createMetadataSimpleMetadataTypeTextboxLabel = new Label();
            createMetadataSimpleSubmitButton = new Button();
            createMetadataSimpleActiveStatusCheckbox = new CheckBox();
            SuspendLayout();
            // 
            // createMetadataSimpleTitleLabel
            // 
            createMetadataSimpleTitleLabel.AutoSize = true;
            createMetadataSimpleTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createMetadataSimpleTitleLabel.Location = new Point(14, 9);
            createMetadataSimpleTitleLabel.Margin = new Padding(5, 0, 5, 0);
            createMetadataSimpleTitleLabel.Name = "createMetadataSimpleTitleLabel";
            createMetadataSimpleTitleLabel.Size = new Size(342, 32);
            createMetadataSimpleTitleLabel.TabIndex = 8;
            createMetadataSimpleTitleLabel.Text = "{Metadata Type Placeholder}";
            // 
            // createMetadataSimpleMetadataTypeTextbox
            // 
            createMetadataSimpleMetadataTypeTextbox.Location = new Point(225, 59);
            createMetadataSimpleMetadataTypeTextbox.Margin = new Padding(3, 4, 3, 4);
            createMetadataSimpleMetadataTypeTextbox.MaxLength = 50;
            createMetadataSimpleMetadataTypeTextbox.Name = "createMetadataSimpleMetadataTypeTextbox";
            createMetadataSimpleMetadataTypeTextbox.Size = new Size(271, 27);
            createMetadataSimpleMetadataTypeTextbox.TabIndex = 20;
            // 
            // createMetadataSimpleMetadataTypeTextboxLabel
            // 
            createMetadataSimpleMetadataTypeTextboxLabel.Font = new Font("Segoe UI", 11F);
            createMetadataSimpleMetadataTypeTextboxLabel.Location = new Point(14, 66);
            createMetadataSimpleMetadataTypeTextboxLabel.Name = "createMetadataSimpleMetadataTypeTextboxLabel";
            createMetadataSimpleMetadataTypeTextboxLabel.Size = new Size(205, 20);
            createMetadataSimpleMetadataTypeTextboxLabel.TabIndex = 23;
            createMetadataSimpleMetadataTypeTextboxLabel.Text = "{Metadata Type Placeholder}";
            createMetadataSimpleMetadataTypeTextboxLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // createMetadataSimpleSubmitButton
            // 
            createMetadataSimpleSubmitButton.FlatStyle = FlatStyle.Flat;
            createMetadataSimpleSubmitButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createMetadataSimpleSubmitButton.Location = new Point(166, 165);
            createMetadataSimpleSubmitButton.Margin = new Padding(4);
            createMetadataSimpleSubmitButton.Name = "createMetadataSimpleSubmitButton";
            createMetadataSimpleSubmitButton.Size = new Size(198, 66);
            createMetadataSimpleSubmitButton.TabIndex = 22;
            createMetadataSimpleSubmitButton.Text = "Submit";
            createMetadataSimpleSubmitButton.UseVisualStyleBackColor = true;
            createMetadataSimpleSubmitButton.Click += createMetadataSimpleSubmitButton_Click;
            // 
            // createMetadataSimpleActiveStatusCheckbox
            // 
            createMetadataSimpleActiveStatusCheckbox.Checked = true;
            createMetadataSimpleActiveStatusCheckbox.CheckState = CheckState.Checked;
            createMetadataSimpleActiveStatusCheckbox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createMetadataSimpleActiveStatusCheckbox.Location = new Point(136, 117);
            createMetadataSimpleActiveStatusCheckbox.Margin = new Padding(5);
            createMetadataSimpleActiveStatusCheckbox.Name = "createMetadataSimpleActiveStatusCheckbox";
            createMetadataSimpleActiveStatusCheckbox.Size = new Size(265, 24);
            createMetadataSimpleActiveStatusCheckbox.TabIndex = 21;
            createMetadataSimpleActiveStatusCheckbox.Text = "Active {Metadata Type Placeholder}";
            createMetadataSimpleActiveStatusCheckbox.UseVisualStyleBackColor = true;
            // 
            // CreateMetadataSimple
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(524, 250);
            Controls.Add(createMetadataSimpleMetadataTypeTextbox);
            Controls.Add(createMetadataSimpleMetadataTypeTextboxLabel);
            Controls.Add(createMetadataSimpleSubmitButton);
            Controls.Add(createMetadataSimpleActiveStatusCheckbox);
            Controls.Add(createMetadataSimpleTitleLabel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "CreateMetadataSimple";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CreateMetadataSimple";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label createMetadataSimpleTitleLabel;
        private TextBox createMetadataSimpleMetadataTypeTextbox;
        private Label createMetadataSimpleMetadataTypeTextboxLabel;
        private Button createMetadataSimpleSubmitButton;
        private CheckBox createMetadataSimpleActiveStatusCheckbox;
    }
}