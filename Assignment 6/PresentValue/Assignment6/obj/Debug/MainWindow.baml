   M S B A M L   `   `   `  ����F  BAssignment6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Assignment6Assignment6  5   	       Assignment6.MainWindow   5	   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5
   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Assignment6     5   	     � Title$  Present Value��5   	   $	��450��6   $	��800��6,    � 
ResizeMode$ NoResize=�68   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��4* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� ���#00a2d3$��2��6*   $��0��6>   .+�5   
   �� $��INPUTS��6   
�������$��TimesNewRoman)�64   $��Center=�6O   $��Center=�6j   $��30(�6�   5      �� 5       $��0��6   $��1��6)   .+�5!      �� $��Future Value:��6   $��30(�6,   $��10q�6:   �� 5"      $��Years:��6   $��30(�6%   $��10q�63   �� 5#      $��Interest Rate:��6   $��30(�6-   $��10q�6;   5$      �� 5%   
   $��1��6   $��1��6%   $��10q�62   .+�5&      ��  �� Orientation$ 
Horizontal=�6   $��5q�62   .+�5'      �� $��$��6   $��20(�6$   �� 5(      -   5        $��TbFutureValue��5(   }   $��30(�6   $	��250��6q   ��6T   �� *FutureValue+6}   5)      �� 5*      $��10q�6   $��Center=�6%   .+�5+      ]� $��Center=�6   $��10q�67   {�6C   �� *Mode+.+�5,      �� $
��Left=�6   $
��Bold"�62   .��6D   N:6H   �� 5-      $��Right=�6u    �� TextAlignment$ Right=�6�   $��60��6�    �� 
IsReadOnly . ��6   ��  �� ElementName$ txtYears�� �� Path$ Value�	 �� UpdateSourceTrigger$	 PropertyChanged=�6�   �� 5.      -   5        $��txtYears��5.   G   
 � Maximum$	
 100Q�69    �� IsSnapToTickEnabled .  �� TickPlacement$ BottomRight=�6s    �� TickFrequency$ 5Q�6�    � Value 6   �� *
NumYears+6�   5/      ]� 51      $��Center=�6   $��10q�67   {�6C   �� *Mode+.+�52      �� $
��Left=�6   $
��Bold"�62   .��6D   %:6H   �� 53      $��Right=�6|   $ Right=�6�   $��60��6�    . ��6   �� $ txtInterestRate��$ Value�$	 PropertyChanged=�6�   �� 54      -   5        $��txtInterestRate��54   K   $	
 100Q�6=    . $ BottomRight=�6}   $ 5Q�6�    6   �� *InterestRate+6�   55      56      57      �� 58   
   $ 
Horizontal=�6   $��2��6.   $��2��6B   $��Center=�6O   .+�59      �� -   5        $��	BtnReload��59      
�������
�������.��5:      �� $��refresh.png��6   $��50��6-   $��60��69   $��Right=�6D   5;      �� 5<      -   5        $��BtnCalculate��5<   S   $��	Calculate��61   $��30(�6E   $	��200��6�   $��5q�6�   ���#00a2d3{�6   �� *Mode+6�   5=      �� 5>   
   ���#00a2d3$��2��6*   $��3��6>   .+�5?   
   �� $��OUTPUTS��6   
�������$��TimesNewRoman)�65   $��Center=�6P   $��Center=�6k   $��30(�6�   5@      �� 5A   
   $��Present Value:��6   $��30(�6)   $��5q�67   $��0��6C   $��4��6S   �� 5B   
   $��30(�60   $��2��6>   $��4��6N   
������� . ��6   �� *PresentValue+6o   5C      5D      