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
            appConfigurationTitleLabel.Location = new Point(11, 9);
            appConfigurationTitleLabel.Margin = new Padding(2, 0, 2, 0);
            appConfigurationTitleLabel.Name = "appConfigurationTitleLabel";
            appConfigurationTitleLabel.Size = new Size(412, 32);
            appConfigurationTitleLabel.TabIndex = 0;
            appConfigurationTitleLabel.Text = "Application Configuration Settings";
            // 
            // appConfigurationDatabaseEncryptConnectionCheckbox
            // 
            appConfigurationDatabaseEncryptConnectionCheckbox.AutoSize = true;
            appConfigurationDatabaseEncryptConnectionCheckbox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            appConfigurationDatabaseEncryptConnectionCheckbox.Location = new Point(233, 197);
            appConfigurationDatabaseEncryptConnectionCheckbox.Margin = new Padding(2, 3, 2, 3);
            appConfigurationDatabaseEncryptConnectionCheckbox.Name = "appConfigurationDatabaseEncryptConnectionCheckbox";
            appConfigurationDatabaseEncryptConnectionCheckbox.Size = new Size(156, 24);
            appConfigurationDatabaseEncryptConnectionCheckbox.TabIndex = 2;
            appConfigurationDatabaseEncryptConnectionCheckbox.Text = "Encrypt Connection";
            appConfigurationDatabaseEncryptConnectionCheckbox.UseVisualStyleBackColor = true;
            // 
            // appConfigurationDatabaseServernameTextbox
            // 
            appConfigurationDatabaseServernameTextbox.Location = new Point(215, 94);
            appConfigurationDatabaseServernameTextbox.Margin = new Padding(2, 3, 2, 3);
            appConfigurationDatabaseServernameTextbox.MaxLength = 50;
            appConfigurationDatabaseServernameTextbox.Name = "appConfigurationDatabaseServernameTextbox";
            appConfigurationDatabaseServernameTextbox.Size = new Size(249, 27);
            appConfigurationDatabaseServernameTextbox.TabIndex = 0;
            // 
            // appConfigurationDatabaseNameTextbox
            // 
            appConfigurationDatabaseNameTextbox.Location = new Point(215, 144);
            appConfigurationDatabaseNameTextbox.Margin = new Padding(2, 3, 2, 3);
            appConfigurationDatabaseNameTextbox.MaxLength = 50;
            appConfigurationDatabaseNameTextbox.Name = "appConfigurationDatabaseNameTextbox";
            appConfigurationDatabaseNameTextbox.Size = new Size(249, 27);
            appConfigurationDatabaseNameTextbox.TabIndex = 1;
            // 
            // appConfigurationDatabaseServernameLabel
            // 
            appConfigurationDatabaseServernameLabel.AutoSize = true;
            appConfigurationDatabaseServernameLabel.Font = new Font("Segoe UI", 11F);
            appConfigurationDatabaseServernameLabel.Location = new Point(117, 97);
            appConfigurationDatabaseServernameLabel.Margin = new Padding(2, 0, 2, 0);
            appConfigurationDatabaseServernameLabel.Name = "appConfigurationDatabaseServernameLabel";
            appConfigurationDatabaseServernameLabel.Size = new Size(94, 20);
            appConfigurationDatabaseServernameLabel.TabIndex = 4;
            appConfigurationDatabaseServernameLabel.Text = "Server Name";
            // 
            // appConfigurationDatabaseNameLabel
            // 
            appConfigurationDatabaseNameLabel.AutoSize = true;
            appConfigurationDatabaseNameLabel.Font = new Font("Segoe UI", 11F);
            appConfigurationDatabaseNameLabel.Location = new Point(95, 147);
            appConfigurationDatabaseNameLabel.Margin = new Padding(2, 0, 2, 0);
            appConfigurationDatabaseNameLabel.Name = "appConfigurationDatabaseNameLabel";
            appConfigurationDatabaseNameLabel.Size = new Size(116, 20);
            appConfigurationDatabaseNameLabel.TabIndex = 5;
            appConfigurationDatabaseNameLabel.Text = "Database Name";
            // 
            // appConfigurationSaveSettingsButton
            // 
            appConfigurationSaveSettingsButton.FlatStyle = FlatStyle.Flat;
            appConfigurationSaveSettingsButton.Font = new Font("Segoe UI", 11F);
            appConfigurationSaveSettingsButton.Location = new Point(49, 244);
            appConfigurationSaveSettingsButton.Margin = new Padding(2, 3, 2, 3);
            appConfigurationSaveSettingsButton.Name = "appConfigurationSaveSettingsButton";
            appConfigurationSaveSettingsButton.Size = new Size(248, 67);
            appConfigurationSaveSettingsButton.TabIndex = 4;
            appConfigurationSaveSettingsButton.Text = "Save Settings";
            appConfigurationSaveSettingsButton.UseVisualStyleBackColor = true;
            appConfigurationSaveSettingsButton.Click += appConfigurationSaveSettingsButton_Click;
            // 
            // appConfigurationTestConnectionButton
            // 
            appConfigurationTestConnectionButton.FlatStyle = FlatStyle.Flat;
            appConfigurationTestConnectionButton.Font = new Font("Segoe UI", 11F);
            appConfigurationTestConnectionButton.Location = new Point(331, 244);
            appConfigurationTestConnectionButton.Margin = new Padding(2, 3, 2, 3);
            appConfigurationTestConnectionButton.Name = "appConfigurationTestConnectionButton";
            appConfigurationTestConnectionButton.Size = new Size(248, 67);
            appConfigurationTestConnectionButton.TabIndex = 3;
            appConfigurationTestConnectionButton.Text = "Test Connection";
            appConfigurationTestConnectionButton.UseVisualStyleBackColor = true;
            appConfigurationTestConnectionButton.Click += appConfigurationTestConnectionButton_Click;
            // 
            // AppConfiguration
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumPurple;
            ClientSize = new Size(624, 341);
            Controls.Add(appConfigurationTestConnectionButton);
            Controls.Add(appConfigurationSaveSettingsButton);
            Controls.Add(appConfigurationDatabaseNameLabel);
            Controls.Add(appConfigurationDatabaseServernameLabel);
            Controls.Add(appConfigurationDatabaseNameTextbox);
            Controls.Add(appConfigurationDatabaseServernameTextbox);
            Controls.Add(appConfigurationDatabaseEncryptConnectionCheckbox);
            Controls.Add(appConfigurationTitleLabel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(2, 3, 2, 3);
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