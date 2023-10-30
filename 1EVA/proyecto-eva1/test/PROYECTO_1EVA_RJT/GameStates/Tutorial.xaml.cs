using PROYECTO_1EVA_RJT.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROYECTO_1EVA_RJT.GameStates
{
    /// <summary>
    /// Lógica de interacción para Tutorial.xaml
    /// </summary>
    public partial class Tutorial : Page , StateMethods
    {

        Player player;
        Game game;
        private List<Rectangle> gameElements = new List<Rectangle>();

        public Tutorial(Game game)
        {
            InitializeComponent();
            this.game = game;
            
            InicializarJugador();
            Focusable = true;
            Focus();

            addGameElements();

        }


        private void addGameElements()
        {

            
            
            gameElements.Add(Casa);
            gameElements.Add(arbol1);
            gameElements.Add(arbol2);
            gameElements.Add(arbol3);
            gameElements.Add(vallas);
            

        }


        private void InicializarJugador()
        {

            
            player = new Player(hitbox,gameElements);


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
