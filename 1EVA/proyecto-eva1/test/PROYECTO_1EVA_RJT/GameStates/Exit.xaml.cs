using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Lógica de interacción para Exit.xaml
    /// </summary>
    public partial class Exit : Window
    {
        public int status { get; private set; }


        public Exit(Game game)
        {
            InitializeComponent();
            this.Owner = game;
        }

        private void No_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            status = 1;
            Close();
            

        }

        private void Salir_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            status = 0;
            Close();

        }


    }
}
