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
    <section class="cart_area">
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
                        <asp:Panel ID="TDHolder" runat="server"></asp:Panel>
                            
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
                                        <input type="text" placeholder="Coupon Code">
                                        <a class="primary-btn" href="#">Apply</a>
                                       
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

                                </td>
                                <td>
                                    <div class="checkout_btn_inner d-flex align-items-center">
                                        <a class="gray_btn" href="Shop.aspx">Continue Shopping</a>
                                        <asp:Button ID="CheckOut" CssClass="primary-btn" runat="server" Text="Proceed To Checkout" OnClick="CheckOut_Click"/>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            
        </div>
    </section>
    <!--================End Cart Area =================-->
</asp:Content>
