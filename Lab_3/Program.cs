using System;

namespace Cripta_Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            NOD Nod = new NOD();
            PrimeNumber Prime = new PrimeNumber();
            
            Console.WriteLine("НОД(540,577) = " + Nod.Nod2(540, 577));
            //Console.WriteLine(Nod.Nod2(1234, 54));
            //Console.WriteLine(Nod.Nod2(54, 1234));
            //Console.WriteLine(Nod.Nod2(25, 60));
            //Console.WriteLine(Nod.Nod2(1352, 12610));

            Console.WriteLine("НОД(52,26,13) = " + Nod.Nod3(52, 26, 13));
            //Console.WriteLine(Nod.Nod3(1352, 12610, 169));

            Console.WriteLine("-------------------------------");
            
            Prime.printInterval(0, 577);
            Prime.printLog(540);

            Console.WriteLine("-------------------------------");

            Prime.printInterval(521, 553);

            Console.WriteLine("-------------------------------");

            Prime.printPrime(39943893);
            Prime.printPrime(39943242);
        }
    }
}