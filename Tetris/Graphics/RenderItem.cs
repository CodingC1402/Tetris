using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace Tetris.Graphics
{
    public class RenderItem
    {
        public Bitmap image;
        public Rectangle srcRectangle;
        public Rectangle desRectangle;
        public ColorMatrix colorMatrix;
        public System.Drawing.Drawing2D.SmoothingMode smoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

        public void Draw(System.Drawing.Graphics gfx)
        {
            if (colorMatrix != null)
            {
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                gfx.DrawImage(image, desRectangle, srcRectangle.X, srcRectangle.Y, srcRectangle.Width, srcRectangle.Height, GraphicsUnit.Pixel, attributes);
            }
            else
            {
                gfx.DrawImage(image, desRectangle, srcRectangle, GraphicsUnit.Pixel);
            }
        }
    }
}
