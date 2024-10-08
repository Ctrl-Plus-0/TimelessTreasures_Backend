<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TimelessTreasuresWeb1.Login" %>
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

	<!--================Login Box Area =================-->
	<section class="login_box_area section_gap">
		<div class="container">
			<div class="row">
				<div class="col-lg-6">
					<div class="login_box_img">
						<img class="img-fluid" src="assets/img/login.jpg" alt="">
						<div class="hover">
							<h4>New to our website?</h4>
							<p>You can create an account by simply clicking on the button below</p>
							<a class="primary-btn" href="Register.aspx">Create an Account</a>
						</div>
					</div>
				</div>
				<div class="col-lg-6">
					<div class="login_form_inner">
						<h3>Log in to your account</h3>
						<div class="row login_form" id="contactForm">
							<div class="col-md-12 form-group">
                          <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server" name="email" type="email" placeholder="email address" required=""
                                                ></asp:TextBox>
                        </div>
							<div class="col-md-12 form-group">
                          <asp:TextBox CssClass="form-control" ID="txtPass" runat="server" name="password" type="password" placeholder="password"
                                                required="" ></asp:TextBox>
                        </div>
							<div class="col-md-12 form-group">
                          <asp:Button CssClass="primary-btn" ID="BtnLogin" runat="server" Text="Login" OnClick="BtnLogin_Click" type="submit" CausesValidation="True" />
							
                          </div>
							<div class="col-md-12 form-group">
                          <asp:Label ID="Msglabel" runat="server" Text=""
                              style="color:red"></asp:Label>
                        <a href="Register.aspx">Don't have an account yet? Register</a>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</section>
	<!--================End Login Box Area =================-->
</asp:Content>
