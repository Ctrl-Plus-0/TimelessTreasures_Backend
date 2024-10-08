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


    [DataContract]
    public class StaffMember
    {
        [DataMember]
        public int UId { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string UFullName { get; set; }

        [DataMember]
        public string USurname { get; set; }

        [DataMember]
        public string UEmail { get; set; }

        [DataMember]
        public DateTime Ucreationtime { get; set; }

        [DataMember]
        public string Urole { get; set; }

        [DataMember]
        public int PermType { get; set; }
    }
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

   

       [OperationContract] 
       //MEthod will assign customer role on its own as admins and managers not added this way
       //Note can make another service to manage the addition and removal of customers as needed
       //
         string Register(string Email,string Name,string Username,string Surname,string Number,string Password,string Address);

        [OperationContract]
        //hash pass in backend when trying to login
        //hash in registering when reading
        int login(string Email, string Password);

        [OperationContract]
        string addItemsToDB(string title, decimal price, string desciption, string category, string image);

   

        [OperationContract]
        List<ItemWrapper> getItems(int SortType);

        [OperationContract]
        ItemWrapper GetItem(int Prodid);

        [OperationContract]
        Item[] filterAndSortItems(String filterOrder, string sortOrder);

        [OperationContract]
        int AddItemToCart(int Prodid, int UserId);

        [OperationContract]

        List<TrackerWrapper> GetCartItems(int Userid);

        [OperationContract]
        int GetUserID(string email, string password);
        [OperationContract]
        int AddStaffMember(string fullName, string surname, string userName, string email, string password, int perms);
        [OperationContract]
        int EditStaffMember(int Memberid,string fullName, string surname, string email, int perms);
        [OperationContract]
        int DeleteStaffMember(string fullName, string surname);
   
        [OperationContract]
        int EditProduct(string title, decimal price, string description, string category, string image, int quantity, int visible);
        [OperationContract]
        int DeleteProduct(string title);
        [OperationContract]
        int AddProduct(string title, decimal price, string description, string category, string image, int quantity, int visible);
        [OperationContract]
        Item GetProductByName(string title);
        [OperationContract]
        StaffMember GetStaffMemberByFullNameAndSurname(string fullName, string surname);

        [OperationContract]

        int RemoveItemFromCart(int ProdID, int UserID);

        [OperationContract]
        int UpdateCartTotal(int UserId);

        [OperationContract]
        int UpdateItemQuantity(int UserID, int NewQuantity, int ProductID);

        [OperationContract]
        decimal GetCartTotal(int UserID);
    }
}
