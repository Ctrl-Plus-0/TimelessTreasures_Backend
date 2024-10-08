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

				//stores all the products
				dynamic prod = Client.getItems(0);
				ViewState["AllProducts"] = prod;

				DisplayDealsOfTheWeek(prod);

				


				

				//sets defaults
				int itemsPerPageInt = int.Parse(ItemsPerPage.SelectedValue);
				int currentPage = 1;


				dynamic productsToDisplay = GetPagedProducts(prod, itemsPerPageInt, currentPage);
			
				DisplayProducts(productsToDisplay);
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
			int sortOption = int.Parse((sender as DropDownList).SelectedValue);

			SortList.SelectedValue = sortOption.ToString();
			SortList2.SelectedValue = sortOption.ToString();

			dynamic allSortedProducts = Client.getItems(sortOption);
			ViewState["AllProducts"] = allSortedProducts;

			int itemsPerPage = int.Parse(ItemsPerPage.SelectedValue);
			int currentPage = 1;

			dynamic productsToDisplay = GetPagedProducts(allSortedProducts, itemsPerPage, currentPage);
			DisplayProducts(productsToDisplay);
		}

		private dynamic GetPagedProducts(dynamic allProds, int itemsPerPage, int currentPage)
        {

			int startIndex = (currentPage - 1) * itemsPerPage;
			int endIndex = Math.Min(startIndex + itemsPerPage, allProds.Length);

			List<ItemWrapper> itemsToDisplay = new List<ItemWrapper>();

			for(int i = startIndex; i < endIndex; i++)
            {
				itemsToDisplay.Add(allProds[i]);
            }

			return itemsToDisplay;
        }

		protected void ItemsPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
			int itemsPerPage = int.Parse((sender as DropDownList).SelectedValue);
			int currentPage = 1;

			ItemsPerPage.SelectedValue = itemsPerPage.ToString();
			ItemsPerPage2.SelectedValue = itemsPerPage.ToString();


			dynamic allProducts = ViewState["AllProducts"];

			dynamic productsToDisplay = GetPagedProducts(allProducts, itemsPerPage, currentPage);
			DisplayProducts(productsToDisplay);

        }

		protected void PageNavigation_Click(object sender, EventArgs e)
        {
			int itemsPerPage = int.Parse(ItemsPerPage.SelectedValue);
			int currentPage = int.Parse((sender as LinkButton).CommandArgument);

			UpdatePaginationControls(currentPage);

			dynamic allProducts = ViewState["AllProducts"];

			dynamic productsToDisplay = GetPagedProducts(allProducts, itemsPerPage, currentPage);
			DisplayProducts(productsToDisplay);
        }

        protected void UpdatePaginationControls(int currentPage)
        {
			//top one
            Page1.CssClass = currentPage == 1 ? "active" : "";
            Page2.CssClass = currentPage == 2 ? "active" : "";
            Page3.CssClass = currentPage == 3 ? "active" : "";
            Page4.CssClass = currentPage == 4 ? "active" : "";
            Page5.CssClass = currentPage == 5 ? "active" : "";

			//bottom one
			Page12.CssClass = currentPage == 1 ? "active" : "";
			Page22.CssClass = currentPage == 2 ? "active" : "";
			Page32.CssClass = currentPage == 3 ? "active" : "";
			Page42.CssClass = currentPage == 4 ? "active" : "";
			Page52.CssClass = currentPage == 5 ? "active" : "";

		}

		protected void Category_Click(object sender, EventArgs e)
        {

			String selectedCategory = (sender as LinkButton).CommandArgument;

			Service1Client Client = new Service1Client();
			dynamic allProducts = Client.getItemsByCategory(selectedCategory);

			ViewState["AllProducts"] = allProducts;

			int itemsPerPage = int.Parse(ItemsPerPage.SelectedValue);
			int currentPage = 1;

			dynamic productsToDisplay = GetPagedProducts(allProducts, itemsPerPage, currentPage);
			DisplayProducts(productsToDisplay);


		}

		protected void DisplayDealsOfTheWeek(dynamic allProducts)
        {
			StringBuilder sb = new StringBuilder();
			Random random = new Random();

			List<ItemWrapper> deals = ((IEnumerable<ItemWrapper>)allProducts).OrderBy(x => random.Next()).Take(9).ToList();

			foreach(ItemWrapper deal in deals)
            {

				decimal strikethroughPrice = deal.Price + random.Next(10, 30);

				sb.Append(@"<div class='col-lg-4 col-md-4 col-sm-6 mb-20' >");
				sb.Append(@"<div class='single-related-product d-flex' style='height: 75px;'>");
				sb.Append($@"<a href='#'><img src='{deal.Image}' alt='' style='width: 80px; height: 80px; object-fit: cover; margin-right: 10px;'></a>");
				sb.Append(@"<div class='desc'>");
				sb.Append($@"<a href='#' class='title'>{deal.Title}</a>");
				sb.Append(@"<div class='price'>");
				sb.Append($@"<h6>R{deal.Price}</h6>");
				sb.Append($@"<h6 class='l-through'>R{strikethroughPrice}</h6>");
				sb.Append("</div>"); // Close price div
				sb.Append("</div>"); // Close desc div
				sb.Append("</div>"); // Close single-related-product div
				sb.Append("</div>"); // Close col div






			}

			DealsOfTheWeekLiteral.Text = sb.ToString();




		}



		}


	}
