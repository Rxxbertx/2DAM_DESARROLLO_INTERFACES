﻿
using PROYECTO_1EVA_RJT.Utilidades;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Color = System.Windows.Media.Color;
using Point = System.Windows.Point;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace PROYECTO_1EVA_RJT.Entidades
{
    class Player
    {

        private double aniTick;
        private int aniIndex;

        private double aniSpeed = 300;

        private double speed = 200;

        private int playerAction = Constantes.PlayerConst.IDLE;
        private int action = Constantes.PlayerConst.FRONT;

        private bool front, back, right, left, moving, attack;

        private Canvas jugador;


        private List<Rectangle> gameElementsColiders = new List<Rectangle>();
        private List<Rectangle>[] gameElementsNormalOpacity;


        private BitmapImage[][][] animaciones;


        public Player(Canvas jugador, List<Rectangle> gameElementsColiders, List<Rectangle>[] gameElementsNormalOpacity)
        {

            importImgs();
            this.jugador = jugador;
            this.gameElementsColiders = gameElementsColiders;
            this.gameElementsNormalOpacity = gameElementsNormalOpacity;
        }




        public void render()
        {
            // Cargar una imagen en un ImageBrush


            ((Rectangle)jugador.Children[0]).Fill = imagen();


        }

        public void update()
        {


            updateNormalOpacity();
            updatePosition();
            updateAnimation();


        }

        private void updateNormalOpacity()
        {

            List<Rectangle> listaOpacidad = gameElementsNormalOpacity[0]; //hitbox de opacidad
            List<Rectangle> listaNormal = gameElementsNormalOpacity[1]; //rectangulo imagen
            Rect newHitBox = new Rect(Canvas.GetLeft(jugador), Canvas.GetTop(jugador), jugador.Width, jugador.Height);

            for (int i = 0; i < listaOpacidad.Count; i++)
            {



                Rect tempObj = new Rect(Canvas.GetLeft(listaOpacidad[i]), Canvas.GetTop(listaOpacidad[i]), listaOpacidad[i].Width, listaOpacidad[i].Height);
                if (newHitBox.IntersectsWith(tempObj))
                {

                    // Crea un LinearGradientBrush
                    LinearGradientBrush linearGradientBrush = new LinearGradientBrush();
                    linearGradientBrush.StartPoint = new Point(0.5, 0);
                    linearGradientBrush.EndPoint = new Point(0.5, 1);



                    // Agrega los GradientStops al LinearGradientBrush
                    linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Black, 0.827));
                    linearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(0x3E, 0xFF, 0xFF, 0xFF), 0.679));

                    // Asigna el LinearGradientBrush como OpacityMask del Rectangle
                    listaNormal[i].OpacityMask = linearGradientBrush;


                }
                else
                    listaNormal[i].OpacityMask = null;
            }

        }




        private void updatePosition()
        {
            bool avanzar = true;

            double x = 0;
            double y = 0;


            //hitbox
            if (isFront())
            {
                y -= speed * Game.deltaTime;
            }
            if (isBack())
            {
                y += speed * Game.deltaTime;
            }
            if (isRight())
            {
                x += speed * Game.deltaTime;
            }
            if (isLeft())
            {
                x -= speed * Game.deltaTime;
            }

            // Verifica colisiones antes de actualizar la posición
            Rect newHitBox = new Rect(Canvas.GetLeft(jugador) + x, Canvas.GetTop(jugador) + y, jugador.Width, jugador.Height);

            foreach (Rectangle element in gameElementsColiders)
            {
                Rect elementRect = new Rect(Canvas.GetLeft(element), Canvas.GetTop(element), element.Width, element.Height);

                if (newHitBox.IntersectsWith(elementRect))
                {
                    // Colisión detectada, no actualices la posición
                    avanzar = false;
                    return;
                }


            }

            if (avanzar)
            {


                Canvas.SetLeft(jugador, Canvas.GetLeft(jugador) + x);
                Canvas.SetTop(jugador, Canvas.GetTop(jugador) + y);

            }



        }



        /* private void updatePosition()
         {

             //double speed = 100; // Velocidad en unidades por segundo (ajusta según tus necesidades)




             if (isFront())
             {
                 jugador.Margin = new Thickness(
                     jugador.Margin.Left,
                     jugador.Margin.Top - speed * Game.deltaTime,
                     jugador.Margin.Right,
                     jugador.Margin.Bottom + speed * Game.deltaTime
                 );
             }
             if (isBack())
             {
                 jugador.Margin = new Thickness(
                     jugador.Margin.Left,
                     jugador.Margin.Top + speed * Game.deltaTime,
                     jugador.Margin.Right,
                     jugador.Margin.Bottom - speed * Game.deltaTime
                 );
             }
             if (isRight())
             {
                 jugador.Margin = new Thickness(
                     jugador.Margin.Left + speed * Game.deltaTime,
                     jugador.Margin.Top,
                     jugador.Margin.Right - speed * Game.deltaTime,
                     jugador.Margin.Bottom
                 );
             }
             if (isLeft())
             {
                 jugador.Margin = new Thickness(
                     jugador.Margin.Left - speed * Game.deltaTime,
                     jugador.Margin.Top,
                     jugador.Margin.Right + speed * Game.deltaTime,
                     jugador.Margin.Bottom
                 );
             }
         }*/


        public bool IsCollidingWith(Rectangle element)
        {
            Rect playerRect = new Rect(jugador.Margin.Left, jugador.Margin.Top, jugador.Width, jugador.Height);
            Rect elementRect = new Rect(element.Margin.Left, element.Margin.Top, element.Width, element.Height);
            return playerRect.IntersectsWith(elementRect);
        }



        #region animaciones

        private void updateAnimation()
        {

            aniTick++;


            if (aniTick >= aniSpeed / 60)
            {
                aniTick = 0;
                aniIndex++;

                if (aniIndex >= Constantes.PlayerConst.getSpritesAmount(action, playerAction))
                {
                    aniIndex = 0;
                }
            }
        }

        /**
         * Comprueba la accion del usuario a realizar, si la animacion que tiene , se mantiene entonce no hara falta
         * restablecer las animaciones, en caso contrario si Si el personaje se puede mover correra, si no se quedara
         * quieto, y si ataca atacara
         */
        public void updatePlayerAction()
        {

            int startAni = playerAction;
            int startAction = action;

            if (isFront())
            {
                this.action = Constantes.PlayerConst.FRONT;
            }
            else if (isBack())
            {
                this.action = Constantes.PlayerConst.BACK;
            }
            else if (isRight())
            {
                this.action = Constantes.PlayerConst.RIGHT;
            }
            else if (isLeft())
            {
                this.action = Constantes.PlayerConst.LEFT;
            }


            if (isMoving())
            {
                this.playerAction = Constantes.PlayerConst.WALK;
            }
            else
            {
                this.playerAction = Constantes.PlayerConst.IDLE;
            }

            if (isAttacking())
            {
                this.playerAction = Constantes.PlayerConst.ATTACK;
            }

            if (startAni != playerAction)
            {
                resetAni();
            }

            if (startAction != action)
            {
                resetAni();
            }



        }

        /**
         * Este metodo es para resetear las animaciones
         */
        private void resetAni()
        {

            aniIndex = 0;
            aniTick = 0;

        }

        #endregion














        private ImageBrush imagen()
        {





            return new ImageBrush(animaciones[playerAction][action][aniIndex]);

        }











        /**
     * Esto es para cargar los sprites del jugador
     */
        private void importImgs()
        {


            animaciones = CargarGuardar.getPlayerSprites();


        }



        //ACCIONES


        public bool isFront()
        {
            return front;
        }

        public bool isBack()
        {
            return back;
        }

        public bool isRight()
        {
            return right;
        }

        public bool isLeft()
        {
            return left;
        }

        public bool isMoving()
        {
            return moving;
        }

        public bool isAttacking()
        {
            return attack;
        }

        public void setFront(bool front)
        {
            this.front = front;
        }

        public void setBack(bool back)
        {
            this.back = back;
        }

        public void setRight(bool right)
        {
            this.right = right;
        }

        public void setLeft(bool left)
        {
            this.left = left;
        }

        public void setMoving(bool moving)
        {
            this.moving = moving;
        }

        public void setAttacking(bool attack)
        {
            this.attack = attack;
        }




    }

}
