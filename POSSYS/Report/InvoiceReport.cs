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
    
    public partial class InvoiceReport : Form
    {

        public InvoiceReport()
        {
            InitializeComponent();
        }

        private void InvoiceReports_Load(object sender, EventArgs e)
        {
            DateTime invdate = DateTime.Now;
            Console.WriteLine(invdate);
            invoices inv = new invoices();
            paylistBindingSource.DataSource = inv.getinvoicelist(invdate);   
            this.reportViewer1.RefreshReport();
        }
    }
}
