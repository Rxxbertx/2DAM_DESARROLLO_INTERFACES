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
    /// <summary>
    /// Lógica de interacción para Level1.xaml
    /// </summary>
    public partial class Level3 : Page, ILevelMethods, StateMethods
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

        public Level3(Player player, Game game)
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
            Canvas.SetTop(canvas, lvl3.Height / 2 - (canvas.Height / 2));
            Canvas.SetLeft(canvas, lvl3.Width / 2 - (canvas.Width / 2));
            canvas.Visibility = System.Windows.Visibility.Visible;
            canvaDisplayed = true;
            ui.Visibility = System.Windows.Visibility.Hidden; Sounds.found.Play();
        }

        public void LoadCanvas()
        {

            CanvaInfo.Add(piezaInfo);
            CanvaInfo.Add(gpuInfo);

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


                    game.MainFrame.Navigate(this);
                    AddElements();
                    Sounds.door.Play();

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

            Game.GameManager.GameStateElements(GameState.LVL3);
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

                piedra1Opacidad,
                piedra2Opacidad,
                piedra3Opacidad,
                piedra4Opacidad,
                piedra5Opacidad,
                piedra6Opacidad,
                piedra7Opacidad,
                piedra8Opacidad,
                piedra9Opacidad,
                piedra10Opacidad,
                piedra11Opacidad,

                arbol1Opacidad,

                casa1Opacidad,
                casa2Opacidad,
                casa3Opacidad


            };
            NormalOpacityElements[1] = new List<Rectangle>()
            {

                piedra1N,
                piedra2N,
                piedra3N,
                piedra4N,
                piedra5N,
                piedra6N,
                piedra7N,
                piedra8N,
                piedra9N,
                piedra10N,
                piedra11N,

                arbol1N,

                casa1N,
                casa2N,
                casa3N



            };




            //collidable


            CollidableElements.Add(piedra1Hitbox);
            CollidableElements.Add(piedra2Hitbox);
            CollidableElements.Add(piedra3Hitbox);
            CollidableElements.Add(piedra4Hitbox);
            CollidableElements.Add(piedra5Hitbox);
            CollidableElements.Add(piedra6Hitbox);
            CollidableElements.Add(piedra7Hitbox);
            CollidableElements.Add(piedra8Hitbox);
            CollidableElements.Add(piedra9Hitbox);

            CollidableElements.Add(piedra10Hitbox);
            CollidableElements.Add(piedra11Hitbox);

            CollidableElements.Add(arbol1Hitbox);


            CollidableElements.Add(casa1Hitbox);
            CollidableElements.Add(casa2Hitbox);
            CollidableElements.Add(casa3Hitbox);

            CollidableElements.Add(objeto1Hitbox);
            CollidableElements.Add(objeto2Hitbox);
            CollidableElements.Add(objeto3Hitbox);
            CollidableElements.Add(objeto4Hitbox);
            CollidableElements.Add(objeto5Hitbox);
            CollidableElements.Add(objeto6Hitbox);
            CollidableElements.Add(objeto7Hitbox);
            CollidableElements.Add(objeto8Hitbox);
            CollidableElements.Add(objeto9Hitbox);
            CollidableElements.Add(objeto10Hitbox);
            CollidableElements.Add(objeto11Hitbox);
            CollidableElements.Add(objeto12Hitbox);
            CollidableElements.Add(objeto13Hitbox);
            CollidableElements.Add(objeto14Hitbox);
            CollidableElements.Add(objeto15Hitbox);
            CollidableElements.Add(objeto16Hitbox);
            CollidableElements.Add(objeto17Hitbox);
            CollidableElements.Add(objeto18Hitbox);
            CollidableElements.Add(objeto19Hitbox);
            CollidableElements.Add(objeto20Hitbox);


            //interactive

            InteractiveElements.Add(puertaCasa1);
            InteractiveElements.Add(puertaCasa2);
            InteractiveElements.Add(puertaCasa4);


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
            Game.GameManager.GameStateElements(GameState.LVL3);

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
