using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TempService
{
    public class UserCartWrapper
    {
        public decimal TaxCost { get; set; }
        public decimal Total { get; set; }

        public decimal DiscountPercentage { get; set; }

    }
}