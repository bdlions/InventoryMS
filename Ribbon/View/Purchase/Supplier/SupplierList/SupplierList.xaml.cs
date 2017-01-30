using System;
using Ribbon.Model;
using Ribbon.View.Purchase.Supplier.NewSupplier;
using Prism.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ribbon.View.Purchase.Supplier.SupplierList
{
    /// <summary>
    /// Interaction logic for SupplierList.xaml
    /// </summary>
    public partial class SupplierList : UserControl
    {
        public SupplierList()
        {
            InitializeComponent();
        }
        public event EventHandler Changed;    // the Event
        private void dgDownloadsInfo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is DataGrid)
            {
                DataGrid grid = (DataGrid)sender;
                if (grid.SelectedItems.Count > 1)
                {
                    MessageBox.Show("Please select one item at a time.");
                    return;
                }

            }
        }
    }
}
