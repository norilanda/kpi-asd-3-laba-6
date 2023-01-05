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
        PlayerUI player1;
        PlayerUI player2;

        //List<CardUI> hand1;
        //List<CardUI> hand2;
        List<PictureBox> hand1PictureBox;
        List<PictureBox> hand2PictureBox;
        CardUI deckCard;

        //CardUI player1WeaponCardUI;
        //CardUI player1ArmourCardUI;
        //CardUI player2WeaponCardUI;
        //CardUI player2ArmourCardUI;

        //int? chosenWeaponCardIndex;
        //int? chosenArmourCardIndex;

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
            for(int i=0;i< GameAlgorithm.CARDS_IN_HAND; i++)
            {
                player1.Hand[i].FaceUp();
                player2.Hand[i].FaceDown();                
            }
        }
        private void InitializeCardsUI()
        {
            List<CardUI> hand1 = new List<CardUI>();
            List<CardUI> hand2 = new List<CardUI>();
            for (int i=0; i< GameAlgorithm.CARDS_IN_HAND; i++)
            {
                hand1.Add(new CardUI(gameAlgo.Hand1[i], hand1PictureBox[i]));
                hand2.Add(new CardUI(gameAlgo.Hand2[i], hand2PictureBox[i]));
            }
            player1 = new PlayerUI(hand1);
            player2 = new PlayerUI(hand2);

            player1.WeaponCard = new CardUI(null, this.player1_weapon);
            player1.ArmourCard = new CardUI(null, this.player1_armour);

            player2.WeaponCard = new CardUI(null, this.player2_weapon);
            player2.ArmourCard = new CardUI(null, this.player2_armour);
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
        
        private void btnPlayCards_Click(object sender, EventArgs e)
        {
            if (player1.ChosenArmourCardIndex != null && player1.ChosenWeaponCardIndex != null)
            {
                this.btnPlayCards.Enabled = false;
                if (player2.WeaponCard.IsEmpty)
                {
                    player1.PlayBot();
                    gameAlgo.AcceptMove(player1.ChosenWeaponCardIndex, player1.ChosenArmourCardIndex);
                    //
                    player1.ChosenWeaponCardIndex = null;
                    player1.ChosenArmourCardIndex = null;
                    int? armourIndex, weaponIndex;
                    
                    if (gameAlgo.MakeMove(out weaponIndex, out armourIndex))
                    {
                        player2.ChosenArmourCardIndex = armourIndex;
                        player2.ChosenWeaponCardIndex = weaponIndex;
                        Task.Delay(1000);
                        player2.PlayBot();
                    }
                    else
                    {
                        /////
                    }
                }
                else
                {
                    if(player1.BeatBot(player2.ArmourCard.GetCard))
                    {
                        /////////
                    }
                    else
                    {
                        this.btnPlayCards.Enabled = true;
                    }
                }
                
            }
            else
            {
                MessageBox.Show("You haven't chosen cards!");
            }
        }
        private void hand1_card1_Click(object sender, EventArgs e)
        {
            player1.ChooseCard(0);
        }
        private void hand1_card2_Click(object sender, EventArgs e)
        {
            player1.ChooseCard(1);
        }
        private void hand1_card3_Click(object sender, EventArgs e)
        {
            player1.ChooseCard(2);
        }
        private void hand1_card4_Click(object sender, EventArgs e)
        {
            player1.ChooseCard(3);
        }
        private void hand1_card5_Click(object sender, EventArgs e)
        {
            player1.ChooseCard(4);
        }
        private void hand1_card6_Click(object sender, EventArgs e)
        {
           player1.ChooseCard(5);
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            player1.ChooseCard(6);
        }
        private void hand1_card8_Click(object sender, EventArgs e)
        {
            player1.ChooseCard(7);
        }
        private void hand1_card9_Click(object sender, EventArgs e)
        {
            player1.ChooseCard(8);
        }
        private void hand1_card10_Click(object sender, EventArgs e)
        {
            player1.ChooseCard(9);
        }

        private void hand2_card3_Click(object sender, EventArgs e)
        {
            
        }

    
    }
}
