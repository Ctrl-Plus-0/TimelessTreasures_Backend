<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="DeleteStaff.aspx.cs" Inherits="TimelessTreasuresWeb1.DeleteStaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

		<section class="banner-area organic-breadcrumb">
		<div class="container">
			<div class="breadcrumb-banner d-flex flex-wrap align-items-center justify-content-end">
				<div class="col-first">
					<h1>Delete Staff</h1>
				
				</div>
			</div>
		</div>
	</section>
   
    <section class="login_box_area section_gap" id="VisibleForm" runat="server" visible="true">
		<div class="container">
			<div class="row">
			
				<div class="col-lg-6">
					<div class="login_form_inner">
                        <h3 id="form-head">Delete Staff Member</h3>
                    <div class="row login_form" action="contact_process.php" method="post" id="contactForm" novalidate="novalidate">
						
							<div class="col-md-12 form-group">
							<asp:TextBox CssClass="form-control" ID="txtSearchName" runat="server" style="color:black" placeholder="Manager To Remove Name*" required="required"></asp:TextBox>
                        </div>
							<div class="col-md-12 form-group">
                          <asp:TextBox CssClass="form-control" ID="txtSearchSurname" runat="server" style="color:black" placeholder="Manager To Remove Surname*" required="required" TextMode="SingleLine"></asp:TextBox>
                        </div>
				
						
							<div class="col-md-12 form-group">
								<asp:Button CssClass="primary-btn" ID="btnSearch" runat="server" Text="Search Staff"  type="submit" OnClick="btnSearch_Click" />
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
                          <asp:TextBox CssClass="form-control" ID="lblFullNameValue" runat="server" style="color:black" Readonly="true" TextMode="SingleLine"></asp:TextBox>
                        </div>
				

							<div class="col-md-12 form-group">
                          <asp:Label CssClass="form-control" ID="lblSurname" runat="server" style="color:black;background-color: transparent; border: none;" Readonly="true" TextMode="SingleLine">Surname</asp:Label>
                        </div>

							<div class="col-md-12 form-group">
                          <asp:TextBox CssClass="form-control" ID="lblSurnameValue" runat="server" style="color:black" Readonly="true" TextMode="SingleLine"></asp:TextBox>
                        </div>

								<div class="col-md-12 form-group">
                          <asp:Label CssClass="form-control" ID="lblEmail" runat="server" style="color:black;background-color: transparent; border: none;" Readonly="true" TextMode="SingleLine">Email</asp:Label>
                        </div>

								<div class="col-md-12 form-group">
                          <asp:TextBox CssClass="form-control" ID="lblEmailValue" runat="server" style="color:black;background-color: transparent; border: none;" Readonly="true" TextMode="SingleLine"></asp:TextBox>
                        </div>

									<div class="col-md-12 form-group">
                          <asp:Label CssClass="form-control" ID="lblRole" runat="server" style="color:black;background-color: transparent; border: none;" Readonly="true" TextMode="SingleLine">Role</asp:Label>
                        </div>
									<div class="col-md-12 form-group">
                          <asp:TextBox CssClass="form-control" ID="lblRoleValue" runat="server" style="color:black" Readonly="true" TextMode="SingleLine"></asp:TextBox>
                        </div>
						
							<div class="col-md-12 form-group">
								<asp:Button CssClass="primary-btn" ID="btnDelete" runat="server" Text="Delete Staff"  type="submit" OnClick="btnDelete_Click" />
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
   
   
</asp:Content>