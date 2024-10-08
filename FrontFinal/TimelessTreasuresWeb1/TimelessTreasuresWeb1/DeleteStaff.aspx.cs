using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimelessTreasuresWeb1.ServiceReference1;

namespace TimelessTreasuresWeb1
{

    public partial class DeleteStaff : System.Web.UI.Page
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
                // Call the method to load staff details
                LoadStaffDetails(fullName, surname);
            }
            else
            {
                lblResponse.Text = "Please enter both the staff member's full name and surname to search.";
            }
        }

        private void LoadStaffDetails(string fullName, string surname)
        {

            Service1Client client = new Service1Client();
            StaffMember staff = client.GetStaffMemberByFullNameAndSurname(fullName, surname);

            if (staff != null)
            {
                // Populate the labels with staff details
                lblFullNameValue.Text = staff.UFullName;
                lblSurnameValue.Text = staff.USurname;
                lblEmailValue.Text = staff.UEmail;
                lblRoleValue.Text = staff.Urole;

                // Show the staff panel
                StaffPanel.Visible = true;

                lblResponse.Text = "Staff member found. You can now delete them.";
            }
            else
            {
                lblResponse.Text = "Staff member not found.";
                StaffPanel.Visible = false;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string fullName = lblFullNameValue.Text;
            string surname = lblSurnameValue.Text;

            if (!string.IsNullOrEmpty(fullName) && !string.IsNullOrEmpty(surname))
            {
                Service1Client client = new Service1Client();
                int result = client.DeleteStaffMember(fullName, surname);

                if (result == 0)
                {
                    lblResponse.Text = "Staff member deleted successfully.";
                    StaffPanel.Visible = false;
                }
                else
                {
                    lblResponse.Text = "An error occurred while deleting the staff member.";
                }
            }
            else
            {
                lblResponse.Text = "Please search for a staff member first.";
            }
        }
    }
}