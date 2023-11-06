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
using System.Windows.Shapes;

namespace PROYECTO_1EVA_RJT.GameStates
{
    /// <summary>
    /// Lógica de interacción para Ayuda.xaml
    /// </summary>
    public partial class Ayuda : Window
    {
        Game game;
        public Ayuda(Game game)
        {
            this.game = game;
            InitializeComponent();
            game.MainFrame.Effect = new System.Windows.Media.Effects.BlurEffect();
        }




        private void SalirX_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            game.MainFrame.Effect = null;
        }




        private void SalirX_MouseEnter(object sender, MouseEventArgs e)
        {
            salirX.Effect = new System.Windows.Media.Effects.DropShadowEffect();

        }

        private void SalirX_MouseLeave(object sender, MouseEventArgs e)
        {
            salirX.Effect = null;
        }


    }
}
