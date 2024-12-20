namespace CRM_WindowsForms.Presentation
{
    partial class CreateCustomer
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
            createCustomerTitleLabel = new Label();
            SuspendLayout();
            // 
            // createCustomerTitleLabel
            // 
            createCustomerTitleLabel.AutoSize = true;
            createCustomerTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createCustomerTitleLabel.Location = new Point(13, 9);
            createCustomerTitleLabel.Margin = new Padding(4, 0, 4, 0);
            createCustomerTitleLabel.Name = "createCustomerTitleLabel";
            createCustomerTitleLabel.Size = new Size(204, 32);
            createCustomerTitleLabel.TabIndex = 6;
            createCustomerTitleLabel.Text = "Create Customer";
            // 
            // CreateCustomer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(960, 540);
            Controls.Add(createCustomerTitleLabel);
            Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "CreateCustomer";
            Text = "CRM - Create Customer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label createCustomerTitleLabel;
    }
}