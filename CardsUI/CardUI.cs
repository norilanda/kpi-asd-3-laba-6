using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameAlgo;

namespace CardsUI
{
    public class CardUI
    {
        private static string _fileNameFaceDown = ".\\deck\\shirt.png";
        private string _fileName;
        Card _card;
        public string FileName => _fileName;
        public static string FileNameFaceDown => _fileNameFaceDown;
        public CardUI(Card card)
        {
            this._card = card;
            SetFileName();
        }
        private void SetFileName()
        {
            _fileName = ".\\deck\\";
            switch (_card.CardRank)
            {
                case Card.Rank.r2:
                    {
                        _fileName += "2_of_";
                        break;
                    }
                case Card.Rank.r3:
                    {
                        _fileName += "3_of_";
                        break;
                    }
                case Card.Rank.r4:
                    {
                        _fileName += "4_of_";
                        break;
                    }
                case Card.Rank.r5:
                    {
                        _fileName += "5_of_";
                        break;
                    }
                case Card.Rank.r6:
                    {
                        _fileName += "6_of_";
                        break;
                    }
                case Card.Rank.r7:
                    {
                        _fileName += "7_of_";
                        break;
                    }
                case Card.Rank.r8:
                    {
                        _fileName += "8_of_";
                        break;
                    }
                case Card.Rank.r9:
                    {
                        _fileName += "9_of_";
                        break;
                    }
                case Card.Rank.r10:
                    {
                        _fileName += "10_of_";
                        break;
                    }
                case Card.Rank.J:
                    {
                        _fileName += "jack_of_";
                        break;
                    }
                case Card.Rank.Q:
                    {
                        _fileName += "queen_of_";
                        break;
                    }
                case Card.Rank.K:
                    {
                        _fileName += "king_of_";
                        break;
                    }
                case Card.Rank.Ace:
                    {
                        _fileName += "ace_of_";
                        break;
                    }
                case Card.Rank.Joker:
                    {
                        _fileName += "joker_";
                        break;
                    }
            }
            switch (_card.CardSuit)
            {
                case Card.Suit.spades:
                    {
                        _fileName += "spades";
                        break;
                    }
                case Card.Suit.hearts:
                    {
                        _fileName += "hearts";
                        break;
                    }
                case Card.Suit.diamonds:
                    {
                        _fileName += "diamonds";
                        break;
                    }
                case Card.Suit.clubs:
                    {
                        _fileName += "clubs";
                        break;
                    }
            }
            _fileName += ".png";
        }
    }
}
