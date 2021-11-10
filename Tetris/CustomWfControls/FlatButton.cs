using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PropertyChanged;

namespace Tetris.CustomWfControls
{
    [AddINotifyPropertyChangedInterface]
    public partial class FlatButton : Button
    {
        private int _cornerRadius;

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

        public FlatButton()
        {
            InitializeComponent();
            DoubleBuffered = true;

            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
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
