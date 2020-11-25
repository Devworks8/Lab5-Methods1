// Name: Christian Lachapelle
//  Student #: A00230066
//
//  Title: Lab 5 - Methods 1
//  Version: 1.0
//
//  Description: Lab 5 - Methods 1 Implementation
//
//
// Program.cs
//
//  Author:
//       Christian Lachapelle <lachapellec@gmail.com>
//
//  Copyright (c) 2020 
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;

namespace Lab5Methods1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            RunImplementation();
        }

        /// <summary>
        /// Run the implementation
        /// </summary>
        public static void RunImplementation()
        {
            Console.Clear();
            PrintResults<double, int>("Method Name -> Floor: The Floor of 7.87 is: ", Floor, 7.87);
            Console.WriteLine();
            PrintResults<int, bool>("Method Name -> FizzBuzz: Is 13 divisible by 2 and 7: ", FizzBuzz, 13);
            PrintResults<int, bool>("Method Name -> FizzBuzz: Is 28 divisible by 2 and 7: ", FizzBuzz, 28);
            Console.WriteLine();
            PrintResults<int, int, int>("Method Name -> Gcd: The GCD of 876000 and 2000000 is: ", Gcd, 876000, 2000000);
            PrintResults<int, int, int>("Method Name -> GcdRecursive: The GCD of 876000 and 2000000 is: ", GcdRecursive, 876000, 2000000);
            Console.WriteLine();
            PrintTestResults<int, int, long, bool>("Total time of the GCD while loop implementation (ms): ",
                TimeDeltaTest, 876000, 2000000, false);
            PrintTestResults<int, int, long, bool>("Total time of the GCD recursive implementation (ms): ",
                TimeDeltaTest, 876000, 2000000, true);
            Console.ReadKey(true);
        }

        /// <summary>
        /// Print Delta Time test results
        /// </summary>
        /// <typeparam name="ArgTypeOne">Argument datatype</typeparam>
        /// <typeparam name="ArgTypeTwo">Argument datatype</typeparam>
        /// <typeparam name="ReturnType">Argument datatype</typeparam>
        /// <typeparam name="IsRecursive">Argument datatype</typeparam>
        /// <param name="msg">Message to display</param>
        /// <param name="methodName">Name of method to run</param>
        /// <param name="numOne">Argument to pass to method</param>
        /// <param name="numTwo">Argument to pass to method</param>
        /// <param name="isRecursive">Recursion flag</param>
        private static void PrintTestResults<ArgTypeOne, ArgTypeTwo, ReturnType, IsRecursive>(
            string msg,
            Func<ArgTypeOne, ArgTypeTwo, IsRecursive, ReturnType> methodName,
            ArgTypeOne numOne,
            ArgTypeTwo numTwo,
            IsRecursive isRecursive)
        {
            Console.WriteLine(String.Format("{0,65}{1,-5}",msg, methodName(numOne, numTwo, isRecursive)));
        }

        /// <summary>
        /// Print the results of the method passed.
        /// </summary>
        /// <typeparam name="ArgType">Argument datatype</typeparam>
        /// <typeparam name="ReturnType">Return datatype</typeparam>
        /// <param name="msg">Message to display</param>
        /// <param name="methodName">Name of method to run</param>
        /// <param name="numOne">Argument to pass to method</param>
        public static void PrintResults<ArgType, ReturnType> (
            string msg,
            Func<ArgType, ReturnType> methodName,
            ArgType numOne)
        {
            Console.WriteLine(String.Format("{0,65}{1,-5}", msg, methodName(numOne)));
        }

        /// <summary>
        /// Print the results of the method passed.
        /// </summary>
        /// <typeparam name="ArgOneType">Argument datatype</typeparam>
        /// <typeparam name="ArgTwoType">Argument datatype</typeparam>
        /// <typeparam name="ReturnType">Return datatype</typeparam>
        /// <param name="msg">Message to display</param>
        /// <param name="methodName">Name of method to run</param>
        /// <param name="numOne">Argument to pass to method</param>
        /// <param name="numTwo">Argument to pass to method</param>
        public static void PrintResults<ArgOneType, ArgTwoType, ReturnType> (
            string msg,
            Func<ArgOneType, ArgTwoType, ReturnType> methodName,
            ArgOneType numOne,
            ArgTwoType numTwo)
        {
            Console.WriteLine(String.Format("{0,65}{1,-5}", msg, methodName(numOne, numTwo)));
        }

        /// <summary>
        /// Calculate total time the GCDs methods run
        /// </summary>
        /// <param name="numOne">Argument One</param>
        /// <param name="numTwo">Argument Two</param>
        /// <param name="isRecursive">Use recursive method</param>
        /// <returns>Total time in milliseconds</returns>
        private static long TimeDeltaTest ( int numOne, int numTwo, bool isRecursive)
        {
            DateTime start = DateTime.Now;
            if (isRecursive)
            {
                GcdRecursive(numOne, numTwo);
            }
            else
            {
                Gcd(numOne, numTwo);
            }
            DateTime end = DateTime.Now;
            return (long)(end - start).TotalMilliseconds;
        }

        /// <summary>
        /// Find the floor of a double
        /// </summary>
        /// <param name="num">Double value</param>
        /// <returns>Int floor</returns>
        private static int Floor(double num)
        {
            return (int)num;
        }

        /// <summary>
        /// Check if number is divisible by 2 and 7
        /// </summary>
        /// <param name="num">Number to check</param>
        /// <returns>True is divisible by 2 and 7</returns>
        private static bool FizzBuzz(int num)
        {
            if (num % 2 == 0 && num % 7 == 0) return true;
            else return false;
        }

        /// <summary>
        /// Return the Greatest Common Divisor
        /// </summary>
        /// <param name="numOne">First value</param>
        /// <param name="numTwo">Second value</param>
        /// <returns>The Greatest Common Divisor</returns>
        private static int Gcd(int numOne, int numTwo)
        {
            int valOne = numOne, valTwo = numTwo, previousRemainder;

            while (valTwo != 0)
            {
                previousRemainder = valTwo;
                valTwo = valOne % valTwo;
                valOne = previousRemainder;
            }
            return valOne;
        }

        /// <summary>
        /// Recursive implementation of GCD
        /// </summary>
        /// <param name="numOne">Argument value</param>
        /// <param name="numTwo">Argument value</param>
        /// <returns></returns>
        private static int GcdRecursive(int numOne, int numTwo)
        {
            if (numTwo != 0) return GcdRecursive(numTwo, numOne % numTwo);
            else return numOne;
        }
    }
}
