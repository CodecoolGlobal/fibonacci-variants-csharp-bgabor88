using System;
using static Codecool.FibonacciVariants.FibonacciVariants;

namespace Codecool.FibonacciVariants
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            const int k = 30;

            ResetCounter();
            PrintFibonacci("iteration", k, Iterative(k), AdditionsCounter);
            
            ResetCounter();
            PrintFibonacci("naive recursion", k, NaiveRecursive(k), AdditionsCounter);
            
            ResetCounter();
            PrintFibonacci("recursion with memoization", k, RecursiveWithMemoization(k), AdditionsCounter);
            
            ResetCounter();
            PrintFibonacci("tail recursion", k, TailRecursive(k), AdditionsCounter);
        }

        private static void PrintFibonacci(string methodName, int k, int fib, int additions)
        {
            Console.WriteLine($"Using {methodName}: Fib({k}) = {fib}, number of additions: {additions}");
        }
    }
}
