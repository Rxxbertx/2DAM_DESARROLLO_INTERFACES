   M S B A M L   `   `   `  ����L  HPROYECTO_1EVA_RJT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:PROYECTO_1EVA_RJT.GameStatesPROYECTO_1EVA_RJT.GameStates  5   	   '    !PROYECTO_1EVA_RJT.GameStates.Exit   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:PROYECTO_1EVA_RJT.GameStates     5   	   -   5          � WindowStartupLocation$  CenterOwner=�5       � Title$
 Exit��5   	   $	��800��6   $	��450��6"    � WindowStyle$
 None=�6/    � 
ResizeMode$ NoResize=�6B    � AllowsTransparency$
 True��5
   	   
������  � ShowInTaskbar$ False��5       J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5   
   .��5      � .+�5   
   �� -   5         ��Name$ ventanaExit��5      .+�5      �� $	��450��6   $'��!/recursos/ExportedIcons/Item3.png��6!   $
��Fill=�6L   $	��800��6[   $
��Left=�6g   $��Center=�6�   �� 5      -   5         ��Name$ No��5      $��97��6M   	 �� Left$		 400��6Y   $'��!/recursos/ExportedIcons/Item5.png��6k   $
��Fill=�6�   

 �� Top$	
 244��6�   $	��260��6�   $��Center=�6�   $	��Top=�6�    � Cursor$ Cross��6�   �� 5      $��49��6   $'��!/recursos/ExportedIcons/Item2.png��6    $
��Fill=�6K   $	��800��6Z   $
��Left=�6f   $��Center=�6�   �� 5      -   5        $ cerrarX��5      $��49��6�   $		 725��6�   $(��"/recursos/ExportedIcons/Icon_X.png��6�   $
��Fill=�6�   $��52��6�   �� 5      -   5        $ Si��5      $��16��6    $		 156��6,   $'��!/recursos/ExportedIcons/Item2.png��6>   $
��Fill=�6i   $	
 325��6x   $	��193��6�   $
��Left=�6�   $	��Top=�6�   �� 5       -   5        $��NO��5    y   $		 406��6�   $	
 254��6�   $��Comic Sans MS)�6�   $��48(�6�   $
��Left=�6�   $��Center=�6�   $	��247��6  $��Center=�6  $��Center=�66  �� 5!      -   5        $��Si��5!   |   $		 156��6�   $	
 254��6�   $��Comic Sans MS)�6�   $��48(�6�   $
��Left=�6�   $��Center=�6�   $	��193��6  $��Center=�6  $��Center=�69  �� 5"      $%��¿Desea salir de la aplicacion?��6   $	 71��6>   $
 70��6O   $��Comic Sans MS)�6_   $��48(�6z   $
��Left=�6�   $	��Top=�6�   �� 5#      $��51��6   $'��!/recursos/ExportedIcons/Item2.png��6    $
��Fill=�6K   $	��800��6Z   $
��Left=�6f   $��Center=�6�   $	
 399��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5$      V� 5%      .~�5&      ��  �� ScaleY$ -1Q�6)   �� 5'      �� 5(      T� 5)      5*      5,      5/      50      52      