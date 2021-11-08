using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Text;

namespace Tetris.Graphics
{
    public abstract class RenderItem
    {
        public SmoothingMode smoothingMode = SmoothingMode.None;
        public virtual void Draw(System.Drawing.Graphics gfx)
        {
            gfx.SmoothingMode = smoothingMode;
        }
    }
}
