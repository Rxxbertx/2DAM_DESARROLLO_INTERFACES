using PROYECTO_1EVA_RJT.Utilidades;
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

namespace PROYECTO_1EVA_RJT.GameStates;

/// <summary>
/// Lógica de interacción para UI.xaml
/// </summary>
public partial class UI : UserControl
{

    private Game game;
    public UI()
    {
        InitializeComponent();
        cargarInventario();

        Nivel.Content = GameManager.Nivel;
        objetivo.Fill = GameManager.piezaBuscar[GameManager.Nivel];
        objetivo.Fill.SetCurrentValue(ImageBrush.StretchProperty, Stretch.Uniform);
        
    }

    private void cargarInventario()
    {

        

        if (GameManager.inventario.Count > 0)
        {
            piezaFoto1.Fill = GameManager.inventario[0];
            piezaFoto1.Fill.SetCurrentValue(ImageBrush.StretchProperty, Stretch.Uniform);
        }
        if (GameManager.inventario.Count > 1)
        {

            piezaFoto2.Fill = GameManager.inventario[1];
            piezaFoto2.Fill.SetCurrentValue(ImageBrush.StretchProperty, Stretch.Uniform);
        }
        if (GameManager.inventario.Count > 2)
        {
            piezaFoto3.Visibility = Visibility.Visible;
            piezaFoto3.Fill = GameManager.inventario[2];
            piezaFoto3.Fill.SetCurrentValue(ImageBrush.StretchProperty, Stretch.Uniform);
        }
        if (GameManager.inventario.Count > 3)
        {

            piezaFoto4.Fill = GameManager.inventario[3];
            piezaFoto4.Fill.SetCurrentValue(ImageBrush.StretchProperty, Stretch.Uniform);
        }
        if (GameManager.inventario.Count > 4)
        {

            piezaFoto5.Fill = GameManager.inventario[4];
            piezaFoto5.Fill.SetCurrentValue(ImageBrush.StretchProperty, Stretch.Uniform);
        }
        if (GameManager.inventario.Count > 5)
        {

            piezaFoto6.Fill = GameManager.inventario[5];
            piezaFoto6.Fill.SetCurrentValue(ImageBrush.StretchProperty, Stretch.Uniform);
        }



    }

    public void cargarGame(Game game)
    {
        this.game = game;

    }


    private void Pausa_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {

        e.Handled = true;
        PauseSettings pauseSettings = new PauseSettings(game);
        pauseSettings.Owner = game;
        pauseSettings.ShowDialog();

        
    }

    private void Taller_MouseLeftButtonDown(object sender ,MouseButtonEventArgs e)
    {
        e.Handled = true;
        
        GameManager.ChangeState(GameState.TALLER);
        game.MainFrame.NavigationService.Navigate(game.Taller);
        game.Taller.Focus();
        game.Taller.ComprobarPiezas();


    }
}
