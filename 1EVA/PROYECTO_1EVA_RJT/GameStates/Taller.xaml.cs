using PROYECTO_1EVA_RJT.Utilidades;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Threading;


namespace PROYECTO_1EVA_RJT.GameStates
{
    /// <summary>
    /// Lógica de interacción para Taller.xaml
    /// </summary>
    public partial class Taller : Page, StateMethods
    {

        private readonly Game game;
        private bool nuevaPieza = false;
        private DispatcherTimer? timer;



        public int contador = 0;
        private bool completado = false;

        private String[] texto = new String[4];


        public Taller(Game game)
        {
            InitializeComponent();
            this.game = game;
            Focusable = true;
            Focus();


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
                piezaFoto1.ToolTip = "Torre de computadora. Este termino se utiliza dentro de la Informática para describir la caja donde se montan y conectan todos los dispositivos que componen la unidad central de la computadora personal. ";

            }
            if (GameManager.inventario.Count > 1)
            {

                piezaFoto2.Fill = GameManager.inventario[1];
                piezaFoto2.Fill.SetCurrentValue(ImageBrush.StretchProperty, Stretch.Uniform);
                piezaFoto2.ToolTip = "La fuente de alimentación, o PS (Power Supply), es el dispositivo que suministra energía eléctrica a un ordenador. ";
            }
            if (GameManager.inventario.Count > 2)
            {
                piezaFoto3.Visibility = Visibility.Visible;
                piezaFoto3.Fill = GameManager.inventario[2];
                piezaFoto3.Fill.SetCurrentValue(ImageBrush.StretchProperty, Stretch.Uniform);
                piezaFoto3.ToolTip = "La memoria de acceso aleatorio, o RAM (Random Access Memory), es la memoria que se utiliza para almacenar los datos y programas que se están utilizando en un momento determinado. ";
            }
            if (GameManager.inventario.Count > 3)
            {

                piezaFoto4.Fill = GameManager.inventario[3];
                piezaFoto4.Fill.SetCurrentValue(ImageBrush.StretchProperty, Stretch.Uniform);
                piezaFoto4.ToolTip = "La unidad central de procesamiento, o CPU (Central Processing Unit), es el componente principal de un ordenador, en el que se encuentran o al que están conectados todos los demás componentes y dispositivos. ";
            }
            if (GameManager.inventario.Count > 4)
            {

                piezaFoto5.Fill = GameManager.inventario[4];
                piezaFoto5.Fill.SetCurrentValue(ImageBrush.StretchProperty, Stretch.Uniform);
                piezaFoto5.ToolTip = "La unidad de procesamiento gráfico, o GPU (Graphics Processing Unit), es un circuito integrado que se encarga de procesar los datos relacionados con la salida de vídeo. ";
            }
            if (GameManager.inventario.Count > 5)
            {

                piezaFoto6.Fill = GameManager.inventario[5];
                piezaFoto6.Fill.SetCurrentValue(ImageBrush.StretchProperty, Stretch.Uniform);
                piezaFoto6.ToolTip = "La placa base, o motherboard, es el componente principal de un ordenador, en el que se encuentran o al que están conectados todos los demás componentes y dispositivos. ";
            }

        }



        public void Update()
        {

            if (nuevaPieza)
            {
                btnSiguiente.Visibility = Visibility.Collapsed;

                return;
            }

        }



        public void ComprobarPiezas()
        {

            ImageBrush? pieza = null;

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
            Sounds.lvlCompelted.Play();

        }
        private void CargarTextos(string nivel)
        {


            if (nivel == Constantes.LvlConst.TUTORIAL)
            {

                texto[0] = "¡Enhorabuena! " + Constantes.NombreUsuario + " Has encontrado la TORRE.";
                texto[1] = "Te explicare para que sirve una TORRE: ";
                texto[2] = "Torre de computadora. Este termino se utiliza dentro de la Informática para describir la caja donde se montan y conectan todos los dispositivos que componen la unidad central de la computadora personal. ";
                texto[3] = "Veo que se te da muy bien buscar piezas, asi que ahora necesito una pieza más :) VAMOS A QUE ESPERAS VE AL SIGUIENTE NIVEL";


            }

            else if (nivel == Constantes.LvlConst.NIVEL2)
            {
                texto[0] = "¡Enhorabuena! " + Constantes.NombreUsuario + " Has encontrado la RAM.";
                texto[1] = "Te explicare para que sirve la RAM: ";
                texto[2] = "La memoria de acceso aleatorio, o RAM (Random Access Memory), es la memoria que se utiliza para almacenar los datos y programas que se están utilizando en un momento determinado. ";
                texto[3] = "Veo que se te da muy bien buscar piezas, asi que ahora necesito una pieza más :) VAMOS A QUE ESPERAS VE AL SIGUIENTE NIVEL";

            }
            else if (nivel == Constantes.LvlConst.NIVEL5)
            {
                texto[0] = "¡Enhorabuena! " + Constantes.NombreUsuario + " Has encontrado la PLACA BASE.";
                texto[1] = "Te explicare para que sirve la PLACA BASE: ";
                texto[2] = "La placa base, o motherboard, es el componente principal de un ordenador, en el que se encuentran o al que están conectados todos los demás componentes y dispositivos. ";
                texto[3] = "Sabía que esto es lo tuyo " + Constantes.NombreUsuario + ", se te da muy bien, es importante que comprendas la utilidad de cada pieza, si tienes alguna duda solo haz clic sobre las imagenes y aparecera una breve explicacion. " +
                    "PERO ESTO NO TERMINA AQUÍ, HAZ CLICK EN MONTAR EL PC PARA ACABAR TU MISIÓN";


            }

            else if (nivel == Constantes.LvlConst.NIVEL3)
            {
                texto[0] = "¡Enhorabuena! " + Constantes.NombreUsuario + " Has encontrado la GPU.";
                texto[1] = "Te explicare para que sirve la GPU: ";
                texto[2] = "La unidad de procesamiento gráfico, o GPU (Graphics Processing Unit), es un circuito integrado que se encarga de procesar los datos relacionados con la salida de vídeo. ";
                texto[3] = "Veo que se te da muy bien buscar piezas, asi que ahora necesito una pieza más :) VAMOS A QUE ESPERAS VE AL SIGUIENTE NIVEL";

            }
            else if (nivel == Constantes.LvlConst.NIVEL4)
            {
                texto[0] = "¡Enhorabuena! " + Constantes.NombreUsuario + " Has encontrado la CPU.";
                texto[1] = "Te explicare para que sirve la CPU: ";
                texto[2] = "La unidad central de procesamiento, o CPU (Central Processing Unit), es el componente principal de un ordenador, en el que se encuentran o al que están conectados todos los demás componentes y dispositivos. ";
                texto[3] = "Veo que se te da muy bien buscar piezas, asi que ahora necesito una pieza más :) VAMOS A QUE ESPERAS VE AL SIGUIENTE NIVEL";

            }
            else if (nivel == Constantes.LvlConst.NIVEL1)
            {
                texto[0] = "¡Enhorabuena! " + Constantes.NombreUsuario + " Has encontrado la PS.";
                texto[1] = "Te explicare para que sirve la PS: ";
                texto[2] = "La fuente de alimentación, o PS (Power Supply), es el dispositivo que suministra energía eléctrica a un ordenador. ";
                texto[3] = "Veo que se te da muy bien buscar piezas, asi que ahora necesito una pieza más :) VAMOS A QUE ESPERAS VE AL SIGUIENTE NIVEL";

            }

        }






        private void PiezaRecogida_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            piezaRecogida.Visibility = Visibility.Collapsed;
            dialogo.Visibility = Visibility.Visible;
            IniciarTexto();
            Sounds.dialog.Play();

        }
        private void Dialogo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            contador++;
            if (contador == 1)
            {
                new TextAnimation(textoDialogo, texto[1]).Start();
                Sounds.dialog.Play();
            }
            else if (contador == 2)
            {
                new TextAnimation(textoDialogo, texto[2]).Start();
                Sounds.dialog.Play();
            }
            else if (contador == 3)
            {
                new TextAnimation(textoDialogo, texto[3]).Start();
                Sounds.dialog.Play();
            }
            else if (contador == 4)
            {
                dialogo.Visibility = Visibility.Collapsed;
                contador = 0;
                nuevaPieza = false;
                btnSiguiente.Visibility = Visibility.Visible;
                piezas.Effect = null;

            }
            if (GameManager.Nivel == Constantes.LvlConst.NIVEL5)
            {

                btnSiguiente.Content = "MONTAR PC";


            }







        }

        private void IniciarTexto()
        {
            //textoDialogo.Text = texto[0];
            new TextAnimation(textoDialogo, texto[0]).Start();
        }

        private void BtnSiguiente_Click(object sender, RoutedEventArgs e)
        {

            Sounds.siguienteLvl.Play();

            if (sender is Button)
            {
                Button button = sender as Button;
                if (button != null && button.Content.Equals("MONTAR PC"))
                {
                    Sounds.winMusic.Play();
                    Sounds.GameMusic.Stop();
                    ExeFinal();
                    return;
                }
            }




            switch (GameManager.PreviousState)
            {
                case GameState.TUTORIAL:
                    GameManager.ChangeState(GameState.TUTORIAL);
                    game.MainFrame.Navigate(game.Tutorial);
                    game.Tutorial.Finished();
                    game.Tutorial.CheckHouse();



                    break;
                case GameState.PLAYING:

                    game.MainFrame.Navigate(game.Playing);
                    GameManager.ChangeState(GameState.PLAYING);
                    game.Playing.LoadNextLevel();


                    break;
                case GameState.MENU:

                    if (game.Tutorial.IsFinished())
                    {
                        game.MainFrame.Navigate(game.Playing);
                        GameManager.ChangeState(GameState.PLAYING);
                        game.Playing.LoadNextLevel();

                    }
                    else
                    {
                        game.MainFrame.Navigate(game.Tutorial);
                        GameManager.ChangeState(GameState.TUTORIAL);
                        game.Tutorial.Finished();
                        game.Tutorial.CheckHouse();
                    }
                    break;
            }
        }

        private void ExeFinal()
        {




            // Crea y configura un DispatcherTimer
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3); // Establece el intervalo a 3 segundos
            timer.Tick += Timer_Tick; // Agrega el controlador de eventos

            // Inicia el temporizador
            timer.Start();

            piezas.Effect = new BlurEffect();
            CanvaGif.Visibility = Visibility.Visible;
            btnSiguiente.Visibility = Visibility.Collapsed;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            final.Visibility = Visibility.Visible;
            Sounds.lvlCompelted.Play();
            Canvas.SetLeft(final, padre.Width / 2 - final.Width / 2);
            Canvas.SetTop(final, padre.Height / 2 - final.Height / 2);
            timer.Stop();


        }

        private void Pausa_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            e.Handled = true;
            PauseSettings pauseSettings = new(game)
            {
                Owner = game
            };
            pauseSettings.ShowDialog();


        }

        private void Final_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            e.Handled = true;
            game.Close();



        }

        public void CheckHouse()
        {

        }
    }
}

