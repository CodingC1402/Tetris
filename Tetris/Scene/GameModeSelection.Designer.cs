
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
            this.normalLabel = new System.Windows.Forms.Label();
            this.risingLabel = new System.Windows.Forms.Label();
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
            this.normalModeBtn.HoverScale = 1.05F;
            this.normalModeBtn.Location = new System.Drawing.Point(150, 180);
            this.normalModeBtn.Name = "normalModeBtn";
            this.normalModeBtn.OriginalSize = new System.Drawing.Size(0, 0);
            this.normalModeBtn.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.normalModeBtn.Size = new System.Drawing.Size(250, 250);
            this.normalModeBtn.TabIndex = 1;
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
            this.risingFloorBtn.HoverScale = 1.05F;
            this.risingFloorBtn.Location = new System.Drawing.Point(642, 180);
            this.risingFloorBtn.Name = "risingFloorBtn";
            this.risingFloorBtn.OriginalSize = new System.Drawing.Size(0, 0);
            this.risingFloorBtn.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.risingFloorBtn.Size = new System.Drawing.Size(250, 250);
            this.risingFloorBtn.TabIndex = 2;
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
            this.label.Location = new System.Drawing.Point(273, 50);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(487, 44);
            this.label.TabIndex = 4;
            this.label.Text = "CHOOSE YOUR GAMEMODE";
            // 
            // normalLabel
            // 
            this.normalLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.normalLabel.AutoSize = true;
            this.normalLabel.BackColor = System.Drawing.Color.Transparent;
            this.normalLabel.Font = new System.Drawing.Font("Stencil", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.normalLabel.ForeColor = System.Drawing.Color.White;
            this.normalLabel.Location = new System.Drawing.Point(170, 453);
            this.normalLabel.Name = "normalLabel";
            this.normalLabel.Size = new System.Drawing.Size(210, 32);
            this.normalLabel.TabIndex = 5;
            this.normalLabel.Text = "NORMAL MODE";
            // 
            // risingLabel
            // 
            this.risingLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.risingLabel.AutoSize = true;
            this.risingLabel.BackColor = System.Drawing.Color.Transparent;
            this.risingLabel.Font = new System.Drawing.Font("Stencil", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.risingLabel.ForeColor = System.Drawing.Color.White;
            this.risingLabel.Location = new System.Drawing.Point(664, 453);
            this.risingLabel.Name = "risingLabel";
            this.risingLabel.Size = new System.Drawing.Size(206, 32);
            this.risingLabel.TabIndex = 6;
            this.risingLabel.Text = "RISING FLOOR";
            // 
            // GameModeSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1032, 610);
            this.Controls.Add(this.risingLabel);
            this.Controls.Add(this.normalLabel);
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
        private System.Windows.Forms.Label normalLabel;
        private System.Windows.Forms.Label risingLabel;
    }
}