using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using Tetris.CustomWfControls;
using Tetris.Logic;

namespace Tetris
{
    public partial class MainMenu : Scene
    {
        private float _fadeTime = 1.5f;
        private float _fadeCounter;

        private Bitmap _startingBG = Images.StartingBG;
        private Bitmap _mainMenuBG = Images.MainMenuBG;

        private PointF _relativeStartButtonPos = new PointF(0.5f, 0.5f);
        private PointF _relativeQuitButtonPos = new PointF(0.5f, 0.65f);

        private float _floatInOffSet = 0.75f;

        private Transition transition;

        private enum State
        {
            WaitForInput,
            InMenu
        }
        private State _currentState = State.WaitForInput;

        public MainMenu()
        {
            InitializeComponent();
            transition = new Transition(this);
            pressAnyKeyToStartLable.Visible = startButton.Visible = quitButton.Visible = false;

            startButton.Click += (s, e) =>
            {
                pressAnyKeyToStartLable.Visible = startButton.Visible = quitButton.Visible = false;
                transition.StartTransitionOut();
                MainWindow.Instance.ToGame(transition.TransitionOutTime);
            };

            quitButton.Click += (s, e) =>
            {
                Program.Stop();
            };

            _fadeCounter = _fadeTime;
            DoubleBuffered = true;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (Visible)
            {
                transition.StartTransitionIn();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var ratioW = Width / (float)_startingBG.Width;
            var ratioH = Height / (float)_startingBG.Height;
            var ratio = MathF.Min(ratioH, ratioW);

            Rectangle drawingRect = new Rectangle(0, 0, (int)(_startingBG.Width * ratio), (int)(_startingBG.Height * ratio));
            drawingRect.X = (Width - (drawingRect.Width)) / 2;
            drawingRect.Y = (Height - (drawingRect.Height)) / 2;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (_currentState == State.InMenu)
                e.Graphics.DrawImage(_mainMenuBG, drawingRect);

            if (_fadeCounter > 0)
            {
                ColorMatrix colorMatrix = new ColorMatrix();
                colorMatrix.Matrix33 = _fadeCounter / _fadeTime;
                ImageAttributes imageAttributes = new ImageAttributes();
                imageAttributes.SetColorMatrix(colorMatrix);

                var floatInPosFactor = _floatInOffSet * (_fadeCounter / _fadeTime);
                var startPath = CustomControlHelpers.GetRoundPath(new Rectangle(startButton.Location.X, (int)(startButton.Location.Y + Height * floatInPosFactor), startButton.Width, startButton.Height), startButton.CornerRadius);
                var quitPath = CustomControlHelpers.GetRoundPath(new Rectangle(quitButton.Location.X, (int)(quitButton.Location.Y + Height * floatInPosFactor), quitButton.Width, quitButton.Height), quitButton.CornerRadius);

                using (Brush startBrush = new SolidBrush(startButton.BackColor))
                using (Brush quitBrush = new SolidBrush(quitButton.BackColor))
                {
                    e.Graphics.FillPath(startBrush, startPath);
                    e.Graphics.FillPath(quitBrush, quitPath);
                }

                e.Graphics.DrawImage(_startingBG, drawingRect, 0, 0, _startingBG.Width, _startingBG.Height, GraphicsUnit.Pixel, imageAttributes);

                if (_fadeCounter == _fadeTime)
                {
                    using (Brush textBrush = new SolidBrush(Color.FromArgb((int)(255 * _fadeCounter / _fadeTime), pressAnyKeyToStartLable.ForeColor)))
                    {
                        e.Graphics.DrawString(pressAnyKeyToStartLable.Text, pressAnyKeyToStartLable.Font, textBrush, pressAnyKeyToStartLable.Location);
                    }
                }
            }

            base.OnPaint(e);
        }

        public override void UpdateLogic()
        {
            if (_currentState == State.WaitForInput)
            {
                if (InputSystem.HaveKeyDown)
                {
                    _currentState = State.InMenu;
                }
                return;
            }

            var fadeFactor = _fadeCounter / (float)_fadeTime;
            fadeFactor *= _floatInOffSet;
            if (_fadeCounter > 0)
            {
                _fadeCounter -= Program.DeltaTime;
                if (_fadeCounter < 0)
                {
                    _fadeCounter = 0;
                    startButton.Visible = true;
                    quitButton.Visible = true;
                }
                return;
            }

        }

        public override void Render()
        {
            Invalidate();
        }

        protected void SetRelativePos(Control control, float relativeX, float relativeY)
        {
            var posX = relativeX * Width - control.Width / 2f;
            var posY = relativeY * Height - control.Height / 2f;

            control.Location = new Point((int)posX, (int)posY);
        }
    }
}
