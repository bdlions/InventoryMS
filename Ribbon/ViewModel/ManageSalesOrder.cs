﻿using com.inventory.bean;
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
using System.Windows.Controls;
using System.Windows.Input;

namespace Ribbon.ViewModel
{
    class ManageSalesOrder : BindableBase, INotifyPropertyChanged
    {
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
                OnPropertyChanged("CustomerName");
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

        private int _cusomerUserId;
        public int CusomerUserId
        {
            get
            {
                return this._cusomerUserId;
            }
            set
            {
                this._cusomerUserId = value;
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
                OnPropertyChanged("Phone");
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
                this._order = Guid.NewGuid().ToString().ToUpper();
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


        /*  ------------ Sale Order Item ----------------------*/
        private string _orderItem;
        public string OrderItem
        {
            get
            {
                return this._orderItem;
            }
            set
            {
                this._orderItem = value;
            }
        }

        private string _orderItemCategory;
        public string OrderItemCategory
        {
            get
            {
                return this._orderItem;
            }
            set
            {
                this._orderItemCategory = value;
            }
        }
        private string _orderItemQuantity;
        public string OrderItemQuantity
        {
            get
            {
                return this._orderItemQuantity;
            }
            set
            {
                this._orderItemQuantity = value;
            }
        }

        private long _orderItemUnitPrice;
        public long OrderItemUnitPrice
        {
            get
            {
                return this._orderItemUnitPrice;
            }
            set
            {
                this._orderItemUnitPrice = value;
            }
        }

        private string _orderItemDiscount;
        public string OrderItemDiscount
        {
            get
            {
                return this._orderItemDiscount;
            }
            set
            {
                this._orderItemDiscount = value;
            }
        }

        private string _orderItemSubTotal;
        public string OrderItemSubTotal
        {
            get
            {
                return this._orderItemSubTotal;
            }
            set
            {
                this._orderItemSubTotal = value;
            }
        }





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
            productInfo.setUnitPrice(productInfo.getUnitPrice());
            productInfo.setQuantity(productInfo.getQuantity());
            productInfo.setDiscount(productInfo.getDiscount());
            productInfo.setPurchaseOrderNo(productInfo.getPurchaseOrderNo());

            List productList = new ArrayList();
            productList.add(productInfo);

            SaleInfo saleInfo = new SaleInfo();
            CustomerInfo customerInfo = new CustomerInfo();
            saleInfo.setProductList(productList);
            saleInfo.setCustomerUserId(customerInfo.getUserInfo().getId());
            saleInfo.setOrderNo(saleInfo.getOrderNo());
            saleInfo.setStatusId(saleInfo.getStatusId());
            saleInfo.setRemarks(saleInfo.getRemarks());

            SaleManager saleManager = new SaleManager();
            saleManager.addSaleOrder(saleInfo);

            MessageBox.Show("Save Successfully");
        }


       

        public DelegateCommand<object> OnItemSelected
        {
            get
            {
                return new DelegateCommand<object>((selectedItem) =>
                {
                    SaleList.Insert(SaleList.Count - 1, (ProductInfoNJ)selectedItem);
                    SaleList.RemoveAt(SaleList.Count - 1);
                });
            }
        }


        public ICommand SaveSale
        {
            get
            {
                return new DelegateCommand(new Action(() =>
                {

                    java.util.List productList = new java.util.ArrayList();

                    foreach (ProductInfoNJ productInfoNJ in SaleList)
                    {
                        ProductInfo productInfo = new ProductInfo();
                        productInfo.setName(productInfoNJ.Name);
                        productInfo.setCode(productInfoNJ.Code);
                        productInfo.setUnitPrice(productInfoNJ.Price);
                        productInfo.setQuantity(productInfoNJ.Quantity);
                        productInfo.setDiscount(productInfoNJ.Discount);
                        productInfo.setId(productInfoNJ.ProductId);

                        productList.add(productInfo);
                    }


                    SaleInfo saleInfo = new SaleInfo();
                    saleInfo.setProductList(productList);
                    saleInfo.setCustomerUserId(5905093);
                    saleInfo.setOrderNo(Order);
                    saleInfo.setStatusId(1);
                    saleInfo.setRemarks(OrderRemark);
                    //purchaseInfo.setOrderDate(123);
                    //saleInfo.setRequestShippedDate(456);

                    SaleManager saleManager = new SaleManager();
                    saleManager.addSaleOrder(saleInfo);
                    MessageBox.Show("Save Successfully");
                }));
            }
        }

        public DelegateCommand<object> OnCustomerSelected
        {
            get
            {
                return new DelegateCommand<object>((SelectedCustomer) =>
                {


                    CustomerInfoNJ customerInfoNJ = (CustomerInfoNJ)SelectedCustomer;

                    CustomerFirstName = customerInfoNJ.CustomerFirstName;
                    CustomerLastName = customerInfoNJ.CustomerLastName;
                    
                    Phone = customerInfoNJ.Phone;
                    //SupplierFirstName = supplierInfo.SupplierFirstName;
                    //SupplierLastName = supplierInfo.SupplierLastName;
                    

                  

                });
            }
        }


        ObservableCollection<ProductInfoNJ> _saleList;

        public ObservableCollection<ProductInfoNJ> SaleList
        {
            get
            {
                if (_saleList == null || _saleList.Count <= 0)
                {
                    _saleList = new ObservableCollection<ProductInfoNJ>();


                    ProductInfo productInfo = new ProductInfo();
                    ProductInfoNJ productInfoNJ = new ProductInfoNJ();
                    productInfoNJ.Price = productInfo.getUnitPrice();
                    productInfoNJ.Quantity = productInfo.getQuantity();
                    productInfoNJ.Discount = productInfo.getDiscount();
                    productInfoNJ.ProductId = productInfo.getId();

                    CustomerInfo customerInfo = new CustomerInfo();
                    CustomerInfoNJ customerInfoNJ = new CustomerInfoNJ();

                    customerInfoNJ.CustomerFirstName = customerInfo.getUserInfo().getFirstName();
                    customerInfoNJ.CustomerLastName = customerInfo.getUserInfo().getLastName();
                }
                return _saleList;

            }
            set
            {
                this._saleList = value;
            }
        }



        ObservableCollection<CustomerInfoNJ> _customerItemList;

        public ObservableCollection<CustomerInfoNJ> CustomerItemList
        {
            get
            {
                CustomerManager supplierManager = new CustomerManager();

                _customerItemList = new ObservableCollection<CustomerInfoNJ>();
                for (Iterator i = supplierManager.getAllCustomers().iterator(); i.hasNext(); )
                {
                    CustomerInfo customerInfo = (CustomerInfo)i.next();
                    CustomerInfoNJ customerInfoNJ = new CustomerInfoNJ();

                    customerInfoNJ.CustomerFirstName = customerInfo.getUserInfo().getFirstName();
                    customerInfoNJ.CustomerLastName = customerInfo.getUserInfo().getLastName();
                    customerInfoNJ.Phone = customerInfo.getUserInfo().getPhone();
                    customerInfoNJ.CusomerUserId = customerInfo.getUserInfo().getId();


                    _customerItemList.Add(customerInfoNJ);
                }
                return _customerItemList;
            }
            set
            {
                this._customerItemList = value;
            }
        }


        ObservableCollection<CustomerInfoNJ> _customerList;

        public ObservableCollection<CustomerInfoNJ> CustomerList
        {
            get
            {
                if (_customerList == null || _customerList.Count <= 0)
                {
                    _customerList = new ObservableCollection<CustomerInfoNJ>();

                    CustomerInfo customerInfo = new CustomerInfo();
                    CustomerInfoNJ customerInfoNJ = new CustomerInfoNJ();

                    customerInfoNJ.CustomerFirstName = customerInfo.getUserInfo().getFirstName();
                    customerInfoNJ.CustomerLastName = customerInfo.getUserInfo().getLastName();
                    customerInfoNJ.Phone = customerInfo.getUserInfo().getPhone();
                    customerInfoNJ.CusomerUserId = customerInfo.getUserInfo().getId();

                    
                }
                return _customerList;

            }
            set
            {
                this._customerList = value;
            }
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

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler(this, new PropertyChangedEventArgs(propertyName));

        }

    }
}

