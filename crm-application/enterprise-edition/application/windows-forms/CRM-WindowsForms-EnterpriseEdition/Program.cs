using CRM_WindowsForms_EnterpriseEdition.Presentation;

namespace CRM_WindowsForms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var splash = new Splashscreen())
            {
                splash.ShowDialog();
            }

            Application.Run(new Home());
        }
    }
}