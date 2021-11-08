using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Game : Form
    {
        private static Game _instance = null;

        public static bool InFullScreenMode { get; private set; } = false;
        public static void FullScreen()
        {
            if (InFullScreenMode)
            {
                InFullScreenMode = false;
                _instance.FormBorderStyle = FormBorderStyle.Sizable;
                _instance.WindowState = FormWindowState.Normal;
            }
            else
            {
                InFullScreenMode = true;
                _instance.WindowState = FormWindowState.Normal;
                _instance.FormBorderStyle = FormBorderStyle.None;
                _instance.WindowState = FormWindowState.Maximized;
            }
        }

        public Game()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += (s, e) =>
            {
                Logic.InputSystem.AddToStack(e.KeyCode, false, true);
            };
            KeyUp += (s, e) =>
            {
                Logic.InputSystem.AddToStack(e.KeyCode, false, false);
            };

            _instance = this;
            Graphics.Renderer.FpsLable = fpsLabel;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
