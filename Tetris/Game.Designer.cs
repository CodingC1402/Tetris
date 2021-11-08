
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
            this.fpsLabel = new System.Windows.Forms.Label();
            this.board1 = new Tetris.Graphics.Board();
            this.SuspendLayout();
            // 
            // fpsLabel
            // 
            this.fpsLabel.AutoSize = true;
            this.fpsLabel.BackColor = System.Drawing.Color.White;
            this.fpsLabel.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.fpsLabel.ForeColor = System.Drawing.Color.Black;
            this.fpsLabel.Location = new System.Drawing.Point(11, 10);
            this.fpsLabel.Name = "fpsLabel";
            this.fpsLabel.Size = new System.Drawing.Size(85, 29);
            this.fpsLabel.TabIndex = 1;
            this.fpsLabel.Text = "label1";
            // 
            // board1
            // 
            this.board1.BackColor = System.Drawing.Color.Black;
            this.board1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.board1.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.board1.Location = new System.Drawing.Point(0, 0);
            this.board1.Margin = new System.Windows.Forms.Padding(20);
            this.board1.Name = "board1";
            this.board1.Size = new System.Drawing.Size(884, 761);
            this.board1.TabIndex = 5;
            this.board1.Text = "board1";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(884, 761);
            this.Controls.Add(this.fpsLabel);
            this.Controls.Add(this.board1);
            this.MinimumSize = new System.Drawing.Size(900, 800);
            this.Name = "Game";
            this.Text = "Tetris";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label fpsLabel;
        private Graphics.Board board1;
    }
}

