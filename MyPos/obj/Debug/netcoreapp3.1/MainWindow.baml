   M S B A M L   `   `   `  ����@  <MyPos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MyPosMyPos  5   	       MyPos.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:MyPos     5   	   S OMaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $	��450��5	   	   $	��370��6     � 
ResizeMode$  NoResize=�6"    � WindowStartupLocation$ CenterScreen=�68    � WindowStyle$
 none=�6]    � AllowsTransparency$
 True��6p   
������ .��5
      � .+�5   
   �� $	��370��6   $	��450��6    
������� �� RadiusX$
 20px��6:    �� RadiusY$
 20px��6I   �� 5   
   .+�5      �� -   5         ��Name$ btnClose��5      $	��Top=�6'   $��Right=�6?   $��0q�6[   $��	0 15 20 0q�6g   ���#374047��6�   Z� ��6�   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Power=�6*   $��20��67   $��20��6C   5      �� 5      $��Login��6   $��20(�6&   $
��auto��65   $
��auto��6B   $��Center=�6P   $
��Left=�6k   $��	50 20 0 0q�6�   ���#3740476�   � 5      $	��240��6   $��30��6   $��0 50 0 0q�6A   $��Center=�6S   $��Center=�6n   ��6+   Z� .+�5      �� 
�������$	��240��6(   $ 15��64   $ 15��6A   $��30��6N    J� Opacity$	 0.1Q�6Z   �� 5      	 �� Orientation$	 
Horizontal=�6   .+�5        $
 user=�6.   $��	 10 5 5 5q�6:   $��Center=�6M   $��20��6h   $��20��6s   ���#3740476   �� 5      )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 User Id��6   $	��190��6G   $��14(�6j   $��2 0 0 0q�6x   $��Bottom=�6�   ��6S   Z� 6�   5      5      � 5      $	��240��6   $��40��6   $��0 30 0 0q�6A   $��Center=�6S   $��Center=�6n   ��6+   Z� .+�5      �� 
�������$	��240��6(   $ 15��64   $ 15��6A   $��30��6N   $	 0.1Q�6Z   �� 5      $	 
Horizontal=�6   .+�5        $	 Key=�6.   $��10 5 5 5q�6:   $��Center=�6L   $
��20px��6g   $��20��6t   ���#3740476�   G� 5      -   5         G�Name$ PasswordBox��5      $
 Password��63   .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True��6]      
HelperText$ At least 8 characters��6�   $��14(�6�   $��2 0 0 5q�6�   $	��192��6  $��Bottom=�6  ��6�   Z� 6  5      5       �� 5"      $	 
Horizontal=�6   $��Center=�62   $��Center=�6M   $	��200��6j   $��20��6v   $��0 20 0 0q�6�   ��6�   Z� .+�5#      ��  d� 	IsChecked$ FalseY�6   
�������6-   �� 5$      $��Show password��6   $��2q�61   $
��auto��6<   $
��auto��6I   $��11(�6W   
�������6e   5%      � 5'      $	��240��6   $��30��6   $��0 20 0 0q�6A   $��Center=�6S   $��Center=�6n   ��6+   Z� .+�5(      �� ���#eceeef$	��240��6+   $ 15��67   $ 15��6D   $��30��6Q   � 5)       � ColumnDefinitions 5*      �� 5+      $��* �6+   �� 5,      $��2* �6+   .+�5.      �� $��	User type��6    $��13(�61   $
��Left=�6?   $��15 5 0 0q�6Z   �� 5/      -   5         ��Name$ cmbUsertype��5/   1    �� SelectedIndex$ 1��6   $��1��6G   ���#eceeef$	 0.2Q�6l   $	��130��6z   $��30��6�   $
��Left=�6�   $��2 0 0 0q�6�   $��Bottom=�6�   50      51      �� 53      -   5        $ BtnLogin��53         MaterialDesignRaisedButton#���   6(   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 4��6]   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth2=�6�   
���� ��$	��100��6�   $��35��6�   $��Login��6�   
�������$��0 30 0 0q�6  $��Center=�6  $��Center=�68  6U  55      56      57      