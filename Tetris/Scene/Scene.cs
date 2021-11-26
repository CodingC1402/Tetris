using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Tetris.CustomWfControls;

namespace Tetris
{
    public class Scene : Form
    {
        protected Transition _transition;

        public Scene()
        {
            if (!Program.IsDesignMode())
            {
                TopLevel = false;
                FormBorderStyle = FormBorderStyle.None;
                _transition = new Transition(this);
                DoubleBuffered = true;
            }
        }

        protected List<Bitmap> GetBitmapFromControls(bool ignoreVisible = true)
        {
            return GetBitmapFromControls(this, ignoreVisible);
        }

        protected List<Bitmap> GetBitmapFromControls(Control uiComponent, bool ignoreVisible = true)
        {
            List<Bitmap> result = new List<Bitmap>();
            foreach (Control control in uiComponent.Controls)
            {
                if (ignoreVisible || control.Visible)
                {
                    Bitmap newBitmap = new Bitmap(control.Width, control.Height);
                    control.DrawToBitmap(newBitmap, new Rectangle(0, 0, control.Width, control.Height));

                    if (control.Controls.Count > 0)
                    {
                        var childBitmaps = GetBitmapFromControls(control, ignoreVisible);
                        using (System.Drawing.Graphics gfx = System.Drawing.Graphics.FromImage(newBitmap))
                        {
                            for (int i = 0; i < childBitmaps.Count; i++)
                            {
                                gfx.DrawImage(childBitmaps[i], control.Controls[i].Location);
                            }
                        }
                    }

                    result.Add(newBitmap);
                }
            }

            return result;
        }

        protected virtual void SetControlVisibility(bool value)
        {
            SetControlVisibility(this, value);
        }

        protected virtual void SetControlVisibility(Control uiComponent, bool value)
        {
            uiComponent.SuspendLayout();
            foreach (Control control in uiComponent.Controls)
            {
                control.Visible = value;
            }
            uiComponent.ResumeLayout();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            PaintingControl(e);
        }

        // Will always call after on paint, used to switch up the painting order
        protected virtual void PaintingControl(PaintEventArgs e)
        {

        }

        public virtual void StartLogic() { }
        public virtual void UpdateLogic() { }
        public virtual void EndLogic() { }

        public virtual void Render() {
            Invalidate();
        }
    }
}
