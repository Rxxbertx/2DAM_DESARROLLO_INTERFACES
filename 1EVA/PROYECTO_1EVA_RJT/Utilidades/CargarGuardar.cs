using System;
using System.Security.Policy;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PROYECTO_1EVA_RJT.Utilidades
{
    class CargarGuardar
    {


        public static ImageBrush[][][] getPlayerSprites()
        {
            string playerPath = "recursos/Player/"; // Ajusta la ruta base de tus imágenes

            ImageBrush[][][] animaciones = new ImageBrush[3][][];

            for (int i = 0; i < 3; i++)
            {
                animaciones[i] = new ImageBrush[4][];

                for (int j = 0; j < 4; j++)
                {
                    animaciones[i][j] = new ImageBrush[7];
                    
                }
            }

            #region player idle
            // Player Idle front
            for (int i = 0; i < 6; i++)
            {
                animaciones[Constantes.PlayerConst.IDLE][Constantes.PlayerConst.FRONT][i] = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(playerPath + "idle/player-idle-front/player-idle-front-" + (i + 1) + ".png", UriKind.RelativeOrAbsolute)),
                    RelativeTransform = new ScaleTransform(4, 4,0.5, 0.5),
                    Stretch = Stretch.None
            };
            }

            // Player Idle back
            for (int i = 0; i < 7; i++)
            {
                animaciones[Constantes.PlayerConst.IDLE][Constantes.PlayerConst.BACK][i] = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(playerPath + "idle/player-idle-back/player-idle-back-" + (i + 1) + ".png", UriKind.RelativeOrAbsolute)),
                    RelativeTransform = new ScaleTransform(4, 4, 0.5, 0.5),
                    Stretch = Stretch.None
                };
            }

            // Player Idle right
            for (int i = 0; i < 6; i++)
            {
                animaciones[Constantes.PlayerConst.IDLE][Constantes.PlayerConst.RIGHT][i] = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(playerPath + "idle/player-idle-right/player-idle-right-" + (i + 1) + ".png", UriKind.RelativeOrAbsolute)),
                    RelativeTransform = new ScaleTransform(4, 4, 0.5, 0.5),
                    Stretch = Stretch.None
                };
            }

            // Player Idle left
            for (int i = 0; i < 6; i++)
            {
                animaciones[Constantes.PlayerConst.IDLE][Constantes.PlayerConst.LEFT][i] = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(playerPath + "idle/player-idle-left/player-idle-left-" + (i + 1) + ".png", UriKind.RelativeOrAbsolute)),
                    RelativeTransform = new ScaleTransform(4, 4, 0.5, 0.5),
                    Stretch = Stretch.None
                };
            }
            #endregion

            #region player walk
            // Player Walk front
            for (int i = 0; i < 6; i++)
            {
                animaciones[Constantes.PlayerConst.WALK][Constantes.PlayerConst.FRONT][i] = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(playerPath + "walk/player-walk-front/player-walk-front-" + (i + 1) + ".png", UriKind.RelativeOrAbsolute)),
                    RelativeTransform = new ScaleTransform(4, 4, 0.5, 0.5),
                    Stretch = Stretch.None
                };
            }

            // Player Walk back
            for (int i = 0; i < 6; i++)
            {
                animaciones[Constantes.PlayerConst.WALK][Constantes.PlayerConst.BACK][i] = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(playerPath + "walk/player-walk-back/player-walk-back-" + (i + 1) + ".png", UriKind.RelativeOrAbsolute)),
                    RelativeTransform = new ScaleTransform(4, 4, 0.5, 0.5),
                    Stretch = Stretch.None
                };
            }

            // Player Walk right
            for (int i = 0; i < 6; i++)
            {
                animaciones[Constantes.PlayerConst.WALK][Constantes.PlayerConst.RIGHT][i] = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(playerPath + "walk/player-walk-right/player-walk-right-" + (i + 1) + ".png", UriKind.RelativeOrAbsolute)),
                    RelativeTransform = new ScaleTransform(4, 4, 0.5, 0.5),
                    Stretch = Stretch.None
                };
            }

            // Player Walk left
            for (int i = 0; i < 6; i++)
            {
                animaciones[Constantes.PlayerConst.WALK][Constantes.PlayerConst.LEFT][i] = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(playerPath + "walk/player-walk-left/player-walk-left-" + (i + 1) + ".png", UriKind.RelativeOrAbsolute)),
                    RelativeTransform = new ScaleTransform(4, 4, 0.5, 0.5),
                    Stretch = Stretch.None
                };
            }
            #endregion

            #region player attack
            // Player Attack front
            for (int i = 0; i < 3; i++)
            {
                animaciones[Constantes.PlayerConst.ATTACK][Constantes.PlayerConst.FRONT][i] = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(playerPath + "attack/player-attack-front/player-attack-front-" + (i + 1) + ".png", UriKind.RelativeOrAbsolute)),
                    RelativeTransform = new ScaleTransform(4, 4, 0.511, 0.51),
                    Stretch = Stretch.None
                };
            }

            // Player Attack back
            for (int i = 0; i < 3; i++)
            {
                animaciones[Constantes.PlayerConst.ATTACK][Constantes.PlayerConst.BACK][i] = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(playerPath + "attack/player-attack-back/player-attack-back-" + (i + 1) + ".png", UriKind.RelativeOrAbsolute)),
                    RelativeTransform = new ScaleTransform(4, 4, 0.4935, 0.513),
                    Stretch = Stretch.None
                };
            }

            // Player Attack right
            for (int i = 0; i < 3; i++)
            {
                animaciones[Constantes.PlayerConst.ATTACK][Constantes.PlayerConst.RIGHT][i] = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(playerPath + "attack/player-attack-right/player-attack-right-" + (i + 1) + ".png", UriKind.RelativeOrAbsolute)),
                    RelativeTransform = new ScaleTransform(4, 4, 0.5, 0.503),
                    Stretch = Stretch.None
                };
            }

            // Player Attack left
            for (int i = 0; i < 3; i++)
            {
                animaciones[Constantes.PlayerConst.ATTACK][Constantes.PlayerConst.LEFT][i] = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(playerPath + "attack/player-attack-left/player-attack-left-" + (i + 1) + ".png", UriKind.RelativeOrAbsolute)),
                    RelativeTransform = new ScaleTransform(4, 4, 0.5, 0.505),
                    Stretch = Stretch.None
                };
            }
            #endregion

            return animaciones;
        }


        public static ImageBrush getPiezaFoto(String imagen)
        {
            try
            {
                return new ImageBrush
                {

                    ImageSource = new BitmapImage(new Uri("recursos/componentespc/" + imagen + ".png", UriKind.RelativeOrAbsolute)),
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ImageBrush();
            }

            
        }




    }
}
