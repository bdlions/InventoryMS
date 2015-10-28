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
            subMenuHomePage.Click += onClickSubMenuHomePage;
            subMenuDashboard.Click += onClickSubMenuDashboard;
        }

        private void onClickSubMenuDashboard(object sender, RoutedEventArgs e)
        {
            if (RibbonContainer.SelectedItem is RibbonTab)
            {
                RibbonTab selectedTab = (RibbonTab)RibbonContainer.SelectedItem;
                selectedTab.Items.Clear();
                selectedTab.Header = "Dashboard";

                selectedTab.Margin = new Thickness(0, 0, -200, -727);

                RibbonGroup dashboardTabGroup = new RibbonGroup();
                dashboardTabGroup.Background = (Brush)FindResource("Purchase");

                UserControl dashboardTabContent = new ManageSupplier();

                dashboardTabGroup.Items.Add(dashboardTabContent);
                selectedTab.Items.Add(dashboardTabGroup);
            }
        }

        private void onClickSubMenuHomePage(object sender, RoutedEventArgs e)
        {
            if(RibbonContainer.SelectedItem is RibbonTab){
                RibbonTab selectedTab = (RibbonTab)RibbonContainer.SelectedItem;
                selectedTab.Items.Clear();
                selectedTab.Header = "Home";

                selectedTab.Margin = new Thickness(0, 0, -100, -627);

                RibbonGroup homeTabGroup = new RibbonGroup();
                homeTabGroup.Background = (Brush)FindResource("HomePage");

                UserControl homeTabContent = new HomePage();
                homeTabContent.Margin = new Thickness(50, 200, 0, 0);

                homeTabGroup.Items.Add(homeTabContent);
                selectedTab.Items.Add(homeTabGroup);

                
            }
            
        }

        private void onClickTabCreationButton(object sender, RoutedEventArgs e)
        {

            RibbonButton tabCreationButton = (RibbonButton)RibbonContainer.Items.GetItemAt(RibbonContainer.Items.Count - 1);

            RibbonTab homeTab = new RibbonTab() { Header = "Home" };
            homeTab.Margin = new Thickness(0, 0, -100, -627);

            RibbonGroup homeTabGroup = new RibbonGroup();
            homeTabGroup.Background = (Brush)FindResource("HomePage");

            UserControl homeTabContent = new HomePage();
            homeTabContent.Margin = new Thickness(50, 200, 0, 0);
            
            homeTabGroup.Items.Add(homeTabContent);
            homeTab.Items.Add(homeTabGroup);

            RibbonContainer.Items.Remove(tabCreationButton);
            RibbonContainer.Items.Add(homeTab);
            RibbonContainer.Items.Add(tabCreationButton);

        }


    }
}
