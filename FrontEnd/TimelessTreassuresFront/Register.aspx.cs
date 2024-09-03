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
    public partial class Register : System.Web.UI.Page
    {
       
        protected void BtnReg_Click(object sender, EventArgs e)
        {
            Service1Client Client = new Service1Client();

            string Name = txtName.Text;
            string Surname = txtSurname.Text;
            string Address = txtAddy.Text;
            string PhoneNO = txtContact.Text;
            string Email = txtEmail.Text;
            string Username = TxtUsername.Text;
            string Password =     Secrecy.HashPassword(TxtPass.Text);

            string RegistrationStatus = Client.Register(Email, Name, Username, Surname, PhoneNO, Password, Address);

            if(RegistrationStatus == "User Succesfully Registered")
            {
                Msglabel.Text = "Registration succesful, proceed to login";
            }else if( RegistrationStatus == "Already Registred")
            {
                Msglabel.Text = "User alredy registered, please login instead!";
            }
            else
            {
                Msglabel.Text = "An error has occured";
            }

        }
    }
}