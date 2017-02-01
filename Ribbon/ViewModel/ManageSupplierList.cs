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
    class ManageSupplierList : BindableBase
    {

     //constructor
        public ManageSupplierList()
        {
            //loading supplier list
            SupplierManager supplierManager = new SupplierManager();
            for (Iterator i = supplierManager.getAllSuppliers().iterator(); i.hasNext(); )
            {
                SupplierInfo supplierInfo = (SupplierInfo)i.next();
                SupplierInfoNJ supplierInfoNJ = new SupplierInfoNJ();
                supplierInfoNJ.ProfileInfoNJ.Id = supplierInfo.getProfileInfo().getId();
                supplierInfoNJ.ProfileInfoNJ.FirstName = supplierInfo.getProfileInfo().getFirstName();
                supplierInfoNJ.ProfileInfoNJ.LastName = supplierInfo.getProfileInfo().getLastName();
                supplierInfoNJ.ProfileInfoNJ.Phone = supplierInfo.getProfileInfo().getPhone();
                supplierInfoNJ.ProfileInfoNJ.Fax = supplierInfo.getProfileInfo().getFax();
                supplierInfoNJ.ProfileInfoNJ.Email = supplierInfo.getProfileInfo().getEmail();
                supplierInfoNJ.ProfileInfoNJ.Website = supplierInfo.getProfileInfo().getWebsite();
                supplierInfoNJ.Remarks = supplierInfo.getRemarks();
                SupplierList.Add(supplierInfoNJ);
            }
        }

        //supplier info
        private SupplierInfoNJ _supplierInfoNJ;
        public SupplierInfoNJ SupplierInfoNJ
        {
            get
            {
                if (_supplierInfoNJ == null)
                {
                    _supplierInfoNJ = new SupplierInfoNJ();
                }
                return this._supplierInfoNJ;
            }
            set
            {
                this._supplierInfoNJ = value;
            }
        }


        // Search Supplier
        private string _searchSupplierByPhone;
        public string SearchSupplierByPhone
        {
            get
            {
                return this._searchSupplierByPhone;
            }
            set
            {
                this._searchSupplierByPhone = value;
            }
        }


        ObservableCollection<SupplierInfoNJ> _supplierList;

        public ObservableCollection<SupplierInfoNJ> SupplierList
        {
            get
            {
                if (_supplierList == null)
                {
                    _supplierList = new ObservableCollection<SupplierInfoNJ>();
                }
                return _supplierList;
            }
            set
            {
                this._supplierList = value;
            }
        }




        /*
      * Event Handler to searh supplier
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
        * This method will search supplier info
        * @author A.K.M. Nazmul Islam on 30th january 2016
        */
        private void OnSearch()
        {
            SupplierManager supplierManager = new SupplierManager();
            SupplierList.Clear();
            for (Iterator i = supplierManager.searchSuppliers(SearchSupplierByPhone).iterator(); i.hasNext(); )
            {
                SupplierInfo supplierInfo = (SupplierInfo)i.next();
                SupplierInfoNJ supplierInfoNJ = new SupplierInfoNJ();
                supplierInfoNJ.ProfileInfoNJ.Id = supplierInfo.getProfileInfo().getId();
                supplierInfoNJ.ProfileInfoNJ.FirstName = supplierInfo.getProfileInfo().getFirstName();
                supplierInfoNJ.ProfileInfoNJ.LastName = supplierInfo.getProfileInfo().getLastName();
                supplierInfoNJ.ProfileInfoNJ.Phone = supplierInfo.getProfileInfo().getPhone();
                supplierInfoNJ.ProfileInfoNJ.Fax = supplierInfo.getProfileInfo().getFax();
                supplierInfoNJ.ProfileInfoNJ.Email = supplierInfo.getProfileInfo().getEmail();
                supplierInfoNJ.ProfileInfoNJ.Website = supplierInfo.getProfileInfo().getWebsite();
                supplierInfoNJ.Remarks = supplierInfo.getRemarks();
                SupplierList.Add(supplierInfoNJ);
            }
        }


        //ObservableCollection<SupplierInfoNJ> _supplierList;

        //public ObservableCollection<SupplierInfoNJ> SupplierList
        //{
        //    get
        //    {
        //        SupplierManager supplierManager = new SupplierManager();

        //        _supplierList = new ObservableCollection<SupplierInfoNJ>();
        //        for (Iterator i = supplierManager.getAllSuppliers().iterator(); i.hasNext(); )
        //        {
        //            SupplierInfo supplierInfo = (SupplierInfo)i.next();
        //            SupplierInfoNJ supplierInfoNJ = new SupplierInfoNJ();

        //            supplierInfoNJ.SupplierFirstName = supplierInfo.getProfileInfo().getFirstName();
        //            supplierInfoNJ.SupplierLastName = supplierInfo.getProfileInfo().getLastName();
        //            supplierInfoNJ.Phone = supplierInfo.getProfileInfo().getPhone();
        //            supplierInfoNJ.Fax = supplierInfo.getProfileInfo().getFax();
        //            supplierInfoNJ.Email = supplierInfo.getProfileInfo().getEmail();
        //            supplierInfoNJ.Website = supplierInfo.getProfileInfo().getWebsite();

        //            _supplierList.Add(supplierInfoNJ);
        //        }
        //        return _supplierList;
        //    }
        //    set
        //    {
        //        this._supplierList = value;
        //    }
        //}



    }
}
