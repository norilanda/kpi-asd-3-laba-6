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
        int _score = 0;
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
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }
        public Player(List<Card?> hand)
        {
            this._hand = hand;
        }
        public Card BotWeapon => (Card)_hand[(int)_botWeaponIndex];
        public Card BotArmour => (Card)_hand[(int)BotArmourIndex];
        public void DeleteCardsAfterMove()//
        {
            if (_botArmourIndex == null || _botWeaponIndex == null)
                return;
            _hand[(int)_botArmourIndex] = null;
            _hand[(int)_botWeaponIndex] = null;
        }
        public void UnchooseAllCards()
        {
            _botArmourIndex = null;
            _botWeaponIndex = null;
        }
        public void DealCards(List<Card> deck)
        {
            Random rnd = new Random();
            int index;
            for (int i = 0; i < _hand.Count; i++)
            {
                if (_hand[i] == null)
                {
                    if (deck.Count == 0)
                        return;//
                    index = rnd.Next(deck.Count);
                    _hand[i] = deck[index];
                    deck.RemoveAt(index);
                }               
            }
        }

        //FIND MIN OR MAX CARDS
        public int? FindMinRedCard()
        {
            int? minCardIndex = null;
            for (int i = 0; i < _hand.Count; i++)
            {
                if (_hand[i] == null)
                    continue;               
                if (_hand[i].IsRed())
                {
                    if (minCardIndex == null || _hand[(int)minCardIndex].CardRank > _hand[i].CardRank)
                        minCardIndex = i;
                }
            }
            return minCardIndex;
        }
        public int? FindMinBlackCard(Card? cardToBeat )
        {
            int? minCardIndex = null;
            for (int i = 0; i < _hand.Count; i++)
            {
                if (_hand[i] == null)
                    continue;
                if (_hand[i].IsBlack())
                {
                    if (minCardIndex == null || _hand[(int)minCardIndex].CardRank > _hand[i].CardRank)
                    {
                        if (cardToBeat==null || _hand[i].CardRank >= cardToBeat.CardRank)
                            minCardIndex = i;                       
                    }                        
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
                if (_hand[i].IsRed())
                {
                    if (maxCardIndex == null || _hand[(int)maxCardIndex].CardRank < _hand[i].CardRank)
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
                if (_hand[i].IsBlack())
                {
                    if (maxCardIndex == null || _hand[(int)maxCardIndex].CardRank < _hand[i].CardRank)
                        maxCardIndex = i;
                }
            }
            return maxCardIndex;
        }
        private int? FindBeforeMaxRedCard(int numberBeforeMax)
        {
            List<(Card c, int ind)> redCardIndexes= new List<(Card, int)>();
            int? maxCardIndex = null;
            for (int i = 0; i < _hand.Count; i++)
            {
                if (_hand[i] == null)
                    continue;
                if (_hand[i].IsRed())
                {
                    redCardIndexes.Add((_hand[i], i));                                     
                }
            }
            if (redCardIndexes.Count == 0)//if there is no red cards
                return null;
            redCardIndexes.OrderBy(x => x.c.CardSuit).ToList();
            int resultIndex = redCardIndexes.Count - numberBeforeMax - 1;
            if (resultIndex < 0 || resultIndex >= redCardIndexes.Count)
                resultIndex = redCardIndexes.Count-1;
            return redCardIndexes[resultIndex].ind;
        }

        //EASY LEVEL
        public int? EasyBotWeaponForCreation()
        {
            return FindMaxBlackCard();
        }
        public int? EasyBotWeaponForBeating(Card cardToBeat)
        {
            int? index = FindMaxBlackCard();
            if (index == null || _hand[(int)index].CardRank < cardToBeat.CardRank)
                return null;
            return index;
        }
        public int? EasyBotArmour()
        {
            List<int> redCardsIndexes = new List<int>();
            for (int i = 0; i < _hand.Count;i++)
            {
                if (_hand[i] == null)
                    continue;
                if (_hand[i].IsRed())
                    redCardsIndexes.Add(i);
            }
            if (redCardsIndexes.Count == 0)
                return null;
            Random rnd = new Random();
            return redCardsIndexes[rnd.Next(redCardsIndexes.Count)];
        }

        //MEDIUM
        public int? MediumBotArmour(int deadBotNumber)
        {
            if(deadBotNumber > 1)
                return FindMaxRedCard();
            return FindBeforeMaxRedCard(1);
        }

        //HARD
        public int? minMax(int deadBotNumber, int enemyScore, int BOT_NUMBER_TO_WIN)
        {
             if(enemyScore > _score || enemyScore + deadBotNumber >= BOT_NUMBER_TO_WIN || deadBotNumber > 2)
            {
                if (deadBotNumber > 0)//if there are dead bots
                    return FindMaxRedCard();
                return FindMinRedCard();
            }
            else
            {
                int bigNum, smallNum;
                CountBigAndSmallCards(out bigNum, out smallNum);
                if (bigNum > 2)
                {
                    if(deadBotNumber > 0)
                    {
                        int? redMinIndex = FindMinRedCard();
                        int? blackMaxIndex = FindMaxBlackCard();
                        if ((redMinIndex != null && (int)_hand[(int)redMinIndex].CardRank < 10) || CountWeapon() <= 3
                            || (blackMaxIndex != null && (int)_hand[(int)blackMaxIndex].CardRank >= 10))
                            return FindMaxRedCard();
                        else
                            return FindBeforeMaxRedCard(1);
                    }
                    else
                    {
                        Random rnd = new Random();
                        if(rnd.Next(2) == 0)
                            return FindBeforeMaxRedCard(1);
                        else
                            return FindBeforeMaxRedCard(2);
                    }
                }
                else
                {
                    if ((smallNum > 3 && deadBotNumber > 0 && bigNum > 0) || CountWeapon() > smallNum + bigNum)
                        return FindMaxRedCard();
                    return FindMinRedCard();
                }
            }
        }
        private void CountBigAndSmallCards(out int bigNum, out int smallNum)
        {
            const int BIG_CARD_RANK = 10;
            bigNum = 0;
            smallNum = 0;
            for (int i=0; i< _hand.Count; i++)
            {
                if (_hand[i] != null && _hand[i].IsRed())
                {
                    if ((int)_hand[i].CardRank >= BIG_CARD_RANK)
                        bigNum++;
                    else
                        smallNum++;
                }
            }
        }
        private int CountWeapon()
        {
            int n = 0;
            for(int i = 0; i< _hand.Count; i++)
            {
                if (_hand[i].IsBlack())
                    n++;
            }
            return n;
        }
    }
}
