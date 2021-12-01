using System;
using System.IO;

// includes D1P2

namespace D1P1
{
    class Program
    {
        static void Main()
        {
            // gets whole text from file, found in \bin\debug
            string inputString = File.ReadAllText("input.txt");

            // converts text to array of strings
            // fileContent.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string[] stringArray = inputString.Split(new char[] { '\n' });

            int[] intArray = new int[stringArray.Length];

            // converts string to int
            for (int i = 0; i<stringArray.Length; i++)
            {
                intArray[i] = int.Parse(stringArray[i]);
            }

            Console.WriteLine("amount of inputs: " + intArray.Length);

            int n = 0;

            // if previous number is smaller, add 1 to counter n
            for (int i = 1; i < intArray.Length; i++)
            {
                if (intArray[i] > intArray[i - 1])
                {
                    n++;
                }
            }

            Console.WriteLine("amount of depth increases: " + n);

            int m = 0;

            // if previous window of 3 is smaller than current window of 3, add 1 to counter m
            for (int i = 3; i < intArray.Length; i++)
            {
                int firstWindow = intArray[i - 3] + intArray[i - 2] + intArray[i - 1];
                int secondWindow = intArray[i - 2] + intArray[i - 1] + intArray[i];

                if(secondWindow > firstWindow)
                {
                    m++;
                }
            }

            Console.WriteLine("amount of depth increases in windows of 3: " + m);
            Console.ReadKey();
        }
    }
}
