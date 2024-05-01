using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSYS
{
    
    class customers
    {
        Connect con = new Connect();

        //create a function to insert a new customer
        public bool insertClient( string nm, string ph, string reg, string sub, string tow, string cha,int state)
        {
            MySqlCommand command = new MySqlCommand();
            string insertQuery = "INSERT INTO `possys`.`customer`(`Name`,`Phone_no`,`Region`,`Sub_Zone`,`Township`,`Channel`,`Status`)VALUES(@nm,@ph,@reg,@sub,@tow,@cha,@state)";
            command.CommandText = insertQuery;
            command.Connection = con.getConnetion();

            //@nm, @ph, @ad, @bp
            command.Parameters.Add("@nm", MySqlDbType.VarChar).Value = nm;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = ph;
            command.Parameters.Add("@reg", MySqlDbType.VarChar).Value = reg;
            command.Parameters.Add("@sub", MySqlDbType.VarChar).Value = sub;
            command.Parameters.Add("@tow", MySqlDbType.VarChar).Value = tow;
            command.Parameters.Add("@cha", MySqlDbType.VarChar).Value = cha;
            command.Parameters.Add("@state", MySqlDbType.Int32).Value = state;
            con.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                con.closeConnection();
                return true;
            }
            else
            {
                con.closeConnection();
                return false;
            }
        }

        // create a unction to delete the select customers
        /*        UPDATE `possys`.`customer`SET `Name` = @nm,`Phone_no` = @ph, `Region` = @reg,`Sub_Zone` = @sub,`Township` = @tow,`Channel` = @cha,`Status` = @state WHERE `Customer_ID` = @id;*/

        public bool removecustomer(int id ,string nm, string ph, string reg, string sub, string tow, string cha, int state)
        {
            MySqlCommand command = new MySqlCommand();
            String removeQuery = "UPDATE `possys`.`customer`SET `Name` = @nm,`Phone_no` = @ph, `Region` = @reg,`Sub_Zone` = @sub,`Township` = @tow,`Channel` = @cha,`Status` = @state WHERE `Customer_ID` = @id ";
            command.CommandText = removeQuery;
            command.Connection = con.getConnetion();

            //@eid,@nm, @ph, @ad, @bp
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@nm", MySqlDbType.VarChar).Value = nm;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = ph;
            command.Parameters.Add("@reg", MySqlDbType.VarChar).Value = reg;
            command.Parameters.Add("@sub", MySqlDbType.VarChar).Value = sub;
            command.Parameters.Add("@tow", MySqlDbType.VarChar).Value = tow;
            command.Parameters.Add("@cha", MySqlDbType.VarChar).Value = cha;
            command.Parameters.Add("@state", MySqlDbType.Int32).Value = state;

            con.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                con.closeConnection();
                return true;
            }
            else
            {
                con.closeConnection();
                return false;
            }
        }

        public DataTable getRegions()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", Type.GetType("System.String"));
            MySqlCommand command = new MySqlCommand("SELECT * FROM possys.region_gp;", con.getConnetion());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Name"] = table.Rows[i]["Name"].ToString();
                dt.Rows.Add(dr);
            }
            return dt;
        }
        //for get all customer
        public DataTable getcustomer()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM possys.customer", con.getConnetion());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        // for get removed customer
        public DataTable getremovedcustomer()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM possys.customer where `Status`!= 2", con.getConnetion());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        // get customer list for report
        public DataTable getcustomerslist()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Customer_ID", Type.GetType("System.String"));
            dt.Columns.Add("Name", Type.GetType("System.String"));
            dt.Columns.Add("Phone_no", Type.GetType("System.String"));
            dt.Columns.Add("Region", Type.GetType("System.String"));
            dt.Columns.Add("Sub_Zone", Type.GetType("System.String"));
            dt.Columns.Add("Township", Type.GetType("System.String"));
            dt.Columns.Add("Channel", Type.GetType("System.String"));
            dt.Columns.Add("Status", Type.GetType("System.String"));
            MySqlCommand command = new MySqlCommand("SELECT * FROM possys.customer where `Status`!= 2", con.getConnetion());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Customer_ID"] = table.Rows[i]["ID"].ToString();
                dr["Name"] = table.Rows[i]["Name"].ToString();
                dr["Phone_no"] = table.Rows[i]["Phone_no"].ToString();
                dr["Region"] = table.Rows[i]["Region"].ToString();
                dr["Sub_Zone"] = table.Rows[i]["Sub_Zone"].ToString();
                dr["Township"] = table.Rows[i]["Township"].ToString();
                dr["Channel"] = table.Rows[i]["Channel"].ToString();
                dr["Status"] = table.Rows[i]["Status"].ToString();
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public DataTable getSubZones()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", Type.GetType("System.String"));
            MySqlCommand command = new MySqlCommand("SELECT * FROM possys.sub_zone;", con.getConnetion());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Name"] = table.Rows[i]["Name"].ToString();
                dt.Rows.Add(dr);
            }
            return dt;
        }

    }
}
