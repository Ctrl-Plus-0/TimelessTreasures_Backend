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

       

        TempDatabaseDataContext DB = new TempDatabaseDataContext();

        string IService1.login(string Email, string Password)
        {
            //using the join is not 100% necessary as only the username and password really matter at this point
            //but for later when this method needs to be updated for showing who signed in and so forth itll work
            var UserLogged = (from c in DB.PUsers
                              where c.UEmail == Email && c.UPassword == Password
                              select c).FirstOrDefault();


            //simple logic from here
            //check if user returned is null,if not  say they logged in succesfully
            //Returns login role 
            //perform additional check in front end for admin type to see if manager or admin
            if(UserLogged!=null){
                return UserLogged.Urole;
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
            //If so return a string saying theyve already registered and that they should log in instead
            

            var UserToStore = new PUser
            {
                UEmail = Email,
                UFullName = Name,
                USurname = Surname,
                Urole = "Customer", //this method is used only for registering client so this can be done
                UPassword = Password,
                UserName = Username,
                Ucreationtime=DateTime.Now



            };
            DB.PUsers.InsertOnSubmit(UserToStore);
            try
            {
                DB.SubmitChanges();

            }
            //Update the exceptions to take more into account not just general exception 
            //Makes debugging easier
            catch (Exception e)
            {
                return "Error in Registering user" +e.Message;
            }

            //Now do Registering for the Customer
            var UCustToStore = new Customer
            {

                //get auto generated iD from the user table
                //maintain inheritance
                CustId = UserToStore.UId,
                CustAddress=Address,
                CustPhoneNo=Number,
              };
            DB.Customers.InsertOnSubmit(UCustToStore);
            try
            {
                DB.SubmitChanges();
               
            }
            catch
            {
                //if a customer record fails to be made delete the previously made user record
                //To avoid dummy records that point nowhere
                DB.PUsers.DeleteOnSubmit(UserToStore);
                DB.SubmitChanges();

                return "Error in Registering customer";
            }

            //As soon as a user registers create a shopping cart for their accound
            //If there are concerns about dead accounts adding bloat to database can
            //Make function to check for inactivity 
            //If account inavtive for certain period deactivate it

            //Only the user id is necessary to fully create the cart
            //Can do this becasue this method is stricntly for registering customers
            var cart = new UCart
            {
                CustId = UserToStore.UId
            };

            DB.UCarts.InsertOnSubmit(cart);

            try
            {
                DB.SubmitChanges();

                return "User Succesfully Registered";

            }
            catch(Exception e1) 
            {
                Console.WriteLine(e1.Message);
             
                //Same as above remove to prevent dummy records
                DB.Customers.DeleteOnSubmit(UCustToStore);

                DB.SubmitChanges();

                DB.PUsers.DeleteOnSubmit(UserToStore);

                DB.SubmitChanges();


                return " Error in Registration";
            }


        }

        //List of products
        public List<Item> prodList = new List<Item>();

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
                    prodList = JsonSerializer.Deserialize<List<Item>>(res);
                }

            };

        }

        Item[] prodArray;

        //function to convert list to array
        public Item[] returnList()
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
            foreach (Item p in prodArray)
            {
                string result = addItemsToDB(p.Title, p.Price, p.Description, p.Category, p.Image);
            }
        }

        public List<ItemWrapper> getItems(int SortType)
        {
            dynamic prod = new List<ItemWrapper>();
            if (SortType == 1)
            {
                //return a sorted list starting from higheest to lowest price
                dynamic Sorted = (from i in DB.Items
                                  where i.Quantity > 0 && i.Visible_ == 1
                                  orderby i.Price descending
                                  select i).DefaultIfEmpty();

                //Instead of using the table use the wrapper and return list of the wrappers
                //used in front end as well in exact same way
                foreach (dynamic i in Sorted)
                {
                    ItemWrapper IW = new ItemWrapper();
                    IW.ID = i.Id;
                    IW.Title = i.Title;
                    IW.Image = i.Image;
                    IW.Description = i.Description;
                    IW.Price = i.Price;
                    IW.Quantity = i.Quantity;
                    IW.Category = i.Category;
                    IW.NumSold = i.NumSold;
                    IW.Visibility = i.Visible_;
                    prod.Add(IW);

                }
                return prod;

            }
            else if (SortType == 2)
            {
                //return a sorted list starting from lowest price to highest
                dynamic Sorted = (from i in DB.Items
                                  where i.Quantity > 0 && i.Visible_ == 1
                                  orderby i.Price
                                  select i).DefaultIfEmpty();

                foreach (dynamic i in Sorted)
                {
                    ItemWrapper IW = new ItemWrapper();
                    IW.ID = i.Id;
                    IW.Title = i.Title;
                    IW.Image = i.Image;
                    IW.Description = i.Description;
                    IW.Price = i.Price;
                    IW.Quantity = i.Quantity;
                    IW.Category = i.Category;
                    IW.NumSold = i.NumSold;
                    IW.Visibility = i.Visible_;
                    prod.Add(IW);

                }
                return prod;
            }
            else if (SortType == 3)
            {
                //return a sorted list starting from A to Z
                dynamic Sorted = (from i in DB.Items
                                  where i.Quantity > 0 && i.Visible_ == 1
                                  orderby i.Title
                                  select i).DefaultIfEmpty();

                foreach (dynamic i in Sorted)
                {
                    ItemWrapper IW = new ItemWrapper();
                    IW.ID = i.Id;
                    IW.Title = i.Title;
                    IW.Image = i.Image;
                    IW.Description = i.Description;
                    IW.Price = i.Price;
                    IW.Quantity = i.Quantity;
                    IW.Category = i.Category;
                    IW.NumSold = i.NumSold;
                    IW.Visibility = i.Visible_;
                    prod.Add(IW);

                }
                return prod;
            }
            else if (SortType == 4)
            {
                //return a sorted list starting from A to Z
                dynamic Sorted = (from i in DB.Items
                                  where i.Quantity > 0 && i.Visible_ == 1
                                  orderby i.Title ascending
                                  select i).DefaultIfEmpty();

                foreach (dynamic i in Sorted)
                {
                    ItemWrapper IW = new ItemWrapper();
                    IW.ID = i.Id;
                    IW.Title = i.Title;
                    IW.Image = i.Image;
                    IW.Description = i.Description;
                    IW.Price = i.Price;
                    IW.Quantity = i.Quantity;
                    IW.Category = i.Category;
                    IW.NumSold = i.NumSold;
                    IW.Visibility = i.Visible_;
                    prod.Add(IW);

                }
                return prod;

            }
            else
            {
                //return a sorted list starting from A to Z
                dynamic Unsorted = (from i in DB.Items
                                    where i.Quantity > 0 && i.Visible_ == 1
                                    select i).DefaultIfEmpty();

                foreach (dynamic i in Unsorted)
                {
                    ItemWrapper IW = new ItemWrapper();
                    IW.ID = i.Id;
                    IW.Title = i.Title;
                    IW.Image = i.Image;
                    IW.Description = i.Description;
                    IW.Price = i.Price;
                    IW.Quantity = i.Quantity;
                    IW.Category = i.Category;
                    IW.NumSold = i.NumSold;
                    IW.Visibility = i.Visible_;
                    prod.Add(IW);

                }
                return prod;

            }
        }

  
        //NOTE:This function needs to be updated when the categories are finaly made/added 

        //Function to filter by category and sort by price
        public Item[] filterAndSortItems(string filterOrder, string sortOrder)
        {

            Item[] items;

            switch (filterOrder)
            {
                case "men's clothing":
                    items = (from i in DB.Items
                             where i.Category.Equals("men's clothing")
                             select i
                             ).ToArray();
                    break;
                case "women's clothing":
                    items = (from i in DB.Items
                             where i.Category.Equals("women's clothing")
                             select i
                             ).ToArray();
                    break;
                case "electronics":
                    items = (from i in DB.Items
                             where i.Category.Equals("electronics")
                             select i
                             ).ToArray();
                    break;
                case "jewelery":
                    items = (from i in DB.Items
                             where i.Category.Equals("jewelery")
                             select i
                             ).ToArray();
                    break;
                default:
                    items = (from i in DB.Items
                             select i
                             ).ToArray();
                    break;
            }

            switch (sortOrder)
            {
                case "Price ASC":
                    items = (from i in items
                             orderby i.Price ascending
                             select i
                             ).ToArray();
                    break;
                case "Price DESC":
                    items = (from i in items
                             orderby i.Price descending
                             select i
                             ).ToArray();
                    break;
                default:
            
                    break;

            }

            return items;
        }

        public string AddItemToCart(int Prodid, int UserId)
        {
            var CT = (from Tracker in DB.CartTrackers
                      join Cart in DB.UCarts
                      on Tracker.CartId equals Cart.Id
                      where Cart.CustId == UserId && Tracker.ProdID == Prodid
                      select Tracker).FirstOrDefault();

            if (CT != null)
            {
                //update the quantity if user tries to add same item
                CT.Quantity += 1;
                try
                {
                    DB.SubmitChanges();
                    return "Product Exists adding to quantity";

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return "Error adding existing record to cart";
                    //Problem encountred when trying to up quantity
                }
            }
            else
            {
                var Cartrack = new CartTracker();
                //Get the cart and product record being used in this instance
                var Prod = (from p in DB.Items
                            where p.Id == Prodid
                            select p).FirstOrDefault();
                var Cart = (from c in DB.UCarts
                            where c.CustId == UserId
                            select c).FirstOrDefault();
                Cartrack.ProdID = Prodid;
                Cartrack.Price = Prod.Price;
                Cartrack.CartId = Cart.Id; //set the id to the id of the cart associated to the user 
                Cartrack.Quantity = 1; //set to 1 sice is first time adding to the cart
                DB.CartTrackers.InsertOnSubmit(Cartrack);
                try
                {
                    DB.SubmitChanges();
                    return Prod.Title + " added to cart";
                }
                catch (Exception e1)
                {
                    Console.WriteLine(e1.Message);
                    return "Error inserting Product to cart,try again later";
                    //Problem encountred when inserting product to cart;
                }
            }
        }
    }
}
       
