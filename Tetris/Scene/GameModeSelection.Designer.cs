
namespace Tetris
{
    partial class GameModeSelection
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
            this.normalModeBtn = new Tetris.CustomWfControls.FlatButton();
            this.risingFloorBtn = new Tetris.CustomWfControls.FlatButton();
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // normalModeBtn
            // 
            this.normalModeBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.normalModeBtn.AnimationTime = 0.2F;
            this.normalModeBtn.BackColor = System.Drawing.Color.Teal;
            this.normalModeBtn.CornerRadius = 15;
            this.normalModeBtn.FlatAppearance.BorderSize = 0;
            this.normalModeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.normalModeBtn.Font = new System.Drawing.Font("Stencil", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.normalModeBtn.ForeColor = System.Drawing.Color.White;
            this.normalModeBtn.HoverScale = 1.1F;
            this.normalModeBtn.Location = new System.Drawing.Point(150, 180);
            this.normalModeBtn.Name = "normalModeBtn";
            this.normalModeBtn.OriginalSize = new System.Drawing.Size(0, 0);
            this.normalModeBtn.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.normalModeBtn.Size = new System.Drawing.Size(250, 250);
            this.normalModeBtn.TabIndex = 1;
            this.normalModeBtn.Text = "NORMAL";
            this.normalModeBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.normalModeBtn.UseVisualStyleBackColor = false;
            this.normalModeBtn.UsingHoverAnimation = false;
            // 
            // risingFloorBtn
            // 
            this.risingFloorBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.risingFloorBtn.AnimationTime = 0.2F;
            this.risingFloorBtn.BackColor = System.Drawing.Color.Teal;
            this.risingFloorBtn.CornerRadius = 15;
            this.risingFloorBtn.FlatAppearance.BorderSize = 0;
            this.risingFloorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.risingFloorBtn.Font = new System.Drawing.Font("Stencil", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.risingFloorBtn.ForeColor = System.Drawing.Color.White;
            this.risingFloorBtn.HoverScale = 1.1F;
            this.risingFloorBtn.Location = new System.Drawing.Point(642, 180);
            this.risingFloorBtn.Name = "risingFloorBtn";
            this.risingFloorBtn.OriginalSize = new System.Drawing.Size(0, 0);
            this.risingFloorBtn.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.risingFloorBtn.Size = new System.Drawing.Size(250, 250);
            this.risingFloorBtn.TabIndex = 2;
            this.risingFloorBtn.Text = "RISING FLOOR";
            this.risingFloorBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.risingFloorBtn.UseVisualStyleBackColor = false;
            this.risingFloorBtn.UsingHoverAnimation = false;
            // 
            // label
            // 
            this.label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label.AutoSize = true;
            this.label.BackColor = System.Drawing.Color.Transparent;
            this.label.Font = new System.Drawing.Font("Stencil", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.Location = new System.Drawing.Point(273, 103);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(487, 44);
            this.label.TabIndex = 4;
            this.label.Text = "CHOOSE YOUR GAMEMODE";
            // 
            // GameModeSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1032, 610);
            this.Controls.Add(this.label);
            this.Controls.Add(this.risingFloorBtn);
            this.Controls.Add(this.normalModeBtn);
            this.Name = "GameModeSelection";
            this.Text = "GameModeSelection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomWfControls.FlatButton normalModeBtn;
        private CustomWfControls.FlatButton risingFloorBtn;
        private System.Windows.Forms.Label label;
    }
}