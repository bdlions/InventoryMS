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
    class ManageSalesOrderList:BindableBase
    {
        ObservableCollection<SaleInfoNJ> _saleList;

        public ObservableCollection<SaleInfoNJ> SaleList
        {
            get
            {
                SaleManager saleManager = new SaleManager();

                _saleList = new ObservableCollection<SaleInfoNJ>();
                for (Iterator i = saleManager.getAllSaleOrders().iterator(); i.hasNext(); )
                {
                    SaleInfo saleInfo = (SaleInfo)i.next();
                    SaleInfoNJ saleInfoNJ = new SaleInfoNJ();
                    saleInfoNJ.Order = saleInfo.getOrderNo();
                    saleInfoNJ.OrderDate = saleInfo.getSaleDate();
                    saleInfoNJ.Status = saleInfo.getStatusId();

                    _saleList.Add(saleInfoNJ);
                }
                return _saleList;
            }
            set
            {
                this._saleList = value;
            }
        }
    }
}