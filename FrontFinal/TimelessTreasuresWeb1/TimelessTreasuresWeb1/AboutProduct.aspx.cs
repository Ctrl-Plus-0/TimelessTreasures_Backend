using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimelessTreasuresWeb1.ServiceReference1;
using System.Text;

namespace TimelessTreasuresWeb1
{
    public partial class AboutProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Service1Client Client = new Service1Client();

            int ProdID = int.Parse(Request.QueryString["Pid"]); //parse prod id and use to get specefic product

            ItemWrapper Prod = Client.GetItem(ProdID);

            if (Prod != null)
            {
                StringBuilder Sb = new StringBuilder();
                string ImgDest = Prod.Image;
                string ItemName = Prod.Title;
                string ItemDescription = Prod.Description;
                string Category = Prod.Category; //if storing many categories in one do string .replace and replace all / with ,
                decimal Price = Prod.Price;
                int ProdId = Prod.ID;

                Sb.Append(@"<div class=""product_image_area"">");
                Sb.Append(@"<div class=""container"">");
                Sb.Append(@"<div class=""row s_product_inner"">");
                Sb.Append(@"<div class=""col-lg-6"">");
                Sb.Append($@"<img class=""img-fluid"" src=""{ImgDest}"" alt=""{ItemName}"">");
                Sb.Append("</div>");
                Sb.Append(@"<div class=""col-lg-5 offset-lg-1"">");
                Sb.Append(@"<div class=""s_product_text"">");
                Sb.Append($"<h3>{ItemName}</h3>");
                Sb.Append($"<h2>R{Price}</h2>");
                Sb.Append(@"<ul class=""list"">");
                Sb.Append($@"<li><p class=""active""><span>Category</span> : {Category}</p></li>");
                Sb.Append("</ul>");
                Sb.Append($"{ItemDescription}");
                Sb.Append(@"<div class=""card_area d-flex align-items-center"">");
                Sb.Append($@"<a class=""primary-btn"" href=""ShoppingCart.aspx?Pid={ProdId}"">Add to Cart</a>");
                Sb.Append($@"<a class=""primary-btn"" href=""Wishlist.aspx?Pid={ProdId}"">Add to Wishlist</a>");
                Sb.Append("</div>");
                Sb.Append("</div>");
                Sb.Append("</div>");
                Sb.Append("</div>");
                Sb.Append("</div>");
                Sb.Append("</div>");
                AbtProd.Text = Sb.ToString();
            }


        }
    }
}