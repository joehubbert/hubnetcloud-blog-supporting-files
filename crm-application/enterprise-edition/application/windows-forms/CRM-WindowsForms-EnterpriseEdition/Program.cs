using CRM.Presentation.General;

namespace CRM
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