using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameAlgo;

namespace laba6
{
    internal class PlayerUI
    {
        private List<CardUI> _hand;
        private CardUI _weaponCard;
        private CardUI _armourCard;

        private int? _chosenWeaponCardIndex;
        private int? _chosenArmourCardIndex;
        private int _score;

        //getters/setters
        public List<CardUI> Hand
        { get { return _hand; } }
        public CardUI WeaponCard
        { 
            get { return _weaponCard; }
            set { _weaponCard = value; }
        }
        public CardUI ArmourCard
        {
            get { return _armourCard; }
            set { _armourCard = value; }
        }
        public int? ChosenWeaponCardIndex
        {
            get { return _chosenWeaponCardIndex;}
            set { _chosenWeaponCardIndex = value; }
        }
        public int? ChosenArmourCardIndex
        {
            get { return _chosenArmourCardIndex;}
            set { _chosenArmourCardIndex = value;}
        }
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        //constructor
        public PlayerUI(List<CardUI> hand)
        {
            this._hand = hand;
            _score = 0;
        }
        public void ChooseCard(int cardIndex)
        {
            if (_hand[cardIndex].IsEmpty)
                return;
            if (_hand[cardIndex].GetColor == CardUI.SuitColor.black)
            {
                if (_chosenWeaponCardIndex == cardIndex)
                {
                    _chosenWeaponCardIndex = null;
                    _hand[cardIndex].MarkUnchosen();
                }
                else
                {
                    if (_chosenWeaponCardIndex != null)
                        _hand[(int)_chosenWeaponCardIndex].MarkUnchosen();
                    _chosenWeaponCardIndex = cardIndex;
                    _hand[cardIndex].MarkChosen();
                }
            }
            else if (_hand[cardIndex].GetColor == CardUI.SuitColor.red)
            {
                if (_chosenArmourCardIndex == cardIndex)
                {
                    _chosenArmourCardIndex = null;
                    _hand[cardIndex].MarkUnchosen();
                }
                else
                {
                    if (_chosenArmourCardIndex != null)
                        _hand[(int)_chosenArmourCardIndex].MarkUnchosen();
                    _chosenArmourCardIndex = cardIndex;
                    _hand[cardIndex].MarkChosen();
                }
            }
        }
        //public void ClearBattleField()
        //{
        //    _chosenWeaponCardIndex = null;
        //    _chosenArmourCardIndex = null;
        //}
        public void PlayBot()
        {
            _hand[(int)_chosenWeaponCardIndex].MoveTo(_weaponCard);
            _hand[(int)_chosenArmourCardIndex].MoveTo(_armourCard);
        }
        public bool BeatBot(Card armourCard)
        {
            if (_hand[(int)_chosenWeaponCardIndex].GetCard.CardRank >= armourCard.CardRank)
            {
                PlayBot();
                return true;
            }
            else
            {
                MessageBox.Show("Your card rank is not enough!");
                return false;
            }                
        }
    }
}
