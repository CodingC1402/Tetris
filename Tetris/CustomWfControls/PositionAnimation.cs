using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tetris.CustomWfControls
{
    public class PositionAnimation : ValueAnimation<Point>
    {
        public PositionAnimation(Control owner, Point fromValue, Point toValue) : base(owner, fromValue, toValue)
        {}

        public PositionAnimation(Control owner) : base(owner) { }

        protected override void OnPaintOverParent(object sender, PaintEventArgs e)
        {
            base.OnPaintOverParent(sender, e);
            Point targetLocation = new Point();

            targetLocation.X = MathEx.Lerp(FromValue.X, ToValue.X, Counter / AnimationTime);
            targetLocation.Y = MathEx.Lerp(FromValue.Y, ToValue.Y, Counter / AnimationTime);

            e.Graphics.DrawImage(ControlBmp, targetLocation);
        }

        protected override void OnAnimationEnded(EventArgs e)
        {
            Owner.Location = ToValue;
            base.OnAnimationEnded(e);
        }
    }
}
