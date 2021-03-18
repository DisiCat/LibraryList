using System;
using LibraryList;

namespace ProverkaLibrary
{
    class Program
    {
        static void Main(string[] args)
        {

            ArrayList List = new ArrayList();
            Console.WriteLine(List.Length);
            List.AddLast(10);
            List.AddLast(10);
            List.AddLast(10);
            Console.WriteLine(List[0] = 99);
            List.RemoveFirst(2);
            Console.WriteLine(List.Length);

            

        }

    }
}

