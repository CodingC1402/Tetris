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
using Tetris.Logic;
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
            circelPause.BackGroundImage = Images.pauseButton;
            circelPause.Referencing = board;
            circelPause.MouseDown += (s, e) =>
            {
                BoardLogic.Paused = true;
            };

            _boardTransition = new Transition(board);
            _boardTransition.TransitionInTime = 1;
            _instance = this;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible)
            {
                BoardLogic.Start();
                _boardTransition.StartTransitionIn();
            }
        }

        public override void UpdateLogic()
        {
            if (!Visible)
                return;

            circelPause.Visible = !(BoardLogic.Paused || !BoardLogic.Started);
            Logic.Logic.Update();
        }

        public override void StartLogic()
        {

        }

        public override void Render()
        {
            Graphics.Board.Instance.Invalidate();
            circelPause.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
