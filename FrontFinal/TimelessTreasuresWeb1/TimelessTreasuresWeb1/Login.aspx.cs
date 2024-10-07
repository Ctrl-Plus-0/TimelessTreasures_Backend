using HashPass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimelessTreasuresWeb1.ServiceReference1;

namespace TimelessTreasuresWeb1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
      

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            Service1Client Client = new Service1Client();

            string email = txtEmail.Text;
            string password = Secrecy.HashPassword(txtPass.Text);

            int loginstatus = Client.login(email, password);

            if (loginstatus == -1)
            {

                Msglabel.Text = "Incorrect Username or Passowrd";

            }
            else if (loginstatus == 0)
            {
                //create a session variable fot the login status
                //this will be used by  landing page to change the navbar type


                Session["UserType"] = "Customer";  //*****//
                Session["UserId"] = Client.GetUserID(email, password);
                Response.Redirect("Home.aspx");


            }
            else if (loginstatus == 1)
            {
                Session["UserType"] = "Head Manager";  //*****//
                Session["UserId"] = Client.GetUserID(email, password);
                Response.Redirect("Home.aspx");
            }
            else if (loginstatus == 2)
            {
                Session["UserType"] = "Manager";  //*****//
                Session["UserId"] = Client.GetUserID(email, password);
                Response.Redirect("Home.aspx");
            }
        }

        
    }
}