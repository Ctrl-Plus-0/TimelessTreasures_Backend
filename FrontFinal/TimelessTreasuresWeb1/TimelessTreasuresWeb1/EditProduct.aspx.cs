using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimelessTreasuresWeb1.ServiceReference1;

namespace TimelessTreasuresWeb1
{
    public partial class EditProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string productName = txtSearchTitle.Text;

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

                txtTitle.Text = product.Title;
                txtPrice.Text = product.Price.ToString("F2");
                txtDescription.Text = product.Description;
                txtCategory.Text = product.Category;
                txtImageURL.Text = product.Image;
                txtQuantity.Text = product.Quantity.ToString();
                cbVisible.Checked = product.Visible_ == 1;


                ProductPanel.Visible = true;

                lblResponse.Text = "Product details loaded.";
            }
            else
            {
                lblResponse.Text = "Product not found.";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            string title = txtTitle.Text;
            decimal price = decimal.Parse(txtPrice.Text);
            string description = txtDescription.Text;
            string category = txtCategory.Text;
            string imageUrl = txtImageURL.Text;
            int quantity = int.Parse(txtQuantity.Text);
            int visible = cbVisible.Checked ? 1 : 0;


            Service1Client client = new Service1Client();


            int result = client.EditProduct(title, price, description, category, imageUrl, quantity, visible);


            if (result == 0)
            {
                lblResponse.Text = "Product updated successfully.";
            }
            else if (result == 1)
            {
                lblResponse.Text = "Product not found.";
            }
            else
            {
                lblResponse.Text = "An error occurred while updating the product.";
            }
        }
    }
}