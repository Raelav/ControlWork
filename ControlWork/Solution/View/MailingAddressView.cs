using System;
using Solution.Factories;
using Solution.Interfaces;

namespace Solution.View
{
    class MailingAddressView : IView
    {
        public void Main(SolutionFactory Factory)
        {
            var obj = GetObj(Factory);

            obj.CreateAdvertisement();
            obj.CreateEnvelope();
        }

        private IMailingAddress GetObj(SolutionFactory Factory)
        {
            var post = (IMailingAddress)Factory.FactoryMethod();
            Console.Write("Enter company name  ");
            post.Name = Console.ReadLine();
            Console.Write("Enter city          ");
            post.City = Console.ReadLine();
            Console.Write("Enter street        ");
            post.Street = Console.ReadLine();
            Console.Write("Enter home address  ");
            post.HomeAddress = Console.ReadLine();
            Console.Write("Enter postal code   ");
            post.PostalCode = Console.ReadLine();

            return post;
        }
    }
}
