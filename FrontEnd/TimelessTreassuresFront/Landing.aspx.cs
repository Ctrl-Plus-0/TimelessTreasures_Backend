using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TimelessTreassuresFront
{
    public partial class Landing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string usertype = (string)Session["UserType"];
            NavBarset(usertype);
        }

        private void NavBarset(string Utype)
        {
            Front Masterpage = Master as Front;
            var customerbar = Masterpage.FindControl("CustomerNav") as Control;
            var adminbar = Masterpage.FindControl("AdminNav") as Control;
            var regloginbar = Masterpage.FindControl("RegLoginNav") as Control;
            if (Masterpage != null && (customerbar != null | adminbar != null | regloginbar != null))
            {
                switch (Utype)
                {
                    case "Customer":

                        customerbar.Visible = true;
                        regloginbar.Visible = false;
                        break;
                    case "Admin":

                        adminbar.Visible = true;
                        regloginbar.Visible = false;
                        break;

                    default:
                        return;
                }
            }
        }
    }

}
