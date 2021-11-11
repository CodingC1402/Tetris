
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
            this.SuspendLayout();
            // 
            // soundEffectSlider
            // 
            this.soundEffectSlider.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.soundEffectSlider.BackColor = System.Drawing.Color.Transparent;
            this.soundEffectSlider.CornerRadius = 10;
            this.soundEffectSlider.Location = new System.Drawing.Point(326, 146);
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
            this.sfxLabel.Location = new System.Drawing.Point(19, 142);
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
            this.musicLabel.Location = new System.Drawing.Point(19, 220);
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
            this.musicSlider.Location = new System.Drawing.Point(326, 219);
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
            this.settingLabel.Location = new System.Drawing.Point(368, 40);
            this.settingLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.settingLabel.Name = "settingLabel";
            this.settingLabel.Size = new System.Drawing.Size(226, 57);
            this.settingLabel.TabIndex = 9;
            this.settingLabel.Text = "Setting";
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
            // SettingMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(963, 570);
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
    }
}