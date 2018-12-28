using System;
using Solution.Interfaces;
using Solution.Enums;

namespace Solution.Classes
{
    public class PlayingCard : IPlayingCard, IStudyAssignment
    {
        private CardSuit _cardSuit;
        private CardValue _cardValue;
        private bool _visibility;

        public CardSuit CardSuit
        {
            get
            {
                return _cardSuit;
            }
            set
            {
                _cardSuit = value;
            }
        }

        public CardValue CardValue
        {
            get
            {
                return _cardValue;
            }
            set
            {
                _cardValue = value;
            }
        }

        public string Color
        {
            get
            {
                if (CardSuit == CardSuit.Hearts || CardSuit == CardSuit.Diamonds)
                    return "Red";
                return "Black";
            }
        }

        public bool Visibility
        {
            get
            {
                return _visibility;
            }
            set
            {
                _visibility = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rank">Номинал карты</param>
        /// <param name="suit">Масть</param>
        /// <param name="visibility">Видимость карты(true - лицом вверх, false - рубашкой)</param>
        public PlayingCard(CardValue rank, CardSuit suit, bool visibility = false)
        {
            CardValue = rank;
            CardSuit = suit;
            Visibility = visibility;
        }
        public PlayingCard():this(CardValue.Queen, CardSuit.Clubs) { }

        public void Print()
        {
            Console.WriteLine($"{CardValue} of {CardSuit}");
        }

        public void TurnOver()
        {
            Visibility = !Visibility;
        }

        public void Run()
        {
            new View.PlayingCardView().Main(new Factories.PlayingCardFactory());
        }
    }
}
