using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TempService
{
    public class SalesbyProduct
    {
        TempDatabaseDataContext DB = new TempDatabaseDataContext();

        public List<String> getItemNames()
        {
            dynamic prod = new List<String>();
            
            dynamic Sorted = (from i in DB.Items
                                  where i.Quantity > 0 && i.Visible_ == 1
                                  orderby i.Price descending
                                  select i).DefaultIfEmpty();

            //Instead of using the table use the wrapper and return list of the wrappers
            //used in front end as well in exact same way
            foreach (dynamic i in Sorted)
            {
                prod.Add(i.Title);
            }

            return prod;
        }

        public List<String> getItemOnHand()
        {
            dynamic prod = new List<String>();

            dynamic Sorted = (from i in DB.Items
                              where i.Quantity > 0 && i.Visible_ == 1
                              orderby i.Price descending
                              select i).DefaultIfEmpty();

            //Instead of using the table use the wrapper and return list of the wrappers
            //used in front end as well in exact same way
            foreach (dynamic i in Sorted)
            {
                prod.Add(i.Quantity);
            }

            return prod;
        }
    }
}