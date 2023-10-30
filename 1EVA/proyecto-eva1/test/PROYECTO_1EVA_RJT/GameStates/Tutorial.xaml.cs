using PROYECTO_1EVA_RJT.Entidades;
using System.Collections.Generic;
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

        Player player;
        Game game;
        private List<Rectangle> gameElementsColiders = new List<Rectangle>();
        private List<Rectangle>[] gameElementsNormalOpacity = new List<Rectangle>[2];

        public Tutorial(Game game)
        {
            InitializeComponent();
            this.game = game;
            addGameElements();
            InicializarJugador();
            Focusable = true;
            Focus();



        }


        private void addGameElements()
        {

            //image and opacity
            gameElementsNormalOpacity[0] = new List<Rectangle>();
            gameElementsNormalOpacity[1] = new List<Rectangle>();

            gameElementsNormalOpacity[1].Add(arbol1N);
            gameElementsNormalOpacity[0].Add(arbol1Opacidad);





            //coliders

            gameElementsColiders.Add(arbol1HitBox);
            //gameElementsColiders.Add(vallas);


        }


        private void InicializarJugador()
        {


            player = new Player(hitbox, gameElementsColiders, gameElementsNormalOpacity);


        }


        public void render()
        {
            player.render();
        }

        public void update()
        {
            player.update();
        }



        private void Page_KeyDown(object sender, KeyEventArgs e)
        {


            switch (e.Key)
            {
                case Key.W:
                    player.setFront(true);
                    player.setMoving(true);
                    break;
                case Key.S:
                    player.setBack(true);
                    player.setMoving(true);
                    break;
                case Key.A:
                    player.setLeft(true);
                    player.setMoving(true);
                    break;
                case Key.D:
                    player.setRight(true);
                    player.setMoving(true);
                    break;
            }



        }

        private void Page_KeyUp(object sender, KeyEventArgs e)
        {


            switch (e.Key)
            {
                case Key.W:
                    player.setFront(false);
                    player.setMoving(false);
                    break;
                case Key.S:
                    player.setBack(false);
                    player.setMoving(false);
                    break;
                case Key.A:
                    player.setLeft(false);
                    player.setMoving(false);
                    break;
                case Key.D:
                    player.setRight(false);
                    player.setMoving(false);
                    break;
            }


        }

        private void Page_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {


            player.setAttacking(true);

        }
    }
}
