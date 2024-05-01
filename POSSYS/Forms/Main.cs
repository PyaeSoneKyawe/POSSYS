using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSSYS.Forms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }


        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Customer frm = new Forms.Customer() { TopLevel = false, TopMost = true};
            mainpnl.Controls.Add(frm);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }

        private void customerReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report.CustomerReports frm = new Report.CustomerReports() { TopLevel = false, TopMost = true };
            mainpnl.Controls.Add(frm);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();

        }

        private void Main_Load(object sender, EventArgs e)
        {           
            Forms.Dashbook dashbook = new Forms.Dashbook() { TopLevel = false, TopMost = true };
            mainpnl.Controls.Add(dashbook);
            dashbook.StartPosition = FormStartPosition.CenterParent;
            dashbook.Show();
            
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Product frm = new Forms.Product() { TopLevel = false, TopMost = true };
            mainpnl.Controls.Add(frm);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
  
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void productsReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report.ProductsReports frm = new Report.ProductsReports() { TopLevel = false, TopMost = true };
            mainpnl.Controls.Add(frm);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
            
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Sales sale = new Forms.Sales() { TopLevel = false, TopMost = true };
            mainpnl.Controls.Add(sale);
            sale.StartPosition = FormStartPosition.CenterParent;
            sale.Show();

        }

        private void reprintInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.InvoiceReprint invreprint = new Forms.InvoiceReprint() { TopLevel = false, TopMost = true };
            mainpnl.Controls.Add(invreprint);
            invreprint.Show();
        }

        private void summaryReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report.SummaryReport summary = new Report.SummaryReport() { TopLevel = false, TopMost = true };
            mainpnl.Controls.Add(summary);
            summary.Show();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Backup backup = new Forms.Backup();
            backup.StartPosition = FormStartPosition.CenterParent;
            backup.Show();

        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Register register = new Forms.Register();
            register.StartPosition = FormStartPosition.CenterParent;
            register.Show();
        }
    }
}
