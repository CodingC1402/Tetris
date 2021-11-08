using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tetris.Graphics
{
    public partial class BitmapRenderer : Control
    {
        public readonly List<RenderItem> NeedToRender = new List<RenderItem>();

        protected Bitmap _bufferBitmap;
        protected System.Drawing.Graphics _bufferGfx;

        protected int _trueWidth = 0;
        protected int _trueHeight = 0;
        protected int _offSetX = 0;
        protected int _offSetY = 0;

        public bool PerfectPixel = true;

        public Bitmap BufferBitmap
        {
            get => _bufferBitmap;
        }

        public System.Drawing.Graphics graphics
        {
            get => _bufferGfx;
        }

        public BitmapRenderer()
        {
            InitializeComponent();
            SizeChanged += (s, e) =>
            {
                SetBoundsForBitmap();
            };

            DoubleBuffered = true;
        }

        public virtual void CreateBitmap(int width, int height)
        {
            _bufferBitmap = new Bitmap(width, height);
            _bufferGfx = System.Drawing.Graphics.FromImage(_bufferBitmap);
            _bufferGfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            _bufferGfx.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            _bufferGfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            SetBoundsForBitmap();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            if (_bufferBitmap == null)
                return;

            _bufferGfx.Clear(Color.Transparent);
            foreach (RenderItem item in NeedToRender)
            {
                item.Draw(_bufferGfx);
            }

            pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            pe.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Default;
            pe.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            pe.Graphics.DrawImage(_bufferBitmap, _offSetX, _offSetY, _trueWidth, _trueHeight);
            NeedToRender.Clear();
        }

        protected virtual void SetBoundsForBitmap()
        {
            if (_bufferBitmap == null)
                return;

            var ratioW = Bounds.Width / (float)_bufferBitmap.Width;
            var ratioH = Bounds.Height / (float)_bufferBitmap.Height;

            var ratio = Math.Min(ratioH, ratioW);
            if (PerfectPixel)
            {
                ratio = (int)(ratio);
                if (ratio < 1)
                    ratio = 1;
            }

            _trueWidth = (int)Math.Round(_bufferBitmap.Width * ratio);
            _trueHeight = (int)Math.Round(_bufferBitmap.Height * ratio);

            _offSetX = (int)Math.Round((Bounds.Width - _trueWidth) / 2.0f);
            _offSetY = (int)Math.Round((Bounds.Height - _trueHeight) / 2.0f);
        }
    }
}
