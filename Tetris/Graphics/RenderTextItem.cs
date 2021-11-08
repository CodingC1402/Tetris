using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace Tetris.Graphics
{
    public class RenderTextItem : RenderItem
    {
        public string text = "";
        public Font font;
        public Brush textBrush;
        public RectangleF desRect;

        public RenderTextItem()
        {
            smoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        }

        public override void Draw(System.Drawing.Graphics gfx)
        {
            base.Draw(gfx);

            if (font == null || textBrush == null)
                return;

            gfx.DrawString(text, font, textBrush, desRect);
        }
    }
}
