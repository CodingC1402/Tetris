using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tetris.CustomWfControls
{
    public class ScaleAnimation : ValueAnimation<float>
    {
        public Size OriginalSize {get; set;}

        public ScaleAnimation(Control owner) : base(owner) {
            OriginalSize = Owner.Size;
        }
        public ScaleAnimation(Control owner, float fromValue, float toValue) : base(owner, fromValue, toValue) {
            OriginalSize = Owner.Size;
        }

        protected override void OnPaintOverParent(object sender, PaintEventArgs e)
        {
            base.OnPaintOverParent(sender, e);
            PointF targetLocation = Owner.Location;
            float currentScale = MathEx.Lerp(_fromValue, _toValue, Counter / AnimationTime);

            var newWidth = (OriginalSize.Width * currentScale);
            var newHeight = (OriginalSize.Height * currentScale);
            targetLocation.X -= (newWidth - OriginalSize.Width * _fromValue) / 2f; 
            targetLocation.Y -= (newHeight - OriginalSize.Height * _fromValue) / 2f;

            Owner.Width = (int)MathF.Round(newWidth);
            Owner.Height = (int)MathF.Round(newHeight);

            _controlBmp.Dispose();
            _controlBmp = new Bitmap(Owner.Width, Owner.Height);
            Owner.DrawToBitmap(_controlBmp, new Rectangle(0, 0, Owner.Width, Owner.Height));

            e.Graphics.DrawImage(ControlBmp, targetLocation);
        }

        protected override void OnAnimationEnded(EventArgs e)
        {
            base.OnAnimationEnded(e);

            Point targetLocation = Owner.Location;
            targetLocation.X -= (int)MathF.Round((Owner.Width - OriginalSize.Width * _fromValue) / 2f);
            targetLocation.Y -= (int)MathF.Round((Owner.Height - OriginalSize.Height * _fromValue) / 2f);
            Owner.Location = targetLocation;

            Owner.Size = new Size((int)(OriginalSize.Width * _toValue), (int)(OriginalSize.Height * _toValue));
        }
    }
}
