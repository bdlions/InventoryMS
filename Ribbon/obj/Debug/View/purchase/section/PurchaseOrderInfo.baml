   M S B A M L   `   `   `  ����A  =Ribbon, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Ribbon.View.PopUpWindowRibbon.View.PopUpWindow  5      #    Ribbon.View.PurchaseOrderInfo   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :popupbox%clr-namespace:Ribbon.View.PopUpWindow     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      .command http://www.galasoft.ch/mvvmlight  5      .��5      � $��5q�6   .+�5   
   � $
��Left=�6     � RowDefinitions  5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $	��100 �6     � ColumnDefinitions 5      �� 5      $��70 �6#   �� 5      $	��160 �6#   �� 5      $��65 �6#   �� 5      $	��125 �6#   �� 5      $��15 �6#   �� 5      $��75 �6#   �� 5      $	��145 �6#   .+�5      �� $��0��6   $��0��6!   $	��Top=�61      Purchase_ForeBackground#��[  6I   $
��Bold"�6   $��Supplier��6�   $��2��6�   $��	0,0,157,0q�6�   �� 5      -   5        $��0��5      $��1��6#   $	��3,1q�63   ��6@   �� *SupplierName+6^   �� 5!      .+�5"      �� .+�5#      ;   5Ribbon.View.PopUpWindow.PurchaseOrderSupplierSelector  -   5          Name$ SupplierSelector��5#   >   5$      5%      �� 5)      $��0��6   $��2��6!   #��[  61   $
��Bold"�6g   $��Location��6y   �� 5*      $��0��6   $��3��6#   $��0,1,1,1q�63   ��6D   �� *
Location+�� 5+      $��0��6   $��5��6!   #��[  61   $
��Bold"�6g   $��Order��6y   �� 5,      $��0��6   $��6��6#   $��5,1,6,1q�63    �� 
IsReadOnly . ��6D   �� *Order+6[   �� 5/      $��1��6   $��0��6!   #��[  61   $
��Bold"�6g   $��Contact��6y   $	��0,7q�6�   �� 50      $��1��6   $��1��6#   $��3,8,3,11q�63   ��6E   �� *	Contact+�� 51      $��1��6   $��5��6!   $
��Left=�61   $��0,8,2,11q�6L   #��[  6^   $
��Bold"�6�   $��
Order Date��6�   �� 54      $��2��6   $��0��6!   $��1,0,3,19q�61   #��[  6C   $
��Bold"�6y   $��Phone��6�   �� 55      $��2��6   $��1��6#   $��3,0,3,19q�63   ��6E   �� *Phone+�� 56      $��2��6   $��5��6!   #��[  61   $
��Bold"�6g   $��Status��6y   $��0,0,0,19q�6�   �� 57      $��2��6   $��6��6#   $��5,0,6,19q�63    . ��6E   �� *Status+6]   �� 5:      $��1��6   $��2��6!   #��[  62   $
��Bold"�6h   $��Address��6z   $��2��6�   $��
2,7,118,10q�6�   �� 5;      $��1��6   $��3��6#   $��0,8,0,11q�63    �� TextWrapping$
 Wrap=�6E    �� AcceptsReturn . ��6n   �� *	Address+(  "System.Windows.Controls.DatePicker  5<      $��6��6   $
��Left=�6)   $��5,8,0,0q�6D   $��1��6U   $	��Top=�6b   $	��134��6z   $��1q�6�   5=      �� 5?   
   .+�5@      �� .+�5A      &   System.Windows.Controls.DataGrid  -   5        $��productPurchaseOrderGrid��5A      $��2��6;   $��0��5B      $	��645��6+   $��	5 150 5 0q�67   $
��Left=�5C         AutoGenerateColumns .     CanUserAddRows .    CanUserDeleteRows .  	   CanUserReorderColumns	 .  
   CanUserResizeColumns
 .  ��. $
��Auto=�5H      $��Disabled=�5I      $	��235��5J         CanUserResizeRows .     CanUserSortColumns .     SelectionMode$ Single=�5K   6   
�������  Sales_ForeBackground#��[ 5M      ��5L      �� *PurchaseList+.  (System.Windows.Interactivity.Interaction   Triggers 5R      /  )System.Windows.Interactivity.EventTrigger  5S         	EventName$ SelectionChanged��6)   .  (System.Windows.Interactivity.TriggerBase   Actions. 5T      6  0System.Windows.Interactivity.InvokeCommandAction     Command 64   �� *SelectedItemChangedCommand+   CommandParameter 5U   4   ��  �� ElementName$ productPurchaseOrderGrid�� �� Path$ SelectedItem�5V         Columns 5Y      0  *System.Windows.Controls.DataGridTextColumn  5Z      ,	  &System.Windows.Controls.DataGridColumn 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$	 195
 6-    	  Header$
 Item��69      
FontFamily$ Arial)�6G   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6Z   �� $
 Name�  5[      $ 90
 6-   $ Quantity��69   $ Arial)�6K    6^   �� $ Quantity�  5\      $ 90
 6-   $ 
Unit Price��69   $ Arial)�6M    6`   �� $ Price�  5]      $ 90
 6-   $ Discount��69   $ Arial)�6K    6^   �� $ Discount�  5^      $ 90
 6-   $ 	Sub-Total��69   $ Arial)�6L    6_   �� $ OrderItemSubTotal�  5_      $ 90
 6-   $ 	ProductId��69   $ Arial)�6L   5a      :   4Ribbon.View.PopUpWindow.PurchaseOrderProductSelector  5b      -   5          Name$ productSelector��5b   9   5c      5d      � 5�   
   $��	5,415,5,5q�6   $
��Left=�6"     5�      �� 5�      $
��Auto �6    �� 5�      $
��Auto �6    �� 5�      $
��Auto �6     5�      �� 5�      $	��120 �6#   �� 5�      $	��100 �6#   �� 5�      $��15 �6#   �� 5�      $��60 �6#   �� 5�      $	��160 �6#   �� 5�      $��15 �6#   �� 5�      $��65 �6#   �� 5�      $	��110 �6#   .+�5�      �� $��0��6   $��0��6!   #��[ 61   $
��Bold"�6d   $��Taxing Scheme��6v   $��0,0,0,46q�6�   �� 5�      $��0��6   $��1��6$   #��[ 64   $
��Bold"�6g   $��0,0,0,53q�6y   $��23��6�   .@�5�      ��  �� 
IsSelected . $��No Tax��61   �� 5�      $��Add New��6   5�      �� 5�      $��0��6   $��3��6!   #��[ 61   $
��Bold"�6d   $��Remarks��6v   �� 5�      $��0��6   $��4��6#   $
 Wrap=�63    . $��0,0,0,15q�6\   $��60��6n   ��6z   �� *OrderRemark+�� 5�      $��0��6   $��6��6!   #��[ 61   $
��Bold"�6d   $��	Sub-Total��6v   �� 5�      $��0��6   $��7��6%   $
��Bold"�6Z   $
��Left=�6l   $��
0,4,-14,58q�6�   ��65   �� *OrderSubTotalAmount+6�   �� 5�      $��0��6   $��0��6!   #��[ 61   $
��Bold"�6d   $��Non-Supplier Costs��6v   $��	0,24,0,22q�6�   �� 5�      $��0��6   $��1��6#   $��	0,26,0,28q�63   ��6F   �� *NonSupplierCost+�� 5�      $��1��6   $��4��6"   $��70��62   $��22��6=   $��Right=�6I   $
��Save��6e   $
��Bold"�6t     DarkBackground#��[ 5�      
�������$��0,5,0,1q�5�   (   ��5�      �� *SavePurchase+5�   (   �� 5�      $��0��6   $��6��6!   #��[ 61   $
��Bold"�6d   $��Total��6v   $��	0,28,0,-6q�6�   $��3��6�   �� 5�      $��0��6   $��7��6%   $��0,33,-14,22q�65   $
��Bold"�6l   $
��Left=�6~   ��6J   �� *OrderTotalAmount+6~   �� 5�      $��0��6   $��0��6!   #��[ 61   $
��Bold"�6d   $��Currency��6v   $��0,50,0,0q�6�   �� 5�      #��[ 6   $
��Bold"�6J   $��0��6\   $��1��6i   $��0,51,0,0q�6y   $��23��6�   $��11(�6�   .@�5�      �� $��Ugandan Shilling (USh)��6   �� 5�      $��UK Pound (£)��6   �� 5�      $��Ukrainian Hryvnia (rpH.)��6   �� 5�       . $��US Dollar ($)��61   �� 5�      $��Venezuelan Bolivar (Bs)��6   �� 5�      $��Vietnamese Dong (₫)��6   �� 5�      $$��West African CFA France (FCFA)��6   �� 5�      $��Zimbian Kwacha (ZK)��6   �� 5�      $��Add New��6   5�      5      5     5     