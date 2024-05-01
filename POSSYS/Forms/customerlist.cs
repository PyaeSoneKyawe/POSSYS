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
    public partial class customerlist : Form
    {
        public static string setvalueforcustomername = "";
        customers customer = new customers();
       
        public customerlist()
        {
            InitializeComponent();
        }
        private void customerlist_Load(object sender, EventArgs e)
        {
            customers customer = new customers();
            dataGridView1.DataSource = customer.getremovedcustomer();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            setvalueforcustomername = name.ToString();
            Console.WriteLine(name);
            this.Close();
        }
    }
}
