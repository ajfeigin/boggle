using System;
using System.Drawing;

namespace Boggle{
    public partial class FrmNumberBoggle : FormBoggleParent{
        private const int DEFAULTROWSCOLS = 4;
        
        public FrmNumberBoggle(){
            InitializeComponent();
            //hide the target groupbox until it's needed
            gbTarget.Visible = false;

            GridVals = new NumberBoggleGridVals();
            //set the number of  columns & rows displayed to default
            numudCols.Value = GridVals.Cols = DEFAULTROWSCOLS;
            numudRows.Value= GridVals.Rows=DEFAULTROWSCOLS;
            numudRows.ValueChanged += numupRows_TextChanged;
            numudCols.TextChanged += numudCols_TextChanged;
            btnValidate.Text = @"Check answers";
            type_ = "equation";
            verification_ = "equal the target";

        }

        //keep UI #cols and code #cols in sync
        private void numudCols_TextChanged(object sender, EventArgs e){GridVals.Cols = (int)numudCols.Value;}
        //keep UI #rows and code #rows in sync
        private void numupRows_TextChanged(object sender, EventArgs e){GridVals.Rows= (int)numudRows.Value;}

        private void new2digNums_Click(object sender, EventArgs e){
            newGame(2);
        }
        private void new3digNums_Click(object sender, EventArgs e) {
            newGame(3);
        }
        private void newGame(int numdigs){
            SetupGrid();
            //show and calculate the target
            gbTarget.Visible = true;
            lblTarget.Text = ((NumberBoggleGridVals)GridVals).GetTarget(numdigs);
            lblTarget.BackColor = Color.Orange;
            prepareToCheckWords();
        }

        protected override string Instructions() { 
            string res = "Create sums using the values in the grid that result in the target (the target appears at the top of the screen during the game).\n";
            res += "Numbers used must be touching (diagonally is fine!).";
            res +=
                "Use addition, subtraction, multiplication, division and brackets to combine the numbers to equal the target.\n";
            res += "For more options allow the use of additional operators and functions.\n";
            res += verificationInstruction();
            return res;
        }

        }
    }