   M S B A M L   `   `   `  ����	  MyPos    MyPos.AdminDashBoard   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $	��900��5   	   $
��1600��6     � WindowStyle$
  none=�6#    � WindowState$ 	Maximized=�66    � AllowsTransparency$ false��6N   .��5	      �� .+�5
   
   � 
����� �$
��auto��6!   $��50��6.   .+�5      �� $��Admin Dashboard��6   $��Center=�6/   $
��Left=�6J   $��30 0 0 0q�6e   $��16(�6w   
�������6�   �� 5      -   5         ��Name$ btnClose��5      $��Right=�6'   ��6C   Z� ��6Z   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ power=�6*    � ToolTip$
 Exit��67   $��20��6F   $��20��6Q   $��0q�6]   5      5      � 5   
   
��� � �$
��auto��6"   $��40��6/    � ColumnDefinitions 5      �� 5      $	��150 �6#   �� 5      $	��150 �6#   �� 5      $	��150 �6#   �� 5      $	��150 �6#   �� 5      $	��150 �6#   �� 5      $	��15* �6#   �� 5      $��* �6#   .+�5      �� -   5        0��$��0��5      $��Product��6/   $	��150��6n   $
��Left=�6z   ��6A   Z� ��6X   Z� 6�   �� 5      -   5        1��$��1��5      $��Report��6/   $	��150��6m   $
��Left=�6y   ��6@   Z� ��6W   Z� 6�   �� 5      -   5        2��$��2��5      $��Transaction��6/   $	��150��6r   $
��Left=�6~   ��6E   Z� ��6\   Z� 6�   �� 5      -   5        3��$��3��5      $��Manage Users ��6/   $	��150��6t   $
��Left=�6�   ��6G   Z� ��6^   Z� 6�   �� 5      -   5        4��$��4��5      $��Backup ��6/   $	��150��6n   $
��Left=�6z   ��6A   Z� ��6X   Z� 6�   �� 5       -   5        $ 	BtnLogout��5       $��6��6(   $ Logout��6c   $��0q�6�   ��68   0  *MaterialDesignThemes.Wpf.PackIconExtension  *logout+��6t   Z� ��6�   Z� 6�   5!      � 5"   
   -   5         �Name$ 	tabslider��5"      $	��150��6"   $��4��6.   $
��Left=�69   
���   �6i   � 5$   
   .+�5%      � -	   5        $ gridswitcher1��5%      $��0 10 0 0q�6*   � 5&      -
   5        $ gridswitcher2��5&      $��0 10 0 0q�6*   � 5'      -   5        $ gridswitcher3��5'      $��0 10 0 0q�6*   � 5(      -   5        $ gridswitcher4��5(      $��0 10 0 0q�6*   � 5)      -   5        $ gridswitcher5��5)      $��0 10 0 0q�6*   5*      5+      5,      