   M S B A M L   `   `   `  ����@  <MyPos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MyPosMyPos  5          MyPos.SalesReturnControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:MyPos     5      S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5	      � 
�������$
��auto��6   $
��auto��6+   $��150 20 150 0q�69     � ColumnDefinitions  5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $	��120 �6   .+�5   
   �� $��0��6   .+�5      �� $��Find information��6   $
��Left=�60   $��
100 25 0 0q�6K   $��12(�6_   � 5      $��
20 10 20 0q�6   $	��250��6'   $��40��63   .+�5      �� $	��250��6   
�������$��1q�68    �� CornerRadius$ 5��6L   $��40��6]   � 5        5      �� 5      $��* �6+   �� 5      $��2* �6+   .+�5      �� $��0��6    $��Bill Number��60   $
��Left=�6C   $��15 0 0 0q�6^   $��12(�6p   $��Center=�6~   �� 5      -   5         ��Name$ 	txtbillNo��5      $��1��61   $	��150��6A   $��12(�6M   $��Center=�6   ��6�   Z� 5      5      �� 5      -   5         ��Name$ btnFind��5         MaterialDesignRaisedButton#���   6&   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 6��6[   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth1=�6�   
���� ��$	��100��6�   $��40��6�   $
��Find��6�   
�������$��0 20 0 0q�6  $��Center=�6  $��Center=�65  $��Arial)�6R  6e  �� 5       $��Bill information��6   $��Center=�60   $��0 10 0 0q�6M   $��14(�6_   � 5!      $	��250��6   $��40��6#     5"      �� 5#      $��* �6+   �� 5$      $��2* �6+   .+�5&      �� $��0��6    $�� Billed Date��60   $
��Left=�6D   $��	15 10 0 0q�6_   $��12(�6r   �� 5'      -   5        $ txtDate��5'      $��1��6/   $	��200��6?   $��14(�6K    �� 
IsReadOnly$
 True��6Y   ��6k   Z� 5(      &   System.Windows.Controls.DataGrid  5*      -   5          Name$ grdBill��5*   B   $��
20 10 20 0q�6   
�������$	��400��6S   $	��350��6_      AutoGenerateColumns$ False��6l   -  'MaterialDesignThemes.Wpf.DataGridAssist	   CellPadding$	 8 5 0 5q�6�   
�������$��1q�6�   
   CanUserResizeColumns$
 False��6  $   HorizontalScrollBarVisibility$ Disabled=�6,     ColumnHeaderStyle 5+      �� 5,       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5-      ��  �� Property � �� �� Value$
 left=�6G   �� 5.       � ��$ 8 0 0 0q�64   �� 5/       � ��
 �����67   �� 50       � ��$ 35��63   51         Columns 53      0  *System.Windows.Controls.DataGridTextColumn  54      ,  &System.Windows.Controls.DataGridColumn   Header$ Description��6)      FontSize$ 11Q�6^      Width5  /System.Windows.Controls.DataGridLengthConverter$	 110 6l   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6>   �� *description+6l     55      $ 
Unit Price��6-   $ 80 6_    6A   �� *	unitprice+6_     56      $ Quantity��6-   $ 70 6\    6?   �� *
quantity+6\     57      $ 	Sub total��6-   $ 70 6]    6@   �� *
subtotal+6]     58      $ Discount��6-   $ 70 6\    6?   �� *
discount+6\   5:      5;      �� 5<   
   $��1��6   .+�5=      �� $��Return Quantity��6   $
��Left=�6/   $��
100 25 0 0q�6J   � 5>      $��
20 10 20 0q�6   $	��250��6'   $��40��63   .+�5?      �� $	��250��6   
�������$��1q�69   $��40��6M   $ 5��6Y   � 5@        5A      �� 5B      $��* �6+   �� 5C      $��2* �6+   .+�5E      �� $��0��6    $��Quantity��60   $
��Left=�6@   $��	15 10 0 0q�6[   $��12(�6n   �� 5F      -   5        $ txtQuantityReturn��5F      $��1��69   $	��150��6I   $��12(�6U   ��6�   Z� 5G      5H      � 5J      $��
20 20 20 0q�6   $	��350��6'     5K      �� 5L      $��* �6'   �� 5M      $��* �6'   �� 5N      $��* �6'   .+�5P      �� -   5        $ 	btnRemove��5P   )   $��1��6   #���   6<   $ 6��6q   $ Depth1=�6�   
���� ��$	��100��6�   $��40��6�   $��Remove��6�   
�������$��Center=�6   $��Center=�6;  $��Arial)�6X  6k  �� 5Q      -   5        $ btnAdd��5Q   )   $��0��6   #���   69   $ 6��6n   $ Depth1=�6�   
���� ��$	��100��6�   $��40��6�   $	��Add��6�   
�������$��Center=�6  $��Center=�66  $��Arial)�6S  6f  �� 5R      -   5        $ 
btnconfirm��5R   *   $��2��6   #���   6>   $ 6��6s   $ Depth1=�6�   
���� ��$	��100��6�   $��40��6�   $��Confirm��6�   
�������$��Center=�6$  $��Center=�6?  $��Arial)�6\  6o  5T        5W      -	   5        $ grdReturnDetails��5W   C   
�������$��20 80 20 0 q�6.   $	��400��6]   $	��350��6i   $
 False��6w      CanUserAddRows$
 True��6�      HeadersVisibility$ Column=�6�      GridLinesVisibility$	 All=�6�      HorizontalGridLinesBrush
 �   �$	 8 5 0 5q�65  $ Disabled=�6j  
�������$��2q�6�   5X      �� 5Y      "  6   .�5Z      ��  � ��$
 left=�6G   �� 5[       � ��$ 8 0 0 0q�64   �� 5\       � ��
 �����67   �� 5]       � ��$ 35��63   5^       5`        5a      $ 80 6)   $ 
Product ID��64      
IsReadOnly$
 True��6H   $ 12Q�6v    6Z   ��  �� Path$ p1�6v     5b      $	 100 6*   $ Description��66   $
 true��6K   $ 12Q�6y    6]   �� $ p2�6y     5c      $ 80 6*   $ 
Unit Price��65   $
 true��6I   $ 12Q�6w    6[   �� $ p4�6w     5d      $ 70 6*   $ Quantity��65   $
 true��6G   $ 12Q�6u    6Y   �� $ p3�6u     5e      $ 90 6*   $ Total��65   $
 true��6D   $ 12Q�6r    6V   �� $ p5�6r   5g      5h      �� 5j   
   $��3��6   .+�5k      �� -
   5        $ btnBack��5k      $��12(�6&   $	��100��64   $��25��6@   
�������$ 4��6u   $ Depth0=�6�   
�������$	��Top=�6�   $��0 10 0 0q�6�    � ToolTip$ Back to Dashboard��6  .��5l      '
  !MaterialDesignThemes.Wpf.PackIcon
   
  Kind$ 	ArrowBack=�6*   $��15��6;   $��15��6F   
�������6R   5m      5n      5p      5q      