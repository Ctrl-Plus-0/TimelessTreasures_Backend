using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimelessTreasuresWeb1.ServiceReference1;

namespace TimelessTreasuresWeb1
{
    public partial class DeleteProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string productName = txtSearchTitle.Text.Trim();

            if (!string.IsNullOrEmpty(productName))
            {

                LoadProductDetails(productName);
            }
            else
            {
                lblResponse.Text = "Please enter a product name to search.";
            }
        }
        private void LoadProductDetails(string productName)
        {

            Service1Client client = new Service1Client();


            var product = client.GetProductByName(productName);

            if (product != null)
            {

                lblTitleValue.Text = product.Title;
                lblPriceValue.Text = product.Price.ToString("F2");
                lblDescriptionValue.Text = product.Description;
                lblCategoryValue.Text = product.Category;
                lblQuantityValue.Text = product.Quantity.ToString();
                lblVisibleValue.Text = product.Visible_ == 1 ? "Yes" : "No";

                // Show the product panel
                ProductPanel.Visible = true;

                lblResponse.Text = "Product found. You can now delete it.";
            }
            else
            {
                lblResponse.Text = "Product not found.";
                ProductPanel.Visible = false;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string productName = lblTitleValue.Text;


            Service1Client client = new Service1Client();


            int result = client.DeleteProduct(productName);


            if (result == 0)
            {
                lblResponse.Text = "Product deleted successfully.";
                ProductPanel.Visible = false;
            }
            else if (result == 1)
            {
                lblResponse.Text = "Product not found.";
            }
            else
            {
                lblResponse.Text = "An error occurred while deleting the product.";
            }
        }
    }
}