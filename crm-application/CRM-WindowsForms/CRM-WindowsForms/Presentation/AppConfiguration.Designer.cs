namespace CRM_WindowsForms.Presentation
{
    partial class AppConfiguration
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
            appConfigurationTitleLabel = new Label();
            appConfigurationDatabaseEncryptConnectionCheckbox = new CheckBox();
            appConfigurationDatabaseServernameTextbox = new TextBox();
            appConfigurationDatabaseNameTextbox = new TextBox();
            appConfigurationDatabaseServernameLabel = new Label();
            appConfigurationDatabaseNameLabel = new Label();
            appConfigurationSaveSettingsButton = new Button();
            appConfigurationTestConnectionButton = new Button();
            SuspendLayout();
            // 
            // appConfigurationTitleLabel
            // 
            appConfigurationTitleLabel.AutoSize = true;
            appConfigurationTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            appConfigurationTitleLabel.Location = new Point(30, 29);
            appConfigurationTitleLabel.Name = "appConfigurationTitleLabel";
            appConfigurationTitleLabel.Size = new Size(605, 48);
            appConfigurationTitleLabel.TabIndex = 0;
            appConfigurationTitleLabel.Text = "Application Configuration Settings";
            // 
            // appConfigurationDatabaseEncryptConnectionCheckbox
            // 
            appConfigurationDatabaseEncryptConnectionCheckbox.AutoSize = true;
            appConfigurationDatabaseEncryptConnectionCheckbox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            appConfigurationDatabaseEncryptConnectionCheckbox.Location = new Point(291, 247);
            appConfigurationDatabaseEncryptConnectionCheckbox.Name = "appConfigurationDatabaseEncryptConnectionCheckbox";
            appConfigurationDatabaseEncryptConnectionCheckbox.Size = new Size(227, 34);
            appConfigurationDatabaseEncryptConnectionCheckbox.TabIndex = 1;
            appConfigurationDatabaseEncryptConnectionCheckbox.Text = "Encrypt Connection";
            appConfigurationDatabaseEncryptConnectionCheckbox.UseVisualStyleBackColor = true;
            // 
            // appConfigurationDatabaseServernameTextbox
            // 
            appConfigurationDatabaseServernameTextbox.Location = new Point(291, 123);
            appConfigurationDatabaseServernameTextbox.Name = "appConfigurationDatabaseServernameTextbox";
            appConfigurationDatabaseServernameTextbox.Size = new Size(310, 31);
            appConfigurationDatabaseServernameTextbox.TabIndex = 2;
            // 
            // appConfigurationDatabaseNameTextbox
            // 
            appConfigurationDatabaseNameTextbox.Location = new Point(291, 184);
            appConfigurationDatabaseNameTextbox.Name = "appConfigurationDatabaseNameTextbox";
            appConfigurationDatabaseNameTextbox.Size = new Size(310, 31);
            appConfigurationDatabaseNameTextbox.TabIndex = 3;
            // 
            // appConfigurationDatabaseServernameLabel
            // 
            appConfigurationDatabaseServernameLabel.AutoSize = true;
            appConfigurationDatabaseServernameLabel.Font = new Font("Segoe UI", 11F);
            appConfigurationDatabaseServernameLabel.Location = new Point(145, 122);
            appConfigurationDatabaseServernameLabel.Name = "appConfigurationDatabaseServernameLabel";
            appConfigurationDatabaseServernameLabel.Size = new Size(140, 30);
            appConfigurationDatabaseServernameLabel.TabIndex = 4;
            appConfigurationDatabaseServernameLabel.Text = "Server Name";
            // 
            // appConfigurationDatabaseNameLabel
            // 
            appConfigurationDatabaseNameLabel.AutoSize = true;
            appConfigurationDatabaseNameLabel.Font = new Font("Segoe UI", 11F);
            appConfigurationDatabaseNameLabel.Location = new Point(119, 183);
            appConfigurationDatabaseNameLabel.Name = "appConfigurationDatabaseNameLabel";
            appConfigurationDatabaseNameLabel.Size = new Size(166, 30);
            appConfigurationDatabaseNameLabel.TabIndex = 5;
            appConfigurationDatabaseNameLabel.Text = "Database Name";
            // 
            // appConfigurationSaveSettingsButton
            // 
            appConfigurationSaveSettingsButton.FlatStyle = FlatStyle.Flat;
            appConfigurationSaveSettingsButton.Font = new Font("Segoe UI", 11F);
            appConfigurationSaveSettingsButton.Location = new Point(61, 305);
            appConfigurationSaveSettingsButton.Name = "appConfigurationSaveSettingsButton";
            appConfigurationSaveSettingsButton.Size = new Size(310, 84);
            appConfigurationSaveSettingsButton.TabIndex = 6;
            appConfigurationSaveSettingsButton.Text = "Save Settings";
            appConfigurationSaveSettingsButton.UseVisualStyleBackColor = true;
            appConfigurationSaveSettingsButton.Click += appConfigurationSaveSettingsButton_Click;
            // 
            // appConfigurationTestConnectionButton
            // 
            appConfigurationTestConnectionButton.FlatStyle = FlatStyle.Flat;
            appConfigurationTestConnectionButton.Font = new Font("Segoe UI", 11F);
            appConfigurationTestConnectionButton.Location = new Point(415, 305);
            appConfigurationTestConnectionButton.Name = "appConfigurationTestConnectionButton";
            appConfigurationTestConnectionButton.Size = new Size(310, 84);
            appConfigurationTestConnectionButton.TabIndex = 7;
            appConfigurationTestConnectionButton.Text = "Test Connection";
            appConfigurationTestConnectionButton.UseVisualStyleBackColor = true;
            appConfigurationTestConnectionButton.Click += appConfigurationTestConnectionButton_Click;
            // 
            // AppConfiguration
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumPurple;
            ClientSize = new Size(780, 426);
            Controls.Add(appConfigurationTestConnectionButton);
            Controls.Add(appConfigurationSaveSettingsButton);
            Controls.Add(appConfigurationDatabaseNameLabel);
            Controls.Add(appConfigurationDatabaseServernameLabel);
            Controls.Add(appConfigurationDatabaseNameTextbox);
            Controls.Add(appConfigurationDatabaseServernameTextbox);
            Controls.Add(appConfigurationDatabaseEncryptConnectionCheckbox);
            Controls.Add(appConfigurationTitleLabel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "AppConfiguration";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - App Configuration";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label appConfigurationTitleLabel;
        private CheckBox appConfigurationDatabaseEncryptConnectionCheckbox;
        private TextBox appConfigurationDatabaseServernameTextbox;
        private TextBox appConfigurationDatabaseNameTextbox;
        private Label appConfigurationDatabaseServernameLabel;
        private Label appConfigurationDatabaseNameLabel;
        private Button appConfigurationSaveSettingsButton;
        private Button appConfigurationTestConnectionButton;
    }
}