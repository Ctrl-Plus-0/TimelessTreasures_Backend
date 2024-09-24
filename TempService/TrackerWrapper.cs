using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TempService
{
    public class TrackerWrapper
    {
        public int ProdId { get; set; }
        public int CartID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}