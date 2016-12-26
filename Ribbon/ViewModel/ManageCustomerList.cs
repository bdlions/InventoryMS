using com.inventory.bean;
using com.inventory.db;
using com.inventory.db.manager;
using java.util;
using Prism.Commands;
using Prism.Mvvm;
using Ribbon.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Ribbon.ViewModel
{
    class ManageCustomerList :BindableBase
    {
        ObservableCollection<CustomerInfoNJ> _customerList;

        public ObservableCollection<CustomerInfoNJ> CustomerList
        {
            get
            {
                CustomerManager customerManager = new CustomerManager();

                _customerList = new ObservableCollection<CustomerInfoNJ>();
                for (Iterator i = customerManager.getAllCustomers().iterator(); i.hasNext(); )
                {
                    CustomerInfo customerInfo = (CustomerInfo)i.next();
                    CustomerInfoNJ customerInfoNJ = new CustomerInfoNJ();

                    customerInfoNJ.CustomerFirstName = customerInfo.getProfileInfo().getFirstName();
                    customerInfoNJ.CustomerLastName = customerInfo.getProfileInfo().getLastName();
                    customerInfoNJ.Phone = customerInfo.getProfileInfo().getPhone();
                    customerInfoNJ.Fax = customerInfo.getProfileInfo().getFax();
                    customerInfoNJ.Email = customerInfo.getProfileInfo().getEmail();
                    customerInfoNJ.Website = customerInfo.getProfileInfo().getWebsite();

                    _customerList.Add(customerInfoNJ);
                }
                return _customerList;
            }
            set
            {
                this._customerList = value;
            }
        }
    }
}


