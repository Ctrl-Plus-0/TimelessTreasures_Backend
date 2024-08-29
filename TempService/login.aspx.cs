using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TempService.ServiceReference1;

namespace TempService
{
    public partial class login : System.Web.UI.Page
    {
        ServiceReference1.Service1Client sc = new ServiceReference1.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SubmitRegister(object sender, EventArgs e)
        {
            Console.Write("hERE");

            bool isReg = false;

            string username = regUsername.Text;
            string fname = regFName.Text;
            string lname = regLName.Text;
            string email = regEmail.Text;
            string password1 = regPassword1.Text;
            string password2 = regPassword2.Text;

            if (password1 == password2)
            {
                string results = sc.Register(email, fname, username, lname, "1", password1, "xxxx");
                if(results.Equals("User Succesfully Registered"))
                {
                    isReg = true;
                }

                if (isReg)
                {
                   
                }
            }

     
        }

        public bool SubmitLogin(object sender, EventArgs e)
        {
            

            bool isLog = false;

            string email = Request.Form["logEmail"];
            string password = Request.Form["logPassword"];

            string result = sc.login(email, password);

            if (result.Equals("User Succesfully Registered"))
            {
                Response.Redirect("index.aspx");
            }

            return isLog;

        }
    }
}