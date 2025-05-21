namespace CRM_WindowsForms.Presentation
{
    partial class OrderStatusDetail
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
            orderStatusDetailTitleLabel = new Label();
            orderStatusDetailUpdateOrderStatusButton = new Button();
            orderStatusDetailActiveStatusCheckbox = new CheckBox();
            orderStatusDetailToggleEditModeButton = new Button();
            orderStatusDetailOrderStatusIdTextbox = new TextBox();
            orderStatusDetailOrderStatusTextbox = new TextBox();
            orderStatusDetailCreatedTimestampTextbox = new TextBox();
            orderStatusDetailLastUpdatedTimestampTextbox = new TextBox();
            orderStatusDetailCreatedByTextbox = new TextBox();
            orderStatusDetailLastUpdatedByTextbox = new TextBox();
            orderStatusDetailLastUpdatedTimestampLabel = new Label();
            orderStatusDetailLastUpdatedByLabel = new Label();
            orderStatusDetailCreatedTimestampLabel = new Label();
            orderStatusDetailCreatedByLabel = new Label();
            orderStatusDetailOrderStatusLabel = new Label();
            orderStatusDetailOrderStatusIdLabel = new Label();
            SuspendLayout();
            // 
            // orderStatusDetailTitleLabel
            // 
            orderStatusDetailTitleLabel.AutoSize = true;
            orderStatusDetailTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            orderStatusDetailTitleLabel.Location = new Point(13, 9);
            orderStatusDetailTitleLabel.Margin = new Padding(4, 0, 4, 0);
            orderStatusDetailTitleLabel.Name = "orderStatusDetailTitleLabel";
            orderStatusDetailTitleLabel.Size = new Size(230, 32);
            orderStatusDetailTitleLabel.TabIndex = 8;
            orderStatusDetailTitleLabel.Text = "Order Status Detail";
            // 
            // orderStatusDetailUpdateOrderStatusButton
            // 
            orderStatusDetailUpdateOrderStatusButton.Enabled = false;
            orderStatusDetailUpdateOrderStatusButton.FlatStyle = FlatStyle.Flat;
            orderStatusDetailUpdateOrderStatusButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            orderStatusDetailUpdateOrderStatusButton.Location = new Point(525, 339);
            orderStatusDetailUpdateOrderStatusButton.Margin = new Padding(4);
            orderStatusDetailUpdateOrderStatusButton.Name = "orderStatusDetailUpdateOrderStatusButton";
            orderStatusDetailUpdateOrderStatusButton.Size = new Size(185, 70);
            orderStatusDetailUpdateOrderStatusButton.TabIndex = 8;
            orderStatusDetailUpdateOrderStatusButton.Text = "Update Order Status";
            orderStatusDetailUpdateOrderStatusButton.UseVisualStyleBackColor = true;
            orderStatusDetailUpdateOrderStatusButton.Click += orderStatusDetailUpdateOrderStatusButton_Click;
            // 
            // orderStatusDetailActiveStatusCheckbox
            // 
            orderStatusDetailActiveStatusCheckbox.AutoSize = true;
            orderStatusDetailActiveStatusCheckbox.Enabled = false;
            orderStatusDetailActiveStatusCheckbox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            orderStatusDetailActiveStatusCheckbox.Location = new Point(224, 308);
            orderStatusDetailActiveStatusCheckbox.Margin = new Padding(4);
            orderStatusDetailActiveStatusCheckbox.Name = "orderStatusDetailActiveStatusCheckbox";
            orderStatusDetailActiveStatusCheckbox.Size = new Size(155, 24);
            orderStatusDetailActiveStatusCheckbox.TabIndex = 2;
            orderStatusDetailActiveStatusCheckbox.Text = "Active Order Status";
            orderStatusDetailActiveStatusCheckbox.UseVisualStyleBackColor = true;
            // 
            // orderStatusDetailToggleEditModeButton
            // 
            orderStatusDetailToggleEditModeButton.FlatStyle = FlatStyle.Flat;
            orderStatusDetailToggleEditModeButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            orderStatusDetailToggleEditModeButton.Location = new Point(1111, 13);
            orderStatusDetailToggleEditModeButton.Margin = new Padding(4);
            orderStatusDetailToggleEditModeButton.Name = "orderStatusDetailToggleEditModeButton";
            orderStatusDetailToggleEditModeButton.Size = new Size(108, 92);
            orderStatusDetailToggleEditModeButton.TabIndex = 7;
            orderStatusDetailToggleEditModeButton.Text = "Toggle Edit Mode";
            orderStatusDetailToggleEditModeButton.UseVisualStyleBackColor = true;
            // 
            // orderStatusDetailOrderStatusIdTextbox
            // 
            orderStatusDetailOrderStatusIdTextbox.Location = new Point(224, 138);
            orderStatusDetailOrderStatusIdTextbox.MaxLength = 36;
            orderStatusDetailOrderStatusIdTextbox.Name = "orderStatusDetailOrderStatusIdTextbox";
            orderStatusDetailOrderStatusIdTextbox.ReadOnly = true;
            orderStatusDetailOrderStatusIdTextbox.Size = new Size(370, 27);
            orderStatusDetailOrderStatusIdTextbox.TabIndex = 0;
            // 
            // orderStatusDetailOrderStatusTextbox
            // 
            orderStatusDetailOrderStatusTextbox.Location = new Point(224, 178);
            orderStatusDetailOrderStatusTextbox.MaxLength = 50;
            orderStatusDetailOrderStatusTextbox.Name = "orderStatusDetailOrderStatusTextbox";
            orderStatusDetailOrderStatusTextbox.ReadOnly = true;
            orderStatusDetailOrderStatusTextbox.Size = new Size(370, 27);
            orderStatusDetailOrderStatusTextbox.TabIndex = 1;
            // 
            // orderStatusDetailCreatedTimestampTextbox
            // 
            orderStatusDetailCreatedTimestampTextbox.Location = new Point(849, 178);
            orderStatusDetailCreatedTimestampTextbox.MaxLength = 50;
            orderStatusDetailCreatedTimestampTextbox.Name = "orderStatusDetailCreatedTimestampTextbox";
            orderStatusDetailCreatedTimestampTextbox.ReadOnly = true;
            orderStatusDetailCreatedTimestampTextbox.Size = new Size(370, 27);
            orderStatusDetailCreatedTimestampTextbox.TabIndex = 4;
            // 
            // orderStatusDetailLastUpdatedTimestampTextbox
            // 
            orderStatusDetailLastUpdatedTimestampTextbox.Location = new Point(849, 258);
            orderStatusDetailLastUpdatedTimestampTextbox.MaxLength = 50;
            orderStatusDetailLastUpdatedTimestampTextbox.Name = "orderStatusDetailLastUpdatedTimestampTextbox";
            orderStatusDetailLastUpdatedTimestampTextbox.ReadOnly = true;
            orderStatusDetailLastUpdatedTimestampTextbox.Size = new Size(370, 27);
            orderStatusDetailLastUpdatedTimestampTextbox.TabIndex = 6;
            // 
            // orderStatusDetailCreatedByTextbox
            // 
            orderStatusDetailCreatedByTextbox.Location = new Point(849, 138);
            orderStatusDetailCreatedByTextbox.MaxLength = 50;
            orderStatusDetailCreatedByTextbox.Name = "orderStatusDetailCreatedByTextbox";
            orderStatusDetailCreatedByTextbox.ReadOnly = true;
            orderStatusDetailCreatedByTextbox.Size = new Size(370, 27);
            orderStatusDetailCreatedByTextbox.TabIndex = 3;
            // 
            // orderStatusDetailLastUpdatedByTextbox
            // 
            orderStatusDetailLastUpdatedByTextbox.Location = new Point(849, 218);
            orderStatusDetailLastUpdatedByTextbox.MaxLength = 50;
            orderStatusDetailLastUpdatedByTextbox.Name = "orderStatusDetailLastUpdatedByTextbox";
            orderStatusDetailLastUpdatedByTextbox.ReadOnly = true;
            orderStatusDetailLastUpdatedByTextbox.Size = new Size(370, 27);
            orderStatusDetailLastUpdatedByTextbox.TabIndex = 5;
            // 
            // orderStatusDetailLastUpdatedTimestampLabel
            // 
            orderStatusDetailLastUpdatedTimestampLabel.AutoSize = true;
            orderStatusDetailLastUpdatedTimestampLabel.Location = new Point(658, 265);
            orderStatusDetailLastUpdatedTimestampLabel.Name = "orderStatusDetailLastUpdatedTimestampLabel";
            orderStatusDetailLastUpdatedTimestampLabel.Size = new Size(175, 20);
            orderStatusDetailLastUpdatedTimestampLabel.TabIndex = 34;
            orderStatusDetailLastUpdatedTimestampLabel.Text = "Last Updated Timestamp";
            // 
            // orderStatusDetailLastUpdatedByLabel
            // 
            orderStatusDetailLastUpdatedByLabel.AutoSize = true;
            orderStatusDetailLastUpdatedByLabel.Location = new Point(658, 224);
            orderStatusDetailLastUpdatedByLabel.Name = "orderStatusDetailLastUpdatedByLabel";
            orderStatusDetailLastUpdatedByLabel.Size = new Size(117, 20);
            orderStatusDetailLastUpdatedByLabel.TabIndex = 33;
            orderStatusDetailLastUpdatedByLabel.Text = "Last Updated By";
            // 
            // orderStatusDetailCreatedTimestampLabel
            // 
            orderStatusDetailCreatedTimestampLabel.AutoSize = true;
            orderStatusDetailCreatedTimestampLabel.Location = new Point(658, 180);
            orderStatusDetailCreatedTimestampLabel.Name = "orderStatusDetailCreatedTimestampLabel";
            orderStatusDetailCreatedTimestampLabel.Size = new Size(139, 20);
            orderStatusDetailCreatedTimestampLabel.TabIndex = 32;
            orderStatusDetailCreatedTimestampLabel.Text = "Created Timestamp";
            // 
            // orderStatusDetailCreatedByLabel
            // 
            orderStatusDetailCreatedByLabel.AutoSize = true;
            orderStatusDetailCreatedByLabel.Location = new Point(658, 141);
            orderStatusDetailCreatedByLabel.Name = "orderStatusDetailCreatedByLabel";
            orderStatusDetailCreatedByLabel.Size = new Size(81, 20);
            orderStatusDetailCreatedByLabel.TabIndex = 31;
            orderStatusDetailCreatedByLabel.Text = "Created By";
            // 
            // orderStatusDetailOrderStatusLabel
            // 
            orderStatusDetailOrderStatusLabel.AutoSize = true;
            orderStatusDetailOrderStatusLabel.Location = new Point(107, 180);
            orderStatusDetailOrderStatusLabel.Name = "orderStatusDetailOrderStatusLabel";
            orderStatusDetailOrderStatusLabel.Size = new Size(91, 20);
            orderStatusDetailOrderStatusLabel.TabIndex = 30;
            orderStatusDetailOrderStatusLabel.Text = "Order Status";
            // 
            // orderStatusDetailOrderStatusIdLabel
            // 
            orderStatusDetailOrderStatusIdLabel.AutoSize = true;
            orderStatusDetailOrderStatusIdLabel.Location = new Point(90, 141);
            orderStatusDetailOrderStatusIdLabel.Name = "orderStatusDetailOrderStatusIdLabel";
            orderStatusDetailOrderStatusIdLabel.Size = new Size(108, 20);
            orderStatusDetailOrderStatusIdLabel.TabIndex = 28;
            orderStatusDetailOrderStatusIdLabel.Text = "Order Status Id";
            // 
            // OrderStatusDetail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(1244, 438);
            Controls.Add(orderStatusDetailUpdateOrderStatusButton);
            Controls.Add(orderStatusDetailActiveStatusCheckbox);
            Controls.Add(orderStatusDetailToggleEditModeButton);
            Controls.Add(orderStatusDetailOrderStatusIdTextbox);
            Controls.Add(orderStatusDetailOrderStatusTextbox);
            Controls.Add(orderStatusDetailCreatedTimestampTextbox);
            Controls.Add(orderStatusDetailLastUpdatedTimestampTextbox);
            Controls.Add(orderStatusDetailCreatedByTextbox);
            Controls.Add(orderStatusDetailLastUpdatedByTextbox);
            Controls.Add(orderStatusDetailLastUpdatedTimestampLabel);
            Controls.Add(orderStatusDetailLastUpdatedByLabel);
            Controls.Add(orderStatusDetailCreatedTimestampLabel);
            Controls.Add(orderStatusDetailCreatedByLabel);
            Controls.Add(orderStatusDetailOrderStatusLabel);
            Controls.Add(orderStatusDetailOrderStatusIdLabel);
            Controls.Add(orderStatusDetailTitleLabel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "OrderStatusDetail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - Order Status Detail";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label orderStatusDetailTitleLabel;
        private Button orderStatusDetailUpdateOrderStatusButton;
        private CheckBox orderStatusDetailActiveStatusCheckbox;
        private Button orderStatusDetailToggleEditModeButton;
        private TextBox orderStatusDetailOrderStatusIdTextbox;
        private TextBox orderStatusDetailOrderStatusTextbox;
        private TextBox orderStatusDetailCreatedTimestampTextbox;
        private TextBox orderStatusDetailLastUpdatedTimestampTextbox;
        private TextBox orderStatusDetailCreatedByTextbox;
        private TextBox orderStatusDetailLastUpdatedByTextbox;
        private Label orderStatusDetailLastUpdatedTimestampLabel;
        private Label orderStatusDetailLastUpdatedByLabel;
        private Label orderStatusDetailCreatedTimestampLabel;
        private Label orderStatusDetailCreatedByLabel;
        private Label orderStatusDetailOrderStatusLabel;
        private Label orderStatusDetailOrderStatusIdLabel;
    }
}