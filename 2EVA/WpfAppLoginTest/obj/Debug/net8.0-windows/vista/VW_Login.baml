   M S B A M L   `   `   `  ����J  FWpfAppLoginTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WpfAppLoginTest.vistaWpfAppLoginTest.vista  5   	   $    WpfAppLoginTest.vista.VW_Login   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:WpfAppLoginTest.vista     5   	   -   5          � WindowStyle$
  None=�5   	    � AllowsTransparency$
 True��5	   	   
������  � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ VW_Login��5   	   $	��450��6   $	��800��6'   .��5      ��  �� CornerRadius$ 70��6   ���	#66000000$��	1 1 20 40q�67   ��5   
   �� 5       �� EndPoint$	 1,1&�6"    �� 
StartPoint$ 0.5,0.5&�61   .��5      �  � Color$
 Blue��6   	 � Offset$		 0.5Q�6,   � 5      $ White��6   $		 0.2Q�6-   � 5      $
 Blue��6   $		 0.3Q�6,   � 5      $ White��6   $		 0.4Q�6-   � 5      $
 Blue��6   $		 0.5Q�6,   � 5      $ White��6   $		 0.2Q�6-   � 5      $ White��6   $		 0.6Q�6-   � 5      $
 Blue��6   $		 -20Q�6,   5      ._�5   
   � 
 � ColumnDefinitions
 5      �� 5       �� 5!      $��25 �6#   �� 5"      $��25 �6#   �� 5#      $��5 �6#    � RowDefinitions 5%      �� 5&      $��50 �6    �� 5'      .+�5+      �� $��LOGIN��6   
���   �$��30(�68   $��Bahnschrift)�6F   $��0��6_   $��Center=�6o   $��Center=�6�   $
��Bold"�6�    �� TextAlignment$ Center=�6�   �� 5-      -   5         ��Name$ btnMinimizar��5-      $��1��6+   $��0��6;   ��5/      �� 50       �� 
TargetType" ��6   .�51      ��  �� Property � �� �� Value
 �����67   �� 52       � ��
 �   �67   �� 53       � ��$ Center=�6E   �� 54       � ��$ Center=�6G    �� Triggers 55      P� 56       P� Property �@J�IsMouseOver P� Value$
 True��6=   . �58   "   ��  � ��
 �   �6?   �� 59   "    � ��
 �����6?   5;      5>      ��5@      �� 5A       �� 
TargetType" ��6&   .R�5F      �� $��18��6!   $��18��6,   $ 10��68   #��z��6J   ._�5H      �� $��Center=�6/   $��Center=�6J   $��-��6g   5J      5N      5R      �� 5S      -   5        $ 	btnCerrar��5S      $��2��6(   $��0��68   
���   ���5U      �� 5V      " ��6   .�5W      ��  � ��
 �����67   �� 5X       � ��
 �   �67   �� 5Y       � ��$ Center=�6E   �� 5Z       � ��$ Center=�6G    5[      P� 5\       �@J�IsMouseOver$
 True��6=   . �5^   "   ��  � ��
 �   �6?   �� 5_   "    � ��
 �����6?   5a      5d      ��5f      �� 5g      " ��6&   .R�5j      �� $��18��6!   $��18��6,   $ 10��68   #��z��6J   ._�5l      �� $��Center=�6/   $��Center=�6J   $��x��6g   5n      5p      5t      5w      5y      5z      