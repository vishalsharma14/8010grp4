   M S B A M L   `   `   `  ����F  BAssignment6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Assignment6Assignment6  5   	       Assignment6.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Assignment6     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��4* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� ���#00a2d3$��2��6*   $��0��6>   .+�5   
   �� $��INPUTS��6   
�������$��TimesNewRoman)�64   $��Center=�6O   $��Center=�6j   $��30(�6�   5      �� 5      $��0��6   $��1��6)   .+�5      �� $��Future Value:��6   $��30(�6,   $��10q�6:   �� 5      $��Years:��6   $��30(�6%   $��10q�63   �� 5      $��Discount Rate:��6   $��30(�6-   $��10q�6;   5      �� 5   
   $��1��6   $��1��6%   $��10q�62   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��5q�62   .+�5      �� $��$��6   $��20(�6$   �� 5       $��30(�6   $	��250��6E   ��6(   �� *FutureValue+6E   5!      �� 5"      $��10q�6   $��Center=�6%   .+�5#      ]� $��Center=�6   $��10q�67   .+�5$      �� $
��Left=�6   $
��Bold"�62   .��6D   N:6H   �� 5%      $��Right=�6u    �� TextAlignment$ Right=�6�   $��60��6�   ��6   ��  �� ElementName$ txtYears�� �� Path$ Value� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5&      -   5        $��txtYears��5&   G    � Maximum$	 100Q�69   	 �� IsSnapToTickEnabled	 . 
 �� TickPlacement$
 BottomRight=�6s    �� TickFrequency$ 5Q�6�    � Value 6   �� *
NumYears+6�   5'      ]� 5)      $��Center=�6   $��10q�67   .+�5*      �� $
��Left=�6   $
��Bold"�62   .��6D   %:6H   �� 5+      $��Right=�6|   $ Right=�6�   $��60��6�   ��6   �� $ txtDiscountRate��$ Value�$ PropertyChanged=�6�   �� 5,      -   5        $��txtDiscountRate��5,   K   $	 100Q�6=   	 . $
 BottomRight=�6}   $ 5Q�6�    6   �� *interestRate+6�   5-      5.      5/      �� 50   
   $ 
Horizontal=�6   $��2��6.   $��2��6B   $��Center=�6O   .+�51      �� -   5        $��	btnReload��51      
�������
�������.��52      �� $��refresh.png��6   $��50��6-   $��60��69   $��Right=�6D   53      �� 54      -   5        $��btnCalculate��54   V   $��	Calculate��64   $��30(�6H   $	��200��6�   $��5q�6�   ���#00a2d3{�6   �� *	BtnMode+6�   55      �� 56   
   ���#00a2d3$��2��6*   $��3��6>   .+�57   
   �� $��OUTPUTS��6   
�������$��TimesNewRoman)�65   $��Center=�6P   $��Center=�6k   $��30(�6�   58      �� 59   
   $��Present Value:��6   $��30(�6)   $��5q�67   $��0��6C   $��4��6S   �� 5:   
   $��30(�60   $��2��6>   $��4��6N   
���������6   �� *PresentValue+6[   5;      5<      