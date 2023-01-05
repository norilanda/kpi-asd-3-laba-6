using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameAlgo;

namespace laba6
{
    public class CardUI
    {
        public enum SuitColor
        {
            black,
            red,
            noColor
        }
        private static string _fileNameFaceDown = ".\\deck\\shirt.png";
        private string _fileName;
        private PictureBox _picture;
        Card? _card;

        public static Color unchosenBackColor = Color.White;
        public string FileName => _fileName;
        public PictureBox Picture => _picture;
        public bool IsEmpty => _card == null;
        public static string FileNameFaceDown => _fileNameFaceDown;
        public SuitColor GetColor
        {
            get
            {
                if (_card.CardSuit == Card.Suit.diamonds || _card.CardSuit == Card.Suit.hearts)
                    return SuitColor.red;
                if (_card.CardSuit == Card.Suit.clubs || _card.CardSuit == Card.Suit.spades)
                    return SuitColor.black;
                return SuitColor.noColor;
            }
        }
        public CardUI(Card card, PictureBox pBox)
        {
            this._card = card;
            SetFileName();
            this._picture = pBox;
            this._picture.BackColor = unchosenBackColor;
        }
        public void SetEmpty()
        { 
            _picture.BackColor = unchosenBackColor;
            _fileName = "";
            _card = null;
        }
        public void FaceUp()
        {
            _picture.Load(_fileName);
        }
        public void FaceDown()
        {
            _picture.Load(_fileNameFaceDown);
        }
        public void MarkChosen()
        {
            _picture.BackColor = Color.Green;
        }
        public void MarkUnchosen()
        {
            _picture.BackColor = unchosenBackColor;
        }
        private void SetFileName()
        {
            _fileName = ".\\deck\\";
            if(_card == null )
            {
                _fileName = "";
                return;
            }
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
        public void MoveTo(PictureBox pBox)
        {
            _picture.Image = null;
            pBox.Load(_fileName);
            SetEmpty();
        }
        public void AddCard(Card card)
        {
            //
            //-----
        }
    }
}
