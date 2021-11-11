using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tetris.CustomWfControls;
using Tetris.Logic;

namespace Tetris
{
    public partial class GameModeSelection : Scene  
    {
        private Bitmap _mainMenuBG = Images.GameModeSelection;

        private PositionAnimation _risingFloorAnim;
        private PositionAnimation _normalAnim;
        private PositionAnimation _labelAnim;

        private List<Bitmap> _controlBitmap;

        private int _imagePadding = 40;

        public GameModeSelection()
        {
            InitializeComponent();
            DoubleBuffered = true;

            _risingFloorAnim = new PositionAnimation(risingFloorBtn);
            _normalAnim = new PositionAnimation(normalModeBtn);
            _labelAnim = new PositionAnimation(label);
            _labelAnim.AnimationTime = _risingFloorAnim.AnimationTime = _normalAnim.AnimationTime = 0.5f;

            SetControlVisibility(false);

            risingFloorBtn.Paint += DrawOnButton;
            normalModeBtn.Paint += DrawOnButton;

            Resize += (s, e) => UpdateAnimation();

            risingFloorBtn.UsingHoverAnimation = normalModeBtn.UsingHoverAnimation = true;
            risingFloorBtn.OriginalSize = risingFloorBtn.Size;
            normalModeBtn.OriginalSize = normalModeBtn.Size;

            risingFloorBtn.Click += (s, e) =>
            {
                BoardLogic.CurrentGameMode = BoardLogic.GameMode.RisingFloor;
                TransitionToGame();
            };

            normalModeBtn.Click += (s, e) =>
            {
                BoardLogic.CurrentGameMode = BoardLogic.GameMode.Normal;
                TransitionToGame();
            };

            backButton.Click += (s, e) =>
            {
                TransitionSetup();
                MainWindow.Instance.ToMainMenu(_transition.TransitionOutTime);
            };

            _transition.TransitionInFinished += (s, e) =>
            {
                SetControlVisibility(true);
            };
        }

        protected void DrawOnButton(object sender, PaintEventArgs e)
        {
            FlatButton flatButton = sender as FlatButton;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

            Rectangle rectangle = new Rectangle(_imagePadding, _imagePadding, flatButton.Width - _imagePadding * 2, flatButton.Height - _imagePadding * 2);

            if (sender == risingFloorBtn)
            {
                e.Graphics.DrawImage(Images.RisingFloorMode, rectangle);
            }
            else
            {
                e.Graphics.DrawImage(Images.NormalMode, rectangle);
            }
        }

        protected void UpdateAnimation()
        {
            _risingFloorAnim.FromValue = new Point(risingFloorBtn.Location.X + Width / 2, risingFloorBtn.Location.Y);
            _risingFloorAnim.ToValue = risingFloorBtn.Location;

            _normalAnim.FromValue = new Point(normalModeBtn.Location.X - Width / 2, normalModeBtn.Location.Y);
            _normalAnim.ToValue = normalModeBtn.Location;

            _labelAnim.FromValue = new Point(label.Location.X, label.Location.Y - Height / 2);
            _labelAnim.ToValue = label.Location;
        }

        protected void TransitionSetup()
        {
            risingFloorBtn.ForceStopAnim();
            normalModeBtn.ForceStopAnim();
            backButton.ForceStopAnim();
            SetControlVisibility(false);

            _controlBitmap = GetBitmapFromControls();
            _transition.StartTransitionOut();
        }

        protected void TransitionToGame()
        {
            TransitionSetup();
            MainWindow.Instance.ToGame(_transition.TransitionOutTime);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible)
            {
                _risingFloorAnim.Start();
                _labelAnim.Start();
                _normalAnim.Start();
                _transition.StartTransitionIn();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var ratio = Height / (float)_mainMenuBG.Height;

            Rectangle drawingRect = new Rectangle(0, 0, (int)(_mainMenuBG.Width * ratio), (int)(_mainMenuBG.Height * ratio));
            drawingRect.X = (Width - (drawingRect.Width)) / 2;
            drawingRect.Y = (Height - (drawingRect.Height)) / 2;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.DrawImage(_mainMenuBG, drawingRect);

            if (_controlBitmap != null)
            {
                for (int i = 0; i < _controlBitmap.Count; i++)
                {
                    e.Graphics.DrawImage(_controlBitmap[i], Controls[i].Bounds);
                }
            }

            base.OnPaint(e);
        }

        public override void Render()
        {
            base.Render();
            Invalidate();
        }
    }
}
