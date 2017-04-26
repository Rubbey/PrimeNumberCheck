using System;
using System.Numerics;
using System.Diagnostics;

namespace PrimeNumberCheck
{
    class Program
    {
        static ulong counter = 0;

        static bool IsPrimeInstrumental(BigInteger Num)
        {
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else counter++;
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

        static bool IsPrime2(BigInteger Num)
        {

            return true;
        }

        static void Main(string[] args)
        {
            BigInteger[] array = { 100913, 1009139, 10091401, 100914061 };

            for (int i = 0; i < array.Length; i++)
            {
                counter = 0;
                Console.WriteLine($"Testuję liczbę: {array[i],-15:N0} {IsPrimeInstrumental(array[i])} Counter={counter} ");
            }

            double ElapsedSeconds;
            long IterationElapsedTime = 0;
            for (int i = 0; i < array.Length; i++)
            {
                long StartingTime = Stopwatch.GetTimestamp();
                bool Test = IsPrime(array[i]);
                long EndingTime = Stopwatch.GetTimestamp();
                IterationElapsedTime = EndingTime - StartingTime;
                ElapsedSeconds = IterationElapsedTime * (1.0 / Stopwatch.Frequency);
                Console.WriteLine($"Testuję liczbę: {array[i],-15:N0} {Test} Time[s]= {ElapsedSeconds} ");
            }            
           
        }
    }
}
