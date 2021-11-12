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

        private DirectSoundOut _currentWo;
        private AudioFileReader _currentAudioFile;
        private int _currentIndex = 0;

        public MusicGroup(string name, string[] audioFileNames)
        {
            Name = name;
            AudioFileNames = audioFileNames;
            _currentIndex = Program.Rnd.Next(0, audioFileNames.Length);

            _currentWo = new DirectSoundOut();
            _currentWo.PlaybackStopped += PlayStopped;
        }

        public void UpdateVolumn()
        {
            if (_currentAudioFile != null)
                _currentAudioFile.Volume = Music.MusicVolumn;
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
            _currentAudioFile = null;
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
            _currentAudioFile = new AudioFileReader(System.IO.Path.Combine(Music.AudioFile, AudioFileNames[_currentIndex]));
            _currentWo.Init(_currentAudioFile);
            UpdateVolumn();

            _currentWo.Play();
        }
    }
}
