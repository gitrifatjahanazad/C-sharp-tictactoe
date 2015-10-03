using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacTo
{
    public partial class GameBoard : Form
    {
        PlayWith symbol;
        bool turn; // true for p1 & false for p2
        int turn_count = 0;
        public GameBoard(PlayWith symbol)
        {
            InitializeComponent();
            this.symbol = symbol;
            label2.Text = symbol.P1symbol;
            label4.Text = symbol.P2symbol;
        }

        private void GameBoard_Load(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("First Player - 1 Turn.",
        "The Question",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Exclamation);

            if (result1 == DialogResult.Yes)
            {
                turn = true;
            }
            else
            {
                turn = false;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button B = (Button)sender;
            if (turn)
                B.Text = symbol.P1symbol;
            else
                B.Text = symbol.P2symbol;
            turn = !turn;
            B.Enabled = false;

            turn_count++;

            checkforwinner();
            
        }

        private void GameBoard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            panel2.Visible = true;
            buttonPlay.Enabled = false;
        }

        public void disableButton()
        {
            A1.Enabled = false;
            B1.Enabled = false;
            C1.Enabled = false;

            A2.Enabled = false;
            B2.Enabled = false;
            C2.Enabled = false;

            A3.Enabled = false;
            B3.Enabled = false;
            C3.Enabled = false;
        }

        private void checkforwinner()
        {
            bool winner = false;

            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                winner = true;

            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                winner = true;

            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                winner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                winner = true;

            if(winner)
            {
                disableButton();
                string win = "";
                if(!turn)
                {
                    win = "Player - 1";
                }
                else
                {
                    win = "Player - 2";
                }

                MessageBox.Show(win + " Win!", "WIN",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                if(turn_count == 9)
                {
                    MessageBox.Show("Match Draw", "Draw",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                }
            }
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            this.Hide();
            StartForm play = new StartForm();
            play.Show();
        }

        private void Button_Enter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(button.Enabled)
            {
                if (turn)
                {
                    button.Text = symbol.P1symbol;
                    button.BackColor = Color.LimeGreen;
                }
                else
                {
                    button.BackColor = Color.Red;
                    button.Text = symbol.P2symbol;
                }
            }
            
        }

        private void Button_Leave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Enabled)
            {
                button.Text = "";
                button.BackColor = SystemColors.Control;
            }
        }
    }
}
