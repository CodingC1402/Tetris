using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tetris.Graphics
{
    public partial class LeaderBoardUI : BitmapRenderer
    {
        private int _textBoardPadding = 10;
        [Browsable(true), Category("Appearance")]
        public int TextBoardPadding
        {
            get => _textBoardPadding;
            set
            {
                _textBoardPadding = value;
                Invalidate();
            }
        }

        private Image _boardImage = null;
        [Browsable(true), Category("Appearance")]
        public Image BoardImage
        {
            get => _boardImage;
            set
            {
                _boardImage = value;
                Invalidate();
            }
        }

        private Font _itemFont = null;
        [Browsable(true), Category("Appearance")]
        public Font ItemFont
        {
            get => _itemFont;
            set
            {
                _itemFont = value;
                Invalidate();
            }
        }
        private Logic.LeaderBoard _item;

        private int _itemStringPadding = 35;

        public void SetBoardItem(Logic.LeaderBoard item)
        {
            _item = item;
            Invalidate();
        }

        public LeaderBoardUI()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            Resize += (s, e) =>
            {
                Invalidate();
            };
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            var strSze = pe.Graphics.MeasureString(Text, Font);
            RectangleF strRect = new RectangleF(0, 0, strSze.Width, strSze.Height);
            strRect.X = (Width - strSze.Width) / 2.0f;

            using (Brush textBrush = new SolidBrush(ForeColor))
            {
                pe.Graphics.DrawString(Text, Font, textBrush, strRect);
            }

            strSze.Height += _textBoardPadding;
            var drawingHeight = Height - strSze.Height;

            var ratioW = Width / (float) Images.LeaderBoard.Width;
            var ratioH = drawingHeight / (Images.LeaderBoard.Height);
            var ratio = MathF.Min(ratioW, ratioH);

            Rectangle imageRect = new Rectangle(0, 0, (int)(ratio * Images.LeaderBoard.Width) , (int)(ratio * Images.LeaderBoard.Height));
            imageRect.X = (Width - imageRect.Width) / 2;
            imageRect.Y = (int)(strSze.Height + (drawingHeight - imageRect.Height) / 2);

            pe.Graphics.DrawImage(Images.LeaderBoard, imageRect);

            if (_item != null)
            {
                int itemHeight = imageRect.Height / _item.Scores.Count;
                int currentItemHeight = (int)strSze.Height;

                foreach (var record in _item.Scores)
                {
                    if (record != null)
                    {
                        var score = record.Score.ToString();
                        var date = record.Date.ToString("dd/MM/yyyy");

                        var scoreSize = pe.Graphics.MeasureString(score, ItemFont);
                        var dateSize = pe.Graphics.MeasureString(date, ItemFont);

                        var drawY = currentItemHeight + (itemHeight - scoreSize.Height) / 2f;
                        var scoreX = imageRect.X + _itemStringPadding;
                        var dateX = imageRect.X + imageRect.Width - dateSize.Width - _itemStringPadding;

                        using (Brush brush = new SolidBrush(ForeColor))
                        {
                            pe.Graphics.DrawString(score, _itemFont, brush, scoreX, drawY);
                            pe.Graphics.DrawString(date, _itemFont, brush, dateX, drawY);
                        }
                    }
                    else
                    {
                        var str = "No record!";
                        var strSize = pe.Graphics.MeasureString(str, ItemFont);
                        var drawY = currentItemHeight + (itemHeight - strSize.Height) / 2f;
                        var drawX = imageRect.X + _itemStringPadding;

                        using (Brush brush = new SolidBrush(ForeColor))
                        {
                            pe.Graphics.DrawString(str, _itemFont, brush, drawX, drawY);
                        }
                    }

                    currentItemHeight += itemHeight;
                }
            }

            base.OnPaint(pe);
        }
    }
}
