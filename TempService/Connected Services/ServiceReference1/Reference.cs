﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TempService.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Product", Namespace="http://schemas.datacontract.org/2004/07/TempService")]
    [System.SerializableAttribute()]
    public partial class Product : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal PriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ImageField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CategoryField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Price {
            get {
                return this.PriceField;
            }
            set {
                if ((this.PriceField.Equals(value) != true)) {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Image
        {
            get
            {
                return this.ImageField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ImageField, value) != true))
                {
                    this.ImageField = value;
                    this.RaisePropertyChanged("Image");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Category
        {
            get
            {
                return this.CategoryField;
            }
            set
            {
                if ((object.ReferenceEquals(this.CategoryField, value) != true))
                {
                    this.CategoryField = value;
                    this.RaisePropertyChanged("Category");
                }
            }
        }


        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description
        {
            get
            {
                return this.DescriptionField;
            }
            set
            {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true))
                {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }





        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/returnList", ReplyAction="http://tempuri.org/IService1/returnListResponse")]
        TempService.ServiceReference1.Product[] returnList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/returnList", ReplyAction="http://tempuri.org/IService1/returnListResponse")]
        System.Threading.Tasks.Task<TempService.ServiceReference1.Product[]> returnListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Register", ReplyAction="http://tempuri.org/IService1/RegisterResponse")]
        string Register(string Email, string Name, string Username, string Surname, string Number, string Password, string Address);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Register", ReplyAction="http://tempuri.org/IService1/RegisterResponse")]
        System.Threading.Tasks.Task<string> RegisterAsync(string Email, string Name, string Username, string Surname, string Number, string Password, string Address);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/login", ReplyAction="http://tempuri.org/IService1/loginResponse")]
        string login(string Email, string Password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/login", ReplyAction="http://tempuri.org/IService1/loginResponse")]
        System.Threading.Tasks.Task<string> loginAsync(string Email, string Password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getProducts", ReplyAction="http://tempuri.org/IService1/getProductsResponse")]
        void getProducts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getProducts", ReplyAction="http://tempuri.org/IService1/getProductsResponse")]
        System.Threading.Tasks.Task getProductsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : TempService.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<TempService.ServiceReference1.IService1>, TempService.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public TempService.ServiceReference1.Product[] returnList() {
            return base.Channel.returnList();
        }
        
        public System.Threading.Tasks.Task<TempService.ServiceReference1.Product[]> returnListAsync() {
            return base.Channel.returnListAsync();
        }
        
        public string Register(string Email, string Name, string Username, string Surname, string Number, string Password, string Address) {
            return base.Channel.Register(Email, Name, Username, Surname, Number, Password, Address);
        }
        
        public System.Threading.Tasks.Task<string> RegisterAsync(string Email, string Name, string Username, string Surname, string Number, string Password, string Address) {
            return base.Channel.RegisterAsync(Email, Name, Username, Surname, Number, Password, Address);
        }
        
        public string login(string Email, string Password) {
            return base.Channel.login(Email, Password);
        }
        
        public System.Threading.Tasks.Task<string> loginAsync(string Email, string Password) {
            return base.Channel.loginAsync(Email, Password);
        }
        
        public void getProducts() {
            base.Channel.getProducts();
        }
        
        public System.Threading.Tasks.Task getProductsAsync() {
            return base.Channel.getProductsAsync();
        }
    }
}
