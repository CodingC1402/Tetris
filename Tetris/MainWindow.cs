using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris.CustomWfControls;

namespace Tetris
{
    public partial class MainWindow : Form
    {
        private static MainWindow _instance = null;
        public static MainWindow Instance { get => _instance; }

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

        private Scene _currentScene = null;
        public Scene CurrentScene
        {
            get => _currentScene;
        }
        public MainWindow()
        {
            InitializeComponent();
            _instance = this;

            KeyPreview = true;
            KeyDown += (s, e) =>
            {
                Logic.InputSystem.AddToStack(e.KeyCode, false, true);
            };
            KeyUp += (s, e) =>
            {
                Logic.InputSystem.AddToStack(e.KeyCode, false, false);
            };

            ToMainMenu(0);
        }

        public void ToMainMenu(float delay)
        {
            CustomControlHelpers.CallFunctionWithDelay(this, () => {
                ToScene(new MainMenu());
            }, delay);
        }

        public void ToGame(float delay)
        {
            CustomControlHelpers.CallFunctionWithDelay(this, () => {
                ToScene(new Game());
            }, delay);
        }

        public void ToScene(Scene scene)
        {
            if (_currentScene == scene || scene == null)
                return;

            if (_currentScene != null)
            {
                _currentScene.Visible = false;
                _currentScene.EndLogic();
            }

            scene.StartLogic();
            Controls.Add(scene);
            scene.Dock = DockStyle.Fill;
            scene.Visible = true;
            _currentScene = scene;
        }
    }
}
