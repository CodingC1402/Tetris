using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris.CustomWfControls;
using Tetris.Graphics;
using Tetris.Sound;

namespace Tetris
{
    static class Program
    {
        private static bool _quit = false;
        private static Timer _clock = new Timer();
        private static int _framePerSecond;
        private static float _deltaTimeBetweenRender;

        private static float _deltaTime = 0;
        private static long _oldTimeStamp;

        public static Random Rnd = new Random();
        public static int GetRandom(int min, int max)
        {
            return Rnd.Next(min, max);
        }

        public static int FramePerSecond
        {
            get => _framePerSecond;
            set
            {
                _framePerSecond = value;
                _deltaTimeBetweenRender = 1 / (float)value;
            }
        }

        public static float DeltaTimeBetweenRender
        {
            get => _deltaTimeBetweenRender;
        }
        public static float DeltaTime
        {
            get => _deltaTime;
        }

        public static void Stop()
        {
            _quit = true;
        }

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Mark();
            // Tempt
            Music.StartPlayingMenuMusic();

            FramePerSecond = 30;
            _clock.Interval = 10;
            _clock.Tick += (s, e) =>
            {
                Mark();

                if (_quit)
                {
                    Logic.Logic.End();
                    Application.Exit();
                }
                else
                {
                    Logic.InputSystem.Update();
                    Transition.UpdateTransitions();
                    MainWindow.Instance.CurrentScene?.UpdateLogic();
                    Logic.InputSystem.FlushKeyDown();
                    Renderer.Render();
                }
            };
            _clock.Start();
            Application.Run(new MainWindow());
        }

        public static bool IsDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        }

        static void Mark()
        {
            long newStamp = DateTime.Now.Ticks;
            _deltaTime = (float)((newStamp - _oldTimeStamp) / 10000000.0);
            _oldTimeStamp = newStamp;
        }
    }
}
