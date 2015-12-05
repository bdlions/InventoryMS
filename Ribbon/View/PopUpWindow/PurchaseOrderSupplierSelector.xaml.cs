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

namespace Ribbon.View.PopUpWindow
{
    /// <summary>
    /// Interaction logic for PurchaseOrderSupplierSelector.xaml
    /// </summary>
    public partial class PurchaseOrderSupplierSelector : Popup
    {
        public PurchaseOrderSupplierSelector()
        {
            InitializeComponent();
        }

        private void supplierSelectionGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            IsOpen = false;
        }

        private void supplierSelectionGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IsOpen = false;
        }
    }
}
