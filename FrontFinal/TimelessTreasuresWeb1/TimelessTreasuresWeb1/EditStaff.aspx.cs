using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimelessTreasuresWeb1.ServiceReference1;

namespace TimelessTreasuresWeb1
{


    public partial class EditStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string fullName = txtSearchName.Text.Trim();
            string surname = txtSearchSurname.Text.Trim();

            if (!string.IsNullOrEmpty(fullName) && !string.IsNullOrEmpty(surname))
            {

                LoadStaffDetails(fullName, surname);
            }
            else
            {
                lblResponse.Text = "Please enter the staff member's full name and surname to search.";
            }
        }

        private void LoadStaffDetails(string fullName, string surname)
        {
            Service1Client client = new Service1Client();


            StaffMember staff = client.GetStaffMemberByFullNameAndSurname(fullName, surname);

            //After getting the staf using the above method
            //create a session variable to store the id of the 
            //memeber to be edited
            //this session variable is deleted once edit is made
            Session["EditID"] = staff.UId.ToString(); 

            if (staff != null)
            {

                txtFullName.Text = staff.UFullName;
                txtSurname.Text = staff.USurname;
                txtEmail.Text = staff.UEmail;
                ddlRole.SelectedValue = staff.PermType.ToString();


                txtFullName.ReadOnly = true;
                txtSurname.ReadOnly = true;


                StaffPanel.Visible = true;
                lblResponse.Text = "Staff member found. You can now edit their details.";
            }
            else
            {
                lblResponse.Text = "Staff member not found.";
                StaffPanel.Visible = false;
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text;
            string surname = txtSurname.Text;
            string email = txtEmail.Text;
            int role =int.Parse(ddlRole.SelectedValue);
            int Memberid = int.Parse(Session["EditID"].ToString());

            if (!string.IsNullOrEmpty(fullName) && !string.IsNullOrEmpty(surname))
            {
                Service1Client client = new Service1Client();
                int result = client.EditStaffMember(Memberid,fullName, surname, email, role);

                if (result == 0)
                {
                    lblResponse.Text = "Staff member details updated successfully.";
                    Session.Remove("EditID");
                    //add in code here to clear screen again
                }
                else
                {
                    lblResponse.Text = "An error occurred while updating the staff member details.";
                }
            }
            else
            {
                lblResponse.Text = "Please search for a staff member first.";
            }
        }
    }
}