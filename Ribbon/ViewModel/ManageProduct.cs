using com.inventory.bean;
using com.inventory.db;
using com.inventory.db.manager;
using com.inventory.response;
using java.util;
using Prism.Commands;
using Prism.Mvvm;
using System;
using Ribbon.Model;
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
    class ManageProduct : BindableBase, INotifyPropertyChanged
    {
        //constructor
        public ManageProduct()
        {
            //loading product list on left panel
            ProductManager productManager = new ProductManager();
            for (Iterator i = productManager.getAllProducts().iterator(); i.hasNext(); )
            {
                ProductInfo pInfo = (ProductInfo)i.next();
                ProductInfoNJ pInfoNJ = new ProductInfoNJ();
                pInfoNJ.Id = pInfo.getId();
                pInfoNJ.Name = pInfo.getName();
                pInfoNJ.Code = pInfo.getCode();
                pInfoNJ.Price = pInfo.getUnitPrice();
                ProductList.Add(pInfoNJ);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
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

        private int _id;
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }
        private string _productName;
        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                _productName = value;
                OnPropertyChanged("ProductName");

            }
        }

        private string _productCode;
        public string ProductCode
        {
            get
            {
                return this._productCode;
            }
            set
            {
                this._productCode = value;
                OnPropertyChanged("ProductCode");
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
                OnPropertyChanged("Price");
            }
        }

        // Search product items
        private string _searchProductName;
        public string SearchProductName
        {
            get
            {
                return this._searchProductName;
            }
            set
            {
                this._searchProductName = value;
                //OnPropertyChanged("ProductCode");
            }
        }

        ObservableCollection<ProductInfoNJ> _productList;

        public ObservableCollection<ProductInfoNJ> ProductList
        {
            get
            {
                if(_productList == null)
                {
                    _productList = new ObservableCollection<ProductInfoNJ>();
                }                
                return _productList;
            }
            set
            {
                this._productList = value;
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

        public ICommand Deactivate
        {
            get
            {
                return new DelegateCommand(this.OnDeactivate);
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
        public ICommand SelectProductEvent
        {
            get
            {
                return new DelegateCommand<ProductInfoNJ>(this.selectProductEvent);
            }
        }

        /// <summary>
        /// Called when Button SendToViewModel is clicked
        /// </summary>
        private void OnAdd()
        {
            if (!ValidateProduct())
            {
                MessageBox.Show(ErrorMessage);
                return;
            }
            ProductInfo productInfo = new ProductInfo();            
            productInfo.setId(Id);
            productInfo.setName(ProductName);
            productInfo.setCode(ProductCode);
            productInfo.setUnitPrice(Price);

            ProductInfoNJ productInfoNJ = new ProductInfoNJ();
            productInfoNJ.Name = ProductName;
            productInfoNJ.Code = ProductCode;
            productInfoNJ.Price = Price;

            ResultEvent resultEvent = new ResultEvent();
            ProductManager productManager = new ProductManager();
            if (Id > 0)
            {
                resultEvent = productManager.updateProduct(productInfo);                
            }
            else
            {
                resultEvent = productManager.createProduct(productInfo);
            }
            if (resultEvent.getResponseCode() == 2000)
            {
                if (Id > 0)
                {
                    for (int counter = 0; counter < ProductList.Count; counter++)
                    {
                        productInfoNJ.Id = Id;
                        ProductInfoNJ tempProductInfoNJ = ProductList.ElementAt(counter);
                        if (tempProductInfoNJ.Id == Id)
                        {
                            ProductList.RemoveAt(counter);
                            ProductList.Insert(counter, productInfoNJ);
                        }
                    }
                }
                else
                {
                    ProductInfo responseProductInfo = (ProductInfo)resultEvent.getResult();
                    Id = responseProductInfo.getId();
                    productInfoNJ.Id = Id;
                    if(ProductList.Count == 0)
                    {
                        //appending product info in product list on left panel
                        ProductList.Add(productInfoNJ);
                    }
                    else
                    {
                        //appending productinfo at first index in product list on left panel
                        ProductList.Insert(0, productInfoNJ);
                    }                    
                }
            }
            MessageBox.Show(resultEvent.getMessage());
            //reset create product fields
            OnReset();
        }


        /// <summary>
        /// Called when Button SendToViewModel is clicked
        /// </summary>
        private void OnReset()
        {
            Id = 0;
            ProductName = "";
            ProductCode = "";
            Price = 0;
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
        public void OnDeactivate()
        {
            MessageBox.Show("OnDeactivate");
        }

        public static void OnProductChange()
        {
            //ProductName = "sdfsdf";
            MessageBox.Show("OnDeactivate");
        }

        /// <summary>
        /// Called when Button SendToViewModel is clicked
        /// </summary>
        private void OnSearch()
        {
            ProductManager productManager = new ProductManager();

            _productList.Clear();
            for (Iterator i = productManager.searchProduct(SearchProductName).iterator(); i.hasNext(); )
            {
                ProductInfo pInfo = (ProductInfo)i.next();
                ProductInfoNJ pInfoNJ = new ProductInfoNJ();
                pInfoNJ.Id = pInfo.getId();
                pInfoNJ.Name = pInfo.getName();
                pInfoNJ.Code = pInfo.getCode();
                pInfoNJ.Price = pInfo.getUnitPrice();
                _productList.Add(pInfoNJ);
            }
        }

        public void selectProductEvent(ProductInfoNJ p)
        {
            this.Id = p.Id;
            this.ProductName = p.Name;
            this.ProductCode = p.Code;
            this.Price = p.Price;
        }

        public Boolean ValidateProduct()
        {
            if (ProductName == null)
            {
                ErrorMessage = "Product name is required.";
                return false;
            }
            if (ProductCode == null)
            {
                ErrorMessage = "Product code is required.";
                return false;
            }
            if (Price < 0)
            {
                ErrorMessage = "Invalid value for price field. It must be a positive number.";
                return false;
            }
            return true;
        }

    }
}
