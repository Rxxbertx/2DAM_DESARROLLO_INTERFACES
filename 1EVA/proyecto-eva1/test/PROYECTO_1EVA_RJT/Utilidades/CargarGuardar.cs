using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace PROYECTO_1EVA_RJT.Utilidades
{
    class CargarGuardar
    {


public static BitmapImage[][][] getPlayerSprites()
    {
        string playerPath = "recursos/Player/"; // Ajusta la ruta base de tus imágenes

        BitmapImage[][][] animaciones = new BitmapImage[3][][];

        for (int i = 0; i < 3; i++)
        {
            animaciones[i] = new BitmapImage[4][];

            for (int j = 0; j < 4; j++)
            {
                animaciones[i][j] = new BitmapImage[7];
            }
        }

        #region player idle
        //player Idle front

        for (int i = 0; i < 6; i++)
        {
            animaciones[Constantes.PlayerConst.IDLE][Constantes.PlayerConst.FRONT][i] = new BitmapImage(new Uri(playerPath + "idle/player-idle-front/player-idle-front-" + (i + 1) + ".png", UriKind.RelativeOrAbsolute));
        }

        //player Idle back

        for (int i = 0; i < 7; i++)
        {
            animaciones[Constantes.PlayerConst.IDLE][Constantes.PlayerConst.BACK][i] = new BitmapImage(new Uri(playerPath + "idle/player-idle-back/player-idle-back-" + (i + 1) + ".png", UriKind.RelativeOrAbsolute));
        }

        //player Idle right

        for (int i = 0; i < 6; i++)
        {
            animaciones[Constantes.PlayerConst.IDLE][Constantes.PlayerConst.RIGHT][i] = new BitmapImage(new Uri(playerPath + "idle/player-idle-right/player-idle-right-" + (i + 1) + ".png", UriKind.RelativeOrAbsolute));
        }

        //player Idle left

        for (int i = 0; i < 6; i++)
        {
            animaciones[Constantes.PlayerConst.IDLE][Constantes.PlayerConst.LEFT][i] = new BitmapImage(new Uri(playerPath + "idle/player-idle-left/player-idle-left-" + (i + 1) + ".png", UriKind.RelativeOrAbsolute));
        }

        #endregion

        #region player walk
        //player walk front

        for (int i = 0; i < 6; i++)
        {
            animaciones[Constantes.PlayerConst.WALK][Constantes.PlayerConst.FRONT][i] = new BitmapImage(new Uri(playerPath + "walk/player-walk-front/player-walk-front-" + (i + 1) + ".png", UriKind.RelativeOrAbsolute));
        }

        //player walk back

        for (int i = 0; i < 6; i++)
        {
            animaciones[Constantes.PlayerConst.WALK][Constantes.PlayerConst.BACK][i] = new BitmapImage(new Uri(playerPath + "walk/player-walk-back/player-walk-back-" + (i + 1) + ".png", UriKind.RelativeOrAbsolute));
        }

        //player walk right

        for (int i = 0; i < 6; i++)
        {
            animaciones[Constantes.PlayerConst.WALK][Constantes.PlayerConst.RIGHT][i] = new BitmapImage(new Uri(playerPath + "walk/player-walk-right/player-walk-right-" + (i + 1) + ".png", UriKind.RelativeOrAbsolute));
        }

        //player walk left

        for (int i = 0; i < 6; i++)
        {
            animaciones[Constantes.PlayerConst.WALK][Constantes.PlayerConst.LEFT][i] = new BitmapImage(new Uri(playerPath + "walk/player-walk-left/player-walk-left-" + (i + 1) + ".png", UriKind.RelativeOrAbsolute));
        }
        #endregion

        #region player attack
        //player attack front

        for (int i = 0; i < 3; i++)
        {
            animaciones[Constantes.PlayerConst.ATTACK][Constantes.PlayerConst.FRONT][i] = new BitmapImage(new Uri(playerPath + "attack/player-attack-front/player-attack-front-" + (i + 1) + ".png", UriKind.RelativeOrAbsolute));
        }

        //player attack back

        for (int i = 0; i < 3; i++)
        {
            animaciones[Constantes.PlayerConst.ATTACK][Constantes.PlayerConst.BACK][i] = new BitmapImage(new Uri(playerPath + "attack/player-attack-back/player-attack-back-" + (i + 1) + ".png", UriKind.RelativeOrAbsolute));
        }

        //player attack right

        for (int i = 0; i < 3; i++)
        {
            animaciones[Constantes.PlayerConst.ATTACK][Constantes.PlayerConst.RIGHT][i] = new BitmapImage(new Uri(playerPath + "attack/player-attack-right/player-attack-right-" + (i + 1) + ".png", UriKind.RelativeOrAbsolute));
        }

        //player attack left

        for (int i = 0; i < 3; i++)
        {
            animaciones[Constantes.PlayerConst.ATTACK][Constantes.PlayerConst.LEFT][i] = new BitmapImage(new Uri(playerPath + "attack/player-attack-left/player-attack-left-" + (i + 1) + ".png", UriKind.RelativeOrAbsolute));
        }
        #endregion

        return animaciones;
    }



}
}
