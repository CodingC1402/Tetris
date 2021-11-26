using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Tetris.Graphics;
using Tetris.Logic;
using Tetris.Sound;

namespace Tetris
{
    public partial class SettingMenu : Scene
    {
        public enum Screen
        {
            Settings,
            Controls,
            Skins
        }
        private const int ScreenNumber = 3;

        private Bitmap _mainMenuBG = Images.GameModeSelection;

        private List<Bitmap> _controlBitmaps;

        private float _originalMusicVol;
        private float _originalSfxVol;
        private int _originalSkinIndex;

        private bool _inTransition = true;

        private bool _waitingForKeyInput = false;
        private Input _changingInput;

        private Screen _currentScreen = Screen.Settings;
        private Dictionary<Control, Screen> _controlsDependOnScreen = new Dictionary<Control, Screen>();

        public SettingMenu()
        {
            InitializeComponent();
            SetControlVisibility(false);
            SetControlBtnText();

            _originalMusicVol = musicSlider.Value = Music.Volumn;
            _originalSfxVol = soundEffectSlider.Value = SoundEffect.SfxVolumn;
            _originalSkinIndex = Settings.CurrentSkinIndex;

            nextKeyLabel.Visible = false;

            _controlsDependOnScreen.Add(musicSlider, Screen.Settings);
            _controlsDependOnScreen.Add(musicLabel, Screen.Settings);
            _controlsDependOnScreen.Add(sfxLabel, Screen.Settings);
            _controlsDependOnScreen.Add(soundEffectSlider, Screen.Settings);
            _controlsDependOnScreen.Add(noteLabel, Screen.Settings);

            _controlsDependOnScreen.Add(rotateBtn, Screen.Controls);
            _controlsDependOnScreen.Add(leftBtn, Screen.Controls);
            _controlsDependOnScreen.Add(rightBtn, Screen.Controls);
            _controlsDependOnScreen.Add(downBtn, Screen.Controls);
            _controlsDependOnScreen.Add(placeBtn, Screen.Controls);
            _controlsDependOnScreen.Add(nextKeyLabel, Screen.Controls);

            _controlsDependOnScreen.Add(currentSkinPictureBox, Screen.Skins);
            _controlsDependOnScreen.Add(skinUpBtn, Screen.Skins);
            _controlsDependOnScreen.Add(skinDownBtn, Screen.Skins);
            SetLabelToScreenName();
            SetPictureBoxToCorrectSkin();

            musicSlider.ValueChanged += (s, e) =>
            {
                Music.Volumn = musicSlider.Value;
            };
            soundEffectSlider.ValueChanged += (s, e) =>
            {
                SoundEffect.SfxVolumn = soundEffectSlider.Value;
            };

            skinUpBtn.Click += (s, e) =>
            {
                Settings.CurrentSkinIndex++;
                SetPictureBoxToCorrectSkin();

            };
            skinDownBtn.Click += (s, e) =>
            {
                Settings.CurrentSkinIndex--;
                SetPictureBoxToCorrectSkin();
            };

            confirmBtn.UsingHoverAnimation = true;
            cancelBtn.UsingHoverAnimation = true;

            confirmBtn.OriginalSize = confirmBtn.Size;
            cancelBtn.OriginalSize = cancelBtn.Size;

            _controlBitmaps = GetBitmapFromControls();

            modeLeft.Click += (s, e) => MoveScreenLeft();
            modeRight.Click += (s, e) => MoveScreenRight();

            cancelBtn.Click += (s, e) =>
            {
                Music.Volumn = _originalMusicVol;
                SoundEffect.SfxVolumn = _originalSfxVol;
                Settings.CurrentSkinIndex = _originalSkinIndex;

                InputSetting.LoadInput();
                TransitionToMainMenu();
            };
            confirmBtn.Click += (s, e) =>
            {
                TransitionToMainMenu();
                InputSetting.SaveInput();
                Settings.SaveSetting();
            };

            _transition.TransitionInFinished += (s, e) =>
            {
                SetControlVisibility(true);
                _inTransition = false;
            };

            rotateBtn.Click += ControlBtnClick;
            rightBtn.Click += ControlBtnClick;
            leftBtn.Click += ControlBtnClick;
            downBtn.Click += ControlBtnClick;
            placeBtn.Click += ControlBtnClick;
        }
        
        private void SetPictureBoxToCorrectSkin()
        {
            currentSkinPictureBox.Image = Texture.GetTexture(Texture.BlockTextureKey).Bmp;
        }
        private void ControlBtnClick(object sender, EventArgs e)
        {
            _waitingForKeyInput = true;
            if (sender == rotateBtn)
            {
                _changingInput = InputSystem.RotateInput;
            }
            else if (sender == rightBtn)
            {
                _changingInput = InputSystem.MoveRightInput;
            }
            else if (sender == leftBtn)
            {
                _changingInput = InputSystem.MoveLeftInput;
            }
            else if (sender == downBtn)
            {
                _changingInput = InputSystem.MoveDownInput;
            }
            else if (sender == placeBtn)
            {
                _changingInput = InputSystem.ForcePlaceInput;
            }
        }

        protected override void SetControlVisibility(bool value)
        {
            base.SetControlVisibility(value);
            if (value)
                SetScreenDependControlsVisibility();
        }

        protected void MoveScreenLeft()
        {
            int index = (int)_currentScreen;
            index--;
            if (index < 0)
                index = ScreenNumber - 1;

            _currentScreen = (Screen)index;

            SetScreenDependControlsVisibility();
            SetLabelToScreenName();
        }
        protected void MoveScreenRight()
        {
            int index = (int)_currentScreen;
            index++;
            index %= ScreenNumber;

            _currentScreen = (Screen)index;

            SetScreenDependControlsVisibility();
            SetLabelToScreenName();
        }
        protected void SetScreenDependControlsVisibility()
        {
            foreach (var keyValue in _controlsDependOnScreen)
            {
                if (keyValue.Key == nextKeyLabel)
                    keyValue.Key.Visible = _waitingForKeyInput;
                else
                    keyValue.Key.Visible = keyValue.Value == _currentScreen;
            }
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
            if (!_inTransition && _currentScreen == Screen.Controls)
            {
                nextKeyLabel.Visible = _waitingForKeyInput;
                if (_waitingForKeyInput && InputSystem.HaveKeyDown)
                {
                    _waitingForKeyInput = false;
                    _changingInput.KeyCode = InputSystem.FirstKeyDown;
                    SetControlBtnText();
                }
            }
        }

        protected void SetControlBtnText()
        {
            rotateBtn.Text = $"Rotate: {InputSystem.RotateInput.KeyCode}";
            leftBtn.Text = $"Left: {InputSystem.MoveLeftInput.KeyCode}";
            rightBtn.Text = $"Right: {InputSystem.MoveRightInput.KeyCode}";
            downBtn.Text = $"Down: {InputSystem.MoveDownInput.KeyCode}";
            placeBtn.Text = $"Place: {InputSystem.ForcePlaceInput.KeyCode}";
        }

        protected void SetLabelToScreenName()
        {
            if (_currentScreen == Screen.Skins)
                settingLabel.Text = "Skin";
            else
                settingLabel.Text = _currentScreen.ToString();

            var oldLocation = settingLabel.Location;
            oldLocation.X = (Width - settingLabel.Width) / 2;
            settingLabel.Location = oldLocation;
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
                    Screen screen;
                    if (Controls[i] == nextKeyLabel)
                    {
                        if (_waitingForKeyInput)
                            e.Graphics.DrawImage(_controlBitmaps[i], Controls[i].Location);
                    }
                    else if (_controlsDependOnScreen.TryGetValue(Controls[i], out screen))
                    {
                        if (screen == _currentScreen)
                        {
                            e.Graphics.DrawImage(_controlBitmaps[i], Controls[i].Location);
                        }
                    }
                    else
                    {
                        e.Graphics.DrawImage(_controlBitmaps[i], Controls[i].Location);
                    }
                }
            }

            base.OnPaint(e);
        }
    }
}
