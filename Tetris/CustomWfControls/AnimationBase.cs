using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tetris.CustomWfControls
{
    public class AnimationBase
    {
        public enum State
        {
            Stopped,
            Started,
            Paused
        }

        private static List<AnimationBase> _needToUpdate = new List<AnimationBase>();
        private static List<AnimationBase> _needToAddToUpdate = new List<AnimationBase>();

        private float _counter;
        private float _animationTime;
        private State _currentState = State.Stopped;
        public State CurrentState
        {
            get => _currentState;
        }

        public float Counter
        {
            get => _counter;
        }
        public float AnimationTime
        {
            get => _animationTime;
            set => _animationTime = value;
        }

        private Control _owner;
        public Control Owner { get => _owner; }

        protected Bitmap _controlBmp;
        public Bitmap ControlBmp { get => _controlBmp; }

        private event EventHandler _animationEnded;
        public event EventHandler AnimationEnded
        {
            add { _animationEnded += value; }
            remove { _animationEnded -= value; }
        }

        public AnimationBase(Control owner)
        {
            _owner = owner;
        }

        public virtual void Start()
        {
            if (_currentState == State.Started)
                return;
            if (_animationTime <= 0)
            {
                throw new Exception("Animation time has to be greater than 0");
            }

            AddToUpdate();
            if (_currentState == State.Stopped)
            {
                _counter = 0;
                if (_controlBmp == null)
                    _controlBmp = new Bitmap(_owner.Width, _owner.Height);
                _owner.DrawToBitmap(_controlBmp, new Rectangle(0, 0, _controlBmp.Width, _controlBmp.Height));
                _owner.Parent.Paint += OnPaintOverParent;
                _owner.Visible = false;
            }

            _currentState = State.Started;
        }

        public virtual void Stop()
        {
            if (_currentState == State.Stopped)
                return;
            OnAnimationEnded(new EventArgs());
        }

        public virtual void Pause()
        {
            if (_currentState == State.Paused)
                return;
            _currentState = State.Paused;
        }

        protected virtual void OnAnimationEnded(EventArgs e)
        {
            _owner.Parent.Paint -= OnPaintOverParent;
            _controlBmp.Dispose();
            _controlBmp = null;
            _owner.Visible = true;

            _currentState = State.Stopped;
            if (_animationEnded != null)
                _animationEnded(this, e);
        }

        protected virtual void OnPaintOverParent(object sender, PaintEventArgs e)
        {

        }

        protected void AddToUpdate()
        {
            _needToAddToUpdate.Add(this);
        }

        protected void RemoveFromUpdate()
        {
            _needToUpdate.Remove(this);
        }

        public static void UpdateAnimations()
        {
            var dt = Program.DeltaTime;
            List<AnimationBase> needToRemove = new List<AnimationBase>();
            _needToUpdate.AddRange(_needToAddToUpdate);
            _needToAddToUpdate.Clear();

            foreach (var anim in _needToUpdate)
            {
                anim.Update(dt);
                if (anim._currentState == State.Stopped || anim._currentState == State.Paused)
                {
                    needToRemove.Add(anim);
                }
            }

            foreach (var anim in needToRemove)
                anim.RemoveFromUpdate();
        }

        protected void Update(float delta)
        {
            if (_currentState == State.Paused || _currentState == State.Stopped)
                return;

            _counter += delta;
            if (_counter > _animationTime)
                OnAnimationEnded(new EventArgs());
        }
    }
}
