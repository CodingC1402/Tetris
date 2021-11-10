using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PropertyChanged;
using System.Drawing.Drawing2D;

namespace Tetris.CustomWfControls
{
    [AddINotifyPropertyChangedInterface]
    public partial class Slider : Control
    {
        private int _sliderHeight = 10;
        private int _thumbWidth = 10;
        private int _cornerRadius = 10;
        private float _value = 0;
        // This determent the actual width of the line;
        private int _workingWidth = 0;

        private Color _sliderColor = Color.Gray;
        private Color _thumbColor = Color.White;

        private Bitmap _sliderBmp = null;
        private System.Drawing.Graphics _sliderGfx = null;

        private Bitmap _thumbBmp = null;
        private System.Drawing.Graphics _thumbGfx = null;

        private bool _redrawSlider = false;
        private bool _redrawThumb = false;

        private bool _changingValue;

        [Browsable(true), Category("Appearance")]
        public int SliderHeight {
            get => _sliderHeight;
            set
            {
                _sliderHeight = value;
                Invalidate();
            }
        }
        [Browsable(true), Category("Appearance")]
        public int ThumbWidth {
            get => _thumbWidth;
            set
            {
                _thumbWidth = value;
                UpdateWorkingWidth();
                Invalidate();
            }
        }
        [Browsable(true), Category("Appearance")]
        public int CornerRadius {
            get => _cornerRadius;
            set
            {
                _cornerRadius = value;
                Invalidate();
            }
        }

        [Browsable(true), Category("Appearance")]
        public float Value
        {
            get => _value;
            set
            {
                _value = Math.Clamp(value, 0, 1);
                Invalidate();
                OnValueChanged(new EventArgs());
            }
        }

        [Browsable(true), Category("Appearance")]
        public Color SliderColor
        {
            get => _sliderColor;
            set
            {
                _sliderColor = value;
                _redrawSlider = true;
                Invalidate();
            }
        }
        [Browsable(true), Category("Appearance")]
        public Color ThumbColor
        {
            get => _thumbColor;
            set
            {
                _thumbColor = value;
                _redrawThumb = true;
                Invalidate();
            }
        }

        private event EventHandler _valueChanged;
        public event EventHandler ValueChanged
        {
            add { _valueChanged += value; }
            remove { _valueChanged -= value; }
        }

        public Slider()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateWorkingWidth();

            CreateThumbBmp();
            CreateSliderBmp();
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            var localMousePos = PointToClient(MousePosition);
            Rectangle checkRect = new Rectangle((int)(_value * _workingWidth), 0, _thumbWidth, Height);
            if (checkRect.Contains(localMousePos))
            {
                _changingValue = true;
            }
            else
            {
                Rectangle sliderRect = new Rectangle((Width - _workingWidth) / 2, (Height - _sliderHeight) / 2, _workingWidth, _sliderHeight);
                if (sliderRect.Contains(localMousePos))
                {
                    Value = (localMousePos.X - _thumbWidth / 2) / (float)_workingWidth;
                    _changingValue = true;
                }
            }

            if (_changingValue)
            {
                Capture = true;
                Cursor = Cursors.SizeWE;
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!_changingValue)
                return;

            var localMousePos = PointToClient(MousePosition);
            Value = (localMousePos.X - _thumbWidth / 2) / (float)_workingWidth;
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (_changingValue)
            {
                _changingValue = false;
                Capture = false;
                Cursor = Cursors.Arrow;
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            if (_redrawSlider)
            {
                _sliderGfx.Clear(Color.Transparent);
                Rectangle sliderRect = new Rectangle((Width - _workingWidth) / 2, 0, _workingWidth, _sliderHeight);
                using (Brush sliderBrush = new SolidBrush(_sliderColor))
                {
                    var sliderBound = CustomControlHelpers.GetRoundPath(sliderRect, CornerRadius);
                    _sliderGfx.FillPath(sliderBrush, sliderBound);
                }
                _redrawSlider = false;
            }

            if (_redrawThumb)
            {
                _thumbGfx.Clear(Color.Transparent);
                Rectangle thumbRect = new Rectangle(0, 0, _thumbBmp.Width, _thumbBmp.Height);

                using (Brush thumbBrush = new SolidBrush(_thumbColor))
                {
                    var thumbBounds = CustomControlHelpers.GetRoundPath(thumbRect, CornerRadius);
                    _thumbGfx.FillPath(thumbBrush, thumbBounds);   
                }
                _redrawThumb = false;
            }

            pe.Graphics.DrawImage(_sliderBmp, 0, (Height - _sliderHeight) / 2);
            pe.Graphics.DrawImage(_thumbBmp, _workingWidth * _value, 0);
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            if (_valueChanged != null)
                _valueChanged(this, new EventArgs());
        }

        protected virtual void CreateSliderBmp()
        {
            _sliderBmp = new Bitmap(Width, _sliderHeight);
            _sliderGfx = System.Drawing.Graphics.FromImage(_sliderBmp);
            _sliderGfx.SmoothingMode = SmoothingMode.HighQuality;
            _redrawSlider = true;
        }

        protected virtual void CreateThumbBmp()
        {
            _thumbBmp = new Bitmap(ThumbWidth, Height);
            _thumbGfx = System.Drawing.Graphics.FromImage(_thumbBmp);
            _thumbGfx.SmoothingMode = SmoothingMode.HighQuality;
            _redrawThumb = true;
        }

        protected virtual void UpdateWorkingWidth()
        {
            _workingWidth = Width - _thumbWidth;
        }
    }
}
