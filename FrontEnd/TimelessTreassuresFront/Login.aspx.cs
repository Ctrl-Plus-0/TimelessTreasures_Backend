using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TimelessTreassuresFront.ServiceReference1;
using HashPass;

namespace TimelessTreassuresFront
{
    public partial class Login : System.Web.UI.Page
    {

        //This method wllneed to cheange to accomodate session varaibles but for now
        //This will do
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            Service1Client Client = new Service1Client();

            string email = txtEmail.Text;
            string password = Secrecy.HashPassword(txtPass.Text);

            string loginstatus = Client.login(email, password);

            if (loginstatus == "Username Or Password is Incorrect")
            {

                Msglabel.Text = "Incorrect Username or Passowrd";

            }
            else
            {
                //create a session variable fot the login status
                //this will be used by  landing page to change the navbar type
                Session["UserType"] = loginstatus;

                Response.Redirect("Landing.aspx");


            }
        }
    }
       

    
}