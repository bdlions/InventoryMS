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

namespace Ribbon.ViewModel
{
    class ManagePurchaseOrder : BindableBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private PurchaseInfoNJ _purchaseInfoNJ;
        public PurchaseInfoNJ PurchaseInfoNJ
        {
            get
            {
                if (_purchaseInfoNJ == null)
                {
                    _purchaseInfoNJ = new PurchaseInfoNJ();
                }
                return this._purchaseInfoNJ;
            }
            set
            {
                this._purchaseInfoNJ = value;
            }
        }

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

        private string _fname;
        public string SupplierFirstName
        {
            get
            {
                return this._fname;
            }
            set
            {
                this._fname = value;
                OnPropertyChanged("SupplierName");
            }
        }

        private string _lname;
        public string SupplierLastName
        {
            get
            {
                return this._lname;
            }
            set
            {
                this._lname = value;
                OnPropertyChanged("SupplierName");
            }
        }


        private string _supplier;
        public string SupplierName
        {
            get
            {
                return this._supplier = SupplierFirstName + " " + SupplierLastName;
            }
            set
            {
                this._supplier = value;
                OnPropertyChanged("SupplierName");
            }
        }

        private int _supplierUserId;
        public int SupplierUserId
        {
            get
            {
                return this._supplierUserId;
            }
            set
            {
                this._supplierUserId = value;
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

        private long _requestShippedDate;
        public long RequestShippedDate
        {
            get
            {
                return this._requestShippedDate;
            }
            set
            {
                this._requestShippedDate = value;
            }
        }



        /*  ------------------------- Purchase Order Item ----------------------*/

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
        private long _orderItemQuantity;
        public long OrderItemQuantity
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

        private long _orderItemDiscount;
        public long OrderItemDiscount
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

        private double _orderItemSubTotal;
        public double OrderItemSubTotal
        {
            get
            {
                double subTotal = 0;
                for (int i = 0; i < this._purchaseList.Count; i++)
                {
                    ProductInfoNJ product = _purchaseList.ElementAt(i);
                    subTotal = product.Price * product.Quantity;
                }
                this._orderItemSubTotal = subTotal;
                return this._orderSubTotal;
            }
            set
            {
                this._orderItemSubTotal = value;
            }
        }

        /*-------------------------------------------------------------------------------*/

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
                this._order = Guid.NewGuid().ToString().ToUpper();
                return this._order;
            }
            set
            {
                this._order = value;
            }
        }

        private int _status;
        public int Status
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

        private double _orderSubTotal;
        public double OrderSubTotalAmount
        {
            get
            {
                double total = 0;
                for (int i = 0; i < this._purchaseList.Count; i++)
                {
                    ProductInfoNJ product = _purchaseList.ElementAt(i);
                    total += product.Price * product.Quantity;
                }
                this._orderSubTotal = total;
                return this._orderSubTotal;
            }
            set
            {
                this._orderSubTotal = value;
            }
        }

       

        public DelegateCommand<object> SelectedItemChangedCommand
        {
            get
            {
                return new DelegateCommand<object>((selectedItem) =>
                {
                    OnPropertyChanged("OrderSubTotalAmount");
                    OnPropertyChanged("OrderItemSubTotal");
                });
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


        // Search Purchase Order
        private string _searchPurchaseOderNo;
        public string SearchPurchaseOderNo
        {
            get
            {
                return this._searchPurchaseOderNo;
            }
            set
            {
                this._searchPurchaseOderNo = value;
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

        public ICommand SelectPurchaseOrderEvent
        {
            get
            {
                return new DelegateCommand<PurchaseInfoNJ>(this.selectPurchaseOrderEvent);
            }
        }
        public ICommand Search
        {
            get
            {
                return new DelegateCommand(this.OnSearch);
            }
        }

        public ICommand SavePurchase
        {
            get
            {
                return new DelegateCommand(new Action(() =>
                {
                    if (!ValidatePurchaseOrder())
                    {
                        MessageBox.Show(ErrorMessage);
                        return;
                    }
                    java.util.List productList = new java.util.ArrayList();

                    foreach (ProductInfoNJ productInfoNJ in PurchaseList)
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

                    PurchaseInfo purchaseInfo = new PurchaseInfo();
                    purchaseInfo.setProductList(productList);
                    purchaseInfo.setSupplierUserId(SupplierUserId);
                    purchaseInfo.setOrderNo(Order);
                    purchaseInfo.setRemarks(PurchaseInfoNJ.Remarks);
                    purchaseInfo.setStatusId(1);
                    //purchaseInfo.setRemarks(OrderRemark);

                    ResultEvent resultEvent = new ResultEvent();
                    PurchaseManager purchaseManager = new PurchaseManager();
                    resultEvent = purchaseManager.addPurchaseOrder(purchaseInfo);
                    MessageBox.Show(resultEvent.getMessage());
                }));
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

        ObservableCollection<ProductInfoNJ> _purchaseList;

        public ObservableCollection<ProductInfoNJ> PurchaseList
        {
            get
            {
                if (_purchaseList == null)
                {
                    _purchaseList = new ObservableCollection<ProductInfoNJ>();
                }
                return _purchaseList;
            }
            set
            {
                this._purchaseList = value;
            }
        }

        ObservableCollection<PurchaseInfoNJ> _purchaseOrderList;

        public ObservableCollection<PurchaseInfoNJ> PurchaseOrderList
        {
            get
            {
                PurchaseManager purchaseManager = new PurchaseManager();

                _purchaseOrderList = new ObservableCollection<PurchaseInfoNJ>();
                for (Iterator i = purchaseManager.getAllPurchaseOrders().iterator(); i.hasNext(); )
                {
                    PurchaseInfo purchaseInfo = (PurchaseInfo)i.next();
                    PurchaseInfoNJ purchaseInfoNJ = new PurchaseInfoNJ();
                    purchaseInfoNJ.Order = purchaseInfo.getOrderNo();
                    purchaseInfoNJ.OrderRemark = purchaseInfo.getRemarks();
                    purchaseInfoNJ.RequestedShipDate = purchaseInfo.getRequestShippedDate();
                    //purchaseInfoNJ.OrderDate = purchaseInfo.getOrderDate();
                    purchaseInfoNJ.StatusId = purchaseInfo.getStatusId();
                    purchaseInfoNJ.Discount = purchaseInfo.getDiscount();

                    for (Iterator j = purchaseInfo.getProductList().iterator(); j.hasNext(); )
                    {
                        ProductInfo productInfo = (ProductInfo)j.next();
                        ProductInfoNJ productInfoNJ = new ProductInfoNJ();
                        productInfoNJ.Name = productInfo.getName();
                        productInfoNJ.Code = productInfo.getCode();
                        //productInfoNJ.Discount = 20;
                        productInfoNJ.Price = productInfo.getUnitPrice();
                        purchaseInfoNJ.ProductList.Add(productInfoNJ);
                    }


                    //ProductInfoNJ productInfoNJ = new ProductInfoNJ();
                    //productInfoNJ.Name = "RedoyTestProduct";
                    //productInfoNJ.Quantity = 10;
                    //productInfoNJ.Discount = 20;
                    //productInfoNJ.Price = 100;


                    //purchaseInfoNJ.ProductList.Add(productInfoNJ);

                    SupplierInfo supplierInfo = new SupplierInfo();
                    SupplierInfoNJ supplierInfoNJ = new SupplierInfoNJ();
                    purchaseInfoNJ.SupplierFirstName = purchaseInfo.getSupplierInfo().getProfileInfo().getFirstName();
                    purchaseInfoNJ.SupplierLastName = purchaseInfo.getSupplierInfo().getProfileInfo().getLastName();

                    purchaseInfoNJ.SupplierInfoNJ = supplierInfoNJ;
                    _purchaseOrderList.Add(purchaseInfoNJ);
                }
                return _purchaseOrderList;
            }
            set
            {
                this._purchaseOrderList = value;
            }
        }


        ObservableCollection<SupplierInfoNJ> _supplierItemList;

        public ObservableCollection<SupplierInfoNJ> SupplierItemList
        {
            get
            {
                SupplierManager supplierManager = new SupplierManager();

                _supplierItemList = new ObservableCollection<SupplierInfoNJ>();
                for (Iterator i = supplierManager.getAllSuppliers().iterator(); i.hasNext(); )
                {
                    SupplierInfo supplierInfo = (SupplierInfo)i.next();
                    SupplierInfoNJ supplierInfoNJ = new SupplierInfoNJ();
                    supplierInfoNJ.SupplierFirstName = supplierInfo.getProfileInfo().getFirstName();
                    supplierInfoNJ.SupplierLastName = supplierInfo.getProfileInfo().getLastName();
                    supplierInfoNJ.Phone = supplierInfo.getProfileInfo().getPhone();
                    supplierInfoNJ.SupplierUserID = supplierInfo.getProfileInfo().getId();

                    _supplierItemList.Add(supplierInfoNJ);
                }
                return _supplierItemList;
            }
            set
            {
                this._supplierItemList = value;
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

                    //SupplierInfo supplierInfo = new SupplierInfo();
                    //SupplierInfoNJ supplierInfoNJ = new SupplierInfoNJ();

                    //supplierInfoNJ.SupplierFirstName = supplierInfo.getProfileInfo().getFirstName();
                    //supplierInfoNJ.SupplierLastName = supplierInfo.getProfileInfo().getLastName();
                    //supplierInfoNJ.SupplierName = supplierInfoNJ.SupplierFirstName + " " + supplierInfoNJ.SupplierLastName;
                    //supplierInfoNJ.Phone = supplierInfo.getProfileInfo().getPhone();
                    //supplierInfoNJ.SupplierUserID = supplierInfo.getProfileInfo().getId();
                }
                return _supplierList;
            }
            set
            {
                this._supplierList = value;
            }
        }






        public DelegateCommand<object> OnItemSelected
        {
            get
            {
                return new DelegateCommand<object>((selectedItem) =>
                {
                    ProductInfoNJ selectedProductInfoNJ = (ProductInfoNJ)selectedItem;
                    selectedProductInfoNJ.Quantity = 1;
                    PurchaseList.Insert(PurchaseList.Count - 1, selectedProductInfoNJ);
                    PurchaseList.RemoveAt(PurchaseList.Count - 1);
                    OnPropertyChanged("OrderSubTotalAmount");
                    OnPropertyChanged("OrderItemSubTotal");
                });
            }
        }


        public DelegateCommand<object> OnSupplierSelected
        {
            get
            {
                return new DelegateCommand<object>((SelectedSupplier) =>
                {
                    if (SelectedSupplier is SupplierInfoNJ)
                    {
                        SupplierInfoNJ supplierInfo = (SupplierInfoNJ)SelectedSupplier;
                        SupplierFirstName = supplierInfo.SupplierFirstName;
                        SupplierLastName = supplierInfo.SupplierLastName;
                        Phone = supplierInfo.Phone;
                        SupplierUserId = supplierInfo.SupplierUserID;
                    }



                });
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

        private void OnSearch()
        {

            PurchaseManager purchaseManager = new PurchaseManager();

            _purchaseOrderList.Clear();
            for (Iterator i = purchaseManager.searchPurchaseOrders(SearchPurchaseOderNo).iterator(); i.hasNext(); )
            {
                PurchaseInfo purchaseInfo = (PurchaseInfo)i.next();
                PurchaseInfoNJ purchaseInfoNJ = new PurchaseInfoNJ();

                purchaseInfoNJ.Order = purchaseInfo.getOrderNo();
                purchaseInfoNJ.SupplierFirstName = purchaseInfo.getSupplierInfo().getProfileInfo().getFirstName();
                purchaseInfoNJ.SupplierLastName = purchaseInfo.getSupplierInfo().getProfileInfo().getLastName();
                purchaseInfoNJ.Phone = purchaseInfo.getSupplierInfo().getProfileInfo().getPhone();

                _purchaseOrderList.Add(purchaseInfoNJ);
            }
        }


        public void selectPurchaseOrderEvent(PurchaseInfoNJ purchaseInfoNJ)
        {   
            PurchaseManager purchaseManager = new PurchaseManager();
            ResultEvent resultEvent = purchaseManager.getPurchaseOrderInfo(purchaseInfoNJ.Order);
            if (resultEvent.getResponseCode() == 2000)
            {
                Order = purchaseInfoNJ.Order;
                PurchaseInfo purchaseInfo = (PurchaseInfo)resultEvent.getResult();
                SupplierFirstName = purchaseInfo.getSupplierInfo().getProfileInfo().getFirstName();
                SupplierLastName = purchaseInfo.getSupplierInfo().getProfileInfo().getLastName();
                SupplierUserId = purchaseInfo.getSupplierInfo().getProfileInfo().getId();
                PurchaseList.Clear();
                for (Iterator j = purchaseInfo.getProductList().iterator(); j.hasNext(); )
                {
                    ProductInfo productInfo = (ProductInfo)j.next();
                    ProductInfoNJ productInfoNJ = new ProductInfoNJ();
                    productInfoNJ.Name = productInfo.getName();
                    productInfoNJ.Code = productInfo.getCode();
                    productInfoNJ.Quantity = productInfo.getQuantity();
                    purchaseInfoNJ.ProductList.Add(productInfoNJ);
                    PurchaseList.Add(productInfoNJ);
                }
            }
            else 
            {
                MessageBox.Show(resultEvent.getMessage());
            }



            //SupplierFirstName = purchaseInfoNJ.SupplierFirstName;
            //SupplierLastName = purchaseInfoNJ.SupplierLastName;

            //PurchaseList.Clear();
            //for (int i = 0; i < purchaseInfoNJ.ProductList.Count; i++)
            //{
            //    PurchaseList.Add(purchaseInfoNJ.ProductList.ElementAt(i));
            //}

        }

        public Boolean ValidatePurchaseOrder()
        {
            if (SupplierUserId == 0)
            {
                ErrorMessage = "Please select a supplier.";
                return false;
            }

            if (PurchaseList == null || PurchaseList.Count == 0)
            {
                ErrorMessage = "Please select a product.";
                return false;
            }
            
            return true;
        }

    }
}

