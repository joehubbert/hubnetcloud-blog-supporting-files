namespace CRM_WindowsForms.Presentation
{
    partial class CreateProductCategory
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
            createProductCategoryTitleLabel = new Label();
            createProductCategoryProductCategoryTextbox = new TextBox();
            createProductCategoryProductCategoryLabel = new Label();
            createProductCategorySubmitButton = new Button();
            createProductCategoryActiveStatusCheckbox = new CheckBox();
            SuspendLayout();
            // 
            // createProductCategoryTitleLabel
            // 
            createProductCategoryTitleLabel.AutoSize = true;
            createProductCategoryTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createProductCategoryTitleLabel.Location = new Point(15, 12);
            createProductCategoryTitleLabel.Margin = new Padding(5, 0, 5, 0);
            createProductCategoryTitleLabel.Name = "createProductCategoryTitleLabel";
            createProductCategoryTitleLabel.Size = new Size(296, 32);
            createProductCategoryTitleLabel.TabIndex = 7;
            createProductCategoryTitleLabel.Text = "Create Product Category";
            // 
            // createProductCategoryProductCategoryTextbox
            // 
            createProductCategoryProductCategoryTextbox.Location = new Point(155, 74);
            createProductCategoryProductCategoryTextbox.Margin = new Padding(3, 4, 3, 4);
            createProductCategoryProductCategoryTextbox.MaxLength = 50;
            createProductCategoryProductCategoryTextbox.Name = "createProductCategoryProductCategoryTextbox";
            createProductCategoryProductCategoryTextbox.Size = new Size(284, 27);
            createProductCategoryProductCategoryTextbox.TabIndex = 20;
            // 
            // createProductCategoryProductCategoryLabel
            // 
            createProductCategoryProductCategoryLabel.AutoSize = true;
            createProductCategoryProductCategoryLabel.Font = new Font("Segoe UI", 11F);
            createProductCategoryProductCategoryLabel.Location = new Point(25, 77);
            createProductCategoryProductCategoryLabel.Name = "createProductCategoryProductCategoryLabel";
            createProductCategoryProductCategoryLabel.Size = new Size(124, 20);
            createProductCategoryProductCategoryLabel.TabIndex = 19;
            createProductCategoryProductCategoryLabel.Text = "Product Category";
            // 
            // createProductCategorySubmitButton
            // 
            createProductCategorySubmitButton.FlatStyle = FlatStyle.Flat;
            createProductCategorySubmitButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createProductCategorySubmitButton.Location = new Point(131, 199);
            createProductCategorySubmitButton.Margin = new Padding(4);
            createProductCategorySubmitButton.Name = "createProductCategorySubmitButton";
            createProductCategorySubmitButton.Size = new Size(198, 66);
            createProductCategorySubmitButton.TabIndex = 18;
            createProductCategorySubmitButton.Text = "Submit";
            createProductCategorySubmitButton.UseVisualStyleBackColor = true;
            // 
            // createProductCategoryActiveStatusCheckbox
            // 
            createProductCategoryActiveStatusCheckbox.AutoSize = true;
            createProductCategoryActiveStatusCheckbox.Checked = true;
            createProductCategoryActiveStatusCheckbox.CheckState = CheckState.Checked;
            createProductCategoryActiveStatusCheckbox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createProductCategoryActiveStatusCheckbox.Location = new Point(144, 151);
            createProductCategoryActiveStatusCheckbox.Margin = new Padding(5);
            createProductCategoryActiveStatusCheckbox.Name = "createProductCategoryActiveStatusCheckbox";
            createProductCategoryActiveStatusCheckbox.Size = new Size(188, 24);
            createProductCategoryActiveStatusCheckbox.TabIndex = 17;
            createProductCategoryActiveStatusCheckbox.Text = "Active Product Category";
            createProductCategoryActiveStatusCheckbox.UseVisualStyleBackColor = true;
            // 
            // CreateProductCategory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(467, 279);
            Controls.Add(createProductCategoryProductCategoryTextbox);
            Controls.Add(createProductCategoryProductCategoryLabel);
            Controls.Add(createProductCategorySubmitButton);
            Controls.Add(createProductCategoryActiveStatusCheckbox);
            Controls.Add(createProductCategoryTitleLabel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "CreateProductCategory";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - Create Product Category";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label createProductCategoryTitleLabel;
        private TextBox createProductCategoryProductCategoryTextbox;
        private Label createProductCategoryProductCategoryLabel;
        private Button createProductCategorySubmitButton;
        private CheckBox createProductCategoryActiveStatusCheckbox;
    }
}