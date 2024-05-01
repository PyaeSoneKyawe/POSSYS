using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSYS
{
    
    class products
    {
        Connect con = new Connect();

        //create a function to insert a new customer
        public bool insertClient(string code,string nm, string packsize, string category,int factoryprice,int state)
        {
            MySqlCommand command = new MySqlCommand();
            string insertQuery = "INSERT INTO `possys`.`products`(`Code`,`Name`,`Pack_Size`,`Category`,`Factory_Price`,`Status`)VALUES(@code,@name,@packsize,@category,@factoryprice,@state)";
            command.CommandText = insertQuery;
            command.Connection = con.getConnetion();

            //@nm, @ph, @ad, @bp
            command.Parameters.Add("@code", MySqlDbType.VarChar).Value = code;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = nm;
            command.Parameters.Add("@packsize", MySqlDbType.VarChar).Value = packsize;
            command.Parameters.Add("@category", MySqlDbType.VarChar).Value = category;
            command.Parameters.Add("@factoryprice", MySqlDbType.Int32).Value = factoryprice;
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
        // update product
        /* UPDATE `possys`.`products` SET` `Code` = @code,`Name` = @name,`Pack_Size` = @packsize,`Category` = @category,`Factory_Price` = @factoryprice,`Status` = @state WHERE `ID` = @id;*/
        public bool updateproducts(int Id,string code, string nm, string packsize, string category, int factoryprice, int state)
        {
            MySqlCommand command = new MySqlCommand();
            String removeQuery = " UPDATE `possys`.`products` SET `Code` = @code,`Name` = @name,`Pack_Size` = @packsize,`Category` = @category,`Factory_Price` = @factoryprice,`Status` = @state WHERE `ID` = @id ";
            command.CommandText = removeQuery;
            command.Connection = con.getConnetion();

            //@eid,@nm, @ph, @ad, @bp
            command.Parameters.Add("@code", MySqlDbType.VarChar).Value = code;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = nm;
            command.Parameters.Add("@packsize", MySqlDbType.VarChar).Value = packsize;
            command.Parameters.Add("@category", MySqlDbType.VarChar).Value = category;
            command.Parameters.Add("@factoryprice", MySqlDbType.Int32).Value = factoryprice;
            command.Parameters.Add("@state", MySqlDbType.Int32).Value = state;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = Id;

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
        //delete products
        public bool removeproducts(int Id, string code, string nm, string packsize, string category, int factoryprice, int state)
        {
            MySqlCommand command = new MySqlCommand();
            String removeQuery = " UPDATE `possys`.`products` SET `Code` = @code,`Name` = @name,`Pack_Size` = @packsize,`Category` = @category,`Factory_Price` = @factoryprice,`Status` = @state WHERE `ID` = @id ";
            command.CommandText = removeQuery;
            command.Connection = con.getConnetion();

            //@eid,@nm, @ph, @ad, @bp
            command.Parameters.Add("@code", MySqlDbType.VarChar).Value = code;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = nm;
            command.Parameters.Add("@packsize", MySqlDbType.VarChar).Value = packsize;
            command.Parameters.Add("@category", MySqlDbType.VarChar).Value = category;
            command.Parameters.Add("@factoryprice", MySqlDbType.Int32).Value = factoryprice;
            command.Parameters.Add("@state", MySqlDbType.Int32).Value = state;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = Id;

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
        //for get all product

        public DataTable getproduct()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM possys.products;", con.getConnetion());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        // for get removed customer
        public DataTable getremovedproduct()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM possys.products where `Status`!= 3", con.getConnetion());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }
        // products list for report
        public DataTable getproductslist()
        {

 
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Code", Type.GetType("System.String"));
            dt.Columns.Add("Name", Type.GetType("System.String"));
            dt.Columns.Add("Pack_Size", Type.GetType("System.String"));
            dt.Columns.Add("Category", Type.GetType("System.String"));
            dt.Columns.Add("Factory_Price", Type.GetType("System.String"));
            dt.Columns.Add("Status", Type.GetType("System.String"));
            MySqlCommand command = new MySqlCommand("SELECT * FROM possys.products where `Status`!= 3  ", con.getConnetion());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = table.Rows[i]["ID"].ToString();
                dr["Code"] = table.Rows[i]["Code"].ToString();
                dr["Name"] = table.Rows[i]["Name"].ToString();
                dr["Pack_Size"] = table.Rows[i]["Pack_Size"].ToString();
                dr["Category"] = table.Rows[i]["Category"].ToString();
                dr["Factory_Price"] = table.Rows[i]["Factory_Price"].ToString();
                dr["Status"] = table.Rows[i]["Status"].ToString();
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public DataTable getproductscode()
        {
            DataTable dt = new DataTable();           
            dt.Columns.Add("Code", Type.GetType("System.String"));
            dt.Columns.Add("Name", Type.GetType("System.String"));
            MySqlCommand command = new MySqlCommand("SELECT Code,Name FROM products where Status != 3", con.getConnetion());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Code"] = table.Rows[i]["Code"].ToString();
                dr["Name"] = table.Rows[i]["Name"].ToString();
                dt.Rows.Add(dr);
            }
            return dt;

        }
    }
}
