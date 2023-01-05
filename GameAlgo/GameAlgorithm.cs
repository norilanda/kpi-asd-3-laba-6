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

        public List<Card?> Hand1 => player1.Hand;
        public List<Card?> Hand2 => player2.Hand;

        public GameAlgorithm(int mode)
        {
            _gameMode = (Mode)mode;
            InitiateGame();
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
          
            Response(player1.BotArmour);
        }
        public bool MakeMove(out int? weaponIndex, out int? armourIndex)
        {
            weaponIndex = player2.BotWeaponIndex;
            armourIndex = player2.BotArmourIndex;
            if (weaponIndex == null)//check if skip
                return false;
            player2.DeleteCardsAfterMove();
            return true;
        }
        private void Response(Card cardToBeat)
        {
            switch (_gameMode)
            {
                case Mode.Easy:
                    {
                        player2.BotWeaponIndex = player2.EasyBotWeaponForBeating(cardToBeat);                        
                        if (player2.BotWeaponIndex != null)
                        {
                            player2.BotArmourIndex = player2.EasyBotArmour();
                            if (player2.BotArmourIndex == null)
                                player2.BotWeaponIndex = null;
                        }
                        break;
                    }
                case Mode.Medium:
                    {
                        break;
                    }
                case Mode.Difficult:
                    {
                        break;
                    }
            }
            player1.DeleteCardsAfterMove();
        }
     

    }
}
