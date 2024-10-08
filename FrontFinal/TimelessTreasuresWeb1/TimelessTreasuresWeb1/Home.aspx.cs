using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TimelessTreasuresWeb1
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var master = Master as Web;
                string Role = Convert.ToString(Session["UserType"]);

                if (master != null) 
                {
                    if (Role.Equals("Customer"))
                    {
                        master.getWishlist.Visible = true;
                        master.getShoppingBag.Visible = true;
                        master.getUser.Visible = true;
                        master.getLogin.Visible = false;
                        master.getLogout.Visible = true;
                    }
                    else if (Role.Equals("Manager"))
                    {
                        master.getManageProducts.Visible = true;
                        master.getWishlist.Visible = false;
                        master.getShoppingBag.Visible = false;
                        master.getUser.Visible = true;
                        master.getLogin.Visible = false;
                        master.getLogout.Visible = true;
                    }
                    else if (Role.Equals("Head Manager"))
                    {
                        master.getManageProducts.Visible = true;
                        master.getManageStaff.Visible = true;
                        master.getUser.Visible = true;
                        master.getWishlist.Visible = false;
                        master.getShoppingBag.Visible = false;
                        master.getLogin.Visible = false;
                        master.getLogout.Visible = true;
                    }
                    else
                    {
                        master.getLogin.Visible = true;
                    }
                }
            }
        }
    }
}