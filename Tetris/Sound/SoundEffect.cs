using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Text;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Tetris.Sound
{
    public class SoundEffect : IDisposable
    {
        public static readonly string AudioPath = "";
        public static readonly string AudioFolder = @"AudioFiles\SoundEffects";

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
                    foreach (var sound in Collection)
                    {
                        sound.Value.UpdateVolumn();
                    }
                }
            }
        }

        public static Dictionary<string, SoundEffect> Collection;

        public readonly string ID = "";
        public readonly string AudioAddress = "";
        public bool Stacking = false;

        private List<WaveOutEvent> _waveOutEvents = new List<WaveOutEvent>();

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
        static SoundEffect()
        {
            AudioPath = AudioFolder;

            Collection = new Dictionary<string, SoundEffect>();

            SoundEffect newSound = new SoundEffect(SfxFileName.ClearOne1, Path.Combine(AudioPath, SfxFileName.ClearOne1));
            Collection.Add(newSound.ID, newSound);

            newSound = new SoundEffect(SfxFileName.ClearTwo1, Path.Combine(AudioPath, SfxFileName.ClearTwo1));
            Collection.Add(newSound.ID, newSound);

            newSound = new SoundEffect(SfxFileName.ClearThree1, Path.Combine(AudioPath, SfxFileName.ClearThree1));
            Collection.Add(newSound.ID, newSound);

            newSound = new SoundEffect(SfxFileName.Tetris1, Path.Combine(AudioPath, SfxFileName.Tetris1));
            Collection.Add(newSound.ID, newSound);

            newSound = new SoundEffect(SfxFileName.PlayerAction, Path.Combine(AudioPath, SfxFileName.PlayerAction));
            Collection.Add(newSound.ID, newSound);
        }

        private SoundEffect(string id, string fileAddress)
        {
            ID = id;
            AudioAddress = fileAddress;
        }

        public void Dispose()
        {
            foreach (var wo in _waveOutEvents)
            {
                wo.Stop();
                wo.Dispose();
            }
            _waveOutEvents.Clear();
        }

        public void Play()
        {
            if (Stacking || (!Stacking && (_waveOutEvents.Count == 0)))
            {
                WaveOutEvent wo = new WaveOutEvent();
                AudioFileReader audioFileReader = new AudioFileReader(AudioAddress);
                wo.Init(audioFileReader);
                wo.PlaybackStopped += DonePlaying;

                _waveOutEvents.Add(wo);
                wo.Play();
            }
        }

        private void DonePlaying(object sender, StoppedEventArgs e)
        {
            WaveOutEvent wo = sender as WaveOutEvent;
            _waveOutEvents.Remove(wo);
            wo.Dispose();
        }

        private void UpdateVolumn()
        {
            foreach (var wo in _waveOutEvents)
            {
                wo.Volume = _sfxVolumn * _volumn;
            }
        }
    }
}
