using com.inventory.bean;
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
    class ManageCustomer : BindableBase, INotifyPropertyChanged
    {
         //constructor
        public ManageCustomer()
        {
            //loading customer list on left panel
            CustomerManager customerManager = new CustomerManager();
            for (Iterator i = customerManager.getAllCustomers().iterator(); i.hasNext(); )
            {
                CustomerInfo customerInfo = (CustomerInfo)i.next();
                CustomerInfoNJ customerInfoNJ = new CustomerInfoNJ();

                customerInfoNJ.CustomerUserId = customerInfo.getProfileInfo().getId();
                customerInfoNJ.CustomerFirstName = customerInfo.getProfileInfo().getFirstName();
                customerInfoNJ.CustomerLastName = customerInfo.getProfileInfo().getLastName();
                customerInfoNJ.Phone = customerInfo.getProfileInfo().getPhone();
                customerInfoNJ.Fax = customerInfo.getProfileInfo().getFax();
                customerInfoNJ.Email = customerInfo.getProfileInfo().getEmail();
                customerInfoNJ.Website = customerInfo.getProfileInfo().getWebsite();

                CustomerList.Add(customerInfoNJ);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

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
                    if (propertyName.ToLower().Equals("customerfirstname") || propertyName.ToLower().Equals("customerlastname"))
                    {
                        CustomerName = CustomerFirstName + " " + CustomerLastName;
                        handler(this, new PropertyChangedEventArgs("CustomerName"));
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

        private int _customerUserId;
        public int CustomerUserId
        {
            get
            {
                return this._customerUserId;
            }
            set
            {
                this._customerUserId = value;
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
                OnPropertyChanged();
                OnPropertyChanged_1();
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
                OnPropertyChanged();
                OnPropertyChanged_1();
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
                OnPropertyChanged();
                OnPropertyChanged_1("CustomerName");
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
                OnPropertyChanged("CustomerBalance");
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
                OnPropertyChanged("Address");
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
                OnPropertyChanged("CustomerPhone");
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
                OnPropertyChanged("CustomerFax");
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
                OnPropertyChanged("CustomerEmail");
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
                OnPropertyChanged("CustomerWebsite");
            }
        }

        private string _discount;
        public string Discount
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
        public string TaxExempt
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

        private string _cardNumber;
        public string CardNumber
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
        public string CardSecurityCode
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

        // Search Customer panel
        private string _searchCustomerPhone;
        public string SearchCustomerPhone
        {
            get
            {
                return this._searchCustomerPhone;
            }
            set
            {
                this._searchCustomerPhone = value;
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

        public ICommand Emailing
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
        public ICommand SelectCustomerEvent
        {
            get
            {
                return new DelegateCommand<CustomerInfoNJ>(this.selectCustomerEvent);
            }
        }

        /// <summary>
        /// Called when Button SendToViewModel is clicked
        /// </summary>
        private void OnAdd()
        {
            if (!ValidateCustomer())
            {
                MessageBox.Show(ErrorMessage);
                return;
            }
            ProfileInfo profileInfo = new ProfileInfo();
            profileInfo.setId(CustomerUserId);
            profileInfo.setFirstName(CustomerFirstName);
            profileInfo.setLastName(CustomerLastName);
            profileInfo.setEmail(Email);
            profileInfo.setPhone(Phone);
            profileInfo.setFax(Fax);
            profileInfo.setWebsite(Website);

            CustomerInfo customerInfo = new CustomerInfo();
            customerInfo.setProfileInfo(profileInfo);
            CustomerManager customerManager = new CustomerManager();

            ResultEvent resultEvent = new ResultEvent();

            CustomerInfoNJ customerInfoNJ = new CustomerInfoNJ();
            customerInfoNJ.CustomerUserId = CustomerUserId;
            customerInfoNJ.CustomerFirstName = CustomerFirstName;
            customerInfoNJ.CustomerLastName = CustomerLastName;
            customerInfoNJ.CustomerName = CustomerName;
            customerInfoNJ.Email = Email;
            customerInfoNJ.Phone = Phone;
            customerInfoNJ.Fax = Fax;
            customerInfoNJ.Website = Website;

            if (CustomerUserId > 0)
            {
                resultEvent = customerManager.updateCustomer(customerInfo);                
            }
            else
            {
                resultEvent = customerManager.createCustomer(customerInfo);
                //reset create Customer fields
                OnReset();
            }
            if (resultEvent.getResponseCode() == 2000)
            {
                if (CustomerUserId > 0)
                {
                    for (int counter = 0; counter < CustomerList.Count; counter++)
                    {
                        CustomerInfoNJ tempCustomerInfoNJ = CustomerList.ElementAt(counter);

                        if (tempCustomerInfoNJ.CustomerUserId == CustomerUserId)
                        {
                            CustomerList.RemoveAt(counter);
                            CustomerList.Insert(counter, customerInfoNJ);
                        }
                    }
                }
                else 
                {
                    if (CustomerList.Count == 0)
                    {
                        CustomerList.Add(customerInfoNJ);
                    }
                    else 
                    {
                        CustomerList.Insert(0, customerInfoNJ);
                    }
                }

            }

            MessageBox.Show(resultEvent.getMessage());
        }





        /// <summary>
        /// Called when Button SendToViewModel is clicked
        /// </summary>
        private void OnReset()
        {
            this.CustomerFirstName = "";
            this.CustomerLastName = "";
            this.Email = "";
            this.Phone = "";
            this.Fax = "";
            this.Website = "";
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

        public ICommand Search
        {
            get
            {
                return new DelegateCommand(this.OnSearch);
            }
        }

        private void OnSearch()
        {

            CustomerManager customerManager = new CustomerManager();

            _customerList.Clear();
            for (Iterator i = customerManager.searchCustomers(SearchCustomerPhone).iterator(); i.hasNext(); )
            {
                CustomerInfo customerInfo = (CustomerInfo)i.next();
                CustomerInfoNJ customerInfoNJ = new CustomerInfoNJ();

                customerInfoNJ.CustomerUserId = customerInfo.getProfileInfo().getId();
                customerInfoNJ.CustomerFirstName = customerInfo.getProfileInfo().getFirstName();
                customerInfoNJ.CustomerLastName = customerInfo.getProfileInfo().getLastName();
                customerInfoNJ.Phone = customerInfo.getProfileInfo().getPhone();
                customerInfoNJ.Fax = customerInfo.getProfileInfo().getFax();
                customerInfoNJ.Email = customerInfo.getProfileInfo().getEmail();
                customerInfoNJ.Website = customerInfo.getProfileInfo().getWebsite();

                _customerList.Add(customerInfoNJ);
            }
        }


        public void selectCustomerEvent(CustomerInfoNJ c)
        {
            this.CustomerUserId = c.CustomerUserId;
            this.CustomerFirstName = c.CustomerFirstName;
            this.CustomerLastName = c.CustomerLastName;
            this.CustomerName = c.CustomerName;
            this.Phone = c.Phone;
            this.Fax = c.Fax;
            this.Email = c.Email;
            this.Website = c.Website;
        }
        public Boolean ValidateCustomer()
        {
            if (CustomerFirstName == null)
            {
                ErrorMessage = "Customer first name is required.";
                return false;
            }
            if (CustomerLastName == null)
            {
                ErrorMessage = "Customer Last name is required.";
                return false;
            }

            return true;
        }
    }
}

