using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Tetris.CustomWfControls
{
    public class ValueAnimation<T> : AnimationBase
    {
        protected T _fromValue;
        public T FromValue { 
            get => _fromValue;
            set => _fromValue = value;
        }

        protected T _toValue;
        public T ToValue { 
            get => _toValue;
            set => _toValue = value;
        }

        public ValueAnimation(Control owner) : base(owner) { }

        public ValueAnimation(Control owner, T fromValue, T toValue) : base(owner) {
            _fromValue = fromValue;
            _toValue = toValue;
        }
    }
}
