using System;
using System.Linq;
using System.Threading;
using zadaca1;

namespace zad2
{
    class Program
    {
        static void Main(string[] args)
        {
            IGenericList<string> stringList = new GenericList<string>();
            stringList.Add("Hello");
            stringList.Add("World");
            stringList.Add("!");
            foreach (string a in stringList)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine(stringList.Count);
            // 3
            Console.WriteLine(stringList.Contains("Hello"));
            // true
            Console.WriteLine(stringList.IndexOf("Hello"));
            // 0
            Console.WriteLine(stringList.GetElement(1));
            // World
            IGenericList<double> doubleList = new GenericList<double>();
            doubleList.Add(0.2);
            doubleList.Add(0.7);

            foreach (double a in doubleList)
            {
                Console.WriteLine(a);
            }
            Thread.Sleep(2000);

        }
    }
}
