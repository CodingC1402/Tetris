
namespace Tetris
{
    partial class MainMenu
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
            this.startButton = new Tetris.CustomWfControls.FlatButton();
            this.quitButton = new Tetris.CustomWfControls.FlatButton();
            this.pressAnyKeyToStartLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.startButton.AnimationTime = 0.2F;
            this.startButton.BackColor = System.Drawing.Color.Teal;
            this.startButton.CornerRadius = 15;
            this.startButton.FlatAppearance.BorderSize = 0;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Font = new System.Drawing.Font("Stencil", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.startButton.ForeColor = System.Drawing.Color.White;
            this.startButton.HoverScale = 1.05F;
            this.startButton.Location = new System.Drawing.Point(413, 256);
            this.startButton.Name = "startButton";
            this.startButton.OriginalSize = new System.Drawing.Size(0, 0);
            this.startButton.Size = new System.Drawing.Size(228, 70);
            this.startButton.TabIndex = 8;
            this.startButton.Text = "START";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.UsingHoverAnimation = false;
            // 
            // quitButton
            // 
            this.quitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.quitButton.AnimationTime = 0.2F;
            this.quitButton.BackColor = System.Drawing.Color.Teal;
            this.quitButton.CornerRadius = 15;
            this.quitButton.FlatAppearance.BorderSize = 0;
            this.quitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitButton.Font = new System.Drawing.Font("Stencil", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.quitButton.ForeColor = System.Drawing.Color.White;
            this.quitButton.HoverScale = 1.05F;
            this.quitButton.Location = new System.Drawing.Point(448, 350);
            this.quitButton.Name = "quitButton";
            this.quitButton.OriginalSize = new System.Drawing.Size(0, 0);
            this.quitButton.Size = new System.Drawing.Size(159, 60);
            this.quitButton.TabIndex = 9;
            this.quitButton.Text = "QUIT";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.UsingHoverAnimation = false;
            // 
            // pressAnyKeyToStartLable
            // 
            this.pressAnyKeyToStartLable.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pressAnyKeyToStartLable.AutoSize = true;
            this.pressAnyKeyToStartLable.Font = new System.Drawing.Font("Stencil", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.pressAnyKeyToStartLable.ForeColor = System.Drawing.Color.White;
            this.pressAnyKeyToStartLable.Location = new System.Drawing.Point(314, 502);
            this.pressAnyKeyToStartLable.Name = "pressAnyKeyToStartLable";
            this.pressAnyKeyToStartLable.Size = new System.Drawing.Size(426, 38);
            this.pressAnyKeyToStartLable.TabIndex = 10;
            this.pressAnyKeyToStartLable.Text = "Press any key to start";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1054, 583);
            this.Controls.Add(this.pressAnyKeyToStartLable);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.startButton);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CustomWfControls.FlatButton startButton;
        private CustomWfControls.FlatButton quitButton;
        private System.Windows.Forms.Label pressAnyKeyToStartLable;
    }
}