using com.inventory.bean;
using com.inventory.db;
using com.inventory.db.manager;
using com.inventory.response;
using java.util;
using Prism.Commands;
using Prism.Mvvm;
using System;
using Ribbon.Model;
using Ribbon.Constants;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace Ribbon.ViewModel
{
    class ManageProductList : BindableBase
    {
           //constructor
        public ManageProductList()
        {
            //loading product list
            ProductManager productManager = new ProductManager();
            for (Iterator i = productManager.getAllProducts().iterator(); i.hasNext(); )
            {
                ProductInfo productInfo = (ProductInfo)i.next();
                ProductInfoNJ productInfoNJ = new ProductInfoNJ();
                productInfoNJ.Id = productInfo.getId();
                productInfoNJ.Name = productInfo.getName();
                productInfoNJ.Code = productInfo.getCode();
                productInfoNJ.UnitPrice = productInfo.getUnitPrice();
                ProductList.Add(productInfoNJ);
            }
        }


        //product info
        private ProductInfoNJ _productInfoNJ;
        public ProductInfoNJ ProductInfoNJ
        {
            get
            {
                if(_productInfoNJ == null)
                {
                    _productInfoNJ = new ProductInfoNJ();
                }
                return _productInfoNJ;
            }
            set
            {
                _productInfoNJ = value;

            }
        }
        

        // search product by name
        private string _searchProductByName;
        public string SearchProductByName
        {
            get
            {
                return this._searchProductByName;
            }
            set
            {
                this._searchProductByName = value;
            }
        }

        //product list 
        ObservableCollection<ProductInfoNJ> _productList;
        public ObservableCollection<ProductInfoNJ> ProductList
        {
            get
            {
                if(_productList == null)
                {
                    _productList = new ObservableCollection<ProductInfoNJ>();
                }                
                return _productList;
            }
            set
            {
                this._productList = value;
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

            ProductManager productManager = new ProductManager();

            _productList.Clear();
            for (Iterator i = productManager.searchProduct(SearchProductByName).iterator(); i.hasNext(); )
            {
                ProductInfo productInfo = (ProductInfo)i.next();
                ProductInfoNJ productInfoNJ = new ProductInfoNJ();
                productInfoNJ.Id = productInfo.getId();
                productInfoNJ.Name = productInfo.getName();
                productInfoNJ.Code = productInfo.getCode();
                productInfoNJ.UnitPrice = productInfo.getUnitPrice();
                ProductList.Add(productInfoNJ);
            }
        }


        //// Search product items
        //private string _searchProductName;
        //public string SearchProductName
        //{
        //    get
        //    {
        //        return this._searchProductName;
        //    }
        //    set
        //    {
        //        this._searchProductName = value;
        //    }
        //}

        //ObservableCollection<ProductInfoNJ> _productList;

        //public ObservableCollection<ProductInfoNJ> ProductList
        //{ 
        //    get {
        //        ProductManager productManager = new ProductManager();

        //        _productList = new ObservableCollection<ProductInfoNJ>();
        //        for (Iterator i = productManager.getAllProducts().iterator(); i.hasNext(); )
        //        {
        //            ProductInfo pInfo = (ProductInfo)i.next();
        //            ProductInfoNJ pInfoNJ = new ProductInfoNJ();
        //            pInfoNJ.Name = pInfo.getName();
        //            pInfoNJ.Code = pInfo.getCode();
        //            pInfoNJ.Price = pInfo.getUnitPrice();
        //            _productList.Add(pInfoNJ);
        //        }
        //        return _productList;
        //    }
        //    set {
        //        this._productList = value;
        //    }
        //}
    }
}
