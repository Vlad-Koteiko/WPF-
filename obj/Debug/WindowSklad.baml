   M S B A M L   `   `   `  ����@  <LAB_7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:LAB_7LAB_7  5   	       LAB_7.WindowSklad   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:LAB_7     5   	     � Title$  WindowSklad��5   	   $	��450��6   $	��800��6*   .��5	      � -   5         �Name$ 	gridSklad��5	       � ColumnDefinitions 5
   
   �� 5      $	��150 �6   �� 5      .+�5   
   �� $��0��6   
�������.+�5      �� -   5        $��50��5      $��10q�6!   
�����_�.��6]   Просмотр6g   �� 5      -   5        $��50��5      $��10q�6!   .��6L   Обновить6V   5      �� 5   
   $��1��6   .+�5      � -   5        $ 
gridperson��5      
������� 5      �� 5      $��* �6'   �� 5      $��2* �6'   �� 5      $��* �6'   �� 5      $��2* �6'    � RowDefinitions 5      �� 5      �� 5      �� 5      .+�5!      �� $	��200��6   $
��5,10q�6$   $��1��62   $��0��6?   .��6O   Паполнить6Z   �� 5"      -   5         ��Name$ textBoxName��5"      $	��200��6/   $
��5,10q�6;   $��1��6I   $��1��6V   ��5#      ��  �� Path$ Amount�69   5%      �� 5&      -   5         ��Name$ listBox��5&      $
��10 0q�6'   $	��260��6M   
���������65   �� 6Z   5(      5,      5-      