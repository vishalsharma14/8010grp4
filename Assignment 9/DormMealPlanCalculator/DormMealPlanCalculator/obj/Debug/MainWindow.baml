   M S B A M L   `   `   `  ����Q  MDormMealPlanCalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:DormMealPlanCalculatorDormMealPlanCalculator  5   	   '    !DormMealPlanCalculator.MainWindow   5	   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5
   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:DormMealPlanCalculator     5   	     � Title$#  Dorm And Meal Plan Calculator��5   	   $	��450��6/   $	��800��6<   .��5      � ���#C1E7EE � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��2* �6   .+�5   
   �� ���#564E4B$��0��5      $��35(�5      $#��Dorm And Meal Plan Calculator��5      $��Center=�5      $��Center=�5      $
��Bold"�5      �� 5!   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�5"      �� $��30(�5#      $��Select Dorm: ��5$      ���#564E4B$��Center=�5&      $��Center=�5'      $
��Bold"�5(      $	��400��5)      �� 5+      -   5        $
��20,0q�5.      ���#564E4B �� 
IsEditable .  �� 
IsReadOnly . $��30(�53      $	��300��54      $��50��55      $��Center=�56       �� Text$ -- Select --��57       �� SelectedItem 5,      �� *SelectedDorm+��5-      �� *Dorms+57      59      �� 5:   
   $��2��6   $ 
Horizontal=�6"   $��Center=�6;   .+�5;      �� $��30(�5<      $��Select Meal Plan: ��5=      ���#564E4B$��Center=�5?      $��Center=�5@      $
��Bold"�5A      $	��400��5B      �� 5D      -   5        $
��20,0q�5G      ���#564E4B .  . $��30(�5L      $	��300��5M      $��50��5N      $��Center=�5O      $ -- Select --��5P       5E      �� *SelectedMealPlan+��5F      �� *	MealPlans+5P      5R      �� 5S   
    �� CornerRadius$ 5��5T      $��3��5U      $��50��5V      $	��200��5W      
�������
�������._�5[      �� -   5        $��BtnCalculate��5c      $��0q�5\      
������ ���#564E4B$��	Calculate��5_      $��30(�5a      $
��Bold"�5b      {�.  5d      5f      5g      5h      