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
            SetControlVisibility();

            circelPause.BackGroundImage = Images.pauseButton;
            circelPause.Referencing = board;
            circelPause.MouseDown += (s, e) =>
            {
                BoardLogic.Paused = true;
            };

            soundEffectSlider.VisibleChanged += (s, e) =>
            {
                if (soundEffectSlider.Visible)
                    soundEffectSlider.Value = SoundEffect.SfxVolumn;
            };
            soundEffectSlider.ValueChanged += (s, e) =>
            {
                SoundEffect.SfxVolumn = soundEffectSlider.Value;
            };

            musicSlider.VisibleChanged += (s, e) =>
            {
                if (musicSlider.Visible)
                    musicSlider.Value = Music.Volumn;
            };
            musicSlider.ValueChanged += (s, e) =>
            {
                Music.Volumn = musicSlider.Value;
            };

            continueBtn.Click += (s, e) =>
            {
                BoardLogic.Paused = false;
            };

            menuBtn.Click += (s, e) =>
            {
                BoardLogic.Stop();
                StartTransition();
                MainWindow.Instance.ToMainMenu(_boardTransition.TransitionOutTime);
            };

            restartBtn.Click += (s, e) =>
            {
                BoardLogic.Stop();
                StartTransition();
                MainWindow.Instance.ToGame(_boardTransition.TransitionOutTime);
            };

            _boardTransition = new Transition(board);
            _boardTransition.TransitionInTime = 1;
            _instance = this;
        }

        protected void StartTransition()
        {
            menuBtn.ForceStopAnim();
            continueBtn.ForceStopAnim();
            restartBtn.ForceStopAnim();

            _boardTransition.StartTransitionOut();
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

            SetControlVisibility();
            Logic.Logic.Update();
        }

        private void SetControlVisibility()
        {
            restartBtn.Visible = menuBtn.Visible = continueBtn.Visible = sfxLabel.Visible = musicLabel.Visible = musicSlider.Visible = soundEffectSlider.Visible = pausedLabel.Visible = BoardLogic.Paused;
            circelPause.Visible = !(BoardLogic.Paused || !BoardLogic.Started);
        }

        public override void StartLogic()
        {

        }

        public override void Render()
        {
            board.Invalidate();
            circelPause.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
