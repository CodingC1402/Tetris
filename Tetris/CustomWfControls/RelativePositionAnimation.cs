using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tetris.CustomWfControls
{
    public class RelativePositionAnimation : ValueAnimation<PointF>
    {
        public RelativePositionAnimation(Control owner, PointF fromValue, PointF toValue) : base(owner, fromValue, toValue)
        {
            _fromValue.X = MathEx.Clamp01(_fromValue.X);
            _fromValue.Y = MathEx.Clamp01(_fromValue.Y);

            _toValue.X = MathEx.Clamp01(_toValue.X);
            _toValue.Y = MathEx.Clamp01(_toValue.Y);
        }

        protected override void OnPaintOverParent(object sender, PaintEventArgs e)
        {
            base.OnPaintOverParent(sender, e);
            Point targetLocation = new Point();

            targetLocation.X = (int)MathF.Round(Owner.Parent.Width * MathEx.Lerp(FromValue.X, ToValue.X, Counter / AnimationTime)) - ControlBmp.Width / 2;
            targetLocation.Y = (int)MathF.Round(Owner.Parent.Height * MathEx.Lerp(FromValue.Y, ToValue.Y, Counter / AnimationTime)) - ControlBmp.Height / 2;

            e.Graphics.DrawImage(ControlBmp, targetLocation);
        }

        protected override void OnAnimationEnded(EventArgs e)
        {
            Point targetLocation = new Point();

            targetLocation.X = (int)MathF.Round(Owner.Parent.Width * ToValue.X) - ControlBmp.Width / 2;
            targetLocation.Y = (int)MathF.Round(Owner.Parent.Height * ToValue.Y) - ControlBmp.Height / 2;
            Owner.Location = targetLocation;

            base.OnAnimationEnded(e);
        }
    }
}
