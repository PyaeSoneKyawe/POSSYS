using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSYS
{
    class Customers_List
    {
        public int Customer_ID { get; set; }
        public string Name { get; set; }
        public string Phone_no { get; set; }
        public string Region { get; set; }
        public string Sub_Zone { get; set; }
        public string Township { get; set; }
        public string Channel { get; set; }
        public int Status { get; set; }

        public Customers_List(int ID, string Name, string Phone_no, string Region, string Sub_Zone, string Township, string Channel, int state)
        {
            this.Customer_ID = ID;this.Name = Name;
            this.Phone_no = Phone_no;
            this.Region = Region;
            this.Sub_Zone = Sub_Zone;
            this.Township = Township;
            this.Channel = Channel;
            
            this.Status = state;
        }
    }
}
