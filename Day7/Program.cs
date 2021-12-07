using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    class Program
    {
        static void Main()
        {
            // gather input numbers to int array
            string inputString = System.IO.File.ReadAllText("input.txt");
            string[] stringArray = inputString.Split(new char[] { ',' });

            int[] intArray = new int[stringArray.Length];

            for (int i = 0; i < stringArray.Length; i++)
            {
                intArray[i] = int.Parse(stringArray[i]);
            }

            Array.Sort(intArray);
            Console.WriteLine("Amount of crabs: " + intArray.Length);

            // PART 1
            Console.WriteLine("\nPART 1:");

            int median = intArray[intArray.Length / 2];
            Console.WriteLine("\nMiddle number (median) in sorted array: " + median);

            int fuel = 0;

            // we go through every crab position and add distance between crab and median to total fuel spent
            for (int i = 0; i < intArray.Length; i++)
            {
                fuel += Math.Abs(median - intArray[i]);
            }

            Console.WriteLine("\nTotal fuel spent: " + fuel);

            // PART 2
            Console.WriteLine("\nPART 2:");

            int average = intArray.Sum() / intArray.Length;
            Console.WriteLine("\naverage: " + average);

            int averageLow = average - 1;
            int averageHigh = average + 1;

            int[] averages = { averageLow, average, averageHigh };

            // we get answers for average and we also check average-1 and average+1
            for (int k = 0; k < averages.Length; k++)
            {
                fuel = 0;

                // we go through every crab position and add increasing fuel spent based on distance between crab and average
                for (int i = 0; i < intArray.Length; i++)
                {
                    int distance = Math.Abs(averages[k] - intArray[i]);

                    for (int j = 0; j <= distance; j++)
                    {
                        fuel += j;
                    }
                }

                Console.WriteLine("\nTotal fuel spent with position " + averages[k].ToString() + ": " + fuel);
            }

            Console.ReadKey();
        }
    }
}
