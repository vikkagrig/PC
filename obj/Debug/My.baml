   M S B A M L   `   `   `  ����\  XПриемная_комиссия, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Приемная_комиссия!Приемная_комиссия  5   	   *    $Приемная_комиссия.My   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:Приемная_комиссия     5   	     � Icon$@  :/graduation_hat_graduate_university_school_icon_193302.png��5       � Title$ Мои заявления��5   	   $	��200��6   $	��500��6,   ��5	      �� 5
   
   .��5      �  � Color$ 	#FFEBEBF3��6    � Offset$ 0Q�6-   � 5      $ White��6   $ 1Q�6)   5       � 	Resources 5       �� 
TargetType �� Property �� Value&   System.Windows.Controls.DataGrid=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%�  '��       '�� �     '�� �    '  1    '      �� 5   
   " ��6   .�5      ��  � �� �	#FF09222E6+   �� 5       � ��$ 
Montserrat)�6+   �� 5       � ��$ 10(�6)   �� 5       � ��$	 0 2q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$ 
Montserrat)�6+   �� 5       � ��$ 10(�6)   �� 5       � ��$ Center=�64   �� 5       � ��$ 2q�6'   �� 5       � �� �	#FFEAEAEA6+   �� 5       � ��$ 0q�60   5      �� 5   
   " ��6   .�5      ��  � �� �	#FF09222E6+   �� 5        � ��$ 
Montserrat)�6+   �� 5!       � ��$ 10(�6)   �� 5"       � ��$	 150��6&   �� 5#       � ��$	 0 3q�6'   �� 5$       � ��$ 0q�60   �� 5%       � �� �	#FFEAEAEA6+   �� 5&       � ��$	 170��6&   5'      �� 5(   
   "  6   .�5)      ��  � ��$	 450��6&   �� 5*       � ��$	 100��6'   �� 5+       � �� �	#FF09222E6+   �� 5,       � ��$ 
Montserrat)�6+   �� 5-       � ��$ 10(�6)   5.      �� 5/   
   "  6   .�50      ��  � ��$ Medium"�6+   51      52      .��53      �  � ColumnDefinitions 54   
   �� 55      $
��125* �6   �� 56      $	��12* �6   .+�58   
     -   5        	  Name$	 table��58      $��25,42,25,42q�6"   
   HeadersVisibility$
 Column=�67      
IsReadOnly .    Columns 59      0  *System.Windows.Controls.DataGridTextColumn  5:      ,  &System.Windows.Controls.DataGridColumn   Header$# Номер заявления��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.2* 6>   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6K   �� *
Column11+  5;      $  Специальность��6%   $
 0.3* 6<    6I   �� *
Column22+  5<      $ Приоритет��6%   $ 0.13* 68    6F   �� *
Column33+  5=      $! Форма обучения��6%   $
 0.2* 6=    6J   �� *
Column44+5?      5@      5A      