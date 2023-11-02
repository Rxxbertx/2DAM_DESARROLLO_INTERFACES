using PROYECTO_1EVA_RJT.Entidades;
using PROYECTO_1EVA_RJT.Utilidades;
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

        public Tutorial(Player player, Game game)
        {
            GameManager.Nivel = Constantes.LvlConst.TUTORIAL;

            InitializeComponent();
            this.player = player;
            this.house = new House(player, game);
            ui.cargarGame(game);
            addElements();
            InicializarJugador();
            Focusable = true;
            Focus();



        }


        public void addElements()
        {
            Game.GameManager.GameStateElements(GameState.TUTORIAL);
            if (Game.GameManager.CurrentGameStateData != null)
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

            Game.GameManager.GameStateElements(GameState.TUTORIAL);
            Game.GameManager.CurrentGameStateData.playerHitbox = hitbox;
            Game.GameManager.CurrentGameStateData.CollidableElements = CollidableElements;
            Game.GameManager.CurrentGameStateData.InteractiveElements = InteractiveElements;
            Game.GameManager.CurrentGameStateData.NormalOpacityElements = NormalOpacityElements;


        }

        public bool loadElements()
        {

            if (Game.GameManager.CurrentGameStateData.playerHitbox == null || Game.GameManager.CurrentGameStateData.CollidableElements == null || Game.GameManager.CurrentGameStateData.InteractiveElements == null || Game.GameManager.CurrentGameStateData.NormalOpacityElements == null)
                return false;

            hitbox = Game.GameManager.CurrentGameStateData.playerHitbox;
            CollidableElements = Game.GameManager.CurrentGameStateData.CollidableElements;
            InteractiveElements = Game.GameManager.CurrentGameStateData.InteractiveElements;
            NormalOpacityElements = Game.GameManager.CurrentGameStateData.NormalOpacityElements;
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
            }
            player.render();
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

            if (player.interactiveObj != null)
            {


                if (Regex.IsMatch(player.interactiveObj, "puertaCasa"))
                {
                    insideBuild = true;
                    house.loadPage(player.interactiveObj);

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

            if(player.turnOff)
            {
                
                return;
            }

            player.setAttacking(true);


        }



    }
}
