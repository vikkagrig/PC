   M S B A M L   `   `   `  ����\  XПриемная_комиссия, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Приемная_комиссия!Приемная_комиссия  5   	   /    )Приемная_комиссия.NewSpec   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:Приемная_комиссия     5   	     � Icon$@  :/graduation_hat_graduate_university_school_icon_193302.png��5   	    � Title$1 +Добавить специальность��5	   	   $	��350��6(   $	��450��65   ��5
      �� 5   
   .��5      �  � Color$ 	#FFEBEBF3��6    � Offset$ 0Q�6-   � 5      $ White��6   $ 1Q�6)   5       � 	Resources 5       �� 
TargetType �� Property �� Value �� Triggers	 P� Property
 P� Value��%"  '��       '�� �     '�� �    '�� V    �� 5   
   " ��6   .�5      ��  � �� �	#FF09222E6+   �� 5       � ��$ 
Montserrat)�6+   �� 5       � ��$ 14(�6)   �� 5       � ��$	 0 2q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$ 
Montserrat)�6+   �� 5       � ��$ 14(�6)   �� 5       � ��$ Center=�64   �� 5       � ��$ 2q�6'   �� 5       � ��$	 250��6&   �� 5       � �� �	#FFEAEAEA6+   �� 5       � ��$ 0q�60   5      �� 5    
   " ��6   .�5!      ��  � �� �	#FF09222E6+   �� 5"       � ��$ 
Montserrat)�6+   �� 5#       � ��$ 10(�6)   �� 5$       � ��$	 150��6&   �� 5%       � ��$	 0 3q�6'   �� 5&       � ��$ 0q�60   �� 5'       � �� �	#FFEAEAEA6+   �� 5(       � ��$	 170��6&   5)      �� 5*   
   " ��6   .�5+      ��  � �� �	#FF7978786+   �� 5,       � ��$ 
Montserrat)�6+   �� 5-       � ��$ 14(�6)   �� 5.       � ��$ 3q�6'   �� 5/       � ��$	 250��6&   �� 50       � ��$ 20��6'   �� 51       � ��$ 
0, 0, 0, 1q�60    52      P� 53      	 �@J�	IsFocused
 . . �54      ��  � ��$ 
0, 0, 0, 2q�68   55      57      58      .��59      � .+�5:   
   ��  �� Orientation$ Vertical=�6   $��Center=�6,   $��Center=�6I   .+�5;      �� -   5         ��Name$
 name��5;   :   $��Название��6    �� TextWrapping$
 Wrap=�6&   $��40��6H   6m   �� 5<      -   5        $
 code��5<   C   $
 Wrap=�6   $'��!Код специальности��6*   6�   �� 5=      -   5        $	 but��5=   A   $
 Wrap=�6   $#��Бюджетные места��6*   6�   �� 5>      -   5        $
 comm��5>   ?   $
 Wrap=�6   $��Платные места��6*   6�   �� 5?      -   5        $	 dur��5?   G   $
 Wrap=�6   $/��)Длительность обучения��6*   6�   �� 5@      -   5        $
 mark��5@   @   $
 Wrap=�6   $!��Проходной балл��6*   6�   �� 5A      -   5        $
 cost��5A   A   $
 Wrap=�6   $"��Стоимость в год��6*   6�   �� 5B      -   5        ��5C      �� 5D      $��Добавить��6    $��2q�60   5F      5G      5H      5I      