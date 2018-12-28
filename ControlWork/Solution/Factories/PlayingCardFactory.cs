using System;
using Solution.Interfaces;
using Solution.Classes;
using Solution.Enums;

namespace Solution.Factories
{
    class PlayingCardFactory : SolutionFactory
    {
        public override string Name
        {
            get
            {
                return "Игральные карты";
            }
        }

        public override IStudyAssignment FactoryMethod(params object[] values)
        {
            if (values.Length == 0) return new PlayingCard();
            if(values.Length >= 2)
            {
                return ChoiseValidType(values);
            }
            return new PlayingCard();
        }

        private IStudyAssignment ChoiseValidType(object[] values)
        {
            if (values[0] is CardValue && values[1] is CardSuit)
                return ToProcessEnumInputType(values);
            if (values[0] is string && values[1] is string)
                return ToProcessStringInputType(values);
            return new PlayingCard();
        }

        private IStudyAssignment ToProcessStringInputType(object[] values)
        {
            CardValue Value = CardValue.Queen;
            CardSuit Suit = CardSuit.Spades;

            if (Enum.TryParse((string)values[0], out Value) &&
                Enum.TryParse((string)values[1], out Suit))
                return new PlayingCard(Value, Suit);

            return new PlayingCard();
        }

        private IStudyAssignment ToProcessEnumInputType(object[] values)
        {
            if (values.Length >= 3 && values[2] is bool)
                return new PlayingCard((CardValue)values[0], (CardSuit)values[1], (bool)values[2]);
            return new PlayingCard((CardValue)values[0], (CardSuit)values[1]);
        }
    }
}
