<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStaff.aspx.cs" Inherits="TimelessTreasuresWeb1.AddStaff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label for="txtFullName">Full Name:</label>
            <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
            <br />
            <label for="txtSurname">Surname:</label>
            <asp:TextBox ID="txtSurname" runat="server"></asp:TextBox>
            <br />
            <label for="txtUserName">User Name:</label>
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            <br />
            <label for="txtEmail">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <br />
            <label for="txtPassword">Password:</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <label for="txtRole">Role:</label>
            <asp:TextBox ID="txtRole" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Add Staff Member" OnClick="btnSubmit_Click" />
            <br />
            <asp:Label ID="lblResponse" runat="server" ForeColor="Green"></asp:Label>
        </div>
    </form>
</body>
</html>
