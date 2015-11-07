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
    class ManageCustomer : BindableBase
    {
        private string _customername = "Rahsida Sultana";
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

        private double _balance = 0.0;
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


        private string _address = "Niketon";
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

        private string _phone = "0291556548";
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

        private string _fax = "+88-0000-4444";
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

        private string _email = "rashida@gmail.com";
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

        private string _website = "www.rashida.com";
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

        private string _discount = "Tk. 5.0 %";
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

        private string _taxExempt = "Tk. 1000000000000";
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

        private string _remark = "Very good Customer";
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

        private string _cardNumber = "1";
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

        private string _cardSecurityCode = "James Bond 007";
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
            MessageBox.Show("OnAdd: \n" + "Customer Name: " + this._customername + "\nBalance: " + _balance);
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

