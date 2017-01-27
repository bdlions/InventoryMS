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
    class ManagePurchaseOrder : BindableBase, INotifyPropertyChanged
    {
        //constructor
        public ManagePurchaseOrder() 
        {
            //loading purchase list on left panel
            PurchaseManager purchaseManager = new PurchaseManager();
            for (Iterator i = purchaseManager.getAllPurchaseOrders().iterator(); i.hasNext(); )
            {
                PurchaseInfo purchaseInfo = (PurchaseInfo)i.next();
                PurchaseInfoNJ purchaseInfoNJ = new PurchaseInfoNJ();
                //We will display order no in grid view on left panel
                purchaseInfoNJ.OrderNo = purchaseInfo.getOrderNo();
                //right now after clicking on item on left panel purchase info is again retrived from the database
                //so we can ignore rest of the part right now if required.
                purchaseInfoNJ.StatusId = purchaseInfo.getStatusId();
                purchaseInfoNJ.Remarks = purchaseInfo.getRemarks();
                for (Iterator j = purchaseInfo.getProductList().iterator(); j.hasNext(); )
                {
                    ProductInfo productInfo = (ProductInfo)j.next();
                    ProductInfoNJ productInfoNJ = new ProductInfoNJ();
                    productInfoNJ.Id = productInfo.getId();
                    productInfoNJ.Name = productInfo.getName();
                    productInfoNJ.Code = productInfo.getCode();
                    productInfoNJ.Price = productInfo.getUnitPrice();
                    productInfoNJ.Quantity = productInfo.getQuantity();
                    purchaseInfoNJ.ProductList.Add(productInfoNJ);
                }
                SupplierInfo supplierInfo = new SupplierInfo();
                SupplierInfoNJ supplierInfoNJ = new SupplierInfoNJ();
                supplierInfoNJ.ProfileInfoNJ.Id = purchaseInfo.getSupplierInfo().getProfileInfo().getId();
                supplierInfoNJ.ProfileInfoNJ.FirstName = purchaseInfo.getSupplierInfo().getProfileInfo().getFirstName();
                supplierInfoNJ.ProfileInfoNJ.LastName = purchaseInfo.getSupplierInfo().getProfileInfo().getLastName();
                purchaseInfoNJ.SupplierInfoNJ = supplierInfoNJ;
                PurchaseOrderList.Add(purchaseInfoNJ);
            }

            //Setting a default random Order No for Purchase Info
            PurchaseInfoNJ.OrderNo = Guid.NewGuid().ToString().ToUpper(); ;
        }

        //purchase order list on left panel
        ObservableCollection<PurchaseInfoNJ> _purchaseOrderList;
        public ObservableCollection<PurchaseInfoNJ> PurchaseOrderList
        {
            get
            {
                if(_purchaseOrderList == null)
                {
                    _purchaseOrderList = new ObservableCollection<PurchaseInfoNJ>();
                }
                return _purchaseOrderList;             
            }
            set
            {
                this._purchaseOrderList = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler(this, new PropertyChangedEventArgs(propertyName));

        }

        //purchase order info
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
                OnPropertyChanged("PurchaseInfoNJ");
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

        //popup product list to be displayed while selecting product for purchase
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
         * @author nazmul hasan on 26th january 2016
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
                        PurchaseInfoNJ.ProductList.Insert(PurchaseInfoNJ.ProductList.Count - 1, selectedProductInfoNJ);
                        PurchaseInfoNJ.ProductList.RemoveAt(PurchaseInfoNJ.ProductList.Count - 1);
                        //OnPropertyChanged("OrderSubTotalAmount");
                        //OnPropertyChanged("OrderItemSubTotal");
                    }                    
                });
            }
        }

        //popup supplier list to be displayed while selecting a supplier
        ObservableCollection<SupplierInfoNJ> _supplierList;
        public ObservableCollection<SupplierInfoNJ> SupplierList
        {
            get
            {
                if (_supplierList == null)
                {
                    _supplierList = new ObservableCollection<SupplierInfoNJ>();
                    SupplierManager supplierManager = new SupplierManager();
                    for (Iterator i = supplierManager.getAllSuppliers().iterator(); i.hasNext(); )
                    {
                        SupplierInfo supplierInfo = (SupplierInfo)i.next();
                        SupplierInfoNJ supplierInfoNJ = new SupplierInfoNJ();
                        supplierInfoNJ.ProfileInfoNJ.Id = supplierInfo.getProfileInfo().getId();
                        supplierInfoNJ.ProfileInfoNJ.FirstName = supplierInfo.getProfileInfo().getFirstName();
                        supplierInfoNJ.ProfileInfoNJ.LastName = supplierInfo.getProfileInfo().getLastName();
                        supplierInfoNJ.ProfileInfoNJ.Phone = supplierInfo.getProfileInfo().getPhone();                        
                        _supplierList.Add(supplierInfoNJ);
                    }
                }                
                return _supplierList;
            }
            set
            {
                this._supplierList = value;
            }
        }
        /*
         * Event Handler if a supplier is selected from popup supplier list
         * @author nazmul hasan on 26th january 2016
         */
        public DelegateCommand<object> OnSupplierSelected
        {
            get
            {
                return new DelegateCommand<object>((SelectedSupplier) =>
                {
                    if (SelectedSupplier is SupplierInfoNJ)
                    {
                        SupplierInfoNJ supplierInfoNJ = (SupplierInfoNJ)SelectedSupplier;
                        PurchaseInfoNJ tempPurchaseInfoNJ = PurchaseInfoNJ;
                        SupplierInfoNJ tempSupplierInfoNJ = new SupplierInfoNJ();
                        tempSupplierInfoNJ.ProfileInfoNJ.Id = supplierInfoNJ.ProfileInfoNJ.Id;
                        tempSupplierInfoNJ.ProfileInfoNJ.FirstName = supplierInfoNJ.ProfileInfoNJ.FirstName;
                        tempSupplierInfoNJ.ProfileInfoNJ.LastName = supplierInfoNJ.ProfileInfoNJ.LastName;                        
                        tempPurchaseInfoNJ.SupplierInfoNJ = tempSupplierInfoNJ;
                        PurchaseInfoNJ = tempPurchaseInfoNJ;
                    }
                });
            }
        }

        /*
         * Event Handler if pruchase info is selected from left panel
         * @author nazmul hasan on 26th january 2016
         */
        public ICommand SelectPurchaseOrderEvent
        {
            get
            {
                return new DelegateCommand<PurchaseInfoNJ>(this.OnSelectPurchaseOrderEvent);
            }
        }
        /*
         * This method will display selected purchase info
         * @author nazmul hasan on 26th january 2016
         */
        public void OnSelectPurchaseOrderEvent(PurchaseInfoNJ purchaseInfoNJ)
        {
            PurchaseManager purchaseManager = new PurchaseManager();
            ResultEvent resultEvent = purchaseManager.getPurchaseOrderInfo(purchaseInfoNJ.OrderNo);
            if (resultEvent.getResponseCode() == Responses.RESPONSE_CODE_SUCCESS)
            {
                PurchaseInfo purchaseInfo = (PurchaseInfo)resultEvent.getResult();
                PurchaseInfoNJ tempPurchaseInfoNJ = new PurchaseInfoNJ();
                tempPurchaseInfoNJ.OrderNo = purchaseInfo.getOrderNo();
                tempPurchaseInfoNJ.StatusId = purchaseInfo.getStatusId();
                tempPurchaseInfoNJ.Remarks = purchaseInfo.getRemarks();
                for (Iterator j = purchaseInfo.getProductList().iterator(); j.hasNext(); )
                {
                    ProductInfo productInfo = (ProductInfo)j.next();
                    ProductInfoNJ productInfoNJ = new ProductInfoNJ();
                    productInfoNJ.Id = productInfo.getId();
                    productInfoNJ.Name = productInfo.getName();
                    productInfoNJ.Code = productInfo.getCode();
                    productInfoNJ.Price = productInfo.getUnitPrice();
                    productInfoNJ.Quantity = productInfo.getQuantity();
                    tempPurchaseInfoNJ.ProductList.Add(productInfoNJ);
                }
                SupplierInfo supplierInfo = new SupplierInfo();
                SupplierInfoNJ supplierInfoNJ = new SupplierInfoNJ();
                supplierInfoNJ.ProfileInfoNJ.Id = purchaseInfo.getSupplierInfo().getProfileInfo().getId();
                supplierInfoNJ.ProfileInfoNJ.FirstName = purchaseInfo.getSupplierInfo().getProfileInfo().getFirstName();
                supplierInfoNJ.ProfileInfoNJ.LastName = purchaseInfo.getSupplierInfo().getProfileInfo().getLastName();
                tempPurchaseInfoNJ.SupplierInfoNJ = supplierInfoNJ;
                PurchaseInfoNJ = tempPurchaseInfoNJ;                  
            }
            else
            {
                MessageBox.Show(resultEvent.getMessage());
            }
        }

        
        /*
         * This method will validate purchase order info
         * @author nazmul hasan on 26th january 2016
         */
        public Boolean ValidatePurchaseOrder()
        {
            if (PurchaseInfoNJ.SupplierInfoNJ.ProfileInfoNJ.Id == 0)
            {
                ErrorMessage = Messages.ERROR_PURCHASE_SUPPLIER_SELECTION_REQURIED;
                return false;
            }

            if (PurchaseInfoNJ.ProductList == null || PurchaseInfoNJ.ProductList.Count == 0)
            {
                ErrorMessage = Messages.ERROR_PURCHASE_PRODUCT_SELECTION_REQURIED;
                return false;
            }
            return true;
        }

        /*
        * Event Handler to save purchase order info
        * @author nazmul hasan on 26th january 2016
        */
        public ICommand SavePurchase
        {
            get
            {
                return new DelegateCommand(new Action(() =>
                {
                    //if no supplier is selected then default supplier is assigned
                    if(PurchaseInfoNJ.SupplierInfoNJ.ProfileInfoNJ.Id == 0)
                    {
                        PurchaseInfoNJ.SupplierInfoNJ.ProfileInfoNJ.Id = General.DEFAULT_SUPPLIER_USER_ID;
                    }
                    if (!ValidatePurchaseOrder())
                    {
                        MessageBox.Show(ErrorMessage);
                        return;
                    }
                    java.util.List productList = new java.util.ArrayList();

                    foreach (ProductInfoNJ productInfoNJ in PurchaseInfoNJ.ProductList)
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

                    PurchaseInfo purchaseInfo = new PurchaseInfo();
                    purchaseInfo.setProductList(productList);
                    purchaseInfo.setSupplierUserId(PurchaseInfoNJ.SupplierInfoNJ.ProfileInfoNJ.Id);
                    purchaseInfo.setOrderNo(PurchaseInfoNJ.OrderNo);
                    purchaseInfo.setRemarks(PurchaseInfoNJ.Remarks);
                    purchaseInfo.setStatusId(1);
                    
                    ResultEvent resultEvent = new ResultEvent();
                    PurchaseManager purchaseManager = new PurchaseManager();
                    resultEvent = purchaseManager.addPurchaseOrder(purchaseInfo);
                    if (resultEvent.getResponseCode() == Responses.RESPONSE_CODE_SUCCESS)
                    {
                        //adding purchase info on left panel
                        if (PurchaseOrderList.Count == 0)
                        {
                            PurchaseOrderList.Add(PurchaseInfoNJ);
                        }
                        else
                        {
                            PurchaseOrderList.Insert(0, PurchaseInfoNJ);
                        }
                        OnReset();
                    }
                    MessageBox.Show(resultEvent.getMessage());                    
                }));
            }
        }

        /*
         * This method will reset purchase order info
         * @author nazmul hasan on 26th january 2017
         */
        private void OnReset()
        {
            PurchaseInfoNJ = new PurchaseInfoNJ();
        }












        //----------------------------------Implement later ------------------------------//

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
                for (int i = 0; i < PurchaseInfoNJ.ProductList.Count; i++)
                {
                    ProductInfoNJ product = PurchaseInfoNJ.ProductList.ElementAt(i);
                    total += product.Price * product.Quantity;
                }
                /*for (int i = 0; i < this._purchaseList.Count; i++)
                {
                    ProductInfoNJ product = _purchaseList.ElementAt(i);
                    total += product.Price * product.Quantity;
                }*/
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

        
        public ICommand Search
        {
            get
            {
                return new DelegateCommand(this.OnSearch);
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

        
        


        /*ObservableCollection<SupplierInfoNJ> _supplierList;

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
        }*/






        

        


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


        

        

    }
}

