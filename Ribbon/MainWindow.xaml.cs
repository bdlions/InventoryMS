using Ribbon.Model;
using Ribbon.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using com.inventory.db.manager;

namespace Ribbon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            buttonAddTab.Click += onClickTabCreationButton;
            //buttonCloseTab.Click += onClickTabRemoveButton;
            subMenuHomePage.Click += onClickSubMenuHomePage;
            subMenuDashboard.Click += onClickSubMenuDashboard;
            //  subMenuSalesQuote.Click += onClickSubMenuSalesQuote;
            subMenuManageSupplier.Click += onClickSubManageSupplier;
            subMenuManageSupplierList.Click += onClickSubManageSupplierList;
            subMenuManageSalesOrderList.Click += onClickSubManageSalesOrderList;
            subMenuManagePurchageOrderList.Click += onClickSubManagePurchageOrderList;
            subMenuManagePurchageOrder.Click += onClicksubManagePurchageOrder;
            subMenuManageProductList.Click += onClicksubManageProductList;
            subMenuManageProduct.Click += onClicksubManageProduct;
            subMenuManageNewSalesOrder.Click += onClicksubManageNewSalesOrder;
            subMenuManageNewCustomer.Click += onClicksubManageNewCustomer;
            // subMenuManageMovementHistory.Click += onClicksubManageMovementHistory;
            subMenuManageCustomerList.Click += onClicksuManageCustomerList;
            subMenuManageCurrentStock.Click += onClicksuManageCurrentStock;
        }

        private void onClicksuManageCurrentStock(object sender, RoutedEventArgs e)
        {
            if (RibbonContainer.SelectedItem is RibbonTab)
            {
                RibbonTab selectedTab = (RibbonTab)RibbonContainer.SelectedItem;
                selectedTab.Items.Clear();
                selectedTab.Header = "Current Stock";

                selectedTab.Margin = new Thickness(0, 0, -200, -727);

                RibbonGroup ManageCurrentStockTabGroup = new RibbonGroup();
                ManageCurrentStockTabGroup.Background = (Brush)FindResource("Inventory");

                ContextMenu contextMenu = new ContextMenu();
                MenuItem closeMenuItem = new MenuItem();
                closeMenuItem.Header = "Close";
                closeMenuItem.Click += MenuItem_Click_1;
                contextMenu.Items.Add(closeMenuItem);
                ManageCurrentStockTabGroup.ContextMenu = contextMenu;

                UserControl ManageCurrentStockTabContent = new ManageCurrentStock();

                ManageCurrentStockTabGroup.Items.Add(ManageCurrentStockTabContent);
                selectedTab.Items.Add(ManageCurrentStockTabGroup);
            }
        }

        private void onClicksuManageCustomerList(object sender, RoutedEventArgs e)
        {
            if (RibbonContainer.SelectedItem is RibbonTab)
            {
                RibbonTab selectedTab = (RibbonTab)RibbonContainer.SelectedItem;
                selectedTab.Items.Clear();
                selectedTab.Header = "Customer List";

                selectedTab.Margin = new Thickness(0, 0, -200, -727);

                RibbonGroup ManageCustomerListTabGroup = new RibbonGroup();
                ManageCustomerListTabGroup.Background = (Brush)FindResource("Sales");
                ContextMenu contextMenu = new ContextMenu();
                MenuItem closeMenuItem = new MenuItem();
                closeMenuItem.Header = "Close";
                closeMenuItem.Click += MenuItem_Click_1;
                contextMenu.Items.Add(closeMenuItem);
                ManageCustomerListTabGroup.ContextMenu = contextMenu;

                UserControl ManageCustomerListTabContent = new ManageCustomerList();

                ManageCustomerListTabGroup.Items.Add(ManageCustomerListTabContent);
                selectedTab.Items.Add(ManageCustomerListTabGroup);
            }
        }

        private void onClicksubManageMovementHistory(object sender, RoutedEventArgs e)
        {
            if (RibbonContainer.SelectedItem is RibbonTab)
            {
                RibbonTab selectedTab = (RibbonTab)RibbonContainer.SelectedItem;
                selectedTab.Items.Clear();
                selectedTab.Header = "Movement History";

                selectedTab.Margin = new Thickness(0, 0, -200, -727);

                RibbonGroup ManageMovementHistoryTabGroup = new RibbonGroup();
                ManageMovementHistoryTabGroup.Background = (Brush)FindResource("Inventory");
                ContextMenu contextMenu = new ContextMenu();
                MenuItem closeMenuItem = new MenuItem();
                closeMenuItem.Header = "Close";
                closeMenuItem.Click += MenuItem_Click_1;
                contextMenu.Items.Add(closeMenuItem);
                ManageMovementHistoryTabGroup.ContextMenu = contextMenu;

                UserControl ManageMovementHistoryTabContent = new ManageMovementHistory();

                ManageMovementHistoryTabGroup.Items.Add(ManageMovementHistoryTabContent);
                selectedTab.Items.Add(ManageMovementHistoryTabGroup);
            }
        }

        private void onClicksubManageNewCustomer(object sender, RoutedEventArgs e)
        {
            if (RibbonContainer.SelectedItem is RibbonTab)
            {
                RibbonTab selectedTab = (RibbonTab)RibbonContainer.SelectedItem;
                selectedTab.Items.Clear();
                selectedTab.Header = "Customer";

                selectedTab.Margin = new Thickness(0, 0, -200, -727);

                RibbonGroup ManageNewCustomerTabGroup = new RibbonGroup();
                ManageNewCustomerTabGroup.Background = (Brush)FindResource("Sales");

                ContextMenu contextMenu = new ContextMenu();
                MenuItem closeMenuItem = new MenuItem();
                closeMenuItem.Header = "Close";
                closeMenuItem.Click += MenuItem_Click_1;
                contextMenu.Items.Add(closeMenuItem);
                ManageNewCustomerTabGroup.ContextMenu = contextMenu;

                UserControl ManageNewCustomerTabContent = new ManageNewCustomer();

                ManageNewCustomerTabGroup.Items.Add(ManageNewCustomerTabContent);
                selectedTab.Items.Add(ManageNewCustomerTabGroup);
            }
        }

        private void onClicksubManageNewSalesOrder(object sender, RoutedEventArgs e)
        {
            if (RibbonContainer.SelectedItem is RibbonTab)
            {
                RibbonTab selectedTab = (RibbonTab)RibbonContainer.SelectedItem;
                selectedTab.Items.Clear();
                selectedTab.Header = "Sales Order";

                selectedTab.Margin = new Thickness(0, 0, -200, -727);

                RibbonGroup ManageNewSalesOrderTabGroup = new RibbonGroup();
                ManageNewSalesOrderTabGroup.Background = (Brush)FindResource("Sales");

                ContextMenu contextMenu = new ContextMenu();
                MenuItem closeMenuItem = new MenuItem();
                closeMenuItem.Header = "Close";
                closeMenuItem.Click += MenuItem_Click_1;
                contextMenu.Items.Add(closeMenuItem);
                ManageNewSalesOrderTabGroup.ContextMenu = contextMenu;

                UserControl ManageNewSalesOrderTabContent = new ManageNewSalesOrder();

                ManageNewSalesOrderTabGroup.Items.Add(ManageNewSalesOrderTabContent);
                selectedTab.Items.Add(ManageNewSalesOrderTabGroup);
            }
        }

        private void onClicksubManageProduct(object sender, RoutedEventArgs e)
        {
            if (RibbonContainer.SelectedItem is RibbonTab)
            {
                RibbonTab selectedTab = (RibbonTab)RibbonContainer.SelectedItem;
                selectedTab.Items.Clear();
                selectedTab.Header = "Product";

                selectedTab.Margin = new Thickness(0, 0, -200, -727);

                RibbonGroup ManageProductTabGroup = new RibbonGroup();
                ManageProductTabGroup.Background = (Brush)FindResource("Inventory");

                ContextMenu contextMenu = new ContextMenu();
                MenuItem closeMenuItem = new MenuItem();
                closeMenuItem.Header = "Close";
                closeMenuItem.Click += MenuItem_Click_1;
                contextMenu.Items.Add(closeMenuItem);
                ManageProductTabGroup.ContextMenu = contextMenu;

                UserControl ManageProductTabContent = new ManageProduct();

                ManageProductTabGroup.Items.Add(ManageProductTabContent);
                selectedTab.Items.Add(ManageProductTabGroup);
            }
        }


        private void onClicksubManageProductList(object sender, RoutedEventArgs e)
        {
            if (RibbonContainer.SelectedItem is RibbonTab)
            {
                RibbonTab selectedTab = (RibbonTab)RibbonContainer.SelectedItem;
                selectedTab.Items.Clear();
                selectedTab.Header = "Product List";

                selectedTab.Margin = new Thickness(0, 0, -200, -727);

                RibbonGroup ManageProductListTabGroup = new RibbonGroup();
                ManageProductListTabGroup.Background = (Brush)FindResource("Inventory");

                ContextMenu contextMenu = new ContextMenu();
                MenuItem closeMenuItem = new MenuItem();
                closeMenuItem.Header = "Close";
                closeMenuItem.Click += MenuItem_Click_1;
                contextMenu.Items.Add(closeMenuItem);
                ManageProductListTabGroup.ContextMenu = contextMenu;

                UserControl ManageProductListTabContent = new ManageProductList();

                ManageProductListTabGroup.Items.Add(ManageProductListTabContent);
                selectedTab.Items.Add(ManageProductListTabGroup);
            }
        }


        private void onClicksubManagePurchageOrder(object sender, RoutedEventArgs e)
        {
            if (RibbonContainer.SelectedItem is RibbonTab)
            {
                RibbonTab selectedTab = (RibbonTab)RibbonContainer.SelectedItem;
                selectedTab.Items.Clear();
                selectedTab.Header = "Purchage Order";

                selectedTab.Margin = new Thickness(0, 0, -200, -727);

                RibbonGroup ManagePurchageOrderTabGroup = new RibbonGroup();
                ManagePurchageOrderTabGroup.Background = (Brush)FindResource("Purchase");

                ContextMenu contextMenu = new ContextMenu();
                MenuItem closeMenuItem = new MenuItem();
                closeMenuItem.Header = "Close";
                closeMenuItem.Click += MenuItem_Click_1;
                contextMenu.Items.Add(closeMenuItem);
                ManagePurchageOrderTabGroup.ContextMenu = contextMenu;

                UserControl ManagePurchageOrderTabContent = new ManagePurchageOrder();

                ManagePurchageOrderTabGroup.Items.Add(ManagePurchageOrderTabContent);
                selectedTab.Items.Add(ManagePurchageOrderTabGroup);
            }
        }

        private void onClickSubManagePurchageOrderList(object sender, RoutedEventArgs e)
        {
            if (RibbonContainer.SelectedItem is RibbonTab)
            {
                RibbonTab selectedTab = (RibbonTab)RibbonContainer.SelectedItem;
                selectedTab.Items.Clear();
                selectedTab.Header = "Purchage Order List";

                selectedTab.Margin = new Thickness(0, 0, -200, -727);

                RibbonGroup ManagePurchageOrderListTabGroup = new RibbonGroup();
                ManagePurchageOrderListTabGroup.Background = (Brush)FindResource("Purchase");

                ContextMenu contextMenu = new ContextMenu();
                MenuItem closeMenuItem = new MenuItem();
                closeMenuItem.Header = "Close";
                closeMenuItem.Click += MenuItem_Click_1;
                contextMenu.Items.Add(closeMenuItem);
                ManagePurchageOrderListTabGroup.ContextMenu = contextMenu;

                UserControl ManagePurchageOrderListTabContent = new ManagePurchageOrderList();

                ManagePurchageOrderListTabGroup.Items.Add(ManagePurchageOrderListTabContent);
                selectedTab.Items.Add(ManagePurchageOrderListTabGroup);
            }
        }

        private void onClickSubManageSupplierList(object sender, RoutedEventArgs e)
        {
            if (RibbonContainer.SelectedItem is RibbonTab)
            {
                RibbonTab selectedTab = (RibbonTab)RibbonContainer.SelectedItem;
                selectedTab.Items.Clear();
                selectedTab.Header = "Supplier List";

                selectedTab.Margin = new Thickness(0, 0, -200, -727);

                RibbonGroup ManageSupplierListTabGroup = new RibbonGroup();
                ManageSupplierListTabGroup.Background = (Brush)FindResource("Purchase");

                ContextMenu contextMenu = new ContextMenu();
                MenuItem closeMenuItem = new MenuItem();
                closeMenuItem.Header = "Close";
                closeMenuItem.Click += MenuItem_Click_1;
                contextMenu.Items.Add(closeMenuItem);
                ManageSupplierListTabGroup.ContextMenu = contextMenu;

                UserControl ManageSupplierListTabContent = new ManageSupplierList();

                ManageSupplierListTabGroup.Items.Add(ManageSupplierListTabContent);
                selectedTab.Items.Add(ManageSupplierListTabGroup);
            }
        }

        private void onClickSubManageSupplier(object sender, RoutedEventArgs e)
        {
            if (RibbonContainer.SelectedItem is RibbonTab)
            {
                RibbonTab selectedTab = (RibbonTab)RibbonContainer.SelectedItem;
                selectedTab.Items.Clear();
                selectedTab.Header = "Supplier";

                selectedTab.Margin = new Thickness(0, 0, -200, -727);

                RibbonGroup ManageSupplierTabGroup = new RibbonGroup();
                ManageSupplierTabGroup.Background = (Brush)FindResource("Purchase");

                ContextMenu contextMenu = new ContextMenu();
                MenuItem closeMenuItem = new MenuItem();
                closeMenuItem.Header = "Close";
                closeMenuItem.Click += MenuItem_Click_1;
                contextMenu.Items.Add(closeMenuItem);
                ManageSupplierTabGroup.ContextMenu = contextMenu;

                UserControl ManageSupplierTabContent = new ManageSupplier();

                ManageSupplierTabGroup.Items.Add(ManageSupplierTabContent);
                selectedTab.Items.Add(ManageSupplierTabGroup);
            }
        }


        private void onClickSubManageSalesOrderList(object sender, RoutedEventArgs e)
        {
            if (RibbonContainer.SelectedItem is RibbonTab)
            {
                RibbonTab selectedTab = (RibbonTab)RibbonContainer.SelectedItem;
                selectedTab.Items.Clear();
                selectedTab.Header = "Sales Order List";

                selectedTab.Margin = new Thickness(0, 0, -200, -727);

                RibbonGroup ManageSalesOrderListTabGroup = new RibbonGroup();
                ManageSalesOrderListTabGroup.Background = (Brush)FindResource("Sales");

                ContextMenu contextMenu = new ContextMenu();
                MenuItem closeMenuItem = new MenuItem();
                closeMenuItem.Header = "Close";
                closeMenuItem.Click += MenuItem_Click_1;
                contextMenu.Items.Add(closeMenuItem);
                ManageSalesOrderListTabGroup.ContextMenu = contextMenu;

                UserControl ManageSalesOrderListTabContent = new ManageSalesOrderList();

                ManageSalesOrderListTabGroup.Items.Add(ManageSalesOrderListTabContent);
                selectedTab.Items.Add(ManageSalesOrderListTabGroup);
            }
        }

        private void onClickSubMenuSalesQuote(object sender, RoutedEventArgs e)
        {
            if (RibbonContainer.SelectedItem is RibbonTab)
            {
                RibbonTab selectedTab = (RibbonTab)RibbonContainer.SelectedItem;
                selectedTab.Items.Clear();
                selectedTab.Header = "Sales Quote";

                selectedTab.Margin = new Thickness(0, 0, -200, -727);

                RibbonGroup SalesQuoteTabGroup = new RibbonGroup();
                SalesQuoteTabGroup.Background = (Brush)FindResource("Sales");

                ContextMenu contextMenu = new ContextMenu();
                MenuItem closeMenuItem = new MenuItem();
                closeMenuItem.Header = "Close";
                closeMenuItem.Click += MenuItem_Click_1;
                contextMenu.Items.Add(closeMenuItem);
                SalesQuoteTabGroup.ContextMenu = contextMenu;

                UserControl SalesQuoteTabContent = new ManageSalesQuote();

                SalesQuoteTabGroup.Items.Add(SalesQuoteTabContent);
                selectedTab.Items.Add(SalesQuoteTabGroup);
            }
        }


        private void onClickSubMenuDashboard(object sender, RoutedEventArgs e)
        {
            if (RibbonContainer.SelectedItem is RibbonTab)
            {
                RibbonTab selectedTab = (RibbonTab)RibbonContainer.SelectedItem;
                selectedTab.Items.Clear();
                selectedTab.Header = "Dashboard";

                selectedTab.Margin = new Thickness(0, 0, -100, -627);

                RibbonGroup dashboardTabGroup = new RibbonGroup();
                dashboardTabGroup.Background = (Brush)FindResource("HomePage");

                ContextMenu contextMenu = new ContextMenu();
                MenuItem closeMenuItem = new MenuItem();
                closeMenuItem.Header = "Close";
                closeMenuItem.Click += MenuItem_Click_1;
                contextMenu.Items.Add(closeMenuItem);
                dashboardTabGroup.ContextMenu = contextMenu;

                UserControl dashboardTabContent = new HomePage();
                dashboardTabContent.Margin = new Thickness(76, 200, 3, 0);

                dashboardTabGroup.Items.Add(dashboardTabContent);
                selectedTab.Items.Add(dashboardTabGroup);
            }
        }

        private void onClickSubMenuHomePage(object sender, RoutedEventArgs e)
        {
            if (RibbonContainer.SelectedItem is RibbonTab)
            {
                RibbonTab selectedTab = (RibbonTab)RibbonContainer.SelectedItem;
                selectedTab.Items.Clear();
                selectedTab.Header = "Home";

                selectedTab.Margin = new Thickness(0, 0, -100, -627);

                RibbonGroup homeTabGroup = new RibbonGroup();
                homeTabGroup.Background = (Brush)FindResource("HomePage");

                ContextMenu contextMenu = new ContextMenu();
                MenuItem closeMenuItem = new MenuItem();
                closeMenuItem.Header = "Close";
                closeMenuItem.Click += MenuItem_Click_1;
                contextMenu.Items.Add(closeMenuItem);
                homeTabGroup.ContextMenu = contextMenu;

                UserControl homeTabContent = new HomePage();
                homeTabContent.Margin = new Thickness(76, 200, 3, 0);

                homeTabGroup.Items.Add(homeTabContent);
                selectedTab.Items.Add(homeTabGroup);

            }

        }

        private void onClickTabCreationButton(object sender, RoutedEventArgs e)
        {

            Button tabCreationButton = (Button)RibbonContainer.Items.GetItemAt(RibbonContainer.Items.Count - 1);

            RibbonTab homeTab = new RibbonTab() { Header = "Home" };
            homeTab.Margin = new Thickness(0, 0, -100, -627);


            RibbonGroup homeTabGroup = new RibbonGroup();
            homeTabGroup.Background = (Brush)FindResource("HomePage");

            ContextMenu contextMenu = new ContextMenu();
            MenuItem closeMenuItem = new MenuItem();
            closeMenuItem.Header = "Close";
            closeMenuItem.Click += MenuItem_Click_1;
            contextMenu.Items.Add(closeMenuItem);
            homeTabGroup.ContextMenu = contextMenu;

            UserControl homeTabContent = new HomePage();
            homeTabContent.Margin = new Thickness(76, 200, 3, 0);

            homeTabGroup.Items.Add(homeTabContent);
            homeTab.Items.Add(homeTabGroup);

            RibbonContainer.Items.Remove(tabCreationButton);
            RibbonContainer.Items.Add(homeTab);
            RibbonContainer.SelectedItem = homeTab;
            RibbonContainer.Items.Add(tabCreationButton);

        }


        private void RibbonContainer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (RibbonContainer.SelectedItem is RibbonTab)
            {
                RibbonTab selectedTab = (RibbonTab)RibbonContainer.SelectedItem;
                RibbonContainer.Items.Remove(selectedTab);
            }
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            // MessageBox.Show("Windown loaded....");

            InitManager initManager = new InitManager();
            initManager.initConnection();
            if (RibbonContainer.SelectedItem is RibbonTab)
            {
                RibbonTab selectedTab = (RibbonTab)RibbonContainer.SelectedItem;
                selectedTab.Items.Clear();
                selectedTab.Header = "Home";

                selectedTab.Margin = new Thickness(0, 0, -100, -627);

                RibbonGroup homeTabGroup = new RibbonGroup();
                homeTabGroup.Background = (Brush)FindResource("HomePage");

                ContextMenu contextMenu = new ContextMenu();
                MenuItem closeMenuItem = new MenuItem();
                closeMenuItem.Header = "Close";
                closeMenuItem.Click += MenuItem_Click_1;
                contextMenu.Items.Add(closeMenuItem);
                homeTabGroup.ContextMenu = contextMenu;

                UserControl homeTabContent = new HomePage();
                homeTabContent.Margin = new Thickness(76, 200, 3, 0);

                homeTabGroup.Items.Add(homeTabContent);
                selectedTab.Items.Add(homeTabGroup);

            }
        }

    }

}
