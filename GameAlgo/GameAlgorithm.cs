using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAlgo
{
    public class GameAlgorithm
    {
        public const int CARDS_IN_HAND = 10;
        public const int BOT_NUMBER_TO_WIN = 5;
        public enum Mode
        {
            Easy,
            Medium,
            Difficult
        }
        Mode _gameMode;
        List<Card> deck;
        Player player1;
        Player player2;//ШІ
        int _deadBotNumber = 0;
        int _roundNumber = 1;

        public List<Card?> Hand1 => player1.Hand;
        public List<Card?> Hand2 => player2.Hand;
        public int Score1 => player1.Score;
        public int Score2 => player2.Score;
        public bool IsDeckEmpty() => deck.Count == 0;
        public int RoundNumber
        {
            get => _roundNumber;
            //set => _roundNumber = value;
        }
        public int DeadBotNumber
        {
            get => _deadBotNumber;
           // set => _deadBotNumber = value;
        }

        public GameAlgorithm(int mode)
        {
            _gameMode = (Mode)mode;
            InitiateGame();
        }
        public void NewRound()
        {
            _roundNumber++;
            _deadBotNumber= 0;
            player1.UnchooseAllCards();
            player2.UnchooseAllCards();

            deck = Card.GenerateDeck();
            player1.Hand = HandCards();
            player2.Hand = HandCards();
            //DealCardsForPlayers();
        }
        private void InitiateGame()
        {
            deck = Card.GenerateDeck();
            player1 = new Player(HandCards());
            player2 = new Player(HandCards());            
        }
        private List<Card?> HandCards()
        {
            List<Card?> hand = new List<Card?>();
            Random rnd = new Random();
            int index;
            for (int i=0; i< CARDS_IN_HAND; i++)
            {
                index = rnd.Next(0, deck.Count);
                hand.Add(deck[index]);
                deck.RemoveAt(index);
            }
            return hand;
        }
        public void AcceptMove(int? weaponIndex, int? armourIndex)
        {
            player1.BotWeaponIndex = weaponIndex;
            player1.BotArmourIndex = armourIndex;
            if (weaponIndex == null)//if player1 skips move
            {
                SkipMove(1);
                NewRound();
            }                
            else
                Response(player1.BotArmour);
        }
        public void AcceptResponse(int? weaponIndex, int? armourIndex)
        {
            player1.BotWeaponIndex = weaponIndex;
            player1.BotArmourIndex = armourIndex;
            if (weaponIndex != null)
            {
                _deadBotNumber++;
            }
            player1.DeleteCardsAfterMove();
        }
        public bool MakeMove(out int? weaponIndex, out int? armourIndex)
        {
            weaponIndex = player2.BotWeaponIndex;
            armourIndex = player2.BotArmourIndex;
            if (weaponIndex == null)//check if player2 skips
                return false;
            player2.DeleteCardsAfterMove();
            return true;
        }
        private void SkipMove(int playerNumber)
        {
            if (playerNumber == 2)
                player1.Score += _deadBotNumber;
            else
                player2.Score += _deadBotNumber;
            _deadBotNumber = 0;
        }
        private void Response(Card cardToBeat)
        {
            switch (_gameMode)
            {
                case Mode.Easy:
                    {
                        player2.BotWeaponIndex = player2.EasyBotWeaponForBeating(cardToBeat);                        
                        if (player2.BotWeaponIndex != null)//if has a weapon to beat the enemy
                        {
                            player2.BotArmourIndex = player2.EasyBotArmour();
                            if (player2.BotArmourIndex == null)
                            {
                                player2.UnchooseAllCards();
                                SkipMove(2);
                                NewRound();
                            }
                            else {
                                _deadBotNumber++;
                            }
                        }
                        else {
                            SkipMove(2);
                            NewRound();
                        }
                        break;
                    }
                case Mode.Medium:
                    {
                        player2.BotWeaponIndex = player2.FindMinBlackCard(cardToBeat);
                        if (player2.BotWeaponIndex != null)//if has a weapon to beat the enemy
                        {
                            player2.BotArmourIndex = player2.FindMinRedCard();
                            if (player2.BotArmourIndex == null)
                            {
                                player2.UnchooseAllCards();
                                SkipMove(2);
                                NewRound();
                            }
                            else
                            {
                                _deadBotNumber++;
                            }
                        }
                        else
                        {
                            SkipMove(2);
                            NewRound();
                        }
                        break;
                    }
                case Mode.Difficult:
                    {
                        break;
                    }
            }
            player1.DeleteCardsAfterMove();
        }
        public void CreateBot()
        {
            switch (_gameMode)
            {
                case Mode.Easy:
                    {
                        player2.BotWeaponIndex = player2.EasyBotWeaponForCreation();
                        if (player2.BotWeaponIndex != null)//if there is a black card
                        {
                            player2.BotArmourIndex = player2.EasyBotArmour();
                            if (player2.BotArmourIndex == null)
                                player2.UnchooseAllCards();
                        }
                        break;
                    }
                case Mode.Medium:
                    {
                        player2.BotWeaponIndex = player2.FindMinBlackCard(null);
                        if (player2.BotWeaponIndex != null)//if there is a black card
                        {
                            player2.BotArmourIndex = player2.MediumBotArmour(this._deadBotNumber);
                            if (player2.BotArmourIndex == null)
                                player2.UnchooseAllCards();
                        }
                        break;
                    }
                case Mode.Difficult:
                    {
                        break;
                    }
            }
        }
     
        public void DealCardsForPlayers()
        {
            player1.DealCards(deck);
            player2.DealCards(deck);
        }
    }
}
