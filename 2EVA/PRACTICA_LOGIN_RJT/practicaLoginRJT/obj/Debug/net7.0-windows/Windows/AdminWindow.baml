   M S B A M L   `   `   `  ����R  NInicioSesionUsuario_RJT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:practicaLoginRJT.WindowspracticaLoginRJT.Windows  5   	   *    $practicaLoginRJT.Windows.AdminWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:practicaLoginRJT.Windows     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ AdminWindow��5   	   $	��450��6   $	��800��6*   .��5      � ��5   
   
� 5      .��5      �  � Color$ Black��6    � Offset$ 1Q�6-   � 5      $ 	#FF2F2222��6   $ 0Q�61   5      .+�5   
   o� $	��Top=�6   $	��Top=�6.   ���	#FF2F2222��6]   Z� .@�5      �� -   5        $
��Exit��5      $��Center=�6k   $��Center=�6�   
�������$
��Bold"�6�   $��Bahnschrift)�6�   $��18(�6�   ��6>   Z� ��6T   Z� 6�   5      �� 5   
   $��Center=�6   $��Center=�62   .+�5      �� $��WELCOME BACK ��6   $��Center=�6Y   $��Center=�6v   
�������$
��Bold"�6�   $��Bahnschrift)�6�   $��24(�6�   ��6,   Z� ��6B   Z� 6�   &   System.Windows.Controls.DataGrid  5      -   5        $��dataGrid��5#   ,      SelectionMode$ Single=�5"         HeadersVisibility$ Column=�5#      $��50q�6<      AutoGenerateColumns$ False��6H   $��Center=�6d   $��Center=�6�   $��22(�6�   $��Bahnschrift)�6�      CanUserReorderColumns$ False��6�      CanUserDeleteRows$ False��6�   	   CanUserAddRows$	 False��6	  
���   �
   GridLinesVisibility$

 None=�64  ��5!      Z�    ColumnHeaderStyle 5%      �� 5&       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5'      ��  �� Property � �� �� Value 5(      �� 5)   "    �� EndPoint$ 0.5,1&�66    �� 
StartPoint$ 0.5,0&�6G   .��5*   &   � $ 1Q�63   $ Black��6>   � 5+   &   $ 	#FF201717��63   $ 0Q�6E   5,   #   5.      �� 5/       � ��
 �����67   �� 50       � ��$ 15q�64   �� 51       � ��$ Center=�6G   �� 52       � ��$ Center=�6E   54         	CellStyle 59      �� 5:      *  $System.Windows.Controls.DataGridCell"  6   .�5;      ��  � ��
 ���� 67   �� 5<       � ��
 ���� 68   �� 5=       � ��$ Center=�6@   �� 5>       � ��$ Center=�6>   �� 5?       � ��$ 5q�64   �� 5@       � ��
 �����67   5C         RowStyle 5F      �� 5G      )  #System.Windows.Controls.DataGridRow"  6   .�5H      ��  � ��
 ���� 67   5J         Columns 5M      0  *System.Windows.Controls.DataGridTextColumn  5N      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6)      
IsReadOnly$
 True��6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Id+6L     5O      $
 Name��6)   $
 True��6P    67   �� *Name+6P     5P      $ UserName��6)   $
 True��6X    6;   �� *
UserName+6X     5Q      $ Password��6)   $
 True��6X    6;   �� *
Password+6X     5R      $ Admin��6)   $
 True��6R    68   �� *Admin+6R   4  .System.Windows.Controls.DataGridTemplateColumn  5S      $ Blocked��6-   $
 True��6>      CellTemplate 5T      �� 5U      .R�5V   "   �� -   5        $��20(�5V   �   ���	#FFFDFF00 d� 	IsChecked 6+   �� *	Blocked+ �� Mode$ TwoWay=� J� Effect 5W   &   3	  -System.Windows.Media.Effects.DropShadowEffect	  5X   *   5Z   #   5[      5]      5_      5b      �� 5c   
   $��adminSession��6   
�������$
��Bold"�6g   $��Bahnschrift)�6y   $��Right=�6�   $��Bottom=�6�   $��20(�6�   ��6'   Z� ��6=   Z� 6�   5i      5j      