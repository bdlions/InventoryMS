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
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Ribbon.ViewModel
{
    class ManageCustomer : BindableBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private string _fName;
        public string CustomerFirstName
        {
            get
            {
                return this._fName;
            }
            set
            {
                this._fName = value;
                OnPropertyChanged("CustomerName");
            }
        }

        private string _lName;
        public string CustomerLastName
        {
            get
            {
                return this._lName;

            }
            set
            {
                this._lName = value;
                OnPropertyChanged("CustomerName");
            }
        }

        private string _name;
        public string CustomerName
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

        private double _balance;
        public double CustomerBalance
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

        private string _phone;
        public string CustomerPhone
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
        public string CustomerFax
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
        public string CustomerEmail
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
        public string CustomerWebsite
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

        private string _discount;
        public string CustomerDiscount
        {
            get
            {
                return this._discount;
            }
            set
            {
                this._discount = value;
            }
        }

        private string _taxExempt;
        public string CustomerTaxExempt
        {
            get
            {
                return this._taxExempt;
            }
            set
            {
                this._taxExempt = value;
            }
        }

        private string _remark;
        public string CustomerRemark
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

        private string _cardNumber;
        public string CustomerCardNumber
        {
            get
            {
                return this._cardNumber;
            }
            set
            {
                this._cardNumber = value;
            }
        }

        private string _cardSecurityCode;
        public string CustomerCardSecurityCode
        {
            get
            {
                return this._cardSecurityCode;
            }
            set
            {
                this._cardSecurityCode = value;
            }
        }


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

        public ICommand Email
        {
            get
            {
                return new DelegateCommand(this.OnEmail);
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
            userInfo.setFirstName(CustomerFirstName);
            userInfo.setLastName(CustomerLastName);
            userInfo.setEmail(CustomerEmail);
            userInfo.setPhone(CustomerPhone);
            userInfo.setFax(CustomerFax);
            userInfo.setWebsite(CustomerWebsite);

            

            CustomerInfo customerInfo = new CustomerInfo();
            customerInfo.setUserInfo(userInfo);

            CustomerManager customerManager = new CustomerManager();
            customerManager.createCustomer(customerInfo);





            MessageBox.Show("Save Successfully");
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
        private void OnEmail()
        {
            MessageBox.Show("OnEmail");
        }
    }
}

