using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSYS.Report
{
    class customerlis
    {
        private List<Customers_List> m_customers;
        public customerlis()
        {
            Connect conn = new Connect();
            MySqlCommand command = new MySqlCommand("SELECT * FROM possys.customer WHERE `Status`!=2", conn.getConnetion());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            m_customers = new List<Customers_List>();

            foreach (DataRow row in table.Rows)
            {
                string cusid = row["ID"].ToString();
                int ID = Int32.Parse(cusid);
                Console.WriteLine(ID);
                string Name = row["Name"].ToString();
                string Phone_no = row["Phone No"].ToString();
                string Region = row["Region"].ToString();
                string Sub_Zone = row["Sub_Zone"].ToString();
                string Township = row["Township"].ToString();
                string Channel = row["Channel"].ToString();
                string status = row["Status"].ToString();
                int state = Int32.Parse(status);

                m_customers.Add(new Customers_List(ID,Name,Phone_no,Region,Sub_Zone,Township,Channel,state));
            }
        }
        public List<Customers_List> GetCustomers_Lists()
        {
            return m_customers;
        }

    }
}
