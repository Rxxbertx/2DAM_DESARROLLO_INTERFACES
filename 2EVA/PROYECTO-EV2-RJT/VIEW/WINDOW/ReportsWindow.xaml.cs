
using System.Windows;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;

namespace PROYECTO_EV2_RJT.VIEW.WINDOW
{
    /// <summary>
    /// Lógica de interacción para ReportsWindow.xaml
    /// </summary>
    public partial class ReportsWindow : Window
    {
        public ReportsWindow()
        {
            InitializeComponent();

            ReportDocument reportDocument = new ReportDocument();

            //CrystalReportViewer reportViewer = new();
            //reportViewer.ReportSource = reportDocument;

            //host.Child = reportViewer;
        }
    }
}
