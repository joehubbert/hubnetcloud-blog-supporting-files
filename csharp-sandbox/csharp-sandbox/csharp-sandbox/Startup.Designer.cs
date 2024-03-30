namespace csharp_sandbox
{
    partial class Startup
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
            APISandboxButton = new Button();
            DatabaseQueryEngineButton = new Button();
            SuspendLayout();
            // 
            // APISandboxButton
            // 
            APISandboxButton.Location = new Point(92, 12);
            APISandboxButton.Name = "APISandboxButton";
            APISandboxButton.Size = new Size(144, 45);
            APISandboxButton.TabIndex = 0;
            APISandboxButton.Text = "API Sandbox";
            APISandboxButton.UseVisualStyleBackColor = true;
            APISandboxButton.Click += APISandboxButton_Click;
            // 
            // DatabaseQueryEngineButton
            // 
            DatabaseQueryEngineButton.Location = new Point(92, 77);
            DatabaseQueryEngineButton.Name = "DatabaseQueryEngineButton";
            DatabaseQueryEngineButton.Size = new Size(144, 45);
            DatabaseQueryEngineButton.TabIndex = 1;
            DatabaseQueryEngineButton.Text = "Database Query Engine";
            DatabaseQueryEngineButton.UseVisualStyleBackColor = true;
            DatabaseQueryEngineButton.Click += DatabaseQueryEngineButton_Click;
            // 
            // Startup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(339, 146);
            Controls.Add(DatabaseQueryEngineButton);
            Controls.Add(APISandboxButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Startup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Startup";
            ResumeLayout(false);
        }

        #endregion

        private Button APISandboxButton;
        private Button DatabaseQueryEngineButton;
    }
}