using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimelessTreasuresWeb1.ServiceReference1;

namespace TimelessTreasuresWeb1
{
    public partial class Gift : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Service1Client SC = new Service1Client();
            int InvoiceToRetrieve = int.Parse(Request.QueryString["InvID"]);
            InvoiceWrapper IW = SC.GetInvoice(InvoiceToRetrieve);
            txtName.Text = IW.receipiant;
            txtMessage.Text = IW.message;
            txtContact.Text = IW.Contact;
            txtAddy.Text = IW.Address;
            txtDeliveryDate.Text = IW.Delivery.ToString();
            FillTable(IW);
        }

        private void FillTable(InvoiceWrapper IW)
        {
            Service1Client SC = new Service1Client();
            for(int i = 0; i < IW.ProductIDs.Length; i++)
            {
                int chek = IW.ProductIDs[i];
                if (IW.ProductIDs[i] < 100) //this will never happen for the stored ids so it will preent trailing value issues
                {
                    continue;
                }
                ItemWrapper prod = SC.GetItem(IW.ProductIDs[i]);

                TableRow TR = new TableRow();
                //Image Start
                LiteralControl MediaDivOpen = new LiteralControl(@"<div class=""media"">");
                LiteralControl MediaDivClose = new LiteralControl();
                LiteralControl DflexDiveOpen = new LiteralControl(@"<div class=""d-flex"">");
                LiteralControl DflexDiveClose = new LiteralControl("</div>");

                TableCell ImageCell = new TableCell();
                Image ItemImage = new Image();
                ItemImage.ImageUrl = prod.Image;
                ItemImage.AlternateText = prod.Title;
                ItemImage.Width = 200;
                ItemImage.Height = 200;
                ImageCell.Controls.Add(MediaDivOpen);
                ImageCell.Controls.Add(DflexDiveOpen);
                ImageCell.Controls.Add(ItemImage);
                ImageCell.Controls.Add(DflexDiveClose);
                ImageCell.Controls.Add(MediaDivClose);
                TR.Controls.Add(ImageCell);

                //image end

                //Name Start
                LiteralControl MediaBodyDivOpen = new LiteralControl(@"<div class=""media-body"">");
                LiteralControl TextBody = new LiteralControl(prod.Title);
                LiteralControl MediaBodyDivClose = new LiteralControl("</div>");

                TableCell NameCell = new TableCell();
                NameCell.Controls.Add(MediaBodyDivOpen);
                NameCell.Controls.Add(TextBody);
                NameCell.Controls.Add(MediaBodyDivClose);
                TR.Controls.Add(NameCell);
                //Name End

                //Base Price Start
                TableCell PriceCell = new TableCell();
            
                PriceCell.Attributes["style"] = "font-weight: bold; color: black;";
                PriceCell.Text = "R" + prod.Price.ToString();
                TR.Controls.Add(PriceCell);
                //Base Price End


                //Quantity Begin
                TableCell Quantity = new TableCell();
                LiteralControl divopen = new LiteralControl(@"<div class=""product_count"">");
                LiteralControl divclose = new LiteralControl("</div>");

                Quantity.Controls.Add(divopen);
                TextBox txtQuant = new TextBox();
                txtQuant.CssClass = @"class=""input-text qty""";
                txtQuant.TextMode = TextBoxMode.SingleLine;
                txtQuant.ReadOnly = true;
                txtQuant.Text = IW.QuantityProd[i].ToString(); //indexes are stored in a way to match 
                                                           //as such i works for both item needed adn its quantity
          
                Quantity.Controls.Add(txtQuant);
                Quantity.Controls.Add(divclose);
                TR.Controls.Add(Quantity);
                //Quantity end

                //Total Cost
                TableCell TotalPrice = new TableCell();
                TotalPrice.Attributes["style"] = "font-weight: bold; color: black;";
                decimal tot;
                tot = prod.Price * IW.QuantityProd[i]; //Calculate the total and display it

                TotalPrice.Text = "R" + tot.ToString();
                TR.Controls.Add(TotalPrice);

                //Total cost end

                InvHolder.Controls.Add(TR);
            }
        }
    }
}