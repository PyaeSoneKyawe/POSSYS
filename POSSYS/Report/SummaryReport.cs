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

namespace POSSYS.Report
{
    public partial class SummaryReport : Form
    {
        private List<Summary_List> m_summarylist;
        public SummaryReport()
        {
            InitializeComponent();
        }

        private void SummaryReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            m_summarylist = new List<Summary_List>();
            if (customertxt.Text != "" && invoicenumbertxt.Text == "")
            {

                String name = customertxt.Text;
                DateTime date = dateTimePicker1.Value;
                Connect conn = new Connect();
                MySqlCommand command = new MySqlCommand("select customer.Name,customer.Channel,customer.Sub_Zone,customer.Township,invoice.Item_code,invoice.Item_name,invoice.unit_Price,invoice.pay_mode,invoice.quantity,invoice.InvDate,invoice.pay_id,products.Pack_Size,products.Category,invoice_total.Tax,invoice_total.Total_amount from customer join invoice on customer.Name = invoice.customer join products on products.Code = invoice.Item_code join invoice_total on invoice_total.ID = invoice.pay_id where customer.Name =@name and invoice.InvDate = @date and invoice.Status = 2; ", conn.getConnetion());
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                DataTable table = new DataTable();
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                command.Parameters.Add("@date", MySqlDbType.Date).Value = date;
                adapter.SelectCommand = command;
                adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    string invid = row["pay_id"].ToString();
                    int payid = Int32.Parse(invid);
                    string customer_name = row["Name"].ToString();
                    string item_code = row["Item_code"].ToString();
                    string item_name = row["Item_name"].ToString();
                    string Pay_mode = row["pay_mode"].ToString();
                    string unitprice = row["unit_Price"].ToString();
                    int unit_price = Int32.Parse(unitprice);
                    string Quantity = row["quantity"].ToString();
                    int quantity = Int32.Parse(Quantity);
                    string Tax = row["Tax"].ToString();
                    int tax = Int32.Parse(Tax);
                    string totalamount = row["Total_amount"].ToString();
                    int total_amount = Int32.Parse(totalamount);
                    string invdate = row["InvDate"].ToString();
                    DateTime inv_date = DateTime.Parse(invdate);
                    string Pack_Size = row["Pack_Size"].ToString();
                    string Category = row["Category"].ToString();
                    string Sub_Zone = row["Sub_Zone"].ToString();
                    string Township = row["Township"].ToString();
                    string Channel = row["Channel"].ToString();

                    m_summarylist.Add(new Summary_List(payid,customer_name,item_code,item_name,unit_price,Pay_mode,quantity,tax,total_amount,inv_date,Pack_Size,Category,Sub_Zone,Township,Channel));
                }
                Summary_ListBindingSource.DataSource = m_summarylist;
                this.reportViewer1.RefreshReport();

            }
            else if (invoicenumbertxt.Text != "" && customertxt.Text == "")
            {
                int inv = Convert.ToInt32(invoicenumbertxt.Text);           
                DateTime date = dateTimePicker1.Value;
                Connect conn = new Connect();
                MySqlCommand command = new MySqlCommand("select customer.Name,customer.Channel,customer.Sub_Zone,customer.Township,invoice.Item_code,invoice.Item_name,invoice.unit_Price,invoice.pay_mode,invoice.quantity,invoice.InvDate,invoice.pay_id,products.Pack_Size,products.Category,invoice_total.Tax,invoice_total.Total_amount from customer join invoice on customer.Name = invoice.customer join products on products.Code = invoice.Item_code join invoice_total on invoice_total.ID = invoice.pay_id where invoice.pay_id = @inv and invoice.InvDate = @date and invoice.Status = 2; ", conn.getConnetion());
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                DataTable table = new DataTable();
                command.Parameters.Add("@inv", MySqlDbType.Int32).Value = inv;
                command.Parameters.Add("@date", MySqlDbType.Date).Value = date;
                adapter.SelectCommand = command;
                adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    string invid = row["pay_id"].ToString();
                    int payid = Int32.Parse(invid);
                    string customer_name = row["Name"].ToString();
                    string item_code = row["Item_code"].ToString();
                    string item_name = row["Item_name"].ToString();
                    string Pay_mode = row["pay_mode"].ToString();
                    string unitprice = row["unit_Price"].ToString();
                    int unit_price = Int32.Parse(unitprice);
                    string Quantity = row["quantity"].ToString();
                    int quantity = Int32.Parse(Quantity);
                    string Tax = row["Tax"].ToString();
                    int tax = Int32.Parse(Tax);
                    string totalamount = row["Total_amount"].ToString();
                    int total_amount = Int32.Parse(totalamount);
                    string invdate = row["InvDate"].ToString();
                    DateTime inv_date = DateTime.Parse(invdate);
                    string Pack_Size = row["Pack_Size"].ToString();
                    string Category = row["Category"].ToString();
                    string Sub_Zone = row["Sub_Zone"].ToString();
                    string Township = row["Township"].ToString();
                    string Channel = row["Channel"].ToString();

                    m_summarylist.Add(new Summary_List(payid, customer_name, item_code, item_name, unit_price, Pay_mode, quantity, tax, total_amount, inv_date, Pack_Size, Category, Sub_Zone, Township, Channel));
                }
                Summary_ListBindingSource.DataSource = m_summarylist;
                this.reportViewer1.RefreshReport();
            }
            else if (invoicenumbertxt.Text == "" && customertxt.Text == "")
            {
                
                DateTime date = dateTimePicker1.Value;
                Connect conn = new Connect();
                MySqlCommand command = new MySqlCommand("select customer.Name,customer.Channel,customer.Sub_Zone,customer.Township,invoice.Item_code,invoice.Item_name,invoice.unit_Price,invoice.pay_mode,invoice.quantity,invoice.InvDate,invoice.pay_id,products.Pack_Size,products.Category,invoice_total.Tax,invoice_total.Total_amount from customer join invoice on customer.Name = invoice.customer join products on products.Code = invoice.Item_code join invoice_total on invoice_total.ID = invoice.pay_id where invoice.InvDate = @date and invoice.Status = 2; ", conn.getConnetion());
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                DataTable table = new DataTable();
                command.Parameters.Add("@date", MySqlDbType.Date).Value = date;
                adapter.SelectCommand = command;
                adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    string invid = row["pay_id"].ToString();
                    int payid = Int32.Parse(invid);
                    string customer_name = row["Name"].ToString();
                    string item_code = row["Item_code"].ToString();
                    string item_name = row["Item_name"].ToString();
                    string Pay_mode = row["pay_mode"].ToString();
                    string unitprice = row["unit_Price"].ToString();
                    int unit_price = Int32.Parse(unitprice);
                    string Quantity = row["quantity"].ToString();
                    int quantity = Int32.Parse(Quantity);
                    string Tax = row["Tax"].ToString();
                    int tax = Int32.Parse(Tax);
                    string totalamount = row["Total_amount"].ToString();
                    int total_amount = Int32.Parse(totalamount);
                    string invdate = row["InvDate"].ToString();
                    DateTime inv_date = DateTime.Parse(invdate);
                    string Pack_Size = row["Pack_Size"].ToString();
                    string Category = row["Category"].ToString();
                    string Sub_Zone = row["Sub_Zone"].ToString();
                    string Township = row["Township"].ToString();
                    string Channel = row["Channel"].ToString();

                    m_summarylist.Add(new Summary_List(payid, customer_name, item_code, item_name, unit_price, Pay_mode, quantity, tax, total_amount, inv_date, Pack_Size, Category, Sub_Zone, Township, Channel));
                }
                Summary_ListBindingSource.DataSource = m_summarylist;
                this.reportViewer1.RefreshReport();
            }

        }
    }
}
