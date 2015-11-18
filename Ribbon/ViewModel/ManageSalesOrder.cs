using com.inventory.bean;
using com.inventory.db;
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
    class ManageSalesOrder : BindableBase, INotifyPropertyChanged
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
                        Customername = FirstName + " " + LastName;
                        handler(this, new PropertyChangedEventArgs("Name"));
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

        ObservableCollection<ProductInfoNJ> _saleList;

        public ObservableCollection<ProductInfoNJ> SaleList
        {
            get
            {
                if (_saleList == null || _saleList.Count <= 0) {
                    _saleList = new ObservableCollection<ProductInfoNJ>();
                }
                return _saleList;
                
            }
            set
            {
                this._saleList = value;
            }
        }
        
        private string _lName;
        public string LastName
        {
            get
            {
                return this._lName;
                OnPropertyChanged();
            }
            set
            {
                this._lName = value;
            }
        }

        private string _customerName;
        public string Customername
        {
            get
            {
                return this._fName + " " + this._lName;
            }
            set
            {
                this._customerName = value;
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


        private string _salesRep;
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

        private string _saleOrderDate;
         public string SaleOrderDate
        {
            get
            {
                return this._saleOrderDate;
            }
            set
            {
                this._saleOrderDate = value;
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



        /*  ------------ Sale Order ----------------------*/

        private string _nonCustomerCost;
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

        private string _taxingScheme;
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

        private string _pricing;
        public string Pricing
        {
            get
            {
                return this._pricing;
            }
            set
            {
                this._pricing = value;
            }
        }

        private string _salesOrderSubTotal;
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


        private string _salesOrderTotal;
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

        //private string _orderItem;
        //public string OrderItem
        //{
        //    get
        //    {
        //        return this._orderItem;
        //    }
        //    set
        //    {
        //        this._orderItem = value;
        //    }
        //}

        //private string _orderItemQuantity;
        //public string OrderItemQuantity
        //{
        //    get
        //    {
        //        return this._orderItemQuantity;
        //    }
        //    set
        //    {
        //        this._orderItemQuantity = value;
        //    }
        //}

        //private string _orderItemUnitPrice;
        //public string OrderItemUnitPrice
        //{
        //    get
        //    {
        //        return this._orderItemUnitPrice;
        //    }
        //    set
        //    {
        //        this._orderItemUnitPrice = value;
        //    }
        //}

        //private string _orderItemDiscount;
        //public string OrderItemDiscount
        //{
        //    get
        //    {
        //        return this._orderItemDiscount;
        //    }
        //    set
        //    {
        //        this._orderItemDiscount = value;
        //    }
        //}

        //private string _orderItemSubTotal;
        //public string OrderItemSubTotal
        //{
        //    get
        //    {
        //        return this._orderItemSubTotal;
        //    }
        //    set
        //    {
        //        this._orderItemSubTotal = value;
        //    }
        //}





        /*  ------------ Invoice Sale Order ----------------------*/

        private string _salesOrderInvoiceRemark;
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


        private string _salesOrderInvoiceSubTotal;
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

        private string _salesOrderInvoiceTotal;
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


        private string _salesOrderInvoicePaid;
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


        private string _salesOrderInvoiceBalance;
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


        /*  ------------ Pick Sale Order ----------------------*/

        private string _salesOrderPickRemark;
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


        private string _pickOrderedQuantity;
        public string PickOrderedQuantity
        {
            get
            {
                return this._pickOrderedQuantity;
            }
            set
            {
                this._pickOrderedQuantity = value;
            }
        }


        private string _pickedQuantity;
        public string PickedQuantity
        {
            get
            {
                return this._pickedQuantity;
            }
            set
            {
                this._pickedQuantity = value;
            }
        }

        /*  ------------ Restock Sale Order ----------------------*/


        private string _salesOrderRestockRemark;
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


        /*  ------------ Return Sale Order ----------------------*/

        private string _salesOrderReturnRemark;
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

        private string _salesOrderReturnSubTotalAmount;
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


        private string _salesOrderReturnTotalAmount;
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

        private string _salesOrderReturnFreeAmount;
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

        private string _salesOrderReturnRefundedAmount;
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

        private string _salesOrderReturnCreditAmount;
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



        /// <summary>
        /// Called when Button SendToViewModel is clicked
        /// </summary>
        private void OnAdd()
        {

            ProductInfo productInfo = new ProductInfo();
            productInfo.setUnitPrice(1000);
            productInfo.setQuantity(10);
            productInfo.setDiscount(3);
            productInfo.setPurchaseOrderNo("007");

            java.util.List productList = new java.util.ArrayList();
            productList.add(productInfo);

            SaleInfo saleInfo = new SaleInfo();
            saleInfo.setProductList(productList);
            saleInfo.setOrderNo("o2");
            saleInfo.setStatusId(5);
            saleInfo.setRemarks("remarks2");
            
            //Date d = new Date();
            //long milliseconds = d.getTime();
            //saleInfo.setSaleDate(milliseconds);

            

            SaleManager saleManager = new SaleManager();
            saleManager.addSaleOrder(saleInfo);

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

