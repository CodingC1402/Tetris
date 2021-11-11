using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tetris.Sound;

namespace Tetris
{
    public partial class SettingMenu : Scene
    {
        private Bitmap _mainMenuBG = Images.GameModeSelection;

        private List<Bitmap> _controlBitmaps;

        private float _originalMusicVol;
        private float _originalSfxVol;
        private bool _inTransition = true;

        public SettingMenu()
        {
            InitializeComponent();
            SetControlVisibility(false);

            _originalMusicVol = musicSlider.Value = Music.Volumn;
            _originalSfxVol = soundEffectSlider.Value = SoundEffect.SfxVolumn;

            musicSlider.ValueChanged += (s, e) =>
            {
                Music.Volumn = musicSlider.Value;
            };
            soundEffectSlider.ValueChanged += (s, e) =>
            {
                SoundEffect.SfxVolumn = soundEffectSlider.Value;
            };

            confirmBtn.UsingHoverAnimation = true;
            cancelBtn.UsingHoverAnimation = true;

            confirmBtn.OriginalSize = confirmBtn.Size;
            cancelBtn.OriginalSize = cancelBtn.Size;

            _controlBitmaps = GetBitmapFromControls();

            cancelBtn.Click += (s, e) =>
            {
                Music.Volumn = _originalMusicVol;
                SoundEffect.SfxVolumn = _originalSfxVol;
                TransitionToMainMenu();
            };
            confirmBtn.Click += (s, e) =>
            {
                TransitionToMainMenu();
            };

            _transition.TransitionInFinished += (s, e) =>
            {
                SetControlVisibility(true);
                _inTransition = false;
            };
        }

        protected void TransitionToMainMenu()
        {
            confirmBtn.ForceStopAnim();
            cancelBtn.ForceStopAnim();

            SetControlVisibility(false);
            _controlBitmaps = GetBitmapFromControls();

            _inTransition = true;
            _transition.StartTransitionOut();
            MainWindow.Instance.ToMainMenu(_transition.TransitionOutTime);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible)
            {
                _transition.StartTransitionIn();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var ratio = Height / (float)_mainMenuBG.Height;

            Rectangle drawingRect = new Rectangle(0, 0, (int)(_mainMenuBG.Width * ratio), (int)(_mainMenuBG.Height * ratio));
            drawingRect.X = (Width - (drawingRect.Width)) / 2;
            drawingRect.Y = (Height - (drawingRect.Height)) / 2;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.DrawImage(_mainMenuBG, drawingRect);

            if (_inTransition && _controlBitmaps != null)
            {
                for (int i = 0; i < Controls.Count && i < _controlBitmaps.Count; i++)
                {
                    e.Graphics.DrawImage(_controlBitmaps[i], Controls[i].Location);
                }
            }

            base.OnPaint(e);
        }
    }
}
