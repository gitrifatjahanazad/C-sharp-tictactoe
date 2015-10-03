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
    public partial class StartForm : Form
    {
        PlayWith symbol;
        public StartForm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString() == comboBox2.SelectedItem.ToString())
            {
                MessageBox.Show("Both Player select same thing.", "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                symbol = new PlayWith();
                symbol.P1symbol = comboBox1.SelectedItem.ToString();
                symbol.P2symbol = comboBox2.SelectedItem.ToString();
                this.Hide();
                GameBoard game = new GameBoard(symbol);
                game.Show();
            }
        }

        private void StartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
