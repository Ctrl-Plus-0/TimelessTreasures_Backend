using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

using TimelessTreasuresWeb1.ServiceReference1;

namespace TimelessTreasuresWeb1
{
    public partial class ManageProducts : System.Web.UI.Page
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

				//DisplayDealsOfTheWeek(prod);






				//sets defaults
				int itemsPerPageInt = int.Parse(ItemsPerPage.SelectedValue);
				int currentPage = 1;


				dynamic productsToDisplay = GetPagedProducts(prod, itemsPerPageInt, currentPage);

				DisplayProducts(productsToDisplay);

				
			}

		}

		private void DisplayProducts(dynamic Products)
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
				SB.Append($@"<a href ="""">");
				SB.Append($@"<img class=""img-fluid"" src=""{ImgDest}"" alt=""{ItemName}""> </a>");
				SB.Append(@"<div class=""product-details"">");
				SB.Append($"<h6>{ItemName}</h6>");
				SB.Append(@"<div class=""price"">");
				SB.Append($"<h6>R{Price}</h6>");
				SB.Append("</div>");
				SB.Append(@"<div class=""prd-bottom"">");
				SB.Append($@"<a href='javascript:void(0);' onclick='openEditModal({ProdId});' class='social-info'>");
				SB.Append(@"<span class='ti-pencil'></span>");
				SB.Append(@"<p class='hover-text'>Edit</p>");
				SB.Append("</a>");
				SB.Append($@"<a href='javascript:void(0);' onclick='openDeleteConfirmationModal({ProdId}, ""{ItemName}"", {Price})' class='social-info'>");
				SB.Append(@"<span class='lnr lnr-trash'></span>");
				SB.Append(@"<p class='hover-text'>Delete</p>");
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

			for (int i = startIndex; i < endIndex; i++)
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

		protected void AddProduct_Click(object sender, EventArgs e)
		{
			Service1Client Client = new Service1Client();

			if (productImageUpload.HasFile)
			{
				try
				{
					string fileName = System.IO.Path.GetFileName(productImageUpload.FileName);
					string savePath = Server.MapPath("~/assets/img/catalogue/") + fileName;

					// Save the file to the specified directory
					productImageUpload.SaveAs(savePath);

					// Store the new URL (relative path)
					string imageUrl = "/assets/img/catalogue/" + fileName;

					// Logic to save the imageUrl and other product details to the database
					string title = productTitle.Text;
					decimal price = Convert.ToDecimal(productPrice.Text);
					string description = productDescription.Text;
					string category = productCategory.SelectedValue;
					int quantity = Convert.ToInt32(productQuantity.Text);
					int visible = Convert.ToInt32(productVisible.Text);

					Client.AddProduct(title, price, description, category, imageUrl, quantity, visible);

					string successMessage = "Product added successfully!";
					ClientScript.RegisterStartupScript(this.GetType(), "showModal", "showMessageModal('" + successMessage + "');", true);
				}
				catch (Exception ex)
				{
					// Display error message in modal
					string errorMessage = "Error: " + ex.Message;
					ClientScript.RegisterStartupScript(this.GetType(), "showModal", "showMessageModal('" + errorMessage + "');", true);
				}
			}
			else
			{
				Response.Write("Please select an image file to upload.");
			}
		}
		[WebMethod]
		public static object GetProductDetails(int id)
		{
			Service1Client Client = new Service1Client();

			try
			{
				var product = Client.GetItem(id); // Replace this with your logic to fetch the product

				if (product != null)
				{
					return new
					{
						id = product.ID,
						title = product.Title,
						price = product.Price,
						description = product.Description,
						category = product.Category,
						quantity = product.Quantity,
						visible = product.Visibility
					};
				}

				return new { error = "Product not found" };
			}
			catch (Exception ex)
			{
				return new { error = "An error occurred on the server: " + ex.Message };
			}
		}




		[WebMethod]
		public static string SaveProductChanges(int id, string title, decimal price, string description, string category, string image, int quantity, int visible)
		{
			try
			{
				// Log the data received from the client
				Console.WriteLine($"Received data for EditProduct: ID={id}, Title={title}, Price={price}, Quantity={quantity}");

				Service1Client Client = new Service1Client();
				int result = Client.EditProduct(id, title, price, description, category, image, quantity, visible);

				if (result == 0)
				{
					Console.WriteLine("Product successfully updated.");
					return "Success";
				}
				else
				{
					Console.WriteLine("Error: Product not found or update failed.");
					return "Error: Product not found or update failed.";
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error in SaveProductChanges: " + ex.Message);
				return "Error: " + ex.Message;
			}
		}



		[WebMethod]
		public static string DeleteProduct(int id)
		{
			Service1Client Client = new Service1Client();


			try
			{
				// Call the deleteItem method to mark the product as deleted
				int result = Client.deleteItem(id);

				if (result == 0)
				{
					return "Success"; // Return success message if the deletion was successful
				}
				else if (result == 1)
				{
					return "Product not found"; // Return if the product was not found
				}
				else
				{
					return "Error deleting product"; // Return a generic error message
				}
			}
			catch (Exception ex)
			{
				return "Error: " + ex.Message; // Return specific error message if something goes wrong
			}
		}





	}
}