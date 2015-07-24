using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using Mommo.Data;

namespace Boggle {
    public partial class FormBoggleParent : Form {
        //initial  value for 1 step in the progress bar (reset by the UI) in ms
        protected int onestep;
        //initial value for increment between flashes of the progress bar
        protected int tflashstep = 500;
        //progress bar timer
        protected readonly Timer timer = new Timer();
        //timer for flashing the progress bar
        protected readonly Timer timerFlash = new Timer();
        //The data for populating the grid
        protected BoggleGridVals GridVals;
        //timer for switching between highlighted locations
        protected Timer timerpaintlocations_ = new Timer();
        //which sequence of those entered by the user has been selected
        protected int selectedword_=-1;
        protected int selectedlocation_;
        protected string type_;
        protected string verification_;

        public FormBoggleParent() {
            InitializeComponent();
            //% of the progress bar moved in each step
            progressBar1.Step = 1;
            //initialise the progress bar timer interval value
            onestep = (int)(numTime.Value * 10);
            timerFlash.Tick += timerFlash_Tick;
            //attach a method the tick even of the progress bar timer
            timer.Tick += timer_Tick;
            txtWords.Enabled = false;
            //setup the timer for highlighting different copies of the same word when validated
            timerpaintlocations_.Interval = 1000;
            timerpaintlocations_.Tick += TimerpaintlocationsTick;
            btnValidate.Enabled = false;
        }
        private void btnCancel_Click(object sender, EventArgs e) {
            timer.Stop();
            timerFlash.Stop();
            timerpaintlocations_.Stop();
            resetDGValuesColorWhite();
            progressBar1.Value = 0;
        }
        protected void numTime_ValueChanged(object sender, EventArgs e) {
            //set the value of the step of the progress bar based on the amount of time entered in the UI
            // steps are measured in milliseconds so to get 100th of the total time entered divide by 100 and multiply 
            // by 1000 hence multiply by 10
            onestep = (int)(numTime.Value * 10);

            //set step of the notification timer to be a fairly small number but a function of the total time of the game
            tflashstep = (int)Math.Min(500, Math.Max(numTime.Value * 3, 50));
        }

        protected void SetupGrid(){
            //http://www.codeproject.com/KB/database/BindArrayGrid.aspx for code used to easily bind a 2 dimensional
            // array to a datagridview
            dgValues.DataSource = new ArrayDataView(GridVals.GetValues());
            pnlflash.ResetBackColor();
            pnlflash.Refresh();
            //reset row height to fill the grid
            dgValues.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            int height = dgValues.Height;
            foreach (DataGridViewRow row in dgValues.Rows) row.Height = height / GridVals.Rows;
            dgValues.Refresh();
            //link data grid to the random number array
            //set the timer interval to a value which is a function of the amount of time the progress bar should run
            if (timerFlash.Enabled) timerFlash.Stop();
            if (timer.Enabled) timer.Stop();
            timer.Interval = onestep;
            progressBar1.Visible = true;
            //reset the progress bar
            progressBar1.Value = 0;
            //start the progress bar timer
            timer.Start();
            //ensure the flashing progress bar is visible, set to the default colour and refreshed
            pnlflash.Visible = true;
            pnlflash.ResetForeColor();
            pnlflash.Refresh();
            //set the notification time step
            timerFlash.Interval = tflashstep;
        }
        protected void timerFlash_Tick(object sender, EventArgs e) {
            //flash the progress bar and the notification panel    
            if (progressBar1.Visible) {
                progressBar1.Visible = false;
                pnlflash.Visible = false;
            } else {
                progressBar1.Visible = true;
                pnlflash.Visible = true;
            }
        }

        protected void timer_Tick(object sender, EventArgs e) {
            progressBar1.Increment(1);
            if (progressBar1.Value == progressBar1.Maximum) {
                // stop the time that increments the progress bar
                timer.Stop();
                pnlflash.Visible = true;
                progressBar1.Visible = true;
                //            http://msdn.microsoft.com/en-us/library/4y171b18.aspx play a sound at the end of the game
                const string sound = @"c:\Windows\Media\Windows Print complete.wav";
                if (File.Exists(sound)) {
                    var simpleSound = new SoundPlayer(sound);
                    simpleSound.Play();
                    simpleSound.Play();
                    simpleSound.Play();
                } else {
                    Console.Beep(1000, 400);
                    Console.Beep(1000, 400);
                    Console.Beep(1000, 400);
                }
                // stop the time that makes the progress bar flash
                timerFlash.Stop();
                //ensure the progress bar is visible at the end of the game
                progressBar1.Visible = true;
                //show a message box indicating that the game is over
                MessageBox.Show(@"Game Over!", @"Game Over");
            } else if (progressBar1.Value > 0.80 * progressBar1.Maximum) {
                pnlflash.BackColor = Color.DarkRed;
                pnlflash.Refresh();
            } else if (progressBar1.Value > 0.60 * progressBar1.Maximum && !timerFlash.Enabled) {
                //start the notification timer
                timerFlash.Start();
                pnlflash.BackColor = Color.OrangeRed;
                pnlflash.Refresh();
            }
        }

        protected void btnInstructions_Click(object sender, EventArgs e) { MessageBox.Show(Instructions(), "Game Instructions"); }

        protected virtual string Instructions() { return "Not Implemented"; }

        private void txtWord_Changed(object sender, EventArgs e) {
            timerpaintlocations_.Stop();
            resetDGValuesColorWhite();
            if (null == GridVals) throw new InvalidOperationException("Can not verify text yet, start a game first!");
            if (txtWords.Lines.Count() == 0 || txtWords.Lines[0].Length == 0) {
                dgvCheckWords.Visible = false;
                btnValidate.Enabled = false;
            } else {
                btnValidate.Enabled = true;
                dgvCheckWords.Visible = true;
            }
        }

        private void btnValidate_Click(object sender, EventArgs e){
            selectedword_ = -1;
            //validate each word/equation entered by the user
            GridVals.Validate(txtWords.Lines);
            //link the results of validation to the results grid
            dgvCheckWords.DataSource = GridVals.Verified;
            //setup the columns in the results grid appropriately depending on the game being played
            EditCols();
            //stop the highlighting timer and clear any highlighting
            timerpaintlocations_.Stop();
            resetDGValuesColorWhite();

        }

        protected virtual void EditCols() { return; }

        private void dgvCheckWords_CellClick(object sender, DataGridViewCellEventArgs e) {
            resetDGValuesColorWhite();
            //if the selected row is the one that was already selected stop highlighting anything
            if (e.RowIndex == selectedword_&&timerpaintlocations_.Enabled){
                timerpaintlocations_.Stop();
                return;
            }
            timerpaintlocations_.Stop();
            if (e.RowIndex > -1 && GridVals.Verified[e.RowIndex].InGrid) {
                //update the selected word and then start from the first copy of it
                selectedword_ = e.RowIndex;
                selectedlocation_ = 0;
                timerpaintlocations_.Start();
            }
        }

        private void resetDGValuesColorWhite() {
            for (var i = 0; i < GridVals.Rows; i++) {
                for (var j = 0; j < GridVals.Cols; j++) dgValues.Rows[i].Cells[j].Style.BackColor = Color.White;
            }
            dgValues.Refresh();
            dgValues.ClearSelection();
        }
        void TimerpaintlocationsTick(object sender, EventArgs e) {
            //get all the locations for each copy of the selected word in the grid
            List<List<int[]>> locations = GridVals.Verified[selectedword_].Locations;
            //stop it flashing if there's just 1 combination that works
            if(locations.Count>1)resetDGValuesColorWhite();
            //highlight each cell in the chosen copy of the word 
            foreach (int[] cells in locations[selectedlocation_]) {
                dgValues.Rows[cells[0]].Cells[cells[1]].Style.BackColor = Color.DarkViolet;
            }
            dgValues.Refresh();
            dgValues.ClearSelection();
            //increment selected copy so the next iteration will colour a different copy
            if (selectedlocation_ < locations.Count - 1) selectedlocation_++;
            else selectedlocation_ = 0;

        }
        protected void prepareToCheckWords() {
            timerpaintlocations_.Stop();
            txtWords.Enabled = true;
        }
        private void FrmBoggleParent_FormClosed(object sender, FormClosedEventArgs e) {
            timerpaintlocations_.Stop();
        }

        protected string verificationInstruction(){
            string res =  "\n\n The box at the top right of the screen can be used to enter the "+type_+"s you find. Clicking the " +
                   btnValidate.Text + " button will check whether those" +type_+ "s appear in the current game and also if they "+verification_+
                   ". The results will be displayed";
            res +=
                "in a table at the top of the screen. If you click on a cell in that table it will highlight each way you can make that "+type_+" in the grid if it's there.";
            return res;
        }
    }

}
