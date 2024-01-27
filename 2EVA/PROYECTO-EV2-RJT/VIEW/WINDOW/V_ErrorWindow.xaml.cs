using PROYECTO_EV2_RJT.CORE.COMMANDS;
using PROYECTO_EV2_RJT.CORE.ENUMS;
using PROYECTO_EV2_RJT.CORE.UTILS;
using PROYECTO_EV2_RJT.VIEWMODEL;
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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PROYECTO_EV2_RJT.VIEW
{
    /// <summary>
    /// Lógica de interacción para V_ErrorWindow.xaml
    /// </summary>
    public partial class V_ErrorWindow : Window
    {

        public V_ErrorWindow( string errorMessage)
        {
            InitializeComponent();
            textMessage.Text = errorMessage;
        }



        public void InitWindow()
        {
            
            Owner.Effect = new BlurEffect();

        }


        private void Btn_Click(object sender, RoutedEventArgs e)
        {

            _=WindowAnimationUtils.FadeOutAndClose(this);
            

        }


        #region window events
        public void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Owner.Effect = null;
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitWindow();
        }

        #endregion window events






    }
}
