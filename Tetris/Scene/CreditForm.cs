using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public partial class CreditForm : Scene
    {
        Bitmap _mainMenuBG = Images.creaditBG;
        bool _transiting = false;
        List<Bitmap> _controlsBitmaps;

        public CreditForm()
        {
            InitializeComponent();

            backBtn.UsingHoverAnimation = true;
            backBtn.OriginalSize = backBtn.Size;
            backBtn.Click += (s, e) =>
            {
                backBtn.ForceStopAnim();
                SetControlVisibility(false);
                _transition.StartTransitionOut();
                _controlsBitmaps = GetBitmapFromControls();
                _transiting = true;
                MainWindow.Instance.ToMainMenu(_transition.TransitionOutTime);
            };

            _transition.TransitionInFinished += (s, e) =>
            {
                SetControlVisibility(true);
                _transiting = false;
            };

            this.VisibleChanged += (s, e) =>
            {
                if (Visible)
                {
                    _controlsBitmaps = GetBitmapFromControls();
                    _transition.StartTransitionIn();
                    _transiting = true;
                }
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
    }
}
