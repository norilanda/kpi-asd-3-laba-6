using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAlgo
{
    public class Player
    {
        List<Card?> _hand;
        int? _botWeaponIndex;
        int? _botArmourIndex;
        public List<Card?> Hand
        {
            get { return _hand; }
            set { _hand = value; }
        }
        public int? BotWeaponIndex
        {
            get { return _botWeaponIndex; }
            set { _botWeaponIndex = value; }
        }
        public int? BotArmourIndex
        {
            get { return _botArmourIndex; }
            set { _botArmourIndex = value;}
        }
        public Player(List<Card?> hand)
        {
            this._hand = hand;
        }
        public int? FindMinRedCard()
        {
            int? minCardIndex = null;
            for (int i = 0; i < _hand.Count; i++)
            {
                if (_hand[i] == null)
                    continue;               
                if (_hand[i].CardSuit == Card.Suit.diamonds || _hand[i].CardSuit == Card.Suit.hearts)
                {
                    if (minCardIndex == null || minCardIndex > (int)_hand[i].CardRank)
                        minCardIndex = i;
                }
            }
            return minCardIndex;
        }
        public int? FindMinBlackCard()
        {
            int? minCardIndex = null;
            for (int i = 0; i < _hand.Count; i++)
            {
                if (_hand[i] == null)
                    continue;
                if (_hand[i].CardSuit == Card.Suit.clubs || _hand[i].CardSuit == Card.Suit.spades)
                {
                    if (minCardIndex == null || minCardIndex > (int)_hand[i].CardRank)
                        minCardIndex = i;
                }                
            }
            return minCardIndex;
        }
        public int? FindMaxRedCard()
        {
            int? maxCardIndex = null;
            for (int i = 0; i < _hand.Count; i++)
            {
                if (_hand[i] == null)
                    continue;
                if (_hand[i].CardSuit == Card.Suit.diamonds || _hand[i].CardSuit == Card.Suit.hearts)
                {
                    if (maxCardIndex == null || maxCardIndex < (int)_hand[i].CardRank)
                        maxCardIndex = i;
                }
            }
            return maxCardIndex;
        }
        public int? FindMaxBlackCard()
        {
            int? maxCardIndex = null;
            for (int i = 0; i < _hand.Count; i++)
            {
                if (_hand[i] == null)
                    continue;
                if (_hand[i].CardSuit == Card.Suit.clubs || _hand[i].CardSuit == Card.Suit.spades)
                {
                    if (maxCardIndex == null || maxCardIndex < (int)_hand[i].CardRank)
                        maxCardIndex = i;
                }
            }
            return maxCardIndex;
        }
    }
}
