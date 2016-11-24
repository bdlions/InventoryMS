using com.inventory.bean;
using com.inventory.db;
using com.inventory.db.manager;
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
    class ManageProduct : BindableBase, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
        private string _productName;
        public  string ProductName
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

        private long _price;
        public long Price
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

        ObservableCollection<ProductInfoNJ> _productList;

        public ObservableCollection<ProductInfoNJ> ProductList
        {
            get
            {
                ProductManager productManager = new ProductManager();

                _productList = new ObservableCollection<ProductInfoNJ>();
                for (Iterator i = productManager.getAllProducts().iterator(); i.hasNext(); )
                {
                    ProductInfo pInfo = (ProductInfo)i.next();
                    ProductInfoNJ pInfoNJ = new ProductInfoNJ();
                    pInfoNJ.Name = pInfo.getName();
                    pInfoNJ.Code = pInfo.getCode();
                    pInfoNJ.Price = pInfo.getUnitPrice();
                    _productList.Add(pInfoNJ);
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

            ProductInfo productInfo = new ProductInfo();
            productInfo.setName(ProductName);
            productInfo.setCode(ProductCode);
            productInfo.setUnitPrice(Price);
            //productInfo1.setLength("c1");
            //productInfo1.setWidth("d1");
            //productInfo1.setHeight("e1");
            //productInfo1.setWeight("f1");

            ProductManager productManager = new ProductManager();
            productManager.createProduct(productInfo);


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
        public void OnDeactivate()
        {
            MessageBox.Show("OnDeactivate");
        }

        public static void OnProductChange()
        {
            //ProductName = "sdfsdf";
            MessageBox.Show("OnDeactivate");
        }

        public void selectProductEvent(ProductInfoNJ p)
        {
            this.ProductName = p.Name;
            this.ProductCode = p.Code;
        }

    }
}
