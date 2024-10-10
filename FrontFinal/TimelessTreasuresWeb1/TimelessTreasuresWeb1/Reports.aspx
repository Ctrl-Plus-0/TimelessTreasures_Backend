<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="TimelessTreasuresWeb1.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Start Banner Area -->
	<section class="banner-area organic-breadcrumb">
		<div class="container">
			<div class="breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end">
				<div class="col-first">
					<h1>Reports</h1>
					<nav class="d-flex align-items-center">
						<a href="Home.aspx">Home<span class="lnr lnr-arrow-right"></span></a>
						<a href="Reports.aspx">Reports</a>
					</nav>
				</div>
			</div>
		</div>
	</section>
	<!-- End Banner Area -->

	<section class="login_box_area section_gap">
		<div class="container">
			<div class="row">
				<div class="col-lg-2">
					<div class="reports_side" style="padding: 20px; color: black;">
						<p>Choose Chart</p>
						<asp:DropDownList ID="chart_name" runat="server" style="min-width: 150px; margin: 20px;">
							<asp:ListItem Value="SalesbyProd">Sales by Product</asp:ListItem>
							<asp:ListItem Value="Prodonhand">Stock on Hand by Product</asp:ListItem>
							<asp:ListItem Value="DailyRegister">New Users per Day</asp:ListItem>
							<asp:ListItem Value="MonthlySales">Monthly Sales</asp:ListItem>
						</asp:DropDownList>

						<asp:Button CssClass="genric-btn info" ID="btnGetChart" runat="server" Text="Get Report" OnClick="btnGetChart_Click" style="margin: 20px;" />
					</div>
				</div>
				<div class="col-lg-10">
					
					
					<div id="report_chart" runat="server">

						
						
					</div>
				</div>
			</div>
		</div>
	</section>
	<!--================End Login Box Area =================-->

</asp:Content>
