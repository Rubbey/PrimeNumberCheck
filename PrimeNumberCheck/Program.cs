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

        static bool PrimeNumbers(BigInteger Num)
        {
            if (Num < 2) return false;
            else if (Num == 2 | Num == 3) return true;
            counter++;
            if (Num % 2 == 0) return false;
            counter++;
            if (Num % 3 == 0) return false;
            

            BigInteger BaseNumber = 5; // first number of {6i-1, 6i+2} for i={1,2,3,4,...}
            BigInteger IncrementationFactor = 2;

            while (BaseNumber * BaseNumber <= Num) // BaseNumber <= sqrt(Num)
            {
                counter++;
                if (Num % BaseNumber == 0) return false;
                BaseNumber += IncrementationFactor;
                IncrementationFactor = 6 - IncrementationFactor;
            }
            return true;
        }

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
            counter++;
            if (Num < 2 | Num % 2 == 0) return false;
            if (Num == 3) return false;
            counter++;
            for (BigInteger u = 5; u <= Num / 2; u += 4)
            {
                counter++;
                if (Num % u == 0) return false;
                if ((Num / u) < u) break;
                u += 2;
                counter++;
                if (Num % u == 0) return false;
                if ((Num / u) < u) break;
            }
            return true;
        }

        static bool IsPrime3Instrumental(BigInteger Num)
        {
            counter++;
            if (Num < 2 | Num % 2 == 0) return false;

            for (BigInteger u = 5; u <= Num / 2; u += 4)
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
            for (BigInteger u = 3; u <= Num / 2; u += 2)
            {
                if (Num % u == 0) return false;
                if ((Num / u) < u) return true;
                u += 2;
                if (Num % u == 0) return false;
                if ((Num / u) < u) return true;
            }
            return true;
        }


        static void Main(string[] args)
        {

            BigInteger[] array = { 101, 1009, 10091, 100913, 1009139, 10091401, 100914061 }; // , 1009140611, 10091406133, 100914061337, 1009140613399

            // Przykładowy algorytm.
            
            Console.WriteLine("Algorytm z wykładów (instrumentacja):");
            for (int i = 0; i < array.Length; i++)
            {
                counter = 0;
                Console.WriteLine($"Testuję liczbę: {array[i],-15:N0} {IsPrimeInstrumental(array[i])}\t Counter={counter} ");
            }
            Console.WriteLine("\n\n");
           /* 
                        
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
                Console.WriteLine($"Testuję liczbę: {array[i],-15:N0} {Test}\t Time[ms]= {ElapsedSeconds} ");
            }
            Console.WriteLine("\n\n");
            */

            // Implementacja własna.
            Console.WriteLine("Implementacja własna (instrumentacja):");
            for (int i = 0; i < array.Length; i++)
            {
                counter = 0;
                Console.WriteLine($"Testuję liczbę: {array[i],-15:N0} {PrimeNumbers(array[i])}\t Counter={counter} ");
            }
            Console.WriteLine("\n\n");

            Console.WriteLine("Implementacja własna 2 (instrumentacja):");
            for (int i = 0; i < array.Length; i++)
            {
                counter = 0;
                Console.WriteLine($"Testuję liczbę: {array[i],-15:N0} {IsPrime3Instrumental(array[i])}\t Counter={counter} ");
            }
            Console.WriteLine("\n\n");

            /*
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
                Console.WriteLine($"Testuję liczbę: {array[i],-15:N0} {Test}\t Time[ms]= {ElapsedSeconds} ");
            }
            Console.WriteLine("\n\n");
            */
            Console.ReadLine();



        }
    }
}
