using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp_sandbox
{
    public partial class Startup : Form
    {
        public Startup()
        {
            InitializeComponent();
        }

        private void APISandboxButton_Click(object sender, EventArgs e)
        {
            APISandbox apiSandbox = new APISandbox();
            Hide();
            apiSandbox.ShowDialog();
            Close();
        }

        private void DatabaseQueryEngineButton_Click(object sender, EventArgs e)
        {
            DatabaseQueryEngine databaseQueryEngine = new DatabaseQueryEngine();
            Hide();
            databaseQueryEngine.ShowDialog();
            Close();
        }
    }
}
