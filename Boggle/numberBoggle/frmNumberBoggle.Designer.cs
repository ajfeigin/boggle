namespace Boggle
{
    partial class FrmNumberBoggle
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
            this.btnNew2dig = new System.Windows.Forms.Button();
            this.lblRows = new System.Windows.Forms.Label();
            this.lblCols = new System.Windows.Forms.Label();
            this.numudCols = new System.Windows.Forms.NumericUpDown();
            this.numudRows = new System.Windows.Forms.NumericUpDown();
            this.gbTarget = new System.Windows.Forms.GroupBox();
            this.lblTarget = new System.Windows.Forms.Label();
            this.btnNew3dig = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numudCols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numudRows)).BeginInit();
            this.gbTarget.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNew2dig
            // 
            this.btnNew2dig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew2dig.Location = new System.Drawing.Point(435, 109);
            this.btnNew2dig.Name = "btnNew2dig";
            this.btnNew2dig.Size = new System.Drawing.Size(86, 40);
            this.btnNew2dig.TabIndex = 0;
            this.btnNew2dig.Text = "New 2-digit target Game!";
            this.btnNew2dig.UseVisualStyleBackColor = true;
            this.btnNew2dig.Click += new System.EventHandler(this.new2digNums_Click);
            // 
            // lblRows
            // 
            this.lblRows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRows.AutoSize = true;
            this.lblRows.Location = new System.Drawing.Point(466, 243);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(41, 13);
            this.lblRows.TabIndex = 22;
            this.lblRows.Text = "#Rows";
            // 
            // lblCols
            // 
            this.lblCols.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCols.AutoSize = true;
            this.lblCols.Location = new System.Drawing.Point(547, 243);
            this.lblCols.Name = "lblCols";
            this.lblCols.Size = new System.Drawing.Size(54, 13);
            this.lblCols.TabIndex = 23;
            this.lblCols.Text = "#Columns";
            // 
            // numudCols
            // 
            this.numudCols.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numudCols.Location = new System.Drawing.Point(550, 264);
            this.numudCols.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numudCols.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numudCols.Name = "numudCols";
            this.numudCols.Size = new System.Drawing.Size(47, 20);
            this.numudCols.TabIndex = 3;
            this.numudCols.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numudCols.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // numudRows
            // 
            this.numudRows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numudRows.Location = new System.Drawing.Point(466, 264);
            this.numudRows.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numudRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numudRows.Name = "numudRows";
            this.numudRows.Size = new System.Drawing.Size(47, 20);
            this.numudRows.TabIndex = 2;
            this.numudRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numudRows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // gbTarget
            // 
            this.gbTarget.Controls.Add(this.lblTarget);
            this.gbTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTarget.Location = new System.Drawing.Point(435, 154);
            this.gbTarget.Name = "gbTarget";
            this.gbTarget.Size = new System.Drawing.Size(194, 86);
            this.gbTarget.TabIndex = 31;
            this.gbTarget.TabStop = false;
            this.gbTarget.Text = "Target Number:";
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarget.Location = new System.Drawing.Point(47, 32);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(132, 42);
            this.lblTarget.TabIndex = 0;
            this.lblTarget.Text = "Target";
            // 
            // btnNew3dig
            // 
            this.btnNew3dig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew3dig.Location = new System.Drawing.Point(533, 109);
            this.btnNew3dig.Name = "btnNew3dig";
            this.btnNew3dig.Size = new System.Drawing.Size(86, 40);
            this.btnNew3dig.TabIndex = 45;
            this.btnNew3dig.Text = "New 3-digit target Game!";
            this.btnNew3dig.UseVisualStyleBackColor = true;
            this.btnNew3dig.Click += new System.EventHandler(this.new3digNums_Click);
            // 
            // FrmNumberBoggle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(630, 451);
            this.Controls.Add(this.btnNew3dig);
            this.Controls.Add(this.gbTarget);
            this.Controls.Add(this.numudRows);
            this.Controls.Add(this.numudCols);
            this.Controls.Add(this.lblCols);
            this.Controls.Add(this.lblRows);
            this.Controls.Add(this.btnNew2dig);
            this.Name = "FrmNumberBoggle";
            this.Text = "Number game";
            this.Controls.SetChildIndex(this.txtWords, 0);
            this.Controls.SetChildIndex(this.btnValidate, 0);
            this.Controls.SetChildIndex(this.btnNew2dig, 0);
            this.Controls.SetChildIndex(this.lblRows, 0);
            this.Controls.SetChildIndex(this.lblCols, 0);
            this.Controls.SetChildIndex(this.numudCols, 0);
            this.Controls.SetChildIndex(this.numudRows, 0);
            this.Controls.SetChildIndex(this.gbTarget, 0);
            this.Controls.SetChildIndex(this.btnNew3dig, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numudCols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numudRows)).EndInit();
            this.gbTarget.ResumeLayout(false);
            this.gbTarget.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNew2dig;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.Label lblCols;
        private System.Windows.Forms.NumericUpDown numudCols;
        private System.Windows.Forms.NumericUpDown numudRows;
        private System.Windows.Forms.GroupBox gbTarget;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.Button btnNew3dig;
    }
}

