using System;
using LibraryList;

namespace ProverkaLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList array = new ArrayList();
            //array.Add(1);
            //Console.WriteLine(array.IndexAccess(0));
            //array.AddInStart(11);
            //Console.WriteLine(array.IndexAccess(0));
            //array.Insert(0, 5);
            //Console.WriteLine(array.IndexAccess(0));
            //array.Insert(1, 40);
            //Console.WriteLine(array.IndexAccess(1));
            //Console.WriteLine("ВЕсь массив :");
            //for (int i = 0; i < array.Lenght; i++)
            //{
            //    Console.WriteLine(array.IndexAccess(i));
            //}

            //array.RemoveLast();

            //Console.WriteLine("ВЕсь массив :");
            //for (int i = 0; i < array.Lenght; i++)
            //{
            //    Console.WriteLine(array.IndexAccess(i));
            //}

            //array.RemoveFirst();
            //Console.WriteLine("ВЕсь массив :");
            //for (int i = 0; i < array.Lenght; i++)
            //{
            //    Console.WriteLine(array.IndexAccess(i));
            //}
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);
            array.Add(5);
            array.Add(6);
            Console.WriteLine("ВЕсь массив :");
            for (int i = 0; i < array.Lenght; i++)
            {
                Console.WriteLine(array.IndexAccess(i));
            }
            array.RemoveNElementsAt(1,6);
            Console.WriteLine("ВЕсь массив :");
            for (int i = 0; i < array.Lenght; i++)
            {
                Console.WriteLine(array.IndexAccess(i));
            }
            Console.Write("Че? ");
        }
    }
}

