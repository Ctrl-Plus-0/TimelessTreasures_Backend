using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TempService.ServiceReference1;

namespace TempService
{
    public partial class products : System.Web.UI.Page
    {
        public int id;
        public string title;

        ServiceReference1.Service1Client sc = new ServiceReference1.Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            sc.getProducts();
            TempService.ServiceReference1.Product[] products = sc.returnList();

            productsDiv.InnerHtml = "<h1>Products</h1> ";

            // Start the section and container
            productsDiv.InnerHtml += "<section class='section' id='about'>";
            productsDiv.InnerHtml += "<div class='container'>";

            // Iterate through the products and dynamically create rows and columns
            for (int i = 0; i < products.Length; i++)
            {
                // Start a new row for every 4th product (i.e., at index 0, 4, 8, 12, 16)
                if (i % 4 == 0)
                {
                    productsDiv.InnerHtml += "<div class='row' style='display: flex; flex-wrap: wrap;'>";
                }

                // Create a column for each product with inline styles
                productsDiv.InnerHtml += "<div class='col-lg-3 col-md-6 col-sm-12' style='flex: 1 1 22%; max-width: 22%; min-width: 22%; box-sizing: border-box; padding: 16px; margin: 10px; min-height: 450px; display: flex; flex-direction: column; justify-content: space-between; align-items: center; border: 1px solid #e0e0e0; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1); border-radius: 8px; overflow: hidden;'>"; // Set minimum height and flexbox properties
                productsDiv.InnerHtml += "<div class='features-item' style='flex-grow: 1; width: 100%; display: flex; flex-direction: column; justify-content: space-between;'>"; // Adjust flexbox layout
                productsDiv.InnerHtml += "<div class='features-icon' style='width: 100%; text-align: center;'>";

                // Product details
                productsDiv.InnerHtml += "<h2 style='text-align: center;'>" + products[i].Id + "</h2>";
                productsDiv.InnerHtml += "<img src='" + products[i].Image + "' alt='img' style='width: 100%; height: auto; margin-bottom: 15px;' />";
                productsDiv.InnerHtml += "<h4 style='text-align: center;'>" + products[i].Title + "</h4>";

                // Limit description to 100 characters and apply flex properties
                string truncatedDescription = products[i].Description.Length > 100 ? products[i].Description.Substring(0, 100) + "..." : products[i].Description;
                productsDiv.InnerHtml += "<p style='flex-grow: 1; text-align: center; margin-bottom: 10px;'>" + truncatedDescription + "</p>";

                // Add to Cart Button
                productsDiv.InnerHtml += "<button style='margin-top: auto; padding: 10px 20px; background-color: #007bff; color: white; border: none; border-radius: 4px; cursor: pointer;'>Add to Cart</button>";

                // Close column divs
                productsDiv.InnerHtml += "</div>"; // .features-icon
                productsDiv.InnerHtml += "</div>"; // .features-item
                productsDiv.InnerHtml += "</div>"; // .col-lg-3

                // Close the row after every 4th product or after the last product
                if (i % 4 == 3 || i == products.Length - 1)
                {
                    productsDiv.InnerHtml += "</div>"; // .row
                }
            }

            // Close container and section divs
            productsDiv.InnerHtml += "</div>"; // .container
            productsDiv.InnerHtml += "</section>";











        }


    }
}