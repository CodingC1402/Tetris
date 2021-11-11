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
        private float _fadeTime = 0.5f;
        private float _fadeCounter;

        private Bitmap _startingBG = Images.StartingBG;
        private Bitmap _mainMenuBG = Images.MainMenuBG;

        private PositionAnimation _startBtnAnim;
        private PositionAnimation _quitBtnAnim;

        private enum State
        {
            WaitForInput,
            InMenu
        }
        private State _currentState = State.WaitForInput;

        public MainMenu()
        {
            InitializeComponent();
            _transition = new Transition(this);
            pressAnyKeyToStartLable.Visible = startButton.Visible = quitButton.Visible = false;

            Resize += (s, e) =>
            {
                UpdateAnimation();
            };

            startButton.UsingHoverAnimation = true;
            quitButton.UsingHoverAnimation = true;

            _startBtnAnim = new PositionAnimation(startButton);
            _quitBtnAnim = new PositionAnimation(quitButton);
            _quitBtnAnim.AnimationTime = _startBtnAnim.AnimationTime = _fadeTime;

            startButton.Click += (s, e) =>
            {
                startButton.ForceStopAnim();
                quitButton.ForceStopAnim();
                pressAnyKeyToStartLable.Visible = startButton.Visible = quitButton.Visible = false;
                _transition.StartTransitionOut();
                MainWindow.Instance.ToGameModeSelection(_transition.TransitionOutTime);
            };

            quitButton.Click += (s, e) =>
            {
                Program.Stop();
            };

            startButton.OriginalSize = startButton.Size;
            quitButton.OriginalSize = quitButton.Size;

            _fadeCounter = _fadeTime;
            DoubleBuffered = true;
        }

        protected void UpdateAnimation()
        {
            _startBtnAnim.FromValue = new Point(startButton.Location.X, startButton.Location.Y + Height); 
            _startBtnAnim.ToValue = startButton.Location;

            _quitBtnAnim.FromValue = new Point(quitButton.Location.X, quitButton.Location.Y + Height);
            _quitBtnAnim.ToValue = quitButton.Location;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (Visible)
            {
                _transition.StartTransitionIn();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var ratio = Height / (float)_startingBG.Height;

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

            if (_fadeCounter > 0)
            {
                _fadeCounter -= Program.DeltaTime;
                if (_fadeCounter < 0)
                {
                    _fadeCounter = 0;
                    _quitBtnAnim.Start();
                    _startBtnAnim.Start();
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
