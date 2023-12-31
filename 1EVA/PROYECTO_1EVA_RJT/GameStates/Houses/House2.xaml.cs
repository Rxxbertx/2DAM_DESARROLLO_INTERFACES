﻿using PROYECTO_1EVA_RJT.Entidades;
using PROYECTO_1EVA_RJT.Utilidades;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace PROYECTO_1EVA_RJT.GameStates.Houses;

public partial class House2 : Page, StateMethods
{

    private Game game;
    private Player player;
    private bool completado = false;
    private List<Rectangle> CollidableElements = new List<Rectangle>();
    private List<Rectangle> InteractiveElements = new List<Rectangle>();
    private List<Rectangle>[] NormalOpacityElements = new List<Rectangle>[2];



    public House2(Game game, Player player)
    {
        InitializeComponent();
        this.game = game;
        this.player = player;
        game.MainFrame.NavigationService.Navigate(this);
        ui.cargarGame(game);
        AddElements();

        Focusable = true;
        Focus();
    }

    private void cargarCanva(Canvas canvaCompletado)
    {
        canvaCompletado.Visibility = System.Windows.Visibility.Visible;
        Canvas.SetLeft(canvaCompletado, Width / 2 - canvaCompletado.Width / 2);
        Canvas.SetTop(canvaCompletado, Height / 2 - canvaCompletado.Height / 2);
        completado = true; Sounds.piezaRecogida.Play(); ;
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





    public void AddElements()
    {

        if (GameManager.Nivel == Constantes.LvlConst.NIVEL1)
        {

            ps.Visibility = System.Windows.Visibility.Visible;
            gato.Visibility = System.Windows.Visibility.Visible;

            InteractiveElements.Add(ps);


        }
        else
        {
            ps.Visibility = System.Windows.Visibility.Hidden;
            gato.Visibility = System.Windows.Visibility.Hidden;
        }

        //image and opacity
        NormalOpacityElements[0] = new List<Rectangle>();
        NormalOpacityElements[1] = new List<Rectangle>();


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
        NormalOpacityElements[1].Add(objeto11N);
        NormalOpacityElements[0].Add(objeto11Opacidad);
        NormalOpacityElements[1].Add(objeto12N);
        NormalOpacityElements[0].Add(objeto12Opacidad);
        NormalOpacityElements[1].Add(objeto13N);
        NormalOpacityElements[0].Add(objeto13Opacidad);
        NormalOpacityElements[1].Add(objeto14N);
        NormalOpacityElements[0].Add(objeto14Opacidad);
        NormalOpacityElements[1].Add(objeto16N);
        NormalOpacityElements[0].Add(objeto16Opacidad);
        NormalOpacityElements[1].Add(objeto18N);
        NormalOpacityElements[0].Add(objeto18Opacidad);


        //collidable

        CollidableElements.Add(objeto1Hitbox);
        CollidableElements.Add(objeto2Hitbox);
        CollidableElements.Add(objeto3Hitbox);
        CollidableElements.Add(objeto4Hitbox);
        CollidableElements.Add(objeto5Hitbox);
        CollidableElements.Add(objeto6Hitbox);
        CollidableElements.Add(objeto7Hitbox);
        CollidableElements.Add(objeto8Hitbox);
        CollidableElements.Add(objeto10Hitbox);
        CollidableElements.Add(objeto11Hitbox);
        CollidableElements.Add(objeto12Hitbox);
        CollidableElements.Add(objeto13Hitbox);
        CollidableElements.Add(objeto14Hitbox);
        CollidableElements.Add(objeto15Hitbox);
        CollidableElements.Add(objeto16Hitbox);
        CollidableElements.Add(objeto17Hitbox);
        CollidableElements.Add(objeto18Hitbox);
        CollidableElements.Add(objeto19Hitbox);
        CollidableElements.Add(objeto20Hitbox);

        CollidableElements.Add(objetoPared1Hitbox);
        CollidableElements.Add(objetoPared2Hitbox);
        CollidableElements.Add(objetoPared3Hitbox);
        CollidableElements.Add(objetoPared4Hitbox);
        CollidableElements.Add(objetoPared5Hitbox);
        CollidableElements.Add(objetoPared6Hitbox);
        CollidableElements.Add(objetoPared7Hitbox);
        CollidableElements.Add(objetoPared8Hitbox);
        CollidableElements.Add(objetoPared9Hitbox);



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
        if (completado) return;
        player.Update();
        checkInteractiveElements();
    }

    private void checkInteractiveElements()
    {

        if (player.InteractiveObj != null)
        {
            if (player.InteractiveObj.Equals("ps"))
            {
                GameManager.addInventarioElemento(CargarGuardar.getPiezaFoto("ps"));
                cargarCanva(ui.canvaCompletado);
            }
        }


    }

    private void Page_KeyDown(object sender, KeyEventArgs e)
    {

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
