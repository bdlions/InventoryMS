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
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
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
                OnPropertyChanged("CustomerInfoNJ");
            }
        }

        //error message
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

        private string _name;
        public string CustomerName
        {
            get
            {
                return CustomerInfoNJ.ProfileInfoNJ.FirstName + " " + CustomerInfoNJ.ProfileInfoNJ.LastName;
            }
            set
            {
                this._name = value;
                OnPropertyChanged("CustomerName");
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

        /*
         * This method will validate customer info
         * @author nazmul hasan on 5th january 2016
         */
        public Boolean ValidateCustomer()
        {
            if (CustomerInfoNJ.ProfileInfoNJ.FirstName == null)
            {
                ErrorMessage = Messages.ERROR_PROFILE_FIRST_NAME_REQUIRED;
                return false;
            }
            return true;
        }
        /*
         * Event Handler to add/update customer
         * @author nazmul hasan on 5th january 2016
         */
        public ICommand Add
        {
            get
            {
                return new DelegateCommand(this.OnAdd);
            }
        }
        /*
         * This method will add/update a customer
         * @author nazmul hasan on 5th january 2016
         */
        private void OnAdd()
        {
            if (!ValidateCustomer())
            {
                MessageBox.Show(ErrorMessage);
                return;
            }
            ProfileInfo profileInfo = new ProfileInfo();
            profileInfo.setId(CustomerInfoNJ.ProfileInfoNJ.Id);
            profileInfo.setFirstName(CustomerInfoNJ.ProfileInfoNJ.FirstName);
            profileInfo.setLastName(CustomerInfoNJ.ProfileInfoNJ.LastName);
            profileInfo.setEmail(CustomerInfoNJ.ProfileInfoNJ.Email);
            profileInfo.setPhone(CustomerInfoNJ.ProfileInfoNJ.Phone);
            profileInfo.setFax(CustomerInfoNJ.ProfileInfoNJ.Fax);
            profileInfo.setWebsite(CustomerInfoNJ.ProfileInfoNJ.Website);
            CustomerInfo customerInfo = new CustomerInfo();
            customerInfo.setProfileInfo(profileInfo);
            CustomerManager customerManager = new CustomerManager();

            CustomerInfoNJ customerInfoNJ = new CustomerInfoNJ();
            customerInfoNJ.ProfileInfoNJ.Id = CustomerInfoNJ.ProfileInfoNJ.Id;
            customerInfoNJ.ProfileInfoNJ.FirstName = CustomerInfoNJ.ProfileInfoNJ.FirstName;
            customerInfoNJ.ProfileInfoNJ.LastName = CustomerInfoNJ.ProfileInfoNJ.LastName;
            customerInfoNJ.ProfileInfoNJ.Email = CustomerInfoNJ.ProfileInfoNJ.Email;
            customerInfoNJ.ProfileInfoNJ.Phone = CustomerInfoNJ.ProfileInfoNJ.Phone;
            customerInfoNJ.ProfileInfoNJ.Fax = CustomerInfoNJ.ProfileInfoNJ.Fax;
            customerInfoNJ.ProfileInfoNJ.Website = CustomerInfoNJ.ProfileInfoNJ.Website;

            ResultEvent resultEvent = new ResultEvent();
            if (CustomerInfoNJ.ProfileInfoNJ.Id > 0)
            {
                resultEvent = customerManager.updateCustomer(customerInfo);
            }
            else
            {
                resultEvent = customerManager.createCustomer(customerInfo);
            }
            if (resultEvent.getResponseCode() == Responses.RESPONSE_CODE_SUCCESS)
            {
                if (CustomerInfoNJ.ProfileInfoNJ.Id > 0)
                {
                    for (int counter = 0; counter < CustomerList.Count; counter++)
                    {
                        CustomerInfoNJ tempCustomerInfoNJ = CustomerList.ElementAt(counter);

                        if (tempCustomerInfoNJ.ProfileInfoNJ.Id == CustomerInfoNJ.ProfileInfoNJ.Id)
                        {
                            CustomerList.RemoveAt(counter);
                            CustomerList.Insert(counter, customerInfoNJ);
                        }
                    }
                }
                else
                {
                    CustomerInfo responseCustomerInfo = (CustomerInfo)resultEvent.getResult();
                    CustomerInfoNJ.ProfileInfoNJ.Id = responseCustomerInfo.getProfileInfo().getId();
                    customerInfoNJ.ProfileInfoNJ.Id = CustomerInfoNJ.ProfileInfoNJ.Id;
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
            //reset create Customer fields
            OnReset();
        }

        /*
         * Event Handler to reset customer info
         * @author nazmul hasan on 5th january 2016
         */
        public ICommand Reset
        {
            get
            {
                return new DelegateCommand(this.OnReset);
            }
        }
        /*
         * This method will reset customer info
         * @author nazmul hasan on 5th january 2016
         */
        private void OnReset()
        {
            CustomerInfoNJ = new CustomerInfoNJ();
        }

        /*
         * Event Handler to select a customer from left panel
         * @author nazmul hasan on 5th january 2016
         */
        public ICommand SelectCustomerEvent
        {
            get
            {
                return new DelegateCommand<CustomerInfoNJ>(this.OnSelectCustomerEvent);
            }
        }
        /*
         * This method will select a customer from left panel and update reference of currently selected
         * customer info
         * @author nazmul hasan on 5th january 2016
         */
        public void OnSelectCustomerEvent(CustomerInfoNJ customerInfoNJ)
        {
            CustomerInfoNJ = customerInfoNJ;
        }

        /*
         * Event Handler to searh customer
         * @author nazmul hasan on 5th january 2016
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
        * @author nazmul hasan on 5th january 2016
        */
        private void OnSearch()
        {
            CustomerManager customerManager = new CustomerManager();
            CustomerList.Clear();
            for (Iterator i = customerManager.searchCustomers(SearchCustomerPhone).iterator(); i.hasNext(); )
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

        //----------------------------------Implement later ------------------------------//
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

