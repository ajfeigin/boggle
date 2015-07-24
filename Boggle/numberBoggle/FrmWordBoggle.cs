using System;

namespace Boggle {
    public partial class FrmWordBoggle : FormBoggleParent {


        public FrmWordBoggle() {
            InitializeComponent();
            //make sure there's a gridvals setup
            GridVals = new WordBoggleGridVals(true);
            //disable entry of words to review until there is a populated grid
            type_ = "word";
            verification_ = "are dictionary words";
        }

        private void newBigGame_Click(object sender, EventArgs e) {
            GenBoggle(true);

        }
        private void newRegularGame_Click(object sender, EventArgs e) {
            GenBoggle(false);
        }

        private void GenBoggle(bool isbig) {
            //setup the grid value class with the one for word boggle and tell it whether the game is big (5x5) or regular(4x4)
            GridVals = new WordBoggleGridVals(isbig);
            SetupGrid();
            prepareToCheckWords();
        }

        protected override string Instructions() {
            string res = "Create words using the letters in the grid that result. Words must have at least 3 letters(some people require at least 4 letters).\n";
            res += "Each letter used must be touching (diagonally is fine!) the letter used after it in the word.";
            res +=
                "Get 1 point for each 3 or 4 letter word that no one else found, 2 points for 5 letter words, 3 points for 6, 5 points for 7 and 11 points for 8+ letter words.\n";
            res += verificationInstruction();
            return res;
        }

        protected override void EditCols(){
                if (dgvCheckWords != null) dgvCheckWords.Columns["MatchesTarget"].HeaderText= "In Dictionary";
        }
    }
}
