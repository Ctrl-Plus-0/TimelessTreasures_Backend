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

        public Item[] getItems()
        {
            return DB.Items.ToArray();
        }

  

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
<<<<<<< Updated upstream
=======

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

        public ItemWrapper GetItem(int Prodid)
        {
            var Prod = (from p in DB.Items
                        where p.Id == Prodid
                        select p).FirstOrDefault();

            if (Prod != null)
            {
                ItemWrapper IW = new ItemWrapper();
                IW.ID = Prod.Id;
                IW.Title = Prod.Title;
                IW.Image = Prod.Image;
                IW.Description = Prod.Description;
                IW.Price = Prod.Price;
                IW.Quantity = Prod.Quantity;
                IW.Category = Prod.Category;
                IW.NumSold = Prod.NumSold;
                IW.Visibility = Prod.Visible_;

                return IW;
            }
            else
            {
                return null;
            }
           
        }


        public int AddStaffMember(string fullName, string surname, string userName, string email, string password, string role)
        {
            {
                var checkUser = (from u in DB.PUsers
                                 where u.UserName.Equals(userName) || u.UEmail.Equals(email)
                                 select u).FirstOrDefault();

                if (checkUser == null)
                {
                    var staffToBeSaved = new PUser
                    {
                        UFullName = fullName,
                        USurname = surname,
                        UserName = userName,
                        UEmail = email,
                        UPassword = IFM2B10_2014_CS_Paper_A.Secrecy.HashPassword(password),
                        Ucreationtime = DateTime.Now,
                        Urole = role
                    };

                    DB.PUsers.InsertOnSubmit(staffToBeSaved);
                    try
                    {
                        DB.SubmitChanges();
                        return 0; // STAFF MEMBER ADDED SUCCESSFULLY
                    }
                    catch (Exception)
                    {
                        return -1; // INTERNAL SERVER ERROR
                    }
                }
                else
                {
                    return 1; // STAFF MEMBER ALREADY EXISTS
                }
            }
        }

        public int EditStaffMember(string fullName, string surname, string email, string role)
        {
            using (TempDatabaseDataContext DB = new TempDatabaseDataContext())
            {
                var staff = DB.PUsers.FirstOrDefault(u => u.UFullName == fullName && u.USurname == surname);
                if (staff != null)
                {
                    staff.UEmail = email;
                    staff.Urole = role;
                    DB.SubmitChanges(); // Save changes to the database
                    return 0; // Success
                }
                return -1; // Staff member not found
            }
        }

        public int DeleteStaffMember(string fullName, string surname)
        {

            using (TempDatabaseDataContext DB = new TempDatabaseDataContext())
            {
                var staff = DB.PUsers.FirstOrDefault(u => u.UFullName == fullName && u.USurname == surname);
                if (staff != null)
                {

                    var admin = DB.Admins.FirstOrDefault(a => a.AdminId == staff.UId);
                    if (admin != null)
                    {
                        DB.Admins.DeleteOnSubmit(admin);
                    }

                    // Remove from the PUser table
                    DB.PUsers.DeleteOnSubmit(staff);
                    DB.SubmitChanges(); // Save changes to the database
                    return 0; // Success
                }
                return -1; // Staff member not found
            }
        }

        public StaffMember GetStaffMember(int userId)
        {
            var staffMember = (from u in DB.PUsers
                               where u.UId == userId
                               select new StaffMember
                               {
                                   UId = u.UId,
                                   UserName = u.UserName,
                                   UFullName = u.UFullName,
                                   USurname = u.USurname,
                                   UEmail = u.UEmail,
                                   Ucreationtime = u.Ucreationtime,
                                   Urole = u.Urole
                               }).FirstOrDefault();

            return staffMember;
        }

        public int EditProduct(string title, decimal price, string description, string category, string image, int quantity, int visible)
        {
            var existingItem = GetProductByName(title);


            if (existingItem == null)
            {
                return 1;
            }


            existingItem.Price = price;
            existingItem.Description = description;
            existingItem.Category = category;
            existingItem.Image = image;
            existingItem.Quantity = quantity;
            existingItem.Visible_ = visible;

            try
            {

                DB.SubmitChanges();
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int DeleteProduct(string title)
        {
            var existingItem = DB.Items.FirstOrDefault(i => i.Title == title);

            if (existingItem == null)
            {
                return 1;
            }

            DB.Items.DeleteOnSubmit(existingItem);

            try
            {
                DB.SubmitChanges();
                return 0; // Product deleted successfully
            }
            catch (Exception)
            {
                return -1; // Internal server error
            }
        }

        public int AddProduct(string title, decimal price, string description, string category, string image, int quantity, int visible)
        {
            var existingItem = DB.Items.FirstOrDefault(i => i.Title == title);

            if (existingItem != null)
            {
                return 1; // Product already exists
            }

            var newItem = new Item
            {
                Title = title,
                Price = price,
                Description = description,
                Category = category,
                Image = image,
                Quantity = quantity,
                Visible_ = visible,
                NumSold = 0 // Default to not sold
            };

            DB.Items.InsertOnSubmit(newItem);

            try
            {
                DB.SubmitChanges();
                return 0; // Product added successfully
            }
            catch (Exception)
            {
                return -1; // Internal server error
            }
        }

        public Item GetProductByName(string title)
        {
            var product = DB.Items.FirstOrDefault(i => i.Title.Equals(title));

            return product;
        }

        public PUser GetStaffMemberByFullNameAndSurname(string fullName, string surname)
        {
            using (TempDatabaseDataContext DB = new TempDatabaseDataContext())
            {
                return DB.PUsers.FirstOrDefault(u => u.UFullName == fullName && u.USurname == surname);
            }
        }

        public List<ItemWrapper> getItemsByCategory(string category)
        {
            List<ItemWrapper> allProds = getItems(0);

            List<ItemWrapper> filteredItems = new List<ItemWrapper>();

            if (category.Equals("All"))
            {
                filteredItems = allProds;
            }
            else
            {
                foreach (ItemWrapper item in allProds)
                {
                    if (item.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                    {
                        filteredItems.Add(item);
                    }
                }

            }

            return filteredItems;
        }
>>>>>>> Stashed changes
    }
}
       
