using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris.CustomWfControls;
using Tetris.Sound;

namespace Tetris
{
    public partial class Game : Scene
    {
        private static Game _instance = null;
        public static Game Instance { get => _instance; }

        private Transition _boardTransition;

        public Game()
        {
            InitializeComponent();
            _boardTransition = new Transition(board);
            _boardTransition.TransitionInTime = 1;

            this.VisibleChanged += (s, e) =>
            {
                slider1.Value = Music.Volumn;
            };
            slider1.ValueChanged += (s, e) =>
            {
                Music.Volumn = slider1.Value;
            };

            _instance = this;

            Graphics.Renderer.FpsLable = fpsLabel;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            slider1.Value = Music.Volumn;
            if (Visible)
                _boardTransition.StartTransitionIn();
        }

        public override void UpdateLogic()
        {
            if (!Visible)
                return;

            Logic.Logic.Update();
        }

        public override void StartLogic()
        {

        }

        public override void Render()
        {
            Graphics.Board.Instance.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
