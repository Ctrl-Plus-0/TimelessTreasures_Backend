using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimelessTreasuresWeb1.ServiceReference1;
using HashPass;


namespace TimelessTreasuresWeb1
{
    public partial class AddStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            string fullName = txtFullName.Text;
            string surname = txtSurname.Text;
            string userName = txtUserName.Text;
            string email = txtEmail.Text;
            string password = Secrecy.HashPassword(txtPassword.Text);
            int role = int.Parse(ddlRole.SelectedValue);

            //if no role is selected dont let them proceed with registration
            //stop and send message
            if (role == 0)
            {
                lblResponse.ForeColor = System.Drawing.Color.Yellow;
                lblResponse.Text = "Please Select a Valid Manager Type";
                return;
            }



            Service1Client client = new Service1Client();
            int result = client.AddStaffMember(fullName, surname, userName, email, password,role);
            
            if (result == 0)
            {
                lblResponse.ForeColor = System.Drawing.Color.Green;
                lblResponse.Text = "Staff Member Added Successfully";
            }
            else if (result == 1)
            {
                lblResponse.ForeColor = System.Drawing.Color.Yellow;
                lblResponse.Text = "Staff Member Already Exists";
            }
            else if (result == 2)
            {
                lblResponse.ForeColor = System.Drawing.Color.Yellow;
                lblResponse.Text = "Email Already In Use";
            }
            else
            {
                lblResponse.ForeColor = System.Drawing.Color.Red;
                lblResponse.Text = "Internal Server Error";
            }
        }
    }
}
