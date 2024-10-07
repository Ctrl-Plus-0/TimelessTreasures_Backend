<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="TimelessTreasuresWeb1.AddProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Add Product</h2>
            <label>Title:</label>
            <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox><br />
            <label>Price:</label>
            <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox><br />
            <label>Description:</label>
            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox><br />
            <label>Category:</label>
            <asp:TextBox ID="txtCategory" runat="server"></asp:TextBox><br />
            <label>Image URL:</label>
            <asp:TextBox ID="txtImageURL" runat="server"></asp:TextBox><br />
            <label>Quantity:</label>
            <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox><br />
            <label>Visible (1 for Yes, 0 for No):</label>
            <asp:TextBox ID="txtVisible" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnSubmit" Text="Add Product" runat="server" OnClick="btnSubmit_Click" />
            <asp:Label ID="lblResponse" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
