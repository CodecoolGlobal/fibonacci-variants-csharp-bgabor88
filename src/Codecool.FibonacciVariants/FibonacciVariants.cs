﻿using System.Collections.Generic;

namespace Codecool.FibonacciVariants
{
    public static class FibonacciVariants
    {
        // fibs: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, ...

        public static int AdditionsCounter { get; private set; }

        public static void ResetCounter()
        {
            AdditionsCounter = 0;
        }

        /// <summary>
        ///     Fibonacci sequence (iterative) implementation without recursive.
        /// </summary>
        /// <param name="n">N.-th Fibonacci number.</param>
        /// <returns></returns>
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

        public static int NaiveRecursive(int n)
        {
            return 0;
        }

        public static int RecursiveWithMemoization(int n)
        {
            return 0;
        }

        public static int TailRecursive(int n)
        {
            return 0;
        }

        private static int TailRecursiveHelper(int n, int a, int b)
        {
            return 0;
        }
    }
}
