using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TimelessTreasuresWeb1.ServiceReference1;

namespace TimelessTreasuresWeb1
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserType"] == null)
            {
                Response.Redirect("Login.aspx");

            }
            Service1Client SC = new Service1Client();
            //get user id from string
            int Uid = int.Parse(Session["UserId"].ToString());

            if (!IsPostBack)
            {
                
                if (Request.QueryString["Pid"] == null)
                {
                    FillCart(Uid);
                    UpdateCart_Click(sender, e);
                    return;
                }
                int ProdToAdd = int.Parse(Request.QueryString["Pid"]);
                if (ProdToAdd != 0)
                {
                    int Result = SC.AddItemToCart(ProdToAdd, Uid);

                    if (Result == -3)
                    {
                        lblMsg.ForeColor = System.Drawing.Color.Yellow;
                        lblMsg.Text = "Max Quantity Already In Cart For The Selected Item.";
                    }
                    else if (Result == -2)
                    {
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        lblMsg.Text = "Error Adding Existing Item To Cart;Try Again Later";
                    }
                    else if (Result == -1)
                    {
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        lblMsg.Text = "Error Adding New Item To Cart;Try Again Later";
                    }
                    else if (Result == 1)
                    {
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        lblMsg.Text = "Item Already In Cart,Increasing Quantity insstead";
                    }
                    else if (Result == 2)
                    {
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        lblMsg.Text = "New Item Added To Cart";
                    }
                    //call method to fill with user specefic cart info
                    FillCart(Uid);
                    UpdateCart_Click(sender, e);

                }
                else
                {
                    FillCart(Uid);
                    UpdateCart_Click(sender, e);

                }
           
            }
            else
            {
                FillCart(Uid);
                UpdateCart_Click(sender, e);

            }



        }
      
        private void FillCart(int UserId)
        {
            Service1Client SC = new Service1Client();
            dynamic items = SC.GetCartItems(UserId);

            foreach (TrackerWrapper T in items)
            {
                if (T != null)
                {
                    var Prod = SC.GetItem(T.ProdId);

                    TableRow TR = new TableRow();
                    //Image Start
                    LiteralControl MediaDivOpen = new LiteralControl(@"<div class=""media"">");
                    LiteralControl MediaDivClose = new LiteralControl();
                    LiteralControl DflexDiveOpen = new LiteralControl(@"<div class=""d-flex"">");
                    LiteralControl DflexDiveClose = new LiteralControl("</div>");

                    TableCell ImageCell = new TableCell();
                    Image ItemImage = new Image();
                    ItemImage.ImageUrl = Prod.Image;
                    ItemImage.AlternateText = Prod.Title;
                    ItemImage.Width = 200;
                    ItemImage.Height = 200;
                    ImageCell.Controls.Add(MediaDivOpen);
                    ImageCell.Controls.Add(DflexDiveOpen);
                    ImageCell.Controls.Add(ItemImage);
                    ImageCell.Controls.Add(DflexDiveClose);
                    ImageCell.Controls.Add(MediaDivClose);
                    TR.Controls.Add(ImageCell);
                    //Image end

                    //Name Start
                    LiteralControl MediaBodyDivOpen = new LiteralControl(@"<div class=""media-body"">");
                    LiteralControl TextBody = new LiteralControl(Prod.Title);
                    LiteralControl MediaBodyDivClose = new LiteralControl("</div>");

                    TableCell NameCell = new TableCell();
                    NameCell.Controls.Add(MediaBodyDivOpen);
                    NameCell.Controls.Add(TextBody);
                    NameCell.Controls.Add(MediaBodyDivClose);
                    TR.Controls.Add(NameCell);
                    //Name End

                    //Base Price Start
                    TableCell PriceCell = new TableCell();
                    PriceCell.ID = "P_BasePrice_" + Prod.ID; //Used in Calculations so it needs and ID
                    PriceCell.Attributes["style"] = "font-weight: bold; color: black;";
                    PriceCell.Text ="R"+Prod.Price.ToString();
                    TR.Controls.Add(PriceCell);
                    //Base Price End

                    //Quantity Begin
                    TableCell Quantity = new TableCell();
                    LiteralControl divopen = new LiteralControl(@"<div class=""product_count"">");
                    LiteralControl divclose = new LiteralControl("</div>");

                    Quantity.Controls.Add(divopen);
                    TextBox txtQuant = new TextBox();
                    txtQuant.CssClass = @"class=""input-text qty""";
                    txtQuant.TextMode = TextBoxMode.Number;
                    txtQuant.ID = "P_Quantity_" + Prod.ID;
                    txtQuant.Text = T.Quantity.ToString();
                    txtQuant.Attributes["min"] = "1";
                    txtQuant.Attributes["max"] = "10";



                    Quantity.Controls.Add(txtQuant);
                    Quantity.Controls.Add(divclose);
                    TR.Controls.Add(Quantity);
                    //Quantity end

                    //Total Cost
                    TableCell TotalPrice = new TableCell();
                    TotalPrice.ID = "P_Total_" + Prod.ID;
                    TotalPrice.Attributes["style"] = "font-weight: bold; color: black;";
                    decimal tot;
                    tot = Prod.Price * T.Quantity; //Calculate the total and display it

                    TotalPrice.Text ="R"+tot.ToString();
                    TR.Controls.Add(TotalPrice);

                    //Total cost end


                    //Remove Button
                    TableCell RemoveProd = new TableCell();
                    Button BtnRemoveFromCart = new Button();
                    BtnRemoveFromCart.Text = "X";
                    BtnRemoveFromCart.CssClass = "primary-btn";
                    BtnRemoveFromCart.ID = "P_Remove_" + Prod.ID;
                    BtnRemoveFromCart.Click += new EventHandler(BtnRemoveFromCart_Click);
                    RemoveProd.Controls.Add(BtnRemoveFromCart);
                    TR.Controls.Add(RemoveProd);

                    TDHolder.Controls.Add(TR);
                }
            }
    
        }

        protected void BtnRemoveFromCart_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            Service1Client SC = new Service1Client();
            //get user id from string
            int Uid = int.Parse(Session["UserId"].ToString());
            Button BtnRemove = (Button)sender; //Get a copy of the button currently being worked in
            string[] SplitID = BtnRemove.ID.Split('_');
            int Prodid = int.Parse(SplitID[2]); //get id from the button

            int Result = SC.RemoveItemFromCart(Prodid, Uid);
           
            if (Result == -1)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Failed To Remove Item From Cart,Try Again Later"; 
            }else if (Result == -2)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Item Does Not Exist";
            }
            else if(Result==1)
            {
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "Item Removed From Cart";
            }
          
            Response.Redirect("ShoppingCart.aspx");
        }

        protected void CheckOut_Click(object sender, EventArgs e)
        {
            Service1Client SC = new Service1Client();
            int Uid = int.Parse(Session["UserId"].ToString());


            var Temp=SC.GetCartItems(Uid);

            if (!Temp.Any())
            { 
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Cannot Checkout With Empty Cart.";
                return;
            }

            VisibleCart.Visible = false;
            VisibleForm.Visible = true;

        }

        protected void UpdateCart_Click(object sender, EventArgs e)
        {
            Service1Client SC = new Service1Client();
            int Uid = int.Parse(Session["UserId"].ToString());
            dynamic items = SC.GetCartItems(Uid);
         
            foreach (TrackerWrapper T in items)
            {
                if (T != null)
                {
                    TextBox txtQuant = (TextBox)TDHolder.FindControl("P_Quantity_" + T.ProdId);

                    SC.UpdateItemQuantity(Uid, int.Parse(txtQuant.Text), T.ProdId);
                }
            }
               
                    string TxtDisct = txtCuponCOde.Text;

                    decimal total = 0;
                    decimal VatCost = 0;
                    decimal DiscountPercentage = 0;
                    decimal FinalTot = 0;
                    
                    Cupon Disc = SC.ApplyDiscount(TxtDisct);

            if (Disc != null)
            {

                DiscountPercentage = Disc.DiscountPercentage;
            }
                    SC.UpdateCartTotal(Uid, DiscountPercentage);
                    SC.RemoveFromDiscountPool(TxtDisct); //discounts are tracked permanently so we can safely remove a used cupon from the discount pool

                     var UserCart = SC.GetCart(Uid);
                     total = UserCart.Total;
                     VatCost = UserCart.TaxCost;
                     DiscountPercentage = UserCart.DiscountPercentage;

                     decimal DiscountAmount = total * (DiscountPercentage / 100);
                     DiscountAmount = Math.Round(DiscountAmount, 2);
                     FinalTot = total + VatCost - DiscountAmount;
                    Total.InnerText = "R" + total;
                    Vat.InnerText = "R" + VatCost;
                    Discount.InnerText = "R" + DiscountAmount;
                    SubTotal.InnerText = "R" + FinalTot;

                    



                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Text = "Cart Updated";

             
        }

        protected void BtnProceed_Click(object sender, EventArgs e)
        {
            Service1Client SC = new Service1Client();
            int Uid = int.Parse(Session["UserId"].ToString());

            string message = txtMessage.Text;
            string contact = txtContact.Text;
            string address = txtAddy.Text;
            string receipiant = txtName.Text;
            string UnparsedDate = txtDeliveryDate.Text;
            DateTime Delivery;
            string[] formats = { "yyyy/MM/dd", "yyyy-MM-dd" };
            if (DateTime.TryParseExact(UnparsedDate,formats, null, System.Globalization.DateTimeStyles.None,out Delivery))
            {

                SC.CreateInvoice(Uid,message,receipiant,address,Delivery,contact);
                SC.UpdateAfterSale(Uid);
                SC.ClearCart(Uid);
                VisibleForm.Visible = false;
                VisibleCart.Visible = true;
                Response.Redirect("Invoices.aspx");
            }

        }

        protected void BtnBackToShop_Click(object sender, EventArgs e)
        {
            Response.Redirect("Shop.aspx");
        }
    }
}