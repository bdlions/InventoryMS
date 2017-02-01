using com.inventory.bean;
using com.inventory.db;
using com.inventory.db.manager;
using com.inventory.response;
using java.util;
using Prism.Commands;
using Prism.Mvvm;
using Ribbon.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Ribbon.Constants;


namespace Ribbon.ViewModel
{
    class ManagePurchaseOrderList : BindableBase
    {


             //constructor
        public ManagePurchaseOrderList() 
        {
            //loading purchase list
            PurchaseManager purchaseManager = new PurchaseManager();
            for (Iterator i = purchaseManager.getAllPurchaseOrders().iterator(); i.hasNext(); )
            {
                PurchaseInfo purchaseInfo = (PurchaseInfo)i.next();
                PurchaseInfoNJ purchaseInfoNJ = new PurchaseInfoNJ();
                purchaseInfoNJ.OrderNo = purchaseInfo.getOrderNo();
                purchaseInfoNJ.StatusId = purchaseInfo.getStatusId();
                purchaseInfoNJ.Remarks = purchaseInfo.getRemarks();
                for (Iterator j = purchaseInfo.getProductList().iterator(); j.hasNext(); )
                {
                    ProductInfo productInfo = (ProductInfo)j.next();
                    ProductInfoNJ productInfoNJ = new ProductInfoNJ();
                    productInfoNJ.Id = productInfo.getId();
                    productInfoNJ.Name = productInfo.getName();
                    productInfoNJ.Code = productInfo.getCode();
                    productInfoNJ.UnitPrice = productInfo.getUnitPrice();
                    productInfoNJ.Quantity = productInfo.getQuantity();
                    purchaseInfoNJ.ProductList.Add(productInfoNJ);
                }
                SupplierInfo supplierInfo = new SupplierInfo();
                SupplierInfoNJ supplierInfoNJ = new SupplierInfoNJ();
                supplierInfoNJ.ProfileInfoNJ.Id = purchaseInfo.getSupplierInfo().getProfileInfo().getId();
                supplierInfoNJ.ProfileInfoNJ.FirstName = purchaseInfo.getSupplierInfo().getProfileInfo().getFirstName();
                supplierInfoNJ.ProfileInfoNJ.LastName = purchaseInfo.getSupplierInfo().getProfileInfo().getLastName();
                purchaseInfoNJ.SupplierInfoNJ = supplierInfoNJ;
                PurchaseOrderList.Add(purchaseInfoNJ);
            }
        }

        //purchase order list on left panel
        ObservableCollection<PurchaseInfoNJ> _purchaseOrderList;
        public ObservableCollection<PurchaseInfoNJ> PurchaseOrderList
        {
            get
            {
                if(_purchaseOrderList == null)
                {
                    _purchaseOrderList = new ObservableCollection<PurchaseInfoNJ>();
                }
                return _purchaseOrderList;             
            }
            set
            {
                this._purchaseOrderList = value;
            }
        }

        

        //purchase order info
        private PurchaseInfoNJ _purchaseInfoNJ;
        public PurchaseInfoNJ PurchaseInfoNJ
        {
            get
            {
                if (_purchaseInfoNJ == null)
                {
                    _purchaseInfoNJ = new PurchaseInfoNJ();
                }
                return this._purchaseInfoNJ;
            }
            set
            {
                this._purchaseInfoNJ = value;
            }
        }

          // Search Purchase Order
        private string _searchPurchaseByOderNo;
        public string SearchPurchaseByOderNo
        {
            get
            {
                return this._searchPurchaseByOderNo;
            }
            set
            {
                this._searchPurchaseByOderNo = value;
            }
        }


        public ICommand Search
        {
            get
            {
                return new DelegateCommand(this.OnSearch);
            }
        }


        private void OnSearch()
        {
            PurchaseManager purchaseManager = new PurchaseManager();
            PurchaseOrderList.Clear();
            for (Iterator i = purchaseManager.searchPurchaseOrders(SearchPurchaseByOderNo).iterator(); i.hasNext(); )
            {
                PurchaseInfo purchaseInfo = (PurchaseInfo)i.next();
                PurchaseInfoNJ purchaseInfoNJ = new PurchaseInfoNJ();

                purchaseInfoNJ.OrderNo = purchaseInfo.getOrderNo();
                purchaseInfoNJ.StatusId = purchaseInfo.getStatusId();
                purchaseInfoNJ.Remarks = purchaseInfo.getRemarks();

                SupplierInfo supplierInfo = new SupplierInfo();
                SupplierInfoNJ supplierInfoNJ = new SupplierInfoNJ();

                supplierInfoNJ.ProfileInfoNJ.Id = purchaseInfo.getSupplierInfo().getProfileInfo().getId();
                supplierInfoNJ.ProfileInfoNJ.FirstName = purchaseInfo.getSupplierInfo().getProfileInfo().getFirstName();
                supplierInfoNJ.ProfileInfoNJ.LastName = purchaseInfo.getSupplierInfo().getProfileInfo().getLastName();
                purchaseInfoNJ.SupplierInfoNJ = supplierInfoNJ;

                PurchaseOrderList.Add(purchaseInfoNJ);
            }
        }


        //ObservableCollection<PurchaseInfoNJ> _purchaseList;

        //public ObservableCollection<PurchaseInfoNJ> PurchaseList
        //{
        //    get
        //    {
        //        PurchaseManager purchaseManager = new PurchaseManager();

        //        _purchaseList = new ObservableCollection<PurchaseInfoNJ>();
        //        for (Iterator i = purchaseManager.getAllPurchaseOrders().iterator(); i.hasNext(); )
        //        {
        //            PurchaseInfo purchaseInfo = (PurchaseInfo)i.next();
        //            PurchaseInfoNJ purchaseInfoNJ = new PurchaseInfoNJ();
        //            purchaseInfoNJ.Order = purchaseInfo.getOrderNo();
        //            purchaseInfoNJ.OrderRemark = purchaseInfo.getRemarks();
        //            purchaseInfoNJ.RequestedShipDate = purchaseInfo.getRequestShippedDate();
        //            //purchaseInfoNJ.OrderDate = purchaseInfo.getOrderDate();
        //            purchaseInfoNJ.StatusId = purchaseInfo.getStatusId();
        //            purchaseInfoNJ.Discount = purchaseInfo.getDiscount();

        //            purchaseInfoNJ.SupplierFirstName = purchaseInfo.getSupplierInfo().getProfileInfo().getFirstName();
        //            purchaseInfoNJ.SupplierLastName = purchaseInfo.getSupplierInfo().getProfileInfo().getLastName();
                    
        //            //supplierInfoNJ.SupplierUserID = supplierInfo.getProfileInfo().getId();


        //            _purchaseList.Add(purchaseInfoNJ);
        //        }
        //        return _purchaseList;
        //    }
        //    set
        //    {
        //        this._purchaseList = value;
        //    }
        //}



    }
}