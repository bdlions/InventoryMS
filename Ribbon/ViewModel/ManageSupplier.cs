using com.inventory.bean;
using com.inventory.db;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using java.util;
using com.inventory.db.manager;

namespace Ribbon.ViewModel
{

    class ManageSupplier : BindableBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                if (!String.IsNullOrEmpty(propertyName))
                {
                    if (propertyName.ToLower().Equals("firstname") || propertyName.ToLower().Equals("lastname"))
                    {
                        SupplierName = FirstName + " " + LastName;
                        handler(this, new PropertyChangedEventArgs("SupplierName"));
                    }
                }
                else
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }

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



        /// <summary>
        /// Called when Button SendToViewModel is clicked
        /// </summary>
        private void OnAdd()
        {

            ProfileInfo userInfo = new ProfileInfo();
            userInfo.setFirstName(FirstName);
            userInfo.setLastName(LastName);
            userInfo.setEmail(Email);
            userInfo.setPhone(Phone);
            userInfo.setFax(Fax);
            userInfo.setWebsite(Website);
            userInfo.setId(SupplierUserID);

            SupplierInfo supplierInfo = new SupplierInfo();
            supplierInfo.setProfileInfo(userInfo);
            supplierInfo.setRemarks(Remark);
            SupplierManager supplierManager = new SupplierManager();
            supplierManager.createSupplier(supplierInfo);


            MessageBox.Show("Save Successfully.");
        }


        /// <summary>
        /// Called when Button SendToViewModel is clicked
        /// </summary>
        private void OnReset()
        {
            MessageBox.Show("OnReset");
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
    }
}
