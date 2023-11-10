using PROYECTO_1EVA_RJT.Entidades;
using PROYECTO_1EVA_RJT.Utilidades;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace PROYECTO_1EVA_RJT.GameStates.Houses;

public partial class House1 : Page, StateMethods
{

    private Game game;
    private Player player; //player
    private bool completado = false; //si se ha completado el nivel
    private List<Rectangle> CollidableElements = new List<Rectangle>(); //elementos con los que colisiona
    private List<Rectangle> InteractiveElements = new List<Rectangle>(); //elementos con los que interactua
    private List<Rectangle>[] NormalOpacityElements = new List<Rectangle>[2]; //elementos con los que colisiona y se les cambia la opacidad



    public House1(Game game, Player player)
    {
        InitializeComponent(); //inicializar componentes
        this.game = game; //guardar game
        this.player = player; //guardar player
        game.MainFrame.NavigationService.Navigate(this); //navegar a esta pagina
        ui.cargarGame(game); //cargar game en ui
        AddElements(); //añadir elementos

        Focusable = true; //foco
        Focus(); 
    }

    private void cargarCanva(Canvas canvaCompletado)
    {
        //cargar canva completado
        canvaCompletado.Visibility = System.Windows.Visibility.Visible;
        Canvas.SetLeft(canvaCompletado, Width / 2 - canvaCompletado.Width / 2);
        Canvas.SetTop(canvaCompletado, Height / 2 - canvaCompletado.Height / 2);
        completado = true;
        Sounds.piezaRecogida.Play();
    }

    private void InicializarJugador()
    {




        // player = new Player(hitbox, gameElementsColiders, gameElementsNormalOpacity, canvaInteractuar, gameElementsInteractive);
        player.Jugador = hitbox;
        player.GameElementsColiders = CollidableElements;
        player.GameElementsNormalOpacity = NormalOpacityElements;
        player.CanvaInteractuar = ui.canvaInteractuar;
        player.GameElementsInteractive = InteractiveElements;
        player.setInteract(false);


    }





    public void AddElements() //añadir elementos a las listas de elementos
    {

        if (GameManager.Nivel == Constantes.LvlConst.TUTORIAL)//si es el tutorial 
        {
            //añadir elementos del tutorial
            torre.Visibility = System.Windows.Visibility.Visible;
            gato.Visibility = System.Windows.Visibility.Visible;

            InteractiveElements.Add(torre); //añadir torre a elementos interactivos


        }
        else
        {

            torre.Visibility = System.Windows.Visibility.Hidden;
            gato.Visibility = System.Windows.Visibility.Hidden;
        }

        //image and opacity
        NormalOpacityElements[0] = new List<Rectangle>();
        NormalOpacityElements[1] = new List<Rectangle>();

        //elementos con los que colisiona y se les cambia la opacidad
        NormalOpacityElements[1].Add(objeto1N);
        NormalOpacityElements[0].Add(objeto1Opacidad);
        NormalOpacityElements[1].Add(objeto2N);
        NormalOpacityElements[0].Add(objeto2Opacidad);
        NormalOpacityElements[1].Add(objeto3N);
        NormalOpacityElements[0].Add(objeto3Opacidad);
        NormalOpacityElements[1].Add(objeto4N);
        NormalOpacityElements[0].Add(objeto4Opacidad);
        NormalOpacityElements[1].Add(objeto5N);
        NormalOpacityElements[0].Add(objeto5Opacidad);
        NormalOpacityElements[1].Add(objeto6N);
        NormalOpacityElements[0].Add(objeto6Opacidad);


        //collidable

        //añadir elementos collidables 
        CollidableElements.Add(objeto1Hitbox);
        CollidableElements.Add(objeto2Hitbox);
        CollidableElements.Add(objeto3Hitbox);
        CollidableElements.Add(objeto4Hitbox);
        CollidableElements.Add(objeto5Hitbox);
        CollidableElements.Add(objeto6Hitbox);
        CollidableElements.Add(objeto7Hitbox);
        CollidableElements.Add(objeto8Hitbox);
        CollidableElements.Add(objeto9Hitbox);
        CollidableElements.Add(objeto10Hitbox);
        CollidableElements.Add(objetoPared1Hitbox);
        CollidableElements.Add(objetoPared2Hitbox);
        CollidableElements.Add(objetoPared3Hitbox);
        CollidableElements.Add(objetoPared4Hitbox);
        CollidableElements.Add(objetoPared5Hitbox);
        CollidableElements.Add(objetoPared6Hitbox);
        CollidableElements.Add(objetoPared7Hitbox);
        CollidableElements.Add(objetoPared8Hitbox);


        //interactive
        InteractiveElements.Add(salirPuerta);


        InicializarJugador();


    }


    public void Render()
    {
        player.Render();
    }


    public void Update()
    {
        if (completado) return; //si esta completado no hacer nada
        player.Update(); //actualizar player
        CheckInteractiveElements(); //comprobar elementos interactivos
    }

    private void CheckInteractiveElements() //comprobar elementos interactivos 
    {

        if (player.InteractiveObj != null) //si el player esta interactuando con algun elemento
        {
            if (player.InteractiveObj.Equals("torre")) //si es la torre
            {
                GameManager.addInventarioElemento(CargarGuardar.getPiezaFoto("torre")); //añadir pieza a inventario
                cargarCanva(ui.canvaCompletado); //cargar canva completado
            }
        }


    }

    private void Page_KeyDown(object sender, KeyEventArgs e) //cuando se pulsa una tecla
    {
        //diferentes teclas para moverse
        e.Handled = true;

        if (e.Key == Key.W)
        {

            player.setBack(true);
            // player.setMoving(true);

        }
        if (e.Key == Key.S)
        {

            player.setFront(true);
            // player.setMoving(true);
        }
        if (e.Key == Key.A)
        {
            player.setLeft(true);
            // player.setMoving(true);
        }
        if (e.Key == Key.D)
        {
            player.setRight(true);
            // player.setMoving(true);
        }

        if (e.Key == Key.E)
        {
            player.setInteract(true);
        }



    }

    private void Page_KeyUp(object sender, KeyEventArgs e)
    {





        if (e.Key == Key.W)
        {

            player.setBack(false);
            // player.setMoving(false);

        }
        if (e.Key == Key.S)
        {

            player.setFront(false);
            // player.setMoving(false);
        }
        if (e.Key == Key.A)
        {
            player.setLeft(false);
            // player.setMoving(false);
        }
        if (e.Key == Key.D)
        {
            player.setRight(false);
            // player.setMoving(false);
        }

        if (e.Key == Key.E)
        {
            player.setInteract(false);
        }

    }




    private void Page_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {

        e.Handled = true;

        player.setAttacking(true);

    }

    public void CheckHouse()
    {
        throw new System.NotImplementedException();
    }
}
