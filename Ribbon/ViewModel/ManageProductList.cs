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
namespace Ribbon.ViewModel
{
    class ManageProductList : BindableBase
    {
        ObservableCollection<ProductInfo> _productList;

        public ObservableCollection<ProductInfo> ProductList
        { 
            get {
                ProductManager productManager = new ProductManager();

                _productList = new ObservableCollection<ProductInfo>();
                for (Iterator i = productManager.getAllProducts().iterator(); i.hasNext(); ){
                    _productList.Add((ProductInfo)i.next());
                }

                return _productList;
            }
            set {
                this._productList = value;
            }
        }
    }
}
