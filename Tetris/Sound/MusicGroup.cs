using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris.Sound
{
    public  class MusicGroup
    {
        public readonly string Name = "";
        public readonly string[] AudioFileNames;
        public bool IsPlaying { get; private set; } = false;

        private WaveOutEvent _currentWo;
        private int _currentIndex = 0;

        public MusicGroup(string name, string[] audioFileNames)
        {
            Name = name;
            AudioFileNames = audioFileNames;
            _currentIndex = Program.Rnd.Next(0, audioFileNames.Length);

            _currentWo = new WaveOutEvent();
            _currentWo.PlaybackStopped += PlayStopped;
            UpdateVolumn();
        }

        public void UpdateVolumn()
        {
            _currentWo.Volume = Music.Volumn;
        }

        public void Start()
        {
            if (IsPlaying || AudioFileNames.Length == 0)
                return;

            IsPlaying = true;
            PlayCurrentFile();
        }

        public void Stop()
        {
            if (!IsPlaying)
                return;

            IsPlaying = false;
            _currentWo.Stop();
        }

        private void PlayStopped(object sender, StoppedEventArgs e)
        {
            if (!IsPlaying || AudioFileNames.Length == 0)
                return;

            _currentIndex = (_currentIndex + 1) % AudioFileNames.Length;
            PlayCurrentFile();
        }

        private void PlayCurrentFile()
        {
            AudioFileReader audioFileReader = new AudioFileReader(System.IO.Path.Combine(Music.AudioFile, AudioFileNames[_currentIndex]));
            _currentWo.Init(audioFileReader);
            _currentWo.Play();
        }
    }
}
