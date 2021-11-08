using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace Tetris.Graphics
{
    public class RenderImageItem : RenderItem
    {
        public Bitmap image;
        public Rectangle srcRectangle;
        public Rectangle desRectangle;
        public ColorMatrix colorMatrix;

        public override void Draw(System.Drawing.Graphics gfx)
        {
            base.Draw(gfx);

            if (image == null)
                return;

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
