   M S B A M L   `   `   `  ����H  DAdditionTutor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:AdditionTutorAdditionTutor  5   	       AdditionTutor.MainWindow   5	   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5
   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:AdditionTutor     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   ���#CED8F6.��5      � .+�5   
   � y�6   �� *DisplayNewQuiz+ � RowDefinitions 5      �� 5      $��* �6    �� 5      $��3* �6    �� 5      $��2* �6    �� 5      $��* �6    .+�5      �� $��0��5      $��30(�5      $��Addition Tutor��5      $��Center=�5      $��Center=�5      
�������$
��Bold"�5       �� 5"       �� Orientation$ 
Horizontal=�6   $��1��62   $��Center=�6?   .+�5#      �� $��60(�5$      $	��130��5&      $��Center=�5'      $��Center=�5(      ��5%      �� *AdditionTutor.FirstNumber+5(      �� 5*      $��60(�5+      $��+��5,      $	��100��5-      $��Center=�5.      $��Center=�5/      �� 51      $��60(�52      $	��130��54      $��Center=�55      $��Center=�56      ��53      �� *AdditionTutor.SecondNumber+ �� UpdateSourceTrigger$ PropertyChanged=�56      �� 58      $��60(�59      $��=��5:      $	��100��5;      $��Center=�5<      $��Center=�5=      �� 5?      -   5        $��TbInput��5B      $��60(�5@      $	��200��5C      $	��100��5D      $��Center=�5E      $��Center=�5F      ���#E6E6E6��5A      �� *
InputValue+ �� TargetNullValue$
 null��5I      5K      �� 5L       �� CornerRadius$ 5��5M      $��2��5N      $��60��5O      $	��200��5P      
�������
�������._�5T      �� -   5        $��	BtnSubmit��5X      $��0q�5U      $��30(�5V      $��Submit��5W      {�.  
������ 5[      5]      5^      � 5_   
   y�6   �� *DisplayQuizResult+ 5`      �� 5a      $��* �6    �� 5b      $��2* �6    �� 5c      $��* �6    �� 5d      $��2* �6    .+�5f      �� $��0��5g      $��30(�5h      $��Addition Tutor��5i      $��Center=�5j      $��Center=�5k      
�������$
��Bold"�5m      �� 5o      $��40(�5p      $��1��5r      $��Center=�5s      $��Center=�5t      ��5q      �� *Output+5t      �� 5v      $��40(�5w      $��2��5y      $��Center=�5z      $��Center=�5{      ��5x      �� *OutputExpression+5{      �� 5}      $ 5��5~      $��3��5      $��60��5�      $	��200��5�      
�������
�������._�5�      �� -   5        $��
BtnNewQuiz��5�      $��0q�5�      $��30(�5�      $��New Quiz��5�      
������ 5�      5�      5�      5�      5�      