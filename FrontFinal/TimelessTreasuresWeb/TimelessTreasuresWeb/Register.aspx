<%@ Page Title="Timeless Treasures ! Register" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TimelessTreasuresWeb.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
    
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <!-- Start Banner Area -->
	<section class="banner-area organic-breadcrumb">
		<div class="container">
			<div class="breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end">
				<div class="col-first">
					<h1>Login/Register</h1>
					<nav class="d-flex align-items-center">
						<a href="Home.aspx">Home<span class="lnr lnr-arrow-right"></span></a>
						<a href="Login.aspx">Login/Register</a>
					</nav>
				</div>
			</div>
		</div>
	</section>
	<!-- End Banner Area -->

    <section class="login_box_area section_gap">
		<div class="container">
			<div class="row">
				<div class="col-lg-6">
					<div class="login_box_img">
						<img class="img-fluid" src="assets/img/login.jpg" alt="">
						<div class="hover">
							<h4>Why choose us?</h4>
							<p>You can view testimonials from customers on the link below</p>
							<a class="primary-btn" href="Testimonials.aspx">Create an Account</a>
						</div>
					</div>
				</div>
				<div class="col-lg-6">
					<div class="login_form_inner">
                        <h3 id="form-head">Register</h3>
                    <div class="row login_form" action="contact_process.php" method="post" id="contactForm" novalidate="novalidate">
							<div class="col-md-12 form-group">
                          <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server" style="color:black" placeholder="email*" TextMode="Email" required="required" CausesValidation="True" Visible="True"></asp:TextBox>
                        </div>
							<div class="col-md-12 form-group">
							<asp:TextBox CssClass="form-control" ID="txtName" runat="server" style="color:black" placeholder="name*" required="required"></asp:TextBox>
                        </div>
							<div class="col-md-12 form-group">
                          <asp:TextBox CssClass="form-control" ID="txtSurname" runat="server" style="color:black" placeholder="surname*" required="required"></asp:TextBox>
                        </div>
							<div class="col-md-12 form-group">
                          <asp:TextBox CssClass="form-control" ID="txtAddy" runat="server" style="color:black" placeholder="address*" required=""></asp:TextBox>
                        </div>
							<div class="col-md-12 form-group">
                          <asp:TextBox CssClass="form-control" ID="txtContact" runat="server" style="color:black" placeholder="contact number*" TextMode="Phone" required=""></asp:TextBox>
                        </div>
							<div class="col-md-12 form-group">
                          <asp:TextBox CssClass="form-control" ID="TxtUsername" runat="server" style="color:black" placeholder="username*" required=""></asp:TextBox>
                        </div>
							<div class="col-md-12 form-group">
                          <asp:TextBox CssClass="form-control" ID="TxtPass" runat="server" style="color:black" placeholder="password*" TextMode="Password" required=""></asp:TextBox>
                       </div>
							<div class="col-md-12 form-group">
								<asp:Button CssClass="primary-btn" ID="BtnReg" runat="server" Text="Register" OnClick="BtnReg_Click" type="submit" />
                        </div>
							<div class="col-md-12 form-group">
                            <asp:Label ID="Msglabel" runat="server" Text=""
                                style="color:red"></asp:Label>
                        </div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</section>
	<!--================End Login Box Area =================-->
</asp:Content>
