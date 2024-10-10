<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="TimelessTreasuresWeb1.ShoppingCart" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <!-- Start Banner Area -->
    <section class="banner-area organic-breadcrumb">
        <div class="container">
            <div class="breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end">
                <div class="col-first">
                    <h1>Shopping Cart</h1>
                    <nav class="d-flex align-items-center">
                        <a href="Home.aspx">Home<span class="lnr lnr-arrow-right"></span></a>
                        <a href="Cart,aspx">Cart</a>
                    </nav>
                </div>
            </div>
        </div>
    </section>
    <!-- End Banner Area -->

    <!--================Cart Area =================-->
    <section class="cart_area" id="VisibleCart" runat="server" visible="true">
        <div class="container">
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
            <div class="cart_inner">
                <div class="table-responsive">
                    <table class="table">
                        <thead>
                            <tr>
                                <th scope="col">Image</th>
                                <th scope="col">Product</th>
                                <th scope="col">Price</th>
                                <th scope="col">Quantity</th>
                                <th scope="col">Total</th>
                                <th scope="col">Remove</th>
                            </tr>
                        </thead>
                        <tbody>
                              <!-- Replace all td and prod info with panel place holder
                              add in dynamically-->
                          <!--do same for the update/checkout sections-->
                        <asp:Panel ID="TDHolder" runat="server" ></asp:Panel>
                            
                            <tr class="bottom_button">
                                <td>
                                    <asp:Button ID="UpdateCart" runat="server" Text="Update Cart" CssClass="gray_btn" OnClick="UpdateCart_Click"/>
                                </td>
                                <td>

                                </td>
                                <td>

                                </td>
                                      <td>

                                </td>
                                      <td>

                                </td>

                                <td>
                                    <div class="cupon_text d-flex align-items-center">
                                        <asp:TextBox ID="txtCuponCOde" runat="server" Placeholder="Enter Discount Code"  ></asp:TextBox>
                                        
                                       
                                    </div>
                                </td>
                            </tr>
                            <tr>
                          <td>

                                </td>
                               
                                 <td>

                                </td>
                                 <td>

                                </td>
                                 <td>

                                </td>
                                <td>
                                    <h5>Total</h5>
                                    <h5>Vat Amount</h5>
                                    <h5>Discount</h5>
                                    <h5>Subtotal</h5>
                                </td>
                                <td>
                                    
                                    <h5 id="Total" runat="server"></h5>
                                    <h5 id="Vat" runat="server"></h5>
                                    <h5 id="Discount" runat="server"></h5>
                                    <h5 id="SubTotal" runat="server"></h5>
                                </td>
                            </tr>
                      
                            <tr class="out_button_area">
                              <td>

                                </td>
                                 <td>

                                </td>
                                 <td>
                                      
                                </td>
                                 <td>

                                </td>
                                 <td>
                                     
                                        <asp:button ID="BtnBackToShop" runat="server" CssClass="gray_btn" Text="Continue Shopping" OnClick="BtnBackToShop_Click" />
                                      
                                </td>
                             
                                <td>
                                    
                                        
                                        <asp:Button ID="CheckOut" CssClass="primary-btn" runat="server" Text="Proceed To Checkout" OnClick="CheckOut_Click"/>
                                  
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            
        </div>
    </section>
    <!--================End Cart Area =================-->

    <!--Start of the Form For Submitting invoices and gift message -->
    <section class="login_box_area section_gap" id="VisibleForm" runat="server" visible="false">
		<div class="container">
			<div class="row">
			
				<div class="col-lg-6">
					<div class="login_form_inner">
                        <h3 id="form-head">Gift Information</h3>
                    <div class="row login_form" action="contact_process.php" method="post" id="contactForm" novalidate="novalidate">
						
							<div class="col-md-12 form-group">
							<asp:TextBox CssClass="form-control" ID="txtName" runat="server" style="color:black" placeholder="Receipiant Name*" required="required"></asp:TextBox>
                        </div>
							<div class="col-md-12 form-group">
                          <asp:TextBox CssClass="form-control" ID="txtMessage" runat="server" style="color:black" placeholder="Gift Message*" required="required" TextMode="MultiLine"></asp:TextBox>
                        </div>
							<div class="col-md-12 form-group">
                          <asp:TextBox CssClass="form-control" ID="txtAddy" runat="server" style="color:black" placeholder="Recepiant Address*" required="required"></asp:TextBox>
                        </div>
							<div class="col-md-12 form-group">
                          <asp:TextBox CssClass="form-control" ID="txtContact" runat="server" style="color:black" placeholder="Receipiant Contact Number*" TextMode="Phone" required="required"></asp:TextBox>
                        </div>
							<div class="col-md-12 form-group">
                          <asp:TextBox CssClass="form-control" ID="txtDeliveryDate" runat="server" style="color:black"  required="required" TextMode="Date" ></asp:TextBox>
                        </div>
						
							<div class="col-md-12 form-group">
								<asp:Button CssClass="primary-btn" ID="BtnProceed" runat="server" Text="Finalize Checkout"  type="submit" OnClick="BtnProceed_Click" />
                        </div>
							<div class="col-md-12 form-group">
                            <asp:Label ID="Msglabel" runat="server" Text=""
                                ></asp:Label>
                        </div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</section>

</asp:Content>
