<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="Gift.aspx.cs" Inherits="TimelessTreasuresWeb1.Gift" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- Start Banner Area -->
    <section class="banner-area organic-breadcrumb">
        <div class="container">
            <div class="breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end">
                <div class="col-first">
                    <h1>Gift</h1>
                  
                </div>
            </div>
        </div>
    </section>
    <!-- End Banner Area -->

        <!--Start of the Form For Submitting invoices and gift message -->
    <section class="login_box_area section_gap" id="VisibleForm" runat="server" visible="true">
		<div class="container">
			<div class="row">
			
				<div class="col-lg-6">
					<div class="login_form_inner">
                        <h3 id="form-head">Gift Information</h3>
                    <div class="row login_form" action="contact_process.php" method="post" id="contactForm" novalidate="novalidate">
						
                        	<div class="col-md-12 form-group">
                           
							<label>Receipiant Name</label>
                        </div>
							<div class="col-md-12 form-group">
                           
							<asp:TextBox CssClass="form-control" ID="txtName" runat="server" style="color:black" Readonly="true"></asp:TextBox>
                        </div>
                        
                        	<div class="col-md-12 form-group">
                           
							<label>Gift Message</label>
                        </div>
							<div class="col-md-12 form-group">
                          <asp:TextBox CssClass="form-control" ID="txtMessage" runat="server" style="color:black" Readonly="true" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        	<div class="col-md-12 form-group">
                           
							<label>Receipiant Address</label>
                        </div>
							<div class="col-md-12 form-group">
                          <asp:TextBox CssClass="form-control" ID="txtAddy" runat="server" style="color:black" Readonly="true"></asp:TextBox>
                        </div>
                        	<div class="col-md-12 form-group">
                           
							<label>Receipiant Contact Details</label>
                        </div>
							<div class="col-md-12 form-group">
                          <asp:TextBox CssClass="form-control" ID="txtContact" runat="server" style="color:black" Readonly="true" TextMode="Phone" ></asp:TextBox>
                        </div>
                        	<div class="col-md-12 form-group">
                           
							<label>Gift Delivery Date</label>
                        </div>
							<div class="col-md-12 form-group">
                          <asp:TextBox CssClass="form-control" ID="txtDeliveryDate" runat="server" style="color:black" Readonly="true" TextMode="SingleLine" ></asp:TextBox>
                        </div>
	
						</div>
					</div>
				</div>
			</div>
		</div>
	</section>

    <h3 style="text-align: center;">Items Contained In Gift</h3>

    <br />
    
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
                              
                            </tr>
                        </thead>
                        <tbody>
                              <!-- Replace all td and prod info with panel place holder
                              add in dynamically-->
                          <!--do same for the update/checkout sections-->
                        <asp:Panel ID="InvHolder" runat="server" ></asp:Panel>
                            
                        
                        </tbody>
                    </table>
                </div>
            </div>
            
        </div>
    </section>
    <!--================End Cart Area =================-->
</asp:Content>
