   M S B A M L   `   `   `  ����M  IWpfAppRepasoExamen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WpfAppRepasoExamenWpfAppRepasoExamen  5   	   "    WpfAppRepasoExamen.dockPanel   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:WpfAppRepasoExamen     5   	     � Title$  	dockPanel��5   	   $	��450��6   $	��800��6(    � 	Resources 5
         operaciones��%�   &	        �� 5   
   .@�5      m� -   5        $
��Suma��5      6%   m� 5      -   5        $��Resta��5      6&   m� 5      -   5        $��Multiplicacion��5      6/   5      5      .��5      ]� .+�5   
   o� $	��Top=�6   .@�5      m� $��Archivo��6   .@�5      m� $��Nuevo��6   m� 5      $��Abrir��6   m� 5      $��Guardar��6   m� 5      $��Guardar como��6   m� 5      $��Salir��6   5      m� 5      $��	Operacion��6   .@�5       m� -   5        $
��Suma��5       6)   m� 5!      -   5        $��Resta��5!      6*   m� 5"      -   5        $��Multiplicacion��5"      63   5$      5&      c� 5(   
   $	��Top=�6   .@�5)      �� -   5        $��Salir��5)      6%   5*      �� 5,   
   $
��Left=�6   $	��100��6+   
�������.+�5-      �� .��6   -+...........................................6A   5.      �� 50   
   $��Bottom=�6   $��30��6,   .@�52      �� 
���   �$��1q�6)   ._�53      �� $��Barra de estado��6   $��Center=�63   $��Center=�6N   54      �� 56      $��Center=�6h   $��Center=�6�   ��6   �� *Value+ �� ElementName$ slider�� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 57      -   5         ��Name$ slider��57       � Minimum$ 10Q�6%    � Maximum$	 100Q�62    � Value$ 50Q�6@    �� TickPlacement$ TopLeft=�6K   	 �� IsSnapToTickEnabled$
	 True��6c   $��False��6~   
���   �
 � SmallChange$
 10Q�6�    �� TickFrequency$ 10Q�6�   $��Center=�6�   $��Center=�6�   $	��134��6�   59      9� 5:   
   $��Right=�6   $��
Calendario��6*    9� ExpandDirection$
 Down=�6>   .��5;   
   &   System.Windows.Controls.Calendar  $��Right=�6   $��10q�6*   5<      �� 5>   
   $	��Top=�6   .@�5@      �� $
��Tab1��6   .��5A      �� $��Center=�6   $��Center=�68   .+�5B      �� -	   5         ��Name$ n1��5B      $��Escribe aqui numero 1��6*   $��10q�6G   �� 5C      -
   5        $ n2��5C      $��Escribe aqui numero 2��6*   $��10q�6G   �� 5D      -   5        $ nr��5D      $��AQUI RESULTADO��6*    �� 
IsReadOnly$
 True��6@   $��10q�6R    � ContextMenu# [  6^   5E      5F      �� 5G      $
��Tab2��6   .��5I      �� $��10q�6   $��Center=�6'   $��Center=�6D   .@�5J      �� .��5L      �� $��Center=�6!   $��Center=�6<   .��6Y   HOLA6_   5O      �� 5P      .��5R      �� $��Center=�6    $��Center=�6;   .��6X   HOLA6^   5U      �� 5X      .��5Z      �� $��Center=�6    $��Center=�6;   .��6X   HOLA6^   5]      5^      5`      �� 5b      $
��TAB3��6   .��5d      -� -   5         -�Name$ lectura��5d   %   .��5g      /� .T�5i      J� .*�6$   �
�
lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed euismod, nisl sed aliquam ultricies, nunc nisl ultricies nunc, sed ultricies nisl nisl sit amet nisl. Donec auctor, nisl sed aliquam ultricies, nunc nisl ultricies nunc, sed ultricies nisl nisl sit amet nisl. Donec auctor, nisl sed aliquam ultricies, nunc nisl ultricies nunc, sed ultricies nisl nisl sit amet nisl. Donec auctor, nisl sed aliquam ultricies, nunc nisl ultricies nunc, sed ultricies nisl nisl sit amet nisl. Donec auctor, nisl sed aliquam ultricies, nunc nisl ultricies nunc, sed ultricies nisl nisl sit amet nisl. Donec auctor, nisl sed aliquam ultricies, nunc nisl ultricies nunc, sed ultricies nisl nisl sit amet nisl. Donec auctor, nisl sed aliquam ultricies, nunc nisl ultricies nunc, sed ultricies nisl nisl sit amet nisl. Donec auctor, nisl sed aliquam ultricies, nunc nisl ultricies nunc, sed ultricies nisl nisl sit amet nisl. Donec auctor, nisl sed aliquam ultricies, nunc nisl ultricies nunc, sed ultricies nisl nisl sit amet nisl. Donec auctor, nisl sed aliquam ultricies, nunc nisl ultricies nunc, sed ultricies nisl nisl sit amet nisl. Donec auctor, nisl sed aliquam ultricies, nunc nisl ultricies nunc, sed ultricies nisl nisl sit amet nisl. Donec auctor, nisl sed aliquam ultricies, nunc nisl ultricies nunc, sed ultricies nisl nisl sit amet nisl.5o      5s      5w      5z      5|      5�      5�      