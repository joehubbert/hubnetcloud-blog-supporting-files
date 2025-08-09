namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    partial class ActiveCompanyConfiguration
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
            activeCompanyConfigurationTitleLabel = new Label();
            activeCompanyConfigurationCompanyConfigurationComboBoxLabel = new Label();
            activeCompanyConfigurationCompanyConfigurationComboBox = new ComboBox();
            activeCompanyConfigurationCompanyConfigurationButton = new Button();
            SuspendLayout();
            // 
            // activeCompanyConfigurationTitleLabel
            // 
            activeCompanyConfigurationTitleLabel.AutoSize = true;
            activeCompanyConfigurationTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            activeCompanyConfigurationTitleLabel.Location = new Point(13, 9);
            activeCompanyConfigurationTitleLabel.Margin = new Padding(4, 0, 4, 0);
            activeCompanyConfigurationTitleLabel.Name = "activeCompanyConfigurationTitleLabel";
            activeCompanyConfigurationTitleLabel.Size = new Size(367, 32);
            activeCompanyConfigurationTitleLabel.TabIndex = 7;
            activeCompanyConfigurationTitleLabel.Text = "Active Company Configuration";
            // 
            // activeCompanyConfigurationCompanyConfigurationComboBoxLabel
            // 
            activeCompanyConfigurationCompanyConfigurationComboBoxLabel.AutoSize = true;
            activeCompanyConfigurationCompanyConfigurationComboBoxLabel.Location = new Point(99, 53);
            activeCompanyConfigurationCompanyConfigurationComboBoxLabel.Name = "activeCompanyConfigurationCompanyConfigurationComboBoxLabel";
            activeCompanyConfigurationCompanyConfigurationComboBoxLabel.Size = new Size(167, 20);
            activeCompanyConfigurationCompanyConfigurationComboBoxLabel.TabIndex = 9;
            activeCompanyConfigurationCompanyConfigurationComboBoxLabel.Text = "Company Configuration";
            activeCompanyConfigurationCompanyConfigurationComboBoxLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // activeCompanyConfigurationCompanyConfigurationComboBox
            // 
            activeCompanyConfigurationCompanyConfigurationComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            activeCompanyConfigurationCompanyConfigurationComboBox.FormattingEnabled = true;
            activeCompanyConfigurationCompanyConfigurationComboBox.Location = new Point(272, 50);
            activeCompanyConfigurationCompanyConfigurationComboBox.Name = "activeCompanyConfigurationCompanyConfigurationComboBox";
            activeCompanyConfigurationCompanyConfigurationComboBox.Size = new Size(352, 28);
            activeCompanyConfigurationCompanyConfigurationComboBox.Sorted = true;
            activeCompanyConfigurationCompanyConfigurationComboBox.TabIndex = 0;
            // 
            // activeCompanyConfigurationCompanyConfigurationButton
            // 
            activeCompanyConfigurationCompanyConfigurationButton.FlatStyle = FlatStyle.Flat;
            activeCompanyConfigurationCompanyConfigurationButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            activeCompanyConfigurationCompanyConfigurationButton.Location = new Point(215, 99);
            activeCompanyConfigurationCompanyConfigurationButton.Margin = new Padding(2, 3, 2, 3);
            activeCompanyConfigurationCompanyConfigurationButton.Name = "activeCompanyConfigurationCompanyConfigurationButton";
            activeCompanyConfigurationCompanyConfigurationButton.Size = new Size(204, 67);
            activeCompanyConfigurationCompanyConfigurationButton.TabIndex = 1;
            activeCompanyConfigurationCompanyConfigurationButton.Text = "Save Active Company Configuration";
            activeCompanyConfigurationCompanyConfigurationButton.UseVisualStyleBackColor = true;
            activeCompanyConfigurationCompanyConfigurationButton.Click += activeCompanyConfigurationCompanyConfigurationButton_Click;
            // 
            // ActiveCompanyConfiguration
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(636, 178);
            Controls.Add(activeCompanyConfigurationCompanyConfigurationButton);
            Controls.Add(activeCompanyConfigurationCompanyConfigurationComboBoxLabel);
            Controls.Add(activeCompanyConfigurationCompanyConfigurationComboBox);
            Controls.Add(activeCompanyConfigurationTitleLabel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "ActiveCompanyConfiguration";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - Active Company Configuration";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label activeCompanyConfigurationTitleLabel;
        private Label activeCompanyConfigurationCompanyConfigurationComboBoxLabel;
        private ComboBox activeCompanyConfigurationCompanyConfigurationComboBox;
        private Button activeCompanyConfigurationCompanyConfigurationButton;
    }
}