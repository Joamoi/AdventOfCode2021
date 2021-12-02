using System;
using System.IO;

namespace Day2
{
    class Program
    {
        static void Main()
        {
            // store lines of a text in an array
            string[] inputString = File.ReadAllLines("input.txt");

            string[] direction = new string[inputString.Length];
            int[] value = new int[inputString.Length];

            int x = 0;
            int depth = 0;

            // splits every line and stores directions and values in separate arrays
            for (int i = 0; i<inputString.Length; i++)
            {
                string[] item = inputString[i].Split(' ');
                direction[i] = item[0];
                value[i] = int.Parse(item[1]);
            }

            // PART 1

            for (int i = 0; i < inputString.Length; i++)
            {
                if (direction[i] == "forward")
                    x += value[i];
                else if (direction[i] == "down")
                    depth += value[i];
                else if (direction[i] == "up")
                    depth -= value[i];
            }

            Console.WriteLine("PART 1:\n");
            Console.WriteLine("horizontal position in the end: " + x);
            Console.WriteLine("depth in the end: " + depth);
            Console.WriteLine("depth multiplied by horiz. position: " + x*depth);

            // PART 2

            int aim = 0;
            x = 0;
            depth = 0;

            for (int i = 0; i < inputString.Length; i++)
            {
                if (direction[i] == "forward")
                {
                    x += value[i];
                    depth += value[i] * aim;
                }
                   
                else if (direction[i] == "down")
                    aim += value[i];
                else if (direction[i] == "up")
                    aim -= value[i];
            }

            Console.WriteLine("\nPART 2:\n");
            Console.WriteLine("horizontal position in the end: " + x);
            Console.WriteLine("depth in the end: " + depth);
            Console.WriteLine("depth multiplied by horiz. position: " + x * depth);
            Console.ReadKey();
        }
    }
}
