using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris.Logic
{
    public class InputSetting
    {
        public const string InputSettingPath = "Input.setting";

        public static void LoadInput()
        {
            var loadedSetting = WriteReadBinaryUtils.DeserialLize<InputSettingFile>(InputSettingPath);
            loadedSetting ??= new InputSettingFile();

            InputSystem.Inputs.Clear();

            Input input = new Input(nameof(loadedSetting.MoveDown), loadedSetting.MoveDown);
            InputSystem.Inputs.Add(input.Name, input);
            InputSystem.MoveDownInput = input;

            input = new Input(nameof(loadedSetting.Rotate), loadedSetting.Rotate);
            InputSystem.Inputs.Add(input.Name, input);
            InputSystem.RotateInput = input;

            input = new Input(nameof(loadedSetting.ForcePlace), loadedSetting.ForcePlace);
            InputSystem.Inputs.Add(input.Name, input);
            InputSystem.ForcePlaceInput = input;

            input = new Input(nameof(loadedSetting.MoveLeft), loadedSetting.MoveLeft);
            InputSystem.Inputs.Add(input.Name, input);
            InputSystem.MoveLeftInput = input;

            input = new Input(nameof(loadedSetting.MoveRight), loadedSetting.MoveRight);
            InputSystem.Inputs.Add(input.Name, input);
            InputSystem.MoveRightInput = input;
        }

        public static void SaveInput()
        {
            InputSettingFile inputSetting = new InputSettingFile();

            inputSetting.MoveDown = InputSystem.MoveDownInput.KeyCode;
            inputSetting.MoveLeft = InputSystem.MoveLeftInput.KeyCode;
            inputSetting.MoveRight = InputSystem.MoveRightInput.KeyCode;
            inputSetting.Rotate = InputSystem.RotateInput.KeyCode;
            inputSetting.ForcePlace = InputSystem.ForcePlaceInput.KeyCode;

            WriteReadBinaryUtils.Serialize(inputSetting, InputSettingPath);
        }
    }

    [Serializable]
    public class InputSettingFile
    {
        public Keys MoveDown { get; set; } = Keys.S;
        public Keys ForcePlace { get; set; } = Keys.Q;
        public Keys Rotate { get; set; } = Keys.E;
        public Keys MoveRight { get; set; } = Keys.D;
        public Keys MoveLeft { get; set; } = Keys.A;
    }
}
