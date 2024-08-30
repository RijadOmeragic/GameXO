using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameXO
{
    public partial class frmXO : Form
    {
       
        public string Player1 { get; set; }
        public string Player2 { get; set; }

        public int counter { get; set; } = 0;
        public int drawCounter { get; set; } = 0;

        int player1MoveCount = 0;
        int player2MoveCount = 0;

        int player1WinCount = 0;
        int player2WinCount = 0;

        string winnerName;

        private static frmXO instance;  



        public static frmXO GetInstance(string player1, string player2)  
        {
            if (instance == null || instance.IsDisposed)
                instance = new frmXO();

            instance.Player1 = player1;
            instance.Player2 = player2;    

           return instance;
        }

       
        private frmXO()
        {
            InitializeComponent();
        }


        private void frmXO_Load(object sender, EventArgs e)
        {
            DisplayNextPlayer();

            lblPlayer1WinCount.Text = $"{Player1}: {player1WinCount}";
            lblPlayer2WinCount.Text = $"{Player2}: {player2WinCount}";
         
        }

        private void DisplayNextPlayer()
        {
            lblNextPlayer.Text = counter % 2 == 0 ? "Player " + Player1 + " to move" : "Player " + Player2 + " to move";
        }

        private void MakeMove(object sender)
        {
          
            if (sender is Button)
            {
                var button = sender as Button;

                if (button.Text == "")
                {
                    if (counter % 2 == 0)
                    {
                        button.Text = "X";
                        player1MoveCount++;
                    }
                    else
                    {
                        button.Text = "0";
                        player2MoveCount++;
                    }

                    counter++;
                    drawCounter++;
                    DisplayNextPlayer();

                    if (EndGame())
                    {
                        SetButtonStatus(new GameSettings() { Status = false, ResetColor = false, ResetText = false});
                        DisplayWinner();
                    }
                    else if(drawCounter == 9)
                        MessageBox.Show("The game result is a draw.", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

      

        private void DisplayWinner()
        {
           
            if (player1MoveCount > player2MoveCount)
            {
                winnerName = Player1;
                ++player1WinCount;
            }
            else
            {
                winnerName = Player2;
                ++player2WinCount;
            }

            MessageBox.Show($"{winnerName} is the winner, congratulations!", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblPlayer1WinCount.Text = $"{Player1}: {player1WinCount}";
            lblPlayer2WinCount.Text = $"{Player2}: {player2WinCount}";

           
        }

        private void SetButtonStatus(GameSettings gameSettings)
        {

            foreach (var control in this.Controls)
            {
                if (control is Button)
                {
                    var button = control as Button;

                    if (button != btnNewGame)
                    {
                        button.Enabled = gameSettings.Status;
                        button.Text = gameSettings.ResetText ? "" : button.Text;

                        if (gameSettings.ResetText)
                        {
                            button.BackColor = DefaultBackColor;   
                         
                        }
                    }
                }
            }
            DisplayNextPlayer();
        }

       

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            drawCounter = 0;
            player1MoveCount = 0;
            player2MoveCount = 0;

            SetButtonStatus(new GameSettings() { Status = true, ResetColor = true, ResetText = true });

        }

        private bool EndGame()
        {
            return CheckRows() || CheckColumns() || CheckDiagonals();
        }

        private bool CheckDiagonals()
        {
            return CheckWin(button1, button5, button9) ||
                   CheckWin(button3, button5, button7);
        }

        private bool CheckColumns()
        {
            return CheckWin(button1, button4, button7) ||
                   CheckWin(button2, button5, button8) ||
                   CheckWin(button3, button6, button9);
        }

        private bool CheckRows()
        {
            return CheckWin(button1, button2, button3) ||
                   CheckWin(button4, button5, button6) ||
                   CheckWin(button7, button8, button9);
        }

        private bool CheckWin(Button button1, Button button2, Button button3)
        {
            if (button1.Text != "" && button1.Text == button2.Text && button1.Text == button3.Text)
            {
                button1.BackColor = button2.BackColor = button3.BackColor = Color.Green;
                return true;
            }

            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MakeMove(sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MakeMove(sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MakeMove(sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MakeMove(sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MakeMove(sender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MakeMove(sender);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MakeMove(sender);
        }


        private void button8_Click(object sender, EventArgs e)
        {
            MakeMove(sender);
        }


        private void button9_Click(object sender, EventArgs e)
        {
            MakeMove(sender);
        }

       
    }

}
