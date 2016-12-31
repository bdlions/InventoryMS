﻿using com.inventory.bean;
using com.inventory.db;
using com.inventory.db.manager;
using com.inventory.response;
using java.util;
using Prism.Commands;
using Prism.Mvvm;
using System;
using Ribbon.Model;
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

    class ManageSupplier : BindableBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        protected virtual void OnPropertyChanged_1([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                if (!String.IsNullOrEmpty(propertyName))
                {
                    if (propertyName.ToLower().Equals("firstname") || propertyName.ToLower().Equals("lastname"))
                    {
                        SupplierName = SupplierInfoNJ.ProfileInfoNJ.FirstName + " " + SupplierInfoNJ.ProfileInfoNJ.LastName;
                        handler(this, new PropertyChangedEventArgs("SupplierName"));
                    }
                }
                else
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }

            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;

            }
        }


        private int _supplierUserID;
        public int SupplierUserID
        {
            get
            {
                return this._supplierUserID;
            }
            set
            {
                this._supplierUserID = value;
            }
        }

        private string _fName;
        public string FirstName
        {
            get
            {
                return this._fName;
            }
            set
            {
                this._fName = value;
                OnPropertyChanged();
                OnPropertyChanged_1();
            }
        }

        private string _lName;
        public string LastName
        {
            get
            {
                return this._lName;

            }
            set
            {
                this._lName = value;
                OnPropertyChanged();
                OnPropertyChanged_1();
            }
        }

        private string _name;
        public string SupplierName
        {
            get
            {
                return this._fName + " " + this._lName;
            }
            set
            {
                this._name = value;
                OnPropertyChanged();
                OnPropertyChanged_1("SupplierName");
            }
        }

      

        private double _balance;
        public double Balance
        {
            get
            {
                return this._balance;
            }
            set
            {
                this._balance = value;
                OnPropertyChanged("Balance");
            }
        }

        private string _phone;
        public string Phone
        {
            get
            {
                return this._phone;
            }
            set
            {
                this._phone = value;
                OnPropertyChanged("Phone");
            }
        }

        private string _fax;
        public string Fax
        {
            get
            {
                return this._fax;
            }
            set
            {
                this._fax = value;
                OnPropertyChanged("Fax");
            }
        }

        private string _email;
        public string Email
        {
            get
            {
                return this._email;
            }
            set
            {
                this._email = value;
                OnPropertyChanged("Email");
            }
        }

        private string _website;
        public string Website
        {
            get
            {
                return this._website;
            }
            set
            {
                this._website = value;
                OnPropertyChanged("Website");
            }
        }

        private string _address;
        public string Address
        {
            get
            {
                return this._address;
            }
            set
            {
                this._address = value;
            }
        }

        private string _city;
        public string City
        {
            get
            {
                return this._city;
            }
            set
            {
                this._city = value;
            }
        }

        private string _state;
        public string State
        {
            get
            {
                return this._state;
            }
            set
            {
                this._state = value;
            }
        }

        private string _zip;
        public string Zip
        {
            get
            {
                return this._zip;
            }
            set
            {
                this._zip = value;
            }
        }


        private string _remark;
        public string Remark
        {
            get
            {
                return this._remark;
            }
            set
            {
                this._remark = value;
            }
        }

        private string _carrier;
        public string Carrier
        {
            get
            {
                return this._carrier;
            }
            set
            {
                this._carrier = value;
            }
        }


        // Search Supplier
        private string _searchSupplierPhone;
        public string SearchSupplierPhone
        {
            get
            {
                return this._searchSupplierPhone;
            }
            set
            {
                this._searchSupplierPhone = value;
            }
        }


        ObservableCollection<SupplierInfoNJ> _supplierList;

        public ObservableCollection<SupplierInfoNJ> SupplierList
        {
            get
            {
                SupplierManager supplierManager = new SupplierManager();

                _supplierList = new ObservableCollection<SupplierInfoNJ>();
                for (Iterator i = supplierManager.getAllSuppliers().iterator(); i.hasNext(); )
                {
                    SupplierInfo supplierInfo = (SupplierInfo)i.next();
                    SupplierInfoNJ supplierInfoNJ = new SupplierInfoNJ();

                    supplierInfoNJ.SupplierUserID = supplierInfo.getProfileInfo().getId();
                    supplierInfoNJ.SupplierFirstName = supplierInfo.getProfileInfo().getFirstName();
                    supplierInfoNJ.SupplierLastName = supplierInfo.getProfileInfo().getLastName();
                    supplierInfoNJ.Phone = supplierInfo.getProfileInfo().getPhone();
                    supplierInfoNJ.Fax = supplierInfo.getProfileInfo().getFax();
                    supplierInfoNJ.Email = supplierInfo.getProfileInfo().getEmail();
                    supplierInfoNJ.Website = supplierInfo.getProfileInfo().getWebsite();
                    //supplierInfoNJ.Remarks = supplierInfo.getRemarks();

                    _supplierList.Add(supplierInfoNJ);
                }
                return _supplierList;
            }
            set
            {
                this._supplierList = value;
            }
        }


        //    Supplier menu

        public ICommand Add
        {
            get
            {
                return new DelegateCommand(this.OnAdd);
            }
        }
        public ICommand Reset
        {
            get
            {
                return new DelegateCommand(this.OnReset);
            }
        }
        public ICommand Print
        {
            get
            {
                return new DelegateCommand(this.OnPrint);
            }
        }
        public ICommand Attachment
        {
            get
            {
                return new DelegateCommand(this.OnAddAttachment);
            }
        }

        public ICommand Deactivate
        {
            get
            {
                return new DelegateCommand(this.OnDeactivate);
            }
        }
        public ICommand Copy
        {
            get
            {
                return new DelegateCommand(this.OnCopy);
            }
        }
        public ICommand Search
        {
            get
            {
                return new DelegateCommand(this.OnSearch);
            }
        }
        public ICommand SelectSupplierEvent
        {
            get
            {
                return new DelegateCommand<SupplierInfoNJ>(this.selectSupplierEvent);
            }
        }

        /// <summary>
        /// Called when Button SendToViewModel is clicked
        /// </summary>
        private void OnAdd()
        {
            if (!ValidateSupplier())
            {
                MessageBox.Show(ErrorMessage);
                return;
            }
            ProfileInfo profileInfo = new ProfileInfo();
            profileInfo.setId(SupplierUserID);
            profileInfo.setFirstName(FirstName);
            profileInfo.setLastName(LastName);
            profileInfo.setEmail(Email);
            profileInfo.setPhone(Phone);
            profileInfo.setFax(Fax);
            profileInfo.setWebsite(Website);

            SupplierInfo supplierInfo = new SupplierInfo();
            supplierInfo.setProfileInfo(profileInfo);
            //supplierInfo.setRemarks(SupplierInfoNJ.Remarks);
            
            ResultEvent resultEvent = new ResultEvent();
            SupplierManager supplierManager = new SupplierManager();
            if ( SupplierUserID > 0)
            {
                resultEvent = supplierManager.updateSupplier(supplierInfo);
            }
            else
            {
                resultEvent = supplierManager.createSupplier(supplierInfo);
                OnReset();
            }
            if (resultEvent.getResponseCode() == 2000)
            {

                
            }

            MessageBox.Show(resultEvent.getMessage());
        }


        /// <summary>
        /// Called when Button SendToViewModel is clicked
        /// </summary>
        private void OnReset()
        {
            this.FirstName = "";
            this.LastName = "";
            this.SupplierName = "";
            this.Balance = 0;
            this.Email = "";
            this.Phone = "";
            this.Fax = "";
            this.Website = "";
           // MessageBox.Show("OnReset");
        }

        /// <summary>
        /// Called when Button SendToViewModel is clicked
        /// </summary>
        private void OnPrint()
        {
            MessageBox.Show("OnPrint");
        }

        /// <summary>
        /// Called when Button SendToViewModel is clicked
        /// </summary>
        private void OnAddAttachment()
        {
            MessageBox.Show("OnAddAttachment");
        }

        /// <summary>
        /// Called when Button SendToViewModel is clicked
        /// </summary>
        private void OnCopy()
        {
            MessageBox.Show("OnCopy");
        }
        /// <summary>
        /// Called when Button SendToViewModel is clicked
        /// </summary>
        private void OnDeactivate()
        {
            MessageBox.Show("OnDeactivate");
        }
        private void OnSearch()
        {

            SupplierManager supplierManager = new SupplierManager();

            _supplierList.Clear();
            for (Iterator i = supplierManager.searchSuppliers(SearchSupplierPhone).iterator(); i.hasNext(); )
            {
                SupplierInfo supplierInfo = (SupplierInfo)i.next();
                SupplierInfoNJ supplierInfoNJ = new SupplierInfoNJ();

                supplierInfoNJ.SupplierUserID = supplierInfo.getProfileInfo().getId();
                supplierInfoNJ.SupplierFirstName = supplierInfo.getProfileInfo().getFirstName();
                supplierInfoNJ.SupplierLastName = supplierInfo.getProfileInfo().getLastName();
                supplierInfoNJ.Phone = supplierInfo.getProfileInfo().getPhone();
                supplierInfoNJ.Fax = supplierInfo.getProfileInfo().getFax();
                supplierInfoNJ.Email = supplierInfo.getProfileInfo().getEmail();
                supplierInfoNJ.Website = supplierInfo.getProfileInfo().getWebsite();

                _supplierList.Add(supplierInfoNJ);
            }
        }
        public void selectSupplierEvent(SupplierInfoNJ supplierInfoNJ)
        {

            this.SupplierUserID = supplierInfoNJ.SupplierUserID;
            this.FirstName = supplierInfoNJ.SupplierFirstName;
            this.LastName = supplierInfoNJ.SupplierLastName;
            this.SupplierName = supplierInfoNJ.SupplierName;
            this.Balance = supplierInfoNJ.Balance;
            this.Email = supplierInfoNJ.Email;
            this.Phone = supplierInfoNJ.Phone;
            this.Fax = supplierInfoNJ.Fax;
            this.Website = supplierInfoNJ.Website;
        }

        public Boolean ValidateSupplier()
        {
            ErrorMessage = "Supplier name is required.";
            return false;
        }
    }
}
