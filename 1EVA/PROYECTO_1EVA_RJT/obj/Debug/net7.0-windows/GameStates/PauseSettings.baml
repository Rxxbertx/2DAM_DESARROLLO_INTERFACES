   M S B A M L   `   `   `  ����L  HPROYECTO_1EVA_RJT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:PROYECTO_1EVA_RJT.GameStatesPROYECTO_1EVA_RJT.GameStates  5      0    *PROYECTO_1EVA_RJT.GameStates.PauseSettings   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:PROYECTO_1EVA_RJT.GameStates     5      -   5          � WindowStyle$
  None=�5       � WindowStartupLocation$ CenterOwner=�62    � SizeToContent$ WidthAndHeight=�6V    � 
ResizeMode$ NoResize=�6u    � AllowsTransparency$
 True��5   	   
������  � ShowInTaskbar$ False��5      .��5      � .+�5   
   �� -   5         ��Name$ ventanaExit��5       � Cursor$ Cross��6&   $	��780��65   $	��630��6A   $��Center=�6N   .+�5      �� $	��630��6   $'��!/recursos/ExportedIcons/Item3.png��6!   $
��Fill=�6L   $	��784��6[   $
��Left=�6g   $��Center=�6�    �� Left$ -3��6�   �� 5      -   5        	 ��Name$	 	btnCerrar��5   !   $	��108��6   $	 276��64   $'��!/recursos/ExportedIcons/Item5.png��6F   $
��Fill=�6q   

 �� Top$	
 479��6�   $	��248��6�   $��Center=�6�   $	��Top=�6�   $ Cross��6�   �� 5      $��73��6   $'��!/recursos/ExportedIcons/Item2.png��6    $
��Fill=�6K   $	��488��6Z   $��Center=�6f   $	��Top=�6�   $
 35��6�   $	 156��6�   �� 5      -   5        $	 cerrarX��5      $��49��6�   $	 701��6�   $(��"/recursos/ExportedIcons/Icon_X.png��6�   $
��Fill=�6�   $��52��6�   $
 20��6�   $
��Left=�6  $	��Top=�6&   J� RenderTransformOrigin$ 0.471,-0.082&�6>  �� 5      -   5        $	 slrMenu0��5      $��53��6&   $	 282��62   $'��!/recursos/ExportedIcons/Item2.png��6D   $
��Fill=�6o   $	
 407��6~   $	��228��6�   $
��Left=�6�   $	��Top=�6�   �� 5      -   5        $��CERRAR��5   �   $	 285��6�   $	
 490��6�   $��Comic Sans MS)�6�   $��48(�6�   $
��Left=�6�   $��Center=�6�   $��86��6  $	��230��6#  $��Center=�6/  $��Center=�6S  �� 5      -   5         ��Name$ slrMenu��5      $��Salir al Menu��6�   $	 285��6�   $	
 409��6�   $��Comic Sans MS)�6�   $��24(�6�   $	��224��6�   $��Center=�6�   $��Center=�6   $��48��6D  �� 5      $��AJUSTES��6   $	 279��6'   $
 31��69   $��Comic Sans MS)�6I   $��48(�6d   $��Center=�6r   $	��Top=�6�   �� 5      $��Sonido��6   $	 356��6&   $	
 128��68   $��Comic Sans MS)�6I   $��22(�6d   $��Center=�6r   $	��Top=�6�   �� 5       -   5        $	 SoundImageOff��5       $/��)/recursos/ExportedIcons/Icon_SoundOff.png��6+   $
��Fill=�6^   $��58��6m   $	 172��6y   $	
 189��6�   $��53��6�   $��Center=�6�   $	��Top=�6�   �� 5!      -	   5        $	 SoundImageOn��5!      $.��(/recursos/ExportedIcons/Icon_SoundOn.png��6*   $
��Fill=�6\   $��58��6k   $	 172��6w   $	
 189��6�   $��53��6�   $��Center=�6�   $	��Top=�6�   $ 0.453,0.414&�6  �� 5#      -
   5         ��Name$ volumeSlider��5#   �   $	��324��6   $��Center=�6!   $	 269��6>   $	
 211��6P   $	��Top=�6a    �� TickPlacement$ BottomRight=�6y   $ 0.5,0.5&�6�   ���	#FF412220 � Maximum$ 1Q�6�    �� TickFrequency$	 0.1Q�6�    � LargeChange$	 0.1Q�6-  z�5$      V� 5%      .~�5&      ��  �� ScaleX$ 1Q�6)    �� ScaleY$ 2Q�64   �� 5'      �� 5(      T� 5)      5*      5,      �� 5.      $��16��6   $	 324��6    $'��!/recursos/ExportedIcons/Item2.png��62   $
��Fill=�6]   $	
 162��6l   $	��144��6}   $��Center=�6�   $	��Top=�6�   �� 5/      $+��%/recursos/ExportedIcons/Icon_Look.png��6   $
��Fill=�6C   $��38��6R   $	 172��6^   $	
 337��6p   $��53��6�   $��Center=�6�   $	��Top=�6�   $ 	0.509,0.5&�6�   �� 50      $��Pantalla (HZ)��6   $	 328��6-   $	
 257��6?   $��Comic Sans MS)�6P   $��22(�6k   $��Center=�6y   $	��Top=�6�   �� 51      $��16��6   $	 312��6    $'��!/recursos/ExportedIcons/Item2.png��62   $
��Fill=�6]   $	
 298��6l   $	��176��6}   $��Center=�6�   $	��Top=�6�   	� 52      -   5         	�Name$ _60fps��52      $��60��6*    � DataContext$ 1��67   $��84��6G   $��85��6S   $��Comic Sans MS)�6^   $��0,0,0,0q�6y   $��Center=�6�   $��Center=�6�   $
��Left=�6�   $	 396��6�   $	
 314��6�   $��Center=�6  $��5,5,5,5q�6*  $ 0.5,0.5&�6D  
�������
���   ����	#FFC57C70$��36(�6�  	� 53      -   5        $ _30fps��53      $��30��6*   $ 1��67   $��84��6G   $��88��6S   $��Comic Sans MS)�6_   $��0,0,0,0q�6z   $��Center=�6�   $��Center=�6�   $	 505��6�   $	
 314��6�   $��5,5,5,5q�6�   $ 1.341,0.583&�6  
�������
���   ����	#FFC57C70$
��Left=�6q  $��Center=�6�  $��36(�6�  	� 54      -   5        $ _120fps��54      $	��120��6+   $ 1��69   $��84��6I   $��85��6U   $��Comic Sans MS)�6`   $��0,0,0,0q�6{   $��Center=�6�   $��Center=�6�   $	 279��6�   $	
 314��6�   $��5,5,5,5q�6�   $ 0.5,0.5&�6  
�������
���   ����	#FFC57C70$��36(�6o  $
��Left=�6�  $��Center=�6�  56      59      5<      