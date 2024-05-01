using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSYS
{
    class Products_List
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Pack_Size { get; set; }
        public string Category { get; set; }
        public int Factory_Price { get; set; }
        public int Status { get; set; }

        public Products_List(int ID, string Code, string Name, string Pack_Size, string Category,int Factory_Price, int state)
        {
            this.ID = ID;
            this.Code = Code;
            this.Name = Name;
            this.Pack_Size = Pack_Size;
            this.Category = Category;
            this.Factory_Price = Factory_Price;
            this.Status = state;
        }
    }
}
