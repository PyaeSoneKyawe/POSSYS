using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSYS.Forms
{
    class SubZonelis

    {

        private List<Subzonelist> m_subzone;
        public SubZonelis()
        {
            Connect con = new Connect();
            MySqlCommand command = new MySqlCommand("SELECT * FROM possys.region_gp;", con.getConnetion());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            m_subzone = new List<Subzonelist>();

            foreach (DataRow row in table.Rows)
            {

                string Name = row["Name"].ToString();

                m_subzone.Add(new Subzonelist(Name));
            }
        }
        public List<Subzonelist> GetEmployees()
        {
            return m_subzone;
        }
    }
}
