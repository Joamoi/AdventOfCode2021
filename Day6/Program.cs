using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Day6
{
    class Program
    {
        static void Main()
        {
            // gather input numbers to int array
            string inputString = File.ReadAllText("input.txt");
            string[] stringArray = inputString.Split(new char[] { ',' });

            int[] fishArray = new int[stringArray.Length];

            for (int i = 0; i < stringArray.Length; i++)
            {
                fishArray[i] = int.Parse(stringArray[i]);

                Console.Write(fishArray[i] + ", ");
            }

            // PART 1

            Console.WriteLine("\n\nPART 1:\n");

            List<int> fish = new List<int>(fishArray);

            // every day reduct one from every fish value and create 6 and 8 if number goes below zero
            for (int i = 0; i < 80; i++)
            {
                for (int j = fish.Count - 1; j > -1; j--)
                {
                    fish[j]--;

                    if(fish[j] < 0)
                    {
                        fish[j] = 6;
                        fish.Add(8);
                    }
                }

                Console.WriteLine("fish amount after " + (i+1) + " days: " + fish.Count);
            }

            Console.WriteLine("\nTotal fish amount: " + fish.Count);

            // PART 2

            // we run out of memory if we loop daily changes, so instead we loop weekly changes

            Console.WriteLine("\nPART 2:\n");

            fish = new List<int>(fishArray);

            // little loop to day 4 at the beginning so that we get to exact day 256 ( 4 + 36 * 7 = 256 )
            for (int i = 0; i < 4; i++)
            {
                for (int j = fish.Count - 1; j > -1; j--)
                {
                    fish[j]--;

                    if (fish[j] < 0)
                    {
                        fish[j] = 6;
                        fish.Add(8);
                    }
                }

                Console.WriteLine("fish amount after " + (i + 1) + " days: " + fish.Count);
            }

            // fish0 is amount of fish with value 0, fish1 is amount of fish with value 1, etc.
            ulong fish0 = (ulong)fish.Count(x => x == 0);
            ulong fish1 = (ulong)fish.Count(x => x == 1);
            ulong fish2 = (ulong)fish.Count(x => x == 2);
            ulong fish3 = (ulong)fish.Count(x => x == 3);
            ulong fish4 = (ulong)fish.Count(x => x == 4);
            ulong fish5 = (ulong)fish.Count(x => x == 5);
            ulong fish6 = (ulong)fish.Count(x => x == 6);
            ulong fish7 = (ulong)fish.Count(x => x == 7);
            ulong fish8 = (ulong)fish.Count(x => x == 8);

            ulong newFish0 = 0;
            ulong newFish1 = 0;
            ulong newFish2 = 0;
            ulong newFish3 = 0;
            ulong newFish4 = 0;
            ulong newFish5 = 0;
            ulong newFish6 = 0;
            ulong newFish7 = 0;
            ulong newFish8 = 0;

            // from day 4 we loop 36 weeks to get to day 256
            // changes after a week for every fish number:
            // 0 -> 0 and 2     ->      amount of 0 gets added to amount of 2
            // 1 -> 1 and 3     ->      amount of 1 gets added to amount of 3
            // 2 -> 2 and 4     ->      amount of 2 gets added to amount of 4
            // 3 -> 3 and 5     ->      amount of 3 gets added to amount of 5
            // 4 -> 4 and 6     ->      amount of 4 gets added to amount of 6
            // 5 -> 5 and 7     ->      amount of 5 gets added to amount of 7
            // 6 -> 6 and 8     ->      amount of 6 gets added to amount of 8
            // 7 -> 0           ->      amount of 7 gets added to amount of 0, old sevens are gone
            // 8 -> 1           ->      amount of 8 gets added to amount of 1, old eights are gone
            for (int i = 0; i < 36; i ++)
            {
                newFish0 = fish7;
                newFish1 = fish8;
                newFish2 = fish0;
                newFish3 = fish1;
                newFish4 = fish2;
                newFish5 = fish3;
                newFish6 = fish4;
                newFish7 = fish5;
                newFish8 = fish6;

                fish0 += newFish0;
                fish1 += newFish1;
                fish2 += newFish2;
                fish3 += newFish3;
                fish4 += newFish4;
                fish5 += newFish5;
                fish6 += newFish6;
                fish7 = newFish7;
                fish8 = newFish8;

                Console.WriteLine("\nAfter " + (i+1) + " weeks:\t0: " + fish0 + ", 1: " + fish1 + ", 2: " + fish2 + ", 3: " + fish3 + ", 4: " + fish4);
                Console.WriteLine("\nAfter " + (i + 1) + " weeks:\t5: " + fish5 + ", 6: " + fish6 + ", 7: " + fish7 + ", 8: " + fish8);
            }

            ulong fishTotal = fish0 + fish1 + fish2 + fish3 + fish4 + fish5 + fish6 + fish7 + fish8;

            Console.WriteLine("\n36 x 7 days later ->");
            Console.WriteLine("\nTotal fish amount: " + fishTotal);
            Console.WriteLine("\n0: " + fish0 + ", 1: " + fish1 + ", 2: " + fish2 + ", 3: " + fish3 + ", 4: " + fish4 + ", 5: " + fish5 + ", 6: " + fish6 + ", 7: " + fish7 + ", 8: " + fish8);
            Console.ReadKey();
        }
    }
}
