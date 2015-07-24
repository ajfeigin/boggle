namespace Boggle {
    partial class FrmChooseGame {
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
            this.btnNumber = new System.Windows.Forms.Button();
            this.btnBoggle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNumber
            // 
            this.btnNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNumber.Location = new System.Drawing.Point(26, 64);
            this.btnNumber.Name = "btnNumber";
            this.btnNumber.Size = new System.Drawing.Size(225, 64);
            this.btnNumber.TabIndex = 0;
            this.btnNumber.Text = "Number";
            this.btnNumber.UseVisualStyleBackColor = true;
            this.btnNumber.Click += new System.EventHandler(this.btnNumber_Click);
            // 
            // btnBoggle
            // 
            this.btnBoggle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoggle.Location = new System.Drawing.Point(26, 169);
            this.btnBoggle.Name = "btnBoggle";
            this.btnBoggle.Size = new System.Drawing.Size(225, 64);
            this.btnBoggle.TabIndex = 1;
            this.btnBoggle.Text = "Word";
            this.btnBoggle.UseVisualStyleBackColor = true;
            this.btnBoggle.Click += new System.EventHandler(this.btnBoggle_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Boggle-like games";
            // 
            // FrmChooseGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 268);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBoggle);
            this.Controls.Add(this.btnNumber);
            this.Name = "FrmChooseGame";
            this.Text = "Choose your game!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNumber;
        private System.Windows.Forms.Button btnBoggle;
        private System.Windows.Forms.Label label1;
    }
}