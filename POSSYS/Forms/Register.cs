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
    public partial class Register : Form
    {
        Connect con = new Connect();
        Createuser create = new Createuser();
        public Register()
        {
            InitializeComponent();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            string name = nametxt.Text.ToString();
            string password = passwordtxt.Text.ToString();
            int Active = 1;
            try
            {
                // phone_no = Convert.ToInt32(phonetxt.Text);

                if (name.Trim().Equals("") || password.Trim().Equals("") )
                {
                    MessageBox.Show("Required Fill the Fields!", "Empty Field!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Boolean insertClient = create.insertClient(name,password,Active);

                    if (insertClient)
                    {
                       
                        MessageBox.Show("New System User Create Sucessfuly!", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearbtn.PerformClick();

                    }
                    else
                    {
                        MessageBox.Show("Error System User Not Created!", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
