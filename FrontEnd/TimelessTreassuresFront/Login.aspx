<%@ Page Title="" Language="C#" MasterPageFile="~/Front.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TimelessTreassuresFront.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>Login</title>
    <!--ADDITIONAL CSS FOR THE Login BLOCK -->
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
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

    <div class="col-lg-12" style="max-width: 500px; margin: auto; margin-top: 100px;">
        <div class="contact-form" style="background-color:#001524; color: #FFECD1;";>
            <div id="contact" class="form" action="" method="post">
                <div class="row">
                    <div class="col-lg-12" style="padding-bottom: 20px;">
                        <h3>Log In</h3>
                    </div>
                    <div class="col-lg-12">
                        <fieldset>
                          <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
                          <br />
                          <asp:TextBox ID="txtEmail" runat="server" name="email" type="email" placeholder="E-Mail Address" required=""
                                                Style="background-color: rgba(250,250,250,0.3); border-radius: 25px;"></asp:TextBox>
                        </fieldset>
                    </div>
                    <div class="col-lg-12">
                        <fieldset>
                          <asp:Label ID="PassLabel" runat="server" Text="Password"></asp:Label>
                          <br />
                          <asp:TextBox ID="txtPass" runat="server" name="password" type="password" placeholder="Password"
                                                required="" style="background-color: rgba(250,250,250,0.3); border-radius: 25px;"></asp:TextBox>
                        </fieldset>
                    </div>
                    <div class="col-lg-12">
                        <fieldset>
                          <asp:Button ID="BtnLogin" runat="server" Text="Login" OnClick="BtnLogin_Click" type="submit" class="main-button" style="border-radius: 25px; color: #001524;"/>
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
