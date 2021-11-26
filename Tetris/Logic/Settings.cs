using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Tetris.Graphics;
using Tetris.Sound;

namespace Tetris.Logic
{
    public class Settings
    {
        public const string Path = "Setting.ini";
        public const int NumberOfSkin = 3;

        private static int _currentSkinIndex = 0;
        public static int CurrentSkinIndex 
        {
            get => _currentSkinIndex;
            set
            {
                if (value < 0)
                    value = NumberOfSkin - 1;
                value %= NumberOfSkin;

                _currentSkinIndex = value;

                Bitmap skin = null;
                switch (_currentSkinIndex)
                {
                    case 0:
                        skin = Images.SpriteImage;
                        break;
                    case 1:
                        skin = Images.SpriteImage2;
                        break;
                    case 2:
                        skin = Images.SpriteImage3;
                        break;
                    default:
                        skin = Images.SpriteImage;
                        break;
                }
                Texture.GetTexture(Texture.BlockTextureKey).Bmp = skin;
            }
        }

        public static void LoadSetting()
        {
            SettingFile file = WriteReadBinaryUtils.DeserialLize<SettingFile>(Path);
            file?.ApplySetting();
        }
        public static void SaveSetting()
        {
            SettingFile file = new SettingFile();

            file.MusicVolumn = Music.Volumn;
            file.SoundEffectVolumn = SoundEffect.SfxVolumn;
            file.SkinIndex = CurrentSkinIndex;

            WriteReadBinaryUtils.Serialize(file, Path);
        }
    }

    [Serializable]
    public class SettingFile
    {
        public float MusicVolumn { get; set; }
        public float SoundEffectVolumn { get; set; }
        public int SkinIndex { get; set; }

        public void ApplySetting()
        {
            Music.Volumn = MusicVolumn;
            SoundEffect.SfxVolumn = SoundEffectVolumn;
            Settings.CurrentSkinIndex = SkinIndex;
        }
    }
}
