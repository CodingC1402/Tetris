using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tetris.CustomWfControls
{
    public partial class CircelPause : Control
    {
        private Image _backGroundImage = null;
        private Control _referencing = null;

        public Color HoverColor { get; set; }

        public Control Referencing {
            get => _referencing;
            set
            {
                _referencing = value;
                Invalidate();
            }
        }

        public Image BackGroundImage
        {
            get => _backGroundImage;
            set
            {
                _backGroundImage = value;
                Invalidate();
            }
        }
        public CircelPause()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Resize += (s, e) =>
            {
                Invalidate();
            };
            LocationChanged += (s, e) =>
            {
                Invalidate();
            };
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            if (_referencing != null)
                using (Bitmap parentControlBmp = new Bitmap(Width, Height))
                {
                    _referencing.DrawToBitmap(parentControlBmp, new Rectangle(0, 0, Width, Height));
                    pe.Graphics.DrawImage(parentControlBmp, 0, 0);
                }

            using (Brush bgBrush = new SolidBrush(Color.FromArgb(220, Bounds.Contains(Parent.PointToClient(MousePosition)) ? HoverColor : BackColor)))
            {
                pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                var path = CustomControlHelpers.GetRoundPath(new Rectangle(Padding.Left, Padding.Top, Width - Padding.Left - Padding.Right, Height - Padding.Top - Padding.Bottom), Width - Padding.Top - Padding.Bottom);
                pe.Graphics.FillPath(bgBrush, path);
            }

            if (_backGroundImage != null)
            {
                pe.Graphics.DrawImage(_backGroundImage, Padding.Left, Padding.Top, Width - Padding.Left - Padding.Right, Height - Padding.Top - Padding.Bottom);
            }
        }
    }
}
