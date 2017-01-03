using com.inventory.bean;
using com.inventory.db;
using com.inventory.db.manager;
using com.inventory.response;
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
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler(this, new PropertyChangedEventArgs(propertyName));

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


        private string _customerFirstName;
        public string CustomerFirstName
        {
            get
            {
                return this._customerFirstName;
            }
            set
            {
                this._customerFirstName = value;
                OnPropertyChanged("CustomerName");
            }
        }

        private string _customerLastName;
        public string CustomerLastName
        {
            get
            {
                return this._customerLastName;

            }
            set
            {
                this._customerLastName = value;
                OnPropertyChanged("CustomerName");
            }
        }

        private string _customerName;
        public string CustomerName
        {
            get
            {
                return this._customerName = CustomerFirstName + " " + CustomerLastName;
            }
            set
            {
                this._customerName = value;
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

        private double _price;
        public double Price
        {
            get
            {
                return this._price;
            }
            set
            {
                this._price = value;
            }
        }

        private double _salesOrderSubTotal;
        public double SalesOrderSubTotal
        {
            get
            {
                double total = 0;
                for (int i = 0; i < this._saleList.Count; i++)
                {
                    ProductInfoNJ product =  _saleList.ElementAt(i);
                    total +=  product.Price * product.Quantity;
                }
                this._salesOrderSubTotal = total;
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
        private double _orderItemQuantity;
        public double OrderItemQuantity
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

        private double _orderItemDiscount;
        public double OrderItemDiscount
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
        
            // Search Sale Order
        private string _searchSaleOderNo;
        public string SearchSaleOderNo
        {
            get
            {
                return this._searchSaleOderNo;
            }
            set
            {
                this._searchSaleOderNo = value;
            }
        }

        /// <summary>
        /// Called when Button SendToViewModel is clicked
        /// </summary>


        public DelegateCommand<object> OnItemSelected
        {
            get
            {
                return new DelegateCommand<object>((selectedItem) =>
                {
                    ProductInfoNJ selectedProductInfoNJ = (ProductInfoNJ)selectedItem;
                    selectedProductInfoNJ.Quantity = 1;
                    SaleList.Insert(SaleList.Count - 1, selectedProductInfoNJ);
                    SaleList.RemoveAt(SaleList.Count - 1);
                    OnPropertyChanged("SalesOrderSubTotal");
                });
            }
        }
        public DelegateCommand<object> SelectedItemChangedCommand
        {
            get
            {
                return new DelegateCommand<object>((selectedItem) =>
                {
                    OnPropertyChanged("SalesOrderSubTotal");
                });
            }
        }
        

        public ICommand SaveSale
        {
            get
            {
                return new DelegateCommand(new Action(() =>
                {
                    if (!ValidateSaleOrder())
                    {
                        MessageBox.Show(ErrorMessage);
                        return;
                    }

                    java.util.List productList = new java.util.ArrayList();

                    foreach (ProductInfoNJ productInfoNJ in SaleList)
                    {
                        ProductInfo productInfo = new ProductInfo();
                        productInfo.setId(productInfoNJ.ProductId);
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
                    saleInfo.setCustomerUserId(CusomerUserId);
                    saleInfo.setOrderNo(Order);
                    saleInfo.setStatusId(1);
                    saleInfo.setRemarks(OrderRemark);

                    ResultEvent resultEvent = new ResultEvent();
                    SaleManager saleManager = new SaleManager();
                    resultEvent = saleManager.addSaleOrder(saleInfo);
                    MessageBox.Show(resultEvent.getMessage());

                }));
            }
        }

        public DelegateCommand<object> OnCustomerSelected
        {
            get
            {
                return new DelegateCommand<object>((SelectedCustomer) =>
                {
                    if (SelectedCustomer is CustomerInfoNJ)
                    {
                        CustomerInfoNJ customerInfoNJ = (CustomerInfoNJ)SelectedCustomer;
                        CustomerFirstName = customerInfoNJ.CustomerFirstName;
                        CustomerLastName = customerInfoNJ.CustomerLastName;
                        Phone = customerInfoNJ.Phone;
                        CustomerUserId = customerInfoNJ.CustomerUserId;
                    }
                });
            }
        }

        ObservableCollection<SaleInfoNJ> _saleOrderList;

        public ObservableCollection<SaleInfoNJ> SaleOrderList
        {
            get
            {
                SaleManager saleManager = new SaleManager();
                _saleOrderList = new ObservableCollection<SaleInfoNJ>();
                for (Iterator i = saleManager.getAllSaleOrders().iterator(); i.hasNext(); )
                {
                    SaleInfo saleInfo = (SaleInfo)i.next();
                    SaleInfoNJ saleInfoNJ = new SaleInfoNJ();
                    saleInfoNJ.Order = saleInfo.getOrderNo();
                    //saleInfoNJ.OrderDate = saleInfo.getSaleDate();
                    saleInfoNJ.Status = saleInfo.getStatusId();
                    saleInfoNJ.CustomerFirstName = saleInfo.getCustomerInfo().getProfileInfo().getFirstName();
                    saleInfoNJ.CustomerLastName = saleInfo.getCustomerInfo().getProfileInfo().getLastName();

                    for (Iterator j = saleInfo.getProductList().iterator(); j.hasNext(); )
                    {
                        ProductInfo productInfo = (ProductInfo)j.next();
                        ProductInfoNJ productInfoNJ = new ProductInfoNJ();
                        productInfoNJ.Name = productInfo.getName();
                        productInfoNJ.Code = productInfo.getCode();
                        productInfoNJ.Price = productInfo.getUnitPrice();
                        saleInfoNJ.ProductList.Add(productInfoNJ);
                    }

                    _saleOrderList.Add(saleInfoNJ);
                }
                return _saleOrderList;
            }
            set
            {
                this._saleOrderList = value;
            }
        }

        ObservableCollection<ProductInfoNJ> _saleList = new ObservableCollection<ProductInfoNJ>();

        public ObservableCollection<ProductInfoNJ> SaleList
        {
            get
            {
                if (_saleList == null)
                {
                    _saleList = new ObservableCollection<ProductInfoNJ>();
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

                    customerInfoNJ.CustomerFirstName = customerInfo.getProfileInfo().getFirstName();
                    customerInfoNJ.CustomerLastName = customerInfo.getProfileInfo().getLastName();
                    customerInfoNJ.Phone = customerInfo.getProfileInfo().getPhone();
                    customerInfoNJ.CustomerUserId = customerInfo.getProfileInfo().getId();
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

                    customerInfoNJ.CustomerFirstName = customerInfo.getProfileInfo().getFirstName();
                    customerInfoNJ.CustomerLastName = customerInfo.getProfileInfo().getLastName();
                    customerInfoNJ.Phone = customerInfo.getProfileInfo().getPhone();
                    customerInfoNJ.CustomerUserId = customerInfo.getProfileInfo().getId();

                }
                return _customerList;

            }
            set
            {
                this._customerList = value;
            }
        }
        ObservableCollection<ProductInfoNJ> _productItemList;

        public ObservableCollection<ProductInfoNJ> ProductItemList
        {
            get
            {
                ProductManager productManager = new ProductManager();

                _productItemList = new ObservableCollection<ProductInfoNJ>();
                for (Iterator i = productManager.getAllProducts().iterator(); i.hasNext(); )
                {
                    ProductInfo prodcutInfo = (ProductInfo)i.next();
                    ProductInfoNJ productInfoNJ = new ProductInfoNJ();
                    productInfoNJ.Code = prodcutInfo.getCode();
                    productInfoNJ.Name = prodcutInfo.getName();
                    productInfoNJ.Price = prodcutInfo.getUnitPrice();
                    productInfoNJ.ProductId = prodcutInfo.getId();

                    _productItemList.Add(productInfoNJ);
                }
                return _productItemList;
            }
            set
            {
                this._productItemList = value;
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
        

        public ICommand SelectSaleOrderEvent
        {
            get
            {
                return new DelegateCommand<SaleInfoNJ>(this.selectSaleOrderEvent);
            }
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

            SaleManager saleManager = new SaleManager();

            _saleOrderList.Clear();
            for (Iterator i = saleManager.searchAllSaleOrders(SearchSaleOderNo).iterator(); i.hasNext(); )
            {
                SaleInfo saleInfo = (SaleInfo)i.next();
                SaleInfoNJ saleInfoNJ = new SaleInfoNJ();

                saleInfoNJ.Order = saleInfo.getOrderNo();
                saleInfoNJ.CustomerFirstName = saleInfo.getCustomerInfo().getProfileInfo().getFirstName();
                saleInfoNJ.CustomerLastName = saleInfo.getCustomerInfo().getProfileInfo().getLastName();
                saleInfoNJ.Phone = saleInfo.getCustomerInfo().getProfileInfo().getPhone();

                _saleOrderList.Add(saleInfoNJ);
            }
        }

        public void selectSaleOrderEvent(SaleInfoNJ saleInfoNJ)
        {
            SaleManager saleManager = new SaleManager();
            ResultEvent resultEvent = saleManager.getSaleOrderInfo(saleInfoNJ.Order);
            if (resultEvent.getResponseCode() == 2000)
            {
                Order = saleInfoNJ.Order;
                SaleInfo purchaseInfo = (SaleInfo)resultEvent.getResult();
                CustomerFirstName = purchaseInfo.getCustomerInfo().getProfileInfo().getFirstName();
                CustomerLastName = purchaseInfo.getCustomerInfo().getProfileInfo().getLastName();
                CustomerUserId = purchaseInfo.getCustomerInfo().getProfileInfo().getId();
                SaleList.Clear();
                for (Iterator j = purchaseInfo.getProductList().iterator(); j.hasNext(); )
                {
                    ProductInfo productInfo = (ProductInfo)j.next();
                    ProductInfoNJ productInfoNJ = new ProductInfoNJ();
                    productInfoNJ.Name = productInfo.getName();
                    productInfoNJ.Code = productInfo.getCode();
                    productInfoNJ.Quantity = productInfo.getQuantity();
                    saleInfoNJ.ProductList.Add(productInfoNJ);
                    SaleList.Add(productInfoNJ);
                }
            }
            else
            {
                MessageBox.Show(resultEvent.getMessage());
            }

           //Order = saleInfoNJ.Order;
           //Phone = saleInfoNJ.Phone;
           //CustomerFirstName = saleInfoNJ.CustomerFirstName;
           //CustomerLastName = saleInfoNJ.CustomerLastName;

           //SaleList.Clear();
           //for (int i = 0; i < saleInfoNJ.ProductList.Count; i++)
           //{
           //    SaleList.Add(saleInfoNJ.ProductList.ElementAt(i));
           //}

        }


        public Boolean ValidateSaleOrder()
        {
            if (CustomerUserId == 0)
            {
                ErrorMessage = "Please select a customer.";
                return false;
            }

            if (SaleList == null || SaleList.Count == 0)
            {
                ErrorMessage = "Please select a product.";
                return false;
            }

            return true;
        }




    }
}

