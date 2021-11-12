using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris.Sound
{
    public static class Music
    {
        public static readonly string AudioFile = "AudioFiles/Musics";

        public static float MusicVolumn
        {
            get => _volumn * _volumnFilter;
        }

        private static float _volumnFilter = 1f;
        public static float VolumnFilter
        {
            get => _volumnFilter;
            set
            {
                value = Math.Clamp(value, 0, 1);
                if (_volumnFilter != value)
                {
                    _volumnFilter = value;
                    _gameGroup.UpdateVolumn();
                    _menuGroup.UpdateVolumn();
                }
            }
        }

        private static float _volumn = 1f;
        public static float Volumn
        {
            get => _volumn;
            set
            {
                value = Math.Clamp(value, 0, 1);
                if (_volumn != value)
                {
                    _volumn = value;
                    _gameGroup.UpdateVolumn();
                    _menuGroup.UpdateVolumn();
                }
            }
        }
        private static MusicGroup _gameGroup;
        private static MusicGroup _menuGroup;

        public static void StartPlayingGameMusic()
        {
            _menuGroup.Stop();
            _gameGroup.Start();
        }

        public static void StartPlayingMenuMusic()
        {
            _gameGroup.Stop();
            _menuGroup.Start();
        }

        static Music()
        {
            _gameGroup = new MusicGroup("GameGroup", new string[] { 
                GameTheme.Dingos,
                GameTheme.Flouride,
                GameTheme.Thermal,
                GameTheme._20XX
            });

            _menuGroup = new MusicGroup("MenuGroup", new string[] {
                MenuTheme.Prime
            });
        }
    }
}
