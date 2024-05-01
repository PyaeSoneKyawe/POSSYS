using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSSYS.Report
{
    public partial class CustomerReports : Form
    {
        public CustomerReports()
        {
            InitializeComponent();
        }

        private void CustomerReports_Load(object sender, EventArgs e)
        {

            customers customer = new customers();
            Customers_ListBindingSource.DataSource =customer.getcustomerslist();
            this.reportViewer1.RefreshReport();    
        }
    }
}
