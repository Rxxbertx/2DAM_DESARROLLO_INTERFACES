using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PROYECTO_1EVA_RJT.GameStates;

/// <summary>
/// Lógica de interacción para UI.xaml
/// </summary>
public partial class UI : UserControl // control de la interfaz de usuario
{

    private Game? game;
    public UI()
    {
        InitializeComponent();
        cargarInventario(); // carga el inventario

        Nivel.Content = GameManager.Nivel; // carga el nivel
        objetivo.Fill = GameManager.piezaBuscar[GameManager.Nivel]; // carga la pieza a buscar
        objetivo.Fill.SetCurrentValue(ImageBrush.StretchProperty, Stretch.Uniform); // ajusta la imagen a la pantalla

    }

    private void cargarInventario()
    {


        // carga las piezas del inventario
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
        PauseSettings pauseSettings = new PauseSettings(game); // abre el menú de pausa
        pauseSettings.Owner = game;
        pauseSettings.ShowDialog();


    }

    private void Taller_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        e.Handled = true;

        GameManager.ChangeState(GameState.TALLER); // abre el taller
        game.MainFrame.NavigationService.Navigate(game.Taller); // navega al taller
        game.Taller.Focus();
        game.Taller.ComprobarPiezas();


    }
}
