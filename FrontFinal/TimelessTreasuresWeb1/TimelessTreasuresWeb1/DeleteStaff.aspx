<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="DeleteStaff.aspx.cs" Inherits="TimelessTreasuresWeb1.DeleteStaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
   
        <div>
            <h2>Delete Staff Member</h2>
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
                <asp:Label ID="lblFullNameValue" runat="server"></asp:Label><br />
                <asp:Label ID="lblSurname" runat="server" Text="Surname:"></asp:Label><br />
                <asp:Label ID="lblSurnameValue" runat="server"></asp:Label><br />
                <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label><br />
                <asp:Label ID="lblEmailValue" runat="server"></asp:Label><br />
                <asp:Label ID="lblRole" runat="server" Text="Role:"></asp:Label><br />
                <asp:Label ID="lblRoleValue" runat="server"></asp:Label><br />

                <asp:Button ID="btnDelete" runat="server" Text="Delete Staff" OnClick="btnDelete_Click" />
            </asp:Panel>
        </div>
   
</asp:Content>