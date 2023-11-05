using PROYECTO_1EVA_RJT.Entidades;
using PROYECTO_1EVA_RJT.Utilidades;
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
    public partial class Tutorial : Page, StateMethods, LevelMethods
    {

        private Game game;
        public Player player;
        public House house;
        public bool insideHouse;
        public bool canvaTutorialDisplayed = false;
        public int contador = 0;
        private bool completado = false;
        private List<Canvas> canvaTutorialDisplayedOBJ = new List<Canvas>();
        private List<Rectangle> CollidableElements = new List<Rectangle>();
        private List<Rectangle> InteractiveElements = new List<Rectangle>();
        private List<Rectangle>[] NormalOpacityElements = new List<Rectangle>[2];

        public Tutorial(Player player, Game game)
        {
            GameManager.Nivel = Constantes.LvlConst.TUTORIAL;

            InitializeComponent();
            this.game = game;
            this.player = player;
            this.house = new House(player, game);
            ui.cargarGame(game);
            AddElements();
            cargarCanvas();
            cargarCanvasTutorial(canvaTutorialDisplayedOBJ[contador]);

        }

        private void cargarCanvasTutorial(Canvas canvas)
        {
            Canvas.SetTop(canvas, tutorial.Height / 2 - (canvas.Height / 2));
            Canvas.SetLeft(canvas, tutorial.Width / 2 - (canvas.Width / 2));
            canvas.Visibility = System.Windows.Visibility.Visible;
            canvaTutorialDisplayed = true;
            ui.Visibility = System.Windows.Visibility.Hidden;
        }

        private void cargarCanvas()
        {

            canvaTutorialDisplayedOBJ.Add(Bienvenida);
            canvaTutorialDisplayedOBJ.Add(controles);
            canvaTutorialDisplayedOBJ.Add(Casas);
            canvaTutorialDisplayedOBJ.Add(piezaInfo);
            canvaTutorialDisplayedOBJ.Add(TorreInfo);

        }

        public void AddElements()
        {
            insideHouse = false;
            Focusable = true;
            this.Focus();

            Game.GameManager.GameStateElements(GameState.TUTORIAL);
            if (Game.GameManager.CurrentGameStateData != null)
            {
                if (LoadElements())
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

            InteractiveElements.Add(puertaCasa5);

            InicializarJugador();



        }

        public void SaveElements()
        {

            Game.GameManager.GameStateElements(GameState.TUTORIAL);

            if (Game.GameManager.CurrentGameStateData == null)
            {
                Game.GameManager.CurrentGameStateData = new GameStateData();
            }

            Game.GameManager.CurrentGameStateData.playerHitbox = hitbox;
            Game.GameManager.CurrentGameStateData.CollidableElements = CollidableElements;
            Game.GameManager.CurrentGameStateData.InteractiveElements = InteractiveElements;
            Game.GameManager.CurrentGameStateData.NormalOpacityElements = NormalOpacityElements;


        }

        public bool LoadElements()
        {

            if (Game.GameManager.CurrentGameStateData.playerHitbox == null || Game.GameManager.CurrentGameStateData.CollidableElements == null || Game.GameManager.CurrentGameStateData.InteractiveElements == null || Game.GameManager.CurrentGameStateData.NormalOpacityElements == null)
                return false;

            hitbox = Game.GameManager.CurrentGameStateData.playerHitbox;
            CollidableElements = Game.GameManager.CurrentGameStateData.CollidableElements;
            InteractiveElements = Game.GameManager.CurrentGameStateData.InteractiveElements;
            NormalOpacityElements = Game.GameManager.CurrentGameStateData.NormalOpacityElements;

            InicializarJugador();

            return true;


        }



        private void InicializarJugador()
        {


            // player = new Player(hitbox, gameElementsColiders, gameElementsNormalOpacity, canvaInteractuar, gameElementsInteractive);
            player.jugador = hitbox;
            player.gameElementsColiders = CollidableElements;
            player.gameElementsNormalOpacity = NormalOpacityElements;
            player.canvaInteractuar = ui.canvaInteractuar;
            player.gameElementsInteractive = InteractiveElements;
            player.setInteract(false);


        }




        public void Render()
        {

            if (completado)
            {
                return;
            }
            if (canvaTutorialDisplayed)
            {
                return;
            }

            if (insideHouse)
            {
                house.Render();
                return;
            }
            player.render();
        }

        public void Update()
        {

            if (completado)
            {
                return;
            }

            if (canvaTutorialDisplayed)
            {
                return;
            }

            if (insideHouse)
            {
                house.Update();

            }
            else player.update();

            CheckInteractions();
        }

        public void CheckInteractions()
        {

            if (player.interactiveObj != null)
            {


                if (Regex.IsMatch(player.interactiveObj, "puertaCasa"))
                {
                    try
                    {
                        SaveElements();
                        insideHouse = house.loadPage(player.interactiveObj);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                if (player.interactiveObj.Equals("salirPuerta"))
                {

                    if (GameManager.State == GameState.TUTORIAL)
                    {

                        game.MainFrame.Navigate(game.Tutorial);
                        GameManager.ChangeState(GameState.TUTORIAL);
                        game.Tutorial.AddElements();


                        return;
                    }
                    else if (GameManager.State == GameState.PLAYING)
                    {
                        game.MainFrame.Navigate(game.Playing);
                        GameManager.ChangeState(GameState.PLAYING);

                        return;
                    }

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
                player.setInteract(true);
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
                player.setInteract(false);
            }

        }




        private void Page_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            if (canvaTutorialDisplayed)
            {
                canvaTutorialDisplayed = false;
                canvaTutorialDisplayedOBJ[contador].Visibility = System.Windows.Visibility.Hidden;
                contador++;

                if (contador == canvaTutorialDisplayedOBJ.Count)
                {
                    ui.Visibility = System.Windows.Visibility.Visible;
                    return;
                }

                cargarCanvasTutorial(canvaTutorialDisplayedOBJ[contador]);


                return;
            }

            player.setAttacking(true);


        }

        public void CheckHouse()
        {


            if (completado)
            {
                tutorialCompletado.Visibility = System.Windows.Visibility.Visible;
                Canvas.SetLeft(tutorialCompletado, tutorial.Width / 2 - tutorialCompletado.Width / 2);
                Canvas.SetTop(tutorialCompletado, tutorial.Height / 2 - tutorialCompletado.Height / 2);

                return;

            }

            if (insideHouse)
            {
                house.checkHouse();
            }
        }

        internal bool isFinalizado()
        {
            return completado;

        }
        internal void Finalizado()
        {
            completado = true;
        }

        private void tutorialCompletado_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

           tutorialCompletado.Visibility=System.Windows.Visibility.Hidden;

            GameManager.ChangeState(GameState.PLAYING);
            game.MainFrame.Navigate(game.Playing);

        }
    }
}
