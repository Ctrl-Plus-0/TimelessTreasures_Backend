using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimelessTreasuresWeb1.ServiceReference1;


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
            string password = txtPassword.Text;
            string role = txtRole.Text;

            Service1Client client = new Service1Client();
            int result = client.AddStaffMember(fullName, surname, userName, email, password, role);

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
            else
            {
                lblResponse.ForeColor = System.Drawing.Color.Red;
                lblResponse.Text = "Internal Server Error";
            }
        }
    }
}
