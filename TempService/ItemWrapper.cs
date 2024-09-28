using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TempService
{
    public class ItemWrapper
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
      
        public int Visibility { get; set; }
        public int Quantity { get; set; }
       
        public int NumSold { get; set; }
    }
}