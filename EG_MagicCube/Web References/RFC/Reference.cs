﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.42000
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 原始程式碼已由 Microsoft.VSDesigner 自動產生，版本 4.0.30319.42000。
// 
#pragma warning disable 1591

namespace EG_MagicCube.RFC {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="serviceSoap", Namespace="http://tempuri.org/")]
    public partial class service : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetAllVendorsOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetAllWarehousesOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetAllProductsOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetAllProductsByIDOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetAllStockOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetAllPriceOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public service() {
            this.Url = global::EG_MagicCube.Properties.Settings.Default.EG_MagicCube_RFC_service;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetAllVendorsCompletedEventHandler GetAllVendorsCompleted;
        
        /// <remarks/>
        public event GetAllWarehousesCompletedEventHandler GetAllWarehousesCompleted;
        
        /// <remarks/>
        public event GetAllProductsCompletedEventHandler GetAllProductsCompleted;
        
        /// <remarks/>
        public event GetAllProductsByIDCompletedEventHandler GetAllProductsByIDCompleted;
        
        /// <remarks/>
        public event GetAllStockCompletedEventHandler GetAllStockCompleted;
        
        /// <remarks/>
        public event GetAllPriceCompletedEventHandler GetAllPriceCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetAllVendors", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetAllVendors(string P_DATE_from, string P_DATE_TO) {
            object[] results = this.Invoke("GetAllVendors", new object[] {
                        P_DATE_from,
                        P_DATE_TO});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetAllVendorsAsync(string P_DATE_from, string P_DATE_TO) {
            this.GetAllVendorsAsync(P_DATE_from, P_DATE_TO, null);
        }
        
        /// <remarks/>
        public void GetAllVendorsAsync(string P_DATE_from, string P_DATE_TO, object userState) {
            if ((this.GetAllVendorsOperationCompleted == null)) {
                this.GetAllVendorsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetAllVendorsOperationCompleted);
            }
            this.InvokeAsync("GetAllVendors", new object[] {
                        P_DATE_from,
                        P_DATE_TO}, this.GetAllVendorsOperationCompleted, userState);
        }
        
        private void OnGetAllVendorsOperationCompleted(object arg) {
            if ((this.GetAllVendorsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetAllVendorsCompleted(this, new GetAllVendorsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetAllWarehouses", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetAllWarehouses() {
            object[] results = this.Invoke("GetAllWarehouses", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetAllWarehousesAsync() {
            this.GetAllWarehousesAsync(null);
        }
        
        /// <remarks/>
        public void GetAllWarehousesAsync(object userState) {
            if ((this.GetAllWarehousesOperationCompleted == null)) {
                this.GetAllWarehousesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetAllWarehousesOperationCompleted);
            }
            this.InvokeAsync("GetAllWarehouses", new object[0], this.GetAllWarehousesOperationCompleted, userState);
        }
        
        private void OnGetAllWarehousesOperationCompleted(object arg) {
            if ((this.GetAllWarehousesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetAllWarehousesCompleted(this, new GetAllWarehousesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetAllProducts", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetAllProducts(string P_DATE_from, string P_DATE_TO) {
            object[] results = this.Invoke("GetAllProducts", new object[] {
                        P_DATE_from,
                        P_DATE_TO});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetAllProductsAsync(string P_DATE_from, string P_DATE_TO) {
            this.GetAllProductsAsync(P_DATE_from, P_DATE_TO, null);
        }
        
        /// <remarks/>
        public void GetAllProductsAsync(string P_DATE_from, string P_DATE_TO, object userState) {
            if ((this.GetAllProductsOperationCompleted == null)) {
                this.GetAllProductsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetAllProductsOperationCompleted);
            }
            this.InvokeAsync("GetAllProducts", new object[] {
                        P_DATE_from,
                        P_DATE_TO}, this.GetAllProductsOperationCompleted, userState);
        }
        
        private void OnGetAllProductsOperationCompleted(object arg) {
            if ((this.GetAllProductsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetAllProductsCompleted(this, new GetAllProductsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetAllProductsByID", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetAllProductsByID(string ProductsList) {
            object[] results = this.Invoke("GetAllProductsByID", new object[] {
                        ProductsList});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetAllProductsByIDAsync(string ProductsList) {
            this.GetAllProductsByIDAsync(ProductsList, null);
        }
        
        /// <remarks/>
        public void GetAllProductsByIDAsync(string ProductsList, object userState) {
            if ((this.GetAllProductsByIDOperationCompleted == null)) {
                this.GetAllProductsByIDOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetAllProductsByIDOperationCompleted);
            }
            this.InvokeAsync("GetAllProductsByID", new object[] {
                        ProductsList}, this.GetAllProductsByIDOperationCompleted, userState);
        }
        
        private void OnGetAllProductsByIDOperationCompleted(object arg) {
            if ((this.GetAllProductsByIDCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetAllProductsByIDCompleted(this, new GetAllProductsByIDCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetAllStock", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetAllStock(string P_DATE) {
            object[] results = this.Invoke("GetAllStock", new object[] {
                        P_DATE});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetAllStockAsync(string P_DATE) {
            this.GetAllStockAsync(P_DATE, null);
        }
        
        /// <remarks/>
        public void GetAllStockAsync(string P_DATE, object userState) {
            if ((this.GetAllStockOperationCompleted == null)) {
                this.GetAllStockOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetAllStockOperationCompleted);
            }
            this.InvokeAsync("GetAllStock", new object[] {
                        P_DATE}, this.GetAllStockOperationCompleted, userState);
        }
        
        private void OnGetAllStockOperationCompleted(object arg) {
            if ((this.GetAllStockCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetAllStockCompleted(this, new GetAllStockCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetAllPrice", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetAllPrice(string P_DATE) {
            object[] results = this.Invoke("GetAllPrice", new object[] {
                        P_DATE});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetAllPriceAsync(string P_DATE) {
            this.GetAllPriceAsync(P_DATE, null);
        }
        
        /// <remarks/>
        public void GetAllPriceAsync(string P_DATE, object userState) {
            if ((this.GetAllPriceOperationCompleted == null)) {
                this.GetAllPriceOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetAllPriceOperationCompleted);
            }
            this.InvokeAsync("GetAllPrice", new object[] {
                        P_DATE}, this.GetAllPriceOperationCompleted, userState);
        }
        
        private void OnGetAllPriceOperationCompleted(object arg) {
            if ((this.GetAllPriceCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetAllPriceCompleted(this, new GetAllPriceCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void GetAllVendorsCompletedEventHandler(object sender, GetAllVendorsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetAllVendorsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetAllVendorsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void GetAllWarehousesCompletedEventHandler(object sender, GetAllWarehousesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetAllWarehousesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetAllWarehousesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void GetAllProductsCompletedEventHandler(object sender, GetAllProductsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetAllProductsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetAllProductsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void GetAllProductsByIDCompletedEventHandler(object sender, GetAllProductsByIDCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetAllProductsByIDCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetAllProductsByIDCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void GetAllStockCompletedEventHandler(object sender, GetAllStockCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetAllStockCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetAllStockCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void GetAllPriceCompletedEventHandler(object sender, GetAllPriceCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetAllPriceCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetAllPriceCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591