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

    class ManageSupplier : BindableBase, INotifyPropertyChanged
    {
        //constructor
        public ManageSupplier()
        {
            //loading supplier list on left panel
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
                SupplierList.Add(supplierInfoNJ);
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
                OnPropertyChanged("SupplierInfoNJ");
            }
        }

        //validation error message
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
         * This method will validate supplier info
         * @author nazmul hasan on 5th january 2016
         */
        public Boolean ValidateSupplier()
        {
            if (SupplierInfoNJ.ProfileInfoNJ.FirstName == null)
            {
                ErrorMessage = Messages.ERROR_PROFILE_FIRST_NAME_REQUIRED;
                return false;
            }
            return true;
        }

        /*
         * Event Handler to add/update supplier
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
         * This method will add/update a supplier
         * @author nazmul hasan on 5th january 2016
         */
        private void OnAdd()
        {
            if (!ValidateSupplier())
            {
                MessageBox.Show(ErrorMessage);
                return;
            }
            ProfileInfo profileInfo = new ProfileInfo();
            profileInfo.setId(SupplierInfoNJ.ProfileInfoNJ.Id);
            profileInfo.setFirstName(SupplierInfoNJ.ProfileInfoNJ.FirstName);
            profileInfo.setLastName(SupplierInfoNJ.ProfileInfoNJ.LastName);
            profileInfo.setEmail(SupplierInfoNJ.ProfileInfoNJ.Email);
            profileInfo.setPhone(SupplierInfoNJ.ProfileInfoNJ.Phone);
            profileInfo.setFax(SupplierInfoNJ.ProfileInfoNJ.Fax);
            profileInfo.setWebsite(SupplierInfoNJ.ProfileInfoNJ.Website);
            SupplierInfo supplierInfo = new SupplierInfo();
            supplierInfo.setProfileInfo(profileInfo);
            SupplierManager supplierManager = new SupplierManager();            

            SupplierInfoNJ supplierInfoNJ = new SupplierInfoNJ();
            supplierInfoNJ.ProfileInfoNJ.Id = SupplierInfoNJ.ProfileInfoNJ.Id;
            supplierInfoNJ.ProfileInfoNJ.FirstName = SupplierInfoNJ.ProfileInfoNJ.FirstName;
            supplierInfoNJ.ProfileInfoNJ.LastName = SupplierInfoNJ.ProfileInfoNJ.LastName;
            supplierInfoNJ.ProfileInfoNJ.Email = SupplierInfoNJ.ProfileInfoNJ.Email;
            supplierInfoNJ.ProfileInfoNJ.Phone = SupplierInfoNJ.ProfileInfoNJ.Phone;
            supplierInfoNJ.ProfileInfoNJ.Fax = SupplierInfoNJ.ProfileInfoNJ.Fax;
            supplierInfoNJ.ProfileInfoNJ.Website = SupplierInfoNJ.ProfileInfoNJ.Website;

            ResultEvent resultEvent = new ResultEvent();
            if (SupplierInfoNJ.ProfileInfoNJ.Id > 0)
            {
                resultEvent = supplierManager.updateSupplier(supplierInfo);
            }
            else
            {
                resultEvent = supplierManager.createSupplier(supplierInfo);
            }
            if (resultEvent.getResponseCode() == Responses.RESPONSE_CODE_SUCCESS)
            {
                if (SupplierInfoNJ.ProfileInfoNJ.Id > 0)
                {
                    for (int counter = 0; counter < SupplierList.Count; counter++)
                    {
                        SupplierInfoNJ tempSupplierInfoNJ = SupplierList.ElementAt(counter);

                        if (tempSupplierInfoNJ.ProfileInfoNJ.Id == SupplierInfoNJ.ProfileInfoNJ.Id)
                        {
                            SupplierList.RemoveAt(counter);
                            SupplierList.Insert(counter, supplierInfoNJ);
                        }
                    }
                }
                else
                {
                    SupplierInfo responseSupplierInfo = (SupplierInfo)resultEvent.getResult();
                    SupplierInfoNJ.ProfileInfoNJ.Id = responseSupplierInfo.getProfileInfo().getId();
                    supplierInfoNJ.ProfileInfoNJ.Id = SupplierInfoNJ.ProfileInfoNJ.Id;
                    if (SupplierList.Count == 0)
                    {
                        SupplierList.Add(supplierInfoNJ);
                    }
                    else
                    {
                        SupplierList.Insert(0, supplierInfoNJ);
                    }
                }
            }
            MessageBox.Show(resultEvent.getMessage());
            //resetting supplier info fields
            OnReset();
        }

        /*
         * Event Handler to reset supplier info
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
         * This method will reset supplier info
         * @author nazmul hasan on 5th january 2016
         */
        private void OnReset()
        {
            SupplierInfoNJ = new SupplierInfoNJ();
        }

        /*
         * Event Handler to select a supplier from left panel
         * @author nazmul hasan on 5th january 2016
         */
        public ICommand SelectSupplierEvent
        {
            get
            {
                return new DelegateCommand<SupplierInfoNJ>(this.OnSelectSupplierEvent);
            }
        }
        /*
         * This method will select a supplier from left panel and update reference of currently selected
         * supplier info
         * @author nazmul hasan on 5th january 2016
         */
        public void OnSelectSupplierEvent(SupplierInfoNJ supplierInfoNJ)
        {
            SupplierInfoNJ = supplierInfoNJ;
        }

        /*
         * Event Handler to searh supplier
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
        * This method will search supplier info
        * @author nazmul hasan on 5th january 2016
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
                SupplierList.Add(supplierInfoNJ);
            }
        }
        
        //-----------------------------------Implement it later ---------------------------------//
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
