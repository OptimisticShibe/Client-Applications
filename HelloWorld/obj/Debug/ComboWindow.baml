   M S B A M L   `   `   `  ����E  AHelloWorld, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:HelloWorld
HelloWorld  5   	       HelloWorld.ComboWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:HelloWorld     5   	     � Title$  ComboWindow��5   	   $	��300��6   $	��300��6*   .��5	      �� .+�5
   
   �� -   5         ��Name$ uxList��5
       �� View 5      �� 5      .P�5      ��  �� Width$	 100��6%    �� DisplayMemberBinding 61   �� *Name+.��5      �� -   5        .��5   T   Name6Z   5      �� 5      $	 100��6%    61   �� *
Password+.��5      �� -   5        .��5   T   
Password6^   5      5      5      � 5   
   -   5         �Name$ uxGrid��5       � RowDefinitions 5      �� 5      $��20 �6    6.   �� 5      $��20 �6    6.   �� 5      $��20 �6    6.   �� 5      $��20 �6    6.   �� 5      $��20 �6    6.   �� 5      $��20 �6    6.   .+�5!      �� $��0��6   $��
User Name:��6%   �� 5"      $��1��6   ��6#   �� *
UserName+�� 5#      $��2��6   $��	Password:��6%   
�������66   �� 5$      $��3��6   ��6#   �� *UserPassword+�� 5%      $��4��6   $
��Age:��6%   �� 5&      $��5��6   ��6#   �� *	UserAge+5'      5)      5*      