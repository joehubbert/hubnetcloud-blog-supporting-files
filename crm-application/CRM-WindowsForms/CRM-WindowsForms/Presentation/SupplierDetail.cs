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
    public partial class SupplierDetail : Form
    {
        private readonly Guid _supplierId;

        public SupplierDetail(Guid supplierId)
        {
            InitializeComponent();
            _supplierId = supplierId;
        }
    }
}
