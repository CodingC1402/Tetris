using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tetris.CustomWfControls
{
    public class Transition
    {
        private static List<Transition> _needUpdateTransitions = new List<Transition>();
        public static void UpdateTransitions()
        {
            var deltaTime = Program.DeltaTime;
            List<Transition> needToRemove = new List<Transition>();

            foreach (var transition in _needUpdateTransitions)
            {
                transition.Update(deltaTime);
                if (transition._transitionOutCounter <= 0 && transition._transitionInCounter <= 0)
                {
                    needToRemove.Add(transition);
                }
            }

            foreach (var transition in needToRemove)
            {
                _needUpdateTransitions.Remove(transition);
            }
        }

        private Control _owner;

        private event EventHandler _transitionInFinished;
        private event EventHandler _transitionOutFinished;

        public event EventHandler TransitionInFinished
        {
            add { _transitionInFinished += value; }
            remove { _transitionInFinished -= value; }
        }
        public event EventHandler TransitionOutFinished
        {
            add { _transitionOutFinished += value; }
            remove { _transitionOutFinished -= value; }
        }

        private float _transitionInTime = 1;
        private float _transitionOutTime = 1;

        public float TransitionInTime {
            get => _transitionInTime;
            set => _transitionInTime = value;
        }
        public float TransitionOutTime {
            get => _transitionOutTime;
            set => _transitionOutTime = value;
        }

        private float _transitionInCounter = 0;
        private float _transitionOutCounter = 0;

        private void Update(float dt)
        {
            if (_transitionInCounter > 0)
            {
                _transitionInCounter -= dt;
                if (_transitionInCounter <= 0 && _transitionInFinished != null)
                {
                    _transitionInFinished(this, new EventArgs());
                }
            }

            if (_transitionOutCounter > 0)
            {
                _transitionOutCounter -= dt;
                if (_transitionOutCounter <= 0 && _transitionOutFinished != null)
                {
                    _transitionOutFinished(this, new EventArgs());
                }
            }
        }

        public Transition(Control control)
        {
            _owner = control;
        }

        public void PaintTransitionInOnControl(object sender, PaintEventArgs e)
        {
            using (Brush brush = new SolidBrush(Color.FromArgb((int)Math.Clamp(255 * _transitionInCounter / _transitionInTime, 0, 255), Color.Black)))
                e.Graphics.FillRectangle(brush, 0, 0, _owner.Width, _owner.Height);

            if (_transitionInCounter <= 0)
                _owner.Paint -= PaintTransitionInOnControl;
        }

        public void PaintTransitionOutOnControl(object sender, PaintEventArgs e)
        {
            using (Brush brush = new SolidBrush(Color.FromArgb((int)Math.Clamp(255 - 255 * _transitionOutCounter / _transitionInTime, 0, 255), Color.Black)))
                e.Graphics.FillRectangle(brush, 0, 0, _owner.Width, _owner.Height);

            // Don't need to remove cause maybe they don't transit right after finish animation
        }

        public void StartTransitionIn()
        {
            if (_transitionOutCounter > 0)
                return;

            _needUpdateTransitions.Add(this);
            _transitionInCounter = TransitionInTime;
            _owner.Paint += PaintTransitionInOnControl;
            _owner.Paint -= PaintTransitionOutOnControl;
        }

        public void StartTransitionOut()
        {
            if (_transitionInCounter > 0)
                return;

            _needUpdateTransitions.Add(this);
            _transitionOutCounter = TransitionOutTime;
            _owner.Paint += PaintTransitionOutOnControl;
        }
    }
}
