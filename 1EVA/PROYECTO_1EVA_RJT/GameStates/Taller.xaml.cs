using PROYECTO_1EVA_RJT.Entidades;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROYECTO_1EVA_RJT.GameStates
{
    /// <summary>
    /// Lógica de interacción para Taller.xaml
    /// </summary>
    public partial class Taller : Page, StateMethods
    {

        private Game game;
        private bool nuevaPieza = false;

        public int contador = 0;
        private bool completado = false;

        private DoubleAnimation rotateAnimation;
        private RotateTransform rotateTransform;
        private List<Ellipse> imagenesParaAnimar;
        private String[] texto = new String[4];


        public Taller(Game game)
        {
            InitializeComponent();
            this.game = game;
            Focusable = true;


        }


        public void AddElements()
        {
            throw new NotImplementedException();
        }

        public bool LoadElements()
        {
            throw new NotImplementedException();
        }

        public void Render()
        {
            MostrarPiezas();

        }

        private void MostrarPiezas()
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

        public void SaveElements()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {

            if (nuevaPieza)
            {
                btnSiguiente.Visibility = Visibility.Collapsed;

                return;
            }
            if (completado)
            {
                new JuegoCompletado();
                return;
            }

        }



        public void ComprobarPiezas()
        {

            ImageBrush pieza = null;

            if (GameManager.Nivel == Constantes.LvlConst.TUTORIAL)
            {
                pieza = GameManager.piezaBuscar.GetValueOrDefault(Constantes.LvlConst.TUTORIAL);

            }
            else if (GameManager.Nivel == Constantes.LvlConst.NIVEL1)
            {
                pieza = GameManager.piezaBuscar.GetValueOrDefault(Constantes.LvlConst.NIVEL1);

            }
            else if (GameManager.Nivel == Constantes.LvlConst.NIVEL2)
            {
                pieza = GameManager.piezaBuscar.GetValueOrDefault(Constantes.LvlConst.NIVEL2);

            }
            else if (GameManager.Nivel == Constantes.LvlConst.NIVEL3)
            {
                pieza = GameManager.piezaBuscar.GetValueOrDefault(Constantes.LvlConst.NIVEL3);

            }
            else if (GameManager.Nivel == Constantes.LvlConst.NIVEL4)
            {
                pieza = GameManager.piezaBuscar.GetValueOrDefault(Constantes.LvlConst.NIVEL4);

            }
            else if (GameManager.Nivel == Constantes.LvlConst.NIVEL5)
            {
                pieza = GameManager.piezaBuscar.GetValueOrDefault(Constantes.LvlConst.NIVEL5);

            }


            if (pieza != null)
            {

                CargarCanvas(pieza);
                CargarTextos(GameManager.Nivel);
                piezas.Effect = new BlurEffect();
                nuevaPieza = true;



            }




        }

        private void CargarCanvas(ImageBrush pieza)
        {

            piezaFotoCanva.Fill = pieza;
            piezaFotoCanva.Fill.SetCurrentValue(ImageBrush.StretchProperty, Stretch.Uniform);
            piezaFotoDialog.Fill = pieza;
            piezaFotoDialog.Fill.SetCurrentValue(ImageBrush.StretchProperty, Stretch.Uniform);

            Canvas.SetLeft(piezaRecogida, padre.Width / 2 - piezaRecogida.Width / 2);
            Canvas.SetTop(piezaRecogida, padre.Height / 2 - piezaRecogida.Height / 2);

            piezaRecogida.Visibility = Visibility.Visible;


        }
        private void CargarTextos(string nivel)
        {


            if (nivel == Constantes.LvlConst.TUTORIAL)
            {

                texto[0] = "¡Enhorabuena! Has encontrado la TORRE.";
                texto[1] = "Te explicare para que sirve una TORRE: ";
                texto[2] = "Torre de computadora. Este termino se utiliza dentro de la Informática para describir la caja donde se montan y conectan todos los dispositivos que componen la unidad central de la computadora personal. ";
                texto[3] = "Veo que se te da muy bien buscar piezas, asi que ahora necesito una pieza más :) VAMOS A QUE ESPERAS VE AL SIGUIENTE NIVEL";


            }

            else if (nivel == Constantes.LvlConst.NIVEL1)
            {
                texto[0] = "¡Enhorabuena! Has encontrado la RAM.";
                texto[1] = "Te explicare para que sirve la RAM: ";
                texto[2] = "La memoria de acceso aleatorio, o RAM (Random Access Memory), es la memoria que se utiliza para almacenar los datos y programas que se están utilizando en un momento determinado. ";
                texto[3] = "Veo que se te da muy bien buscar piezas, asi que ahora necesito una pieza más :) VAMOS A QUE ESPERAS VE AL SIGUIENTE NIVEL";

            }
            else if (nivel == Constantes.LvlConst.NIVEL5)
            {
                texto[0] = "¡Enhorabuena! Has encontrado la PLACA BASE.";
                texto[1] = "Te explicare para que sirve la PLACA BASE: ";
                texto[2] = "La placa base, o motherboard, es el componente principal de un ordenador, en el que se encuentran o al que están conectados todos los demás componentes y dispositivos. ";
                texto[3] = "Sabía que esto es lo tuyo, se te da muy bien, es importante que comprendas la utilidad de cada pieza, si tienes alguna duda solo haz clic sobre las imagenes y aparecera una breve explicacion";


            }

            else if (nivel == Constantes.LvlConst.NIVEL3)
            {
                texto[0] = "¡Enhorabuena! Has encontrado la GPU.";
                texto[1] = "Te explicare para que sirve la GPU: ";
                texto[2] = "La unidad de procesamiento gráfico, o GPU (Graphics Processing Unit), es un circuito integrado que se encarga de procesar los datos relacionados con la salida de vídeo. ";
                texto[3] = "Veo que se te da muy bien buscar piezas, asi que ahora necesito una pieza más :) VAMOS A QUE ESPERAS VE AL SIGUIENTE NIVEL";

            }
            else if (nivel == Constantes.LvlConst.NIVEL4)
            {
                texto[0] = "¡Enhorabuena! Has encontrado la CPU.";
                texto[1] = "Te explicare para que sirve la CPU: ";
                texto[2] = "La unidad central de procesamiento, o CPU (Central Processing Unit), es el componente principal de un ordenador, en el que se encuentran o al que están conectados todos los demás componentes y dispositivos. ";
                texto[3] = "Veo que se te da muy bien buscar piezas, asi que ahora necesito una pieza más :) VAMOS A QUE ESPERAS VE AL SIGUIENTE NIVEL";

            }
            else if (nivel == Constantes.LvlConst.NIVEL2)
            {
                texto[0] = "¡Enhorabuena! Has encontrado la PS.";
                texto[1] = "Te explicare para que sirve la PS: ";
                texto[2] = "La fuente de alimentación, o PS (Power Supply), es el dispositivo que suministra energía eléctrica a un ordenador. ";
                texto[3] = "Veo que se te da muy bien buscar piezas, asi que ahora necesito una pieza más :) VAMOS A QUE ESPERAS VE AL SIGUIENTE NIVEL";

            }

        }






        private void piezaRecogida_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            piezaRecogida.Visibility = Visibility.Collapsed;
            dialogo.Visibility = Visibility.Visible;
            iniciarTexto();

        }
        private void dialogo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            contador++;
            if (contador == 1)
            {
                textoDialogo.Text = texto[1];
            }
            else if (contador == 2)
            {
                textoDialogo.Text = texto[2];
            }
            else if (contador == 3)
            {
                textoDialogo.Text = texto[3];
            }
            else if (contador == 4)
            {
                dialogo.Visibility = Visibility.Collapsed;
                contador = 0;
                nuevaPieza = false;
                btnSiguiente.Visibility = Visibility.Visible;
                piezas.Effect = null;

            }





        }

        private void iniciarTexto()
        {
            textoDialogo.Text = texto[0];
        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {



            switch (GameManager.PreviousState)
            {
                case GameState.TUTORIAL:
                    GameManager.ChangeState(GameState.TUTORIAL);
                    game.MainFrame.Navigate(game.Tutorial);
                    game.Tutorial.Finalizado();
                    game.Tutorial.checkHouse();



                    break;
                case GameState.PLAYING:
                    game.MainFrame.Navigate(game.Playing);
                    GameManager.ChangeState(GameState.PLAYING);
                    break;
                case GameState.MENU:
                    if (game.Tutorial.isFinalizado())
                    {
                        game.MainFrame.Navigate(game.Playing);
                        GameManager.ChangeState(GameState.PLAYING);
                    }
                    else
                    {
                        game.MainFrame.Navigate(game.Tutorial);
                        GameManager.ChangeState(GameState.TUTORIAL);
                        game.Tutorial.Finalizado();
                        game.Tutorial.checkHouse();
                    }
                    break;
            }



        }

        private void Pausa_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            e.Handled = true;
            PauseSettings pauseSettings = new PauseSettings(game);
            pauseSettings.Owner = game;
            pauseSettings.ShowDialog();


        }
    }
}

