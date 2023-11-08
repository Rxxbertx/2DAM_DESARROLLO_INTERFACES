using System;
using System.IO;
using System.Media;
using System.Windows.Media;

namespace PROYECTO_1EVA_RJT.Utilidades
{
    public static class Sounds
    {

        static string directorioBase = AppDomain.CurrentDomain.BaseDirectory;



        public static MediaPlayer GameMusic = new MediaPlayer();
        public static MediaPlayer MenuMusic = new MediaPlayer();
        public static MediaPlayer winMusic = new MediaPlayer();


        public static SoundPlayer door = new SoundPlayer(Path.Combine(directorioBase, "recursos", "sounds", "door.wav"));
        public static SoundPlayer pop = new SoundPlayer(Path.Combine(directorioBase, "recursos", "sounds", "pop.wav"));

        public static SoundPlayer hit = new SoundPlayer(Path.Combine(directorioBase, "recursos", "sounds", "hit.wav"));
        public static SoundPlayer boton = new SoundPlayer(Path.Combine(directorioBase, "recursos", "sounds", "boton.wav"));
        public static SoundPlayer found = new SoundPlayer(Path.Combine(directorioBase, "recursos", "sounds", "found.wav"));
        public static SoundPlayer dialog = new SoundPlayer(Path.Combine(directorioBase, "recursos", "sounds", "keyboard.wav"));
        public static SoundPlayer lvlCompelted = new SoundPlayer(Path.Combine(directorioBase, "recursos", "sounds", "lvlCompleted.wav"));
        public static SoundPlayer tutoCompleted = new SoundPlayer(Path.Combine(directorioBase, "recursos", "sounds", "tutoCompleted.wav"));
        public static SoundPlayer siguienteLvl = new SoundPlayer(Path.Combine(directorioBase, "recursos", "sounds", "siguienteLvl.wav"));
        public static SoundPlayer piezaRecogida = new SoundPlayer(Path.Combine(directorioBase, "recursos", "sounds", "piezaRecogida.wav"));




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




            GameMusic.Open(new Uri(Path.Combine(directorioBase, "recursos", "sounds", "music.wav")));
            MenuMusic.Open(new Uri(Path.Combine(directorioBase, "recursos", "sounds", "menu.mp3")));

            winMusic.Open(new Uri(Path.Combine(directorioBase, "recursos", "sounds", "win.wav")));

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
