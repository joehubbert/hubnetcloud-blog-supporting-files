namespace CRM_WindowsForms.Presentation
{
    partial class CreateSalesSubRegion
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
            createSalesSubRegionTitleLabel = new Label();
            createSalesSubRegionSalesSubRegionTextbox = new TextBox();
            createSalesSubRegionSalesSubRegionLabel = new Label();
            createSalesSubRegionSubmitButton = new Button();
            createSalesSubRegionActiveStatusCheckbox = new CheckBox();
            createSalesSubRegionSalesRegionLabel = new Label();
            createSalesSubRegionSalesRegionComboBox = new ComboBox();
            SuspendLayout();
            // 
            // createSalesSubRegionTitleLabel
            // 
            createSalesSubRegionTitleLabel.AutoSize = true;
            createSalesSubRegionTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createSalesSubRegionTitleLabel.Location = new Point(15, 12);
            createSalesSubRegionTitleLabel.Margin = new Padding(5, 0, 5, 0);
            createSalesSubRegionTitleLabel.Name = "createSalesSubRegionTitleLabel";
            createSalesSubRegionTitleLabel.Size = new Size(288, 32);
            createSalesSubRegionTitleLabel.TabIndex = 7;
            createSalesSubRegionTitleLabel.Text = "Create Sales Sub Region";
            // 
            // createSalesSubRegionSalesSubRegionTextbox
            // 
            createSalesSubRegionSalesSubRegionTextbox.Location = new Point(164, 117);
            createSalesSubRegionSalesSubRegionTextbox.Margin = new Padding(3, 4, 3, 4);
            createSalesSubRegionSalesSubRegionTextbox.MaxLength = 50;
            createSalesSubRegionSalesSubRegionTextbox.Name = "createSalesSubRegionSalesSubRegionTextbox";
            createSalesSubRegionSalesSubRegionTextbox.Size = new Size(284, 27);
            createSalesSubRegionSalesSubRegionTextbox.TabIndex = 0;
            // 
            // createSalesSubRegionSalesSubRegionLabel
            // 
            createSalesSubRegionSalesSubRegionLabel.AutoSize = true;
            createSalesSubRegionSalesSubRegionLabel.Font = new Font("Segoe UI", 11F);
            createSalesSubRegionSalesSubRegionLabel.Location = new Point(25, 124);
            createSalesSubRegionSalesSubRegionLabel.Name = "createSalesSubRegionSalesSubRegionLabel";
            createSalesSubRegionSalesSubRegionLabel.Size = new Size(123, 20);
            createSalesSubRegionSalesSubRegionLabel.TabIndex = 19;
            createSalesSubRegionSalesSubRegionLabel.Text = "Sales Sub Region";
            // 
            // createSalesSubRegionSubmitButton
            // 
            createSalesSubRegionSubmitButton.FlatStyle = FlatStyle.Flat;
            createSalesSubRegionSubmitButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createSalesSubRegionSubmitButton.Location = new Point(175, 204);
            createSalesSubRegionSubmitButton.Margin = new Padding(4);
            createSalesSubRegionSubmitButton.Name = "createSalesSubRegionSubmitButton";
            createSalesSubRegionSubmitButton.Size = new Size(198, 66);
            createSalesSubRegionSubmitButton.TabIndex = 2;
            createSalesSubRegionSubmitButton.Text = "Submit";
            createSalesSubRegionSubmitButton.UseVisualStyleBackColor = true;
            createSalesSubRegionSubmitButton.Click += createSalesSubRegionSubmitButton_Click;
            // 
            // createSalesSubRegionActiveStatusCheckbox
            // 
            createSalesSubRegionActiveStatusCheckbox.AutoSize = true;
            createSalesSubRegionActiveStatusCheckbox.Checked = true;
            createSalesSubRegionActiveStatusCheckbox.CheckState = CheckState.Checked;
            createSalesSubRegionActiveStatusCheckbox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createSalesSubRegionActiveStatusCheckbox.Location = new Point(181, 171);
            createSalesSubRegionActiveStatusCheckbox.Margin = new Padding(5);
            createSalesSubRegionActiveStatusCheckbox.Name = "createSalesSubRegionActiveStatusCheckbox";
            createSalesSubRegionActiveStatusCheckbox.Size = new Size(187, 24);
            createSalesSubRegionActiveStatusCheckbox.TabIndex = 1;
            createSalesSubRegionActiveStatusCheckbox.Text = "Active Sales Sub Region";
            createSalesSubRegionActiveStatusCheckbox.UseVisualStyleBackColor = true;
            // 
            // createSalesSubRegionSalesRegionLabel
            // 
            createSalesSubRegionSalesRegionLabel.AutoSize = true;
            createSalesSubRegionSalesRegionLabel.Font = new Font("Segoe UI", 11F);
            createSalesSubRegionSalesRegionLabel.Location = new Point(54, 71);
            createSalesSubRegionSalesRegionLabel.Name = "createSalesSubRegionSalesRegionLabel";
            createSalesSubRegionSalesRegionLabel.Size = new Size(94, 20);
            createSalesSubRegionSalesRegionLabel.TabIndex = 20;
            createSalesSubRegionSalesRegionLabel.Text = "Sales Region";
            // 
            // createSalesSubRegionSalesRegionComboBox
            // 
            createSalesSubRegionSalesRegionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            createSalesSubRegionSalesRegionComboBox.FormattingEnabled = true;
            createSalesSubRegionSalesRegionComboBox.Location = new Point(164, 68);
            createSalesSubRegionSalesRegionComboBox.Name = "createSalesSubRegionSalesRegionComboBox";
            createSalesSubRegionSalesRegionComboBox.Size = new Size(284, 28);
            createSalesSubRegionSalesRegionComboBox.TabIndex = 21;
            // 
            // CreateSalesSubRegion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(498, 285);
            Controls.Add(createSalesSubRegionSalesRegionComboBox);
            Controls.Add(createSalesSubRegionSalesRegionLabel);
            Controls.Add(createSalesSubRegionSalesSubRegionTextbox);
            Controls.Add(createSalesSubRegionSalesSubRegionLabel);
            Controls.Add(createSalesSubRegionSubmitButton);
            Controls.Add(createSalesSubRegionActiveStatusCheckbox);
            Controls.Add(createSalesSubRegionTitleLabel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "CreateSalesSubRegion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - Create Sales Sub Region";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label createSalesSubRegionTitleLabel;
        private TextBox createSalesSubRegionSalesSubRegionTextbox;
        private Label createSalesSubRegionSalesSubRegionLabel;
        private Button createSalesSubRegionSubmitButton;
        private CheckBox createSalesSubRegionActiveStatusCheckbox;
        private Label createSalesSubRegionSalesRegionLabel;
        private ComboBox createSalesSubRegionSalesRegionComboBox;
    }
}