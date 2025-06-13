namespace CRM_WindowsForms.Presentation
{
    partial class Splashscreen
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
            splashscreenSoftwareTitle1Label = new Label();
            splashscreenSoftwareEditionLabel = new Label();
            splashscreenAuthorLabel = new Label();
            splashscreenSoftwareTitle2Label = new Label();
            splashscreenSoftwareTitle3Label = new Label();
            splashscreenLoadingLabel = new Label();
            SuspendLayout();
            // 
            // splashscreenSoftwareTitle1Label
            // 
            splashscreenSoftwareTitle1Label.AutoSize = true;
            splashscreenSoftwareTitle1Label.Font = new Font("Segoe UI", 48F, FontStyle.Bold);
            splashscreenSoftwareTitle1Label.ForeColor = Color.Salmon;
            splashscreenSoftwareTitle1Label.Location = new Point(68, 60);
            splashscreenSoftwareTitle1Label.Name = "splashscreenSoftwareTitle1Label";
            splashscreenSoftwareTitle1Label.Size = new Size(77, 86);
            splashscreenSoftwareTitle1Label.TabIndex = 0;
            splashscreenSoftwareTitle1Label.Text = "C";
            // 
            // splashscreenSoftwareEditionLabel
            // 
            splashscreenSoftwareEditionLabel.AutoSize = true;
            splashscreenSoftwareEditionLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            splashscreenSoftwareEditionLabel.Location = new Point(77, 146);
            splashscreenSoftwareEditionLabel.Name = "splashscreenSoftwareEditionLabel";
            splashscreenSoftwareEditionLabel.Size = new Size(126, 20);
            splashscreenSoftwareEditionLabel.TabIndex = 1;
            splashscreenSoftwareEditionLabel.Text = "Enterprise Edition";
            // 
            // splashscreenAuthorLabel
            // 
            splashscreenAuthorLabel.AutoSize = true;
            splashscreenAuthorLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            splashscreenAuthorLabel.Location = new Point(12, 303);
            splashscreenAuthorLabel.Name = "splashscreenAuthorLabel";
            splashscreenAuthorLabel.Size = new Size(143, 20);
            splashscreenAuthorLabel.TabIndex = 2;
            splashscreenAuthorLabel.Text = "© Joe Hubbert 2025";
            // 
            // splashscreenSoftwareTitle2Label
            // 
            splashscreenSoftwareTitle2Label.AutoSize = true;
            splashscreenSoftwareTitle2Label.Font = new Font("Segoe UI", 48F, FontStyle.Bold);
            splashscreenSoftwareTitle2Label.ForeColor = Color.LightGreen;
            splashscreenSoftwareTitle2Label.Location = new Point(124, 60);
            splashscreenSoftwareTitle2Label.Name = "splashscreenSoftwareTitle2Label";
            splashscreenSoftwareTitle2Label.Size = new Size(79, 86);
            splashscreenSoftwareTitle2Label.TabIndex = 3;
            splashscreenSoftwareTitle2Label.Text = "R";
            // 
            // splashscreenSoftwareTitle3Label
            // 
            splashscreenSoftwareTitle3Label.AutoSize = true;
            splashscreenSoftwareTitle3Label.Font = new Font("Segoe UI", 48F, FontStyle.Bold);
            splashscreenSoftwareTitle3Label.ForeColor = Color.SkyBlue;
            splashscreenSoftwareTitle3Label.Location = new Point(181, 60);
            splashscreenSoftwareTitle3Label.Name = "splashscreenSoftwareTitle3Label";
            splashscreenSoftwareTitle3Label.Size = new Size(98, 86);
            splashscreenSoftwareTitle3Label.TabIndex = 4;
            splashscreenSoftwareTitle3Label.Text = "M";
            // 
            // splashscreenLoadingLabel
            // 
            splashscreenLoadingLabel.AutoSize = true;
            splashscreenLoadingLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            splashscreenLoadingLabel.Location = new Point(504, 303);
            splashscreenLoadingLabel.Name = "splashscreenLoadingLabel";
            splashscreenLoadingLabel.Size = new Size(63, 20);
            splashscreenLoadingLabel.TabIndex = 5;
            splashscreenLoadingLabel.Text = "Loading";
            // 
            // Splashscreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(602, 344);
            ControlBox = false;
            Controls.Add(splashscreenLoadingLabel);
            Controls.Add(splashscreenSoftwareTitle3Label);
            Controls.Add(splashscreenSoftwareTitle2Label);
            Controls.Add(splashscreenAuthorLabel);
            Controls.Add(splashscreenSoftwareEditionLabel);
            Controls.Add(splashscreenSoftwareTitle1Label);
            Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Splashscreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label splashscreenSoftwareTitle1Label;
        private Label splashscreenSoftwareEditionLabel;
        private Label splashscreenAuthorLabel;
        private Label splashscreenSoftwareTitle2Label;
        private Label splashscreenSoftwareTitle3Label;
        private Label splashscreenLoadingLabel;
    }
}