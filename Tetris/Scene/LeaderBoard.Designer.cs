
namespace Tetris
{
    partial class LeaderBoard
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
            this.normalBoard = new Tetris.Graphics.LeaderBoardUI();
            this.risingBoard = new Tetris.Graphics.LeaderBoardUI();
            this.SuspendLayout();
            // 
            // normalBoard
            // 
            this.normalBoard.BoardImage = null;
            this.normalBoard.Font = new System.Drawing.Font("Stencil", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.normalBoard.ForeColor = System.Drawing.Color.White;
            this.normalBoard.ItemFont = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.normalBoard.Location = new System.Drawing.Point(39, 54);
            this.normalBoard.Name = "normalBoard";
            this.normalBoard.Size = new System.Drawing.Size(359, 614);
            this.normalBoard.TabIndex = 0;
            this.normalBoard.Text = "Normal mode";
            this.normalBoard.TextBoardPadding = 10;
            // 
            // risingBoard
            // 
            this.risingBoard.BoardImage = null;
            this.risingBoard.Font = new System.Drawing.Font("Stencil", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.risingBoard.ForeColor = System.Drawing.Color.White;
            this.risingBoard.ItemFont = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.risingBoard.Location = new System.Drawing.Point(685, 54);
            this.risingBoard.Name = "risingBoard";
            this.risingBoard.Size = new System.Drawing.Size(357, 614);
            this.risingBoard.TabIndex = 1;
            this.risingBoard.Text = "Rising floor Mode";
            this.risingBoard.TextBoardPadding = 10;
            // 
            // LeaderBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1074, 704);
            this.Controls.Add(this.risingBoard);
            this.Controls.Add(this.normalBoard);
            this.Name = "LeaderBoard";
            this.Text = "ScoreBoard";
            this.ResumeLayout(false);

        }

        #endregion

        private Graphics.LeaderBoardUI normalBoard;
        private Graphics.LeaderBoardUI risingBoard;
    }
}