using System.Collections.Generic;

namespace Codecool.FibonacciVariants
{
    public static class FibonacciVariants
    {
        // fibs: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, ...

        public static int AdditionsCounter { get; private set; }

        private static Dictionary<int, int> _dictMemory = new Dictionary<int, int>();
        
        private static int[] _arrayMemory = new int[100];
        

        public static void ResetCounter()
        {
            AdditionsCounter = 0;
        }

        public static void ResetMemory()
        {
            _dictMemory = new Dictionary<int, int>();
            _arrayMemory = new int[100];
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
            AdditionsCounter++;
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
        public static int IterativeWithDictMemory(int n)
        {
            _dictMemory[0] = 0;
            _dictMemory[1] = 1;
            AdditionsCounter++;
            for (var i = 2; i <= n; i++)
            {
                _dictMemory[i] = _dictMemory[i - 2] + _dictMemory[i - 1];
                AdditionsCounter++;
            }
            return _dictMemory[n];
        }
        /// <summary>
        ///     Fibonacci sequence (iterative with memory) implementation without recursive ARRAY.
        /// </summary>
        /// <param name="n">N.-th Fibonacci number.</param>
        /// <returns>Return the N.-th Fibonacci number.</returns>
        public static int IterativeWithArrayMemory(int n)
        {
            _arrayMemory[0] = 0;
            _arrayMemory[1] = 1;
            AdditionsCounter++;
            for (var i = 2; i <= n; i++)
            {
                _arrayMemory[i] = _arrayMemory[i - 2] + _arrayMemory[i - 1];
                AdditionsCounter++;
            }
            return _arrayMemory[n];
        }

        /// <summary>
        ///     Fibonacci sequence (naive recursive) implementation.
        /// </summary>
        /// <param name="n">N.-th Fibonacci number.</param>
        /// <returns>Return the N.-th Fibonacci number.</returns>
        public static int NaiveRecursive(int n)
        {
            if (n is 0 or 1)
            {
                AdditionsCounter++;
                return n;
            }
            AdditionsCounter++;
            return NaiveRecursive(n - 1) + NaiveRecursive(n - 2);
        }

        /// <summary>
        ///     Fibonacci sequence (recursive with memoization) implementation DICT.
        /// </summary>
        /// <param name="n">N.-th Fibonacci number.</param>
        /// <returns>Return the N.-th Fibonacci number.</returns>
        public static int RecursiveWithMemoization(int n)
        {
            if (_dictMemory.Count == 0)
            {
                _dictMemory[0] = 0;
                _dictMemory[1] = 1;
                AdditionsCounter++;
            }

            if (_dictMemory.ContainsKey(n)) return _dictMemory[n];

            _dictMemory[n] = RecursiveWithMemoization(n - 1) + RecursiveWithMemoization(n - 2);
            AdditionsCounter++;

            return _dictMemory[n];
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
                    AdditionsCounter++;
                    return n;
                case 1:
                    return 1;
            }

            if (_arrayMemory[n] != 0) return _arrayMemory[n];

            _arrayMemory[n] = RecursiveWithMemoizationArray(n - 1) + RecursiveWithMemoizationArray(n - 2);
            AdditionsCounter++;

            return _arrayMemory[n];
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
