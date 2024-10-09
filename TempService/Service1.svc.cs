using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using IFM2B10_2014_CS_Paper_A;


namespace TempService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

       

        TempDatabaseDataContext DB = new TempDatabaseDataContext();

        int IService1.login(string Email, string Password)
        {
            //using the join is not 100% necessary as only the username and password really matter at this point
            //but for later when this method needs to be updated for showing who signed in and so forth itll work
            var UserLogged = (from c in DB.PUsers
                              where c.UEmail.Equals(Email) && c.UPassword.Equals(Password)
                              select c).FirstOrDefault();
            if (UserLogged == null)
            {
                return -1;
            }

            //simple logic from here
            //check if user returned is null,if not  say they logged in succesfully
            //Returns login role 
            //perform additional check in front end for admin type to see if manager or admin
            if (UserLogged.Urole.Equals("Customer"))
            {
                return 0;
            }
            else if(UserLogged.Urole.Equals("Manager"))
            {
                var Admin = (from a in DB.Admins
                             where a.AdminId == UserLogged.UId
                             select a).FirstOrDefault();

                if (Admin.AdminPerms == 1) //HEAD MANAGER PERMS 1
                                           //BASE MANAGER PERMS 2
                {
                    return 1; //HEAD MANAGER LOGGED IN
                }
                else
                {
                    return 2; //BASE MANAGER LOGGED IN
                }
               
            }
            else
            {
                return -1; //INCORRECT USERNAME OR PASSWORD
            }
           
            /*
             * NOTE:this method is a placeholder to ge the frotn end going so long
             * proper implementation will check role types and give adjust the nav bar element as necessary
             * set true admind bar visiblity etc
             */
        }
        public int GetUserID(string email, string password)
        {
            using (DB)
            {
                var checkUser = (from u in DB.PUsers
                                 where u.UEmail.Equals(email) &&
                                       u.UPassword.Equals(password)
                                 select u).FirstOrDefault();

                if (checkUser == null)
                {
                    return -1; // User not found or authentication failed
                }
                else
                {
                    return checkUser.UId; // Return the user's ID
                }
            }
        }
        string IService1.Register(string Email, string Name, string Username, string Surname, string Number, string Password, string Address)
        {
            //First check the database to see if there already exists a user with a specefic email
            //If so return a string saying theyve already registered and that they should log in instead

            var CheckUser = (from u in DB.PUsers
                             where Email.Equals(u.UEmail)
                             select u).FirstOrDefault();

            if (CheckUser != null)
            {
                return "Already Registered";
            }


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
                                  orderby i.Title descending 
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
                //return an unsorted list
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

        public int AddItemToCart(int Prodid, int UserId)
        {
            var CT = (from Tracker in DB.CartTrackers
                      join Cart in DB.UCarts
                      on Tracker.CartId equals Cart.Id
                      where Cart.CustId == UserId && Tracker.ProdID == Prodid
                      select Tracker).FirstOrDefault();

            if (CT != null)
            {
                //update the quantity if user tries to add same item
                //if  quantity is already at 10 return and tell them max amount of items for one purchace reached
                if (CT.Quantity == 10)
                {
                    return -3; //MAX QUANTITY FOR THIS ITEM REACHED
                }

                CT.Quantity += 1;
                try
                {
                    DB.SubmitChanges();
                    return 1; //ITEM ALREADY IN CART INCREMENTING QUANTITY

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return -2; // ERROR WHEN TRYING TO INCREMENT BY A SINGLE VALUE
                   
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
                    return 2; //PRODUCT ADDED TO CART
                }
                catch (Exception e1)
                {
                    Console.WriteLine(e1.Message);
                    return -1; //ERROR WHILE INSERTING NEW ITEM TO THE CART
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


        public int AddStaffMember(string fullName, string surname, string userName, string email, string password, int perms)
        {
            {
                var checkUser = (from u in DB.PUsers
                                 where u.Urole.Equals("Manager") && u.UEmail.Equals(email)
                                 select u).FirstOrDefault();

                //Address the issue of user email clashing with manager 
                //leading to this return
                if (checkUser != null)
                {
                    //before anthing check if the email is a cutomer email
                    //if it isnt this block is skipped
                    if (checkUser.Urole.Equals("Customer"))
                    {
                        return 2;
                    }
                    return 1; // STAFF MEMBER ALREADY EXISTS
                }

              
                    var user = new PUser
                    {
                        UFullName = fullName,
                        USurname = surname,
                        UserName = userName,
                        UEmail = email,
                        UPassword = password,
                        Ucreationtime = DateTime.Now,
                        Urole ="Manager"
                    };

                    DB.PUsers.InsertOnSubmit(user);
                    try
                    {
                        DB.SubmitChanges();
                        
                    }
                    catch (Exception e)
                    {
                        Console.Write(e.Message); //ADD CONSOLE WRITE TO ASSIST WITH DEBUGGING
                        return -1; // INTERNAL SERVER ERROR
                    }

                //Value of 1 For Head Manager perms
                //Value of 2 for normal manager perms
                var manager = new Admin
                {
                    AdminId = user.UId,
                    AdminPerms = perms
                };
                DB.Admins.InsertOnSubmit(manager);

                try
                {
                    DB.SubmitChanges();
                    return 0; // STAFF MEMBER ADDED SUCCESSFULLY
                }
                catch (Exception e)
                {
                    Console.Write(e.Message); //ADD CONSOLE WRITE TO ASSIST WITH DEBUGGING
                    return -1; // INTERNAL SERVER ERROR
                }
               

            }
        }

        public int EditStaffMember(int Memberid,string fullName, string surname, string email, int perms)
        {
            
            {
                var staff = (from u in DB.PUsers
                               where u.UId==Memberid
                               select u).FirstOrDefault();
                if (staff != null)
                {
                    var Manager = (from m in DB.Admins
                                   where m.AdminId ==Memberid
                                   select m).FirstOrDefault();
                    staff.UFullName = fullName;
                    staff.USurname = surname;
                    staff.UEmail = email;
                    Manager.AdminPerms = perms;
                    DB.SubmitChanges(); // Save changes to the database
                    return 0; // Success
                }
                return -1; // Staff member not found
            }
        }

        public int DeleteStaffMember(string fullName, string surname)
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

        //THis function needs to be redone to take into acoount shopping carts that have items in them already
        //either change item visibility to false or remove from the carts 
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

        public StaffMember GetStaffMemberByFullNameAndSurname(string fullName, string surname)
        {

            var staff = (from u in DB.PUsers
                         where u.UFullName.Equals(fullName) &&
                         u.USurname.Equals(surname) &&
                         u.Urole.Equals("Manager")
                         select u).FirstOrDefault();
            if (staff == null)
            {
                return null; //Handle in the front saying invalid details
            }
            var Manager = (from m in DB.Admins
                           where m.AdminId == staff.UId
                           select m).FirstOrDefault();

            StaffMember SM = new StaffMember
            {
                USurname = staff.USurname,
                UFullName = staff.UFullName,
                Ucreationtime = staff.Ucreationtime,
                Urole = staff.Urole,
                UserName = staff.UserName,
                UEmail = staff.UEmail,
                UId=staff.UId,
                PermType=Manager.AdminPerms
                
            };

            return SM;
        }

        public List<TrackerWrapper> GetCartItems(int Userid)
        {
            dynamic CartItems = new List<TrackerWrapper>();

            dynamic Temp = (from CTrack in DB.CartTrackers
                            join CRT in DB.UCarts
                            on CTrack.CartId equals CRT.Id
                            where Userid == CRT.CustId
                            select CTrack).DefaultIfEmpty();

            foreach(var t in Temp)
            {
                if (t != null)
                {
                    TrackerWrapper TW = new TrackerWrapper();
                    TW.CartID = t.CartId;
                    TW.ProdId = t.ProdID;
                    TW.Quantity = t.Quantity;
                    TW.Price = t.Price;

                    CartItems.Add(TW);

    

                }
            }

            return CartItems;
        }

        public int RemoveItemFromCart(int ProdID, int UserID)
        {
            var ToRemove = (from Track in DB.CartTrackers
                            join Crt in DB.UCarts
                            on Track.CartId equals Crt.Id
                            where ProdID == Track.ProdID && UserID == Crt.CustId
                            select Track).FirstOrDefault();


            if (ToRemove != null)
            {
                DB.CartTrackers.DeleteOnSubmit(ToRemove);

                try
                {
                    DB.SubmitChanges();

                  


                    return 1; //ITEM REMOVED SUCCESFULLY
                }catch(Exception E1)
                {
                    Console.WriteLine(E1.Message);
                    return -1; //ITEM FAILED TO BE REMOVED
                }
            }
            else
            {
                return -2; //ITEM DOES NOT EXIST IN THE CART
            }
     
        }

        public int UpdateCartTotal(int UserId, decimal subtotal)
        {
            var temp = (from UserCart in DB.UCarts
                        where UserCart.CustId == UserId
                        select UserCart).FirstOrDefault();

            if (temp != null)
            {
                if (subtotal == -3)
                {
                    dynamic Calc = (from CTrack in DB.CartTrackers
                                    join CRT in DB.UCarts
                                    on CTrack.CartId equals CRT.Id
                                    where UserId == CRT.CustId
                                    select CTrack).DefaultIfEmpty();
                    decimal NewTot = 0;
                    foreach (CartTracker CT in Calc)
                    {
                        if (CT != null)
                        {
                            decimal tempTotal = 0;
                            tempTotal = CT.Price * CT.Quantity;
                            NewTot += tempTotal;
                        }
                    }
                    temp.Total = NewTot;
                }
                else
                {
                    temp.Total = subtotal;
                }
                try
                {
                    DB.SubmitChanges();
                    return 1; //SUCCESFULLY ADDED NEW TOTAL
                }catch(Exception E1)
                {
                    Console.WriteLine(E1);
                    return -1; //UNSUCCESFUL IN COMMITING CHANGES TO THE TOTAL
                }
            }
            else
            {
                return -2; //COULDNT FIND USER CART
            }
            
        }

        public int UpdateItemQuantity(int UserID,int NewQuantity,int ProductID)
        {
            var CartItem = (from CTrack in DB.CartTrackers
                            join CRT in DB.UCarts
                            on CTrack.CartId equals CRT.Id
                            where UserID == CRT.CustId && ProductID ==CTrack.ProdID
                            select CTrack).FirstOrDefault();
            if (CartItem != null)
            {
                if (CartItem.Quantity != NewQuantity)
                {
                    CartItem.Quantity = NewQuantity;
                    try
                    {
                        DB.SubmitChanges();
                        return 1;//QUANTITY UPDATED
                    }catch(Exception E)
                    {
                        Console.WriteLine(E.Message);
                        return -1; //Unable to Update Quantities
                    }
                }
                else
                {
                    return 2; //NO CHANGE IN QUANTITY
                }
            }
            else
            {
                return -2; // CART NOT LOCATED
            }
          
        }

        public decimal GetCartTotal(int UserID)
        {
            var temp = (from UserCart in DB.UCarts
                        where UserCart.CustId == UserID
                        select UserCart).FirstOrDefault();

            if (temp != null)
            {
                return temp.Total;
            }
            else 
            { return 0;
            }
            
        }

        public int CreateInvoice(int UserID, string Message, string receipiant, string RAddress, DateTime Delivery, string contactnum)
        {
            var inv = (from i in DB.Invoice_s
                       where i.UserID == UserID && i.Id==0
                       select i).FirstOrDefault();
            if (inv != null)
            {
                return -1; //INVOICE ALREADY EXISTS
            }
            else
            {
                //get the users cart
                var UserCart = (from u in DB.UCarts
                                where u.CustId == UserID
                                select u).FirstOrDefault();
                dynamic CartItems = (from CT in DB.CartTrackers
                                     where CT.CartId == UserCart.Id
                                     select CT).DefaultIfEmpty();
                var Ninv = new Invoice_();

                Ninv.Price = UserCart.Total;
                  foreach (var C in CartItems) {

                    //add each products id as a string and corresponding quantities too
                    //will be split in the wrapper class and returned as array of integers
                    Ninv.ProdID += C.ProdID.ToString() + "\\";
                    Ninv.Quantity += C.Quantity.ToString() + "\\";
                }
                Ninv.UserID = UserID;
                Ninv.CreationDate = DateTime.Now;
                Ninv.GiftMessage = Message;
                Ninv.Receipiant = receipiant;
                Ninv.RecepiantAdress = RAddress;
                Ninv.ReceipiantContact = contactnum;
                Ninv.DeliveryDate = Delivery.Date;
               

                DB.Invoice_s.InsertOnSubmit(Ninv);

                try
                {
                    DB.SubmitChanges();
                    return 1; //Invoice made
                }
                catch(Exception E1)
                {
                    Console.WriteLine(E1.Message);
                    return -2; //error adding invoice to table
                }
                
            }
            
        }

        public void ClearCart(int Uid)
        {
            try
            {
                var CartClear = (from CRT in DB.CartTrackers
                                 join UT in DB.UCarts
                                 on CRT.CartId equals UT.Id
                                 where UT.CustId == Uid
                                 select CRT).DefaultIfEmpty();
                DB.CartTrackers.DeleteAllOnSubmit(CartClear);
                DB.SubmitChanges();
                var UpdateCart = (from CT in DB.UCarts
                                  where CT.CustId == Uid
                                  select CT).FirstOrDefault();

                UpdateCart.Total = 0;
                DB.SubmitChanges();
                
            }catch(Exception E1)
            {
                Console.WriteLine(E1.Message);
            }
           
        }

        public List<InvoiceWrapper> GetInvoices(int userID)
        {
            dynamic inv = new List<InvoiceWrapper>();

            dynamic temp = (from I in DB.Invoice_s
                            where I.UserID == userID
                            select I).DefaultIfEmpty();

            foreach(Invoice_ i in temp)
            {
                InvoiceWrapper IW = new InvoiceWrapper();
                IW.id = i.Id;
                IW.UserID = i.UserID;
                string[] SplitProds = i.ProdID.Split('\\');
                string[] SplitQuantity = i.Quantity.Split('\\');
                IW.SetProductIDs(SplitProds);
                IW.SetUpQuantity(SplitQuantity);
                IW.Price = i.Price;
                IW.D = i.CreationDate;
                IW.Delivery = i.DeliveryDate.Date;
                IW.Address = i.RecepiantAdress;
                IW.Contact = i.ReceipiantContact;
                IW.message = i.GiftMessage;
                IW.receipiant = i.Receipiant;
                inv.Add(IW);
            }
            return inv;
        }

        public void UpdateAfterSale(int userID)
        {
            dynamic UpdateWith = (from CRT in DB.CartTrackers
                             join UT in DB.UCarts
                             on CRT.CartId equals UT.Id
                             where UT.CustId == userID
                             select CRT).DefaultIfEmpty();

            foreach(CartTracker CT in UpdateWith)
            {
                var ProdUpdate = (from P in DB.Items
                                  where P.Id == CT.ProdID
                                  select P).FirstOrDefault();

                ProdUpdate.NumSold = CT.Quantity;

                try
                {
                    DB.SubmitChanges();
                }catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
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

        public InvoiceWrapper GetInvoice(int invoiceID)
        {
            var Inv = (from i in DB.Invoice_s
                       where i.Id == invoiceID
                       select i).FirstOrDefault();

            if (Inv != null)
            {
                InvoiceWrapper IW = new InvoiceWrapper();
                
                IW.id = Inv.Id;
                IW.UserID = Inv.UserID;
                string[] SplitProds = Inv.ProdID.Split('\\');
                string[] SplitQuantity = Inv.Quantity.Split('\\');
                IW.SetProductIDs(SplitProds);
                IW.SetUpQuantity(SplitQuantity);
                IW.Price = Inv.Price;
                IW.D = Inv.CreationDate;
                IW.Delivery = Inv.DeliveryDate.Date;
                IW.Address = Inv.RecepiantAdress;
                IW.Contact = Inv.ReceipiantContact;
                IW.message = Inv.GiftMessage;
                IW.receipiant = Inv.Receipiant;

                return IW;
            }
            else
            {
                return null;
            }
        
        }

        public Cupon  ApplyDiscount(string Code)
        {
            var Discount = (from C in DB.Cupons
                            where C.Code.Equals(Code)
                            select C).FirstOrDefault();

            if (Discount != null)
            {
                Cupon disc = new Cupon();
                disc = Discount;
                return disc;
            }
            else
            {
                return null;
            }
          
        }

        public void RemoveFromDiscountPool(string Code)
        {

            var Discount = (from C in DB.Cupons
                            where C.Code.Equals(Code)
                            select C).FirstOrDefault();

            if (Discount != null)
            {
                DB.Cupons.DeleteOnSubmit(Discount);

                try
                {
                    DB.SubmitChanges();
                }catch(Exception E1)
                {
                    Console.WriteLine(E1.Message);
                }

            }
            
        }

        public List<string> getItemNames()
        {
            dynamic prod = new List<String>();

            dynamic Sorted = (from i in DB.Items
                              where i.Quantity > 0 && i.Visible_ == 1
                              orderby i.Price descending
                              select i).DefaultIfEmpty();

            //Instead of using the table use the wrapper and return list of the wrappers
            //used in front end as well in exact same way
            foreach (dynamic i in Sorted)
            {
                prod.Add(i.Title);
            }

            return prod;
        }

        public List<string> getItemOnHand()
        {
            dynamic prod = new List<String>();

            dynamic Sorted = (from i in DB.Items
                              where i.Quantity > 0 && i.Visible_ == 1
                              orderby i.Price descending
                              select i).DefaultIfEmpty();

            //Instead of using the table use the wrapper and return list of the wrappers
            //used in front end as well in exact same way
            foreach (dynamic i in Sorted)
            {
                string quant = i.Quantity.ToString();
                prod.Add(quant);
            }

            return prod;
        }

        public List<string> getSalesPerProduct()
        {
            dynamic prod = new List<String>();

            dynamic Sorted = (from i in DB.Items
                              where i.Quantity > 0 && i.Visible_ == 1
                              orderby i.Price descending
                              select i).DefaultIfEmpty();

            //Instead of using the table use the wrapper and return list of the wrappers
            //used in front end as well in exact same way
            foreach (dynamic i in Sorted)
            {
                string quant = i.NumSold.ToString();
                prod.Add(quant);
            }

            return prod;
        }

        public List<string> getRegisteredUsersPerMonth()
        {

            List<string> regPerMonth = new List<string>(31);

            List<int> usersPerMonthInt = new List<int>(31);

            dynamic allUsers = (from u in DB.PUsers
                             orderby u.Ucreationtime ascending
                             select u).DefaultIfEmpty();

            foreach (dynamic us in allUsers) {
                DateTime creationTime = us.Ucreationtime;

                int index = us.Ucreationtime.Day-1;

                int currentValue = usersPerMonthInt[index] + 1;


                usersPerMonthInt.Insert(index, currentValue);
            } 

            foreach (int number in usersPerMonthInt)
            {
                regPerMonth.Add(number.ToString());
            }

            return regPerMonth;
        }
    }
}
       
