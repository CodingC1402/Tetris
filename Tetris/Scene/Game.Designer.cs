
namespace Tetris
{
    partial class Game
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.board = new Tetris.Graphics.Board();
            this.circelPause = new Tetris.CustomWfControls.CircelPause();
            this.pausedLabel = new System.Windows.Forms.Label();
            this.musicSlider = new Tetris.CustomWfControls.Slider();
            this.musicLabel = new System.Windows.Forms.Label();
            this.sfxLabel = new System.Windows.Forms.Label();
            this.soundEffectSlider = new Tetris.CustomWfControls.Slider();
            this.continueBtn = new Tetris.CustomWfControls.FlatButton();
            this.menuBtn = new Tetris.CustomWfControls.FlatButton();
            this.restartBtn = new Tetris.CustomWfControls.FlatButton();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.isHighScoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // board
            // 
            this.board.BackColor = System.Drawing.Color.Black;
            this.board.BoardOpacity = 0.9F;
            this.board.Dock = System.Windows.Forms.DockStyle.Fill;
            this.board.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.board.LevelFont = new System.Drawing.Font("Stencil", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.board.Location = new System.Drawing.Point(0, 0);
            this.board.Margin = new System.Windows.Forms.Padding(20);
            this.board.Name = "board";
            this.board.Padding = new System.Windows.Forms.Padding(0, 80, 0, 80);
            this.board.Size = new System.Drawing.Size(900, 800);
            this.board.TabIndex = 5;
            this.board.Text = "board1";
            // 
            // circelPause
            // 
            this.circelPause.BackColor = System.Drawing.Color.DarkSlateGray;
            this.circelPause.BackGroundImage = null;
            this.circelPause.HoverColor = System.Drawing.Color.Teal;
            this.circelPause.Location = new System.Drawing.Point(0, 0);
            this.circelPause.Margin = new System.Windows.Forms.Padding(0);
            this.circelPause.Name = "circelPause";
            this.circelPause.Padding = new System.Windows.Forms.Padding(15);
            this.circelPause.Referencing = null;
            this.circelPause.Size = new System.Drawing.Size(100, 100);
            this.circelPause.TabIndex = 6;
            this.circelPause.Text = "circelPause1";
            this.circelPause.Visible = false;
            // 
            // pausedLabel
            // 
            this.pausedLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pausedLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pausedLabel.Font = new System.Drawing.Font("Stencil", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.pausedLabel.ForeColor = System.Drawing.Color.White;
            this.pausedLabel.Location = new System.Drawing.Point(244, 238);
            this.pausedLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.pausedLabel.Name = "pausedLabel";
            this.pausedLabel.Size = new System.Drawing.Size(416, 57);
            this.pausedLabel.TabIndex = 14;
            this.pausedLabel.Text = "Paused";
            this.pausedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pausedLabel.Visible = false;
            // 
            // musicSlider
            // 
            this.musicSlider.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.musicSlider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.musicSlider.CornerRadius = 10;
            this.musicSlider.Location = new System.Drawing.Point(300, 410);
            this.musicSlider.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.musicSlider.Name = "musicSlider";
            this.musicSlider.Size = new System.Drawing.Size(608, 38);
            this.musicSlider.SliderColor = System.Drawing.Color.DarkSlateGray;
            this.musicSlider.SliderHeight = 20;
            this.musicSlider.TabIndex = 13;
            this.musicSlider.Text = "slider2";
            this.musicSlider.ThumbColor = System.Drawing.Color.Azure;
            this.musicSlider.ThumbWidth = 30;
            this.musicSlider.Value = 0F;
            this.musicSlider.Visible = false;
            // 
            // musicLabel
            // 
            this.musicLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.musicLabel.AutoSize = true;
            this.musicLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.musicLabel.Font = new System.Drawing.Font("Stencil", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.musicLabel.ForeColor = System.Drawing.Color.White;
            this.musicLabel.Location = new System.Drawing.Point(-7, 411);
            this.musicLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.musicLabel.Name = "musicLabel";
            this.musicLabel.Size = new System.Drawing.Size(119, 38);
            this.musicLabel.TabIndex = 12;
            this.musicLabel.Text = "Music";
            this.musicLabel.Visible = false;
            // 
            // sfxLabel
            // 
            this.sfxLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sfxLabel.AutoSize = true;
            this.sfxLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.sfxLabel.Font = new System.Drawing.Font("Stencil", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sfxLabel.ForeColor = System.Drawing.Color.White;
            this.sfxLabel.Location = new System.Drawing.Point(-7, 333);
            this.sfxLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.sfxLabel.Name = "sfxLabel";
            this.sfxLabel.Size = new System.Drawing.Size(270, 38);
            this.sfxLabel.TabIndex = 11;
            this.sfxLabel.Text = "Sound effects";
            this.sfxLabel.Visible = false;
            // 
            // soundEffectSlider
            // 
            this.soundEffectSlider.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.soundEffectSlider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.soundEffectSlider.CornerRadius = 10;
            this.soundEffectSlider.Location = new System.Drawing.Point(300, 337);
            this.soundEffectSlider.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.soundEffectSlider.Name = "soundEffectSlider";
            this.soundEffectSlider.Size = new System.Drawing.Size(608, 38);
            this.soundEffectSlider.SliderColor = System.Drawing.Color.DarkSlateGray;
            this.soundEffectSlider.SliderHeight = 20;
            this.soundEffectSlider.TabIndex = 10;
            this.soundEffectSlider.Text = "slider1";
            this.soundEffectSlider.ThumbColor = System.Drawing.Color.Azure;
            this.soundEffectSlider.ThumbWidth = 30;
            this.soundEffectSlider.Value = 0F;
            this.soundEffectSlider.Visible = false;
            // 
            // continueBtn
            // 
            this.continueBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.continueBtn.AnimationTime = 0.2F;
            this.continueBtn.BackColor = System.Drawing.Color.Teal;
            this.continueBtn.CornerRadius = 15;
            this.continueBtn.FlatAppearance.BorderSize = 0;
            this.continueBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.continueBtn.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.continueBtn.ForeColor = System.Drawing.Color.White;
            this.continueBtn.HoverScale = 1.05F;
            this.continueBtn.Location = new System.Drawing.Point(179, 498);
            this.continueBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.continueBtn.Name = "continueBtn";
            this.continueBtn.OriginalSize = new System.Drawing.Size(0, 0);
            this.continueBtn.Size = new System.Drawing.Size(150, 67);
            this.continueBtn.TabIndex = 15;
            this.continueBtn.Text = "Continue";
            this.continueBtn.UseVisualStyleBackColor = false;
            this.continueBtn.UsingHoverAnimation = false;
            this.continueBtn.Visible = false;
            // 
            // menuBtn
            // 
            this.menuBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.menuBtn.AnimationTime = 0.2F;
            this.menuBtn.BackColor = System.Drawing.Color.Teal;
            this.menuBtn.CornerRadius = 15;
            this.menuBtn.FlatAppearance.BorderSize = 0;
            this.menuBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuBtn.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.menuBtn.ForeColor = System.Drawing.Color.White;
            this.menuBtn.HoverScale = 1.05F;
            this.menuBtn.Location = new System.Drawing.Point(579, 498);
            this.menuBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.menuBtn.Name = "menuBtn";
            this.menuBtn.OriginalSize = new System.Drawing.Size(0, 0);
            this.menuBtn.Size = new System.Drawing.Size(150, 67);
            this.menuBtn.TabIndex = 16;
            this.menuBtn.Text = "Menu";
            this.menuBtn.UseVisualStyleBackColor = false;
            this.menuBtn.UsingHoverAnimation = false;
            this.menuBtn.Visible = false;
            // 
            // restartBtn
            // 
            this.restartBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.restartBtn.AnimationTime = 0.2F;
            this.restartBtn.BackColor = System.Drawing.Color.Teal;
            this.restartBtn.CornerRadius = 15;
            this.restartBtn.FlatAppearance.BorderSize = 0;
            this.restartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restartBtn.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.restartBtn.ForeColor = System.Drawing.Color.White;
            this.restartBtn.HoverScale = 1.05F;
            this.restartBtn.Location = new System.Drawing.Point(378, 498);
            this.restartBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.restartBtn.Name = "restartBtn";
            this.restartBtn.OriginalSize = new System.Drawing.Size(0, 0);
            this.restartBtn.Size = new System.Drawing.Size(150, 67);
            this.restartBtn.TabIndex = 17;
            this.restartBtn.Text = "Restart";
            this.restartBtn.UseVisualStyleBackColor = false;
            this.restartBtn.UsingHoverAnimation = false;
            this.restartBtn.Visible = false;
            // 
            // scoreLabel
            // 
            this.scoreLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.scoreLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.scoreLabel.Font = new System.Drawing.Font("Stencil", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scoreLabel.Location = new System.Drawing.Point(242, 314);
            this.scoreLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(416, 74);
            this.scoreLabel.TabIndex = 18;
            this.scoreLabel.Text = "Paused";
            this.scoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.scoreLabel.Visible = false;
            // 
            // isHighScoreLabel
            // 
            this.isHighScoreLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.isHighScoreLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.isHighScoreLabel.Font = new System.Drawing.Font("Stencil", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.isHighScoreLabel.ForeColor = System.Drawing.Color.White;
            this.isHighScoreLabel.Location = new System.Drawing.Point(242, 402);
            this.isHighScoreLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.isHighScoreLabel.Name = "isHighScoreLabel";
            this.isHighScoreLabel.Size = new System.Drawing.Size(416, 57);
            this.isHighScoreLabel.TabIndex = 19;
            this.isHighScoreLabel.Text = "Paused";
            this.isHighScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.isHighScoreLabel.Visible = false;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(900, 800);
            this.Controls.Add(this.isHighScoreLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.restartBtn);
            this.Controls.Add(this.menuBtn);
            this.Controls.Add(this.continueBtn);
            this.Controls.Add(this.pausedLabel);
            this.Controls.Add(this.musicSlider);
            this.Controls.Add(this.musicLabel);
            this.Controls.Add(this.sfxLabel);
            this.Controls.Add(this.soundEffectSlider);
            this.Controls.Add(this.circelPause);
            this.Controls.Add(this.board);
            this.Name = "Game";
            this.Text = "Tetris";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Graphics.Board board;
        private CustomWfControls.CircelPause circelPause;
        private System.Windows.Forms.Label pausedLabel;
        private CustomWfControls.Slider musicSlider;
        private System.Windows.Forms.Label musicLabel;
        private System.Windows.Forms.Label sfxLabel;
        private CustomWfControls.Slider soundEffectSlider;
        private CustomWfControls.FlatButton continueBtn;
        private CustomWfControls.FlatButton menuBtn;
        private CustomWfControls.FlatButton restartBtn;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label isHighScoreLabel;
    }
}

