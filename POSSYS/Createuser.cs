using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSYS
{
    class Createuser
    {
        Connect con = new Connect();

        public bool insertClient(string name, string password, int Active)
        {
            MySqlCommand command = new MySqlCommand();
            string insertQuery = "INSERT INTO `login_user`(`Name`,`Passwrod`,`IsActive`)VALUES(@name,@password,@Active)";
            command.CommandText = insertQuery;
            command.Connection = con.getConnetion();
            //@nm, @ph, @ad, @bp
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
            command.Parameters.Add("@Active", MySqlDbType.VarChar).Value = Active;

            con.openConnection();

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
    }
}
