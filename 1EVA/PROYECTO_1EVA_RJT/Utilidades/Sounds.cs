using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace PROYECTO_1EVA_RJT.Utilidades
{
    public static class Sounds
    {

        public static MediaPlayer GameMusic = new MediaPlayer();
        public static MediaPlayer MenuMusic = new MediaPlayer();
        public static MediaPlayer winMusic = new MediaPlayer();
        public static SoundPlayer door = new SoundPlayer(@"..\..\..\recursos\sounds\door.wav");
        public static SoundPlayer pop = new SoundPlayer(@"..\..\..\recursos\sounds\pop.wav");
        public static SoundPlayer hit = new SoundPlayer(@"..\..\..\recursos\sounds\hit.wav");
        public static SoundPlayer boton = new SoundPlayer(@"..\..\..\recursos\sounds\boton.wav");
        public static SoundPlayer found = new SoundPlayer(@"..\..\..\recursos\sounds\found.wav");
        public static SoundPlayer dialog = new SoundPlayer(@"..\..\..\recursos\sounds\keyboard.wav");
        public static SoundPlayer lvlCompelted = new SoundPlayer(@"..\..\..\recursos\sounds\lvlCompleted.wav");
        public static SoundPlayer tutoCompleted = new SoundPlayer(@"..\..\..\recursos\sounds\tutoCompleted.wav");
        public static SoundPlayer siguienteLvl = new SoundPlayer(@"..\..\..\recursos\sounds\siguienteLvl.wav");
        public static SoundPlayer piezaRecogida = new SoundPlayer(@"..\..\..\recursos\sounds\piezaRecogida.wav");

        
    

    public static void InitMusic()
        {

            door.Load();
            pop.Load();
            hit.Load();
            boton.Load();
            found.Load();
            dialog.Load();
            lvlCompelted.Load();
            tutoCompleted.Load();
            siguienteLvl.Load();
            piezaRecogida.Load();



            
            GameMusic.Open(new Uri(@"..\..\..\recursos\sounds\music.wav", UriKind.RelativeOrAbsolute));
            MenuMusic.Open(new Uri(@"..\..\..\recursos\sounds\menu.mp3", UriKind.RelativeOrAbsolute));
           
            winMusic.Open(new Uri(@"..\..\..\recursos\sounds\win.wav", UriKind.RelativeOrAbsolute));

            GameMusic.MediaEnded += MediaEndedHandler;
            winMusic.MediaEnded += MediaEndedHandler2;
            MenuMusic.MediaEnded += MediaEndedHandler3;

            GameMusic.Volume = Constantes.SoundLvl;
            winMusic.Volume = Constantes.SoundLvl;
            MenuMusic.Volume = Constantes.SoundLvl;

            MenuMusic.Play();

                
            
        }

        internal static void UpdateMusic()
        {
            
            if (Constantes.MUTED)
            {
                GameMusic.Volume = 0;
                winMusic.Volume = 0;
                MenuMusic.Volume = 0;


                Constantes.MUTED = true;
            }
            else
            {
                GameMusic.Volume = Constantes.SoundLvl;
                winMusic.Volume = Constantes.SoundLvl;
                MenuMusic.Volume = Constantes.SoundLvl;
                Constantes.MUTED = false;
            }
        }

        private static void MediaEndedHandler(object sender, EventArgs e)
        {
            // Reinicia la reproducción cuando el audio termina
            GameMusic.Position = TimeSpan.Zero;
            
            GameMusic.Play();
            
        }

        private static void MediaEndedHandler2(object sender, EventArgs e)
        {
            // Reinicia la reproducción cuando el audio termina
            winMusic.Position = TimeSpan.Zero;

            winMusic.Play();

        }

        private static void MediaEndedHandler3(object sender, EventArgs e)
        {
            // Reinicia la reproducción cuando el audio termina
            
            MenuMusic.Position = TimeSpan.Zero;
            MenuMusic.Play();

        }
    }

}
