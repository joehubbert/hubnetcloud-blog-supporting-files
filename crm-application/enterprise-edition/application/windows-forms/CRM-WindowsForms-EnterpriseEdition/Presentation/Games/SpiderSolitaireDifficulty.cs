namespace CRM.Presentation.Games
{
    public partial class SpiderSolitaireDifficulty : Form
    {
        public int SelectedSuitCount { get; private set; } = 4;

        public SpiderSolitaireDifficulty(int currentSuitCount)
        {
            Text = "Select Difficulty";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = MinimizeBox = false;
            Width = 300;
            Height = 200;

            var panel = new Panel { Left = 10, Top = 10, Width = 240, Height = 120 };
            var rb1 = new RadioButton { Text = "1 Suit (Easy)", Left = 10, Top = 10, Width = 200, Checked = currentSuitCount == 1 };
            var rb2 = new RadioButton { Text = "2 Suits (Medium)", Left = 10, Top = 35, Width = 200, Checked = currentSuitCount == 2 };
            var rb3 = new RadioButton { Text = "3 Suits (Hard)", Left = 10, Top = 60, Width = 200, Checked = currentSuitCount == 3 };
            var rb4 = new RadioButton { Text = "4 Suits (Expert)", Left = 10, Top = 85, Width = 200, Checked = currentSuitCount == 4 };

            panel.Controls.AddRange(new Control[] { rb1, rb2, rb3, rb4 });
            Controls.Add(panel);

            var okBtn = new Button { Text = "OK", DialogResult = DialogResult.OK, Left = 60, Top = 130, Width = 70 };
            var cancelBtn = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel, Left = 150, Top = 130, Width = 70 };
            Controls.Add(okBtn);
            Controls.Add(cancelBtn);

            AcceptButton = okBtn;
            CancelButton = cancelBtn;

            okBtn.Click += (s, e) =>
            {
                if (rb1.Checked) SelectedSuitCount = 1;
                else if (rb2.Checked) SelectedSuitCount = 2;
                else if (rb3.Checked) SelectedSuitCount = 3;
                else SelectedSuitCount = 4;
            };
        }
    }
}