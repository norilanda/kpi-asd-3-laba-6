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
        GameAlgorithm gameAlgo;
        List<CardUI> hand1;
        List<CardUI> hand2;
        List<PictureBox> hand1PictureBox;
        List<PictureBox> hand2PictureBox;
        CardUI deckCard;

        CardUI player1WeaponCardUI;
        CardUI player1ArmourCardUI;
        CardUI player2WeaponCardUI;
        CardUI player2ArmourCardUI;

        int? chosenWeaponCardIndex;
        int? chosenArmourCardIndex;

        public Game(Form1 mainForm, int difficulty)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.WindowState = FormWindowState.Maximized;
            this.FormClosing += new FormClosingEventHandler(Game_FormClosing);
            CardUI.unchosenBackColor = this.BackColor;

            this.gameAlgo = new GameAlgorithm(difficulty);

            AddPictureBoxToArray();
            InitializeCardsUI();
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
            deckCard = new CardUI(null, this.deck);
            deckCard.FaceDown();
            //this.deck.Load(".\\deck\\shirt.png");
            for(int i=0;i< GameAlgorithm.CARDS_IN_HAND; i++)
            {
                hand1[i].FaceUp();
                hand2[i].FaceDown();                
            }
        }
        private void InitializeCardsUI()
        {
            hand1 = new List<CardUI>();
            hand2 = new List<CardUI>();
            for (int i=0; i< GameAlgorithm.CARDS_IN_HAND; i++)
            {
                hand1.Add(new CardUI(gameAlgo.Hand1[i], hand1PictureBox[i]));
                hand2.Add(new CardUI(gameAlgo.Hand2[i], hand2PictureBox[i]));
            }
            player1WeaponCardUI = new CardUI(null, this.player1_weapon);
            player1ArmourCardUI = new CardUI(null, this.player1_armour);

            player2WeaponCardUI = new CardUI(null, this.player2_weapon);
            player2ArmourCardUI = new CardUI(null, this.player2_armour);
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
                        hand1[WeaponIndex].MoveTo(player1WeaponCardUI);
                        hand1[ArmourIndex].MoveTo(player1ArmourCardUI);
                        chosenWeaponCardIndex = null;
                        chosenArmourCardIndex = null;                        
                        //----------------------
                        break;
                    }
                case 2:
                {
                        hand2[WeaponIndex].MoveTo(player2WeaponCardUI);
                        hand2[ArmourIndex].MoveTo(player2ArmourCardUI);
                        //------------------------------
                        break;
                }
            }
        }
        private void ChooseCard(int cardIndex)
        {
            if (hand1[cardIndex].IsEmpty)
                return;
            if (hand1[cardIndex].GetColor == CardUI.SuitColor.black)
            {
                if (chosenWeaponCardIndex == cardIndex)
                {
                    chosenWeaponCardIndex = null;
                    hand1[cardIndex].MarkUnchosen();
                }
                else
                {
                    if (chosenWeaponCardIndex != null)
                        hand1[(int)chosenWeaponCardIndex].MarkUnchosen();
                    chosenWeaponCardIndex = cardIndex;
                    hand1[cardIndex].MarkChosen();
                }
            }
            else if (hand1[cardIndex].GetColor == CardUI.SuitColor.red)
            {
                if (chosenArmourCardIndex == cardIndex)
                {
                    chosenArmourCardIndex = null;
                    hand1[cardIndex].MarkUnchosen();
                }
                else
                {
                    if (chosenArmourCardIndex != null)
                        hand1[(int)chosenArmourCardIndex].MarkUnchosen();
                    chosenArmourCardIndex = cardIndex;
                    hand1[cardIndex].MarkChosen();
                }
            }

        }
        private void hand1_card1_Click(object sender, EventArgs e)
        {
            ChooseCard(0);
        }
        private void hand1_card2_Click(object sender, EventArgs e)
        {
            ChooseCard(1);
        }
        private void hand1_card3_Click(object sender, EventArgs e)
        {
            ChooseCard(2);
        }
        private void hand1_card4_Click(object sender, EventArgs e)
        {
            ChooseCard(3);
        }
        private void hand1_card5_Click(object sender, EventArgs e)
        {
            ChooseCard(4);
        }
        private void hand1_card6_Click(object sender, EventArgs e)
        {
            ChooseCard(5);
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            ChooseCard(6);
        }
        private void hand1_card8_Click(object sender, EventArgs e)
        {
            ChooseCard(7);
        }
        private void hand1_card9_Click(object sender, EventArgs e)
        {
            ChooseCard(8);
        }
        private void hand1_card10_Click(object sender, EventArgs e)
        {
            ChooseCard(9);
        }

        private void hand2_card3_Click(object sender, EventArgs e)
        {
            
        }

        private void btnPlayCards_Click(object sender, EventArgs e)
        {
            if(chosenArmourCardIndex != null && chosenWeaponCardIndex != null)
            {
                PlayBot(1, (int)chosenWeaponCardIndex, (int)chosenArmourCardIndex);
                this.btnPlayCards.Enabled = false;
            }
            else
            {
                MessageBox.Show("You haven't chosen caards!");
            }
        }
    }
}
