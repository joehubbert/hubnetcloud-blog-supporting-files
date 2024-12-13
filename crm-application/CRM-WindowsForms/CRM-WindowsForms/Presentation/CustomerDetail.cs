using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM_WindowsForms.Presentation
{
    public partial class CustomerDetail : Form
    {
        private readonly Guid _customerId;

        public CustomerDetail(Guid customerId)
        {
            InitializeComponent();
            _customerId = customerId;
        }
    }
}
