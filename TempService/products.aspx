<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="TempService.products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="assets/css/bootstrap.min.css">

    <link rel="stylesheet" type="text/css" href="assets/css/font-awesome.css">

    <link rel="stylesheet" href="assets/css/templatemo-lava.css">

    <link rel="stylesheet" href="assets/css/owl-carousel.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:DropDownList ID="sortDropdown" runat="server" AutoPostBack="true">
        <asp:ListItem Value="Default" Selected="True">Relevance</asp:ListItem>
        <asp:ListItem Value="Price ASC">Price: Low to High</asp:ListItem>
        <asp:ListItem Value="Price DESC">Price: High to Low</asp:ListItem>
    </asp:DropDownList>

    <asp:DropDownList ID="filterDropdown" runat="server" AutoPostBack="true">
        <asp:ListItem Value="default" Selected="True">All</asp:ListItem>
        <asp:ListItem Value="men's clothing">Men's Clothing</asp:ListItem>
        <asp:ListItem Value="women's clothing">Women's Clothing</asp:ListItem>
        <asp:ListItem Value="electronics">Electronics</asp:ListItem>
        <asp:ListItem Value="jewelery">Jewellery</asp:ListItem>
    </asp:DropDownList>

    <div runat="server" id="productsDiv">
    </div>

     <!-- jQuery -->
    <script src="assets/js/jquery-2.1.0.min.js"></script>

    <!-- Bootstrap -->
    <script src="assets/js/popper.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>

    <!-- Plugins -->
    <script src="assets/js/owl-carousel.js"></script>
    <script src="assets/js/scrollreveal.min.js"></script>
    <script src="assets/js/waypoints.min.js"></script>
    <script src="assets/js/jquery.counterup.min.js"></script>
    <script src="assets/js/imgfix.min.js"></script>

    <!-- Global Init -->
    <script src="assets/js/custom.js"></script>
</asp:Content>
