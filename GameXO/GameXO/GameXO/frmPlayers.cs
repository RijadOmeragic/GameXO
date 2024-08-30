using System;
using System.Windows.Forms;

namespace GameXO
{
    public partial class frmPlayers : Form
    {
        public frmPlayers()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var player1 = txtPlayer1.Text;
            var player2 = txtPlayer2.Text;

            if (!Validator.ValidateControl(txtPlayer1,errorProvider1, "You must enter the name of the first player.") || !Validator.ValidateControl(txtPlayer2, errorProvider1, "You must enter the name of the second player."))
            {
                return;
            }

            frmXO.GetInstance(player1,player2).Show();

        }
    }
}
