<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditStaff.aspx.cs" Inherits="TimelessTreasuresWeb1.EditStaff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Edit Staff Member</h2>
            <asp:Label ID="lblResponse" runat="server" ForeColor="Red"></asp:Label><br />

            <asp:Label ID="lblSearchName" runat="server" Text="Enter Staff Full Name:"></asp:Label><br />
            <asp:TextBox ID="txtSearchName" runat="server"></asp:TextBox><br />

            <asp:Label ID="lblSearchSurname" runat="server" Text="Enter Staff Surname:"></asp:Label><br />
            <asp:TextBox ID="txtSearchSurname" runat="server"></asp:TextBox><br />

            <asp:Button ID="btnSearch" runat="server" Text="Search Staff" OnClick="btnSearch_Click" /><br /><br />

            <!-- Staff details section (visible only when staff is found) -->
            <asp:Panel ID="StaffPanel" runat="server" Visible="false">
                <h3>Staff Details</h3>
                <asp:Label ID="lblFullName" runat="server" Text="Full Name:"></asp:Label><br />
                <asp:TextBox ID="txtFullName" runat="server" ReadOnly="true"></asp:TextBox><br />
                
                <asp:Label ID="lblSurname" runat="server" Text="Surname:"></asp:Label><br />
                <asp:TextBox ID="txtSurname" runat="server" ReadOnly="true"></asp:TextBox><br />
                
                <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label><br />
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />

                
                
                <asp:DropDownList ID="ddlRole" runat="server"  >
                <asp:ListItem  Selected="True" Value="0">Select Manager Type</asp:ListItem>
                <asp:ListItem Value="1">Head Manager</asp:ListItem>
                <asp:ListItem Value="2">Standard Manager</asp:ListItem>
            </asp:DropDownList>
                <br />

                <asp:Button ID="btnEdit" runat="server" Text="Edit Staff" OnClick="btnEdit_Click" />
            </asp:Panel>
        </div>
    </form>
</body></html>
