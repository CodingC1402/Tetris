using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Tetris
{
    public class Scene : Form
    {
        public Scene()
        {
            if (!Program.IsDesignMode())
            {
                TopLevel = false;
                FormBorderStyle = FormBorderStyle.None;
            }
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

        public virtual void Render() { }
    }
}
