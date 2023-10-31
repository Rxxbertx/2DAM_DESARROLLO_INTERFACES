using PROYECTO_1EVA_RJT.Entidades;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace PROYECTO_1EVA_RJT.GameStates
{
    /// <summary>
    /// Lógica de interacción para Tutorial.xaml
    /// </summary>
    public partial class Tutorial : Page, StateMethods
    {

        public Player player;
        public House house;
        public bool insideBuild;
        private List<Rectangle> CollidableElements = new List<Rectangle>();
        private List<Rectangle> InteractiveElements = new List<Rectangle>();
        private List<Rectangle>[] NormalOpacityElements = new List<Rectangle>[2];

        public Tutorial(Player player)
        {
            InitializeComponent();

            this.player = player;
            addGameElements();
            InicializarJugador();
            Focusable = true;
            Focus();



        }


        private void addGameElements()
        {
            Game.gameManager.GameStateElements(GameState.TUTORIAL);
            if (Game.gameManager.currentGameStateData != null)
            {
                if (loadElements())
                {
                    return;
                }

            }


            //image and opacity
            NormalOpacityElements[0] = new List<Rectangle>();
            NormalOpacityElements[1] = new List<Rectangle>();


            NormalOpacityElements[1].Add(arbol1N);
            NormalOpacityElements[0].Add(arbol1Opacidad);
            NormalOpacityElements[1].Add(arbol2N);
            NormalOpacityElements[0].Add(arbol2Opacidad);
            NormalOpacityElements[1].Add(arbol3N);
            NormalOpacityElements[0].Add(arbol3Opacidad);
            NormalOpacityElements[1].Add(arbol4N);
            NormalOpacityElements[0].Add(arbol4Opacidad);
            NormalOpacityElements[1].Add(arbol5N);
            NormalOpacityElements[0].Add(arbol5Opacidad);
            NormalOpacityElements[1].Add(casa1N);
            NormalOpacityElements[0].Add(casa1Opacidad);


            //coliders

            CollidableElements.Add(arbol1HitBox);
            CollidableElements.Add(arbol2HitBox);
            CollidableElements.Add(arbol3HitBox);
            CollidableElements.Add(arbol4HitBox);
            CollidableElements.Add(arbol5HitBox);
            CollidableElements.Add(vallasHitbox);
            CollidableElements.Add(casa1Hitbox);


            //interactuables

            InteractiveElements.Add(puertaCasa1);



        }

        public void saveElements()
        {

            Game.gameManager.GameStateElements(GameState.TUTORIAL);
            Game.gameManager.currentGameStateData.playerHitbox = hitbox;
            Game.gameManager.currentGameStateData.CollidableElements = CollidableElements;
            Game.gameManager.currentGameStateData.InteractiveElements = InteractiveElements;
            Game.gameManager.currentGameStateData.NormalOpacityElements = NormalOpacityElements;

        }

        public bool loadElements()
        {

            if (Game.gameManager.currentGameStateData.playerHitbox == null || Game.gameManager.currentGameStateData.CollidableElements == null || Game.gameManager.currentGameStateData.InteractiveElements == null || Game.gameManager.currentGameStateData.NormalOpacityElements == null)
                return false;

            hitbox = Game.gameManager.currentGameStateData.playerHitbox;
            CollidableElements = Game.gameManager.currentGameStateData.CollidableElements;
            InteractiveElements = Game.gameManager.currentGameStateData.InteractiveElements;
            NormalOpacityElements = Game.gameManager.currentGameStateData.NormalOpacityElements;
            return true;


        }



        private void InicializarJugador()
        {


            // player = new Player(hitbox, gameElementsColiders, gameElementsNormalOpacity, canvaInteractuar, gameElementsInteractive);
            player.jugador = hitbox;
            player.gameElementsColiders = CollidableElements;
            player.gameElementsNormalOpacity = NormalOpacityElements;
            player.canvaInteractuar = canvaInteractuar;
            player.gameElementsInteractive = InteractiveElements;


        }


        public void render()
        {
            
            if (insideBuild)
            {
                house.render();
                return;
            }player.render();
        }

        public void update()
        {
            if (insideBuild)
            {
                house.update();
                return;
            }
            player.update();
            
            checkInteractiveElement();
        }

        private void checkInteractiveElement()
        {
            
            if (player.interactiveObj != null) {


                if (Regex.IsMatch(player.interactiveObj,"puerta"))
                {
                    insideBuild = true;
                    House.loadPage(player.interactiveObj);

                }


            }

        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.Key == Key.W)
            {

                player.setBack(true);
                // player.setMoving(true);

            }
            if (e.Key == Key.S)
            {

                player.setFront(true);
                // player.setMoving(true);
            }
            if (e.Key == Key.A)
            {
                player.setLeft(true);
                // player.setMoving(true);
            }
            if (e.Key == Key.D)
            {
                player.setRight(true);
                // player.setMoving(true);
            }

            if (e.Key == Key.E)
            {
                player.setInteract(false);
            }



        }

        private void Page_KeyUp(object sender, KeyEventArgs e)
        {



            if (e.Key == Key.W)
            {

                player.setBack(false);
                // player.setMoving(false);

            }
            if (e.Key == Key.S)
            {

                player.setFront(false);
                // player.setMoving(false);
            }
            if (e.Key == Key.A)
            {
                player.setLeft(false);
                // player.setMoving(false);
            }
            if (e.Key == Key.D)
            {
                player.setRight(false);
                // player.setMoving(false);
            }

            if (e.Key == Key.E)
            {
                player.setInteract(true);
            }

        }




        private void Page_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {


            player.setAttacking(true);

        }



    }
}
