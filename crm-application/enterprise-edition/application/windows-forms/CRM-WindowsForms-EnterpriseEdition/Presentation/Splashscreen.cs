using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class Splashscreen : Form
    {
        private System.Windows.Forms.Timer closeTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer animationTimer = new System.Windows.Forms.Timer();
        private int dotCount = 0;

        public Splashscreen()
        {
            InitializeComponent();
            closeTimer.Interval = 3000; // Set timer interval to 5 seconds
            closeTimer.Tick += (s, e) => { closeTimer.Stop(); this.Close(); };
            this.splashscreenAuthorLabel.Text = $"{new AssemblyAccessor().GetAssemblyCompany()} © {DateTime.Now.Year}";

            animationTimer.Interval = 300; // 0.3 seconds
            animationTimer.Tick += timer_Tick;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            closeTimer.Start();
            animationTimer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            dotCount = (dotCount + 1) % 4;
            splashscreenLoadingLabel.Text = "Loading" + new string('.', dotCount);
        }
    }
}