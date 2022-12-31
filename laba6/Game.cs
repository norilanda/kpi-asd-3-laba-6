using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameAlgo;

namespace laba6
{
    public partial class Game : Form
    {
        Form1 mainForm;
        public Game(Form1 mainForm, int difficulty)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.WindowState = FormWindowState.Maximized;
            this.FormClosing += new FormClosingEventHandler(Game_FormClosing);

            GameAlgorithm gameAlgo = new GameAlgorithm(difficulty);
        }
        void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            this.Close();
        }

    }
}
