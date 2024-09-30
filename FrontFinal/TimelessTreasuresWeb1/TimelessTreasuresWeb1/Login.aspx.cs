﻿using HashPass;
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

                Response.Redirect("Home.aspx");


            }
        }

        protected void btnUserLogin_Click(object sender, EventArgs e)
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

                Response.Redirect("Home.aspx");


            }
        }
    }
}