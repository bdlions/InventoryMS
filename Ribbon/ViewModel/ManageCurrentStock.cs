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

namespace Ribbon.ViewModel
{
    class ManageCurrentStock : BindableBase
    {

        ObservableCollection<ProductInfoNJ> _currentStockList;

        public ObservableCollection<ProductInfoNJ> CurrentStockList
        {
            get
            {
                StockManager stockManager = new StockManager();

                _currentStockList = new ObservableCollection<ProductInfoNJ>();
                for (Iterator i = stockManager.getCurrentStocks().iterator(); i.hasNext(); )
                {
                    ProductInfo productInfo = (ProductInfo)i.next();
                    ProductInfoNJ productInfoNJ = new ProductInfoNJ();

                    productInfoNJ.Name = productInfo.getName();
                    productInfoNJ.Quantity = productInfo.getQuantity();

                    _currentStockList.Add(productInfoNJ);
                }
                return _currentStockList;
            }
            set
            {
                this._currentStockList = value;
            }
        }
    }
}
