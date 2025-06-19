using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            this.aboutProductNameLabel.Text = new AssemblyAccessor().GetAssemblyProduct();
            this.aboutVersionLabel.Text = $"Version {new AssemblyAccessor().GetAssemblyVersion()}";
            this.aboutCompanyNameLabel.Text = $"{new AssemblyAccessor().GetAssemblyCompany()} © {DateTime.Now.Year}";
        }

        private void aboutOKButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}