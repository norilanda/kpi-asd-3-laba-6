using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAlgo
{
    public class Card
    {
        public enum Rank
        {
            r2, r3, r4, r5, r6, r7, r8, r9, r10,
            J, Q, K, Ace,
            Joker
        }
        public enum Suit
        {
            clubs,
            diamonds,
            hearts,
            spades
        }
        Rank _cardRank;
        Suit _cardSuit;
        public Rank CardRank => _cardRank;
        public Suit CardSuit => _cardSuit;
        public Card(Suit s, Rank r)
        {
            _cardSuit = s;
            _cardRank = r;             
        }
        public static List<Card> GenerateDeck()
        {
            const int RANK_NUM = 12;
            const int SUIT_NUM = 4;
            List<Card> deck = new List<Card>();
            for (int suit=0; suit<SUIT_NUM; suit++)
            {
                for (int rank = 0; rank < RANK_NUM; rank++)
                    deck.Add(new Card((Suit)suit, (Rank)rank));
            }
            deck.Add(new Card(Suit.spades, Rank.Joker));
            deck.Add(new Card(Suit.clubs, Rank.Joker));
            return deck;
        }
    }
    
}
