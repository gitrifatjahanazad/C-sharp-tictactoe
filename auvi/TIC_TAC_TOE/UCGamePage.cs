using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIC_TAC_TOE
{
    public partial class UCGamePage : UserControl
    {
        bool turn = true;
        int turn_count = 0;

        public UCGamePage()
        {
            InitializeComponent();
        }

        private void btnClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";
            turn = !turn;
            b.Enabled = false;
            b.BackColor = Color.Pink;
            turn_count++;
            checkWinner();

        }
        private void checkWinner()
        {
            bool winner = false;
                //check Horizontal 
                if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                    winner = true;
                else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                    winner = true;
                else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                    winner = true;

                //check Vertical 
                else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                    winner = true;
                else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                    winner = true;
                else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                    winner = true;

                //diagonal Check 

                else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                    winner = true;
                else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                    winner = true;

                if (winner)
                {
                    disabledBtns();
                    string winner1 = "";
                    if (turn)
                        winner1 = "O";
                    else
                        winner1 = "X";
                    winnerTxt.Text = winner1 + "Wins Yaay";
                    winnerTxt.Show();
                }
                else
                {
                    if (turn_count == 9)
                    {
                        winnerTxt.Text = "Its Draw !";
                        winnerTxt.Show();
                    }
                }           
        }
        private void disabledBtns()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch 
            {
            }         
        }

        private void UCGamePage_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }
    }
}
