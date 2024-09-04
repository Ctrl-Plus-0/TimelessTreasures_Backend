<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TimelessTreassuresFront.Register" %>
<asp:Content ID="Head" ContentPlaceHolderID="head" runat="server">

    <title>Register</title>
    <!--ADDITIONAL CSS FOR THE REGISTER BLOCK -->
    <!--<link rel="stylesheet" href="assets/css/LoginRegister.css"/>-->
    <style>
        .main-button {
            background-color: #FFECD1;
        }
        .main-button:hover {
          background-color: #FF7D00;
        }
    </style>
</asp:Content>


  <asp:Content ID="Main" ContentPlaceHolderID="Main" runat="server" >

      <div class="col-lg-12">
        <div class="contact-form" style="background-color:#001524; color: #FFECD1; margin: auto; max-width: 500px; margin-top: 100px;">
            <div id="contact" class="form" action="" method="post">
                <div class="row">
                    <div class="col-lg-12">
                        <h3>Register</h3>
                    </div>
                    <div class="col-lg-12">
                        <fieldset>
                          <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
                          <br />
                          <asp:TextBox ID="txtEmail" runat="server" style="color:black"></asp:TextBox>
                        </fieldset>
                    </div>
                    <div class="col-lg-12">
                        <fieldset>
                          <asp:Label ID="NameLabel" runat="server" Text="Name"></asp:Label>
                          <br />
                          <asp:TextBox ID="txtName" runat="server" style="color:black"></asp:TextBox>
                        </fieldset>
                    </div>
                    <div class="col-lg-12">
                        <fieldset>
                          <asp:Label ID="SurnameLabel" runat="server" Text="Surname"></asp:Label>
                          <br />
                          <asp:TextBox ID="txtSurname" runat="server" style="color:black"></asp:TextBox>
                        </fieldset>
                    </div>
                    <div class="col-lg-12">
                        <fieldset>
                          <asp:Label ID="AddyLabel" runat="server" Text="Address"></asp:Label>
                          <br />
                          <asp:TextBox ID="txtAddy" runat="server" style="color:black"></asp:TextBox>
                        </fieldset>
                    </div>
                    <div class="col-lg-12">
                        <fieldset>
                          <asp:Label ID="ContactLabel" runat="server" Text="Contact Number"></asp:Label>
                          <br />
                          <asp:TextBox ID="txtContact" runat="server" style="color:black"></asp:TextBox>
                        </fieldset>
                    </div>
                    <div class="col-lg-12">
                        <fieldset>
                          <asp:Label ID="UsernameLabel" runat="server" Text="Username"></asp:Label>
                          <br />
                          <asp:TextBox ID="TxtUsername" runat="server" style="color:black"></asp:TextBox>
                        </fieldset>
                    </div>
                    <div class="col-lg-12">
                        <fieldset>
                          <asp:Label ID="PasswordLabel" runat="server" Text="Password"></asp:Label>
                          <br />
                          <asp:TextBox ID="TxtPass" runat="server" style="color:black"></asp:TextBox>
                        </fieldset>
                    </div>
                    <div class="col-lg-12">
                        <fieldset>
                            <asp:Button ID="BtnReg" runat="server" Text="Register" OnClick="BtnReg_Click" type="submit" class="main-button" style="border-radius: 25px; color: #001524;"/>
                            <br />
                        </fieldset>
                    </div>
                    <div class="col-lg-12">
                        <fieldset>
                            <asp:Label ID="Msglabel" runat="server" Text=""
                                style="color:red"></asp:Label>
                        </fieldset>
                    </div>
                </div>
            </div>
        </div>
    </div>

  </asp:Content>