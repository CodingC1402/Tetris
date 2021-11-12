using System;
using System.Collections.Generic;
using System.IO;
using NAudio.Wave;

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

        private List<KeyValuePair<AudioFileReader, DirectSoundOut>> _waveOutEvents = new List<KeyValuePair<AudioFileReader, DirectSoundOut>>();

        private event EventHandler<StoppedEventArgs> _finishPlaying;
        public event EventHandler<StoppedEventArgs> FinishPlaying
        {
            add { _finishPlaying += value; }
            remove { _finishPlaying -= value; }
        }

        private float _volumn = 1;
        public float Volumn
        {
            get => _volumn;
            set
            {
                value = Math.Clamp(value, 0, 1);
                if (_volumn != value)
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

            newSound = new SoundEffect(SfxFileName.CountDown, Path.Combine(AudioPath, SfxFileName.CountDown));
            Collection.Add(newSound.ID, newSound);

            newSound = new SoundEffect(SfxFileName.ButtonClick, Path.Combine(AudioPath, SfxFileName.ButtonClick));
            Collection.Add(newSound.ID, newSound);

            newSound = new SoundEffect(SfxFileName.GameStart, Path.Combine(AudioPath, SfxFileName.GameStart));
            Collection.Add(newSound.ID, newSound);

            newSound = new SoundEffect(SfxFileName.GameOver, Path.Combine(AudioPath, SfxFileName.GameOver));
            Collection.Add(newSound.ID, newSound);

            newSound = new SoundEffect(SfxFileName.GameOverHighScore, Path.Combine(AudioPath, SfxFileName.GameOverHighScore));
            Collection.Add(newSound.ID, newSound);
        }

        private SoundEffect(string id, string fileAddress)
        {
            ID = id;
            AudioAddress = fileAddress;
        }

        protected virtual void OnFinishPlaying(StoppedEventArgs e)
        {
            if (_finishPlaying != null)
                _finishPlaying(this, e);
        }

        public void Dispose()
        {
            foreach (var wo in _waveOutEvents)
            {
                wo.Value.Stop();
                wo.Key.Dispose();
                wo.Value.Dispose();
            }
            _waveOutEvents.Clear();
        }

        public void Play()
        {
            if (Stacking || (!Stacking && (_waveOutEvents.Count == 0)))
            {
                DirectSoundOut wo = new DirectSoundOut();
                AudioFileReader audioFileReader = new AudioFileReader(AudioAddress);
                audioFileReader.Volume = _sfxVolumn * _volumn;

                wo.Init(audioFileReader);
                wo.PlaybackStopped += DonePlaying;

                _waveOutEvents.Add(new KeyValuePair<AudioFileReader, DirectSoundOut>(audioFileReader, wo));
                wo.Play();
            }
        }

        private void DonePlaying(object sender, StoppedEventArgs e)
        {
            var wo = (DirectSoundOut)sender;
            OnFinishPlaying(e);
            foreach (var keyPair in _waveOutEvents)
            {
                if (wo == keyPair.Value)
                {
                    keyPair.Value.Stop();
                    keyPair.Value.Dispose();
                    keyPair.Key.Dispose();

                    _waveOutEvents.Remove(keyPair);
                    break;
                }
            }
        }

        private void UpdateVolumn()
        {
            foreach (var wo in _waveOutEvents)
            {
                wo.Key.Volume = _sfxVolumn * _volumn;
            }
        }
    }
}
