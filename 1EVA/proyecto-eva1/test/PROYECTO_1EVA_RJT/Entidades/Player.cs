
using PROYECTO_1EVA_RJT.Utilidades;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Color = System.Windows.Media.Color;
using Point = System.Windows.Point;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace PROYECTO_1EVA_RJT.Entidades
{
    public class Player
    {

        private double aniTick;
        private int aniIndex;

        private double aniSpeed = 300;

        private double speed = 200;

        ScaleTransform scaleTransform = new ScaleTransform(3, 3); // Escala 3x en X e Y


        private int playerAction = Constantes.PlayerConst.IDLE;
        private int action = Constantes.PlayerConst.FRONT;

        private bool front, back, right, left, moving, attack, interact;

        public String interactiveObj { get; set; }

        public Canvas jugador { get; set; }
        public Canvas canvaInteractuar { get; set; }


        public List<Rectangle> gameElementsColiders { get; set; }
        public List<Rectangle>[] gameElementsNormalOpacity { get; set; }
        public List<Rectangle> gameElementsInteractive { get; set; }


        private ImageBrush[][][] animaciones;


        public Player(Canvas jugador,
                      List<Rectangle> gameElementsColiders,
                      List<Rectangle>[] gameElementsNormalOpacity,
                      Canvas canvaInteractuar,
                      List<Rectangle> gameElementsInteractive)
        {

            importImgs();
            this.jugador = jugador;
            this.canvaInteractuar = canvaInteractuar;
            this.gameElementsColiders = gameElementsColiders;
            this.gameElementsNormalOpacity = gameElementsNormalOpacity;
            this.gameElementsInteractive = gameElementsInteractive;
        }




        public void render()
        {
            // Cargar una imagen en un ImageBrush


            ((Rectangle)jugador.Children[0]).Fill = imagen();


        }

        public void update()
        {


            updateNormalOpacity();
            updateInteractiveElements();
            updatePosition();
            updatePlayerAction();
            updateAnimation();


        }

        private void updateInteractiveElements()
        {
            canvaInteractuar.Visibility = Visibility.Hidden;
            interactiveObj = null;

            foreach (Rectangle element in gameElementsInteractive)
            {
                if (IsCollidingWith(element))
                {
                    showInteractuable(element);
                    if (isInteract())
                    {

                        interactiveObj = element.Name;
                        return;

                    }
                }
            }


        }

        private bool IsCollidingWith(Rectangle element)
        {

            Rect newHitBox = new Rect(Canvas.GetLeft(jugador), Canvas.GetTop(jugador), jugador.Width, jugador.Height);
            Rect elementRect = new Rect(Canvas.GetLeft(element), Canvas.GetTop(element), element.Width, element.Height);

            if (newHitBox.IntersectsWith(elementRect))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void showInteractuable(Rectangle element)
        {

            if (element.DataContext.Equals("interactivo"))
            {
                canvaInteractuar.Visibility = Visibility.Visible;
                Canvas.SetLeft(canvaInteractuar, Canvas.GetLeft(element) + element.Width / 2 - canvaInteractuar.Width / 2);
                Canvas.SetTop(canvaInteractuar, Canvas.GetTop(element) - canvaInteractuar.Height);
            }
        }

        private void updateNormalOpacity()
        {

            List<Rectangle> listaOpacidad = gameElementsNormalOpacity[0]; //hitbox de opacidad
            List<Rectangle> listaNormal = gameElementsNormalOpacity[1]; //rectangulo imagen

            for (int i = 0; i < listaOpacidad.Count; i++)
            {

                if (IsCollidingWith(listaOpacidad[i]))
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
            setMoving(false);

            double x = 0;
            double y = 0;


            // hitbox
            if (isFront() && Canvas.GetTop(jugador) + jugador.Width < 880)
            {
                y += speed * Game.DeltaTime;
                setMoving(true);
            }
            if (isBack() && Canvas.GetTop(jugador) > 50)
            {
                y -= speed * Game.DeltaTime;
                setMoving(true);
            }
            if (isRight() && Canvas.GetLeft(jugador) + jugador.Width < 1600)
            {
                x += speed * Game.DeltaTime;
                setMoving(true);
            }
            if (isLeft() && Canvas.GetLeft(jugador) > 0)
            {
                x -= speed * Game.DeltaTime;
                setMoving(true);
            }

            // Verifica colisiones antes de actualizar la posición
            Rect newHitBox = new Rect(Canvas.GetLeft(jugador) + x, Canvas.GetTop(jugador) + y, jugador.Width, jugador.Height);

            foreach (Rectangle element in gameElementsColiders)
            {
                Rect elementRect = new Rect(Canvas.GetLeft(element), Canvas.GetTop(element), element.Width, element.Height);

                if (newHitBox.IntersectsWith(elementRect))
                {




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
                    setAttacking(false);
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





            return animaciones[playerAction][action][aniIndex];

        }











        /**
     * Esto es para cargar los sprites del jugador
     */
        private void importImgs()
        {


            animaciones = CargarGuardar.getPlayerSprites();


        }



        //ACCIONES


        public bool isInteract()
        {
            return interact;
        }




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


        //SETTERS

        public void setInteract(bool interact)
        {
            this.interact = interact;
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
