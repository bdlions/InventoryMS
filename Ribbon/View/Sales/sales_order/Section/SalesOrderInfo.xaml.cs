using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ribbon.util;
using Ribbon.Model;

namespace Ribbon.View
{
    /// <summary>
    /// Interaction logic for SalesOrderInfo.xaml
    /// </summary>
    public partial class SalesOrderInfo : UserControl
    {
        public SalesOrderInfo()
        {
            InitializeComponent();
        }

        private void productSaleOrderGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            DataGrid grid = (DataGrid) sender;
            ProductInfoNJ productInfo = (ProductInfoNJ)e.Row.Item;
            if (String.IsNullOrEmpty(productInfo.Name)) {
                Popup productSelector = (Popup)grid.FindName("productSelector");

                productSelector.PlacementTarget = grid.GetCell(e.Row.GetIndex(), e.Column.DisplayIndex);
                productSelector.IsOpen = true;
            }
            
            
        }

        private void productSaleOrderGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            Popup productSelector = (Popup)grid.FindName("productSelector");
            productSelector.IsOpen = false;
            
        }


        private void CustomerTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Popup customerSelector = (Popup)FindName("CustomerSelector");
            if (customerSelector.IsOpen)
            {
                customerSelector.IsOpen = false;
            }
            else
            {
                customerSelector.IsOpen = true;
            }

        }

        //private void LocationTextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    Popup supplierSelector = (Popup)FindName("LocationSelector");
        //    if (supplierSelector.IsOpen)
        //    {
        //        supplierSelector.IsOpen = false;
        //    }
        //    else
        //    {
        //        supplierSelector.IsOpen = true;
        //    }

        //}

    }
}
