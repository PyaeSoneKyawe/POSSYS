using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSYS
{
    class Summary_List
    {
        public string Name { get; set; }
        public string Sub_Zone { get; set; }
        public string Township { get; set; }
        public string Channel { get; set; }
        public string Item_code { get; set; }
        public string Item_name { get; set; }
        public int unit_Price { get; set; }
        public string pay_mode { get; set; }
        public int quantity { get; set; }
        public int Tax { get; set; }
        public int Total_amount { get; set; }
        public int pay_id { get; set; }
        public DateTime InvDate { get; set; }
        public string Pack_Size { get; set; }
        public string Category { get; set; }

        public Summary_List(int payid, string customer_name, string item_code, string item_name, int unit_price, string Pay_mode, int quantity,int tax, int total_amount, DateTime inv_date, string Pack_Size, string Category, string Sub_Zone, string Township, string Channel)
        {
            this.pay_id = payid;
            this.Name = customer_name;
            this.Item_name = item_name;
            this.Item_code = item_code;
            this.unit_Price = unit_price;
            this.pay_mode = Pay_mode;
            this.quantity = quantity;
            this.Tax = tax;
            this.Total_amount = total_amount;
            this.InvDate = inv_date;
            this.Pack_Size = Pack_Size;
            this.Category = Category;
            this.Sub_Zone = Sub_Zone;
            this.Township = Township;
            this.Channel = Channel;
        }
    }
}
