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
                            
                       
                        </tbody>
                    </table>
                </div>
            </div>
            
        </div>
    </section>
    <!--================End Cart Area =================-->
</asp:Content>
