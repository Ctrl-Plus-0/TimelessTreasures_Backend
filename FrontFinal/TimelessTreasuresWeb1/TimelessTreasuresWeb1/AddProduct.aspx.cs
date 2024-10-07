using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimelessTreasuresWeb1.ServiceReference1;

namespace TimelessTreasuresWeb1
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            string title = txtTitle.Text;
            decimal price = decimal.Parse(txtPrice.Text);
            string description = txtDescription.Text;
            string category = txtCategory.Text;
            string image = txtImageURL.Text;
            int quantity = int.Parse(txtQuantity.Text);
            int visible = int.Parse(txtVisible.Text);

            Service1Client client = new Service1Client();
            int result = client.AddProduct(title, price, description, category, image, quantity, visible);

            lblResponse.ForeColor = result == 0 ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            lblResponse.Text = result == 0 ? "Product Added Successfully" : "Failed to Add Product";

        }
    }
}