   M S B A M L   `   `   `  ���� L  HPROYECTO_1EVA_RJT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:PROYECTO_1EVA_RJT.GameStatesPROYECTO_1EVA_RJT.GameStates  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem )    #PROYECTO_1EVA_RJT.GameStates.Taller   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     <local*clr-namespace:PROYECTO_1EVA_RJT.GameStates     6sys&clr-namespace:System;assembly=mscorlib       N� Title$  Taller��.���  � 	Resources    textoVentana��%&   &	        ��TALLER TECNOLOGICO��.+��� -    ��Name$ padre��$
��1600��$	��900��.+��� -   $ piezas��$
��Left=�$	��Top=�$	��900��$
��1600������  j� Stretch$ UniformToFill=� �� ImageSource$) #/recursos/LandscapeMaterials/bg.jpg�� �� Opacity$	 0.8Q�.+��� -    ��Name$ Pausa��$+��%/recursos/ExportedIcons/Icon_Exit.png��$
��Fill=�$��48�� �� Left$ 10��
 �� Top$	 103��$��36���� $	��305��$	 600��$+��%/recursos/LandscapeMaterials/base.png��$
��Fill=�$	 145��$	��400���� $	��196��$
 1216��$+��%/recursos/LandscapeMaterials/base.png��$
��Fill=�$	 402��$	��276��$
��Left=�$	��Top=��� $	��196��$	 940��$+��%/recursos/LandscapeMaterials/base.png��$
��Fill=�$	 380��$	��276��$
��Left=�$	��Top=�	 J� RenderTransformOrigin$	 -0.428,0.548&��� $	��196��$	 384��$+��%/recursos/LandscapeMaterials/base.png��$
��Fill=�$	 380��$	��276��$
��Left=�$��Center=��� $	��196��$ 64��$+��%/recursos/LandscapeMaterials/base.png��$
��Fill=�$	 402��$	��276��$
��Left=�$	��Top=��� $	��196��$	 662��$+��%/recursos/LandscapeMaterials/base.png��$
��Fill=�$	 430��$	��276��$	 0.527,0.515&�$��Center=�$	��Top=��� -   
 ��Name$
 
piezaFoto1��$	��148��$	 119��$	 352��$	��166���� -   $
 
piezaFoto2��$	��148��$	 439��$	 330��$	��166��$
��Left=�$	��Top=�$��0������ $ Uniform=��� -   $
 
piezaFoto3��$	��148��$	 717��$	 380��$	��166��$
��Left=�$	��Top=��� -   $
 
piezaFoto4��$	��148��$	 995��$	 330��$	��166��$
��Left=�$	��Top=��� -   $
 
piezaFoto5��$	��148��$
 1271��$	 352��$	��166��$
��Left=�$	��Top=��� -	   $
 
piezaFoto6��$	��228��$	 670��$ 70��$	��260��$
��Left=�$	��Top=��� #��[  $��36(�$ 25��$��Comic Sans MS)�$
��Left=�$	��Top=����� $' !/recursos/ExportedIcons/Item2.png���� -
    ��Name$ btnSiguiente��$y�	Collapsed=�$��SIGUIENTE NIVEL��$	 630��$	 660��$	��110��$	��340�����	#00707070
�������$��24(����� $' !/recursos/ExportedIcons/Item5.png���� -   $ piezaRecogida��$	��572��$	��604��$
 -752��$��Center=�$��Center=�$y�	Collapsed=����� $' !/recursos/ExportedIcons/Item3.png��.+��� $��PIEZA RECOGIDA��$��36(�$	 140��$ 33��$��Comic Sans MS)����� $' !/recursos/ExportedIcons/Item2.png���� -   $
 piezaFotoCanva��$	��268��$	 156��$	 152��$	��292���� $��Click para continuar��$��22(�$	 196��$	 503��$
��Left=�$	��Top=�
�������$��Comic Sans MS)��� -   $ dialogo��$	��309��$
��1600��$��Center=�$	 581��$	��Top=�$	 0.5,0.5&�$y�	Collapsed=�.+��� $	��436��$ 34��$'��!/recursos/ExportedIcons/Item1.png��$
��Fill=�$
��1164��$
 -128��$	 0.5,0.5&�z�V� .~���  �� ScaleX$ -1Q� �� ScaleY$ -1Q���  �� AngleX$ -17.488Q��� T�  T� X$ 68.685Q��� $	��947��$
 1082��$,��&/recursos/LandscapeMaterials/profe.png��$
��Fill=�$
 -602��$	��568��$��Center=�$	��Top=��� $��Click para continuar��$��22(�$	 556��$	 248�����	#FF0A0909$��Comic Sans MS)�$
��Left=�$	��Top=��� -    ��Name$ textoDialogo��$	 184��$
��Wrap=�$��0��$ 32��$	��154��$	��990��$��24(�$��Comic Sans MS)� �� TextAlignment$ Center=�$��WordEllipsis=�$	��Top=�$��Center=��� -   $
 piezaFotoDialog��$	��268��$	 533��$
 -433��$	��292���� -   $ 
CanvaFinal��$	��900��$
��1600��$��Center=�$��Center=�$y�	Collapsed=�.+��� ���	#B2000000$	��900��$
��1600���� $	��188��$	��260��$	 670��$	 356��$��/recursos/loading.png���� -   $ final��$	��610��$	��640��$
 -789��$	 103��$��Center=�$��Center=�$y�	Collapsed=����� $' !/recursos/ExportedIcons/Item3.png��.+��� $	��194��$	 -73��$'��!/recursos/ExportedIcons/Item4.png��$
��Fill=�$	 -92��$	��786��$��Center=�$	��Top=��� $	��362��$	 117��$$��/recursos/componentesPc/pc.png��$
��Fill=�$	 194��$	��406��$
��Left=�$	��Top=��� $��JUEGO COMPLETADO��$��36(�$	 -66��$��Comic Sans MS)�$��Center=�$	��Top=�$	 122���� $\��VGracias por ayudar a la profe a recoger las piezas necesarias para montar el Ordenador��$��24(�$ 70��$��Comic Sans MS)�$ 82��$
��Left=�$��Center=�$	��119��$	��476��$
��Wrap=�$
��Bold"�$ Center=�
��������� $��Click para Salir��$��20(�$	 622��$��Comic Sans MS)�$
��Left=�$��Center=�$	 244��
�������