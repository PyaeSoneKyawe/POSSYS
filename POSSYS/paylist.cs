using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSYS
{
    class paylist
    {

        public int ID { get; set; }
        public string Item_code { get; set; }
        public string Item_name { get; set; }
        public string Customer { get; set; }
        public int unit_Price { get; set; }
        public string pay_mode { get; set; }
        public int quantity { get; set; }
        public int total_Iteams { get; set; }
        public int Amount { get; set; }
        public int Tax { get; set; }
        public int Total_amount { get; set; }
        public DateTime inv_date { get; set; }

        public paylist(int ID,string  customer_name, string item_code, string item_name,int unit_price,string Pay_mode, int quantity,int total_iteams,int amount, int tax, int total_amount, DateTime inv_date)
        {
            this.ID = ID;
            this.Customer = customer_name;
            this.Item_name = item_name;
            this.Item_code = item_code;
            this.unit_Price = unit_price;
            this.pay_mode = Pay_mode;
            this.quantity = quantity;
            this.total_Iteams = total_iteams;
            this.Amount = amount;
            this.Tax = tax;
            this.Total_amount = total_amount;
            this.inv_date = inv_date;
        }

    }
}
