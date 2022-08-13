using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {

        public static int Proplem(int[] S, int m, int n)
        {
            if (n == 0)
                return 1;

            // If n is less than 0 then no
            // solution exists
            if (n < 0)
                return 0;

            // If there are no coins and n
            // is greater than 0, then no
            // solution exist
            if (m <= 0)
                return 0;

            // count is sum of solutions (i)
            // including S[m-1] (ii) excluding S[m-1]
            return Proplem(S, m - 1, n) +
                Proplem(S, m, n - S[m - 1]);
        }

        public static bool check(String str)
        {
            if (str == null || str.Length != 0)
            {
                return true;
            }

            Dictionary<char, int> map = new Dictionary<char, int>();

            // Run loop form 0 to length of string
            for (int i = 0; i < str.Length; i++)
            {
                if (map.ContainsKey(str[i]))
                    map[str[i]] = map[str[i]] + 1;
                else
                    map.Add(str[i], 1);
            }

            // declaration of variables
            bool first = true, second = true;
            int val1 = 0, val2 = 0;
            int countOfVal1 = 0, countOfVal2 = 0;

            foreach (KeyValuePair<char, int> itr in map)
            {
                int i = itr.Key;

                // if first is true than countOfVal1 increase
                if (first)
                {
                    val1 = i;
                    first = false;
                    countOfVal1++;
                    continue;
                }

                if (i == val1)
                {
                    countOfVal1++;
                    continue;
                }

                // if second is true than countOfVal2 increase
                if (second)
                {
                    val2 = i;
                    countOfVal2++;
                    second = false;
                    continue;
                }

                if (i == val2)
                {
                    countOfVal2++;
                    continue;
                }

                return false;
            }

            if (countOfVal1 > 1 && countOfVal2 > 1)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        static void Main(string[] args)
        {
           
            int[] arr = { 2, 5, 3, 6 };
            int m = arr.Length;
            Console.WriteLine(Proplem(arr, m, 10));
            Console.WriteLine(check("abcbc"));
            Console.ReadLine();
        }
    }
}
