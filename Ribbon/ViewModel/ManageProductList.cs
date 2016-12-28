using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using com.inventory.bean;
using com.inventory.db.repositories;
using com.inventory.db;
using java.util;
using Ribbon.Model;
using com.inventory.db.manager;


namespace Ribbon.ViewModel
{
    class ManageProductList : BindableBase
    {

        // Search product items
        private string _searchProductName;
        public string SearchProductName
        {
            get
            {
                return this._searchProductName;
            }
            set
            {
                this._searchProductName = value;
            }
        }

        ObservableCollection<ProductInfoNJ> _productList;

        public ObservableCollection<ProductInfoNJ> ProductList
        { 
            get {
                ProductManager productManager = new ProductManager();

                _productList = new ObservableCollection<ProductInfoNJ>();
                for (Iterator i = productManager.getAllProducts().iterator(); i.hasNext(); )
                {
                    ProductInfo pInfo = (ProductInfo)i.next();
                    ProductInfoNJ pInfoNJ = new ProductInfoNJ();
                    pInfoNJ.Name = pInfo.getName();
                    pInfoNJ.Code = pInfo.getCode();
                    pInfoNJ.Price = pInfo.getUnitPrice();
                    _productList.Add(pInfoNJ);
                }
                return _productList;
            }
            set {
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
            for (Iterator i = productManager.searchProduct(SearchProductName).iterator(); i.hasNext(); )
            {
                ProductInfo pInfo = (ProductInfo)i.next();
                ProductInfoNJ pInfoNJ = new ProductInfoNJ();
                pInfoNJ.Id = pInfo.getId();
                pInfoNJ.Name = pInfo.getName();
                pInfoNJ.Code = pInfo.getCode();
                pInfoNJ.Price = pInfo.getUnitPrice();
                _productList.Add(pInfoNJ);
            }
        }

    }
}
