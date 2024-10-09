<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="EditStaff.aspx.cs" Inherits="TimelessTreasuresWeb1.EditStaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
       <section class="login_box_area section_gap" id="VisibleForm" runat="server" visible="true" >
		<div class="container">
			<div class="row">
			
				<div class="col-lg-6">
					<div class="login_form_inner">
                        <h3 id="form-head">Edit Staff Member</h3>
                    <div class="row login_form" action="contact_process.php" method="post" id="contactForm" novalidate="novalidate">
						
							<div class="col-md-12 form-group">
							<asp:TextBox CssClass="form-control" ID="txtSearchName" runat="server" style="color:black" placeholder="Manager To Edit Name*" required="required"></asp:TextBox>
                        </div>
							<div class="col-md-12 form-group">
                          <asp:TextBox CssClass="form-control" ID="txtSearchSurname" runat="server" style="color:black" placeholder="Manager To Edit Surname*" required="required" TextMode="SingleLine"></asp:TextBox>
                        </div>
				
						
							<div class="col-md-12 form-group">
								<asp:Button CssClass="primary-btn" ID="btnSearch" runat="server" Text="Search Staff"  type="submit" OnClick="btnSearch_Click" />
                        </div>
							<div class="col-md-12 form-group">
                            <asp:Label ID="Label1" runat="server" Text=""
                                ></asp:Label>
                        </div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</section>
   
      <section class="login_box_area section_gap" id="StaffPanel" runat="server" visible="false" >
		<div class="container">
			<div class="row">
			
				<div class="col-lg-6">
					<div class="login_form_inner">
                        <h3 id="form-head1">Staff Details</h3>
                    <div class="row login_form" action="contact_process.php" method="post" id="contactForm1" novalidate="novalidate">
						
							<div class="col-md-12 form-group" style="background-color: transparent; border: none;">
							<asp:Label CssClass="form-control"   ID="lblFullName" runat="server" style="color:black;background-color: transparent; border: none;"  Readonly="true">Full Name</asp:Label>
                        </div>
							<div class="col-md-12 form-group">
                          <asp:TextBox CssClass="form-control" ID="txtFullName" runat="server" style="color:black" Readonly="true" TextMode="SingleLine"></asp:TextBox>
                        </div>
				

							<div class="col-md-12 form-group">
                          <asp:Label CssClass="form-control" ID="lblSurname" runat="server" style="color:black;background-color: transparent; border: none;" Readonly="true" TextMode="SingleLine">Surname</asp:Label>
                        </div>

							<div class="col-md-12 form-group">
                          <asp:TextBox CssClass="form-control" ID="txtSurname" runat="server" style="color:black" Readonly="true" TextMode="SingleLine"></asp:TextBox>
                        </div>

								<div class="col-md-12 form-group">
                          <asp:Label CssClass="form-control" ID="lblEmail" runat="server" style="color:black;background-color: transparent; border: none;" Readonly="true" TextMode="SingleLine">Email</asp:Label>
                        </div>

								<div class="col-md-12 form-group">
                          <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server" style="color:black;background-color: transparent; border: none;" Readonly="true" TextMode="SingleLine"></asp:TextBox>
                        </div>

							<div class="col-md-12 form-group">
                 <asp:DropDownList ID="ddlRole" runat="server"  >
                <asp:ListItem  Selected="True" Value="0">Select Manager Type</asp:ListItem>
                <asp:ListItem Value="1">Head Manager</asp:ListItem>
                <asp:ListItem Value="2">Standard Manager</asp:ListItem>
            </asp:DropDownList>
                        </div>
						
							<div class="col-md-12 form-group">
								<asp:Button CssClass="primary-btn" ID="btnEdit" runat="server" Text="Edit Staff"  type="submit" OnClick="btnEdit_Click" />
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