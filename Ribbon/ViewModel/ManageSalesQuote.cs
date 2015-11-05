using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Ribbon.ViewModel
{
    class ManageSalesQuote : BindableBase
    {
        private string _customername = "Nazmul Islam";
        public string Customername
        {
            get
            {
                return this._customername;
            }
            set
            {
                this._customername = value;
            }
        }

        private string _contact = "01912314466";
        public string Contact
        {
            get
            {
                return this._contact;
            }
            set
            {
                this._contact = value;
            }
        }

        private string _phone = "7286564";
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

        private string _address = "Meradia";
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

       
        private string _salesRep = "Unknown";
        public string SalesRep
        {
            get
            {
                return this._salesRep;
            }
            set
            {
                this._salesRep = value;
            }
        }

        private string _location = "Rampura";
        public string Location
        {
            get
            {
                return this._location;
            }
            set
            {
                this._location = value;
            }
        }

        private string _quote = "1";
        public string Quote
        {
            get
            {
                return this._quote;
            }
            set
            {
                this._quote = value;
            }
        }

        private string _status = "Active";
        public string Status
        {
            get
            {
                return this._status;
            }
            set
            {
                this._status = value;
            }
        }

        private string _taxingScheme = "Sales Quote Tax Scheme";
        public string TaxingScheme
        {
            get
            {
                return this._taxingScheme;
            }
            set
            {
                this._taxingScheme = value;
            }
        }


        private string _pricingCurrency = "Tk";
        public string PricingCurrency
        {
            get
            {
                return this._pricingCurrency;
            }
            set
            {
                this._pricingCurrency = value;
            }
        }

        private string _remark = "Sales Quote Remark";
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

        private string _subTotal = "Tk. 1000000000000";
        public string SubTotal
        {
            get
            {
                return this._subTotal;
            }
            set
            {
                this._subTotal = value;
            }
        }

        private string _total = "Tk. 2000000000000";
        public string Total
        {
            get
            {
                return this._total;
            }
            set
            {
                this._total = value;
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
            MessageBox.Show("OnAdd: \n" + "Customer Name: " + this._customername + "\n Contact: " + _contact + "\n Phone: " + _phone + "\n Address: " + _address + "\n Sales Rep: " + _salesRep + "\n Location: " + _location + "\n Quote: " + _quote + "\n Status: " + _status);
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
