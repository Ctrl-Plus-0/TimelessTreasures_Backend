<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="DeleteProduct.aspx.cs" Inherits="TimelessTreasuresWeb1.DeleteProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
   
         <div>
            <h2>Delete Product</h2>
            <asp:Label ID="lblResponse" runat="server" ForeColor="Red"></asp:Label><br />
            
            <asp:Label ID="lblSearchTitle" runat="server" Text="Enter Product Name:"></asp:Label><br />
            <asp:TextBox ID="txtSearchTitle" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnSearch" runat="server" Text="Search Product" OnClick="btnSearch_Click" /><br /><br />

           
            <asp:Panel ID="ProductPanel" runat="server" Visible="false">
                <h3>Product Details</h3>
                <asp:Label ID="lblTitle" runat="server" Text="Title:"></asp:Label><br />
                <asp:Label ID="lblTitleValue" runat="server"></asp:Label><br />
                <asp:Label ID="lblPrice" runat="server" Text="Price:"></asp:Label><br />
                <asp:Label ID="lblPriceValue" runat="server"></asp:Label><br />
                <asp:Label ID="lblDescription" runat="server" Text="Description:"></asp:Label><br />
                <asp:Label ID="lblDescriptionValue" runat="server"></asp:Label><br />
                <asp:Label ID="lblCategory" runat="server" Text="Category:"></asp:Label><br />
                <asp:Label ID="lblCategoryValue" runat="server"></asp:Label><br />
                <asp:Label ID="lblQuantity" runat="server" Text="Quantity:"></asp:Label><br />
                <asp:Label ID="lblQuantityValue" runat="server"></asp:Label><br />
                <asp:Label ID="lblVisible" runat="server" Text="Visible:"></asp:Label><br />
                <asp:Label ID="lblVisibleValue" runat="server"></asp:Label><br />

                <asp:Button ID="btnDelete" runat="server" Text="Delete Product" OnClick="btnDelete_Click" />
            </asp:Panel>
        </div>
   
</asp:Content>