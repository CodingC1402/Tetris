using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Tetris.CustomWfControls;
using Tetris.Logic;
using Tetris.Sound;

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
        private PositionAnimation _optionBtnAnim;
        private PositionAnimation _creditAnim;

        private bool _mouseDown = false;
        private SoundEffect _startSoundEffect = SoundEffect.Collection[SfxFileName.GameStart];
        
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
            creditBtn.Visible = pressAnyKeyToStartLable.Visible = startButton.Visible = quitButton.Visible = optionBtn.Visible = false;

            MouseDown += (s, e) =>
            {
                _mouseDown = true;
            };

            Resize += (s, e) =>
            {
                UpdateAnimation();
            };

            startButton.UsingHoverAnimation = true;
            quitButton.UsingHoverAnimation = true;
            optionBtn.UsingHoverAnimation = true;
            creditBtn.UsingHoverAnimation = true;

            _startBtnAnim = new PositionAnimation(startButton);
            _quitBtnAnim = new PositionAnimation(quitButton);
            _optionBtnAnim = new PositionAnimation(optionBtn);
            _creditAnim = new PositionAnimation(creditBtn);
            _creditAnim.AnimationTime = _optionBtnAnim.AnimationTime = _quitBtnAnim.AnimationTime = _startBtnAnim.AnimationTime = _fadeTime;

            startButton.Click += (s, e) =>
            {
                StartTransition();
                MainWindow.Instance.ToGameModeSelection(_transition.TransitionOutTime);
            };

            optionBtn.Click += (s, e) =>
            {
                StartTransition();
                MainWindow.Instance.ToSettingMenu(_transition.TransitionOutTime);
            };

            quitButton.Click += (s, e) =>
            {
                Program.Stop();
            };

            creditBtn.Click += (s, e) =>
            {
                StartTransition();
                MainWindow.Instance.ToCredit(_transition.TransitionOutTime);
            };

            startButton.OriginalSize = startButton.Size;
            quitButton.OriginalSize = quitButton.Size;
            optionBtn.OriginalSize = optionBtn.Size;
            creditBtn.OriginalSize = creditBtn.Size;

            _fadeCounter = _fadeTime;
            DoubleBuffered = true;
        }

        private void StartTransition()
        {
            startButton.ForceStopAnim();
            quitButton.ForceStopAnim();
            optionBtn.ForceStopAnim();
            creditBtn.ForceStopAnim();

            creditBtn.Visible = pressAnyKeyToStartLable.Visible =  startButton.Visible = optionBtn.Visible = quitButton.Visible = false;
            _transition.StartTransitionOut();
        }

        protected void UpdateAnimation()
        {
            _startBtnAnim.FromValue = new Point(startButton.Location.X, startButton.Location.Y + Height); 
            _startBtnAnim.ToValue = startButton.Location;

            _quitBtnAnim.FromValue = new Point(quitButton.Location.X, quitButton.Location.Y + Height);
            _quitBtnAnim.ToValue = quitButton.Location;

            _optionBtnAnim.FromValue = new Point(optionBtn.Location.X, optionBtn.Location.Y + Height);
            _optionBtnAnim.ToValue = optionBtn.Location;

            _creditAnim.FromValue = new Point(creditBtn.Location.X, creditBtn.Location.Y + Height);
            _creditAnim.ToValue = creditBtn.Location;
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
                if (InputSystem.HaveKeyDown || _mouseDown)
                {
                    _currentState = State.InMenu;
                    _startSoundEffect.Play();
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
                    _optionBtnAnim.Start();
                    _creditAnim.Start();
                }
                return;
            }

        }

        protected void SetRelativePos(Control control, float relativeX, float relativeY)
        {
            var posX = relativeX * Width - control.Width / 2f;
            var posY = relativeY * Height - control.Height / 2f;

            control.Location = new Point((int)posX, (int)posY);
        }
    }
}
