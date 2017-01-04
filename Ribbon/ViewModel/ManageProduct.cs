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
                ProductInfo productInfo = (ProductInfo)i.next();
                ProductInfoNJ productInfoNJ = new ProductInfoNJ();
                productInfoNJ.Id = productInfo.getId();
                productInfoNJ.Name = productInfo.getName();
                productInfoNJ.Code = productInfo.getCode();
                productInfoNJ.UnitPrice = productInfo.getUnitPrice();
                ProductList.Add(productInfoNJ);
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

        //product info
        private ProductInfoNJ _productInfoNJ;
        public ProductInfoNJ ProductInfoNJ
        {
            get
            {
                if(_productInfoNJ == null)
                {
                    _productInfoNJ = new ProductInfoNJ();
                }
                return _productInfoNJ;
            }
            set
            {
                _productInfoNJ = value;
                OnPropertyChanged("ProductInfoNJ");

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

        // search product by name
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
            }
        }

        //product list on left panel
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
        
        /*
         * EventHandler if product item is clicked on left panel
         */
        public ICommand SelectProductEvent
        {
            get
            {
                return new DelegateCommand<ProductInfoNJ>(this.OnSelectProductEvent);
            }
        }

        /*
         * This method will set product info based on selected product from left panel
         * @author nazmul hasan
         */
        public void OnSelectProductEvent(ProductInfoNJ productInfoNJ)
        {
            ProductInfoNJ = productInfoNJ;
        }

        /*
         * This method will validate Product info
         * @author nazmul hasan on 4th january 2017
         */
        public Boolean validateProduct()
        {
            if (ProductInfoNJ.Name == null)
            {
                ErrorMessage = "Product name is required.";
                return false;
            }
            if (String.IsNullOrEmpty(ProductInfoNJ.Code))
            {
                ErrorMessage = "Product code is required.";
                return false;
            }
            if (ProductInfoNJ.UnitPrice < 0)
            {
                ErrorMessage = "Invalid value for price field. It must be a positive number.";
                return false;
            }
            return true;
        }

        /*
         * Event handler to add/save product
         */
        public ICommand Add
        {
            get
            {
                return new DelegateCommand(this.OnAdd);
            }
        }
        /*
         * This method will add/save product
         * @author nazmul hasan on 4th january 2017
         */
        private void OnAdd()
        {
            if (!validateProduct())
            {
                MessageBox.Show(ErrorMessage);
                return;
            }
            ProductInfo productInfo = new ProductInfo();            
            productInfo.setId(ProductInfoNJ.Id);
            productInfo.setName(ProductInfoNJ.Name);
            productInfo.setCode(ProductInfoNJ.Code);
            productInfo.setUnitPrice(ProductInfoNJ.UnitPrice);

            ProductInfoNJ productInfoNJ = ProductInfoNJ;
            productInfoNJ.Name = ProductInfoNJ.Name;
            productInfoNJ.Code = ProductInfoNJ.Code;
            productInfoNJ.UnitPrice = ProductInfoNJ.UnitPrice;

            ResultEvent resultEvent = new ResultEvent();
            ProductManager productManager = new ProductManager();
            if (ProductInfoNJ.Id > 0)
            {
                resultEvent = productManager.updateProduct(productInfo);                
            }
            else
            {
                resultEvent = productManager.createProduct(productInfo);
            }
            if (resultEvent.getResponseCode() == 2000)
            {
                if (ProductInfoNJ.Id > 0)
                {
                    for (int counter = 0; counter < ProductList.Count; counter++)
                    {
                        productInfoNJ.Id = ProductInfoNJ.Id;
                        ProductInfoNJ tempProductInfoNJ = ProductList.ElementAt(counter);
                        if (tempProductInfoNJ.Id == ProductInfoNJ.Id)
                        {
                            ProductList.RemoveAt(counter);
                            ProductList.Insert(counter, productInfoNJ);
                        }
                    }
                }
                else
                {
                    ProductInfo responseProductInfo = (ProductInfo)resultEvent.getResult();
                    productInfoNJ.Id = responseProductInfo.getId();
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

        /*
         * Event handler to reset product
         */
        public ICommand Reset
        {
            get
            {
                return new DelegateCommand(this.OnReset);
            }
        }

        /*
         * This method will reset product info
         * @author nazmul hasan on 4th january 2017
         */
        private void OnReset()
        {
            ProductInfoNJ = new ProductInfoNJ();
        }

        /*
         * Event Handler to search product
         * @author nazmul hasan on 4th january 2017
         */
        private void OnSearch()
        {
            ProductManager productManager = new ProductManager();
            ProductList.Clear();
            for (Iterator i = productManager.searchProduct(SearchProductName).iterator(); i.hasNext(); )
            {
                ProductInfo productInfo = (ProductInfo)i.next();
                ProductInfoNJ productInfoNJ = new ProductInfoNJ();
                productInfoNJ.Id = productInfo.getId();
                productInfoNJ.Name = productInfo.getName();
                productInfoNJ.Code = productInfo.getCode();
                productInfoNJ.UnitPrice = productInfo.getUnitPrice();
                ProductList.Add(productInfoNJ);
            }
        }

        


        //-----------------------------Implement later ---------------------------//
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
    }
}
