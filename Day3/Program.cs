using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day3
{
    class Program
    {
        static void Main()
        {
            string[] inputString = File.ReadAllLines("input.txt");

            // PART 1

            // we use stringbuilder so that we can assign single letters to it
            StringBuilder gamma = new StringBuilder("abcdefghijkl");
            StringBuilder epsilon = new StringBuilder("abcdefghijkl");

            for (int j = 0; j < 12; j++)
            {
                int[] bit = new int[inputString.Length];

                for (int i = 0; i < inputString.Length; i++)
                {
                    string current = inputString[i];

                    // i defines length of array and j defines which letter is stored from each line
                    // needs parse, char to int makes character conversion 1 -> 49
                    bit[i] = int.Parse(current[j].ToString());
                }

                // we get most used and least used number from current bit array
                int most = (from item in bit group item by item into g orderby g.Count() descending select g.Key).First();
                int least = (from item in bit group item by item into g orderby g.Count() descending select g.Key).Last();

                // we assign single char to string(builder), char 49=1, char 48=0
                gamma[j] = Convert.ToChar(most+48);
                epsilon[j] = Convert.ToChar(least+48);
            }

            // stringbuilder -> string -> decimal int
            String gammaString = gamma.ToString();
            int gammaInt = Convert.ToInt32(gammaString, 2);

            String epsilonString = epsilon.ToString();
            int epsilonInt = Convert.ToInt32(epsilonString, 2);

            Console.WriteLine("gamma rate in binary: " + gammaString);
            Console.WriteLine("epsilon rate in binary: " + epsilonString);

            Console.WriteLine("\ngamma rate in decimal: " + gammaInt);
            Console.WriteLine("epsilon rate in decimal: " + epsilonInt);

            int power = gammaInt * epsilonInt;

            Console.WriteLine("\npower consumption in decimal: " + power);

            // PART 2

            List<string> oxygen = new List<string>(inputString);
            List<string> co2 = new List<string>(inputString);

            string oxygenString = "abcdefghijkl";
            string co2String = "abcdefghijkl";

            // oxygen iteration
            for (int k = 0; k < 12; k++)
            {
                int[] bit = new int[oxygen.Count];

                // going through bits for counts
                for (int l = 0; l < oxygen.Count; l++)
                {
                    string current = oxygen[l];

                    bit[l] = int.Parse(current[k].ToString());
                }

                int most = (from item in bit group item by item into g orderby g.Count() descending select g.Key).First();
                int least = (from item in bit group item by item into g orderby g.Count() descending select g.Key).Last();

                int zeros = bit.Count(x => x == 0);
                int ones = bit.Count(x => x == 1);

                // removing numbers that don't match the criteria
                for (int m = 0; m < oxygen.Count; )
                {
                    string current = oxygen[m];

                    int currentBit = int.Parse(current[k].ToString());

                    if (oxygen.Count == 1)
                        break;
                    else if (zeros == ones && currentBit == 0)
                        oxygen.RemoveAt(m);
                    else if (currentBit != most)
                        oxygen.RemoveAt(m);
                    else
                        m++;
                }

                if (oxygen.Count == 1)
                {
                    oxygenString = oxygen[0];
                    break;
                }
            }

            // CO2 iteration
            for (int n = 0; n < 12; n++)
            {
                int[] bit = new int[co2.Count];

                // going through bits for counts
                for (int o = 0; o < co2.Count; o++)
                {
                    string current = co2[o];

                    bit[o] = int.Parse(current[n].ToString());
                }

                int most = (from item in bit group item by item into g orderby g.Count() descending select g.Key).First();
                int least = (from item in bit group item by item into g orderby g.Count() descending select g.Key).Last();

                int zeros = bit.Count(x => x == 0);
                int ones = bit.Count(x => x == 1);

                // removing numbers that don't match the criteria
                for (int r = 0; r < co2.Count; )
                {
                    string current = co2[r];

                    int currentBit = int.Parse(current[n].ToString());

                    if (co2.Count == 1)
                        break;
                    if (zeros == ones && currentBit == 1)
                        co2.RemoveAt(r);
                    else if (currentBit != least)
                        co2.RemoveAt(r);
                    else
                        r++;
                }

                if (co2.Count == 1)
                {
                    co2String = co2[0];
                    break;
                }
            }

            // string -> decimal int
            int oxygenInt = Convert.ToInt32(oxygenString, 2);
            int co2Int = Convert.ToInt32(co2String, 2);

            Console.WriteLine("\noxygen generator rating in binary: " + oxygenString);
            Console.WriteLine("CO2 scrubber rating in binary: " + co2String);

            Console.WriteLine("\noxygen generator rating in decimal: " + oxygenInt);
            Console.WriteLine("CO2 scrubber rating in decimal: " + co2Int);

            int life = oxygenInt * co2Int;

            Console.WriteLine("\nlife support rating in decimal: " + life);
            Console.ReadKey();
        }
    }
}
