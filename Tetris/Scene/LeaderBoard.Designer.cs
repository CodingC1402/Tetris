
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
            this.risingBoard = new Tetris.Graphics.LeaderBoardUI();
            this.normalBoard = new Tetris.Graphics.LeaderBoardUI();
            this.label1 = new System.Windows.Forms.Label();
            this.gameModeSelection = new Tetris.CustomWfControls.FlatButton();
            this.SuspendLayout();
            // 
            // risingBoard
            // 
            this.risingBoard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.risingBoard.BackColor = System.Drawing.Color.Transparent;
            this.risingBoard.BoardImage = null;
            this.risingBoard.Font = new System.Drawing.Font("Stencil", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.risingBoard.ForeColor = System.Drawing.Color.White;
            this.risingBoard.ItemFont = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.risingBoard.Location = new System.Drawing.Point(704, 143);
            this.risingBoard.Name = "risingBoard";
            this.risingBoard.Size = new System.Drawing.Size(350, 600);
            this.risingBoard.TabIndex = 5;
            this.risingBoard.Text = "Rising floor Mode";
            this.risingBoard.TextBoardPadding = 10;
            // 
            // normalBoard
            // 
            this.normalBoard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.normalBoard.BackColor = System.Drawing.Color.Transparent;
            this.normalBoard.BoardImage = null;
            this.normalBoard.Font = new System.Drawing.Font("Stencil", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.normalBoard.ForeColor = System.Drawing.Color.White;
            this.normalBoard.ItemFont = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.normalBoard.Location = new System.Drawing.Point(163, 143);
            this.normalBoard.Name = "normalBoard";
            this.normalBoard.Size = new System.Drawing.Size(350, 600);
            this.normalBoard.TabIndex = 4;
            this.normalBoard.Text = "Normal mode";
            this.normalBoard.TextBoardPadding = 10;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Stencil", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(462, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 44);
            this.label1.TabIndex = 6;
            this.label1.Text = "LEADER BOARD";
            // 
            // gameModeSelection
            // 
            this.gameModeSelection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gameModeSelection.AnimationTime = 0.2F;
            this.gameModeSelection.BackColor = System.Drawing.Color.Teal;
            this.gameModeSelection.CornerRadius = 15;
            this.gameModeSelection.FlatAppearance.BorderSize = 0;
            this.gameModeSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gameModeSelection.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gameModeSelection.ForeColor = System.Drawing.Color.White;
            this.gameModeSelection.HoverScale = 1.05F;
            this.gameModeSelection.Location = new System.Drawing.Point(462, 782);
            this.gameModeSelection.Name = "gameModeSelection";
            this.gameModeSelection.OriginalSize = new System.Drawing.Size(0, 0);
            this.gameModeSelection.Size = new System.Drawing.Size(303, 50);
            this.gameModeSelection.TabIndex = 7;
            this.gameModeSelection.Text = "Game mode selection";
            this.gameModeSelection.UseVisualStyleBackColor = false;
            this.gameModeSelection.UsingHoverAnimation = false;
            // 
            // LeaderBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1221, 901);
            this.Controls.Add(this.risingBoard);
            this.Controls.Add(this.normalBoard);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gameModeSelection);
            this.Name = "LeaderBoard";
            this.Text = "ScoreBoard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Graphics.LeaderBoardUI risingBoard;
        private Graphics.LeaderBoardUI normalBoard;
        private System.Windows.Forms.Label label1;
        private CustomWfControls.FlatButton gameModeSelection;
    }
}