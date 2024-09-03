<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TimelessTreassuresFront.Register" %>
<asp:Content ID="Head" ContentPlaceHolderID="head" runat="server">

    <title>Register</title>
    <!--ADDITIONAL CSS FOR THE REGISTER BLOCK -->
    <link rel="stylesheet" href="assets/css/LoginRegister.css"/>
</asp:Content>


  <asp:Content ID="Main" ContentPlaceHolderID="Main" runat="server">

      <div class="Formblock">
          <h3>Register</h3>

          <div class="Label_Box">

              <div class="LabelTextbox">
                  <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
                  <br />
                  <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
          
              </div>
          </div>

            <div class="Label_Box">

              <div class="LabelTextbox">
                  <asp:Label ID="NameLabel" runat="server" Text="Name"></asp:Label>
                  <br />
                  <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
              </div>
          </div>

            <div class="Label_Box">

              <div class="LabelTextbox">
                  <asp:Label ID="SurnameLabel" runat="server" Text="Surname"></asp:Label>
                  <br />
                  <asp:TextBox ID="txtSurname" runat="server"></asp:TextBox>
              </div>
          </div>

            <div class="Label_Box">

              <div class="LabelTextbox">
                  <asp:Label ID="AddyLabel" runat="server" Text="Address"></asp:Label>
                  <br />
                  <asp:TextBox ID="txtAddy" runat="server"></asp:TextBox>
              </div>
          </div>

            <div class="Label_Box">

              <div class="LabelTextbox">
                  <asp:Label ID="ContactLabel" runat="server" Text="Contact Number"></asp:Label>
                  <br />
                  <asp:TextBox ID="txtContact" runat="server"></asp:TextBox>
              </div>
          </div>

           <div class="Label_Box">

              <div class="LabelTextbox">
                  <asp:Label ID="UsernameLabel" runat="server" Text="Username"></asp:Label>
                  <br />
                  <asp:TextBox ID="TxtUsername" runat="server"></asp:TextBox>
              </div>
          </div>

           <div class="Label_Box">

              <div class="LabelTextbox">
                  <asp:Label ID="PasswordLabel" runat="server" Text="Password"></asp:Label>
                  <br />
                  <asp:TextBox ID="TxtPass" runat="server"></asp:TextBox>
              </div>
          </div>

            <div class="BtnReg">


          <asp:Button ID="BtnReg" runat="server" Text="Register" OnClick="BtnReg_Click" />
          <br />

      </div>

      <div class="Label_Box">
          <asp:Label ID="Msglabel" runat="server" Text=""
              style="color:red"></asp:Label>

      </div>

      </div>

    


  </asp:Content>