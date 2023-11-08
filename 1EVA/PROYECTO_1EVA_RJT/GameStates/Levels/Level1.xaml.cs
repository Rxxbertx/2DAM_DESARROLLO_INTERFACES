using PROYECTO_1EVA_RJT.Entidades;
using PROYECTO_1EVA_RJT.Utilidades;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace PROYECTO_1EVA_RJT.GameStates.Levels
{

    public partial class Level1 : Page, ILevelMethods, StateMethods
    {

        public List<Rectangle> CollidableElements { get; set; }
        public List<Rectangle>[] NormalOpacityElements { get; set; }
        public List<Rectangle> InteractiveElements { get; set; }

        private List<Canvas> CanvaInfo = new();


        private readonly Game game;
        public Player player;
        public House house;
        public bool insideHouse;

        public bool canvaDisplayed = false;
        public int contador = 0;

        public bool Completed { get; set; }

        public Level1(Player player, Game game)
        {
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
            LoadCanva(CanvaInfo[contador]);


        }


        #region CANVAS

        public void LoadCanva(Canvas canvas)
        {
            Canvas.SetTop(canvas, lvl1.Height / 2 - (canvas.Height / 2));
            Canvas.SetLeft(canvas, lvl1.Width / 2 - (canvas.Width / 2));
            canvas.Visibility = System.Windows.Visibility.Visible;
            canvaDisplayed = true;
            ui.Visibility = System.Windows.Visibility.Hidden;
            Sounds.found.Play();
        }

        public void LoadCanvas()
        {



            CanvaInfo.Add(piezaInfo);
            CanvaInfo.Add(psInfo);

        }


        #endregion


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



        public void CheckHouse()
        {
            if (insideHouse)
            {
                house.CheckHouse();
            }
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
                    game.MainFrame.Navigate(this);
                    AddElements();


                    return;



                }

            }
        }


        #region saveLoadAdd

        public void AddElements()
        {

            insideHouse = false;
            Focusable = true;
            this.Focus();

            Game.GameManager.GameStateElements(GameState.LVL1);
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

                casa1Opacidad,
                casa2Opacidad,
                arbol1Opacidad,
                arbol2Opacidad,
                arbol3Opacidad,
                arbol4Opacidad,
                arbol5Opacidad,
                arbol6Opacidad,
                arbol7Opacidad,


            };
            NormalOpacityElements[1] = new List<Rectangle>()
            {
                casa1N,
                casa2N,
                arbol1N,
                arbol2N,
                arbol3N,
                arbol4N,
                arbol5N,
                arbol6N,
                arbol7N,



            };




            //collidable

            CollidableElements.Add(casa1Hitbox);
            CollidableElements.Add(casa2Hitbox);
            CollidableElements.Add(arbol1Hitbox);
            CollidableElements.Add(arbol2Hitbox);
            CollidableElements.Add(arbol3Hitbox);
            CollidableElements.Add(arbol4Hitbox);
            CollidableElements.Add(arbol5Hitbox);
            CollidableElements.Add(arbol6Hitbox);
            CollidableElements.Add(arbol7Hitbox);
            CollidableElements.Add(objeto1Hitbox);
            CollidableElements.Add(objeto2Hitbox);
            CollidableElements.Add(objeto3Hitbox);
            CollidableElements.Add(objeto4Hitbox);
            CollidableElements.Add(objeto5Hitbox);
            CollidableElements.Add(objeto6Hitbox);
            CollidableElements.Add(objeto7Hitbox);
            CollidableElements.Add(objeto8Hitbox);
            CollidableElements.Add(objeto9Hitbox);


            //interactive

            InteractiveElements.Add(puertaCasa1);
            InteractiveElements.Add(puertaCasa2);


            InitPlayer();


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

        public void SaveElements()
        {
            Game.GameManager.GameStateElements(GameState.LVL1);

            if (Game.GameManager.CurrentGameStateData == null)
            {
                Game.GameManager.CurrentGameStateData = new GameStateData();
            }

            Game.GameManager.CurrentGameStateData.playerHitbox = hitbox;
            Game.GameManager.CurrentGameStateData.CollidableElements = CollidableElements;
            Game.GameManager.CurrentGameStateData.InteractiveElements = InteractiveElements;
            Game.GameManager.CurrentGameStateData.NormalOpacityElements = NormalOpacityElements;

        }

        #endregion



        #region CHECK FINISH

        public bool IsFinished()
        {
            return Completed;

        }
        public void Finished()
        {
            Completed = true;
        }

        #endregion


        #region gameloop

        public void Update()
        {
            CheckInteractions();

            if (insideHouse)
            {
                house.Update();
                return;

            }
            player.Update();
        }

        public void Render()
        {
            if (insideHouse)
            {
                house.Render();
                return;
            }
            player.Render();
        }

        #endregion


        #region inputs




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

            if (canvaDisplayed)
            {
                canvaDisplayed = false;
                CanvaInfo[contador].Visibility = System.Windows.Visibility.Hidden;
                contador++;

                if (contador == CanvaInfo.Count)
                {
                    ui.Visibility = System.Windows.Visibility.Visible;
                    return;
                }

                LoadCanva(CanvaInfo[contador]);


                return;
            }

            player.setAttacking(true);

        }

        #endregion

    }
}
