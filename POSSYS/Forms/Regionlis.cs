using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSYS.Forms
{
    class Regionlis
    {
        private List<Regionlist> m_region;
        public Regionlis()
        {
            Connect con = new Connect();
            MySqlCommand command = new MySqlCommand("SELECT * FROM possys.region_gp;", con.getConnetion());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            m_region = new List<Regionlist>();

            foreach (DataRow row in table.Rows)
            {

                string Name = row["Name"].ToString();
                
                m_region.Add(new Regionlist (Name));
            }
        }
        public List<Regionlist> GetEmployees()
        {
            return m_region;
        }
    }
}
