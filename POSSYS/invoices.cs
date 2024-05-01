using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSYS
{
    class invoices
    {
        Connect con = new Connect();

        //create a function to insert a new customer
        public bool insertClient(string customer,string code, string nm, int unit_price, string pay_mode,int quantity,int totalamount,DateTime invdate,int payid,int state)
        {
            MySqlCommand command = new MySqlCommand();
            string insertQuery = "INSERT INTO `possys`.`invoice`(`customer`,`Item_code`,`Item_name`,`unit_Price`,`pay_mode`,`quantity`,`TotalAmount`,`InvDate`,`pay_id`,`Status`)VALUES(@customer,@code,@name,@unit_price,@pay_mode,@quantity,@totalamount,@invdate,@payid,@state)";
            command.CommandText = insertQuery;
            command.Connection = con.getConnetion();

            //@customer,@code,@name,@unit_price,@tax,@pay_mode,@quantity,@totalamount,@invdate,@state
            command.Parameters.Add("@customer", MySqlDbType.VarChar).Value = customer;
            command.Parameters.Add("@code", MySqlDbType.VarChar).Value = code;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = nm;
            command.Parameters.Add("@unit_price", MySqlDbType.Int32).Value = unit_price;
            command.Parameters.Add("@pay_mode", MySqlDbType.VarChar).Value = pay_mode;
            command.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantity;
            command.Parameters.Add("@totalamount", MySqlDbType.Int32).Value = totalamount;
            command.Parameters.Add("@invdate", MySqlDbType.Date).Value = invdate;
            command.Parameters.Add("@payid", MySqlDbType.Int32).Value = payid;
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
        //delete items
        public bool removeitem(int id,string customer, string code, string nm, int unit_price, string pay_mode, int quantity, int totalamount, DateTime invdate, int state)
        {
            MySqlCommand command = new MySqlCommand();
            String removeQuery = " UPDATE `possys`.`invoice` SET `customer`= @customer,`Item_code` = @code,`Item_name`=@name,`unit_Price` = @unit_price ,`pay_mode` = @pay_mode,`quantity` = @quantity,`TotalAmount` = @totalamount,`InvDate` = @invdate,`Status` = @state WHERE `ID` = @id";
            command.CommandText = removeQuery;
            command.Connection = con.getConnetion();

            //@customer,@code,@name,@unit_price,@tax,@pay_mode,@quantity,@totalamount,@invdate,@state
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@customer", MySqlDbType.VarChar).Value = customer;
            command.Parameters.Add("@code", MySqlDbType.VarChar).Value = code;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = nm;
            command.Parameters.Add("@unit_price", MySqlDbType.Int32).Value = unit_price;
            command.Parameters.Add("@pay_mode", MySqlDbType.VarChar).Value = pay_mode;
            command.Parameters.Add("@quantity", MySqlDbType.Int32).Value = quantity;
            command.Parameters.Add("@totalamount", MySqlDbType.Int32).Value = totalamount;
            command.Parameters.Add("@invdate", MySqlDbType.Date).Value = invdate;
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
        public bool alreadypay(string customer,DateTime invdate,int state)
        {
            MySqlCommand command = new MySqlCommand();
            String removeQuery = " UPDATE `possys`.`invoice` SET `Status` = @state WHERE `customer`= @customer and `InvDate` = @invdate";
            command.CommandText = removeQuery;
            command.Connection = con.getConnetion();

            //@customer,@code,@name,@unit_price,@tax,@pay_mode,@quantity,@totalamount,@invdate,@state
           // command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@customer", MySqlDbType.VarChar).Value = customer;
            command.Parameters.Add("@invdate", MySqlDbType.Date).Value = invdate;
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
        public DataTable getactualiteam(DateTime invdate)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM possys.invoice where Status = 1 and InvDate =@invdate; ", con.getConnetion());
            command.Parameters.Add("@invdate", MySqlDbType.Date).Value = invdate;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }
        public DataTable GetTotalAmounts(DateTime invdate)
        {

            MySqlCommand command = new MySqlCommand("SELECT sum(TotalAmount) as Amount from possys.invoice where status = 1 and InvDate = @invdate;", con.getConnetion());  
            command.Parameters.Add("@invdate", MySqlDbType.Date).Value = invdate;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;

        }
        public DataTable GetTotalItems(DateTime invdate)
        {

            MySqlCommand command = new MySqlCommand("SELECT Count(ID) as Items from possys.invoice where status = 1 and InvDate = @invdate;", con.getConnetion());
            command.Parameters.Add("@invdate", MySqlDbType.Date).Value = invdate;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;

        }
        public bool inserttotal(string name,int items,int amount,int tax ,int totalamount, DateTime invdate)
        {
            MySqlCommand command = new MySqlCommand();
            string insertQuery = "INSERT INTO `possys`.`invoice_total`(`Customer`,`total_Iteams`,`Amount`,`Tax`,`Total_amount`,`inv_date`) VALUES(@name,@items,@amount,@tax,@totalamount,@invdate)";
            command.CommandText = insertQuery;
            command.Connection = con.getConnetion();

            //@customer,@code,@name,@unit_price,@tax,@pay_mode,@quantity,@totalamount,@invdate,@state
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@items", MySqlDbType.Int32).Value = items;
            command.Parameters.Add("@amount", MySqlDbType.Int32).Value = amount;
            command.Parameters.Add("@tax", MySqlDbType.Int32).Value = tax;
            command.Parameters.Add("@totalamount", MySqlDbType.Int32).Value = totalamount;
            command.Parameters.Add("@invdate", MySqlDbType.Date).Value = invdate;
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

        // invoice list for report
        public DataTable getinvoicelist(DateTime invdate)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Item_code", Type.GetType("System.String"));
            dt.Columns.Add("Item_name", Type.GetType("System.String"));
            dt.Columns.Add("Customer", Type.GetType("System.String"));
            dt.Columns.Add("pay_mode", Type.GetType("System.String"));
            dt.Columns.Add("quantity", Type.GetType("System.String"));
            dt.Columns.Add("total_Iteams", Type.GetType("System.String"));
            dt.Columns.Add("Tax", Type.GetType("System.String"));
            dt.Columns.Add("unit_Price", Type.GetType("System.String"));
            dt.Columns.Add("Amount", Type.GetType("System.String"));
            dt.Columns.Add("Total_amount", Type.GetType("System.String"));
            dt.Columns.Add("inv_date", Type.GetType("System.String"));
            MySqlCommand command = new MySqlCommand("SELECT invoice.Item_code,invoice.Item_name,invoice.unit_Price,invoice.pay_mode,invoice.quantity,invoice.InvDate,invoice_total.ID,invoice_total.Customer,invoice_total.total_Iteams,invoice_total.Amount,invoice_total.Tax,invoice_total.Total_amount,invoice_total.inv_date from invoice inner JOIN invoice_total on invoice.pay_id = invoice_total.ID where invoice.Status = 1 and invoice.InvDate = @date ; ", con.getConnetion());
            command.Parameters.Add("@date", MySqlDbType.Date).Value = invdate;
            //command.Parameters.Add("@customer", MySqlDbType.VarChar).Value = customer;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = table.Rows[i]["ID"].ToString();
                dr["Item_code"] = table.Rows[i]["Item_code"].ToString();
                dr["Item_name"] = table.Rows[i]["Item_name"].ToString();
                dr["Customer"] = table.Rows[i]["Customer"].ToString();
                dr["pay_mode"] = table.Rows[i]["pay_mode"].ToString();
                dr["quantity"] = table.Rows[i]["quantity"].ToString();
                dr["unit_Price"] = table.Rows[i]["unit_Price"].ToString();
                dr["total_Iteams"] = table.Rows[i]["total_Iteams"].ToString();
                dr["Tax"] = table.Rows[i]["Tax"].ToString();
                dr["Amount"] = table.Rows[i]["Amount"].ToString();
                dr["Total_amount"] = table.Rows[i]["Total_amount"].ToString();
                dr["inv_date"] = table.Rows[i]["inv_date"].ToString();
                dt.Rows.Add(dr);
            }
            return dt;
        }

    }
}
