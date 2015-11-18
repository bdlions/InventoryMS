using com.inventory.bean;
using com.inventory.db;
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
    class ManagePurchaseOrder : BindableBase
    {
        private string _supplierFirstName;
        public string SupplierFirstName
        {
            get
            {
                return this._supplierFirstName;
            }
            set
            {
                this._supplierFirstName = value;
            }
        }

        private string _supplierLastName;
        public string SupplierLastName
        {
            get
            {
                return this._supplierLastName;
            }
            set
            {
                this._supplierLastName = value;
            }
        }

        private string _contact;
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


        private string _location;
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


        


        private string _order;
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

        private string _status;
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


        /* Purchase Order */

        private string _nonSupplierCost;
        public string NonSupplierCost
        {
            get
            {
                return this._nonSupplierCost;
            }
            set
            {
                this._nonSupplierCost = value;
            }
        }

        private string _orderRemark;
        public string OrderRemark
        {
            get
            {
                return this._orderRemark;
            }
            set
            {
                this._orderRemark = value;
            }
        }


        private string _receiveRemark;
        public string ReceiveRemark
        {
            get
            {
                return this._receiveRemark;
            }
            set
            {
                this._receiveRemark = value;
            }
        }

        private string _paymentRemark;
        public string PaymentRemark
        {
            get
            {
                return this._paymentRemark;
            }
            set
            {
                this._paymentRemark = value;
            }
        }

        private string _returnRemark;
        public string ReturnRemark
        {
            get
            {
                return this._returnRemark;
            }
            set
            {
                this._returnRemark = value;
            }
        }

        private string _unstockRemark;
        public string UnstockRemark
        {
            get
            {
                return this._unstockRemark;
            }
            set
            {
                this._unstockRemark = value;
            }
        }

        private string _orderSubTotal;
        public string OrderSubTotalAmount
        {
            get
            {
                return this._orderSubTotal;
            }
            set
            {
                this._orderSubTotal = value;
            }
        }

        private string _orderTotal;
        public string OrderTotalAmount
        {
            get
            {
                return this._orderTotal;
            }
            set
            {
                this._orderTotal = value;
            }
        }

        private string _totalOrdered;
        public string TotalOrderedQuantity
        {
            get
            {
                return this._totalOrdered;
            }
            set
            {
                this._totalOrdered = value;
            }
        }

        private string _totalReceived;
        public string TotalReceivedQuantity
        {
            get
            {
                return this._totalReceived;
            }
            set
            {
                this._totalReceived = value;
            }
        }

        private string _paymentSubTotalAmount;
        public string PaymentSubTotalAmount
        {
            get
            {
                return this._paymentSubTotalAmount;
            }
            set
            {
                this._paymentSubTotalAmount = value;
            }
        }

        private string _paymentTotalAmount;
        public string PaymentTotalAmount
        {
            get
            {
                return this._paymentTotalAmount;
            }
            set
            {
                this._paymentTotalAmount = value;
            }
        }


        private string _paymentPaidAmount;
        public string PaymentPaidAmount
        {
            get
            {
                return this._paymentPaidAmount;
            }
            set
            {
                this._paymentPaidAmount = value;
            }
        }

        private string _paymentBalanceAmount;
        public string PaymentBalanceAmount
        {
            get
            {
                return this._paymentBalanceAmount;
            }
            set
            {
                this._paymentBalanceAmount = value;
            }
        }


        private string _returnSubTotalAmount;
        public string ReturnSubTotalAmount
        {
            get
            {
                return this._returnSubTotalAmount;
            }
            set
            {
                this._returnSubTotalAmount = value;
            }
        }

        private string _returnTotalAmount;
        public string ReturnTotalAmount
        {
            get
            {
                return this._returnTotalAmount;
            }
            set
            {
                this._returnTotalAmount = value;
            }
        }


        private string _returnFeeAmount;
        public string ReturnFeeAmount
        {
            get
            {
                return this._returnFeeAmount;
            }
            set
            {
                this._returnFeeAmount = value;
            }
        }

        private string _returnRefundedAmount;
        public string ReturnRefundedAmount
        {
            get
            {
                return this._returnRefundedAmount;
            }
            set
            {
                this._returnRefundedAmount = value;
            }
        }

        private string _returnCreditAmount;
        public string ReturnCreditAmount
        {
            get
            {
                return this._returnCreditAmount;
            }
            set
            {
                this._returnCreditAmount = value;
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

          ProductInfo productInfo = new ProductInfo();
          productInfo.setId(1);
          productInfo.setQuantity(500);
          productInfo.setDiscount(0);

          java.util.List productList = new java.util.ArrayList();
          productList.add(productInfo);
          
          PurchaseInfo purchaseInfo = new PurchaseInfo();
          purchaseInfo.setProductList(productList);
          purchaseInfo.setSupplierUserId(3218648);
          purchaseInfo.setOrderNo(Order);
          purchaseInfo.setStatusId(1);
          purchaseInfo.setRemarks(OrderRemark);
          purchaseInfo.setOrderDate(150);
          purchaseInfo.setRequestShippedDate(566);

          PurchaseManager purchaseManager = new PurchaseManager();
          purchaseManager.addPurchaseOrder(purchaseInfo);
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

