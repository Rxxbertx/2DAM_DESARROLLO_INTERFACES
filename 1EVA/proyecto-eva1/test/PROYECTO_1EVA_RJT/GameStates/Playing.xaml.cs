using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Lógica de interacción para Playing.xaml
    /// </summary>
    public partial class Playing : Page, StateMethods
    {
        Game game;
        public Playing(Game game)
        {
            InitializeComponent();
            this.game = game;
            volverMenu();
        }

       

        private void volverMenu()
        {
            
        }
    public void render()
        {
            throw new NotImplementedException();
        }

        public void update()
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            game.MainFrame.NavigationService.Navigate(new GameStates.Menu(this.game));
            GameManager.state = GameState.MENU;
        }
    }
}
