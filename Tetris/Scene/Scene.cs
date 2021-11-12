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

        protected List<Bitmap> GetBitmapFromControls()
        {
            return GetBitmapFromControls(this);
        }

        protected List<Bitmap> GetBitmapFromControls(Control uiComponent)
        {
            List<Bitmap> result = new List<Bitmap>();
            foreach (Control control in uiComponent.Controls)
            {
                Bitmap newBitmap = new Bitmap(control.Width, control.Height);
                control.DrawToBitmap(newBitmap, new Rectangle(0, 0, control.Width, control.Height));
                result.Add(newBitmap);
            }

            return result;
        }

        protected void SetControlVisibility(bool value)
        {
            SetControlVisibility(this, value);
        }

        protected void SetControlVisibility(Control uiComponent, bool value)
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
