
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace POSSYS
{
    public partial class Loginfrm : Form
    {
        public Loginfrm()
        {
            InitializeComponent();
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        Connect conn = new Connect();
        private void loginbtn_Click(object sender, EventArgs e)
        {
            Connect conn = new Connect();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand();
            String query = "SELECT * FROM login_user WHERE `Name`= @usn and `Passwrod`= @pass and IsActive = 1";
            Console.WriteLine(query);

            command.CommandText = query;
            command.Connection = conn.getConnetion();

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = nametxt.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = passwordtxt.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            // if the username and the password exists
            if (table.Rows.Count > 0)
            {
                // show the main form
                this.Hide();
                Forms.Main mform = new Forms.Main();
                mform.Show();

            }
            else
            {
                if (nametxt.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Enter Your Username to Login", "Empty Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (passwordtxt.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Enter Your Password to Login", "Empty Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("This Username Or Password Doesn't Exists", "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
