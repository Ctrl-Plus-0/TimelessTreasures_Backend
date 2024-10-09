<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="Invoices.aspx.cs" Inherits="TimelessTreasuresWeb1.Invoices" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <!-- Start Banner Area -->
    <section class="banner-area organic-breadcrumb">
        <div class="container">
            <div class="breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end">
                <div class="col-first">
                    <h1>Invoices</h1>
                  
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
                                <th scope="col">ID</th>
                                <th scope="col">Total</th>           
                                <th scope="col">Date Made</th>
                                <th scope="col">View More</th>
                                
                            </tr>
                        </thead>
                        <tbody>
                              <!-- Replace all td and prod info with panel place holder
                              add in dynamically-->
                          <!--do same for the update/checkout sections-->
                        <asp:Panel ID="InvoiceHolder" runat="server"></asp:Panel>
                          
     

                        </tbody>
                    </table>
                </div>
            </div>
            
        </div>
    </section>


</asp:Content>
