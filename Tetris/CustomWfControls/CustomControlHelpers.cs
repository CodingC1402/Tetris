using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Tetris.CustomWfControls
{
    public static class CustomControlHelpers
    {
        public static void CallFunctionWithDelay(Control control, Action action, float secs)
        {
            System.Threading.Timer timer = null;
            timer = new System.Threading.Timer((obj) =>
            {
                control.Invoke(action);
                timer.Dispose();
            },
            null, (int)(secs * 1000), System.Threading.Timeout.Infinite);
        }

        public static GraphicsPath GetRoundPath(RectangleF Rect, int radius)
        {
            GraphicsPath graphPath = new GraphicsPath();
            PointF topLeft = new PointF(Rect.X, Rect.Y);
            PointF bottomRight = new PointF(Rect.Width + Rect.X, Rect.Height + Rect.Y);

            graphPath.AddArc(topLeft.X, topLeft.Y, radius, radius, 180, 90);
            graphPath.AddArc(bottomRight.X - radius, topLeft.Y, radius, radius, 270, 90);
            graphPath.AddArc(bottomRight.X - radius, bottomRight.Y - radius, radius, radius, 0, 90);
            graphPath.AddArc(topLeft.X, bottomRight.Y - radius, radius, radius, 90, 90);
            graphPath.CloseFigure();
            return graphPath;
        }

        public static GraphicsPath[] GetCornerPaths(RectangleF Rect, int radius)
        {
            List<GraphicsPath> graphicsPaths = new List<GraphicsPath>();

            /**
             * 1            2
             *   __________
             *  |          |
             *  |__________|
             * 4            3
             */

            PointF topLeft = new PointF(Rect.X, Rect.Y);
            PointF bottomRight = new PointF(Rect.Width + Rect.X, Rect.Height + Rect.Y);

            GraphicsPath graphPath = new GraphicsPath();
            graphPath.AddArc(topLeft.X, topLeft.Y, radius, radius, 180, 90);
            graphPath.AddLine(topLeft.X - 1, topLeft.Y - 1, topLeft.X - 1, topLeft.Y + radius + 1);
            graphPath.CloseFigure();
            graphicsPaths.Add(graphPath);

            graphPath = new GraphicsPath();
            graphPath.AddArc(bottomRight.X - radius, topLeft.Y, radius, radius, 270, 90);
            graphPath.AddLine(bottomRight.X, topLeft.Y - 1, bottomRight.X - radius, topLeft.Y - 1);
            graphPath.CloseFigure();
            graphicsPaths.Add(graphPath);

            graphPath = new GraphicsPath();
            graphPath.AddArc(bottomRight.X - radius, bottomRight.Y - radius, radius, radius, 0, 90);
            graphPath.AddLine(bottomRight.X, bottomRight.Y + 1, bottomRight.X, bottomRight.Y - radius + 1);
            graphPath.CloseFigure();
            graphicsPaths.Add(graphPath);

            graphPath = new GraphicsPath();
            graphPath.AddArc(topLeft.X, bottomRight.Y - radius, radius, radius, 90, 90);
            graphPath.AddLine(topLeft.X - 1, bottomRight.Y + 1, topLeft.X + radius + 1, bottomRight.Y + 1);
            graphPath.CloseFigure();
            graphicsPaths.Add(graphPath);

            return graphicsPaths.ToArray();
        }
    }
}
