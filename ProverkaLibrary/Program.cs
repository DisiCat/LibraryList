using System;
using LibraryList;

namespace ProverkaLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList array = new ArrayList();

            array.AddInLast(10);
            array.AddInLast(2);
            array.AddInLast(3);
            array.AddInLast(4);
            array.AddInLast(5);
            array.AddInLast(10);
            array.AddInLast(2);
            array.AddInLast(10);
            array.AddInLast(10);
             /// Я ВСЕ ИСПРАВЫИЛ Я МОЛОДЕЦ Ы
            Console.WriteLine("Весь массив :");
            for (int i = 0; i < array.Lenght; i++)
            {
                Console.Write(array.IndexAccess(i) + " ");
            }
            Console.WriteLine(" len = " + array.Lenght);
            array.RemoveAllElementsByValue(10);
        
            Console.WriteLine("Весь массив :");
            for (int i = 0; i < array.Lenght; i++)
            {
                Console.Write(array.IndexAccess(i) + " ");
            }
            Console.WriteLine(" len = " + array.Lenght);

        }

    }
}

