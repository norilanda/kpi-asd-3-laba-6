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
    public partial class ChooseDifficulty : Form
    {
        Form1 mainForm;
        public ChooseDifficulty(Form1 mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            this.Close();
        }

        private void btnEasy_Click(object sender, EventArgs e)
        {

        }

        private void btnMedium_Click(object sender, EventArgs e)
        {

        }

        private void btnHard_Click(object sender, EventArgs e)
        {

        }
    }
}
