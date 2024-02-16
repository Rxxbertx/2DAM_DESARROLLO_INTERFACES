
using System.IO;
using System.Windows;


namespace _2Eva_RJT.REPORTS
{
    /// <summary>
    /// Lógica de interacción para Reporte.xaml
    /// </summary>
    public partial class Reporte : Window
    {
        public Reporte()
        {
            InitializeComponent();

            report.ReportPath = Path.Combine(Environment.CurrentDirectory, "REPORTS", $"Planetas.rdl");
            report.RefreshReport();

            //el conector odbc se debe llamara examen las creadenciales bueno en pirncipcio es admin y dam2t

        }
    }
}
