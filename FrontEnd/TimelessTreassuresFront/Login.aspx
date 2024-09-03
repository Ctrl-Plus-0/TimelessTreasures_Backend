<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TimelessTreassuresFront.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>Login</title>
    <!--ADDITIONAL CSS FOR THE Login BLOCK -->
    <link rel="stylesheet" href="assets/css/LoginRegister.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

    <div class="Formblock">
          <h3>Login</h3>

          <div class="Label_Box">

              <div class="LabelTextbox">
                  <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
                  <br />
                  <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
          
              </div>
          </div>

            <div class="Label_Box">

              <div class="LabelTextbox">
                  <asp:Label ID="PassLabel" runat="server" Text="Password"></asp:Label>
                  <br />
                  <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
              </div>
          </div>

    
            <div class="BtnReg">


          <asp:Button ID="BtnLogin" runat="server" Text="Login" OnClick="BtnLogin_Click" />
          <br />

      </div>

      <div class="Label_Box">
          <asp:Label ID="Msglabel" runat="server" Text=""
              style="color:red"></asp:Label>

      </div>

      </div>

</asp:Content>
