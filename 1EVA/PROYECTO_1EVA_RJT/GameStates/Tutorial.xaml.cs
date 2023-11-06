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
    public partial class Tutorial : Page, StateMethods, ILevelMethods
    {

        private readonly Game game;
        public Player player;
        public House house;
        public bool insideHouse;
        public bool canvaTutorialDisplayed = false;
        public int contador = 0;
        public bool Completed { get; set; }

        private List<Canvas> canvaTutorialDisplayedOBJ = new();

        public List<Rectangle> CollidableElements { get; set; }
        public List<Rectangle>[] NormalOpacityElements { get; set; }
        public List<Rectangle> InteractiveElements { get; set; }

        public Tutorial(Player player, Game game)
        {
            GameManager.Nivel = Constantes.LvlConst.TUTORIAL;

            InitializeComponent();

            CollidableElements = new List<Rectangle>();
            NormalOpacityElements = new List<Rectangle>[2];
            InteractiveElements = new List<Rectangle>();


            this.game = game;
            this.player = player;
            this.house = new House(player, game);
            ui.cargarGame(game);
            AddElements();
            LoadCanvas();
            LoadCanva(canvaTutorialDisplayedOBJ[contador]);

        }

        public void LoadCanva(Canvas canvas)
        {
            Canvas.SetTop(canvas, tutorial.Height / 2 - (canvas.Height / 2));
            Canvas.SetLeft(canvas, tutorial.Width / 2 - (canvas.Width / 2));
            canvas.Visibility = System.Windows.Visibility.Visible;
            canvaTutorialDisplayed = true;
            ui.Visibility = System.Windows.Visibility.Hidden;
            Sounds.found.Play();
        }

        public void LoadCanvas()
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
            NormalOpacityElements[0] = new List<Rectangle>()
            {
                arbol1Opacidad
                , arbol2Opacidad
                , arbol3Opacidad
                , arbol4Opacidad
                , arbol5Opacidad
                , casa1Opacidad

            };
            NormalOpacityElements[1] = new List<Rectangle>
            {
                arbol1N
                , arbol2N
                , arbol3N
                , arbol4N
                , arbol5N
                , casa1N

            };


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

            InitPlayer();



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

            if (Game.GameManager.CurrentGameStateData == null || Game.GameManager.CurrentGameStateData.playerHitbox == null || Game.GameManager.CurrentGameStateData.CollidableElements == null || Game.GameManager.CurrentGameStateData.InteractiveElements == null || Game.GameManager.CurrentGameStateData.NormalOpacityElements == null)
                return false;

            hitbox = Game.GameManager.CurrentGameStateData.playerHitbox;
            CollidableElements = Game.GameManager.CurrentGameStateData.CollidableElements;
            InteractiveElements = Game.GameManager.CurrentGameStateData.InteractiveElements;
            NormalOpacityElements = Game.GameManager.CurrentGameStateData.NormalOpacityElements;

            InitPlayer();

            return true;


        }



        public void InitPlayer()
        {


            // player = new Player(hitbox, gameElementsColiders, gameElementsNormalOpacity, canvaInteractuar, gameElementsInteractive);
            player.Jugador = hitbox;
            player.GameElementsColiders = CollidableElements;
            player.GameElementsNormalOpacity = NormalOpacityElements;
            player.CanvaInteractuar = ui.canvaInteractuar;
            player.GameElementsInteractive = InteractiveElements;
            player.setInteract(false);


        }




        public void Render()
        {

            if (Completed)
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
            player.Render();
        }

        public void Update()
        {

            if (Completed)
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
            else player.Update();

            CheckInteractions();
        }

        public void CheckInteractions()
        {

            if (player.InteractiveObj != null)
            {


                if (Regex.IsMatch(player.InteractiveObj, "puertaCasa"))
                {
                    try
                    {
                        SaveElements();
                        insideHouse = house.LoadPage(player.InteractiveObj);
                        Sounds.door.Play();

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                if (player.InteractiveObj.Equals("salirPuerta"))
                {

                    Sounds.door.Play();

                    if (GameManager.State == GameState.TUTORIAL)
                    {

                        game.MainFrame.Navigate(game.Tutorial);
                        GameManager.ChangeState(GameState.TUTORIAL);
                        game.Tutorial.AddElements();


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

                LoadCanva(canvaTutorialDisplayedOBJ[contador]);


                return;
            }

            player.setAttacking(true);


        }

        public void CheckHouse()
        {


            if (Completed)
            {
                ui.Visibility = System.Windows.Visibility.Hidden;
                tutorialCompletado.Visibility = System.Windows.Visibility.Visible;
                Canvas.SetLeft(tutorialCompletado, tutorial.Width / 2 - tutorialCompletado.Width / 2);
                Canvas.SetTop(tutorialCompletado, tutorial.Height / 2 - tutorialCompletado.Height / 2);
                Sounds.tutoCompleted.Play();

                return;

            }

            if (insideHouse)
            {
                house.CheckHouse();
            }
        }

        public bool IsFinished()
        {
            return Completed;

        }
        public void Finished()
        {
            Completed = true;
        }

        private void TutorialCompletado_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            tutorialCompletado.Visibility = System.Windows.Visibility.Hidden;

            GameManager.ChangeState(GameState.PLAYING);
            game.MainFrame.Navigate(game.Playing);
            game.Playing.LoadNextLevel();

        }
    }
}
