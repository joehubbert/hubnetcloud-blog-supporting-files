using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp_sandbox
{
    public partial class APISandbox : Form
    {
        private string? usNationalParkServiceAPIKey;
        private string[]? usNationalParkServiceAPIParkCode;
        private string[]? usNationalParkServiceAPIStateCode;
        private int? usNationalParkServiceAPIResultLimit;
        private int? usNationalParkServiceAPIStart;
        private string? usNationalParkServiceAPIQuery;
        private string[]? usNationalParkServiceAPISortBy;

        public APISandbox()
        {
            InitializeComponent();
        }

        private void APISandboxUSNationalParksAPISearchButton_Click(object sender, EventArgs e)
        {

        }
    }
}
