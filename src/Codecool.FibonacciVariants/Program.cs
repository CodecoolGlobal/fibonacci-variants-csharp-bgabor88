using System;
using System.Diagnostics;
using static Codecool.FibonacciVariants.FibonacciVariants;

namespace Codecool.FibonacciVariants
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            const int k = 40;
            var sw = new Stopwatch();

            ResetCounter();
            sw.Start();
            var result = Iterative(k);
            sw.Stop();
            var ts = sw.Elapsed;
            PrintFibonacci("iteration", k, result, AdditionsCounter, ts);
            sw.Reset();
            
            ResetCounter();
            sw.Start();
            result = NaiveRecursive(k);
            sw.Stop();
            ts = sw.Elapsed;
            PrintFibonacci("naive recursion", k, result, AdditionsCounter, ts);
            sw.Reset();

            ResetCounter();
            sw.Start();
            result = RecursiveWithMemoization(k);
            sw.Stop();
            ts = sw.Elapsed;
            PrintFibonacci("recursion with memoization", k, result, AdditionsCounter, ts);
            sw.Reset();

            ResetCounter();
            sw.Start();
            result = TailRecursive(k);
            sw.Stop();
            ts = sw.Elapsed;
            PrintFibonacci("tail recursion", k, result, AdditionsCounter, ts);
            sw.Reset();
        }

        private static void PrintFibonacci(string methodName, int k, int fib, int additions, TimeSpan time)
        {
            Console.WriteLine($"Using {methodName}: Fib({k}) = {fib}, number of additions: {additions}, time: {time.TotalMilliseconds}ms");
        }
    }
}
