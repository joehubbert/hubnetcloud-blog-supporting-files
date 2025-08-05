using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            this.aboutProductNameLabel.Text = new AssemblyAccessorService().GetAssemblyProduct();
            this.aboutVersionLabel.Text = $"Version {new AssemblyAccessorService().GetAssemblyVersion()}";
            this.aboutCompanyNameLabel.Text = $"{new AssemblyAccessorService().GetAssemblyCompany()} © {DateTime.Now.Year}";
        }

        private void aboutOKButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}