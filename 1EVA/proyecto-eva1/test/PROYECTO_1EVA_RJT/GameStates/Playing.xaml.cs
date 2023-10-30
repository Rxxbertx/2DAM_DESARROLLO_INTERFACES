﻿using System;
using System.Windows;
using System.Windows.Controls;

namespace PROYECTO_1EVA_RJT.GameStates
{
    /// <summary>
    /// Lógica de interacción para Playing.xaml
    /// </summary>
    public partial class Playing : Page, StateMethods
    {
        Game game;
        public Playing(Game game)
        {
            InitializeComponent();
            this.game = game;
            volverMenu();
        }



        private void volverMenu()
        {

        }
        public void render()
        {
            throw new NotImplementedException();
        }

        public void update()
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            game.MainFrame.NavigationService.Navigate(new GameStates.Menu(this.game));
            GameManager.state = GameState.MENU;
        }
    }
}
