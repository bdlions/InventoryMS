   M S B A M L   `   `   `  ����
  Ribbon#    Ribbon.View.new_customer_info   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4ms%http://namespaces.mindscape.co.nz/wpf     5      .��5	      � $��5q�6     � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $	��327 �6   �� 5      $	��327 �6   .+�5   
   �� $��0��6   $��0��6      Sales_ForeBackground#��[  6-   $
��Bold"�6`   $��16(�6r   $��Basic��6�   �� 5   
   $��0��6   $��1��6   #��[  6-   $
��Bold"�6`   $��16(�6r   $��Address��6�   $��19,0,0,0q�6�   �� 5   
   $��First Name:��6   $
��Left=�6&   $��	10,12,0,0q�6A   $��1��6T   $	��Top=�6a   $��77��6y   $��23��6�   �� 5   
   $
��Left=�6   $��23��6-   $��	87,12,0,0q�69   $��1��6L    �� TextWrapping$
 Wrap=�6Y   $	��Top=�6m   $	��185��6�   ��6�   �� *CustomerFirstName+�� 5   
   $��
Last Name:��6   $
��Left=�6%   $��	10,46,0,0q�6@   $��1��6S   $	��Top=�6`   $��77��6x   $��23��6�   �� 5   
   $
��Left=�6   $��23��6-   $��	87,46,0,0q�69   $��1��6L   $
 Wrap=�6Y   $	��Top=�6m   $	��185��6�   ��6�   �� *CustomerLastName+�� 5   
   $��Balance:��6   $
��Left=�6#   $��	10,80,0,0q�6>   $��1��6Q   $	��Top=�6^   $��77��6v   $��23��6�   �� 5   
   $
��Left=�6   $��23��6-   $��	87,80,0,0q�69   $��1��6L   $
 Wrap=�6Y   $	��Top=�6m   $	��185��6�    �� 
IsReadOnly . ��6�   �� *CustomerBalance+6�   �� 5   
   #��[  6   $
��Bold"�6F   $��19,10,28,155q�6X   $��1��6n   $��1��6~   $��23��6�   .@�5      ��  �� 
IsSelected . $��Business Address��6-   �� 5      $ ��Billing Address (Optional)��6   �� 5      $!��Shopping Address (Optional)��6   �� 5      �� 5       $��Add new Address��6   5!      �� 5"   
   $
��Left=�6   $��80��6-   $��	19,46,0,0q�69   $��1��6L   $
 Wrap=�6Y    �� AcceptsReturn . $	��Top=�6�   $	��280��6�   $��1��6�   ��6�   �� *CustomerAddress+�� 5%   
   $��1��6   $��0��6   #��[  6-   $
��Bold"�6`   $��16(�6r   $��Contact��6�   $��0,155,0,-18q�6�   �� 5&   
   $��Name:��6   $
��Left=�6    $��10,214,0,-192q�6;   $��1��6R   $	��Top=�6_   $��77��6w   $��23��6�   �� 5'   
   $
��Left=�6   $��23��6-   $��87,214,0,-177q�69   $��1��6P   $
 Wrap=�6]   $	��Top=�6q   $	��185��6�   ��6�   ��  �� Path$ CustomerName��� 5(   
   $��Phone:��6   $
��Left=�6!   $��10,248,0,-208q�6<   $��1��6S   $	��Top=�6`   $��77��6x   $��23��6�   �� 5)   
   $
��Left=�6   $��23��6-   $��87,248,0,-212q�69   $��1��6P   $
 Wrap=�6]   $	��Top=�6q   $	��185��6�   ��6�   �� *CustomerPhone+�� 5*   
   $
��Fax:��6   $
��Left=�6   $��10,282,0,-243q�6:   $��1��6Q   $	��Top=�6^   $��77��6v   $��25��6�   �� 5+   
   $
��Left=�6   $��25��6-   $��87,282,0,-249q�69   $��1��6P   $
 Wrap=�6]   $	��Top=�6q   $	��185��6�   ��6�   �� *CustomerFax+�� 5,   
   $��Email:��6   $
��Left=�6!   $��10,319,0,-279q�6<   $��1��6S   $	��Top=�6`   $��77��6x   $��25��6�   �� 5-   
   $
��Left=�6   $��25��6-   $��87,319,0,-276q�69   $��1��6P   $
 Wrap=�6]   $	��Top=�6q   $	��185��6�   ��6�   �� *CustomerEmail+�� 5.   
   $��Website:��6   $
��Left=�6#   $��10,359,0,-306q�6>   $��1��6U   $	��Top=�6b   $��77��6z   $��25��6�   �� 5/   
   $
��Left=�6   $��25��6-   $��87,359,0,-307q�69   $��1��6P   $
 Wrap=�6]   $	��Top=�6q   $	��185��6�   ��6�   �� *CustomerWebsite+�� 53   
   $��1��6   $��1��6   #��[  6-   $
��Bold"�6`   $��16(�6r   $��Purchasing Info��6�   $��19,155,0,-18q�6�   �� 54   
   $��Pricing/Currency:��6   $
��Left=�6,   $��19,214,0,-88q�6G   $��1��6]   $	��Top=�6j   $	��104��6�   $��28��6�   $��1��6�   �� 55   
   #��[  6   $
��Bold"�6F   $��128,216,28,-49q�6X   $��1��6p   $��1��6�   $��23��6�   .@�56      ��  . $��Normal Price��6-   �� 57      $��Add New��6   58      �� 5:   
   $��Payment Terms:��6   $
��Left=�6)   $��19,287,0,-159q�6D   $��1��6[   $	��Top=�6h   $	��104��6�   $��28��6�   $��1��6�   �� 5;   
   #��[  6   $
��Bold"�6F   $��128,287,28,-113q�6X   $��1��6q   $��1��6�   $��23��6�   .@�5<      ��  . $��Business Address��6-   �� 5=      $��Billing Address��6   �� 5>      $��Shopping Address��6   �� 5?      �� 5@      $��Add new Address��6   5A      �� 5D   
   $��Taxing Scheme:��6   $
��Left=�6)   $��19,316,0,-187q�6D   $��1��6[   $	��Top=�6h   $	��104��6�   $��28��6�   $��1��6�   �� 5E   
   #��[  6   $
��Bold"�6F   $��128,321,28,-150q�6X   $��1��6q   $��1��6�   $��23��6�   .@�5F      ��  . $��Business Address��6-   �� 5G      $��Billing Address ��6   �� 5H      $��Shopping Address��6   �� 5I      �� 5J      $��Add new Address��6   5K      �� 5L   
   $��	Discount:��6   $
��Left=�6$   $��19,253,0,-121q�6?   $��1��6V   $	��Top=�6c   $��77��6{   $��23��6�   $��1��6�   �� 5M   
   $
��Left=�6   $��24��6-   $��128,255,0,-78q�69   $��1��6P   $
 Wrap=�6]   $��Center=�6q   $	��171��6�   $��1��6�   $
��Bold"�6�    �� TextAlignment$ Right=�6�   ��6�   �� *CustomerDiscount+6�   �� 5O   
   $��Tax Exempt:��6   $
��Left=�6&   $��19,359,0,-226q�6A   $��1��6X   $	��Top=�6e   $��77��6}   $��25��6�   $��1��6�    J� RenderTransformOrigin$ 0.607,0.512&�6�   �� 5P   
   $
��Left=�6   $��25��6-   $��128,359,0,-182q�69   $��1��6Q   $
 Wrap=�6^   $	��Top=�6r   $	��171��6�   $��1��6�   ��6�   �� *CustomerTaxExempt+�� 5R   
   $��1��6   $��0��6   #��[  6-   $
��Bold"�6`   $��16(�6r   $��Remarks��6�   $��0,402,0,-255q�6�   �� 5S   
   $
��Left=�6   $��50��6-   $��10,440,0,-305q�69   $��1��6P   $
 Wrap=�6]    . $	��Top=�6�   $	��262��6�   ��6�   �� *CustomerRemark+5V      5W      