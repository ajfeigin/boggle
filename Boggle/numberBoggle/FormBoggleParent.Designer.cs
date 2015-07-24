namespace Boggle {
    partial class FormBoggleParent {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlflash = new System.Windows.Forms.Panel();
            this.lblTimerLength = new System.Windows.Forms.Label();
            this.numTime = new System.Windows.Forms.NumericUpDown();
            this.lblTimer = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dgValues = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnInstructions = new System.Windows.Forms.Button();
            this.btnValidate = new System.Windows.Forms.Button();
            this.dgvCheckWords = new System.Windows.Forms.DataGridView();
            this.txtWords = new System.Windows.Forms.TextBox();
            this.lblReviewWords = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckWords)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlflash
            // 
            this.pnlflash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlflash.Location = new System.Drawing.Point(417, 363);
            this.pnlflash.Name = "pnlflash";
            this.pnlflash.Size = new System.Drawing.Size(199, 76);
            this.pnlflash.TabIndex = 34;
            // 
            // lblTimerLength
            // 
            this.lblTimerLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimerLength.AutoSize = true;
            this.lblTimerLength.Location = new System.Drawing.Point(442, 305);
            this.lblTimerLength.Name = "lblTimerLength";
            this.lblTimerLength.Size = new System.Drawing.Size(114, 13);
            this.lblTimerLength.TabIndex = 33;
            this.lblTimerLength.Text = "Timer length (seconds)";
            // 
            // numTime
            // 
            this.numTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numTime.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numTime.Location = new System.Drawing.Point(564, 303);
            this.numTime.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numTime.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numTime.Name = "numTime";
            this.numTime.Size = new System.Drawing.Size(49, 20);
            this.numTime.TabIndex = 30;
            this.numTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numTime.Value = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numTime.ValueChanged += new System.EventHandler(this.numTime_ValueChanged);
            // 
            // lblTimer
            // 
            this.lblTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(461, 336);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(33, 13);
            this.lblTimer.TabIndex = 32;
            this.lblTimer.Text = "Timer";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(513, 329);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 31;
            // 
            // dgValues
            // 
            this.dgValues.AllowUserToAddRows = false;
            this.dgValues.AllowUserToDeleteRows = false;
            this.dgValues.AllowUserToResizeColumns = false;
            this.dgValues.AllowUserToResizeRows = false;
            this.dgValues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgValues.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgValues.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgValues.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgValues.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgValues.Location = new System.Drawing.Point(8, 95);
            this.dgValues.Name = "dgValues";
            this.dgValues.ReadOnly = true;
            this.dgValues.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgValues.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgValues.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgValues.Size = new System.Drawing.Size(421, 265);
            this.dgValues.TabIndex = 35;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(246, 383);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(132, 40);
            this.btnCancel.TabIndex = 36;
            this.btnCancel.Text = "Cancel Game";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnInstructions
            // 
            this.btnInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInstructions.Location = new System.Drawing.Point(57, 383);
            this.btnInstructions.Name = "btnInstructions";
            this.btnInstructions.Size = new System.Drawing.Size(131, 40);
            this.btnInstructions.TabIndex = 37;
            this.btnInstructions.Text = "Instructions";
            this.btnInstructions.UseVisualStyleBackColor = true;
            this.btnInstructions.Click += new System.EventHandler(this.btnInstructions_Click);
            // 
            // btnValidate
            // 
            this.btnValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnValidate.Location = new System.Drawing.Point(473, 78);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(95, 25);
            this.btnValidate.TabIndex = 43;
            this.btnValidate.Text = "Check Words";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // dgvCheckWords
            // 
            this.dgvCheckWords.AllowUserToAddRows = false;
            this.dgvCheckWords.AllowUserToDeleteRows = false;
            this.dgvCheckWords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCheckWords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCheckWords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCheckWords.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCheckWords.Location = new System.Drawing.Point(12, 6);
            this.dgvCheckWords.Name = "dgvCheckWords";
            this.dgvCheckWords.RowHeadersVisible = false;
            this.dgvCheckWords.ShowEditingIcon = false;
            this.dgvCheckWords.Size = new System.Drawing.Size(403, 70);
            this.dgvCheckWords.TabIndex = 42;
            this.dgvCheckWords.Visible = false;
            this.dgvCheckWords.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCheckWords_CellClick);
            // 
            // txtWords
            // 
            this.txtWords.AcceptsReturn = true;
            this.txtWords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWords.Location = new System.Drawing.Point(435, 24);
            this.txtWords.Multiline = true;
            this.txtWords.Name = "txtWords";
            this.txtWords.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtWords.Size = new System.Drawing.Size(184, 49);
            this.txtWords.TabIndex = 41;
            this.txtWords.TextChanged += new System.EventHandler(this.txtWord_Changed);
            // 
            // lblReviewWords
            // 
            this.lblReviewWords.AutoSize = true;
            this.lblReviewWords.Location = new System.Drawing.Point(440, 4);
            this.lblReviewWords.Name = "lblReviewWords";
            this.lblReviewWords.Size = new System.Drawing.Size(93, 13);
            this.lblReviewWords.TabIndex = 44;
            this.lblReviewWords.Text = "Answers to review";
            // 
            // FormBoggleParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(630, 451);
            this.Controls.Add(this.lblReviewWords);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.dgvCheckWords);
            this.Controls.Add(this.txtWords);
            this.Controls.Add(this.btnInstructions);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dgValues);
            this.Controls.Add(this.pnlflash);
            this.Controls.Add(this.lblTimerLength);
            this.Controls.Add(this.numTime);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.progressBar1);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(640, 483);
            this.Name = "FormBoggleParent";
            this.Text = "FormBoggleParent";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmBoggleParent_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.numTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckWords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel pnlflash;
        private System.Windows.Forms.Label lblTimerLength;
        internal System.Windows.Forms.NumericUpDown numTime;
        private System.Windows.Forms.Label lblTimer;
        internal System.Windows.Forms.ProgressBar progressBar1;
        internal System.Windows.Forms.DataGridView dgValues;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnInstructions;
        protected System.Windows.Forms.Button btnValidate;
        protected System.Windows.Forms.DataGridView dgvCheckWords;
        protected System.Windows.Forms.TextBox txtWords;
        private System.Windows.Forms.Label lblReviewWords;
        private System.Windows.Forms.ToolTip toolTip1;

    }
}