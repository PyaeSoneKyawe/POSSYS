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
    public partial class ProductsReports : Form
    {
        products product = new products();
        private List<Products_List> m_products;
        public ProductsReports()
        {
            InitializeComponent();
        }

        private void ProductsReports_Load(object sender, EventArgs e)
        {
            products product = new products();
            Products_ListBindingSource.DataSource = product.getproductslist();
            this.reportViewer1.RefreshReport();
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            m_products = new List<Products_List>();
            if(codetxt.Text != "")
            {
                string code = codetxt.Text;
                Connect conn = new Connect();
                MySqlCommand command = new MySqlCommand("SELECT * FROM possys.products where `Status`!= 3 and `Code` =@code ", conn.getConnetion());
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                DataTable table = new DataTable();
                command.Parameters.Add("@code", MySqlDbType.VarChar).Value = code;
                adapter.SelectCommand = command;
                adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    string pid = row["ID"].ToString();
                    int ID = Int32.Parse(pid);
                    string Code = row["Code"].ToString();
                    string Name = row["Name"].ToString();
                    string Pack_Size = row["Pack_Size"].ToString();
                    string Category = row["Category"].ToString();
                    string fprice = row["Factory_Price"].ToString();
                    int Factory_Price = Int32.Parse(fprice);
                    string status = row["Status"].ToString();
                    int state = Int32.Parse(status);

                    m_products.Add(new Products_List(ID, Code, Name, Pack_Size, Category, Factory_Price, state));
                }
                Products_ListBindingSource.DataSource = m_products;
                this.reportViewer1.RefreshReport();

            }
            

        }
    }
}
