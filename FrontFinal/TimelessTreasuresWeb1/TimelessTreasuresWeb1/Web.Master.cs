using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TimelessTreasuresWeb1
{
    public partial class Web : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public HtmlControl getWishlist
        {
            get { return WISHLIST; }
        }

        public HtmlControl getShoppingBag
        {
            get { return SHOPPINGBAG; }
        }

        public HtmlControl getUser
        {
            get { return USER; }
        }

        public HtmlControl getSearch
        {
            get { return search; }
        }

        public HtmlControl getManageProducts
        {
            get { return MANAGE_PRODUCTS; }
        }

        public HtmlControl getManageStaff
        {
            get { return MANAGE_STAFF; }
        }

        public HtmlControl getLogin
        {
            get { return LOGIN; }
        }
        public HtmlControl getLogout
        {
            get { return LOGOUT; }
        }
    }
}