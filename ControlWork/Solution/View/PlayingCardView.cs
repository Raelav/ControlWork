using System;
using Solution.Factories;
using Solution.Interfaces;
using Solution.Enums;
using System.Linq;

namespace Solution.View
{
    class PlayingCardView : IView
    {
        public void Main(SolutionFactory Factory)
        {
            IPlayingCard obj = GetCard(Factory);
            GetCardColor(obj);
            Console.WriteLine();
            ShowVisibility(obj);
            Console.WriteLine();
            TurnOverCard(obj);
            Console.WriteLine();
            ShowCardInfo(obj);
        }

        private void ShowCardInfo(IPlayingCard obj)
        {
            obj.Print();
            ShowVisibility(obj);
        }

        private void TurnOverCard(IPlayingCard obj)
        {
            Console.WriteLine("The card is turned");
            obj.TurnOver();
        }

        private void ShowVisibility(IPlayingCard obj)
        {
            Console.Write("Playing card is ");
            Console.WriteLine(obj.Visibility ? "visible" : "invisible");
        }

        private void GetCardColor(IPlayingCard obj)
        {
            Console.Write($"A Suit this card is - {Enum.GetName(typeof(CardSuit), obj.CardSuit)}");
            Console.WriteLine($", so a color of card is {obj.Color}");
        }

        void PrintEnums<T>()
        {
            var names = Enum.GetNames(typeof(T));
            int[] values = (int[])Enum.GetValues(typeof(T));
            foreach (var e in values)
            {
                Console.WriteLine($"{Enum.GetName(typeof(T), e)} - {e}");
            }
        }

        private IPlayingCard GetCard(SolutionFactory Factory)
        {
            CardValue Value = (CardValue)GetValueOrRankOfCard<CardValue>("card rank number");
            CardSuit Suit = (CardSuit)GetValueOrRankOfCard<CardSuit>("card suit number");
            return (IPlayingCard)Factory.FactoryMethod(Value, Suit);
        }


        private int GetValueOrRankOfCard<T>(string message)
        {
            PrintEnums<T>();
            Console.WriteLine($"Enter a {message} corresponding to the required card");
            var value = 1;
            var values= (int[])Enum.GetValues(typeof(T));

            if (int.TryParse(Console.ReadLine(), out value) &&
                value >= values.Min() &&
                value <= values.Max())
            {
                Console.WriteLine();
                return value;
            }
                
            else
            {
                Console.WriteLine("Please enter valid data!");
                return GetValueOrRankOfCard<T>(message);
            }
        }
    }
}
