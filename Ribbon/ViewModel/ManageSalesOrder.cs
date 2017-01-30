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
using System.Windows.Input;
using Ribbon.Constants;

namespace Ribbon.ViewModel
{
    class ManageSalesOrder : BindableBase, INotifyPropertyChanged
    {

        //constructor
        public ManageSalesOrder()
        {
            //loading sale list on left panel
            SaleManager saleManager = new SaleManager();
            for (Iterator i = saleManager.getAllSaleOrders().iterator(); i.hasNext(); )
            {
                SaleInfo saleInfo = (SaleInfo)i.next();
                SaleInfoNJ saleInfoNJ = new SaleInfoNJ();
                saleInfoNJ.OrderNo = saleInfo.getOrderNo();
                saleInfoNJ.StatusId = saleInfo.getStatusId();
                saleInfoNJ.Remarks = saleInfo.getRemarks();
                for (Iterator j = saleInfo.getProductList().iterator(); j.hasNext(); )
                {
                    ProductInfo productInfo = (ProductInfo)j.next();
                    ProductInfoNJ productInfoNJ = new ProductInfoNJ();
                    productInfoNJ.Id = productInfo.getId();
                    productInfoNJ.Name = productInfo.getName();
                    productInfoNJ.Code = productInfo.getCode();
                    productInfoNJ.Price = productInfo.getUnitPrice();
                    productInfoNJ.Quantity = productInfo.getQuantity();
                    saleInfoNJ.ProductList.Add(productInfoNJ);
                }
                CustomerInfo customerInfo = new CustomerInfo();
                CustomerInfoNJ customerInfoNJ = new CustomerInfoNJ();
                customerInfoNJ.ProfileInfoNJ.Id = saleInfo.getCustomerInfo().getProfileInfo().getId();
                customerInfoNJ.ProfileInfoNJ.FirstName = saleInfo.getCustomerInfo().getProfileInfo().getFirstName();
                customerInfoNJ.ProfileInfoNJ.LastName = saleInfo.getCustomerInfo().getProfileInfo().getLastName();
                saleInfoNJ.CustomerInfoNJ = customerInfoNJ;
                SaleOrderList.Add(saleInfoNJ);
            }

            //Setting a default random Order No for Sale Info
            SaleInfoNJ.OrderNo = Guid.NewGuid().ToString().ToUpper(); ;
        }


        //sale order list on left panel
        ObservableCollection<SaleInfoNJ> _saleOrderList;
        public ObservableCollection<SaleInfoNJ> SaleOrderList
        {
            get
            {
                if (_saleOrderList == null)
                {
                    _saleOrderList = new ObservableCollection<SaleInfoNJ>();
                }
                return _saleOrderList;
            }
            set
            {
                this._saleOrderList = value;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler(this, new PropertyChangedEventArgs(propertyName));

        }

        //sale order info
        private SaleInfoNJ _saleInfoNJ;
        public SaleInfoNJ SaleInfoNJ
        {
            get
            {
                if (_saleInfoNJ == null)
                {
                    _saleInfoNJ = new SaleInfoNJ();
                }
                return this._saleInfoNJ;
            }
            set
            {
                this._saleInfoNJ = value;
                OnPropertyChanged("SaleInfoNJ");
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


        //popup product list to be displayed while selecting product for sale
        ObservableCollection<ProductInfoNJ> _productList;
        public ObservableCollection<ProductInfoNJ> ProductList
        {
            get
            {
                if (_productList == null)
                {
                    _productList = new ObservableCollection<ProductInfoNJ>();
                    //retrieving product list
                    ProductManager productManager = new ProductManager();
                    for (Iterator i = productManager.getAllProducts().iterator(); i.hasNext(); )
                    {
                        ProductInfo prodcutInfo = (ProductInfo)i.next();
                        ProductInfoNJ productInfoNJ = new ProductInfoNJ();
                        productInfoNJ.Id = prodcutInfo.getId();
                        productInfoNJ.Name = prodcutInfo.getName();
                        productInfoNJ.Code = prodcutInfo.getCode();
                        productInfoNJ.Price = prodcutInfo.getUnitPrice();
                        _productList.Add(productInfoNJ);
                    }
                }
                return _productList;
            }
            set
            {
                this._productList = value;
            }
        }


        /*
         * Event Handler if a product is selected from popup product list
         * @author A.K.M. Nazmul Islam on 26th january 2016
         */
        public DelegateCommand<object> OnProductItemSelected
        {
            get
            {
                return new DelegateCommand<object>((selectedItem) =>
                {
                    ProductInfoNJ selectedProductInfoNJ = (ProductInfoNJ)selectedItem;
                    if (selectedProductInfoNJ != null)
                    {
                        selectedProductInfoNJ.Quantity = 1;
                        SaleInfoNJ.ProductList.Insert(SaleInfoNJ.ProductList.Count - 1, selectedProductInfoNJ);
                        SaleInfoNJ.ProductList.RemoveAt(SaleInfoNJ.ProductList.Count - 1);
                    }
                });
            }
        }

        //popup customer list to be displayed while selecting a customer
        ObservableCollection<CustomerInfoNJ> _customerList;
        public ObservableCollection<CustomerInfoNJ> CustomerList
        {
            get
            {
                if (_customerList == null)
                {
                    _customerList = new ObservableCollection<CustomerInfoNJ>();
                    CustomerManager customerManager = new CustomerManager();
                    for (Iterator i = customerManager.getAllCustomers().iterator(); i.hasNext(); )
                    {
                        CustomerInfo customerInfo = (CustomerInfo)i.next();
                        CustomerInfoNJ customerInfoNJ = new CustomerInfoNJ();
                        customerInfoNJ.ProfileInfoNJ.Id = customerInfo.getProfileInfo().getId();
                        customerInfoNJ.ProfileInfoNJ.FirstName = customerInfo.getProfileInfo().getFirstName();
                        customerInfoNJ.ProfileInfoNJ.LastName = customerInfo.getProfileInfo().getLastName();
                        customerInfoNJ.ProfileInfoNJ.Phone = customerInfo.getProfileInfo().getPhone();
                        _customerList.Add(customerInfoNJ);
                    }
                }
                return _customerList;
            }
            set
            {
                this._customerList = value;
            }
        }
        /*
         * Event Handler if a customer is selected from popup customer list
         * @author A.K.M. Nazmul Islam on 26th january 2016
         */
        public DelegateCommand<object> OnCustomerSelected
        {
            get
            {
                return new DelegateCommand<object>((SelectedCustomer) =>
                {
                    if (SelectedCustomer is CustomerInfoNJ)
                    {
                        CustomerInfoNJ customerInfoNJ = (CustomerInfoNJ)SelectedCustomer;
                        SaleInfoNJ tempSaleInfoNJ = SaleInfoNJ;
                        CustomerInfoNJ tempCustomerInfoNJ = new CustomerInfoNJ();
                        tempCustomerInfoNJ.ProfileInfoNJ.Id = customerInfoNJ.ProfileInfoNJ.Id;
                        tempCustomerInfoNJ.ProfileInfoNJ.FirstName = customerInfoNJ.ProfileInfoNJ.FirstName;
                        tempCustomerInfoNJ.ProfileInfoNJ.LastName = customerInfoNJ.ProfileInfoNJ.LastName;
                        tempSaleInfoNJ.CustomerInfoNJ = tempCustomerInfoNJ;
                        SaleInfoNJ = tempSaleInfoNJ;
                    }
                });
            }
        }



        /*
       * Event Handler if sale info is selected from left panel
       * @author A.K.M. Nazmul Islam on 26th january 2016
       */
        public ICommand SelectSaleOrderEvent
        {
            get
            {
                return new DelegateCommand<SaleInfoNJ>(this.OnSelectSaleOrderEvent);
            }
        }

        /*
     * This method will display selected sale info
     * @author A.K.M. Nazmul Islam on 26th january 2016
     */
        public void OnSelectSaleOrderEvent(SaleInfoNJ saleInfoNJ)
        {
            SaleManager saleManager = new SaleManager();
            ResultEvent resultEvent = saleManager.getSaleOrderInfo(saleInfoNJ.OrderNo);
            if (resultEvent.getResponseCode() == Responses.RESPONSE_CODE_SUCCESS)
            {
                SaleInfo saleInfo = (SaleInfo)resultEvent.getResult();
                SaleInfoNJ tempSaleInfoNJ = new SaleInfoNJ();
                tempSaleInfoNJ.OrderNo = saleInfo.getOrderNo();
                tempSaleInfoNJ.StatusId = saleInfo.getStatusId();
                tempSaleInfoNJ.Remarks = saleInfo.getRemarks();
                for (Iterator j = saleInfo.getProductList().iterator(); j.hasNext(); )
                {
                    ProductInfo productInfo = (ProductInfo)j.next();
                    ProductInfoNJ productInfoNJ = new ProductInfoNJ();
                    productInfoNJ.Id = productInfo.getId();
                    productInfoNJ.Name = productInfo.getName();
                    productInfoNJ.Code = productInfo.getCode();
                    productInfoNJ.Price = productInfo.getUnitPrice();
                    productInfoNJ.Quantity = productInfo.getQuantity();
                    tempSaleInfoNJ.ProductList.Add(productInfoNJ);
                }
                CustomerInfo customerInfo = new CustomerInfo();
                CustomerInfoNJ customerInfoNJ = new CustomerInfoNJ();
                customerInfoNJ.ProfileInfoNJ.Id = saleInfo.getCustomerInfo().getProfileInfo().getId();
                customerInfoNJ.ProfileInfoNJ.FirstName = saleInfo.getCustomerInfo().getProfileInfo().getFirstName();
                customerInfoNJ.ProfileInfoNJ.LastName = saleInfo.getCustomerInfo().getProfileInfo().getLastName();
                tempSaleInfoNJ.CustomerInfoNJ = customerInfoNJ;
                SaleInfoNJ = tempSaleInfoNJ;
            }
            else
            {
                MessageBox.Show(resultEvent.getMessage());
            }
        }


  
       


        /*
         * This method will validate sale order info
         * @author A.K.M. Nazmul Islam on 26th january 2016
         */
        public Boolean ValidateSaleOrder()
        {
            if (SaleInfoNJ.CustomerInfoNJ.ProfileInfoNJ.Id == 0)
            {
                ErrorMessage = Messages.ERROR_SALE_CUSTOMER_SELECTION_REQURIED;
                return false;
            }

            if (SaleInfoNJ.ProductList == null || SaleInfoNJ.ProductList.Count == 0)
            {
                ErrorMessage = Messages.ERROR_SALE_PRODUCT_SELECTION_REQURIED;
                return false;
            }
            return true;
        }


        /*
        * Event Handler to save sale order info
        * @author A.K.M. Nazmul Islam on 26th january 2016
        */
        public ICommand SaveSale
        {
            get
            {
                return new DelegateCommand(new Action(() =>
                {
                    //if no customer is selected then default customer is assigned
                    if(SaleInfoNJ.CustomerInfoNJ.ProfileInfoNJ.Id == 0)
                    {
                        SaleInfoNJ.CustomerInfoNJ.ProfileInfoNJ.Id = General.DEFAULT_CUSTOMER_USER_ID;
                    }
                    if (!ValidateSaleOrder())
                    {
                        MessageBox.Show(ErrorMessage);
                        return;
                    }
                    java.util.List productList = new java.util.ArrayList();

                    foreach (ProductInfoNJ productInfoNJ in SaleInfoNJ.ProductList)
                    {
                        ProductInfo productInfo = new ProductInfo();
                        productInfo.setName(productInfoNJ.Name);
                        productInfo.setCode(productInfoNJ.Code);
                        productInfo.setUnitPrice(productInfoNJ.Price);
                        productInfo.setQuantity(productInfoNJ.Quantity);
                        productInfo.setDiscount(productInfoNJ.Discount);
                        productInfo.setId(productInfoNJ.Id);
                        productList.add(productInfo);
                    }

                    SaleInfo saleInfo = new SaleInfo();
                    saleInfo.setProductList(productList);
                    saleInfo.setCustomerUserId(SaleInfoNJ.CustomerInfoNJ.ProfileInfoNJ.Id);
                    saleInfo.setOrderNo(SaleInfoNJ.OrderNo);
                    saleInfo.setRemarks(SaleInfoNJ.Remarks);
                    saleInfo.setStatusId(1);

                    ResultEvent resultEvent = new ResultEvent();
                    SaleManager saleManager = new SaleManager();
                    resultEvent = saleManager.addSaleOrder(saleInfo);
                    if (resultEvent.getResponseCode() == Responses.RESPONSE_CODE_SUCCESS)
                    {
                        //adding sale info on left panel
                        if (SaleOrderList.Count == 0)
                        {
                            SaleOrderList.Add(SaleInfoNJ);
                        }
                        else
                        {
                            SaleOrderList.Insert(0, SaleInfoNJ);
                        }
                        OnReset();
                    }
                    MessageBox.Show(resultEvent.getMessage());                    
                }));
            }
        }

        /*
         * This method will reset sale order info
         * @author nazmul hasan on 26th january 2017
         */
        private void OnReset()
        {
            SaleInfoNJ = new SaleInfoNJ();
        }



        //----------------------------------Implement later ------------------------------//



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
                for (int i = 0; i < SaleInfoNJ.ProductList.Count; i++)
                {
                    ProductInfoNJ product = SaleInfoNJ.ProductList.ElementAt(i);
                    total += product.Price * product.Quantity;
                }
                /*for (int i = 0; i < this._purchaseList.Count; i++)
                {
                     ProductInfoNJ product = _saleList.ElementAt(i);
                     total += product.Price * product.Quantity;
                }*/
                this._salesOrderSubTotal = total;
                return this._salesOrderSubTotal;
            }
            set
            {
                this._salesOrderSubTotal = value;
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
        private string _searchSaleByOderNo;
        public string SearchSaleByOderNo
        {
            get
            {
                return this._searchSaleByOderNo;
            }
            set
            {
                this._searchSaleByOderNo = value;
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


        public ICommand Search
        {
            get
            {
                return new DelegateCommand(this.OnSearch);
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


        

       /* ObservableCollection<CustomerInfoNJ> _customerList;

        public ObservableCollection<CustomerInfoNJ> CustomerList
        {
            get
            {
                if (_customerList == null)
                {
                    _customerList = new ObservableCollection<CustomerInfoNJ>();

                    //CustomerInfo customerInfo = new CustomerInfo();
                    //CustomerInfoNJ customerInfoNJ = new CustomerInfoNJ();

                    //customerInfoNJ.CustomerFirstName = customerInfo.getProfileInfo().getFirstName();
                    //customerInfoNJ.CustomerLastName = customerInfo.getProfileInfo().getLastName();
                    //customerInfoNJ.Phone = customerInfo.getProfileInfo().getPhone();
                    //customerInfoNJ.CustomerUserId = customerInfo.getProfileInfo().getId();

                }
                return _customerList;

            }
            set
            {
                this._customerList = value;
            }
        }
        */


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


        /// <summary>
        /// Called when Button SendToViewModel is clicked
        /// </summary>
        private void OnSearch()
        {

            SaleManager saleManager = new SaleManager();

            SaleOrderList.Clear();
            for (Iterator i = saleManager.searchAllSaleOrders(SearchSaleByOderNo).iterator(); i.hasNext(); )
            {
                SaleInfo saleInfo = (SaleInfo)i.next();
                SaleInfoNJ saleInfoNJ = new SaleInfoNJ();

                saleInfoNJ.OrderNo = saleInfo.getOrderNo();
                saleInfoNJ.StatusId = saleInfo.getStatusId();
                saleInfoNJ.Remarks = saleInfo.getRemarks();
                SaleOrderList.Add(saleInfoNJ);
                //saleInfoNJ.Order = saleInfo.getOrderNo();
                //saleInfoNJ.CustomerFirstName = saleInfo.getCustomerInfo().getProfileInfo().getFirstName();
                //saleInfoNJ.CustomerLastName = saleInfo.getCustomerInfo().getProfileInfo().getLastName();
                //saleInfoNJ.Phone = saleInfo.getCustomerInfo().getProfileInfo().getPhone();
            }
        }
    }
}

