using System.Collections.Generic;
using System.Windows.Forms;

namespace Tetris.Logic
{
    public static class InputSystem
    {
        private static Stack<InputEvent> _needToProcess = new Stack<InputEvent>();
        public static readonly Dictionary<string, Input> Inputs = new Dictionary<string, Input>();

        public static Input RotateInput;
        public static Input MoveLeftInput;
        public static Input MoveRightInput;
        public static Input MoveDownInput;
        public static Input ForcePlaceInput;

        public static bool HaveKeyDown { get; private set; }
        public static Keys FirstKeyDown { get; private set; }

        public static void AddToStack(Keys key, bool isRepeat, bool isKeyDown)
        {
            _needToProcess.Push(new InputEvent(key, isRepeat, isKeyDown));
        }

        public static void Update()
        {
            while (_needToProcess.Count > 0)
            {
                var key = _needToProcess.Pop();
                foreach (var inputKey in Inputs)
                {
                    var input = inputKey.Value;
                    if (input.KeyCode == key.KeyCode && (!input.IgnoreRepeat || (input.IgnoreRepeat && !key.Repeat)))
                    {
                        if (key.IsKeyDown && !input.IsKeyUp)
                            input.IsKeyPressed = key.IsKeyDown;
                        else if (!key.IsKeyDown && !input.IsKeyDown)
                            input.IsKeyPressed = key.IsKeyDown;
                    }
                }

                if (key.IsKeyDown && !HaveKeyDown)
                    FirstKeyDown = key.KeyCode;
                HaveKeyDown |= key.IsKeyDown;

                if (key.IsKeyDown && key.KeyCode == Keys.F11)
                {
                    MainWindow.FullScreen();
                }

                if (key.IsKeyDown && key.KeyCode == Keys.F12)
                {
                    BoardLogic.Start();
                }

                if (key.IsKeyDown && key.KeyCode == Keys.Escape)
                {
                    BoardLogic.Paused = !BoardLogic.Paused;
                }
            }
        }

        public static void FlushKeyDown()
        {
            foreach (var inputKey in Inputs)
            {
                var input = inputKey.Value;
                input.IsKeyDown = false;
                input.IsKeyUp = false;
            }
            HaveKeyDown = false;
        }
    }
}
