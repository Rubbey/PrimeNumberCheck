using System;
using System.Numerics;
using System.Diagnostics;

namespace PrimeNumberCheck
{

    class Program
    {


        static BigInteger Counter = 0;
        static double ElapsedSeconds;
        static long IterationElapsedTime = 0;

        static bool IsPrime2Instrumental(BigInteger Num)
        {
            if (Num < 2) return false;
            else if (Num == 2 | Num == 3) return true;
            Counter++;
            if (Num % 2 == 0) return false;
            Counter++;
            if (Num % 3 == 0) return false;
            

            BigInteger BaseNumber = 5; // first number of {6i-1, 6i+2} for i={1,2,3,4,...}
            BigInteger IncrementationFactor = 2;

            while (BaseNumber * BaseNumber <= Num) // BaseNumber <= sqrt(Num)
            {
                Counter++;
                if (Num % BaseNumber == 0) return false;
                BaseNumber += IncrementationFactor;
                IncrementationFactor = 6 - IncrementationFactor;
            }
            return true;
        }

        static bool IsPrime2(BigInteger Num)
        {
            if (Num < 2) return false;
            else if (Num == 2 | Num == 3) return true;
            else if (Num % 2 == 0) return false;
            else if (Num % 3 == 0) return false;

            BigInteger BaseNumber = 5;
            BigInteger IncrementationFactor = 2;

            while (BaseNumber * BaseNumber <= Num)
            {                
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
            Counter++;
            if (Num % 2 == 0) return false;
            else for (BigInteger u = 3; u < Num / 2; u += 2)
                {
                    Counter++;
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

        


        static void Main(string[] args)
        {
            BigInteger[] Array = { 100913, 1009139, 10091401, 100914061, 1009140611, 10091406133, 100914061337, 1009140613399 };

            
            Console.WriteLine("Algorytm z wykładów (instrumentacja):");
            Console.WriteLine("Test number:    Is prime?    Counter of modulo operation:");
            for (int i = 0; i < Array.Length; i++)
            {
                Counter = 0;
                Console.WriteLine($"{Array[i],-15:N0} {IsPrimeInstrumental(Array[i]),-12} {Counter}");
            }
            Console.WriteLine("\n\n");
            
                        
            Console.WriteLine("Algorytm z wykładów (czas):");
            Console.WriteLine("Test number:    Is prime?    Time[ms]:");
            ElapsedSeconds = 0;
            IterationElapsedTime = 0;
            for (int i = 0; i < Array.Length; i++)
            {
                long StartingTime = Stopwatch.GetTimestamp();
                bool Test = IsPrime(Array[i]);
                long EndingTime = Stopwatch.GetTimestamp();
                IterationElapsedTime = EndingTime - StartingTime;
                ElapsedSeconds = IterationElapsedTime * (1000.0 / Stopwatch.Frequency);
                Console.WriteLine($"{Array[i],-15:N0} {Test,-12}  {ElapsedSeconds} ");
            }
            Console.WriteLine("\n\n");
            

            // Implementacja własna.
            Console.WriteLine("Implementacja własna (instrumentacja):");
            Console.WriteLine("Test number:    Is prime?    Counter of modulo operation:");
            for (int i = 0; i < Array.Length; i++)
            {
                Counter = 0;
                Console.WriteLine($"{Array[i],-15:N0} {IsPrime2Instrumental(Array[i]),-12} {Counter}");
            }
            Console.WriteLine("\n\n");
            

            Console.WriteLine("Implementacja własna (czas):");
            Console.WriteLine("Test number:    Is prime?    Time[ms]:");
            ElapsedSeconds = 0;
            IterationElapsedTime = 0;
            for (int i = 0; i < Array.Length; i++)
            {
                long StartingTime = Stopwatch.GetTimestamp();
                bool Test = IsPrime2(Array[i]);
                long EndingTime = Stopwatch.GetTimestamp();
                IterationElapsedTime = EndingTime - StartingTime;
                ElapsedSeconds = IterationElapsedTime * (1000.0 / Stopwatch.Frequency);
                Console.WriteLine($"{Array[i],-15:N0} {Test,-12} {ElapsedSeconds}");
            }
            Console.WriteLine("\n\n");
            
            Console.ReadLine();
            Console.WriteLine("Uwaga nastąpi zamknięcie okna!!! Skopiuj i zapisz wyniki");
            Console.ReadLine();
            Console.ReadLine();


        }
    }
}
