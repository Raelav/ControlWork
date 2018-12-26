using System;
using System.Collections.Generic;
using Solution.Factories;

namespace Solution.Client
{
    public static class Client
    {
        /// <summary>
        /// Список готовых заданий
        /// </summary>
        public static List<SolutionFactory> Contents = new List<SolutionFactory>
        {
            new TitlePageFactory(),
            new ComplexNumberFactory(),
            new RationalFractionFactory(),
            new DateFactory(),
            new PolynomialFactory(),
            new NDimensionalVectorFactory(),
            new MailingAddressFactory(),
            new ThreeDVectorFactory(),    
            new ChainListFactory(),
            new OneDArrayFactory(),
            new MessageLogFactory(),
        };

        /// <summary>
        /// Номер текущей страницы
        /// </summary>
        private static int currentPage = 0;

        /// <summary>
        /// Старт приложения
        /// </summary>
        static public void Start()
        {
            DisplaySettings();
            Contents[0].FactoryMethod().Run();
            Run();
        }

        /// <summary>
        /// Главный метод работы приложения
        /// </summary>
        private static void Run()
        {
            ReadNextPage();
            Console.Clear();
            Contents[currentPage].FactoryMethod().Run();
            Run();
        }

        /// <summary>
        /// Задает новую "Текущую" страницу
        /// </summary>
        private static void ReadNextPage()
        {
            Console.Write("\n\nВведите номер следующей страницы... ");
            var nextPage = 0;
            int.TryParse(Console.ReadLine(), out nextPage);
            if (nextPage >= 0 && nextPage < Contents.Count)
                currentPage = nextPage;
            else if (currentPage == Contents.Count - 1)
                currentPage = 0;
            else currentPage++;
        }

        /// <summary>
        /// Настройки отображения консоли
        /// </summary>
        private static void DisplaySettings()
        {
            Console.Title = "Контрольная работа";
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}
