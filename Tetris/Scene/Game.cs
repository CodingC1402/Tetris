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

            pausedLabel.VisibleChanged += (s, e) =>
            {
                if (pausedLabel.Visible)
                    pausedLabel.Text = BoardLogic.IsGameOver ? "Game over" : "Paused";
            };

            scoreLabel.VisibleChanged += (s, e) =>
            {
                if (scoreLabel.Visible)
                {
                    scoreLabel.Text = BoardLogic.Score.ToString();
                }
            };

            isHighScoreLabel.VisibleChanged += (s, e) =>
            {
                if (isHighScoreLabel.Visible)
                {
                    var defaultFont = pausedLabel.Font;
                    switch (BoardLogic.GameResult)
                    {
                        case Logic.LeaderBoard.Result.HighScore:
                            scoreLabel.ForeColor = Color.OrangeRed;
                            defaultFont = new Font(defaultFont.FontFamily, defaultFont.Size + 20, defaultFont.Style);
                            isHighScoreLabel.Text = "NEW RECORD!";
                            break;
                        case Logic.LeaderBoard.Result.IsInTheBoard:
                            scoreLabel.ForeColor = Color.Orange;
                            defaultFont = new Font(defaultFont.FontFamily, defaultFont.Size + 10, defaultFont.Style);
                            isHighScoreLabel.Text = "NEW HIGH SCORE!";
                            break;
                        case Logic.LeaderBoard.Result.Nothing:
                            scoreLabel.ForeColor = Color.White;
                            isHighScoreLabel.Text = "TRY HARDER!";
                            break;
                    }
                    scoreLabel.Font = defaultFont;
                }
            };

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
                StartTransition();
                MainWindow.Instance.ToMainMenu(_boardTransition.TransitionOutTime);
                BoardLogic.Reset();
            };

            restartBtn.Click += (s, e) =>
            {
                StartTransition();
                MainWindow.Instance.ToGame(_boardTransition.TransitionOutTime);
                BoardLogic.Reset();
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

            Logic.Logic.Update();
        }

        private void SetControlVisibility()
        {
            SuspendLayout();
            continueBtn.Visible = sfxLabel.Visible = musicLabel.Visible = musicSlider.Visible = soundEffectSlider.Visible = BoardLogic.Paused;
            pausedLabel.Visible = restartBtn.Visible = menuBtn.Visible = BoardLogic.Paused || BoardLogic.IsGameOver;

            scoreLabel.Visible = BoardLogic.IsGameOver;
            isHighScoreLabel.Visible = BoardLogic.IsGameOver && (BoardLogic.GameResult == Logic.LeaderBoard.Result.HighScore || BoardLogic.GameResult == Logic.LeaderBoard.Result.IsInTheBoard);
            circelPause.Visible = !(BoardLogic.Paused || !BoardLogic.Started);
            ResumeLayout();
        }

        public override void StartLogic()
        {

        }

        public override void Render()
        {
            board.Invalidate();
            circelPause.Invalidate();
            SetControlVisibility();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
