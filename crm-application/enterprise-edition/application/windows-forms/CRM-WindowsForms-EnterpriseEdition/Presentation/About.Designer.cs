namespace CRM_WindowsForms.Presentation
{
    partial class About
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            tableLayoutPanel = new TableLayoutPanel();
            logoPictureBox = new PictureBox();
            aboutProductNameLabel = new Label();
            aboutEditionLabel = new Label();
            aboutVersionLabel = new Label();
            aboutCompanyNameLabel = new Label();
            aboutOKButton = new Button();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67F));
            tableLayoutPanel.Controls.Add(logoPictureBox, 0, 0);
            tableLayoutPanel.Controls.Add(aboutProductNameLabel, 1, 0);
            tableLayoutPanel.Controls.Add(aboutEditionLabel, 1, 1);
            tableLayoutPanel.Controls.Add(aboutVersionLabel, 1, 2);
            tableLayoutPanel.Controls.Add(aboutCompanyNameLabel, 1, 3);
            tableLayoutPanel.Controls.Add(aboutOKButton, 1, 5);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(10, 10);
            tableLayoutPanel.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 6;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel.Size = new Size(487, 307);
            tableLayoutPanel.TabIndex = 0;
            // 
            // logoPictureBox
            // 
            logoPictureBox.Dock = DockStyle.Fill;
            logoPictureBox.Image = (Image)resources.GetObject("logoPictureBox.Image");
            logoPictureBox.Location = new Point(4, 3);
            logoPictureBox.Margin = new Padding(4, 3, 4, 3);
            logoPictureBox.Name = "logoPictureBox";
            tableLayoutPanel.SetRowSpan(logoPictureBox, 6);
            logoPictureBox.Size = new Size(152, 301);
            logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            logoPictureBox.TabIndex = 12;
            logoPictureBox.TabStop = false;
            // 
            // aboutProductNameLabel
            // 
            aboutProductNameLabel.Dock = DockStyle.Fill;
            aboutProductNameLabel.Font = new Font("Segoe UI", 11F);
            aboutProductNameLabel.Location = new Point(167, 0);
            aboutProductNameLabel.Margin = new Padding(7, 0, 4, 0);
            aboutProductNameLabel.MaximumSize = new Size(0, 20);
            aboutProductNameLabel.Name = "aboutProductNameLabel";
            aboutProductNameLabel.Size = new Size(316, 20);
            aboutProductNameLabel.TabIndex = 19;
            aboutProductNameLabel.Text = "CRM";
            aboutProductNameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // aboutEditionLabel
            // 
            aboutEditionLabel.Dock = DockStyle.Fill;
            aboutEditionLabel.Font = new Font("Segoe UI", 11F);
            aboutEditionLabel.Location = new Point(167, 30);
            aboutEditionLabel.Margin = new Padding(7, 0, 4, 0);
            aboutEditionLabel.MaximumSize = new Size(0, 20);
            aboutEditionLabel.Name = "aboutEditionLabel";
            aboutEditionLabel.Size = new Size(316, 20);
            aboutEditionLabel.TabIndex = 0;
            aboutEditionLabel.Text = "Enterprise Edition";
            aboutEditionLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // aboutVersionLabel
            // 
            aboutVersionLabel.Dock = DockStyle.Fill;
            aboutVersionLabel.Font = new Font("Segoe UI", 11F);
            aboutVersionLabel.Location = new Point(167, 60);
            aboutVersionLabel.Margin = new Padding(7, 0, 4, 0);
            aboutVersionLabel.MaximumSize = new Size(0, 20);
            aboutVersionLabel.Name = "aboutVersionLabel";
            aboutVersionLabel.Size = new Size(316, 20);
            aboutVersionLabel.TabIndex = 21;
            aboutVersionLabel.Text = "1.0.0.0";
            aboutVersionLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // aboutCompanyNameLabel
            // 
            aboutCompanyNameLabel.Dock = DockStyle.Fill;
            aboutCompanyNameLabel.Font = new Font("Segoe UI", 11F);
            aboutCompanyNameLabel.Location = new Point(167, 90);
            aboutCompanyNameLabel.Margin = new Padding(7, 0, 4, 0);
            aboutCompanyNameLabel.MaximumSize = new Size(0, 20);
            aboutCompanyNameLabel.Name = "aboutCompanyNameLabel";
            aboutCompanyNameLabel.Size = new Size(316, 20);
            aboutCompanyNameLabel.TabIndex = 22;
            aboutCompanyNameLabel.Text = "© Joe Hubbert 2025";
            aboutCompanyNameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // aboutOKButton
            // 
            aboutOKButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            aboutOKButton.DialogResult = DialogResult.Cancel;
            aboutOKButton.FlatStyle = FlatStyle.Flat;
            aboutOKButton.Font = new Font("Segoe UI", 11F);
            aboutOKButton.Location = new Point(395, 277);
            aboutOKButton.Margin = new Padding(4, 3, 4, 3);
            aboutOKButton.Name = "aboutOKButton";
            aboutOKButton.Size = new Size(88, 27);
            aboutOKButton.TabIndex = 24;
            aboutOKButton.Text = "&OK";
            aboutOKButton.Click += aboutOKButton_Click;
            // 
            // About
            // 
            AcceptButton = aboutOKButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(507, 327);
            Controls.Add(tableLayoutPanel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "About";
            Padding = new Padding(10);
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - About";
            tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label aboutProductNameLabel;
        private System.Windows.Forms.Label aboutEditionLabel;
        private System.Windows.Forms.Label aboutVersionLabel;
        private System.Windows.Forms.Label aboutCompanyNameLabel;
        private System.Windows.Forms.Button aboutOKButton;
    }
}