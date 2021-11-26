
namespace Tetris
{
    partial class SettingMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.soundEffectSlider = new Tetris.CustomWfControls.Slider();
            this.sfxLabel = new System.Windows.Forms.Label();
            this.musicLabel = new System.Windows.Forms.Label();
            this.musicSlider = new Tetris.CustomWfControls.Slider();
            this.settingLabel = new System.Windows.Forms.Label();
            this.confirmBtn = new Tetris.CustomWfControls.FlatButton();
            this.cancelBtn = new Tetris.CustomWfControls.FlatButton();
            this.noteLabel = new System.Windows.Forms.Label();
            this.modeRight = new Tetris.CustomWfControls.FlatButton();
            this.modeLeft = new Tetris.CustomWfControls.FlatButton();
            this.rotateBtn = new Tetris.CustomWfControls.FlatButton();
            this.leftBtn = new Tetris.CustomWfControls.FlatButton();
            this.rightBtn = new Tetris.CustomWfControls.FlatButton();
            this.downBtn = new Tetris.CustomWfControls.FlatButton();
            this.placeBtn = new Tetris.CustomWfControls.FlatButton();
            this.nextKeyLabel = new System.Windows.Forms.Label();
            this.currentSkinPictureBox = new System.Windows.Forms.PictureBox();
            this.skinUpBtn = new Tetris.CustomWfControls.FlatButton();
            this.skinDownBtn = new Tetris.CustomWfControls.FlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.currentSkinPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // soundEffectSlider
            // 
            this.soundEffectSlider.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.soundEffectSlider.BackColor = System.Drawing.Color.Transparent;
            this.soundEffectSlider.CornerRadius = 10;
            this.soundEffectSlider.Location = new System.Drawing.Point(326, 174);
            this.soundEffectSlider.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.soundEffectSlider.Name = "soundEffectSlider";
            this.soundEffectSlider.Size = new System.Drawing.Size(608, 38);
            this.soundEffectSlider.SliderColor = System.Drawing.Color.DarkSlateGray;
            this.soundEffectSlider.SliderHeight = 20;
            this.soundEffectSlider.TabIndex = 0;
            this.soundEffectSlider.Text = "slider1";
            this.soundEffectSlider.ThumbColor = System.Drawing.Color.Azure;
            this.soundEffectSlider.ThumbWidth = 30;
            this.soundEffectSlider.Value = 0F;
            // 
            // sfxLabel
            // 
            this.sfxLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sfxLabel.AutoSize = true;
            this.sfxLabel.BackColor = System.Drawing.Color.Transparent;
            this.sfxLabel.Font = new System.Drawing.Font("Stencil", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sfxLabel.ForeColor = System.Drawing.Color.White;
            this.sfxLabel.Location = new System.Drawing.Point(19, 170);
            this.sfxLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.sfxLabel.Name = "sfxLabel";
            this.sfxLabel.Size = new System.Drawing.Size(270, 38);
            this.sfxLabel.TabIndex = 3;
            this.sfxLabel.Text = "Sound effects";
            // 
            // musicLabel
            // 
            this.musicLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.musicLabel.AutoSize = true;
            this.musicLabel.BackColor = System.Drawing.Color.Transparent;
            this.musicLabel.Font = new System.Drawing.Font("Stencil", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.musicLabel.ForeColor = System.Drawing.Color.White;
            this.musicLabel.Location = new System.Drawing.Point(19, 248);
            this.musicLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.musicLabel.Name = "musicLabel";
            this.musicLabel.Size = new System.Drawing.Size(119, 38);
            this.musicLabel.TabIndex = 4;
            this.musicLabel.Text = "Music";
            // 
            // musicSlider
            // 
            this.musicSlider.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.musicSlider.BackColor = System.Drawing.Color.Transparent;
            this.musicSlider.CornerRadius = 10;
            this.musicSlider.Location = new System.Drawing.Point(326, 247);
            this.musicSlider.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.musicSlider.Name = "musicSlider";
            this.musicSlider.Size = new System.Drawing.Size(608, 38);
            this.musicSlider.SliderColor = System.Drawing.Color.DarkSlateGray;
            this.musicSlider.SliderHeight = 20;
            this.musicSlider.TabIndex = 5;
            this.musicSlider.Text = "slider2";
            this.musicSlider.ThumbColor = System.Drawing.Color.Azure;
            this.musicSlider.ThumbWidth = 30;
            this.musicSlider.Value = 0F;
            // 
            // settingLabel
            // 
            this.settingLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.settingLabel.AutoSize = true;
            this.settingLabel.BackColor = System.Drawing.Color.Transparent;
            this.settingLabel.Font = new System.Drawing.Font("Stencil", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.settingLabel.ForeColor = System.Drawing.Color.White;
            this.settingLabel.Location = new System.Drawing.Point(356, 40);
            this.settingLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.settingLabel.Name = "settingLabel";
            this.settingLabel.Size = new System.Drawing.Size(254, 57);
            this.settingLabel.TabIndex = 9;
            this.settingLabel.Text = "Settings";
            // 
            // confirmBtn
            // 
            this.confirmBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.confirmBtn.AnimationTime = 0.2F;
            this.confirmBtn.BackColor = System.Drawing.Color.Teal;
            this.confirmBtn.CornerRadius = 15;
            this.confirmBtn.FlatAppearance.BorderSize = 0;
            this.confirmBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirmBtn.ForeColor = System.Drawing.Color.White;
            this.confirmBtn.HoverScale = 1.05F;
            this.confirmBtn.Location = new System.Drawing.Point(295, 450);
            this.confirmBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.OriginalSize = new System.Drawing.Size(0, 0);
            this.confirmBtn.Size = new System.Drawing.Size(150, 67);
            this.confirmBtn.TabIndex = 10;
            this.confirmBtn.Text = "CONFIRM";
            this.confirmBtn.UseVisualStyleBackColor = false;
            this.confirmBtn.UsingHoverAnimation = false;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cancelBtn.AnimationTime = 0.2F;
            this.cancelBtn.BackColor = System.Drawing.Color.Teal;
            this.cancelBtn.CornerRadius = 15;
            this.cancelBtn.FlatAppearance.BorderSize = 0;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.ForeColor = System.Drawing.Color.White;
            this.cancelBtn.HoverScale = 1.05F;
            this.cancelBtn.Location = new System.Drawing.Point(504, 450);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.OriginalSize = new System.Drawing.Size(0, 0);
            this.cancelBtn.Size = new System.Drawing.Size(150, 67);
            this.cancelBtn.TabIndex = 11;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.UsingHoverAnimation = false;
            // 
            // noteLabel
            // 
            this.noteLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.noteLabel.AutoSize = true;
            this.noteLabel.BackColor = System.Drawing.Color.Transparent;
            this.noteLabel.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.noteLabel.ForeColor = System.Drawing.Color.White;
            this.noteLabel.Location = new System.Drawing.Point(285, 396);
            this.noteLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(378, 22);
            this.noteLabel.TabIndex = 12;
            this.noteLabel.Text = "NOTE: Press f11 to go full screen";
            // 
            // modeRight
            // 
            this.modeRight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.modeRight.AnimationTime = 0.2F;
            this.modeRight.BackColor = System.Drawing.Color.Teal;
            this.modeRight.CornerRadius = 15;
            this.modeRight.FlatAppearance.BorderSize = 0;
            this.modeRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modeRight.Font = new System.Drawing.Font("Stencil", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.modeRight.ForeColor = System.Drawing.Color.White;
            this.modeRight.HoverScale = 1.05F;
            this.modeRight.Location = new System.Drawing.Point(620, 40);
            this.modeRight.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.modeRight.Name = "modeRight";
            this.modeRight.OriginalSize = new System.Drawing.Size(0, 0);
            this.modeRight.Size = new System.Drawing.Size(47, 57);
            this.modeRight.TabIndex = 13;
            this.modeRight.Text = "❱";
            this.modeRight.UseVisualStyleBackColor = false;
            this.modeRight.UsingHoverAnimation = false;
            // 
            // modeLeft
            // 
            this.modeLeft.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.modeLeft.AnimationTime = 0.2F;
            this.modeLeft.BackColor = System.Drawing.Color.Teal;
            this.modeLeft.CornerRadius = 15;
            this.modeLeft.FlatAppearance.BorderSize = 0;
            this.modeLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modeLeft.Font = new System.Drawing.Font("Stencil", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.modeLeft.ForeColor = System.Drawing.Color.White;
            this.modeLeft.HoverScale = 1.05F;
            this.modeLeft.Location = new System.Drawing.Point(299, 40);
            this.modeLeft.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.modeLeft.Name = "modeLeft";
            this.modeLeft.OriginalSize = new System.Drawing.Size(0, 0);
            this.modeLeft.Size = new System.Drawing.Size(47, 57);
            this.modeLeft.TabIndex = 14;
            this.modeLeft.Text = "❰";
            this.modeLeft.UseVisualStyleBackColor = false;
            this.modeLeft.UsingHoverAnimation = false;
            // 
            // rotateBtn
            // 
            this.rotateBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rotateBtn.AnimationTime = 0.2F;
            this.rotateBtn.BackColor = System.Drawing.Color.Teal;
            this.rotateBtn.CornerRadius = 15;
            this.rotateBtn.FlatAppearance.BorderSize = 0;
            this.rotateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rotateBtn.Font = new System.Drawing.Font("Stencil", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rotateBtn.ForeColor = System.Drawing.Color.White;
            this.rotateBtn.HoverScale = 1.05F;
            this.rotateBtn.Location = new System.Drawing.Point(381, 120);
            this.rotateBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.rotateBtn.Name = "rotateBtn";
            this.rotateBtn.OriginalSize = new System.Drawing.Size(0, 0);
            this.rotateBtn.Size = new System.Drawing.Size(200, 40);
            this.rotateBtn.TabIndex = 22;
            this.rotateBtn.Text = "Cancel";
            this.rotateBtn.UseVisualStyleBackColor = false;
            this.rotateBtn.UsingHoverAnimation = false;
            // 
            // leftBtn
            // 
            this.leftBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.leftBtn.AnimationTime = 0.2F;
            this.leftBtn.BackColor = System.Drawing.Color.Teal;
            this.leftBtn.CornerRadius = 15;
            this.leftBtn.FlatAppearance.BorderSize = 0;
            this.leftBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leftBtn.Font = new System.Drawing.Font("Stencil", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.leftBtn.ForeColor = System.Drawing.Color.White;
            this.leftBtn.HoverScale = 1.05F;
            this.leftBtn.Location = new System.Drawing.Point(381, 170);
            this.leftBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.leftBtn.Name = "leftBtn";
            this.leftBtn.OriginalSize = new System.Drawing.Size(0, 0);
            this.leftBtn.Size = new System.Drawing.Size(200, 40);
            this.leftBtn.TabIndex = 23;
            this.leftBtn.Text = "Cancel";
            this.leftBtn.UseVisualStyleBackColor = false;
            this.leftBtn.UsingHoverAnimation = false;
            // 
            // rightBtn
            // 
            this.rightBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rightBtn.AnimationTime = 0.2F;
            this.rightBtn.BackColor = System.Drawing.Color.Teal;
            this.rightBtn.CornerRadius = 15;
            this.rightBtn.FlatAppearance.BorderSize = 0;
            this.rightBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rightBtn.Font = new System.Drawing.Font("Stencil", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rightBtn.ForeColor = System.Drawing.Color.White;
            this.rightBtn.HoverScale = 1.05F;
            this.rightBtn.Location = new System.Drawing.Point(381, 220);
            this.rightBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.rightBtn.Name = "rightBtn";
            this.rightBtn.OriginalSize = new System.Drawing.Size(0, 0);
            this.rightBtn.Size = new System.Drawing.Size(200, 40);
            this.rightBtn.TabIndex = 24;
            this.rightBtn.Text = "Cancel";
            this.rightBtn.UseVisualStyleBackColor = false;
            this.rightBtn.UsingHoverAnimation = false;
            // 
            // downBtn
            // 
            this.downBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.downBtn.AnimationTime = 0.2F;
            this.downBtn.BackColor = System.Drawing.Color.Teal;
            this.downBtn.CornerRadius = 15;
            this.downBtn.FlatAppearance.BorderSize = 0;
            this.downBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downBtn.Font = new System.Drawing.Font("Stencil", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.downBtn.ForeColor = System.Drawing.Color.White;
            this.downBtn.HoverScale = 1.05F;
            this.downBtn.Location = new System.Drawing.Point(381, 270);
            this.downBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.downBtn.Name = "downBtn";
            this.downBtn.OriginalSize = new System.Drawing.Size(0, 0);
            this.downBtn.Size = new System.Drawing.Size(200, 40);
            this.downBtn.TabIndex = 25;
            this.downBtn.Text = "Cancel";
            this.downBtn.UseVisualStyleBackColor = false;
            this.downBtn.UsingHoverAnimation = false;
            // 
            // placeBtn
            // 
            this.placeBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.placeBtn.AnimationTime = 0.2F;
            this.placeBtn.BackColor = System.Drawing.Color.Teal;
            this.placeBtn.CornerRadius = 15;
            this.placeBtn.FlatAppearance.BorderSize = 0;
            this.placeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.placeBtn.Font = new System.Drawing.Font("Stencil", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.placeBtn.ForeColor = System.Drawing.Color.White;
            this.placeBtn.HoverScale = 1.05F;
            this.placeBtn.Location = new System.Drawing.Point(381, 320);
            this.placeBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.placeBtn.Name = "placeBtn";
            this.placeBtn.OriginalSize = new System.Drawing.Size(0, 0);
            this.placeBtn.Size = new System.Drawing.Size(200, 40);
            this.placeBtn.TabIndex = 26;
            this.placeBtn.Text = "Cancel";
            this.placeBtn.UseVisualStyleBackColor = false;
            this.placeBtn.UsingHoverAnimation = false;
            // 
            // nextKeyLabel
            // 
            this.nextKeyLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nextKeyLabel.AutoSize = true;
            this.nextKeyLabel.BackColor = System.Drawing.Color.Transparent;
            this.nextKeyLabel.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nextKeyLabel.ForeColor = System.Drawing.Color.White;
            this.nextKeyLabel.Location = new System.Drawing.Point(237, 394);
            this.nextKeyLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.nextKeyLabel.Name = "nextKeyLabel";
            this.nextKeyLabel.Size = new System.Drawing.Size(489, 22);
            this.nextKeyLabel.TabIndex = 28;
            this.nextKeyLabel.Text = "Next key you press will be used as control";
            // 
            // currentSkinPictureBox
            // 
            this.currentSkinPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.currentSkinPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.currentSkinPictureBox.Location = new System.Drawing.Point(225, 227);
            this.currentSkinPictureBox.Name = "currentSkinPictureBox";
            this.currentSkinPictureBox.Size = new System.Drawing.Size(512, 64);
            this.currentSkinPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.currentSkinPictureBox.TabIndex = 30;
            this.currentSkinPictureBox.TabStop = false;
            // 
            // skinUpBtn
            // 
            this.skinUpBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.skinUpBtn.AnimationTime = 0.2F;
            this.skinUpBtn.BackColor = System.Drawing.Color.Teal;
            this.skinUpBtn.CornerRadius = 15;
            this.skinUpBtn.FlatAppearance.BorderSize = 0;
            this.skinUpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.skinUpBtn.Font = new System.Drawing.Font("Stencil", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.skinUpBtn.ForeColor = System.Drawing.Color.White;
            this.skinUpBtn.HoverScale = 1.05F;
            this.skinUpBtn.Location = new System.Drawing.Point(446, 153);
            this.skinUpBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.skinUpBtn.Name = "skinUpBtn";
            this.skinUpBtn.OriginalSize = new System.Drawing.Size(0, 0);
            this.skinUpBtn.Size = new System.Drawing.Size(70, 57);
            this.skinUpBtn.TabIndex = 32;
            this.skinUpBtn.Text = "▲";
            this.skinUpBtn.UseVisualStyleBackColor = false;
            this.skinUpBtn.UsingHoverAnimation = false;
            // 
            // skinDownBtn
            // 
            this.skinDownBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.skinDownBtn.AnimationTime = 0.2F;
            this.skinDownBtn.BackColor = System.Drawing.Color.Teal;
            this.skinDownBtn.CornerRadius = 15;
            this.skinDownBtn.FlatAppearance.BorderSize = 0;
            this.skinDownBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.skinDownBtn.Font = new System.Drawing.Font("Stencil", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.skinDownBtn.ForeColor = System.Drawing.Color.White;
            this.skinDownBtn.HoverScale = 1.05F;
            this.skinDownBtn.Location = new System.Drawing.Point(446, 307);
            this.skinDownBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.skinDownBtn.Name = "skinDownBtn";
            this.skinDownBtn.OriginalSize = new System.Drawing.Size(0, 0);
            this.skinDownBtn.Size = new System.Drawing.Size(70, 57);
            this.skinDownBtn.TabIndex = 33;
            this.skinDownBtn.Text = "▼";
            this.skinDownBtn.UseVisualStyleBackColor = false;
            this.skinDownBtn.UsingHoverAnimation = false;
            // 
            // SettingMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(963, 570);
            this.Controls.Add(this.skinDownBtn);
            this.Controls.Add(this.skinUpBtn);
            this.Controls.Add(this.currentSkinPictureBox);
            this.Controls.Add(this.nextKeyLabel);
            this.Controls.Add(this.placeBtn);
            this.Controls.Add(this.downBtn);
            this.Controls.Add(this.rightBtn);
            this.Controls.Add(this.leftBtn);
            this.Controls.Add(this.rotateBtn);
            this.Controls.Add(this.modeLeft);
            this.Controls.Add(this.modeRight);
            this.Controls.Add(this.noteLabel);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.settingLabel);
            this.Controls.Add(this.musicSlider);
            this.Controls.Add(this.musicLabel);
            this.Controls.Add(this.sfxLabel);
            this.Controls.Add(this.soundEffectSlider);
            this.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "SettingMenu";
            this.Text = "SettingMenu";
            ((System.ComponentModel.ISupportInitialize)(this.currentSkinPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomWfControls.Slider soundEffectSlider;
        private System.Windows.Forms.Label sfxLabel;
        private System.Windows.Forms.Label musicLabel;
        private CustomWfControls.Slider musicSlider;
        private System.Windows.Forms.Label settingLabel;
        private CustomWfControls.FlatButton confirmBtn;
        private CustomWfControls.FlatButton cancelBtn;
        private System.Windows.Forms.Label noteLabel;
        private CustomWfControls.FlatButton modeRight;
        private CustomWfControls.FlatButton modeLeft;
        private CustomWfControls.FlatButton rotateBtn;
        private CustomWfControls.FlatButton leftBtn;
        private CustomWfControls.FlatButton rightBtn;
        private CustomWfControls.FlatButton downBtn;
        private CustomWfControls.FlatButton placeBtn;
        private System.Windows.Forms.Label nextKeyLabel;
        private System.Windows.Forms.PictureBox currentSkinPictureBox;
        private CustomWfControls.FlatButton skinUpBtn;
        private CustomWfControls.FlatButton skinDownBtn;
    }
}