   M S B A M L   `   `   `  ���� L  HPROYECTO_1EVA_RJT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:PROYECTO_1EVA_RJT.GameStatesPROYECTO_1EVA_RJT.GameStates  0    *PROYECTO_1EVA_RJT.GameStates.PauseSettings   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     <local*clr-namespace:PROYECTO_1EVA_RJT.GameStates     -     � WindowStyle$
  None=� � WindowStartupLocation$ CenterOwner=� � SizeToContent$ WidthAndHeight=� � 
ResizeMode$ NoResize=� � AllowsTransparency$
 True��
������  � ShowInTaskbar$ False��.��� .+��� -    ��Name$ ventanaExit�� � Cursor$ Cross��$	��780��$	��630��$��Center=�.+��� $	��630��$'��!/recursos/ExportedIcons/Item3.png��$
��Fill=�$	��784��$
��Left=�$��Center=� �� Left$ -3���� -   	 ��Name$	 	btnCerrar��$	��108��$	 276��$'��!/recursos/ExportedIcons/Item5.png��$
��Fill=�

 �� Top$	
 479��$	��248��$��Center=�$	��Top=�$ Cross���� $��73��$'��!/recursos/ExportedIcons/Item2.png��$
��Fill=�$	��488��$��Center=�$	��Top=�$
 35��$	 156���� -   $	 cerrarX��$��49��$	 701��$(��"/recursos/ExportedIcons/Icon_X.png��$
��Fill=�$��52��$
 20��$
��Left=�$	��Top=� J� RenderTransformOrigin$ 0.471,-0.082&��� -   $	 slrMenu0��$��53��$	 282��$'��!/recursos/ExportedIcons/Item2.png��$
��Fill=�$	
 407��$	��228��$
��Left=�$	��Top=��� -   $��CERRAR��$	 285��$	
 490��$��Comic Sans MS)�$��48(�$
��Left=�$��Center=�$��86��$	��230��$��Center=�$��Center=��� -    ��Name$ slrMenu��$��Salir al Menu��$	 285��$	
 409��$��Comic Sans MS)�$��24(�$	��224��$��Center=�$��Center=�$��48���� $��AJUSTES��$	 279��$
 31��$��Comic Sans MS)�$��48(�$��Center=�$	��Top=��� $��Sonido��$	 356��$	
 128��$��Comic Sans MS)�$��22(�$��Center=�$	��Top=��� -   $	 SoundImageOff��$/��)/recursos/ExportedIcons/Icon_SoundOff.png��$
��Fill=�$��58��$	 172��$	
 189��$��53��$��Center=�$	��Top=��� -	   $	 SoundImageOn��$.��(/recursos/ExportedIcons/Icon_SoundOn.png��$
��Fill=�$��58��$	 172��$	
 189��$��53��$��Center=�$	��Top=�$ 0.453,0.414&��� -
    ��Name$ volumeSlider��$	��324��$��Center=�$	 269��$	
 211��$	��Top=� �� TickPlacement$ BottomRight=�$ 0.5,0.5&����	#FF412220 � Maximum$ 1Q� �� TickFrequency$	 0.1Q� � LargeChange$	 0.1Q�z�V� .~���  �� ScaleX$ 1Q� �� ScaleY$ 2Q��� �� T� �� $��16��$	 324��$'��!/recursos/ExportedIcons/Item2.png��$
��Fill=�$	
 162��$	��144��$��Center=�$	��Top=��� $+��%/recursos/ExportedIcons/Icon_Look.png��$
��Fill=�$��38��$	 172��$	
 337��$��53��$��Center=�$	��Top=�$ 	0.509,0.5&��� $��Pantalla (HZ)��$	 328��$	
 257��$��Comic Sans MS)�$��22(�$��Center=�$	��Top=��� $��16��$	 312��$'��!/recursos/ExportedIcons/Item2.png��$
��Fill=�$	
 298��$	��176��$��Center=�$	��Top=�	� -    	�Name$ _60fps��$��60�� � DataContext$ 1��$��84��$��85��$��Comic Sans MS)�$��0,0,0,0q�$��Center=�$��Center=�$
��Left=�$	 396��$	
 314��$��Center=�$��5,5,5,5q�$ 0.5,0.5&�
�������
���   ����	#FFC57C70$��36(�	� -   $ _30fps��$��30��$ 1��$��84��$��88��$��Comic Sans MS)�$��0,0,0,0q�$��Center=�$��Center=�$	 505��$	
 314��$��5,5,5,5q�$ 1.341,0.583&�
�������
���   ����	#FFC57C70$
��Left=�$��Center=�$��36(�	� -   $ _120fps��$	��120��$ 1��$��84��$��85��$��Comic Sans MS)�$��0,0,0,0q�$��Center=�$��Center=�$	 279��$	
 314��$��5,5,5,5q�$ 0.5,0.5&�
�������
���   ����	#FFC57C70$��36(�$
��Left=�$��Center=�