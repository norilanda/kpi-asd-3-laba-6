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
        List<Card> _hand1;
        List<Card> _hand2;

        public List<Card> Hand1 => _hand1;
        public List<Card> Hand2 => _hand2;

        public GameAlgorithm(int mode)
        {
            _gameMode = (Mode)mode;
            InitiateGame();
        }
        private void InitiateGame()
        {
            deck = Card.GenerateDeck();
            _hand1 = HandCards();
            _hand2 = HandCards();
        }
        private List<Card> HandCards()
        {
            List<Card> hand = new List<Card>();
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
    }
}
