using System;
using System.Collections.Generic;
using System.Media;
using System.Text;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Tetris.Sound
{
    public class Sound
    {
        public readonly string ID;


        static Sound()
        {
            var wo = new WaveOutEvent();
            var af = new AudioFileReader(@"example.mp3");
            wo.Init(af);
            wo.Pla
        }

        private Sound(string id)
        {
            ID = id;

        }

        public void Play()
        {
            _soundPlayer.Play();
        }
    }
}
