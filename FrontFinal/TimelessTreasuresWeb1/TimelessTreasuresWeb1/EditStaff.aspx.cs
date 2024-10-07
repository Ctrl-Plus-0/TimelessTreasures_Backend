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

            var staff = client.GetStaffMemberByFullNameAndSurname(fullName, surname);

            if (staff != null)
            {

                txtFullName.Text = staff.UFullName;
                txtSurname.Text = staff.USurname;
                txtEmail.Text = staff.UEmail;
                txtRole.Text = staff.Urole;


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
            string role = txtRole.Text;

            if (!string.IsNullOrEmpty(fullName) && !string.IsNullOrEmpty(surname))
            {
                Service1Client client = new Service1Client();
                int result = client.EditStaffMember(fullName, surname, email, role);

                if (result == 0)
                {
                    lblResponse.Text = "Staff member details updated successfully.";
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