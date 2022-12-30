using System.Windows.Forms;

namespace laba6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            ChooseDifficulty chooseDifficultyForm = new ChooseDifficulty(this);
            chooseDifficultyForm.Location = this.Location;
            chooseDifficultyForm.StartPosition = FormStartPosition.Manual;
            chooseDifficultyForm.FormClosing += delegate { this.Show(); };//this.Show();
            chooseDifficultyForm.Show();
            this.Hide();
            //this.Close();
        }

        private void btnQuite_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}