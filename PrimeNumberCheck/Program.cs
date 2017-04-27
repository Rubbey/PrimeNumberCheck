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

        static bool IsPrime2(BigInteger Num)
        {
            if (Num < 2) return false;
            else if (Num < 4) return true;
            counter++;        
            if (Num % 2 == 0) return false;
            else
            {
                BigInteger Inc = 1, Div = 0;
                for (BigInteger u = 5; Div < Num / 2; u+=4)
                {                    
                    counter++;
                    Div = u;
                    if (Num % Div == 0) return false;
                    if ((Num / Div) < Div) break;
                    Div += 2;
                    counter++;
                    if (Num % Div == 0) return false;
                    if((Num / Div) < Div) break;
                }
                return true;
            }            
        }
        static bool IsPrime3(BigInteger Num)
        {
            if (ModularExponentation(2, Num - 1, Num) != 1 % Num) return false;
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
            BigInteger[] array = { 101, 1009, 10091, 10191, 100913, 1009139, 10091401, 100914061 };

            /*// Przykładowy algorytm
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
           */

            for (int i = 0; i < array.Length; i++)
            {
                counter = 0;
                

                Console.WriteLine($"Testuję liczbę: {array[i],-15:N0} {IsPrime2(array[i])} Counter={counter} ");
            }


        }
    }
}
