using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public static Random Rnd { get; private set; } = new Random();

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
                    Logic.Logic.Update();
                    Graphics.Renderer.Render();
                    Logic.InputSystem.FlushKeyDown();
                }
            };
            _clock.Start();
            Application.Run(new Game());
        }

        static void Mark()
        {
            long newStamp = DateTime.Now.Ticks;
            _deltaTime = (float)((newStamp - _oldTimeStamp) / 10000000.0);
            _oldTimeStamp = newStamp;
        }
    }
}
