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
    public partial class Product : Form
    {
        products product = new products();

        public Product()
        {
            InitializeComponent();

            Connect con = new Connect();
            MySqlCommand command = new MySqlCommand("SELECT * FROM possys.product_pack_size;", con.getConnetion());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            comboBox1.ValueMember = "size_id";
            comboBox1.DisplayMember = "name";
            comboBox1.DataSource = table;
            Console.WriteLine(comboBox1.Text.ToString());
            comboBox2.Enabled = false;

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idtxt.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            nametxt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            codetxt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            pricetxt.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            statetxt.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Connect con = new Connect();
            MySqlCommand command = new MySqlCommand("SELECT * FROM possys.product_category;", con.getConnetion());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            comboBox2.ValueMember = "category_id";
            comboBox2.DisplayMember = "name";
            comboBox2.DataSource = table;
            Console.WriteLine(comboBox2.Text.ToString());
            comboBox2.Enabled = true;

        }
        private void codetxt_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(codetxt.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                codetxt.Text = codetxt.Text.Remove(codetxt.Text.Length - 1);
            }
        }

        private void Product_Load(object sender, EventArgs e)
        {
            customers customer = new customers();
            dataGridView1.DataSource = product.getremovedproduct();
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            codetxt.Text = "";
            idtxt.Text = "";
            statetxt.Text = "";
            nametxt.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            pricetxt.Text = "";
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            string product_name = nametxt.Text;
            string code_id = codetxt.Text;
            string packsize = comboBox1.Text.ToString();
            string category = comboBox2.Text.ToString();
            int price;
            int state = 1;
            //int id;
            try
            {
                price = Convert.ToInt32(pricetxt.Text);
                //id = Convert.ToInt32(idtxt.Text);
                // phone_no = Convert.ToInt32(phonetxt.Text);

                if (product_name.Trim().Equals("") || code_id.Trim().Equals("") || packsize.Equals("") || category.Equals("") || price.Equals(""))
                {
                    MessageBox.Show("Required Fill the Fields!", "Empty Field!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    
                    Boolean insertClient = product.insertClient(code_id, product_name, packsize, category, price, state);

                    if (insertClient)
                    {
                        dataGridView1.DataSource = product.getremovedproduct();
                        MessageBox.Show("New Products Inserted Sucessfuly!", "Add Products", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearbtn.PerformClick();

                    }
                    else
                    {
                        MessageBox.Show("Error Products Not Inserted!", "Add Products", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            int id;
            string product_name = nametxt.Text;
            string code_id = codetxt.Text;
            string packsize = comboBox1.Text.ToString();
            string category = comboBox2.Text.ToString();
            int price;


            try
            {
                price = Convert.ToInt32(pricetxt.Text);


                if (idtxt.Text.Equals(""))
                {
                    MessageBox.Show("Please Select Products To Update!", "Select Products Data!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (product_name.Trim().Equals("") || code_id.Trim().Equals("") || packsize.Equals("") || category.Equals("") || price.Equals(""))
                {
                    MessageBox.Show("Required Fill the Fields!", "Empty Field!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int state = 2;
                    id = Convert.ToInt32(idtxt.Text);

                    Boolean insertClient = product.updateproducts(id, code_id, product_name, packsize, category, price, state);

                    if (insertClient)
                    {
                        dataGridView1.DataSource = product.getremovedproduct();
                        MessageBox.Show("Customer Update Sucessfully!", "Update Products", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearbtn.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Error  Not Updated!", "Update Products", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string product_name = nametxt.Text;
            string code_id = codetxt.Text;
            string packsize = comboBox1.Text.ToString();
            string category = comboBox2.Text.ToString();
            int price;


            try
            {
                price = Convert.ToInt32(pricetxt.Text);


                if (idtxt.Text.Equals(""))
                {
                    MessageBox.Show("Please Select Products To Deleted!", "Select Products Data!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (product_name.Trim().Equals("") || code_id.Trim().Equals("") || packsize.Equals("") || category.Equals("") || price.Equals(""))
                {
                    MessageBox.Show("Required Fill the Fields!", "Empty Field!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int state = 3;
                    id = Convert.ToInt32(idtxt.Text);

                    Boolean insertClient = product.removeproducts(id, code_id, product_name, packsize, category, price, state);

                    if (insertClient)
                    {
                        dataGridView1.DataSource = product.getremovedproduct();
                        MessageBox.Show("Products Delete Sucessfully!", "Delete Products", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearbtn.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Error Products Not Deleted!", "Delete Products", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



    }
}
