
using PROYECTO_1EVA_RJT.Utilidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Documents.DocumentStructures;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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


        public List<Rectangle> gameElements;

        private BitmapImage[][][] animaciones;


        public Player(Canvas jugador, List<Rectangle> gameElements)
        {

            importImgs();
            this.jugador = jugador;
            this.gameElements = gameElements;
        }




        public void render()
        {
            // Cargar una imagen en un ImageBrush


            ((Rectangle)jugador.Children[0]).Fill = imagen();


        }

        public void update()
        {

            updatePosition();
            updateAnimation();
            

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

            foreach (Rectangle element in gameElements)
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


                Canvas.SetLeft(jugador, Canvas.GetLeft(jugador)+x);
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
            

            if (aniTick >=  aniSpeed/60)
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

          

           

            return   new ImageBrush(animaciones[playerAction][action][aniIndex]);

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
