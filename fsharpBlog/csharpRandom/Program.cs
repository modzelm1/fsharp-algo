using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace csharpRandom
{
    class Program
    {
        static void Main(string[] args)
        {
            //PreformShuffleTest();

            PerformAddTest();

            //PerformMultiplyTest();

            Console.ReadKey();
        }

        private static void PreformShuffleTest()
        {
            int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
            prinArray(a);
            shuffle(a);
            prinArray(a);

            Console.WriteLine();
        }

        private static void prinArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write(String.Format("{0:00}", item));
                Console.Write(" ");
            }
            Console.WriteLine();
        }

        private static void shuffle(int[] toShuffle)
        {
            var r = new Random(DateTime.Now.Millisecond);
            for (int cardIndex = 0, randomCardIndex = 0, tmp;
                    cardIndex < toShuffle.Length;
                    randomCardIndex = r.Next(cardIndex, toShuffle.Length - 1), cardIndex++)
            {
                tmp = toShuffle[randomCardIndex];
                toShuffle[randomCardIndex] = toShuffle[cardIndex];
                toShuffle[cardIndex] = tmp;
            }
        }


        private static void PerformAddTest()
        {
            int a = 12;
            int b = 47;
            int varMaxVal = 100;
            int resultSpace = varMaxVal + varMaxVal;
            int numberOfIterations = 1000;

            int sum = 0;
            for (int i = 0; i < numberOfIterations; i++)
            {
                sum += Add_Mk1(varMaxVal, a, b);
            }
            Console.WriteLine("Result Add_Mk1: " + sum / numberOfIterations);

            Console.WriteLine();

            sum = 0;
            for (int i = 0; i < numberOfIterations; i++)
            {
                sum += Add_Mk2(resultSpace, a, b);
            }
            Console.WriteLine("Result Add_Mk2: " + sum / numberOfIterations);
        }

        public static int Add_Mk1(int varMaxVal, int a, int b)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            int couter = 0;

            for (int i = 0; i < varMaxVal; i++)
            {
                int ra = r.Next(varMaxVal);
                if (ra < a)
                    couter++;
            }

            for (int i = 0; i < varMaxVal; i++)
            {
                int rb = r.Next(varMaxVal);
                if (rb < b)
                    couter++;
            }
            return couter;
        }

        public static int Add_Mk2(int resultSpaceSize, int a, int b)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            int couter = 0;

            for (int i = 0; i < resultSpaceSize; i++)
            {
                int ra = r.Next(resultSpaceSize);
                int rb = r.Next(resultSpaceSize);
                if (ra < a || rb < b)
                    couter++;
            }
            return couter;
        }


        private static void PerformMultiplyTest()
        {
            int a = 12;
            int b = 47;
            int varMaxVal = 100;
            int resultSpace = varMaxVal * varMaxVal;
            int numberOfIterations = 1000;

            int sum = 0;
            for (int i = 0; i < numberOfIterations; i++)
            {
                sum += Multiply(varMaxVal, resultSpace, a, b);
            }
            Console.WriteLine("Result Multiply: " + sum / numberOfIterations);

            Console.WriteLine();
        }

        private static int Multiply(int varMaxVal, int resultSpaceSize, int a, int b)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            int couter = 0;
            for (int i = 0; i < resultSpaceSize; i++)
            {
                int ra = r.Next(varMaxVal);
                int rb = r.Next(varMaxVal);
                if (ra < a && rb < b)
                    couter++;
            }
            return couter;
        }
    }
}
