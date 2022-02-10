using System.Collections.Generic;

namespace Codecool.FibonacciVariants
{
    public static class FibonacciVariants
    {
        // fibs: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, ...

        public static int AdditionsCounter { get; private set; }

        private static readonly Dictionary<int, int> Memory = new()
        {
            { 0, 0 }, { 1, 1 }
        };

        private static readonly Dictionary<int, int> IterativeMemory = new()
        {
            { 0, 0 }, { 1, 1 }
        };

        private static readonly int[] IterativeArrayMemory = new int[60];

        private static readonly int[] RecursionArrayMemory = new int[60];

        public static void ResetCounter()
        {
            AdditionsCounter = 0;
        }

        /// <summary>
        ///     Fibonacci sequence (iterative) implementation without recursive.
        /// </summary>
        /// <param name="n">N.-th Fibonacci number.</param>
        /// <returns>Return the N.-th Fibonacci number.</returns>
        public static int Iterative(int n)
        {
            var firstFib = 0;
            var lastFib = 1;

            switch (n)
            {
                case 0:
                    return firstFib;
                case 1:
                    return lastFib;
            }

            for (var i = 2; i <= n; i++)
            {
                var currentFib = firstFib + lastFib;
                firstFib = lastFib;
                lastFib = currentFib;
                AdditionsCounter++;
            }

            return lastFib;
        }

        /// <summary>
        ///     Fibonacci sequence (iterative with memory) implementation without recursive.
        /// </summary>
        /// <param name="n">N.-th Fibonacci number.</param>
        /// <returns>Return the N.-th Fibonacci number.</returns>
        public static int IterativeWithMemory(int n)
        {
            for (var i = 2; i <= n; i++)
            {
                IterativeMemory[i] = IterativeMemory[i - 2] + IterativeMemory[i - 1];
                AdditionsCounter++;
            }
            return IterativeMemory[n];
        }
        /// <summary>
        ///     Fibonacci sequence (iterative with memory) implementation without recursive ARRAY.
        /// </summary>
        /// <param name="n">N.-th Fibonacci number.</param>
        /// <returns>Return the N.-th Fibonacci number.</returns>
        public static int IterativeWithMemoryArray(int n)
        {
            IterativeArrayMemory[0] = 0;
            IterativeArrayMemory[1] = 1;

            for (var i = 2; i <= n; i++)
            {
                IterativeArrayMemory[i] = IterativeArrayMemory[i - 2] + IterativeArrayMemory[i - 1];
                AdditionsCounter++;
            }
            return IterativeArrayMemory[n];
        }

        /// <summary>
        ///     Fibonacci sequence (naive recursive) implementation.
        /// </summary>
        /// <param name="n">N.-th Fibonacci number.</param>
        /// <returns>Return the N.-th Fibonacci number.</returns>
        public static int NaiveRecursive(int n)
        {
            if (n is 0 or 1) return n;
            AdditionsCounter++;
            return NaiveRecursive(n - 1) + NaiveRecursive(n - 2);
        }

        /// <summary>
        ///     Fibonacci sequence (recursive with memoization) implementation.
        /// </summary>
        /// <param name="n">N.-th Fibonacci number.</param>
        /// <returns>Return the N.-th Fibonacci number.</returns>
        public static int RecursiveWithMemoization(int n)
        {
            if (Memory.ContainsKey(n)) return Memory[n];

            Memory[n] = RecursiveWithMemoization(n - 1) + RecursiveWithMemoization(n - 2);
            AdditionsCounter++;

            return Memory[n];
        }

        /// <summary>
        ///     Fibonacci sequence (recursive with memoization) implementation with array as dict.
        /// </summary>
        /// <param name="n">N.-th Fibonacci number.</param>
        /// <returns>Return the N.-th Fibonacci number.</returns>
        public static int RecursiveWithMemoizationArray(int n)
        {
            switch (n)
            {
                case 0:
                    return n;
                case 1 or 2:
                    return 1;
            }

            if (RecursionArrayMemory[n] != 0) return RecursionArrayMemory[n];

            RecursionArrayMemory[n] = RecursiveWithMemoization(n - 1) + RecursiveWithMemoization(n - 2);
            AdditionsCounter++;

            return RecursionArrayMemory[n];
        }

        /// <summary>
        /// Fibonacci sequence (tail recursive) implementation.
        /// </summary>
        /// <param name="n">N.-th Fibonacci number.</param>
        /// <returns>Return the N.-th Fibonacci number.</returns>
        public static int TailRecursive(int n)
        {
            return TailRecursiveHelper(n - 1, 0, 1);
        }

        private static int TailRecursiveHelper(int n, int a, int b)
        {
            AdditionsCounter++;
            return n < 1 ? b : TailRecursiveHelper(n - 1, b, a + b);
        }
    }
}
