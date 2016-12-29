using Ribbon.Model;
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

namespace Ribbon.View
{
    /// <summary>
    /// Interaction logic for PurchaseOrderInfo.xaml
    /// </summary>
    public partial class PurchaseOrderInfo : UserControl
    {
        public PurchaseOrderInfo()
        {
            InitializeComponent();
        }
        private void productPurchaseOrderGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            ProductInfoNJ productInfo = (ProductInfoNJ)e.Row.Item;
            if (String.IsNullOrEmpty(productInfo.Name))
            {
                Popup productSelector = (Popup)grid.FindName("productSelector");

                productSelector.PlacementTarget = grid.GetCell(e.Row.GetIndex(), e.Column.DisplayIndex);
                productSelector.IsOpen = true;
            }


        }

        private void productPurchaseOrderGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            Popup productSelector = (Popup)grid.FindName("productSelector");
            productSelector.IsOpen = false;
        }

        private void TextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            Popup supplierSelector = (Popup)FindName("SupplierSelector");

            if (supplierSelector.IsOpen)
            {
                supplierSelector.IsOpen = false;
            }
            else
            {
                supplierSelector.IsOpen = true;
            }


        }

        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SupplierSelector.IsOpen = false;
        }

    }
}

