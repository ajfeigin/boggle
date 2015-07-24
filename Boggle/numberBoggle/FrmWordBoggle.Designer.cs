namespace Boggle {
    partial class FrmWordBoggle {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.btnBigGame = new System.Windows.Forms.Button();
            this.btnRegGame = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnBigGame
            // 
            this.btnBigGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBigGame.Location = new System.Drawing.Point(462, 198);
            this.btnBigGame.Name = "btnBigGame";
            this.btnBigGame.Size = new System.Drawing.Size(132, 40);
            this.btnBigGame.TabIndex = 1;
            this.btnBigGame.Text = "New Big Boggle Game!";
            this.btnBigGame.UseVisualStyleBackColor = true;
            this.btnBigGame.Click += new System.EventHandler(this.newBigGame_Click);
            // 
            // btnRegGame
            // 
            this.btnRegGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegGame.Location = new System.Drawing.Point(462, 130);
            this.btnRegGame.Name = "btnRegGame";
            this.btnRegGame.Size = new System.Drawing.Size(132, 40);
            this.btnRegGame.TabIndex = 2;
            this.btnRegGame.Text = "New Regular Boggle Game!";
            this.btnRegGame.UseVisualStyleBackColor = true;
            this.btnRegGame.Click += new System.EventHandler(this.newRegularGame_Click);
            // 
            // FrmWordBoggle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 451);
            this.Controls.Add(this.btnRegGame);
            this.Controls.Add(this.btnBigGame);
            this.Name = "FrmWordBoggle";
            this.Text = "Word game";
            this.Controls.SetChildIndex(this.txtWords, 0);
            this.Controls.SetChildIndex(this.btnValidate, 0);
            this.Controls.SetChildIndex(this.btnBigGame, 0);
            this.Controls.SetChildIndex(this.btnRegGame, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBigGame;
        private System.Windows.Forms.Button btnRegGame;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}