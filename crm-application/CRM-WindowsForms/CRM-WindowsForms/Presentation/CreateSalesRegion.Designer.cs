namespace CRM_WindowsForms.Presentation
{
    partial class CreateSalesRegion
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
            createSalesRegionTitleLabel = new Label();
            createSalesRegionSalesRegionTextbox = new TextBox();
            createSalesRegionSalesRegionLabel = new Label();
            createSalesRegionSubmitButton = new Button();
            createSalesRegionActiveStatusCheckbox = new CheckBox();
            SuspendLayout();
            // 
            // createSalesRegionTitleLabel
            // 
            createSalesRegionTitleLabel.AutoSize = true;
            createSalesRegionTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createSalesRegionTitleLabel.Location = new Point(15, 12);
            createSalesRegionTitleLabel.Margin = new Padding(5, 0, 5, 0);
            createSalesRegionTitleLabel.Name = "createSalesRegionTitleLabel";
            createSalesRegionTitleLabel.Size = new Size(238, 32);
            createSalesRegionTitleLabel.TabIndex = 7;
            createSalesRegionTitleLabel.Text = "Create Sales Region";
            // 
            // createSalesRegionSalesRegionTextbox
            // 
            createSalesRegionSalesRegionTextbox.Location = new Point(131, 74);
            createSalesRegionSalesRegionTextbox.Margin = new Padding(3, 4, 3, 4);
            createSalesRegionSalesRegionTextbox.MaxLength = 50;
            createSalesRegionSalesRegionTextbox.Name = "createSalesRegionSalesRegionTextbox";
            createSalesRegionSalesRegionTextbox.Size = new Size(284, 27);
            createSalesRegionSalesRegionTextbox.TabIndex = 0;
            // 
            // createSalesRegionSalesRegionLabel
            // 
            createSalesRegionSalesRegionLabel.AutoSize = true;
            createSalesRegionSalesRegionLabel.Font = new Font("Segoe UI", 11F);
            createSalesRegionSalesRegionLabel.Location = new Point(25, 77);
            createSalesRegionSalesRegionLabel.Name = "createSalesRegionSalesRegionLabel";
            createSalesRegionSalesRegionLabel.Size = new Size(94, 20);
            createSalesRegionSalesRegionLabel.TabIndex = 19;
            createSalesRegionSalesRegionLabel.Text = "Sales Region";
            // 
            // createSalesRegionSubmitButton
            // 
            createSalesRegionSubmitButton.FlatStyle = FlatStyle.Flat;
            createSalesRegionSubmitButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createSalesRegionSubmitButton.Location = new Point(131, 171);
            createSalesRegionSubmitButton.Margin = new Padding(4);
            createSalesRegionSubmitButton.Name = "createSalesRegionSubmitButton";
            createSalesRegionSubmitButton.Size = new Size(198, 66);
            createSalesRegionSubmitButton.TabIndex = 2;
            createSalesRegionSubmitButton.Text = "Submit";
            createSalesRegionSubmitButton.UseVisualStyleBackColor = true;
            createSalesRegionSubmitButton.Click += createSalesRegionSubmitButton_Click;
            // 
            // createSalesRegionActiveStatusCheckbox
            // 
            createSalesRegionActiveStatusCheckbox.AutoSize = true;
            createSalesRegionActiveStatusCheckbox.Checked = true;
            createSalesRegionActiveStatusCheckbox.CheckState = CheckState.Checked;
            createSalesRegionActiveStatusCheckbox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createSalesRegionActiveStatusCheckbox.Location = new Point(152, 138);
            createSalesRegionActiveStatusCheckbox.Margin = new Padding(5);
            createSalesRegionActiveStatusCheckbox.Name = "createSalesRegionActiveStatusCheckbox";
            createSalesRegionActiveStatusCheckbox.Size = new Size(158, 24);
            createSalesRegionActiveStatusCheckbox.TabIndex = 1;
            createSalesRegionActiveStatusCheckbox.Text = "Active Sales Region";
            createSalesRegionActiveStatusCheckbox.UseVisualStyleBackColor = true;
            // 
            // CreateSalesRegion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(467, 249);
            Controls.Add(createSalesRegionSalesRegionTextbox);
            Controls.Add(createSalesRegionSalesRegionLabel);
            Controls.Add(createSalesRegionSubmitButton);
            Controls.Add(createSalesRegionActiveStatusCheckbox);
            Controls.Add(createSalesRegionTitleLabel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "CreateSalesRegion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - Create Sales Region";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label createSalesRegionTitleLabel;
        private TextBox createSalesRegionSalesRegionTextbox;
        private Label createSalesRegionSalesRegionLabel;
        private Button createSalesRegionSubmitButton;
        private CheckBox createSalesRegionActiveStatusCheckbox;
    }
}