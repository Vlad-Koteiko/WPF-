   M S B A M L   `   `   `  ����@  <LAB_7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:LAB_7LAB_7  5   	       LAB_7.WindowTex   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:LAB_7     5   	     � Title$  	WindowTex��5   	   $	��400��6   $	��400��6(    � 	Resources 5
       �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value �� RelativeSource	 �� Path��%�   '��       �� 5   
   " ��6    5      P� 5       �@=�HasError . . �5      ��  �@�ToolTip 5      ��  �� *Self+$)	 #(Validation.Errors)[0].ErrorContent��� 5       � ��
 �  ��63   5      5      5      .��5      � -   5        
 �Name$

 grid��5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5        � ColumnDefinitions 5"   
   �� 5#      $��1* �6   �� 5$      $��2* �6   .+�5&   
   �� $ ��Ф.И.О. инженера��6   $��Center=�6*   $��Center=�6G   �� 5'   
   $%��Тип обслуживания��6   $��1��6+   $��Center=�68   $��Center=�6U   �� 5(   
   $��Запчасти��6   $��2��6#   $��Center=�60   $��Center=�6M   �� 5)   
   $%��Стоимость работы��6   $��3��6+   $��Center=�68   $��Center=�6U   �� 5*   
   $+��%Стоимость запчастей��6   $��4��6.   $��Center=�6;   $��Center=�6X   �� 5+   
   $��1��6   $��0��6"   $��20 15q�6/   .��6>   .��5,      �� $	 Name_person�6    �� ValidationRules 5-      5  /System.Windows.Controls.DataErrorValidationRule  5.      50      51      �� 52   
   -   5         ��Name$ 	combobox2��52      $��1��6&   $��1��66   $��20 15q�6C    �� Text 6R   �� $	 Service_type�53      �� 54   
   -   5        $ 	combobox3��54      $��1��6&   $��2��66   $��20 15q�6C    6R   �� $	 Zapcasti�55      �� 56   
   $��1��6   $��3��6"   $��20 15q�6/   .��6>   .��57      �� $	 	Cost_work�6   58      59      �� 5:   
   $��1��6   $��4��6"   $��20 15q�6/   .��6>   .��5;      �� $	 Cost_zapcast�6   5<      5=      �� 5?   
   -   5        $��Принять��5?      $��5��6#   $��2��60   $��50 10q�6D   6S   5@      5A      