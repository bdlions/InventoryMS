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
    class ManageCustomerList :BindableBase
    {
          //constructor
        public ManageCustomerList()
        {
            //loading customer list on left panel
            CustomerManager customerManager = new CustomerManager();
            for (Iterator i = customerManager.getAllCustomers().iterator(); i.hasNext(); )
            {
                CustomerInfo customerInfo = (CustomerInfo)i.next();
                CustomerInfoNJ customerInfoNJ = new CustomerInfoNJ();
                customerInfoNJ.ProfileInfoNJ.Id = customerInfo.getProfileInfo().getId();
                customerInfoNJ.ProfileInfoNJ.FirstName = customerInfo.getProfileInfo().getFirstName();
                customerInfoNJ.ProfileInfoNJ.LastName = customerInfo.getProfileInfo().getLastName();
                customerInfoNJ.ProfileInfoNJ.Phone = customerInfo.getProfileInfo().getPhone();
                customerInfoNJ.ProfileInfoNJ.Fax = customerInfo.getProfileInfo().getFax();
                customerInfoNJ.ProfileInfoNJ.Email = customerInfo.getProfileInfo().getEmail();
                customerInfoNJ.ProfileInfoNJ.Website = customerInfo.getProfileInfo().getWebsite();
                CustomerList.Add(customerInfoNJ);
            }
        }
      
        //customer info
        private CustomerInfoNJ _customerInfoNJ;
        public CustomerInfoNJ CustomerInfoNJ
        {
            get
            {
                if (_customerInfoNJ == null)
                {
                    _customerInfoNJ = new CustomerInfoNJ();
                }
                return this._customerInfoNJ;
            }
            set
            {
                this._customerInfoNJ = value;
            }
        }


        // Search Customer panel
        private string _searchCustomerByPhone;
        public string SearchCustomerByPhone
        {
            get
            {
                return this._searchCustomerByPhone;
            }
            set
            {
                this._searchCustomerByPhone = value;
            }
        }


        ObservableCollection<CustomerInfoNJ> _customerList;
        public ObservableCollection<CustomerInfoNJ> CustomerList
        {
            get
            {
                if (_customerList == null)
                {
                    _customerList = new ObservableCollection<CustomerInfoNJ>();
                }
                return _customerList;
            }
            set
            {
                this._customerList = value;
            }
        }

        /*
      * Event Handler to searh customer
      * @author A.K.M. Nazmul Islam on 30th january 2016
      */
        public ICommand Search
        {
            get
            {
                return new DelegateCommand(this.OnSearch);
            }
        }
        /*
        * This method will search customer info
        * @author A.K.M. Nazmul Islam on 30th january 2016
        */
        private void OnSearch()
        {
            CustomerManager customerManager = new CustomerManager();
            CustomerList.Clear();
            for (Iterator i = customerManager.searchCustomers(SearchCustomerByPhone).iterator(); i.hasNext(); )
            {
                CustomerInfo customerInfo = (CustomerInfo)i.next();
                CustomerInfoNJ customerInfoNJ = new CustomerInfoNJ();
                customerInfoNJ.ProfileInfoNJ.Id = customerInfo.getProfileInfo().getId();
                customerInfoNJ.ProfileInfoNJ.FirstName = customerInfo.getProfileInfo().getFirstName();
                customerInfoNJ.ProfileInfoNJ.LastName = customerInfo.getProfileInfo().getLastName();
                customerInfoNJ.ProfileInfoNJ.Phone = customerInfo.getProfileInfo().getPhone();
                customerInfoNJ.ProfileInfoNJ.Fax = customerInfo.getProfileInfo().getFax();
                customerInfoNJ.ProfileInfoNJ.Email = customerInfo.getProfileInfo().getEmail();
                customerInfoNJ.ProfileInfoNJ.Website = customerInfo.getProfileInfo().getWebsite();
                CustomerList.Add(customerInfoNJ);
            }
        }



        //ObservableCollection<CustomerInfoNJ> _customerList;

        //public ObservableCollection<CustomerInfoNJ> CustomerList
        //{
        //    get
        //    {
        //        CustomerManager customerManager = new CustomerManager();

        //        _customerList = new ObservableCollection<CustomerInfoNJ>();
        //        for (Iterator i = customerManager.getAllCustomers().iterator(); i.hasNext(); )
        //        {
        //            CustomerInfo customerInfo = (CustomerInfo)i.next();
        //            CustomerInfoNJ customerInfoNJ = new CustomerInfoNJ();

        //            customerInfoNJ.CustomerFirstName = customerInfo.getProfileInfo().getFirstName();
        //            customerInfoNJ.CustomerLastName = customerInfo.getProfileInfo().getLastName();
        //            customerInfoNJ.Phone = customerInfo.getProfileInfo().getPhone();
        //            customerInfoNJ.Fax = customerInfo.getProfileInfo().getFax();
        //            customerInfoNJ.Email = customerInfo.getProfileInfo().getEmail();
        //            customerInfoNJ.Website = customerInfo.getProfileInfo().getWebsite();

        //            _customerList.Add(customerInfoNJ);
        //        }
        //        return _customerList;
        //    }
        //    set
        //    {
        //        this._customerList = value;
        //    }
        //}


    }
}


