using System;
using System.Collections.Generic;

namespace SkillFactory.Task2
{
    class Program
    {
        static void Main()
        {
            const int FioCount = 5;

            var fioHandler = new FioHandler();
            fioHandler.OnFioEntered += SortFioList;

            bool success = false;

            while (!success)
                try
                {
                    fioHandler.EnterFio(FioCount);
                    success = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                    Console.Clear();
                }

            Console.ReadKey();
        }

        private static void SortFioList(IList<string> listFio, bool descSort = false)
        {
            for (int i = 0; i < listFio.Count; i++)
                for (int j = i + 1; j < listFio.Count; j++)
                    if (string.Compare(listFio[i], listFio[j]) == (descSort ? -1 : 1))
                        (listFio[i], listFio[j]) = (listFio[j], listFio[i]);

            foreach (string fio in listFio)
                Console.WriteLine(fio);

            Console.WriteLine();
        }
    }

    class FioHandler
    {
        private readonly List<string> FioList = new List<string>();

        public delegate void FioSortingHandler(IList<string> listFio, bool descSort = false);
        public event FioSortingHandler OnFioEntered;

        public void EnterFio(int count)
        {
            Console.WriteLine("1 is ascending sort");
            Console.WriteLine("2 is descending sort");
            Console.Write("Choose sort type: ");

            string type = Console.ReadLine();

            if (!int.TryParse(type, out int order) || (order != 1 && order != 2))
                throw new SortTypeException();

            Console.WriteLine();

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter the {i + 1} FIO: ");
                FioList.Add(Console.ReadLine());

                OnFioEntered?.Invoke(FioList, order == 2);
            }
        }
    }

    class SortTypeException : Exception 
    {
        public SortTypeException()
            : base("Некорректный тип сортировки")
        {
        }
    }

}
