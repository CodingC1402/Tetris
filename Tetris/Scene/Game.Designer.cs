
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
            this.SuspendLayout();
            // 
            // board
            // 
            this.board.BackColor = System.Drawing.Color.Black;
            this.board.BoardOpacity = 0.9F;
            this.board.Dock = System.Windows.Forms.DockStyle.Fill;
            this.board.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
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
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(900, 800);
            this.Controls.Add(this.circelPause);
            this.Controls.Add(this.board);
            this.Name = "Game";
            this.Text = "Tetris";
            this.ResumeLayout(false);

        }

        #endregion
        private Graphics.Board board;
        private CustomWfControls.CircelPause circelPause;
    }
}

