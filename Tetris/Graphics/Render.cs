using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Tetris.Graphics
{
    public static class Renderer
    {
        private static float _counter = 0;
        private const float _maxCounter = 3;

        private static double _timePassed = 1;
        private static int _frameRendered = 0;
        private static int _resetFrame = 100;

        public static Label FpsLable = null;

        public static void Render()
        {
            _counter += Program.DeltaTime;
            _timePassed += Program.DeltaTime;

            if (_counter > _maxCounter)
                _counter = _maxCounter;

            if (_counter > Program.DeltaTimeBetweenRender)
            {
                MainWindow.Instance.CurrentScene?.Render();

                _counter -= Program.DeltaTimeBetweenRender;
                _frameRendered++;
            }

            if (FpsLable != null)
            {
                double currentFramePerSecond = _frameRendered / _timePassed;
                FpsLable.Text = "FPS " + currentFramePerSecond.ToString("N0");

                if (_frameRendered > _resetFrame)
                {
                    _frameRendered = (int)currentFramePerSecond;
                    _timePassed = 1;
                }
            }
        }
    }
}
