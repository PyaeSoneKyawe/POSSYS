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

    public partial class Sales : Form
    {
        invoices inv = new invoices();



        public Sales()
        {
            InitializeComponent();
        }


        private void Sales_Load(object sender, EventArgs e)
        {
            GetInvoicenumber();
            invdatetime.Format = DateTimePickerFormat.Custom;
            // Display the date as "Mon 27 Feb 2012".  
            invdatetime.CustomFormat = "dd MM yyyy";
            Connect con = new Connect();
            MySqlCommand command = new MySqlCommand("SELECT * FROM possys.products;", con.getConnetion());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            comboBox1.ValueMember = "Code";
            comboBox1.DisplayMember = "Name";
            comboBox1.DataSource = table;
            comboBox2.Enabled = true;
            DateTime invdate = invdatetime.Value;
           // dataGridView1.DataSource = inv.getactualiteam(invdate);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            nametxt.Text =  customerlist.setvalueforcustomername;
            
        }
        //string customer,string code, string nm, int unit_price, int tax, string pay_mode,int quantity,int totalamount,DateTime invdate,int state
       



        private void searchbtn_Click(object sender, EventArgs e)
        {
            Forms.customerlist frm = new Forms.customerlist();
            frm.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string productcode = comboBox1.SelectedValue.ToString();
            productcodetxt.Text = productcode;
            /*string code = productcodetxt.Text;
            pricetxt.Text = inv.getprice(code).ToString();*/
        }

       int Maxid;
       void GetInvoicenumber()
        {
            Connect con = new Connect();
            MySqlCommand command = new MySqlCommand("SELECT Max(ID) as MaxID FROM invoice_total;", con.getConnetion());
            con.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if(reader.HasRows == true)
                {
                    Maxid = Convert.ToInt32(reader["MaxID"]);
                    Maxid = Maxid + 1;
                    invnumberlbl.Text = Maxid.ToString();
                }

                
            }          
        }

        private void productcodetxt_TextChanged(object sender, EventArgs e)
        {
            if (productcodetxt.Text != "")
            {
                string code = productcodetxt.Text;
                Connect conn = new Connect();
                MySqlCommand command = new MySqlCommand("SELECT * FROM possys.products where `Status`!= 3 and `Code` =@code ", conn.getConnetion());
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                DataTable table = new DataTable();
                command.Parameters.Add("@code", MySqlDbType.VarChar).Value = code;
                adapter.SelectCommand = command;
                adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    string fprice = row["Factory_Price"].ToString();
                    pricetxt.Text = fprice;
                }
            }
            
        }
        private void quantitytxt_TextChanged(object sender, EventArgs e)
        {
            int price;
            int quantity;
            string p = pricetxt.Text.ToString();
            if(p != "")
            {
                price = Convert.ToInt32(p);
                string q = "0";
                q = quantitytxt.Text.ToString();
                if (q != "")
                {
                    quantity = Convert.ToInt32(q);
                    int total = (price * quantity);
                    totaltxt.Text = total.ToString();
                }
                else
                {
                    q = "1";
                    quantity = Convert.ToInt32(q);
                    int total = (price * quantity);
                    totaltxt.Text = total.ToString();
                }
            }
        }
        private void clearbtn_Click(object sender, EventArgs e)
        {

            nametxt.Text = "";
            productcodetxt.Text = "0";
            pricetxt.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            totaltxt.Text = "0";
            statetxt.Text = "";
            quantitytxt.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            invnumberlbl.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            nametxt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            productcodetxt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            pricetxt.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            quantitytxt.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            totaltxt.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            statetxt.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            string customer = nametxt.Text;
            string code = productcodetxt.Text;
            string nm = comboBox1.Text.ToString();
            string pay_mode = comboBox2.Text.ToString();
            DateTime invdate = invdatetime.Value;
            int unit_price;
            int state = 1;
            int quantity;
            int totalamount;
            int payid;
            try
            {
                payid = Convert.ToInt32(invnumberlbl.Text);
                unit_price = Convert.ToInt32(pricetxt.Text);
                quantity = Convert.ToInt32(quantitytxt.Text);
                totalamount = Convert.ToInt32(totaltxt.Text);


                if (customer.Trim().Equals("") || code.Trim().Equals("") || nm.Equals("") || pay_mode.Equals("") || unit_price.Equals(""))
                {
                    MessageBox.Show("Required Fill the Fields!", "Empty Field!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    Boolean insertClient = inv.insertClient(customer, code, nm, unit_price, pay_mode, quantity, totalamount, invdate,payid, state);

                    if (insertClient)
                    {
                        //dataGridView1.DataSource = sa.getremovedproduct();
                        MessageBox.Show("New Sales Inserted Sucessfuly!", "Add Sale", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        int Amount;
                        int TotalAmount;
                        int Tax;
                        DataTable table = inv.GetTotalAmounts(invdate);
                        if (table.Rows.Count > 0)
                        {
                            amountlbl.Text = table.Rows[0]["Amount"].ToString();
                            Amount = Convert.ToInt32(table.Rows[0]["Amount"].ToString());
                            Tax = Convert.ToInt32(taxtxt.Text.ToString());
                            if (Tax != 0)
                            {
                                TotalAmount = Amount + Tax;
                                totallbl.Text = TotalAmount.ToString();
                            }
                            else
                            {
                                totallbl.Text = Amount.ToString();
                            }

                        }
                        clearbtn.PerformClick();

                    }
                    else
                    {
                        MessageBox.Show("Error Sales Not Inserted!", "Add Sale", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            dataGridView1.DataSource = inv.getactualiteam(invdate);

            int totalitems;
            DataTable tbl = inv.GetTotalItems(invdate);
            if (tbl.Rows.Count > 0)
            {
                numberofitemslbl.Text = tbl.Rows[0]["Items"].ToString();
                totalitems = Convert.ToInt32(tbl.Rows[0]["Items"].ToString());
            }

        }

        private void removebtn_Click(object sender, EventArgs e)
        {
            string customer = nametxt.Text;
            string code = productcodetxt.Text;
            string nm = comboBox1.Text.ToString();
            string pay_mode = comboBox2.Text.ToString();
            DateTime invdate = invdatetime.Value;
            int unit_price;
            int quantity;
            int totalamount;
            int id;
            try
            {
                unit_price = Convert.ToInt32(pricetxt.Text);
                quantity = Convert.ToInt32(quantitytxt.Text);
                totalamount = Convert.ToInt32(totaltxt.Text);
                id = Convert.ToInt32(invnumberlbl.Text);


                if (invnumberlbl.Text.Equals(""))
                {
                    MessageBox.Show("Please Select Items To Deleted!", "Select Items Data!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (customer.Trim().Equals("") || code.Trim().Equals("") || nm.Equals("") || pay_mode.Equals("") || unit_price.Equals(""))
                {
                    MessageBox.Show("Required Fill the Fields!", "Empty Field!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int state = 3;
                    id = Convert.ToInt32(invnumberlbl.Text);

                    Boolean insertClient = inv.removeitem(id,customer,code,nm,unit_price,pay_mode,quantity,totalamount,invdate,state);

                    if (insertClient)
                    {
                        
                        MessageBox.Show("Items Delete Sucessfully!", "Delete Items", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearbtn.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Error Items Not Deleted!", "Delete Items", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dataGridView1.DataSource = inv.getactualiteam(invdate);
            int Amount;
            int TotalAmount;
            int Tax;
            DataTable table = inv.GetTotalAmounts(invdate);
            if (table.Rows.Count > 0)
            {
                amountlbl.Text = table.Rows[0]["Amount"].ToString();
                Amount = Convert.ToInt32(table.Rows[0]["Amount"].ToString());
                Tax = Convert.ToInt32(taxtxt.Text.ToString());
                if (Tax != 0)
                {
                    TotalAmount = Amount + Tax;
                    totallbl.Text = TotalAmount.ToString();
                }
                else
                {
                    totallbl.Text = Amount.ToString();
                }

            }
            int totalitems;
            DataTable tbl = inv.GetTotalItems(invdate);
            if (tbl.Rows.Count > 0)
            {
                numberofitemslbl.Text = tbl.Rows[0]["Items"].ToString();
                totalitems = Convert.ToInt32(tbl.Rows[0]["Items"].ToString());
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Values Change","Test",MessageBoxButtons.OK);
            Console.WriteLine("Changes Ok");
        }
        private void taxtxt_TextChanged(object sender, EventArgs e)
        {
            DateTime invdate = invdatetime.Value;
            int Amount;
            int TotalAmount;
            int Tax ;
            DataTable table = inv.GetTotalAmounts(invdate);
            if (table.Rows.Count > 0)
            {
                amountlbl.Text = table.Rows[0]["Amount"].ToString();
                Amount = Convert.ToInt32(table.Rows[0]["Amount"].ToString());
                string tax = taxtxt.Text.ToString();

                if (tax != "")
                {
                    Tax = Convert.ToInt32(tax);
                    TotalAmount = Amount + Tax;
                    totallbl.Text = TotalAmount.ToString();
                }
                else
                {
                    totallbl.Text = Amount.ToString();
                }

            }
        }
        
        private void paybtn_Click(object sender, EventArgs e)
        {
            string name = nametxt.Text.ToString();
            int items;
            int amount;
            int tax ;
            int totalamount;
            DateTime invdate = invdatetime.Value;
            string customer = nametxt.Text;


            try
            {

                items = Convert.ToInt32(numberofitemslbl.Text);
                amount = Convert.ToInt32(amountlbl.Text);
                tax = Convert.ToInt32(taxtxt.Text);
                totalamount = Convert.ToInt32(totallbl.Text);
                


                if (amountlbl.Text.Trim().Equals("0") || totallbl.Text.Trim().Equals("0"))
                {
                    MessageBox.Show("Required Fill the Fields!", "Empty Field!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    Boolean insertClient = inv.inserttotal(name,items,amount,tax,totalamount,invdate);

                    if (insertClient)
                    {
                        //dataGridView1.DataSource = sa.getremovedproduct();
                        MessageBox.Show("Pay  Sucessfuly!", "Add Pay", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Report.InvoiceReport invreport = new Report.InvoiceReport();
                        invreport.Show();
                        int state = 2;
                        Boolean payClient = inv.alreadypay(customer,invdate,state);
                        GetInvoicenumber();
                        clearbtn.PerformClick();
                        numberofitemslbl.Text = "0";
                        amountlbl.Text = "0";
                        taxtxt.Text = "0";
                        totallbl.Text = "0";
                         
                    }
                    else
                    {
                        MessageBox.Show("Error Pay Not Inserted!", "Add Pay", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void invdatetime_ValueChanged(object sender, EventArgs e)
        {
            DateTime invdate = invdatetime.Value;
           // dataGridView1.DataSource = inv.getactualiteam(invdate);
        }


    }
}
