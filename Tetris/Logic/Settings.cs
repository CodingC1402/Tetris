using System;
using System.Collections.Generic;
using System.Text;
using Tetris.Sound;

namespace Tetris.Logic
{
    public class Settings
    {
        public const string Path = "Setting.ini";

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

            WriteReadBinaryUtils.Serialize(file, Path);
        }
    }

    [Serializable]
    public class SettingFile
    {
        public float MusicVolumn { get; set; }
        public float SoundEffectVolumn { get; set; }

        public void ApplySetting()
        {
            Music.Volumn = MusicVolumn;
            SoundEffect.SfxVolumn = SoundEffectVolumn;
        }
    }
}
