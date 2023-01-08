using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba6
{
    public partial class Results : Form
    {
        Form1 mainForm;
        Game gameForm;
        public Results(Form1 mainForm, Game gameForm, int score1, int score2, int RoundNumber)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.gameForm = gameForm;
            this.FormClosing += new FormClosingEventHandler(Results_FormClosing);
            DisplayResults(score1, score2, RoundNumber);
        }
        void Results_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        void DisplayResults(int score1, int score2, int RoundNumber)
        {
            if (score1 > score2)
                this.lblPlayerWins.Text = "Player 1 wins!";
            else
                this.lblPlayerWins.Text = "Player 2 wins!";
            this.lblScore1.Text = Convert.ToString(score1);
            this.lblScore2.Text = Convert.ToString(score2);
            this.lblRoundNumber.Text = Convert.ToString(RoundNumber);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            //mainForm.Show();
            //this.Hide();
            this.Close();

        }
    }
}
