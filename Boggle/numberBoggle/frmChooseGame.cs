using System;
using System.Windows.Forms;

namespace Boggle{
    public partial class FrmChooseGame : Form{
        public FrmChooseGame() { InitializeComponent(); }

        private void btnNumber_Click(object sender, EventArgs e){
            Form number = new FrmNumberBoggle();
            number.Show();
        }

        private void btnBoggle_Click(object sender, EventArgs e){
            Form word = new FrmWordBoggle();
            word.Show();
        }
    }
}