using MySql.Data.MySqlClient;
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
    public partial class InvoiceReprint : Form
    {
        invoices inv = new invoices();
        private List<paylist> m_paylists;
        public InvoiceReprint()
        {
            InitializeComponent();
        }

        private void InvoiceReprint_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            m_paylists = new List<paylist>();
            if (invnumbertxt.Text != "")
            {

                int invnumber = Convert.ToInt32(invnumbertxt.Text);
                DateTime date = dateTimePicker1.Value;
                Connect conn = new Connect();
                MySqlCommand command = new MySqlCommand("SELECT invoice.Item_code,invoice.Item_name,invoice.unit_Price,invoice.pay_mode,invoice.quantity,invoice.InvDate,invoice_total.ID,invoice_total.Customer,invoice_total.total_Iteams,invoice_total.Amount,invoice_total.Tax,invoice_total.Total_amount,invoice_total.inv_date from invoice inner JOIN invoice_total on invoice.pay_id = invoice_total.ID where invoice.pay_id = @inv and invoice.Status = 2 and invoice.InvDate = @date ;", conn.getConnetion());
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                DataTable table = new DataTable();
                command.Parameters.Add("@inv", MySqlDbType.VarChar).Value = invnumber;
                command.Parameters.Add("@date", MySqlDbType.Date).Value = date;
                adapter.SelectCommand = command;
                adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    string invid = row["ID"].ToString();
                    int ID = Int32.Parse(invid);
                    string customer_name = row["Customer"].ToString();
                    string item_code = row["Item_code"].ToString();
                    string item_name = row["Item_name"].ToString();
                    string Pay_mode = row["pay_mode"].ToString();
                    string unitprice = row["unit_Price"].ToString();
                    int unit_price = Int32.Parse(unitprice);
                    string Quantity = row["quantity"].ToString();
                    int quantity = Int32.Parse(Quantity);
                    string totalitem = row["total_Iteams"].ToString();
                    int total_iteams = Int32.Parse(totalitem);
                    string Amount = row["Amount"].ToString();
                    int amount = Int32.Parse(Amount);
                    string Tax = row["Tax"].ToString();
                    int tax = Int32.Parse(Tax);
                    string totalamount = row["Total_amount"].ToString();
                    int total_amount = Int32.Parse(totalamount);
                    string invdate = row["inv_date"].ToString();
                    DateTime inv_date = DateTime.Parse(invdate);

                    m_paylists.Add(new paylist(ID,customer_name, item_code,item_name, unit_price, Pay_mode,quantity,total_iteams, amount, tax, total_amount,inv_date));
                }
                paylistBindingSource.DataSource = m_paylists;
                this.reportViewer1.RefreshReport();

            }

        }
    }
}
//["ID"]
//["Item_code"]
//["Item_name"]
//["Customer"]
//["pay_mode"]
//["quantity"]
//["unit_Price"]
//["total_Iteams"]
//["Tax"]
//["Amount"]
//["Total_amount"]
//["inv_date"]