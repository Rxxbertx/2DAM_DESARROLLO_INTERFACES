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


        public Tutorial(Game game)
        {
            InitializeComponent();
            InicializarJugador();
        }

        public void render()
        {
            player.render(jugador);
        }

        public void update()
        {
            player.update();
        }

        private void InicializarJugador()
        {
            
            player = new Player(0, 0, 32, 32);
            

        }
    }
}
