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
    public partial class Dashbook : Form
    {
        products product = new products();
        Connect con = new Connect();
        public Dashbook()
        {
            InitializeComponent();
        }


        private void Dashbook_Load(object sender, EventArgs e)
        {
            chart1.Series["Products"].XValueMember = "Item_name";
            chart1.Series["Products"].YValueMembers = "total";
            chart1.DataSource = getdashbookdata();
            chart1.DataBind();
            chart1.ResetAutoValues();
            /* MySqlCommand command = new MySqlCommand("SELECT Code,Name FROM products where Status != 3;", con.getConnetion());
             MySqlDataAdapter adapter = new MySqlDataAdapter();
             DataTable table = new DataTable();
             adapter.SelectCommand = command;
             adapter.Fill(table);
             comboBox1.ValueMember = "Code";
             comboBox1.DisplayMember = "Name";
             comboBox1.DataSource = table;
             Console.WriteLine(comboBox1.Text.ToString());*/
        }
        //select Item_name, sum(TotalAmount) as total from invoice where Status = 2 group by Item_name;
        public DataTable getdashbookdata()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Item_name", Type.GetType("System.String"));
            dt.Columns.Add("total", Type.GetType("System.String"));
            MySqlCommand command = new MySqlCommand("select Item_name,sum(quantity) as total from invoice where Status = 2 group by Item_name;", con.getConnetion());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
           // command.Parameters.Add("@code", MySqlDbType.VarChar).Value = code;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Item_name"] = table.Rows[i]["Item_name"].ToString();
                dr["total"] = table.Rows[i]["total"].ToString();
                dt.Rows.Add(dr);
            }
            return dt;

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // string code = comboBox1.SelectedValue.ToString();
            //int cod = Int32.Parse(code);
           // if (code != null)
           // {
                
                
           // }
        }
    }
}
