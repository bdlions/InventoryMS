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
    class ManageSalesOrderList:BindableBase
    {

        
        //constructor
        public ManageSalesOrderList()
        {
            //loading sale list 
            SaleManager saleManager = new SaleManager();
            for (Iterator i = saleManager.getAllSaleOrders().iterator(); i.hasNext(); )
            {
                SaleInfo saleInfo = (SaleInfo)i.next();
                SaleInfoNJ saleInfoNJ = new SaleInfoNJ();
                saleInfoNJ.OrderNo = saleInfo.getOrderNo();
                saleInfoNJ.StatusId = saleInfo.getStatusId();
                saleInfoNJ.Remarks = saleInfo.getRemarks();
                for (Iterator j = saleInfo.getProductList().iterator(); j.hasNext(); )
                {
                    ProductInfo productInfo = (ProductInfo)j.next();
                    ProductInfoNJ productInfoNJ = new ProductInfoNJ();
                    productInfoNJ.Id = productInfo.getId();
                    productInfoNJ.Name = productInfo.getName();
                    productInfoNJ.Code = productInfo.getCode();
                    productInfoNJ.UnitPrice = productInfo.getUnitPrice();
                    productInfoNJ.Quantity = productInfo.getQuantity();
                    saleInfoNJ.ProductList.Add(productInfoNJ);
                }
                CustomerInfo customerInfo = new CustomerInfo();
                CustomerInfoNJ customerInfoNJ = new CustomerInfoNJ();
                customerInfoNJ.ProfileInfoNJ.Id = saleInfo.getCustomerInfo().getProfileInfo().getId();
                customerInfoNJ.ProfileInfoNJ.FirstName = saleInfo.getCustomerInfo().getProfileInfo().getFirstName();
                customerInfoNJ.ProfileInfoNJ.LastName = saleInfo.getCustomerInfo().getProfileInfo().getLastName();
                saleInfoNJ.CustomerInfoNJ = customerInfoNJ;
                SaleOrderList.Add(saleInfoNJ);
            }
        }


        //sale order list on left panel
        ObservableCollection<SaleInfoNJ> _saleOrderList;
        public ObservableCollection<SaleInfoNJ> SaleOrderList
        {
            get
            {
                if (_saleOrderList == null)
                {
                    _saleOrderList = new ObservableCollection<SaleInfoNJ>();
                }
                return _saleOrderList;
            }
            set
            {
                this._saleOrderList = value;
            }
        }

        //sale order info
        private SaleInfoNJ _saleInfoNJ;
        public SaleInfoNJ SaleInfoNJ
        {
            get
            {
                if (_saleInfoNJ == null)
                {
                    _saleInfoNJ = new SaleInfoNJ();
                }
                return this._saleInfoNJ;
            }
            set
            {
                this._saleInfoNJ = value;
                OnPropertyChanged("SaleInfoNJ");
            }
        }


        // Search Sale Order
        private string _searchSaleByOderNo;
        public string SearchSaleByOderNo
        {
            get
            {
                return this._searchSaleByOderNo;
            }
            set
            {
                this._searchSaleByOderNo = value;
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

            SaleManager saleManager = new SaleManager();

            SaleOrderList.Clear();
            for (Iterator i = saleManager.searchAllSaleOrders(SearchSaleByOderNo).iterator(); i.hasNext(); )
            {
                SaleInfo saleInfo = (SaleInfo)i.next();
                SaleInfoNJ saleInfoNJ = new SaleInfoNJ();

                saleInfoNJ.OrderNo = saleInfo.getOrderNo();
                saleInfoNJ.CustomerUserId = saleInfo.getCustomerUserId();
                saleInfoNJ.StatusId = saleInfo.getStatusId();
                saleInfoNJ.SaleDate = saleInfo.getSaleDate();
                saleInfoNJ.Discount = saleInfo.getDiscount();
                saleInfoNJ.Remarks = saleInfo.getRemarks();
                SaleOrderList.Add(saleInfoNJ);
            }
        }

        //ObservableCollection<SaleInfoNJ> _saleList;

        //public ObservableCollection<SaleInfoNJ> SaleList
        //{
        //    get
        //    {
        //        SaleManager saleManager = new SaleManager();

        //        _saleList = new ObservableCollection<SaleInfoNJ>();
        //        for (Iterator i = saleManager.getAllSaleOrders().iterator(); i.hasNext(); )
        //        {
        //            SaleInfo saleInfo = (SaleInfo)i.next();
        //            SaleInfoNJ saleInfoNJ = new SaleInfoNJ();
        //            saleInfoNJ.Order = saleInfo.getOrderNo();
        //            //saleInfoNJ.OrderDate = saleInfo.getSaleDate();
        //            saleInfoNJ.StatusId = saleInfo.getStatusId();
        //            saleInfoNJ.CustomerFirstName = saleInfo.getCustomerInfo().getProfileInfo().getFirstName();
        //            saleInfoNJ.CustomerLastName = saleInfo.getCustomerInfo().getProfileInfo().getLastName();

        //            _saleList.Add(saleInfoNJ);
        //        }
        //        return _saleList;
        //    }
        //    set
        //    {
        //        this._saleList = value;
        //    }
        //}



    }
}