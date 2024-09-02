using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;



namespace TempService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        public Service1()
        {
            returnList();
            AddDummyData();
        }


        TempDatabaseDataContext DB = new TempDatabaseDataContext("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\TempDB.mdf;Integrated Security=True");

        string IService1.login(string Email, string Password)
        {
            //using the join is not 100% necessary as only the username and password really matter at this point
            //but for later when this method needs to be updated for showing who signed in and so forth itll work
            var UserLogged = (from c in DB.PUsers
                              where c.UEmail == Email && c.UPassword == Password
                              select c).FirstOrDefault();


            //simple logic from here
            //check if user returned is null,if not  say they logged in succesfully
            if(UserLogged!=null){
                return UserLogged.URole;
            }
            else
            {
                return "Username Or Password is Incorrect";
            }
           
            /*
             * NOTE:this method is a placeholder to ge the frotn end going so long
             * proper implementation will check role types and give adjust the nav bar element as necessary
             * set true admind bar visiblity etc
             */
        }

        string IService1.Register(string Email, string Name, string Username, string Surname, string Number, string Password, string Address)
        {
            //First check the database to see if there already exists a user with a specefic email
            //If so return a string saying theyve already registered adn that they should log in instead
            

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
                Cust_PhoneNum=Number,
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

        //List of products
        public List<Product> prodList = new List<Product>();

        //function to retrieve json from api
        public async Task getProducts()
        {
            using (HttpClient client = new HttpClient())
            {
                var request = await client.GetAsync("https://fakestoreapi.com/products");
                if (request.IsSuccessStatusCode)
                {
                    //store json object
                    var res = await request.Content.ReadAsStringAsync();
                    //deserializes json to list
                    prodList = JsonSerializer.Deserialize<List<Product>>(res);
                }

            };

        }

        Product[] prodArray;

        //function to convert list to array
        public Product[] returnList()
        {
            //gets list
            getProducts().Wait();

            //converts list to arry
            prodArray = prodList.ToArray();
            return prodArray;

        }

        //Method to add items to item table
       public string addItemsToDB(string title, decimal price, string desciption, string category, string image)
        {

            //check if item already exists
            var existingItem = (from i in DB.Items
                                where i.Title == title && i.Category == category
                                select i
                                ).FirstOrDefault();

            if(existingItem != null)
            {
                return "Item already exists";
            }

            var item = new Item
            {
                Title = title,
                Price = price,
                Description = desciption,
                Category = category,
                Image = image
            };

            DB.Items.InsertOnSubmit(item);
            try
            {
                DB.SubmitChanges();
                return "Successfully added item";
            }
            catch
            {
                return "Unable to add item";
            }
            
        }

        public void AddDummyData()
        {
            foreach (Product p in prodArray)
            {
                string result = addItemsToDB(p.Title, p.Price, p.Description, p.Category, p.Image);
            }
        }

     
    }
}
       
