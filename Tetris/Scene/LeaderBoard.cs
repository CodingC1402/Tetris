using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tetris.CustomWfControls;

namespace Tetris
{
    public partial class LeaderBoard : Scene
    {
        bool _transiting = false;
        List<Bitmap> _controlsBitmaps;
        Bitmap _mainMenuBG = Images.GameModeSelection;

        public LeaderBoard()
        {
            InitializeComponent();
            SetControlVisibility(false);
            DoubleBuffered = true;
            _controlsBitmaps = GetBitmapFromControls();

            _transition.TransitionInFinished += (s, e) =>
            {
                SetControlVisibility(true);
                _transiting = false;
            };

            Resize += (s, e) =>
            {
                Invalidate();
            };

            gameModeSelection.OriginalSize = gameModeSelection.Size;
            //gameModeSelection.UsingHoverAnimation = true;
            gameModeSelection.Click += (s, e) =>
            {
                CleanUpTransition();
                MainWindow.Instance.ToGameModeSelection(_transition.TransitionOutTime);
            };

            VisibleChanged += (s, e) =>
            {
                normalBoard.SetBoardItem(Logic.LeaderBoard.Collection[Logic.LeaderBoard.NormalScoreName]);
                risingBoard.SetBoardItem(Logic.LeaderBoard.Collection[Logic.LeaderBoard.RisingFloorName]);
                _transiting = true;

                SetControlVisibility(false);
                _transition.StartTransitionIn();
            };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var ratio = Height / (float)_mainMenuBG.Height;

            Rectangle drawingRect = new Rectangle(0, 0, (int)(_mainMenuBG.Width * ratio), (int)(_mainMenuBG.Height * ratio));
            drawingRect.X = (Width - (drawingRect.Width)) / 2;
            drawingRect.Y = (Height - (drawingRect.Height)) / 2;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.DrawImage(_mainMenuBG, drawingRect);

            if (_transiting)
            {
                for (int i = 0; i < _controlsBitmaps.Count; i++)
                {
                    e.Graphics.DrawImage(_controlsBitmaps[i], Controls[i].Bounds);
                }
            }
            base.OnPaint(e);
        }

        public override void Render()
        {
            if (_transiting)
                base.Render();
        }

        protected void CleanUpTransition()
        {
            gameModeSelection.ForceStopAnim();
            _controlsBitmaps = GetBitmapFromControls();
            _transiting = true;
            SetControlVisibility(false);
            _transition.StartTransitionOut();
        }
    }
}
