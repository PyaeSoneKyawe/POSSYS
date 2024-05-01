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
using System.Configuration;

namespace POSSYS.Forms
{
    public partial class Customer : Form
    {
        customers customer = new customers();
        public Customer()
        {
            InitializeComponent();

            Connect con = new Connect();
            MySqlCommand command = new MySqlCommand("SELECT * FROM possys.region_gp;", con.getConnetion());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            comboBox1.ValueMember = "RGP_ID";
            comboBox1.DisplayMember = "Name";
            comboBox1.DataSource = table;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string regid = comboBox1.SelectedValue.ToString();
            int id = Int32.Parse(regid);
            if (regid != null)
            {
                Connect con = new Connect();
                MySqlCommand command = new MySqlCommand("SELECT * FROM possys.sub_zone where REG_ID = @id  ;", con.getConnetion());
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                DataTable table = new DataTable();
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                comboBox2.ValueMember = "Sub_ID";
                comboBox2.DisplayMember = "Name";
                comboBox2.DataSource = table;
                comboBox2.Enabled = true;
                comboBox3.Enabled = false;
                comboBox4.Enabled = true;
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Subid = comboBox2.SelectedValue.ToString();
            int sub_id = Int32.Parse(Subid);
            if (Subid != null)
            {
                Connect con = new Connect();
                MySqlCommand command = new MySqlCommand("SELECT * FROM possys.township where sub_ID = @id  ;", con.getConnetion());
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                DataTable table = new DataTable();
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = sub_id;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                comboBox3.ValueMember = "TS_ID";
                comboBox3.DisplayMember = "Name";
                comboBox3.DataSource = table;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;
            }

        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedValue.ToString() != null)
            {
                Connect con = new Connect();
                MySqlCommand command = new MySqlCommand("SELECT * FROM possys.channel;", con.getConnetion());
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                DataTable table = new DataTable();
                adapter.SelectCommand = command;
                adapter.Fill(table);
                comboBox4.ValueMember = "Channel_ID";
                comboBox4.DisplayMember = "Name";
                comboBox4.DataSource = table;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;

            }
     
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            customers customer = new customers();
            dataGridView1.DataSource = customer.getremovedcustomer();
            
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            string customer_name = nametxt.Text;
            string phone_no = phonetxt.Text;
            string Region = comboBox1.Text.ToString();
            string Sub_Zone = comboBox2.Text.ToString();
            string Township = comboBox3.Text.ToString();
            string Channel = comboBox4.Text.ToString();
            int state = 1;
            try
            {
               // phone_no = Convert.ToInt32(phonetxt.Text);

                if (customer_name.Trim().Equals("") || Region.Trim().Equals("") || Sub_Zone.Equals("") || Township.Equals("")|| Channel.Equals(""))
                {
                    MessageBox.Show("Required Fill the Fields!", "Empty Field!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Boolean insertClient = customer.insertClient(customer_name,phone_no,Region, Sub_Zone,Township,Channel,state);

                    if (insertClient)
                    {
                        dataGridView1.DataSource = customer.getremovedcustomer();
                        MessageBox.Show("New Customer Inserted Sucessfuly!", "Add Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearbtn.PerformClick();

                    }
                    else
                    {
                        MessageBox.Show("Error Customers Not Inserted!", "Add Customer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void deletebtn_Click(object sender, EventArgs e)
        {
            int id;
            string customer_name = nametxt.Text;
            string phone_no = phonetxt.Text;
            string Region = comboBox1.Text.ToString();
            string Sub_Zone = comboBox2.Text.ToString();
            string Township = comboBox3.Text.ToString();
            string Channel = comboBox4.Text.ToString();



            try
            {


                if (idtxt.Text.Equals(""))
                {
                    MessageBox.Show("Please Select Customer To Delete!", "Select Customer Data!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (customer_name.Trim().Equals("") || Region.Trim().Equals("") || Sub_Zone.Equals("") || Township.Equals("") || Channel.Equals(""))
                {
                    MessageBox.Show("Required Fill the Fields!", "Empty Field!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int state = 2;
                    id = Convert.ToInt32(idtxt.Text);

                    Boolean insertClient = customer.removecustomer(id,customer_name,phone_no,Region,Sub_Zone,Township,Channel,state);

                    if (insertClient)
                    {
                        dataGridView1.DataSource = customer.getremovedcustomer();
                        MessageBox.Show("Customer Deleted Sucessfully!", "Delete Customers", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearbtn.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Error customer Not Deleted!", "Delete Customers", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idtxt.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
            nametxt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            phonetxt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            statustxt.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            idtxt.Text = "" ;
            nametxt.Text = "" ;
            phonetxt.Text = "" ;
            comboBox1.Text = "" ;
            comboBox2.Text = "" ;
            comboBox3.Text = "" ;
            comboBox4.Text = "" ;
            statustxt.Text = "" ;
        }

        private void phonetxt_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(phonetxt.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                phonetxt.Text = phonetxt.Text.Remove(phonetxt.Text.Length - 1);
            }
        }
    }
}
