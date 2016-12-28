﻿using System;
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
    /// Interaction logic for SaleOrderCustomerSelector.xaml
    /// </summary>
    public partial class SaleOrderCustomerSelector : Popup
    {
        public SaleOrderCustomerSelector()
        {
            InitializeComponent();
        }


        private void customerSelectionGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            IsOpen = false;
        }

        private void customerSelectionGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IsOpen = false;
        }


    }
}
