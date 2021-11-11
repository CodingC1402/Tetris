using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PropertyChanged;
using Tetris.Sound;

namespace Tetris.CustomWfControls
{
    [AddINotifyPropertyChangedInterface]
    public partial class FlatButton : Button
    {
        private int _cornerRadius;
        private ScaleAnimation _hoverAnimation;
        private ScaleAnimation _mouseLeaveAnimation;
        private bool _isMouseInside = false;

        private SoundEffect _buttonClick = SoundEffect.Collection[SfxFileName.ButtonClick];

        private Size _originalSize;
        public Size OriginalSize {
            get => _originalSize;
            set {
                _originalSize = value;
                _hoverAnimation.OriginalSize = value;
                _mouseLeaveAnimation.OriginalSize = value;
            }
        }

        [Browsable(true), Category("Appearance")]
        public int CornerRadius
        {
            get => _cornerRadius;
            set
            {
                _cornerRadius = value;
                Invalidate();
            }
        }

        private bool _usingHoverAnimation = false;
        [Browsable(true), Category("Appearance")]
        public bool UsingHoverAnimation {
            get => _usingHoverAnimation;
            set
            {
                _usingHoverAnimation = value;
            }
        }

        private float _hoverScale = 1.05f;
        [Browsable(true), Category("Appearance")]
        public float HoverScale
        {
            get => _hoverScale;
            set
            {
                _hoverScale = value;
                _hoverAnimation.ToValue = value;
                _mouseLeaveAnimation.FromValue = value;
            }
        }

        private float _animationTime = 0.2f;
        [Browsable(true), Category("Appearance")]
        public float AnimationTime
        {
            get => _animationTime;
            set
            {
                _hoverAnimation.AnimationTime = value;
                _mouseLeaveAnimation.AnimationTime = value;
                _animationTime = value;
            }
        }

        public void ForceStopAnim()
        {
            UsingHoverAnimation = false;
            _hoverAnimation.Stop();
            _mouseLeaveAnimation.Stop();
        }

        public FlatButton()
        {
            InitializeComponent();
            Click += (s, e) =>
            {
                _buttonClick.Play();
            };

            _hoverAnimation = new ScaleAnimation(this, 1, _hoverScale);
            _hoverAnimation.AnimationEnded += (s, e) =>
            {
                if (!IsMouseInside())
                {
                    PlayMouseLeaveAnimation();
                }
            };
            _hoverAnimation.AnimationTime = _animationTime;

            _mouseLeaveAnimation = new ScaleAnimation(this, _hoverScale, 1);
            _mouseLeaveAnimation.AnimationEnded += (s, e) =>
            {
                if (IsMouseInside())
                {
                    PlayMouseEnterAnimation();
                }
            };
            _mouseLeaveAnimation.AnimationTime = _animationTime;

            DoubleBuffered = true;

            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }

        protected bool IsMouseInside()
        {
            Rectangle bound = Bounds;
            bound.X = 0;
            bound.Y = 0;

            var localPos = PointToClient(MousePosition);
            return bound.Contains(localPos);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (_mouseLeaveAnimation.CurrentState == AnimationBase.State.Stopped && !_isMouseInside)
            {
                PlayMouseEnterAnimation();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (_hoverAnimation.CurrentState == AnimationBase.State.Stopped && _isMouseInside)
            {
                PlayMouseLeaveAnimation();
            }
        }

        protected void PlayMouseLeaveAnimation()
        {
            if (!_usingHoverAnimation)
                return;

            _isMouseInside = false;
            _mouseLeaveAnimation.Start();
        }

        protected void PlayMouseEnterAnimation()
        {
            if (!_usingHoverAnimation)
                return;

            _isMouseInside = true;
            _hoverAnimation.Start();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            if (_usingHoverAnimation)
            {
                pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                pe.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                pe.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                pe.Graphics.DrawImage(Images.ButtonBack, 0, 0, Width, Height);
            }

            pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            if (_cornerRadius > 0)
            {
                var cornerPaths = CustomControlHelpers.GetCornerPaths(new Rectangle(0, 0, Width, Height), _cornerRadius);
                using (Brush cornerBrush = new SolidBrush(Parent.BackColor))
                {
                    foreach (var corner in cornerPaths)
                    {
                        pe.Graphics.FillPath(cornerBrush, corner);
                    }
                }
            }
        }
    }
}
