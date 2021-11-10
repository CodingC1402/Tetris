using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris.Sound;

namespace Tetris
{
    public partial class Game : Form
    {
        private static Game _instance = null;
        public static Game Instance { get => _instance; }

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
            this.VisibleChanged += (s, e) =>
            {
                LoadLogic();
                slider1.Value = Music.Volumn;
            };
            slider1.ValueChanged += (s, e) =>
            {
                Music.Volumn = slider1.Value;
            };

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

        public void UpdateLogic()
        {
            Logic.InputSystem.Update();
            Logic.Logic.Update();
            Graphics.Renderer.Render();
            Logic.InputSystem.FlushKeyDown();
        }

        public void LoadLogic()
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
