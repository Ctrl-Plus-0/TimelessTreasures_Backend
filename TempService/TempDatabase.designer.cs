﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TempService
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="TempDB")]
	public partial class TempDatabaseDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertPUser(PUser instance);
    partial void UpdatePUser(PUser instance);
    partial void DeletePUser(PUser instance);
    partial void InsertCustomer(Customer instance);
    partial void UpdateCustomer(Customer instance);
    partial void DeleteCustomer(Customer instance);
    partial void InsertItem(Item instance);
    partial void UpdateItem(Item instance);
    partial void DeleteItem(Item instance);
    #endregion
		
		public TempDatabaseDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TempDatabaseDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TempDatabaseDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public TempDatabaseDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<PUser> PUsers
		{
			get
			{
				return this.GetTable<PUser>();
			}
		}
		
		public System.Data.Linq.Table<Customer> Customers
		{
			get
			{
				return this.GetTable<Customer>();
			}
		}
		
		public System.Data.Linq.Table<Item> Items
		{
			get
			{
				return this.GetTable<Item>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PUser")]
	public partial class PUser : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UId;
		
		private string _UserName_;
		
		private string _UPassword;
		
		private string _UFullName;
		
		private string _USurname;
		
		private System.DateTime _UCreationTime;
		
		private string _URole;
		
		private string _UEmail;
		
		private EntityRef<Customer> _Customer;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUIdChanging(int value);
    partial void OnUIdChanged();
    partial void OnUserName_Changing(string value);
    partial void OnUserName_Changed();
    partial void OnUPasswordChanging(string value);
    partial void OnUPasswordChanged();
    partial void OnUFullNameChanging(string value);
    partial void OnUFullNameChanged();
    partial void OnUSurnameChanging(string value);
    partial void OnUSurnameChanged();
    partial void OnUCreationTimeChanging(System.DateTime value);
    partial void OnUCreationTimeChanged();
    partial void OnURoleChanging(string value);
    partial void OnURoleChanged();
    partial void OnUEmailChanging(string value);
    partial void OnUEmailChanged();
    #endregion
		
		public PUser()
		{
			this._Customer = default(EntityRef<Customer>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int UId
		{
			get
			{
				return this._UId;
			}
			set
			{
				if ((this._UId != value))
				{
					this.OnUIdChanging(value);
					this.SendPropertyChanging();
					this._UId = value;
					this.SendPropertyChanged("UId");
					this.OnUIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[UserName ]", Storage="_UserName_", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string UserName_
		{
			get
			{
				return this._UserName_;
			}
			set
			{
				if ((this._UserName_ != value))
				{
					this.OnUserName_Changing(value);
					this.SendPropertyChanging();
					this._UserName_ = value;
					this.SendPropertyChanged("UserName_");
					this.OnUserName_Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UPassword", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string UPassword
		{
			get
			{
				return this._UPassword;
			}
			set
			{
				if ((this._UPassword != value))
				{
					this.OnUPasswordChanging(value);
					this.SendPropertyChanging();
					this._UPassword = value;
					this.SendPropertyChanged("UPassword");
					this.OnUPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UFullName", DbType="NChar(100)")]
		public string UFullName
		{
			get
			{
				return this._UFullName;
			}
			set
			{
				if ((this._UFullName != value))
				{
					this.OnUFullNameChanging(value);
					this.SendPropertyChanging();
					this._UFullName = value;
					this.SendPropertyChanged("UFullName");
					this.OnUFullNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USurname", DbType="VarChar(100)")]
		public string USurname
		{
			get
			{
				return this._USurname;
			}
			set
			{
				if ((this._USurname != value))
				{
					this.OnUSurnameChanging(value);
					this.SendPropertyChanging();
					this._USurname = value;
					this.SendPropertyChanged("USurname");
					this.OnUSurnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UCreationTime", DbType="Date NOT NULL")]
		public System.DateTime UCreationTime
		{
			get
			{
				return this._UCreationTime;
			}
			set
			{
				if ((this._UCreationTime != value))
				{
					this.OnUCreationTimeChanging(value);
					this.SendPropertyChanging();
					this._UCreationTime = value;
					this.SendPropertyChanged("UCreationTime");
					this.OnUCreationTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_URole", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string URole
		{
			get
			{
				return this._URole;
			}
			set
			{
				if ((this._URole != value))
				{
					this.OnURoleChanging(value);
					this.SendPropertyChanging();
					this._URole = value;
					this.SendPropertyChanged("URole");
					this.OnURoleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UEmail", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string UEmail
		{
			get
			{
				return this._UEmail;
			}
			set
			{
				if ((this._UEmail != value))
				{
					this.OnUEmailChanging(value);
					this.SendPropertyChanging();
					this._UEmail = value;
					this.SendPropertyChanged("UEmail");
					this.OnUEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PUser_Customer", Storage="_Customer", ThisKey="UId", OtherKey="CustID", IsUnique=true, IsForeignKey=false)]
		public Customer Customer
		{
			get
			{
				return this._Customer.Entity;
			}
			set
			{
				Customer previousValue = this._Customer.Entity;
				if (((previousValue != value) 
							|| (this._Customer.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Customer.Entity = null;
						previousValue.PUser = null;
					}
					this._Customer.Entity = value;
					if ((value != null))
					{
						value.PUser = this;
					}
					this.SendPropertyChanged("Customer");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Customer")]
	public partial class Customer : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _CustID;
		
		private string _Cust_Address;
		
		private string _Cust_PhoneNum;
		
		private System.DateTime _Date_Of_Birth;
		
		private EntityRef<PUser> _PUser;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCustIDChanging(int value);
    partial void OnCustIDChanged();
    partial void OnCust_AddressChanging(string value);
    partial void OnCust_AddressChanged();
    partial void OnCust_PhoneNumChanging(string value);
    partial void OnCust_PhoneNumChanged();
    partial void OnDate_Of_BirthChanging(System.DateTime value);
    partial void OnDate_Of_BirthChanged();
    #endregion
		
		public Customer()
		{
			this._PUser = default(EntityRef<PUser>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int CustID
		{
			get
			{
				return this._CustID;
			}
			set
			{
				if ((this._CustID != value))
				{
					if (this._PUser.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCustIDChanging(value);
					this.SendPropertyChanging();
					this._CustID = value;
					this.SendPropertyChanged("CustID");
					this.OnCustIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cust_Address", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string Cust_Address
		{
			get
			{
				return this._Cust_Address;
			}
			set
			{
				if ((this._Cust_Address != value))
				{
					this.OnCust_AddressChanging(value);
					this.SendPropertyChanging();
					this._Cust_Address = value;
					this.SendPropertyChanged("Cust_Address");
					this.OnCust_AddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cust_PhoneNum", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string Cust_PhoneNum
		{
			get
			{
				return this._Cust_PhoneNum;
			}
			set
			{
				if ((this._Cust_PhoneNum != value))
				{
					this.OnCust_PhoneNumChanging(value);
					this.SendPropertyChanging();
					this._Cust_PhoneNum = value;
					this.SendPropertyChanged("Cust_PhoneNum");
					this.OnCust_PhoneNumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date_Of_Birth", DbType="Date NOT NULL")]
		public System.DateTime Date_Of_Birth
		{
			get
			{
				return this._Date_Of_Birth;
			}
			set
			{
				if ((this._Date_Of_Birth != value))
				{
					this.OnDate_Of_BirthChanging(value);
					this.SendPropertyChanging();
					this._Date_Of_Birth = value;
					this.SendPropertyChanged("Date_Of_Birth");
					this.OnDate_Of_BirthChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PUser_Customer", Storage="_PUser", ThisKey="CustID", OtherKey="UId", IsForeignKey=true)]
		public PUser PUser
		{
			get
			{
				return this._PUser.Entity;
			}
			set
			{
				PUser previousValue = this._PUser.Entity;
				if (((previousValue != value) 
							|| (this._PUser.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._PUser.Entity = null;
						previousValue.Customer = null;
					}
					this._PUser.Entity = value;
					if ((value != null))
					{
						value.Customer = this;
						this._CustID = value.UId;
					}
					else
					{
						this._CustID = default(int);
					}
					this.SendPropertyChanged("PUser");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="")]
	public partial class Item : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _id;
		
		private string _title = default(string);
		
		private decimal _price;
		
		private string _description;
		
		private string _category;
		
		private string _image;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(string value);
    partial void OnidChanged();
    partial void OnpriceChanging(decimal value);
    partial void OnpriceChanged();
    partial void OndescriptionChanging(string value);
    partial void OndescriptionChanged();
    partial void OncategoryChanging(string value);
    partial void OncategoryChanged();
    partial void OnimageChanging(string value);
    partial void OnimageChanged();
    #endregion
		
		public Item()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", CanBeNull=false, IsPrimaryKey=true)]
		public string id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_title", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string title
		{
			get
			{
				return this._title;
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_price")]
		public decimal price
		{
			get
			{
				return this._price;
			}
			set
			{
				if ((this._price != value))
				{
					this.OnpriceChanging(value);
					this.SendPropertyChanging();
					this._price = value;
					this.SendPropertyChanged("price");
					this.OnpriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_description", CanBeNull=false)]
		public string description
		{
			get
			{
				return this._description;
			}
			set
			{
				if ((this._description != value))
				{
					this.OndescriptionChanging(value);
					this.SendPropertyChanging();
					this._description = value;
					this.SendPropertyChanged("description");
					this.OndescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_category", CanBeNull=false)]
		public string category
		{
			get
			{
				return this._category;
			}
			set
			{
				if ((this._category != value))
				{
					this.OncategoryChanging(value);
					this.SendPropertyChanging();
					this._category = value;
					this.SendPropertyChanged("category");
					this.OncategoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_image", CanBeNull=false)]
		public string image
		{
			get
			{
				return this._image;
			}
			set
			{
				if ((this._image != value))
				{
					this.OnimageChanging(value);
					this.SendPropertyChanging();
					this._image = value;
					this.SendPropertyChanged("image");
					this.OnimageChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
