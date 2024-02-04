
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

        public bool turnOff = false; // Para que no se mueva el jugador cuando se abre el menu

        private int aniIndex; // Indice de la animación actual

        private double animationTime = 0.0;
        private double animationDuration = 0.7; // Duración total de la animación en segundos


        private double speed = 150; // Velocidad en unidades por segundo (ajusta según tus necesidades)

        private int playerAction = Constantes.PlayerConst.IDLE; // 0 = idle, 1 = walk, 2 = attack
        private int action = Constantes.PlayerConst.FRONT; // 0 = front, 1 = back, 2 = right, 3 = left

        private bool front, back, right, left, moving, attack, interact; // Para saber que accion esta realizando el jugador

        public String InteractiveObj { get; set; }

        public Canvas Jugador { get; set; }
        public Canvas CanvaInteractuar { get; set; }


        public List<Rectangle> GameElementsColiders { get; set; } // Hitbox de los elementos con los que colisiona el jugador
        public List<Rectangle>[] GameElementsNormalOpacity { get; set; } // Elementos a los cual se aplica opacidad el jugador
        public List<Rectangle> GameElementsInteractive { get; set; }//Elementos con los que interactua el jugador


        private ImageBrush[][][] animaciones; // Animaciones del jugador


        public Player(Canvas jugador,
                      List<Rectangle> gameElementsColiders,
                      List<Rectangle>[] gameElementsNormalOpacity,
                      Canvas canvaInteractuar,
                      List<Rectangle> gameElementsInteractive)
        {

            importImgs(); // Carga las imagenes del jugador
            this.Jugador = jugador;
            this.CanvaInteractuar = canvaInteractuar;
            this.GameElementsColiders = gameElementsColiders;
            this.GameElementsNormalOpacity = gameElementsNormalOpacity;
            this.GameElementsInteractive = gameElementsInteractive;
        }




        public void Render()
        {
            // Cargar una imagen en un ImageBrush


            ((Rectangle)Jugador.Children[0]).Fill = imagen(); // Asigna la imagen al jugador
            


        }

        public void Update()
        {

            if (turnOff) { return; } // Para que no se mueva el jugador

            UpdateNormalOpacity(); // Actualiza la opacidad de los elementos que se encuentran en la lista de elementos con opacidad
            UpdateInteractiveElements(); // Actualiza los elementos con los que se puede interactuar
            UpdatePosition(); // Actualiza la posición del jugador
            updatePlayerAction(); // Actualiza la accion del jugador
            updateAnimation(); // Actualiza la animación del jugador


        }

        private void UpdateInteractiveElements() // Actualiza los elementos con los que se puede interactuar
        {
            CanvaInteractuar.Visibility = Visibility.Hidden; 
            InteractiveObj = null;

            foreach (Rectangle element in GameElementsInteractive) // Recorre los elementos con los que se puede interactuar
            {
                if (IsCollidingWith(element)) // Si el jugador colisiona con el elemento
                {
                    ShowInteractuable(element); // Muestra el elemento con el que se puede interactuar


                    if (isInteract()) // Si el jugador pulsa la tecla de interactuar
                    {

                        InteractiveObj = element.Name; // Guarda el nombre del elemento con el que se ha interactuado
                        return; // Sale del bucle

                    }
                }
            }


        }

        private bool IsCollidingWith(Rectangle element) // Comprueba si el jugador colisiona con un elemento
        {

            Rect newHitBox = new Rect(Canvas.GetLeft(Jugador), Canvas.GetTop(Jugador), Jugador.Width, Jugador.Height); // Hitbox del jugador

            Rect elementRect = new Rect(Canvas.GetLeft(element), Canvas.GetTop(element), element.Width, element.Height); // Hitbox del elemento

            if (newHitBox.IntersectsWith(elementRect)) // Si el hitbox del jugador colisiona con el hitbox del elemento
            {
                return true; 
            }
            else
            {
                return false;
            }
        }

        private void ShowInteractuable(Rectangle element) // Muestra el elemento con el que se puede interactuar
        {

            CanvaInteractuar.Visibility = Visibility.Visible; // Muestra el elemento con el que se puede interactuar
            Canvas.SetLeft(CanvaInteractuar, Canvas.GetLeft(element) + element.Width / 2 - CanvaInteractuar.Width / 2);
            Canvas.SetTop(CanvaInteractuar, Canvas.GetTop(element) - CanvaInteractuar.Height);

        }

        private void UpdateNormalOpacity()
        {

            List<Rectangle> listaOpacidad = GameElementsNormalOpacity[0]; //hitbox de opacidad
            List<Rectangle> listaNormal = GameElementsNormalOpacity[1]; //rectangulo imagen

            for (int i = 0; i < listaOpacidad.Count; i++) //recorre la lista de elementos con opacidad
            {

                if (IsCollidingWith(listaOpacidad[i])) //si el jugador colisiona con el elemento
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


            // hitbox del jugador
            if (isFront() && Canvas.GetTop(Jugador) + Jugador.Height < 890) // Si el jugador se mueve hacia abajo
            {
                y += speed * Game.DeltaTime; // Aumenta la posición en el eje Y
                setMoving(true);
            }
            if (isBack() && Canvas.GetTop(Jugador) - Jugador.Height > 30) // Si el jugador se mueve hacia arriba 
            {
                y -= speed * Game.DeltaTime; // Disminuye la posición en el eje Y
                setMoving(true);
            }
            if (isRight() && Canvas.GetLeft(Jugador) + Jugador.Width < 1600) // Si el jugador se mueve hacia la derecha
            {
                x += speed * Game.DeltaTime; // Aumenta la posición en el eje X
                setMoving(true);
            }
            if (isLeft() && Canvas.GetLeft(Jugador) > 0) // Si el jugador se mueve hacia la izquierda
            {
                x -= speed * Game.DeltaTime; // Disminuye la posición en el eje X
                setMoving(true);
            }

            // Verifica colisiones antes de actualizar la posición
            Rect newHitBox = new Rect(Canvas.GetLeft(Jugador) + x, Canvas.GetTop(Jugador) + y, Jugador.Width, Jugador.Height); // Hitbox del jugador

            foreach (Rectangle element in GameElementsColiders) // Recorre los elementos con los que colisiona el jugador
            {
                Rect elementRect = new Rect(Canvas.GetLeft(element), Canvas.GetTop(element), element.Width, element.Height); // Hitbox del elemento

                if (newHitBox.IntersectsWith(elementRect)) // Si el hitbox del jugador colisiona con el hitbox del elemento
                {



                    setMoving(false); // El jugador no se puede mover
                    avanzar = false; // El jugador no puede avanzar
                    return; // Sale del bucle
                }


            }

            if (avanzar) // Si el jugador puede avanzar
            {

                double length = Math.Sqrt(x * x + y * y); // Calcula la longitud del vector (x, y) para normalizarlo y que el jugador se mueva a la misma velocidad en todas las direcciones (diagonalmente) 
                if (length > 0) // Si la longitud es mayor que 0 (para evitar dividir entre 0) 
                {
                    x /= length; // Normaliza el vector (x, y)
                    y /= length;
                }

                x *= speed * Game.DeltaTime; // Multiplica el vector (x, y) por la velocidad y el tiempo transcurrido desde el último frame 
                y *= speed * Game.DeltaTime;

                // Actualiza la posición del jugador
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

        private void updateAnimation() // Actualiza la animación del jugador
        {





            // Calcula el progreso de la animación en función del tiempo transcurrido
            animationTime += Game.DeltaTime;

            // Si el progreso de la animación es mayor que la duración de la animación actual (en segundos) dividida entre el número de sprites de la animación actual (para que la animación no se reproduzca demasiado rápido)
            if (animationTime >= animationDuration / Constantes.PlayerConst.getSpritesAmount(action, playerAction))
            {
                animationTime = 0; // Resetea el progreso de la animación
                aniIndex++; // Aumenta el índice de la animación



                if (aniIndex >= Constantes.PlayerConst.getSpritesAmount(action, playerAction)) // Si el índice de la animación es mayor o igual que el número de sprites de la animación actual (para que no se salga del array)
                {
                    aniIndex = 0; // Resetea el índice de la animación
                    setAttacking(false); // El jugador no está atacando

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
                setAttacking(false);
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





            return animaciones[playerAction][action][aniIndex]; // Devuelve la imagen actual del jugador en función de la acción y la dirección en la que se mueve el jugador y el índice de la animación actual

        }











        /**
     * Esto es para cargar los sprites del jugador
     */
        private void importImgs()
        {

            //
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

        internal void TurnOff() // Para que no se mueva el jugador
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
