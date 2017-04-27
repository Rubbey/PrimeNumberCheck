using System;
using System.Numerics;
using System.Diagnostics;

namespace PrimeNumberCheck
{

    class Program
    {
                

        static ulong counter = 0;
        static double ElapsedSeconds;
        static long IterationElapsedTime = 0;

        static bool IsPrimeInstrumental(BigInteger Num)
        {
            if (Num < 2) return false;
            else if (Num < 4) return true;
            counter++;
            if (Num % 2 == 0) return false;
            else for (BigInteger u = 3; u < Num / 2; u += 2)
                {
                    counter++;
                    if (Num % u == 0) return false;
                }
            return true;
        }

        static bool IsPrime(BigInteger Num)
        {
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) return false;
            else for (BigInteger u = 3; u < Num / 2; u += 2)
                    if (Num % u == 0) return false;
            return true;
        }

        static bool IsPrime2Instrumental(BigInteger Num)
        {
            if (Num < 2 | Num % 2 == 0) return false;

            counter++;
            for (BigInteger u = 5; u <= Num / 2; u += 2)
            {
                counter++;
                if (Num % u == 0) return false;
                if ((Num / u) < u) return true;
                u += 2;
                counter++;
                if (Num % u == 0) return false;
                if ((Num / u) < u) return true;
            }
            return true;
        }

        static bool IsPrime2(BigInteger Num)
        {
            if (Num < 2 | Num % 2 == 0) return false;
            for (BigInteger u = 5; u <= Num / 2; u += 2)
            {
                if (Num % u == 0) return false;
                if ((Num / u) < u) return true;
                u += 2;
                if (Num % u == 0) return false;
                if ((Num / u) < u) return true;
            }
            return true;
        }

        static bool test(BigInteger Num, BigInteger u)
        {
            return true;
        }



        static BigInteger ModularExponentation(BigInteger a, BigInteger b, BigInteger n)
        {
            BigInteger i;
            BigInteger result = 1;
            counter++;
            BigInteger x = a % n;

            for (i = 1; i <= b; i <<= 1)
            {
                counter++;
                x %= n;
                if ((b & i) != 0)
                {
                    counter++;
                    result *= x;
                    result %= n;
                }
                x *= x;
            }

            return result;
        }

        static void Main(string[] args)
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            BigInteger[] array = { 100913, 1009139, 10091401, 100914061, 1009140611, 10091406133, 100914061337, 1009140613399 };

            // Przykładowy algorytm.

            Console.WriteLine("Algorytm z wykładów (instrumentacja):");
            for (int i = 0; i < array.Length; i++)
            {
                counter = 0;
                Console.WriteLine($"Testuję liczbę: {array[i],-15:N0} {IsPrimeInstrumental(array[i])} Counter={counter} ");
            }
            Console.WriteLine("\n\n");


            Console.WriteLine("Algorytm z wykładów (czas):");
            ElapsedSeconds = 0;
            IterationElapsedTime = 0;
            for (int i = 0; i < array.Length; i++)
            {
                long StartingTime = Stopwatch.GetTimestamp();
                bool Test = IsPrime(array[i]);
                long EndingTime = Stopwatch.GetTimestamp();
                IterationElapsedTime = EndingTime - StartingTime;
                ElapsedSeconds = IterationElapsedTime * (1000.0 / Stopwatch.Frequency);
                Console.WriteLine($"Testuję liczbę: {array[i],-15:N0} {Test} Time[ms]= {ElapsedSeconds} ");
            }
            Console.WriteLine("\n\n");


            // Implementacja własna.
            Console.WriteLine("Implementacja własna (instrumentacja):");
            for (int i = 0; i < array.Length; i++)
            {
                counter = 0;                
                Console.WriteLine($"Testuję liczbę: {array[i],-15:N0} {IsPrime2Instrumental(array[i])} Counter={counter} ");
            }
            Console.WriteLine("\n\n");


            Console.WriteLine("Implementacja własna (czas):");
            ElapsedSeconds = 0;
            IterationElapsedTime = 0;
            for (int i = 0; i < array.Length; i++)
            {
                long StartingTime = Stopwatch.GetTimestamp();
                bool Test = IsPrime2(array[i]);
                long EndingTime = Stopwatch.GetTimestamp();
                IterationElapsedTime = EndingTime - StartingTime;
                ElapsedSeconds = IterationElapsedTime * (1000.0 / Stopwatch.Frequency);
                Console.WriteLine($"Testuję liczbę: {array[i],-15:N0} {Test} Time[ms]= {ElapsedSeconds} ");
            }
            Console.WriteLine("\n\n");

            stopwatch.Stop();
            Console.WriteLine("Total time [m]: {0}", stopwatch.Elapsed.TotalMinutes);



        }
    }
}
