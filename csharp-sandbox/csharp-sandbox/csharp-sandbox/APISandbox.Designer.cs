namespace csharp_sandbox
{
    partial class APISandbox
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
            APISandboxTabControl = new TabControl();
            APISandboxTabControlUSNationalParks = new TabPage();
            USNationalParksAPIRequestLabel = new Label();
            USNationalParksAPIRequestTextbox = new TextBox();
            USNationalParksSortByTextbox = new TextBox();
            USNationalParksSoryByLabel = new Label();
            USNationalParksQueryTextbox = new TextBox();
            USNationalParksQueryLabel = new Label();
            USNationalParksStartNumeric = new NumericUpDown();
            USNationalParksStartLabel = new Label();
            USNationalParksLimitResultsLabel = new Label();
            USNationalParksLimitResultsNumeric = new NumericUpDown();
            USNationalParksStateCodeTextBox = new TextBox();
            USNationalParksStateCodeLabel = new Label();
            USNationalParksParkCodeTextbox = new TextBox();
            USNationalParksParkCodeLabel = new Label();
            APISandboxUSNationalParksAPISearchButton = new Button();
            USNationalParksAPIResponseTextbox = new TextBox();
            USNationalParksAPIResponseLabel = new Label();
            USNationalParksAPIKeyTextBox = new TextBox();
            USNationalParksAPIKeyLabel = new Label();
            APISandboxTabControlReedJobSearch = new TabPage();
            APISandboxTabControlTransportForLondon = new TabPage();
            tabControl1 = new TabControl();
            TransportForLondonLineStatusTab = new TabPage();
            TransportForLondonArrivalsPredictionTab = new TabPage();
            TransportForLondonStationTimetable = new TabPage();
            USNationalParksAPIEndpointURLTextbox = new TextBox();
            USNationalParksAPIEndpointURLLabel = new Label();
            APISandboxTabControl.SuspendLayout();
            APISandboxTabControlUSNationalParks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)USNationalParksStartNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)USNationalParksLimitResultsNumeric).BeginInit();
            APISandboxTabControlTransportForLondon.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // APISandboxTabControl
            // 
            APISandboxTabControl.Controls.Add(APISandboxTabControlUSNationalParks);
            APISandboxTabControl.Controls.Add(APISandboxTabControlReedJobSearch);
            APISandboxTabControl.Controls.Add(APISandboxTabControlTransportForLondon);
            APISandboxTabControl.Location = new Point(12, 12);
            APISandboxTabControl.Name = "APISandboxTabControl";
            APISandboxTabControl.SelectedIndex = 0;
            APISandboxTabControl.Size = new Size(1156, 822);
            APISandboxTabControl.TabIndex = 0;
            // 
            // APISandboxTabControlUSNationalParks
            // 
            APISandboxTabControlUSNationalParks.Controls.Add(USNationalParksAPIEndpointURLLabel);
            APISandboxTabControlUSNationalParks.Controls.Add(USNationalParksAPIEndpointURLTextbox);
            APISandboxTabControlUSNationalParks.Controls.Add(USNationalParksAPIRequestLabel);
            APISandboxTabControlUSNationalParks.Controls.Add(USNationalParksAPIRequestTextbox);
            APISandboxTabControlUSNationalParks.Controls.Add(USNationalParksSortByTextbox);
            APISandboxTabControlUSNationalParks.Controls.Add(USNationalParksSoryByLabel);
            APISandboxTabControlUSNationalParks.Controls.Add(USNationalParksQueryTextbox);
            APISandboxTabControlUSNationalParks.Controls.Add(USNationalParksQueryLabel);
            APISandboxTabControlUSNationalParks.Controls.Add(USNationalParksStartNumeric);
            APISandboxTabControlUSNationalParks.Controls.Add(USNationalParksStartLabel);
            APISandboxTabControlUSNationalParks.Controls.Add(USNationalParksLimitResultsLabel);
            APISandboxTabControlUSNationalParks.Controls.Add(USNationalParksLimitResultsNumeric);
            APISandboxTabControlUSNationalParks.Controls.Add(USNationalParksStateCodeTextBox);
            APISandboxTabControlUSNationalParks.Controls.Add(USNationalParksStateCodeLabel);
            APISandboxTabControlUSNationalParks.Controls.Add(USNationalParksParkCodeTextbox);
            APISandboxTabControlUSNationalParks.Controls.Add(USNationalParksParkCodeLabel);
            APISandboxTabControlUSNationalParks.Controls.Add(APISandboxUSNationalParksAPISearchButton);
            APISandboxTabControlUSNationalParks.Controls.Add(USNationalParksAPIResponseTextbox);
            APISandboxTabControlUSNationalParks.Controls.Add(USNationalParksAPIResponseLabel);
            APISandboxTabControlUSNationalParks.Controls.Add(USNationalParksAPIKeyTextBox);
            APISandboxTabControlUSNationalParks.Controls.Add(USNationalParksAPIKeyLabel);
            APISandboxTabControlUSNationalParks.Location = new Point(4, 24);
            APISandboxTabControlUSNationalParks.Name = "APISandboxTabControlUSNationalParks";
            APISandboxTabControlUSNationalParks.Padding = new Padding(3);
            APISandboxTabControlUSNationalParks.Size = new Size(1148, 794);
            APISandboxTabControlUSNationalParks.TabIndex = 0;
            APISandboxTabControlUSNationalParks.Text = "US National Parks";
            APISandboxTabControlUSNationalParks.UseVisualStyleBackColor = true;
            // 
            // USNationalParksAPIRequestLabel
            // 
            USNationalParksAPIRequestLabel.AutoSize = true;
            USNationalParksAPIRequestLabel.Location = new Point(16, 398);
            USNationalParksAPIRequestLabel.Name = "USNationalParksAPIRequestLabel";
            USNationalParksAPIRequestLabel.Size = new Size(49, 15);
            USNationalParksAPIRequestLabel.TabIndex = 17;
            USNationalParksAPIRequestLabel.Text = "Request";
            // 
            // USNationalParksAPIRequestTextbox
            // 
            USNationalParksAPIRequestTextbox.Location = new Point(16, 425);
            USNationalParksAPIRequestTextbox.Multiline = true;
            USNationalParksAPIRequestTextbox.Name = "USNationalParksAPIRequestTextbox";
            USNationalParksAPIRequestTextbox.ReadOnly = true;
            USNationalParksAPIRequestTextbox.ScrollBars = ScrollBars.Vertical;
            USNationalParksAPIRequestTextbox.Size = new Size(549, 355);
            USNationalParksAPIRequestTextbox.TabIndex = 16;
            // 
            // USNationalParksSortByTextbox
            // 
            USNationalParksSortByTextbox.Location = new Point(6, 294);
            USNationalParksSortByTextbox.Name = "USNationalParksSortByTextbox";
            USNationalParksSortByTextbox.Size = new Size(559, 23);
            USNationalParksSortByTextbox.TabIndex = 15;
            // 
            // USNationalParksSoryByLabel
            // 
            USNationalParksSoryByLabel.AutoSize = true;
            USNationalParksSoryByLabel.Location = new Point(3, 276);
            USNationalParksSoryByLabel.Name = "USNationalParksSoryByLabel";
            USNationalParksSoryByLabel.Size = new Size(44, 15);
            USNationalParksSoryByLabel.TabIndex = 14;
            USNationalParksSoryByLabel.Text = "Sort By";
            // 
            // USNationalParksQueryTextbox
            // 
            USNationalParksQueryTextbox.Location = new Point(6, 241);
            USNationalParksQueryTextbox.Name = "USNationalParksQueryTextbox";
            USNationalParksQueryTextbox.Size = new Size(559, 23);
            USNationalParksQueryTextbox.TabIndex = 13;
            // 
            // USNationalParksQueryLabel
            // 
            USNationalParksQueryLabel.AutoSize = true;
            USNationalParksQueryLabel.Location = new Point(3, 223);
            USNationalParksQueryLabel.Name = "USNationalParksQueryLabel";
            USNationalParksQueryLabel.Size = new Size(39, 15);
            USNationalParksQueryLabel.TabIndex = 12;
            USNationalParksQueryLabel.Text = "Query";
            // 
            // USNationalParksStartNumeric
            // 
            USNationalParksStartNumeric.Location = new Point(152, 185);
            USNationalParksStartNumeric.Name = "USNationalParksStartNumeric";
            USNationalParksStartNumeric.Size = new Size(120, 23);
            USNationalParksStartNumeric.TabIndex = 11;
            // 
            // USNationalParksStartLabel
            // 
            USNationalParksStartLabel.AutoSize = true;
            USNationalParksStartLabel.Location = new Point(152, 167);
            USNationalParksStartLabel.Name = "USNationalParksStartLabel";
            USNationalParksStartLabel.Size = new Size(31, 15);
            USNationalParksStartLabel.TabIndex = 10;
            USNationalParksStartLabel.Text = "Start";
            // 
            // USNationalParksLimitResultsLabel
            // 
            USNationalParksLimitResultsLabel.AutoSize = true;
            USNationalParksLimitResultsLabel.Location = new Point(3, 167);
            USNationalParksLimitResultsLabel.Name = "USNationalParksLimitResultsLabel";
            USNationalParksLimitResultsLabel.Size = new Size(74, 15);
            USNationalParksLimitResultsLabel.TabIndex = 9;
            USNationalParksLimitResultsLabel.Text = "Limit Results";
            // 
            // USNationalParksLimitResultsNumeric
            // 
            USNationalParksLimitResultsNumeric.Location = new Point(6, 185);
            USNationalParksLimitResultsNumeric.Name = "USNationalParksLimitResultsNumeric";
            USNationalParksLimitResultsNumeric.Size = new Size(120, 23);
            USNationalParksLimitResultsNumeric.TabIndex = 0;
            USNationalParksLimitResultsNumeric.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // USNationalParksStateCodeTextBox
            // 
            USNationalParksStateCodeTextBox.Location = new Point(6, 132);
            USNationalParksStateCodeTextBox.Name = "USNationalParksStateCodeTextBox";
            USNationalParksStateCodeTextBox.Size = new Size(559, 23);
            USNationalParksStateCodeTextBox.TabIndex = 8;
            // 
            // USNationalParksStateCodeLabel
            // 
            USNationalParksStateCodeLabel.AutoSize = true;
            USNationalParksStateCodeLabel.Location = new Point(3, 114);
            USNationalParksStateCodeLabel.Name = "USNationalParksStateCodeLabel";
            USNationalParksStateCodeLabel.Size = new Size(64, 15);
            USNationalParksStateCodeLabel.TabIndex = 7;
            USNationalParksStateCodeLabel.Text = "State Code";
            // 
            // USNationalParksParkCodeTextbox
            // 
            USNationalParksParkCodeTextbox.Location = new Point(6, 79);
            USNationalParksParkCodeTextbox.Name = "USNationalParksParkCodeTextbox";
            USNationalParksParkCodeTextbox.Size = new Size(559, 23);
            USNationalParksParkCodeTextbox.TabIndex = 6;
            // 
            // USNationalParksParkCodeLabel
            // 
            USNationalParksParkCodeLabel.AutoSize = true;
            USNationalParksParkCodeLabel.Location = new Point(3, 61);
            USNationalParksParkCodeLabel.Name = "USNationalParksParkCodeLabel";
            USNationalParksParkCodeLabel.Size = new Size(61, 15);
            USNationalParksParkCodeLabel.TabIndex = 5;
            USNationalParksParkCodeLabel.Text = "Park Code";
            // 
            // APISandboxUSNationalParksAPISearchButton
            // 
            APISandboxUSNationalParksAPISearchButton.Location = new Point(235, 339);
            APISandboxUSNationalParksAPISearchButton.Name = "APISandboxUSNationalParksAPISearchButton";
            APISandboxUSNationalParksAPISearchButton.Size = new Size(117, 42);
            APISandboxUSNationalParksAPISearchButton.TabIndex = 4;
            APISandboxUSNationalParksAPISearchButton.Text = "Search";
            APISandboxUSNationalParksAPISearchButton.UseVisualStyleBackColor = true;
            APISandboxUSNationalParksAPISearchButton.Click += APISandboxUSNationalParksAPISearchButton_Click;
            // 
            // USNationalParksAPIResponseTextbox
            // 
            USNationalParksAPIResponseTextbox.Location = new Point(582, 425);
            USNationalParksAPIResponseTextbox.Multiline = true;
            USNationalParksAPIResponseTextbox.Name = "USNationalParksAPIResponseTextbox";
            USNationalParksAPIResponseTextbox.ReadOnly = true;
            USNationalParksAPIResponseTextbox.ScrollBars = ScrollBars.Vertical;
            USNationalParksAPIResponseTextbox.Size = new Size(549, 355);
            USNationalParksAPIResponseTextbox.TabIndex = 3;
            // 
            // USNationalParksAPIResponseLabel
            // 
            USNationalParksAPIResponseLabel.AutoSize = true;
            USNationalParksAPIResponseLabel.Location = new Point(582, 398);
            USNationalParksAPIResponseLabel.Name = "USNationalParksAPIResponseLabel";
            USNationalParksAPIResponseLabel.Size = new Size(57, 15);
            USNationalParksAPIResponseLabel.TabIndex = 2;
            USNationalParksAPIResponseLabel.Text = "Response";
            // 
            // USNationalParksAPIKeyTextBox
            // 
            USNationalParksAPIKeyTextBox.Location = new Point(6, 26);
            USNationalParksAPIKeyTextBox.Name = "USNationalParksAPIKeyTextBox";
            USNationalParksAPIKeyTextBox.Size = new Size(559, 23);
            USNationalParksAPIKeyTextBox.TabIndex = 1;
            // 
            // USNationalParksAPIKeyLabel
            // 
            USNationalParksAPIKeyLabel.AutoSize = true;
            USNationalParksAPIKeyLabel.Location = new Point(3, 3);
            USNationalParksAPIKeyLabel.Name = "USNationalParksAPIKeyLabel";
            USNationalParksAPIKeyLabel.Size = new Size(47, 15);
            USNationalParksAPIKeyLabel.TabIndex = 0;
            USNationalParksAPIKeyLabel.Text = "API Key";
            // 
            // APISandboxTabControlReedJobSearch
            // 
            APISandboxTabControlReedJobSearch.Location = new Point(4, 24);
            APISandboxTabControlReedJobSearch.Name = "APISandboxTabControlReedJobSearch";
            APISandboxTabControlReedJobSearch.Size = new Size(1148, 794);
            APISandboxTabControlReedJobSearch.TabIndex = 1;
            APISandboxTabControlReedJobSearch.Text = "Reed Job Search";
            APISandboxTabControlReedJobSearch.UseVisualStyleBackColor = true;
            // 
            // APISandboxTabControlTransportForLondon
            // 
            APISandboxTabControlTransportForLondon.Controls.Add(tabControl1);
            APISandboxTabControlTransportForLondon.Location = new Point(4, 24);
            APISandboxTabControlTransportForLondon.Name = "APISandboxTabControlTransportForLondon";
            APISandboxTabControlTransportForLondon.Size = new Size(1148, 794);
            APISandboxTabControlTransportForLondon.TabIndex = 2;
            APISandboxTabControlTransportForLondon.Text = "Transport for London";
            APISandboxTabControlTransportForLondon.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(TransportForLondonLineStatusTab);
            tabControl1.Controls.Add(TransportForLondonArrivalsPredictionTab);
            tabControl1.Controls.Add(TransportForLondonStationTimetable);
            tabControl1.Location = new Point(3, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1142, 788);
            tabControl1.TabIndex = 0;
            // 
            // TransportForLondonLineStatusTab
            // 
            TransportForLondonLineStatusTab.Location = new Point(4, 24);
            TransportForLondonLineStatusTab.Name = "TransportForLondonLineStatusTab";
            TransportForLondonLineStatusTab.Padding = new Padding(3);
            TransportForLondonLineStatusTab.Size = new Size(1134, 760);
            TransportForLondonLineStatusTab.TabIndex = 0;
            TransportForLondonLineStatusTab.Text = "Line Status";
            TransportForLondonLineStatusTab.UseVisualStyleBackColor = true;
            // 
            // TransportForLondonArrivalsPredictionTab
            // 
            TransportForLondonArrivalsPredictionTab.Location = new Point(4, 24);
            TransportForLondonArrivalsPredictionTab.Name = "TransportForLondonArrivalsPredictionTab";
            TransportForLondonArrivalsPredictionTab.Padding = new Padding(3);
            TransportForLondonArrivalsPredictionTab.Size = new Size(1134, 760);
            TransportForLondonArrivalsPredictionTab.TabIndex = 1;
            TransportForLondonArrivalsPredictionTab.Text = "Arrivals Prediction";
            TransportForLondonArrivalsPredictionTab.UseVisualStyleBackColor = true;
            // 
            // TransportForLondonStationTimetable
            // 
            TransportForLondonStationTimetable.Location = new Point(4, 24);
            TransportForLondonStationTimetable.Name = "TransportForLondonStationTimetable";
            TransportForLondonStationTimetable.Size = new Size(1134, 760);
            TransportForLondonStationTimetable.TabIndex = 2;
            TransportForLondonStationTimetable.Text = "Station Timetable";
            TransportForLondonStationTimetable.UseVisualStyleBackColor = true;
            // 
            // USNationalParksAPIEndpointURLTextbox
            // 
            USNationalParksAPIEndpointURLTextbox.Location = new Point(582, 26);
            USNationalParksAPIEndpointURLTextbox.Name = "USNationalParksAPIEndpointURLTextbox";
            USNationalParksAPIEndpointURLTextbox.Size = new Size(549, 23);
            USNationalParksAPIEndpointURLTextbox.TabIndex = 18;
            USNationalParksAPIEndpointURLTextbox.Text = "https://developer.nps.gov/api/v1";
            // 
            // USNationalParksAPIEndpointURLLabel
            // 
            USNationalParksAPIEndpointURLLabel.AutoSize = true;
            USNationalParksAPIEndpointURLLabel.Location = new Point(582, 3);
            USNationalParksAPIEndpointURLLabel.Name = "USNationalParksAPIEndpointURLLabel";
            USNationalParksAPIEndpointURLLabel.Size = new Size(79, 15);
            USNationalParksAPIEndpointURLLabel.TabIndex = 19;
            USNationalParksAPIEndpointURLLabel.Text = "Endpoint URL";
            // 
            // APISandbox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1180, 847);
            Controls.Add(APISandboxTabControl);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "APISandbox";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "API Sandbox";
            APISandboxTabControl.ResumeLayout(false);
            APISandboxTabControlUSNationalParks.ResumeLayout(false);
            APISandboxTabControlUSNationalParks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)USNationalParksStartNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)USNationalParksLimitResultsNumeric).EndInit();
            APISandboxTabControlTransportForLondon.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl APISandboxTabControl;
        private TabPage APISandboxTabControlUSNationalParks;
        private Label USNationalParksAPIKeyLabel;
        private TextBox USNationalParksAPIKeyTextBox;
        private Label USNationalParksAPIResponseLabel;
        private Label USNationalParksParkCodeLabel;
        private Button APISandboxUSNationalParksAPISearchButton;
        private TextBox USNationalParksAPIResponseTextbox;
        private TextBox USNationalParksParkCodeTextbox;
        private NumericUpDown USNationalParksLimitResultsNumeric;
        private TextBox USNationalParksStateCodeTextBox;
        private Label USNationalParksStateCodeLabel;
        private Label USNationalParksLimitResultsLabel;
        private Label USNationalParksQueryLabel;
        private NumericUpDown USNationalParksStartNumeric;
        private Label USNationalParksStartLabel;
        private TextBox USNationalParksSortByTextbox;
        private Label USNationalParksSoryByLabel;
        private TextBox USNationalParksQueryTextbox;
        private TabPage APISandboxTabControlReedJobSearch;
        private TabPage APISandboxTabControlTransportForLondon;
        private TabControl tabControl1;
        private TabPage TransportForLondonLineStatusTab;
        private TabPage TransportForLondonArrivalsPredictionTab;
        private TabPage TransportForLondonStationTimetable;
        private TextBox USNationalParksAPIRequestTextbox;
        private Label USNationalParksAPIRequestLabel;
        private TextBox USNationalParksAPIEndpointURLTextbox;
        private Label USNationalParksAPIEndpointURLLabel;
    }
}