using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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

            //get user id from string
            int Uid = int.Parse(Session["UserId"].ToString());

            if (!IsPostBack)
            {
                Service1Client SC = new Service1Client();
                if (Request.QueryString["Pid"] == null)
                {
                    FillCart(Uid);
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
                }
                else
                {
                    FillCart(Uid);
                }
            }
            else
            {
                FillCart(Uid);
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
                    PriceCell.Text ="<h5>R"+Prod.Price.ToString()+"</h5>";
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
                    decimal tot;
                    tot = Prod.Price * int.Parse(txtQuant.Text); //Calculate the total and display it

                    TotalPrice.Text ="<h5>R"+tot.ToString()+"</h5>";
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
            /*<tr>
                           
                             
                              <td>
                                  <div class="product_count">
                                      <input type="text" name="qty" id="sst" maxlength="12" value="1" title="Quantity:"
                                          class="input-text qty">
                                      <button onclick="var result = document.getElementById('sst'); var sst = result.value; if( !isNaN( sst )) result.value++;return false;"
                                          class="increase items-count" type="button"><i class="lnr lnr-chevron-up"></i></button>
                                      <button onclick="var result = document.getElementById('sst'); var sst = result.value; if( !isNaN( sst ) &amp;&amp; sst > 0 ) result.value--;return false;"
                                          class="reduced items-count" type="button"><i class="lnr lnr-chevron-down"></i></button>
                                  </div>
                              </td>
                              <td>
                                  <h5>$720.00</h5>
                              </td>
                          </tr>
      */
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
            int UpdateTotalResult = SC.UpdateCartTotal(Uid);
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
            if (UpdateTotalResult != 1)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Failed TO Update total";
            }
            Response.Redirect("ShoppingCart.aspx");
        }

       
    }
}