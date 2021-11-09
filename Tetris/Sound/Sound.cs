using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Text;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Tetris.Sound
{
    public class Sound : IDisposable
    {
        public static readonly string AudioPath = "";
        public static readonly string AudioFolder = "AudioFiles";

        private static float _sfxVolumn = 1;
        public static float SfxVolumn
        {
            get => _sfxVolumn;
            set
            {
                value = Math.Clamp(value, 0, 1);
                if (_sfxVolumn != value)
                {
                    _sfxVolumn = value;
                    foreach (Sound sound in Collection)
                    {
                        sound.UpdateVolumn();
                    }
                }
            }
        }

        public static Sound[] Collection;

        public readonly string ID = "";
        public readonly string AudioAddress = "";
        private WaveOutEvent waveOutEvent = new WaveOutEvent();
        private float _volumn = 0;
        public float Volumn
        {
            get => _volumn;
            set
            {
                value = Math.Clamp(value, 0, 1);
                if (_sfxVolumn != value)
                {
                    _volumn = value;
                    UpdateVolumn();
                }
            }
        }
        static Sound()
        {
            AudioPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, AudioFolder);
            Collection = new Sound[] { 
                
            };
        }

        private Sound(string id, string fileAddress)
        {
            ID = id;
            AudioAddress = fileAddress;
            AudioFileReader audioFileReader = new AudioFileReader(fileAddress);
            waveOutEvent.Init(audioFileReader);
        }

        public void Dispose()
        {
            waveOutEvent.Dispose();
        }

        public void Play()
        {
            waveOutEvent.Play();
        }

        private void UpdateVolumn()
        {
            waveOutEvent.Volume = _sfxVolumn * _volumn;
        }
    }
}
