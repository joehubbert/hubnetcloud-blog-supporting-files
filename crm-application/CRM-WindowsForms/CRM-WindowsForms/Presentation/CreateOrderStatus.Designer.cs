namespace CRM_WindowsForms.Presentation
{
    partial class CreateOrderStatus
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
            createOrderStatusTitleLabel = new Label();
            createOrderStatusOrderStatusTextbox = new TextBox();
            createOrderStatusOrderStatusLabel = new Label();
            createOrderStatusSubmitButton = new Button();
            createOrderStatusActiveStatusCheckbox = new CheckBox();
            SuspendLayout();
            // 
            // createOrderStatusTitleLabel
            // 
            createOrderStatusTitleLabel.AutoSize = true;
            createOrderStatusTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createOrderStatusTitleLabel.Location = new Point(15, 12);
            createOrderStatusTitleLabel.Margin = new Padding(5, 0, 5, 0);
            createOrderStatusTitleLabel.Name = "createOrderStatusTitleLabel";
            createOrderStatusTitleLabel.Size = new Size(236, 32);
            createOrderStatusTitleLabel.TabIndex = 7;
            createOrderStatusTitleLabel.Text = "Create Order Status";
            // 
            // createOrderStatusOrderStatusTextbox
            // 
            createOrderStatusOrderStatusTextbox.Location = new Point(144, 70);
            createOrderStatusOrderStatusTextbox.Margin = new Padding(3, 4, 3, 4);
            createOrderStatusOrderStatusTextbox.MaxLength = 50;
            createOrderStatusOrderStatusTextbox.Name = "createOrderStatusOrderStatusTextbox";
            createOrderStatusOrderStatusTextbox.Size = new Size(284, 27);
            createOrderStatusOrderStatusTextbox.TabIndex = 20;
            // 
            // createOrderStatusOrderStatusLabel
            // 
            createOrderStatusOrderStatusLabel.AutoSize = true;
            createOrderStatusOrderStatusLabel.Font = new Font("Segoe UI", 11F);
            createOrderStatusOrderStatusLabel.Location = new Point(25, 77);
            createOrderStatusOrderStatusLabel.Name = "createOrderStatusOrderStatusLabel";
            createOrderStatusOrderStatusLabel.Size = new Size(91, 20);
            createOrderStatusOrderStatusLabel.TabIndex = 19;
            createOrderStatusOrderStatusLabel.Text = "Order Status";
            // 
            // createOrderStatusSubmitButton
            // 
            createOrderStatusSubmitButton.FlatStyle = FlatStyle.Flat;
            createOrderStatusSubmitButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createOrderStatusSubmitButton.Location = new Point(131, 199);
            createOrderStatusSubmitButton.Margin = new Padding(4);
            createOrderStatusSubmitButton.Name = "createOrderStatusSubmitButton";
            createOrderStatusSubmitButton.Size = new Size(198, 66);
            createOrderStatusSubmitButton.TabIndex = 18;
            createOrderStatusSubmitButton.Text = "Submit";
            createOrderStatusSubmitButton.UseVisualStyleBackColor = true;
            // 
            // createOrderStatusActiveStatusCheckbox
            // 
            createOrderStatusActiveStatusCheckbox.AutoSize = true;
            createOrderStatusActiveStatusCheckbox.Checked = true;
            createOrderStatusActiveStatusCheckbox.CheckState = CheckState.Checked;
            createOrderStatusActiveStatusCheckbox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createOrderStatusActiveStatusCheckbox.Location = new Point(144, 151);
            createOrderStatusActiveStatusCheckbox.Margin = new Padding(5);
            createOrderStatusActiveStatusCheckbox.Name = "createOrderStatusActiveStatusCheckbox";
            createOrderStatusActiveStatusCheckbox.Size = new Size(155, 24);
            createOrderStatusActiveStatusCheckbox.TabIndex = 17;
            createOrderStatusActiveStatusCheckbox.Text = "Active Order Status";
            createOrderStatusActiveStatusCheckbox.UseVisualStyleBackColor = true;
            // 
            // CreateOrderStatus
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(467, 279);
            Controls.Add(createOrderStatusOrderStatusTextbox);
            Controls.Add(createOrderStatusOrderStatusLabel);
            Controls.Add(createOrderStatusSubmitButton);
            Controls.Add(createOrderStatusActiveStatusCheckbox);
            Controls.Add(createOrderStatusTitleLabel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "CreateOrderStatus";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - Create Order Status";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label createOrderStatusTitleLabel;
        private TextBox createOrderStatusOrderStatusTextbox;
        private Label createOrderStatusOrderStatusLabel;
        private Button createOrderStatusSubmitButton;
        private CheckBox createOrderStatusActiveStatusCheckbox;
    }
}