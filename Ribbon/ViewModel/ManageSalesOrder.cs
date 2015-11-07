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
    class ManageSalesOrder:BindableBase
    {
        private string _customername = "Shobuj Gope";
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

        private string _contact = "01729331182";
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

        private string _phone = "N/A";
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

        private string _address = "Azimpur";
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

        private string _location = "Dhaka";
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


        private string _order = "1";
        public string Order
        {
            get
            {
                return this._order;
            }
            set
            {
                this._order = value;
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

        private string _nonCustomerCost = "Tk. 5000";
        public string NonCustomerCost
        {
            get
            {
                return this._nonCustomerCost;
            }
            set
            {
                this._nonCustomerCost = value;
            }
        }

        private string _taxingScheme = "Sales Order Tax Scheme";
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

        private string _salesOrderPickRemark = "Sales Order Pick Remark";
        public string SalesOrderPickRemark
        {
            get
            {
                return this._salesOrderPickRemark;
            }
            set
            {
                this._salesOrderPickRemark = value;
            }
        }

        private string _salesOrderInvoiceRemark = "Sales Order Invoice Remark";
        public string SalesOrderInvoiceRemark
        {
            get
            {
                return this._salesOrderInvoiceRemark;
            }
            set
            {
                this._salesOrderInvoiceRemark = value;
            }
        }

        private string _salesOrderReturnRemark = "Sales Order Return Remark";
        public string SalesOrderReturnRemark
        {
            get
            {
                return this._salesOrderReturnRemark;
            }
            set
            {
                this._salesOrderReturnRemark = value;
            }
        }


        private string _salesOrderRestockRemark = "Sales Order Restock Remark";
        public string SalesOrderRestockRemark
        {
            get
            {
                return this._salesOrderRestockRemark;
            }
            set
            {
                this._salesOrderRestockRemark = value;
            }
        }


        private string _salesOrderRemark = "Sales Order Remark";
        public string SalesOrderRemark
        {
            get
            {
                return this._salesOrderRemark;
            }
            set
            {
                this._salesOrderRemark = value;
            }
        }

        private string _salesOrderSubTotal = "Tk. 1000999003330";
        public string SalesOrderSubTotal
        {
            get
            {
                return this._salesOrderSubTotal;
            }
            set
            {
                this._salesOrderSubTotal = value;
            }
        }

        private string _salesOrderTotal = "Tk. 2008880002220";
        public string SalesOrderTotal
        {
            get
            {
                return this._salesOrderTotal;
            }
            set
            {
                this._salesOrderTotal = value;
            }
        }

        private string _orderQuantiry = "250";
        public string OrderQuantiry
        {
            get
            {
                return this._orderQuantiry;
            }
            set
            {
                this._orderQuantiry = value;
            }
        }

        private string _pickedQuantiry = "120";
        public string PickedQuantiry
        {
            get
            {
                return this._pickedQuantiry;
            }
            set
            {
                this._pickedQuantiry = value;
            }
        }

        private string _salesOrderInvoiceSubTotal = "Tk. 1000999003330";
        public string SalesOrderInvoiceSubTotal
        {
            get
            {
                return this._salesOrderInvoiceSubTotal;
            }
            set
            {
                this._salesOrderInvoiceSubTotal = value;
            }
        }

        private string _salesOrderInvoiceTotal = "Tk. 2777999003330";
        public string SalesOrderInvoiceTotal
        {
            get
            {
                return this._salesOrderInvoiceTotal;
            }
            set
            {
                this._salesOrderInvoiceTotal = value;
            }
        }

        private string _salesOrderInvoicePaid = "Tk. 2555999003330";
        public string SalesOrderInvoicePaid
        {
            get
            {
                return this._salesOrderInvoicePaid;
            }
            set
            {
                this._salesOrderInvoicePaid = value;
            }
        }

        private string _salesOrderInvoiceBalance = "Tk. 1444999003330";
        public string SalesOrderInvoiceBalance
        {
            get
            {
                return this._salesOrderInvoiceBalance;
            }
            set
            {
                this._salesOrderInvoiceBalance = value;
            }
        }

        private string _salesOrderReturnSubTotalAmount = "Tk. 1000999003330";
        public string SalesOrderReturnSubTotalAmount
        {
            get
            {
                return this._salesOrderReturnSubTotalAmount;
            }
            set
            {
                this._salesOrderReturnSubTotalAmount = value;
            }
        }

        private string _salesOrderReturnTotalAmount = "Tk. 2000999003330";
        public string SalesOrderReturnTotalAmount
        {
            get
            {
                return this._salesOrderReturnTotalAmount;
            }
            set
            {
                this._salesOrderReturnTotalAmount = value;
            }
        }

        private string _salesOrderReturnFreeAmount = "Tk. 0000000000000";
        public string SalesOrderReturnFreeAmount
        {
            get
            {
                return this._salesOrderReturnFreeAmount;
            }
            set
            {
                this._salesOrderReturnFreeAmount = value;
            }
        }

        private string _salesOrderReturnRefundedAmount = "Tk. 0000999003330";
        public string SalesOrderReturnRefundedAmount
        {
            get
            {
                return this._salesOrderReturnRefundedAmount;
            }
            set
            {
                this._salesOrderReturnRefundedAmount = value;
            }
        }

        private string _salesOrderReturnCreditAmount = "Tk. 3000999003330";
        public string SalesOrderReturnCreditAmount
        {
            get
            {
                return this._salesOrderReturnCreditAmount;
            }
            set
            {
                this._salesOrderReturnCreditAmount = value;
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
            MessageBox.Show("OnAdd: \n" + "Customer Name: " + this._customername + "\nContact: " + _contact + "\nPhone: " + _phone + "\nAddress: " + _address);
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

