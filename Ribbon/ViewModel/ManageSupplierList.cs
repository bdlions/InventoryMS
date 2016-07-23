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
    class ManageSupplierList:BindableBase
    {
        ObservableCollection<SupplierInfoNJ> _supplierList;

        public ObservableCollection<SupplierInfoNJ> SuppplierList
        {
            get
            {
                SupplierManager supplierManager = new SupplierManager();

                _supplierList = new ObservableCollection<SupplierInfoNJ>();
                for (Iterator i = supplierManager.getAllSuppliers().iterator(); i.hasNext(); )
                {
                    SupplierInfo supplierInfo = (SupplierInfo)i.next();
                    SupplierInfoNJ supplierInfoNJ = new SupplierInfoNJ();

                    supplierInfoNJ.SupplierFirstName = supplierInfo.getProfileInfo().getFirstName();
                    supplierInfoNJ.SupplierLastName = supplierInfo.getProfileInfo().getLastName();
                    supplierInfoNJ.Phone = supplierInfo.getProfileInfo().getPhone();
                    supplierInfoNJ.Fax = supplierInfo.getProfileInfo().getFax();
                    supplierInfoNJ.Email = supplierInfo.getProfileInfo().getEmail();
                    supplierInfoNJ.Website = supplierInfo.getProfileInfo().getWebsite();

                    _supplierList.Add(supplierInfoNJ);
                }
                return _supplierList;
            }
            set
            {
                this._supplierList = value;
            }
        }
    }
}
