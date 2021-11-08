using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Tetris.Logic
{
    public class InputEvent
    {
        public readonly Keys KeyCode;
        public readonly bool Repeat;
        public readonly bool IsKeyDown;

        public InputEvent(Keys keyCode, bool repeat, bool isKeyDown)
        {
            KeyCode = keyCode;
            Repeat = repeat;
            IsKeyDown = isKeyDown;
        }
    }
}
