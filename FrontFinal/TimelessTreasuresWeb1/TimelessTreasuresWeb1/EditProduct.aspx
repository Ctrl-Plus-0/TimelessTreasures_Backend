<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="TimelessTreasuresWeb1.EditProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Edit Product</h2>

        
            <label for="txtSearchTitle">Search by Product Name:</label>
            <asp:TextBox ID="txtSearchTitle" runat="server" placeholder="Enter product name"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Search Product" OnClick="btnSearch_Click" />

            <br /><br />

         
            <asp:Panel ID="ProductPanel" runat="server" Visible="false">
                <label for="txtTitle">Product Title:</label>
                <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>

                <br /><br />

                <label for="txtPrice">Price:</label>
                <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>

                <br /><br />

                <label for="txtDescription">Description:</label>
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox>

                <br /><br />

                <label for="txtCategory">Category:</label>
                <asp:TextBox ID="txtCategory" runat="server"></asp:TextBox>

                <br /><br />

                <label for="txtImageURL">Image URL:</label>
                <asp:TextBox ID="txtImageURL" runat="server"></asp:TextBox>

                <br /><br />

                <label for="txtQuantity">Quantity:</label>
                <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>

                <br /><br />

                <label for="cbVisible">Visible:</label>
                <asp:CheckBox ID="cbVisible" runat="server" />

                <br /><br />

                <asp:Button ID="btnUpdate" runat="server" Text="Update Product" OnClick="btnUpdate_Click" />
            </asp:Panel>

            <br /><br />

         
            <asp:Label ID="lblResponse" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body></html>
