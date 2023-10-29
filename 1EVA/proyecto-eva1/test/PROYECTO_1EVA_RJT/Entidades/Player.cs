
using PROYECTO_1EVA_RJT.Utilidades;
using System;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PROYECTO_1EVA_RJT.Entidades
{
    class Player
    {

        private int aniTick, aniIndex;

        private double aniSpeed = 4.5;

        private float speed = 1.0f;

        private int playerAction = Constantes.PlayerConst.IDLE;
        private int action = Constantes.PlayerConst.FRONT;

        private bool front, back, right, left, moving, attack;

        int x, y;


        private BitmapImage[][][] animaciones;


        public Player(float x, float y, int width, int height)
        {
            
            importImgs(); 
           
        }


       

        public void render(System.Windows.Shapes.Rectangle jugador)
        {
            // Cargar una imagen en un ImageBrush

           
            jugador.Fill = imagen();

        }

        public void update()
        {

            updateAnimation();

        }

        private void updateAnimation()
        {
            
            aniTick++;

            if (aniTick >= aniSpeed)
            {
                aniTick = 0;
                aniIndex++;

                if (aniIndex >= Constantes.PlayerConst.getSpritesAmount(action,playerAction))
                {
                    aniIndex = 0;
                }
            }
        }

        private ImageBrush imagen()
        {

            ImageBrush imageBrush = new ImageBrush(animaciones[playerAction][action][aniIndex]);

            ScaleTransform scaleTransform = new ScaleTransform(2, 1.1, 0.5, 0.5); // Ajusta los valores según tus necesidades

            // Crear un TransformGroup y agregar la transformación
            TransformGroup transformGroup = new TransformGroup();
            transformGroup.Children.Add(scaleTransform);

            // Establecer la transformación en el ImageBrush
            imageBrush.RelativeTransform = transformGroup;

            return imageBrush;

        }



        /**
     * Esto es para cargar los sprites del jugador
     */
        private void importImgs()
        {


            animaciones = CargarGuardar.getPlayerSprites();


        }




    }
}
