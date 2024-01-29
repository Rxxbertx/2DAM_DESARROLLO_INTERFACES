
using PROYECTO_EV2_RJT.VIEW;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Effects;

namespace PROYECTO_EV2_RJT.REPORTS
{
    /// <summary>
    /// Lógica de interacción para reports.xaml
    /// </summary>
    public partial class Reports : Window
    {
        private string? file;

        public Reports(string file)
        {
            InitializeComponent();

            this.file = file;

        }

        public Reports()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Owner != null)
            {
                Owner.Effect = new BlurEffect();
 
            }


            if (string.IsNullOrEmpty(file))
            {
                new V_ErrorWindow("No se ha seleccionado ningún reporte") { Owner = this }.ShowDialog();
                Close();
                return;
            }




            report.ReportPath = Path.Combine(Environment.CurrentDirectory, "REPORTS", $"{file}.rdl");
            report.RefreshReport();



        }

        private void Control_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button boton)
            {
                switch (boton.Name)
                {
                    case "exit":
                        Close();
                        break;
                    case "minimize":
                        WindowState = WindowState.Minimized;
                        break;
                    case "maximize":
                        WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
                        break;
                }
            }

        }
      
        private void Border_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {

            DragMove();


        }


        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (Owner != null)
                {
                    Owner.Effect = null;
                }
            }
            catch (Exception)
            {
            }

        }
    }
}

