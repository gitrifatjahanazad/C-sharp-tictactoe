using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private bool turn = true; // true=X turn, false=O turn
        private int turnCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender; // casting sender as a button type and keeping the value in button
            if (turn)
                button.Text = "X";
            else
                button.Text = "O";

            turn = !turn; // changing turns
            button.Enabled = false; // to prevent from changing values in one cell
            turnCount++;
            checkForWinner();
        }

        private void checkForWinner()
        {
            bool isWinner = false;

            // horizontal
            if ((button1.Text == button2.Text) && (button2.Text == button3.Text) && (!button1.Enabled))
                isWinner = true;
            else if ((button4.Text == button5.Text) && (button5.Text == button6.Text) && (!button4.Enabled))
                isWinner = true;
            else if ((button7.Text == button8.Text) && (button8.Text == button9.Text) && (!button7.Enabled))
                isWinner = true;

            // Vertical
            else if ((button1.Text == button4.Text) && (button4.Text == button7.Text) && (!button1.Enabled))
                isWinner = true;
            else if ((button2.Text == button5.Text) && (button5.Text == button8.Text) && (!button2.Enabled))
                isWinner = true;
            else if ((button3.Text == button6.Text) && (button6.Text == button9.Text) && (!button3.Enabled))
                isWinner = true;

            // Diagonal
            else if ((button1.Text == button5.Text) && (button5.Text == button9.Text) && (!button1.Enabled))
                isWinner = true;
            else if ((button3.Text == button5.Text) && (button5.Text == button7.Text) && (!button3.Enabled))
                isWinner = true;

            if (isWinner)
            {
                disableAllButtons(); // disabling all buttons otherwise button results can be changed anytime

                string winner;
                if (turn)
                    winner = "O";
                else
                    winner = "X";

                MessageBox.Show(winner + " wins!");
            }
            else
            {
                if (turnCount == 9) // since there are nine cells
                    MessageBox.Show("Draw!");
            }
        }

        private void disableAllButtons()
        {
            try
            {
                foreach (Control con in Controls)
                {
                    Button button = (Button)con; // casting each control to a button
                    button.Enabled = false;
                }
            }
            catch { }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turnCount = 0;

            try
            {
                foreach (Control comp in Controls) 
                {
                    Button button = (Button)comp; // Enabling the buttons again and clearing texts
                    button.Enabled = true;
                    button.Text = "";
                }
            }
            catch { }
        }

    }
}
