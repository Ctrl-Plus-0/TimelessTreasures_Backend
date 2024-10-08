using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace TempService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

       [OperationContract]
       Product[] returnList();

       [OperationContract] 
       //MEthod will assign customer role on its own as admins and managers not added this way
       //Note can make another service to manage the addition and removal of customers as needed
       //
         string Register(string Email,string Name,string Username,string Surname,string Number,string Password,string Address);

        [OperationContract]
        //hash pass in backend when trying to login
        //hash in registering when reading
        string login(string Email, string Password);

        [OperationContract]
        // function to make http requestion and populate list of products
        Task getProducts();


        [OperationContract]
        string addItemsToDB(string title, decimal price, string desciption, string category, string image);

        [OperationContract]
        void AddDummyData();

        [OperationContract]
        Item[] getItems();

        [OperationContract]
        Item[] filterAndSortItems(String filterOrder, string sortOrder);
<<<<<<< Updated upstream
=======

        [OperationContract]
        string AddItemToCart(int Prodid, int UserId);

        [OperationContract]
        int GetUserID(string email, string password);
        [OperationContract]
        int AddStaffMember(string fullName, string surname, string userName, string email, string password, string role);
        [OperationContract]
        int EditStaffMember(string fullName, string surname, string email, string role);
        [OperationContract]
        int DeleteStaffMember(string fullName, string surname);
        [OperationContract]
        StaffMember GetStaffMember(int userId);
        [OperationContract]
        int EditProduct(string title, decimal price, string description, string category, string image, int quantity, int visible);
        [OperationContract]
        int DeleteProduct(string title);
        [OperationContract]
        int AddProduct(string title, decimal price, string description, string category, string image, int quantity, int visible);
        [OperationContract]
        Item GetProductByName(string title);
        [OperationContract]
        PUser GetStaffMemberByFullNameAndSurname(string fullName, string surname);

        [OperationContract]
        List<ItemWrapper> getItemsByCategory(string category);

>>>>>>> Stashed changes
    }
}
