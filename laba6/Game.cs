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

        List<PictureBox> hand1PictureBox;
        List<PictureBox> hand2PictureBox;
        CardUI deckCard;

        static System.Windows.Forms.Timer gameTimer = new System.Windows.Forms.Timer();
        static bool exitFlag = false;
        int slowerSpeedInMs = 1700;
        int fasterSpeedInMs = 1000;

        public Game(Form1 mainForm, int difficulty)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.WindowState = FormWindowState.Maximized;
            this.FormClosing += new FormClosingEventHandler(Game_FormClosing);
            CardUI.unchosenBackColor = this.BackColor;
            this.lblGameOver.Text = "";

            this.gameAlgo = new GameAlgorithm(difficulty);

            AddPictureBoxToArray();
            InitializeCardsUI();
            LoadCards();
        }
        private void InintResults()
        {
            Results resultsForm = new Results(gameAlgo.Score1, gameAlgo.Score2, gameAlgo.RoundNumber-1);
            resultsForm.Show();
            this.Hide();
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
                player2.Hand[i].FaceUp();    //  FaceDown          
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
        private void RefreshScores()
        {
            this.lblNumberDeadBots.Text = Convert.ToString(gameAlgo.DeadBotNumber);
            this.lblPlayer1Score.Text = Convert.ToString(gameAlgo.Score1);
            this.lblPlayer2Score.Text = Convert.ToString(gameAlgo.Score2);
            this.lblRoundNumber.Text = Convert.ToString(gameAlgo.RoundNumber);
            if (gameAlgo.IsDeckEmpty())
                this.deckCard.SetEmpty();
        }
        
        private void btnPlayCards_Click(object sender, EventArgs e)
        {
            if (player1.ChosenArmourCardIndex != null && player1.ChosenWeaponCardIndex != null)
            {
                this.btnPlayCards.Enabled = false;
                if (player2.WeaponCard.IsEmpty)//deciding play or beat bot
                {
                    player1.PlayBot();
                    this.lblPlayersTurns.Text = "";
                    gameAlgo.AcceptMove(player1.ChosenWeaponCardIndex, player1.ChosenArmourCardIndex);
                    //
                    player1.UnchooseAllCards();
                    int? armourIndex, weaponIndex;
                    
                    if (gameAlgo.MakeMove(out weaponIndex, out armourIndex))
                    {
                        //a-i beats
                        player2.ChosenArmourCardIndex = armourIndex;
                        player2.ChosenWeaponCardIndex = weaponIndex;
                        SetTimer(fasterSpeedInMs);
                        player2.PlayBot();
                        //відбій
                        VisualizeCardsAfterBattle();
                        //a-i moves forward
                        gameAlgo.CreateBot();
                        gameAlgo.MakeMove(out weaponIndex, out armourIndex);
                        player2.ChosenArmourCardIndex = armourIndex;
                        player2.ChosenWeaponCardIndex = weaponIndex;
                        SetTimer(fasterSpeedInMs);
                        player2.PlayBot();
                        RefreshScores();
                    }
                    else
                    {                        
                        gameAlgo.NewRound();
                        NewRound();                       
                    }
                    this.btnPlayCards.Enabled = true;
                    this.lblPlayersTurns.Text = "Your turn!";
                   
                }
                else
                {
                    if(player1.BeatBot(player2.ArmourCard.GetCard))
                    {
                        gameAlgo.AcceptResponse(player1.ChosenWeaponCardIndex, player1.ChosenArmourCardIndex);
                        //відбій
                        VisualizeCardsAfterBattle();
                        RefreshScores();
                    }
                    else
                    {
                        
                    }
                    this.btnPlayCards.Enabled = true;
                }                
            }
            else
            {
                MessageBox.Show("You haven't chosen cards!");
            }
        }
        private void VisualizeCardsAfterBattle()
        {
            SetTimer(slowerSpeedInMs);
            ClearBattleField();
            SetTimer(slowerSpeedInMs);
            DealNewCards();
        }
        private void ClearBattleField()
        {
            player1.ClearBot();
            player2.ClearBot();
        }
        private void DealNewCards()
        {
            gameAlgo.DealCardsForPlayers();
            for(int i=0; i< player1.Hand.Count;i++)
            {
                if (player1.Hand[i].IsEmpty)
                {
                    player1.Hand[i].AddCard(gameAlgo.Hand1[i]);
                    player1.Hand[i].FaceUp();
                }

                if (player2.Hand[i].IsEmpty)
                {
                    player2.Hand[i].AddCard(gameAlgo.Hand2[i]);
                    player2.Hand[i].FaceUp();//FaceDown
                }
            }
            
        }
        private void RenewCardsForNewRound()
        {
            for(int i = 0; i < player1.Hand.Count; i++)
            {               
                player1.Hand[i].AddCard(gameAlgo.Hand1[i]);
                player1.Hand[i].FaceUp();
                
                player2.Hand[i].AddCard(gameAlgo.Hand2[i]);
                player2.Hand[i].FaceUp();//FaceDown                
            }            
        }
        private void NewRound()
        {
            RefreshScores();          
            SetTimer(fasterSpeedInMs);
            ClearBattleField();
            if (gameAlgo.Score1 >= GameAlgorithm.BOT_NUMBER_TO_WIN || gameAlgo.Score2 >= GameAlgorithm.BOT_NUMBER_TO_WIN)
            {
                this.lblGameOver.Text = "Game over!";
                this.lblGameOver.Font = new Font("Segoe Script", 36);
                SetTimer(slowerSpeedInMs+400);
                InintResults();
            }
            SetTimer(slowerSpeedInMs);
            RenewCardsForNewRound();
        }
        private void btnSkipMove_Click(object sender, EventArgs e)
        {
            player1.UnchooseAllCards();
            this.lblPlayersTurns.Text = "";
            gameAlgo.AcceptMove(player1.ChosenWeaponCardIndex, player1.ChosenArmourCardIndex);

            NewRound();

            int? armourIndex, weaponIndex;
            
            gameAlgo.CreateBot();
            gameAlgo.MakeMove(out weaponIndex, out armourIndex);
            player2.ChosenArmourCardIndex = armourIndex;
            player2.ChosenWeaponCardIndex = weaponIndex;
            SetTimer(fasterSpeedInMs);
            player2.PlayBot();
            this.btnPlayCards.Enabled = true;
            this.lblPlayersTurns.Text = "Your turn!";
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

        private void SetTimer(int ms)
        {
            /* Adds the event and the event handler for the method that will 
        process the timer event to the timer. */
            gameTimer.Tick += new EventHandler(TimerEventProcessor);
            gameTimer.Interval = ms; // Sets the timer interval to 1 seconds.
            gameTimer.Start();

            while (exitFlag == false)   // Runs the timer, and raises the event.
            {
                Application.DoEvents(); // Processes all the events in the queue.
            }
            exitFlag = false;
        }
        private static void TimerEventProcessor(Object myObject, EventArgs myEventArgs) // This is the method to run when the timer is raised.
        {
            gameTimer.Stop();
            // Stops the timer.
            exitFlag = true;
        }

    }
}
