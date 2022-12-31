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
using CardsUI;

namespace laba6
{
    public partial class Game : Form
    {
        Form1 mainForm;
        GameAlgorithm gameAlgo;
        List<CardUI> hand1;
        List<CardUI> hand2;
        List<PictureBox> hand1PictureBox;
        List<PictureBox> hand2PictureBox;
        public Game(Form1 mainForm, int difficulty)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.WindowState = FormWindowState.Maximized;
            this.FormClosing += new FormClosingEventHandler(Game_FormClosing);

            this.gameAlgo = new GameAlgorithm(difficulty);

            InitializeCardsUI();
            AddPictureBoxToArray();
            LoadCards();
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

        private void LoadCards()
        {
            this.deck.Load(".\\deck\\shirt.png");
            for(int i=0;i< GameAlgorithm.CARDS_IN_HAND; i++)
            {
                hand1PictureBox[i].Load(hand1[i].FileName);
                hand2PictureBox[i].Load(CardUI.FileNameFaceDown);//hand2[i].FileName
            }
        }
        private void InitializeCardsUI()
        {
            hand1 = new List<CardUI>();
            hand2 = new List<CardUI>();
            for (int i=0; i< GameAlgorithm.CARDS_IN_HAND; i++)
            {
                hand1.Add(new CardUI(gameAlgo.Hand1[i]));
                hand2.Add(new CardUI(gameAlgo.Hand2[i]));
            }
        }
        private void AddPictureBoxToArray()
        {
            //const int CARDS_IN_HAND = 10;
            hand1PictureBox = new List<PictureBox>();
            hand1PictureBox.Add(hand1_card1);
            hand1PictureBox.Add(hand1_card2);
            hand1PictureBox.Add(hand1_card3);
            hand1PictureBox.Add(hand1_card4);
            hand1PictureBox.Add(hand1_card5);
            hand1PictureBox.Add(hand1_card6);
            hand1PictureBox.Add(hand1_card7);
            hand1PictureBox.Add(hand1_card8);
            hand1PictureBox.Add(hand1_card9);
            hand1PictureBox.Add(hand1_card10);

            hand2PictureBox= new List<PictureBox>();
            hand2PictureBox.Add(hand2_card1);
            hand2PictureBox.Add(hand2_card2);
            hand2PictureBox.Add(hand2_card3);
            hand2PictureBox.Add(hand2_card4);
            hand2PictureBox.Add(hand2_card5);
            hand2PictureBox.Add(hand2_card6);
            hand2PictureBox.Add(hand2_card7);
            hand2PictureBox.Add(hand2_card8);
            hand2PictureBox.Add(hand2_card9);
            hand2PictureBox.Add(hand2_card10);
        }
        private void PlayBot(int handNum, int WeaponIndex, int ArmourIndex)
        {
            switch (handNum)
            {
                case 1:
                    {
                        hand1PictureBox[WeaponIndex].Image = null;
                        //----------------------
                        break;
                    }
                case 2:
                {
                    //------------------------------
                    break;
                }
            }
        }
        private void ChooseCard()
        {

        }
        private void hand1_card8_Click(object sender, EventArgs e)
        {

        }






        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
    }
}
