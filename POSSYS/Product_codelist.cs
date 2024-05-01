using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSYS
{
    class Product_codelist
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Pack_Size { get; set; }
        public string Category { get; set; }
        public int Factory_Price { get; set; }
        public int Status { get; set; }



        public Product_codelist(string Code, string Name)
        {
            this.Code = Code;
            this.Name = Name;
        }


    }
}
