using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimelessTreasuresWeb1.ServiceReference1;
namespace TimelessTreasuresWeb1
{
    public partial class Shop : System.Web.UI.Page
    {
         
        protected void Page_Load(object sender, EventArgs e)
        {
            Service1Client Client = new Service1Client();
            if (!IsPostBack)
            {
				//get the items unsorted
				//later depending on the 
				//dynamic Items = Client.getItems(0);

				dynamic prod = Client.getItems(0);
				DisplayProducts(prod);
			}
			
        }

        private void DisplayProducts (dynamic Products)
        {
            Service1Client Client = new Service1Client();

			StringBuilder SB = new StringBuilder();
			foreach (ItemWrapper I in Products)
            {
				
				string ImgDest = I.Image;
				string ItemName = I.Title;
				decimal Price = I.Price;
				int ProdId = I.ID;

				
				SB.Append(@"<div class=""col-lg-4 col-md-6"">");
				SB.Append(@"<div class=""single-product"">");
				SB.Append($@"<a href =""AboutProduct.aspx?Pid={ProdId}"">");
				SB.Append($@"<img class=""img-fluid"" src=""{ImgDest}"" alt=""{ItemName}""> </a>"); 
				SB.Append(@"<div class=""product-details"">");
				SB.Append($"<h6>{ItemName}</h6>");
				SB.Append(@"<div class=""price"">");
				SB.Append($"<h6>R{Price}</h6>");
				SB.Append("</div>");
				SB.Append(@"<div class=""prd-bottom"">");
				SB.Append($@"<a href =""ShoppingCart.aspx?Pid={ProdId}"" class=""social-info"">");
				SB.Append(@"<span class=""ti-bag""></span>");
				SB.Append(@"<p class=""hover-text"">Add To Bag</p>");
				SB.Append("</a>");
				SB.Append($@"<a href =""Wishlist.aspx?Pid={ProdId}"" class=""social-info"">");
				SB.Append(@"<span class=""lnr lnr-heart""></span>");
				SB.Append(@"<p class=""hover-text"">Wishlist</p>");
				SB.Append("</a>");
				SB.Append("</div>");
				SB.Append("</div>");
				SB.Append("</div>");
				SB.Append("</div>");

				Product.Text = SB.ToString();

			}

		}

        protected void SortList_SelectedIndexChanged(object sender, EventArgs e)
        {
			Service1Client Client = new Service1Client();

			dynamic Prods = Client.getItems(int.Parse(SortList.SelectedValue));

			DisplayProducts(Prods);
		}
    }
}