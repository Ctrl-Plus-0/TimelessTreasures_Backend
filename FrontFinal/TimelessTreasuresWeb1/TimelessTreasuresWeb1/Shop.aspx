<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="TimelessTreasuresWeb1.Shop" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <!-- Start Banner Area -->
	<section class="banner-area organic-breadcrumb">
		<div class="container">
			<div class="breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end">
				<div class="col-first">
					<h1>Shop Page</h1>
					<nav class="d-flex align-items-center">
						<a href="Home.aspx">Home<span class="lnr lnr-arrow-right"></span></a>
						<a href="Shop.aspx">Shop</a>
						
					</nav>
				</div>
			</div>
		</div>
	</section>
	<!-- End Banner Area -->
	<div class="container" style="margin-top: 100px;">
		<div class="row">
			<div class="col-xl-3 col-lg-4 col-md-5">
				<div class="sidebar-categories">
					<div class="head" style="background-color:#3f88c5;">Browse Categories</div>
					<ul class="main-categories">
	<li class="main-nav-list"><asp:LinkButton ID="AllLink" runat="server" CommandArgument="All" OnClick="Category_Click">All<span class="number">(32)</span></asp:LinkButton></li>
    <li class="main-nav-list"><asp:LinkButton ID="JewelleryLink" runat="server" CommandArgument="Jewellery" OnClick="Category_Click">Jewellery<span class="number">(3)</span></asp:LinkButton></li>
    <li class="main-nav-list"><asp:LinkButton ID="StationeryLink" runat="server" CommandArgument="Stationery" OnClick="Category_Click">Stationery<span class="number">(3)</span></asp:LinkButton></li>
    <li class="main-nav-list"><asp:LinkButton ID="ArtSuppliesLink" runat="server" CommandArgument="Art Supplies" OnClick="Category_Click">Art Supplies<span class="number">(1)</span></asp:LinkButton></li>
    <li class="main-nav-list"><asp:LinkButton ID="KitchenDiningLink" runat="server" CommandArgument="Kitchen & Dining" OnClick="Category_Click">Kitchen & Dining<span class="number">(3)</span></asp:LinkButton></li>
    <li class="main-nav-list"><asp:LinkButton ID="ClothingLink" runat="server" CommandArgument="Clothing" OnClick="Category_Click">Clothing<span class="number">(1)</span></asp:LinkButton></li>
    <li class="main-nav-list"><asp:LinkButton ID="HomeDecorLink" runat="server" CommandArgument="Mugs" OnClick="Category_Click">Mugs<span class="number">(6)</span></asp:LinkButton></li>
    <li class="main-nav-list"><asp:LinkButton ID="TravelAccessoriesLink" runat="server" CommandArgument="Travel Accessories" OnClick="Category_Click">Travel Accessories<span class="number">(1)</span></asp:LinkButton></li>
    <li class="main-nav-list"><asp:LinkButton ID="GreetingCardsLink" runat="server" CommandArgument="Greeting Cards" OnClick="Category_Click">Greeting Cards<span class="number">(5)</span></asp:LinkButton></li>
    <li class="main-nav-list"><asp:LinkButton ID="MusicalInstrumentsLink" runat="server" CommandArgument="Musical Instruments" OnClick="Category_Click">Musical Instruments<span class="number">(1)</span></asp:LinkButton></li>
    <li class="main-nav-list"><asp:LinkButton ID="BagsLink" runat="server" CommandArgument="Bags" OnClick="Category_Click">Bags<span class="number">(6)</span></asp:LinkButton></li>
    <li class="main-nav-list"><asp:LinkButton ID="AccessoriesLink" runat="server" CommandArgument="Accessories" OnClick="Category_Click">Accessories<span class="number">(2)</span></asp:LinkButton></li>
</ul>

				</div>
				<div class="sidebar-filter mt-50">
					
					
					
				</div>
			</div>
			<div class="col-xl-9 col-lg-8 col-md-7">
				<!-- Start Filter Bar -->
				<div class="filter-bar d-flex flex-wrap align-items-center" style="background-color:#3f88c5;">
					<div class="sorting" >

						<asp:DropDownList ID="SortList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="SortList_SelectedIndexChanged">

						  <asp:ListItem Value="0">Default sorting</asp:ListItem>
						  <asp:ListItem Value="1">Price:High to low</asp:ListItem>
						  <asp:ListItem Value="2">Price:Low to High</asp:ListItem>
						  <asp:ListItem Value="3">Alphabet:A-Z</asp:ListItem>
						  <asp:ListItem Value="4">Alphabet:Z-A</asp:ListItem>
						</asp:DropDownList>
					
					</div>
					<!-- Not Going to do anything here -->
					<div class="sorting mr-auto">
						<asp:DropDownList ID="ItemsPerPage" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ItemsPerPage_SelectedIndexChanged">
							<asp:ListItem Value="6">Show 6</asp:ListItem>
							<asp:ListItem Value="12">Show 12</asp:ListItem>
							<asp:ListItem Value="24">Show 24</asp:ListItem>
							<asp:ListItem Value="32">Show All</asp:ListItem>
						</asp:DropDownList>
					</div>

					<div class="pagination">

						<asp:LinkButton ID="PrevPageButton" runat="server" CommandName="Prev" OnClick="PageNavigation_Click" CssClass="prev-arrow">
							<i class="fa fa-long-arrow-left" aria-hidden="true"></i>
						</asp:LinkButton>

						<asp:LinkButton ID="Page1" runat="server" CommandArgument="1" OnClick="PageNavigation_Click" CssClass="active">1</asp:LinkButton>
						<asp:LinkButton ID="Page2" runat="server" CommandArgument="2" OnClick="PageNavigation_Click">2</asp:LinkButton>
						<asp:LinkButton ID="Page3" runat="server" CommandArgument="3" OnClick="PageNavigation_Click">3</asp:LinkButton>
						<asp:LinkButton ID="Page4" runat="server" CommandArgument="4" OnClick="PageNavigation_Click">4</asp:LinkButton>
						<asp:LinkButton ID="Page5" runat="server" CommandArgument="5" OnClick="PageNavigation_Click">5</asp:LinkButton>



						<asp:LinkButton ID="NextPageButton" runat="server" CommandName="Next" OnClick="PageNavigation_Click" CssClass="next-arrow">
							<i class="fa fa-long-arrow-right" aria-hidden="true"></i>
						</asp:LinkButton>
	
					</div>

				</div>
				<!-- End Filter Bar -->
				<!-- Start Best Seller -->
				<section class="lattest-product-area pb-40 category-list">
					<div class="row">
					<asp:Literal ID="Product" runat="server"></asp:Literal>
				
					</div>
				</section>
				<!-- End Best Seller -->
<!-- Start Filter Bar -->
				<div class="filter-bar d-flex flex-wrap align-items-center" style="background-color:#3f88c5;">
					<div class="sorting" >

						<asp:DropDownList ID="SortList2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="SortList_SelectedIndexChanged">

						  <asp:ListItem Value="0">Default sorting</asp:ListItem>
						  <asp:ListItem Value="1">Price:High to low</asp:ListItem>
						  <asp:ListItem Value="2">Price:Low to High</asp:ListItem>
						  <asp:ListItem Value="3">Alphabet:A-Z</asp:ListItem>
						  <asp:ListItem Value="4">Alphabet:Z-A</asp:ListItem>
						</asp:DropDownList>
					
					</div>
					<!-- Not Going to do anything here -->
					<div class="sorting mr-auto">
						<asp:DropDownList ID="ItemsPerPage2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ItemsPerPage_SelectedIndexChanged">
							<asp:ListItem Value="6">Show 6</asp:ListItem>
							<asp:ListItem Value="12">Show 12</asp:ListItem>
							<asp:ListItem Value="24">Show 24</asp:ListItem>
							<asp:ListItem Value="32">Show All</asp:ListItem>
						</asp:DropDownList>
					</div>

					<div class="pagination">

						<asp:LinkButton ID="PrevPageButton2" runat="server" CommandName="Prev" OnClick="PageNavigation_Click" CssClass="prev-arrow">
							<i class="fa fa-long-arrow-left" aria-hidden="true"></i>
						</asp:LinkButton>

						<asp:LinkButton ID="Page12" runat="server" CommandArgument="1" OnClick="PageNavigation_Click" CssClass="active">1</asp:LinkButton>
						<asp:LinkButton ID="Page22" runat="server" CommandArgument="2" OnClick="PageNavigation_Click">2</asp:LinkButton>
						<asp:LinkButton ID="Page32" runat="server" CommandArgument="3" OnClick="PageNavigation_Click">3</asp:LinkButton>
						<asp:LinkButton ID="Page42" runat="server" CommandArgument="4" OnClick="PageNavigation_Click">4</asp:LinkButton>
						<asp:LinkButton ID="Page52" runat="server" CommandArgument="5" OnClick="PageNavigation_Click">5</asp:LinkButton>



						<asp:LinkButton ID="NextPageButton2" runat="server" CommandName="Next" OnClick="PageNavigation_Click" CssClass="next-arrow">
							<i class="fa fa-long-arrow-right" aria-hidden="true"></i>
						</asp:LinkButton>
	
					</div>

				</div>
				<!-- End Filter Bar -->
			</div>
		</div>
	</div>

	<!-- Start related-product Area -->
	<section class="related-product-area section_gap">
		<div class="container">
			<div class="row justify-content-center">
				<div class="col-lg-6 text-center">
					<div class="section-title">
						<h1>Deals of the Week</h1>
						<p>Discover our top deals of the week and save big on your favourite products! These exclusive offers are available for a limited time, so don’t miss your chance to grab them before they’re gone. Shop now and enjoy unbeatable prices on must-have items!</p>
					</div>
				</div>
			</div>
			<div class="row">
				<div class="col-lg-9">
					<div class="row">
						<asp:Literal ID="DealsOfTheWeekLiteral" runat="server"></asp:Literal>
					</div>
						
				</div>
				<div class="col-lg-3">
					<div class="ctg-right">
						<a href="#" target="_blank">
							<img class="img-fluid d-block mx-auto" src="assets/img/category/c5.jpg" alt="">
						</a>
					</div>
				</div>
			</div>
		</div>
	</section>
	<!-- End related-product Area -->
</asp:Content>
