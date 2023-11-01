using PROYECTO_1EVA_RJT.Entidades;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace PROYECTO_1EVA_RJT.GameStates.Houses;

public partial class House1 : Page, StateMethods
{

    private Game game;
    private Player player;
    private List<Rectangle> CollidableElements = new List<Rectangle>();
    private List<Rectangle> InteractiveElements = new List<Rectangle>();
    private List<Rectangle>[] NormalOpacityElements = new List<Rectangle>[2];



    public House1(Game game, Player player)
    {
        InitializeComponent();
        this.game = game;
        this.player = player;
        game.MainFrame.NavigationService.Navigate(this);
        Focus();
    }

    public void addElements()
    {

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


        //collidable
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
        InteractiveElements.Add(piezaPc);


    }

    public bool loadElements()
    {
        return true;
    }

    public void render()
    {
        player.render();
    }

    public void saveElements()
    {

    }

    public void update()
    {
        player.update();
    }




    private void Page_KeyDown(object sender, KeyEventArgs e)
    {


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
            player.setInteract(false);
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
            player.setInteract(true);
        }

    }




    private void Page_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {


        player.setAttacking(true);

    }

}
