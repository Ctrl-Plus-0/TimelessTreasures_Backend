using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TempService
{
    public class InvoiceWrapper
    {
        public int id;
        public int UserID;
        public int[] ProductIDs;
        public int[] QuantityProd;
        public decimal Price;
        public DateTime D;
        public DateTime Delivery;
        public string Address;
        public string Contact;
        public string receipiant;
        public string message;


        public void SetProductIDs(string[] SplitArray)
        {
            ProductIDs = new int[SplitArray.Length];

            for(int i = 0; i < SplitArray.Length; i++)
            {
                if (SplitArray[i].Equals(""))
                {
                    break;
                }
                ProductIDs[i] = int.Parse(SplitArray[i]);
            }
        }
        
        public void SetUpQuantity(string[] SplitArray)
        {
            QuantityProd = new int[SplitArray.Length];
            for(int i = 0; i < SplitArray.Length; i++)
            {
                if (SplitArray[i].Equals(""))
                {
                    break;
                }
                QuantityProd[i] = int.Parse(SplitArray[i]);
            }
        }

    }
}