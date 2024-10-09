<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="AddStaff.aspx.cs" Inherits="TimelessTreasuresWeb1.AddStaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
  <section class="login_box_area section_gap" id="VisibleForm" runat="server" >
		<div class="container">
			<div class="row">
			
				<div class="col-lg-6">
					<div class="login_form_inner">
                        <h3 id="form-head">Add Manager</h3>
                    <div class="row login_form" action="contact_process.php" method="post" id="contactForm" novalidate="novalidate">
						
							<div class="col-md-12 form-group">
							<asp:TextBox CssClass="form-control" ID="txtFullName" runat="server" style="color:black" placeholder="Manager Name*" required="required"></asp:TextBox>
                        </div>
							<div class="col-md-12 form-group">
                          <asp:TextBox CssClass="form-control" ID="txtSurname" runat="server" style="color:black" placeholder="Manager Surname*" required="required" TextMode="SingleLine"></asp:TextBox>
                        </div>
							<div class="col-md-12 form-group">
                          <asp:TextBox CssClass="form-control" ID="txtUserName" runat="server" style="color:black" placeholder="Manager Username*" required="required"></asp:TextBox>
                        </div>
							<div class="col-md-12 form-group">
                          <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server" style="color:black" placeholder="Email*" TextMode="Email" required="required"></asp:TextBox>
                        </div>
                        	<div class="col-md-12 form-group">
                          <asp:TextBox CssClass="form-control" ID="txtPassword" runat="server" style="color:black" placeholder="Password*" TextMode="Password" required="required"></asp:TextBox>
                        </div>
						<div class="col-md-12 form-group">
                        <asp:DropDownList ID="ddlRole" runat="server"  >
                <asp:ListItem  Selected="True" Value="0">Select Manager Type</asp:ListItem>
                <asp:ListItem Value="1">Head Manager</asp:ListItem>
                <asp:ListItem Value="2">Standard Manager</asp:ListItem>
            </asp:DropDownList>
                        </div>
						
							<div class="col-md-12 form-group">
								<asp:Button CssClass="primary-btn" ID="btnSubmit" runat="server" Text="Add Manager"  type="submit" OnClick="btnSubmit_Click" />
                        </div>
							<div class="col-md-12 form-group">
                            <asp:Label ID="lblResponse" runat="server" Text=""
                                ></asp:Label>
                        </div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</section>



   
</asp:Content>