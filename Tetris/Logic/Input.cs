using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Tetris.Logic
{
    public class Input
    {
        public readonly string Name;
        public readonly Keys KeyCode;

        private bool _isKeyPressed = false;
        public bool IsKeyPressed {
            get => _isKeyPressed;
            set
            {
                if (value && !_isKeyPressed)
                {
                    IsKeyDown = true;
                }
                else if (!value && _isKeyPressed)
                {
                    IsKeyUp = true;
                }
                _isKeyPressed = value;
            }
        }
        public bool IsKeyDown { get; set; } = false;
        public bool IsKeyUp { get; set; } = false;
        public bool IgnoreRepeat { get; set; } = true;
        
        public Input(string name, Keys keyCode)
        {
            Name = name;
            KeyCode = keyCode;
        }
    }
}
