using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static Codecool.FibonacciVariants.FibonacciVariants;

namespace Codecool.FibonacciVariants
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var results = new List<Result>();
            
            Console.WriteLine("Please enter a number between 0-40:");
            int k = Convert.ToInt32(Console.ReadLine());
            if (k > 40) {
                k = 40;
            }

            var sw = new Stopwatch();

            ResetMemory();
            ResetCounter();
            sw.Start();
            var result = Iterative(k);
            sw.Stop();
            results.Add(new Result("Iteration without memory", k, result, AdditionsCounter, sw.Elapsed.TotalMilliseconds));
            sw.Reset();

            ResetMemory();
            ResetCounter();
            sw.Start();
            result = IterativeWithDictMemory(k);
            sw.Stop();
            results.Add(new Result("Iteration with memory (Dict)", k, result, AdditionsCounter, sw.Elapsed.TotalMilliseconds));
            sw.Reset();

            ResetMemory();
            ResetCounter();
            sw.Start();
            result = IterativeWithArrayMemory(k);
            sw.Stop();
            results.Add(new Result("Iteration with memory (Array)", k, result, AdditionsCounter, sw.Elapsed.TotalMilliseconds));
            sw.Reset();

            ResetMemory();
            ResetCounter();
            sw.Start();
            result = NaiveRecursive(k);
            sw.Stop();
            results.Add(new Result("Naive recursion", k, result, AdditionsCounter, sw.Elapsed.TotalMilliseconds));
            sw.Reset();

            ResetMemory();
            ResetCounter();
            sw.Start();
            result = RecursiveWithMemoization(k);
            sw.Stop();
            results.Add(new Result("Recursion with memory (Dict)", k, result, AdditionsCounter, sw.Elapsed.TotalMilliseconds));
            sw.Reset();

            ResetMemory();
            ResetCounter();
            sw.Start();
            result = RecursiveWithMemoizationArray(k);
            sw.Stop();
            results.Add(new Result("Recursion with memory (Array)", k, result, AdditionsCounter, sw.Elapsed.TotalMilliseconds));
            sw.Reset();

            ResetMemory();
            ResetCounter();
            sw.Start();
            result = TailRecursive(k);
            sw.Stop();
            results.Add(new Result("Tail recursion", k, result, AdditionsCounter, sw.Elapsed.TotalMilliseconds));
            sw.Reset();

            PrintFibonacci(results);
        }

        private static void PrintFibonacci(string methodName, int k, int fib, int additions, double time)
        {
            Console.WriteLine($" {time}ms\n     Using {methodName}:\n     Fib({k}): {fib}\n     Additions: {additions}");
            Console.WriteLine();
        }

        private static void PrintFibonacci(IEnumerable<Result> results)
        {
            var orderedResults = results.OrderBy(x => x.Time);

            foreach (var result in orderedResults)
            {
                PrintFibonacci(result.Name, result.Element, result.FibNumber, result.Additions, result.Time);
            }
        }
    }
}
