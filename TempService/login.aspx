<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TempService.login" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />
    <link href="login.css" rel="stylesheet" />
    <script src="login.js" defer="defer"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" onsubmit="">
        <div id="container" class="container">
            <!-- FORM SECTION -->
            <div class="row">
                <!-- SIGN UP -->
                <div class="col align-items-center flex-col sign-up">
                    <div class="form-wrapper align-items-center">
                        <div class="form sign-up">
                            <div class="input-group">
                                <i class='bx bxs-user'></i>
                                <asp:TextBox runat="server" ID="regUsername" Text="Username"></asp:TextBox>
                            </div>
                            <div class="input-group">
                                <i class='bx bxs-user'></i>
                                <asp:TextBox runat="server" ID="regFName" Text="First Name"></asp:TextBox>

                            </div>
                            <div class="input-group">
                                <i class='bx bxs-user'></i>
                                <asp:TextBox runat="server" ID="regLName" Text="Last Name"></asp:TextBox>
                            </div>
                            <div class="input-group">
                                <i class='bx bx-mail-send'></i>
                                <asp:TextBox runat="server" ID="regEmail" Text="Email"></asp:TextBox>
                            </div>
                            <div class="input-group">
                                <i class='bx bxs-lock-alt'></i>
                                <asp:TextBox runat="server" ID="regPassword1" Text="Password"></asp:TextBox>
                            </div>
                            <div class="input-group">
                                <i class='bx bxs-lock-alt'></i>
                                <asp:TextBox runat="server" ID="regPassword2" Text="Password"></asp:TextBox>
                            </div>
<%--                            <asp:Button ID="btnReg" runat="server" OnClick="SubmitRegister" Text="Sign Up" CssClass="btnSubmit"/>--%>
                                <button>Sign Up</button>

                            <p>
                                <span>Already have an account?
                                </span>
                                <b onclick="toggle()" class="pointer">Sign in here
                                </b>
                            </p>
                        </div>
                    </div>

                </div>
                <!-- END SIGN UP -->
                <!-- SIGN IN -->
                <div class="col align-items-center flex-col sign-in">
                    <div class="form-wrapper align-items-center">
                        <div class="form sign-in">
                            <div class="input-group">
                                <i class='bx bxs-user'></i>
                                <input type="text" placeholder="Email" id="logEmail">
                            </div>
                            <div class="input-group">
                                <i class='bx bxs-lock-alt'></i>
                                <input type="password" placeholder="Password" id="logPassword">
                            </div>

                            <div  class="btnSubmit">
                                                            <a href="index.aspx" class="btnSubmit">
                                Sign in
                           </a>
                            </div>

                            
                            <p>
                                <b>Forgot password?
                                </b>
                            </p>
                            <p>
                                <span>Don't have an account?
                                </span>
                                <b onclick="toggle()" class="pointer">Sign up here
                                </b>
                            </p>
                        </div>
                    </div>
                    <div class="form-wrapper">
                    </div>
                </div>
                <!-- END SIGN IN -->
            </div>
            <!-- END FORM SECTION -->
            <!-- CONTENT SECTION -->
            <div class="row content-row">
                <!-- SIGN IN CONTENT -->
                <div class="col align-items-center flex-col">
                    <div class="text sign-in">
                        <h2>Welcome
                        </h2>

                    </div>
                    <div class="img sign-in">
                    </div>
                </div>
                <!-- END SIGN IN CONTENT -->
                <!-- SIGN UP CONTENT -->
                <div class="col align-items-center flex-col">
                    <div class="img sign-up">
                    </div>
                    <div class="text sign-up">
                        <h2>Join with us
                        </h2>

                    </div>
                </div>
                <!-- END SIGN UP CONTENT -->
            </div>
            <!-- END CONTENT SECTION -->
        </div>
    </form>
</body>
</html>

