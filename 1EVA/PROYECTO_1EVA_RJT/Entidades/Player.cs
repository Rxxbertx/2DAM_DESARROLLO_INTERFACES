
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

        public bool turnOff = false;

        private int aniIndex;

        private double animationTime = 0.0;
        private double animationDuration = 0.7; // Duración total de la animación en segundos


        private double speed = 150;

        ScaleTransform scaleTransform = new ScaleTransform(3, 3); // Escala 3x en X e Y


        private int playerAction = Constantes.PlayerConst.IDLE;
        private int action = Constantes.PlayerConst.FRONT;

        private bool front, back, right, left, moving, attack, interact;

        public String InteractiveObj { get; set; }

        public Canvas Jugador { get; set; }
        public Canvas CanvaInteractuar { get; set; }


        public List<Rectangle> GameElementsColiders { get; set; }
        public List<Rectangle>[] GameElementsNormalOpacity { get; set; }
        public List<Rectangle> GameElementsInteractive { get; set; }


        private ImageBrush[][][] animaciones;


        public Player(Canvas jugador,
                      List<Rectangle> gameElementsColiders,
                      List<Rectangle>[] gameElementsNormalOpacity,
                      Canvas canvaInteractuar,
                      List<Rectangle> gameElementsInteractive)
        {

            importImgs();
            this.Jugador = jugador;
            this.CanvaInteractuar = canvaInteractuar;
            this.GameElementsColiders = gameElementsColiders;
            this.GameElementsNormalOpacity = gameElementsNormalOpacity;
            this.GameElementsInteractive = gameElementsInteractive;
        }




        public void Render()
        {
            // Cargar una imagen en un ImageBrush


            ((Rectangle)Jugador.Children[0]).Fill = imagen();


        }

        public void Update()
        {

            if (turnOff) { return; }

            UpdateNormalOpacity();
            UpdateInteractiveElements();
            UpdatePosition();
            updatePlayerAction();
            updateAnimation();


        }

        private void UpdateInteractiveElements()
        {
            CanvaInteractuar.Visibility = Visibility.Hidden;
            InteractiveObj = null;

            foreach (Rectangle element in GameElementsInteractive)
            {
                if (IsCollidingWith(element))
                {
                    ShowInteractuable(element);
                   

                    if (isInteract())
                    {

                        InteractiveObj = element.Name;
                        return;

                    }
                }
            }


        }

        private bool IsCollidingWith(Rectangle element)
        {

            Rect newHitBox = new Rect(Canvas.GetLeft(Jugador), Canvas.GetTop(Jugador), Jugador.Width, Jugador.Height);
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

        private void ShowInteractuable(Rectangle element)
        {
            
            CanvaInteractuar.Visibility = Visibility.Visible;
            Canvas.SetLeft(CanvaInteractuar, Canvas.GetLeft(element) + element.Width / 2 - CanvaInteractuar.Width / 2);
            Canvas.SetTop(CanvaInteractuar, Canvas.GetTop(element) - CanvaInteractuar.Height);

        }

        private void UpdateNormalOpacity()
        {

            List<Rectangle> listaOpacidad = GameElementsNormalOpacity[0]; //hitbox de opacidad
            List<Rectangle> listaNormal = GameElementsNormalOpacity[1]; //rectangulo imagen

            for (int i = 0; i < listaOpacidad.Count; i++)
            {

                if (IsCollidingWith(listaOpacidad[i]))
                {

                    // Crea un LinearGradientBrush
                    LinearGradientBrush linearGradientBrush = new LinearGradientBrush
                    {
                        StartPoint = new Point(0.5, 0),
                        EndPoint = new Point(0.5, 0.8)
                    };



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

        private void UpdatePosition()
        {
            bool avanzar = true;
            setMoving(false);

            double x = 0;
            double y = 0;


            // hitbox
            if (isFront() && Canvas.GetTop(Jugador) + Jugador.Height < 890)
            {
                y += speed * Game.DeltaTime;
                setMoving(true);
            }
            if (isBack() && Canvas.GetTop(Jugador) - Jugador.Height > 30)
            {
                y -= speed * Game.DeltaTime;
                setMoving(true);
            }
            if (isRight() && Canvas.GetLeft(Jugador) + Jugador.Width < 1600)
            {
                x += speed * Game.DeltaTime;
                setMoving(true);
            }
            if (isLeft() && Canvas.GetLeft(Jugador) > 0)
            {
                x -= speed * Game.DeltaTime;
                setMoving(true);
            }

            // Verifica colisiones antes de actualizar la posición
            Rect newHitBox = new Rect(Canvas.GetLeft(Jugador) + x, Canvas.GetTop(Jugador) + y, Jugador.Width, Jugador.Height);

            foreach (Rectangle element in GameElementsColiders)
            {
                Rect elementRect = new Rect(Canvas.GetLeft(element), Canvas.GetTop(element), element.Width, element.Height);

                if (newHitBox.IntersectsWith(elementRect))
                {



                    setMoving(false);
                    avanzar = false;
                    return;
                }


            }

            if (avanzar)
            {

                double length = Math.Sqrt(x * x + y * y);
                if (length > 0)
                {
                    x /= length;
                    y /= length;
                }

                x *= speed * Game.DeltaTime;
                y *= speed * Game.DeltaTime;

                Canvas.SetLeft(Jugador, Canvas.GetLeft(Jugador) + x);
                Canvas.SetTop(Jugador, Canvas.GetTop(Jugador) + y);

              
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





            // Calcula el progreso de la animación en función del tiempo transcurrido
            animationTime += Game.DeltaTime;

            if (animationTime >= animationDuration / Constantes.PlayerConst.getSpritesAmount(action, playerAction))
            {
                animationTime = 0;
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

        internal void TurnOff()
        {
            turnOff = true;


            setAttacking(false);
            setBack(false);
            setFront(false);
            setLeft(false);
            setRight(false);
            setMoving(false);
            setInteract(false);


        }

        internal void TurnOn()
        {
            turnOff = false;
        }
    }

}
