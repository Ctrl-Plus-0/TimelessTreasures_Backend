using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TempService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        TempDatabaseDataContext DB = new TempDatabaseDataContext();
        string IService1.login(string Email, string Password)
        {
            throw new NotImplementedException();
        }

        string IService1.Register(string Email, string Name, string Username, string Surname, string Number, string Password, string Address,string phonenum)
        {
            //First check the database to see if there already exists a user with a specefic email
            //If so return a string saying theyve already registered adn that they should log in instead

            var UserExistCheck = (from c in DB.PUsers
                                  where c.UEmail == Email
                                  select c).FirstOrDefault();

            if (UserExistCheck != null)
            {
                return "You are already registered, please login instead.";
            }

            var UserToStore = new PUser
            {
                UEmail = Email,
                UFullName = Name,
                USurname = Surname,
                URole = "Customer", //this method is used only for registering client so this can be done
                UPassword = Password,
                UserName_ = Username,



            };
            DB.PUsers.InsertOnSubmit(UserToStore);
            try
            {
                DB.SubmitChanges();

            }
            //needs to be fixed
            catch (Exception e)
            {
                return "Error in Registering user";
            }

            //Now do Registering for the Customer
            var UCustToStore = new Customer
            {

                //get auto generated iD from the user table
                //maintain inheritance
                CustID = UserToStore.UId,
                Cust_Address=Address,
                Cust_PhoneNum=phonenum,
              };
            DB.Customers.InsertOnSubmit(UCustToStore);
            try
            {
                DB.SubmitChanges();
                return "User Succesfully Registered";
            }
            catch
            {
                return "Error in Registering customer";
            }
        }
    }
}
       
