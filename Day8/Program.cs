using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Day8
{
    class Program
    {
        static void Main()
        {
            string[] inputString = File.ReadAllLines("input.txt");

            string[] signal = new string[inputString.Length];
            string[] output = new string[inputString.Length];

            // divide line array to signal array and output array
            for (int i = 0; i < inputString.Length; i++)
            {
                string[] lineParts = inputString[i].Split(new char[] { '|' });

                signal[i] = lineParts[0];
                output[i] = lineParts[1];
            }

            Console.WriteLine("signal[0]:" + signal[0]);
            Console.WriteLine("output[0]:" + output[0]);

            // PART 1
            Console.WriteLine("\nPART1:\n");

            int digit1478 = 0;

            // split every output and add 1 to counter for every string with 2, 3, 4 or 7 characters
            for (int i = 0; i < output.Length; i++)
            {
                string[] outputDigits = output[i].Split(new char[] { ' ' });

                for (int j = 0; j < outputDigits.Length; j++)
                {
                    if (outputDigits[j].Length == 2)
                        digit1478++;
                    else if(outputDigits[j].Length == 3)
                        digit1478++;
                    else if (outputDigits[j].Length == 4)
                        digit1478++;
                    else if (outputDigits[j].Length == 7)
                        digit1478++;
                }
            }

            Console.WriteLine("Digit 1, 4, 7 or 8 appears " + digit1478 + " times in the output");

            // PART 2
            Console.WriteLine("\nPART2:");

            int outputTotal = 0;

            // we figure out every segment one by one from the seven-segment display
            for (int i = 0; i < signal.Length; i++)
            {
                // we store characters that appear with each number to figure out letters for each segment
                List<char> chars0 = new List<char>();
                List<char> chars1 = new List<char>();
                List<char> chars2 = new List<char>();
                List<char> chars3 = new List<char>();
                List<char> chars4 = new List<char>();
                List<char> chars5 = new List<char>();
                List<char> chars6 = new List<char>();
                List<char> chars7 = new List<char>();
                List<char> chars8 = new List<char>();
                List<char> chars9 = new List<char>();

                char segA = '0';
                char segB = '0';
                char segC = '0';
                char segD = '0';
                char segE = '0';
                char segF = '0';
                char segG = '0';

                string[] signalDigits = signal[i].Split(new char[] { ' ' });

                // characters in 1: only string with two characters
                for (int j = 0; j < signalDigits.Length; j++)
                {
                    string digit = signalDigits[j];

                    if (digit.Length == 2)
                    {
                        chars1.Add(digit[0]);
                        chars1.Add(digit[1]);
                        break;
                    }
                }

                // characters in 7: only string with 3 characters
                for (int j = 0; j < signalDigits.Length; j++)
                {
                    string digit = signalDigits[j];

                    if (digit.Length == 3)
                    {
                        chars7.Add(digit[0]);
                        chars7.Add(digit[1]);
                        chars7.Add(digit[2]);
                        break;
                    }
                }

                // segment A character: the character that appears in 7 but not in 1
                for (int j = 0; j < chars7.Count; j++)
                {
                    if (chars7[j] != chars1[0] && chars7[j] != chars1[1])
                        segA = chars7[j];
                }

                Console.WriteLine("\nline " + i + " seg A: " + segA);

                // characters in 8: only string with 7 characters
                for (int j = 0; j < signalDigits.Length; j++)
                {
                    string digit = signalDigits[j];

                    if (digit.Length == 7)
                    {
                        chars8.Add(digit[0]);
                        chars8.Add(digit[1]);
                        chars8.Add(digit[2]);
                        chars8.Add(digit[3]);
                        chars8.Add(digit[4]);
                        chars8.Add(digit[5]);
                        chars8.Add(digit[6]);
                        break;
                    }
                }

                // characters in 4: only string with 4 characters
                for (int j = 0; j < signalDigits.Length; j++)
                {
                    string digit = signalDigits[j];

                    if (digit.Length == 4)
                    {
                        chars4.Add(digit[0]);
                        chars4.Add(digit[1]);
                        chars4.Add(digit[2]);
                        chars4.Add(digit[3]);
                        break;
                    }
                }

                // characters in 6: only 6-letter string that doesn't iclude both 1:s characters
                for (int j = 0; j < signalDigits.Length; j++)
                {
                    string digit = signalDigits[j];

                    if (digit.Length == 6)
                    {
                        int counter = 0;

                        for (int k = 0; k < digit.Length; k++)
                        {
                            if (digit[k] == chars1[0] || digit[k] == chars1[1])
                                counter++;
                        }

                        if(counter == 1)
                        {
                            chars6.Add(digit[0]);
                            chars6.Add(digit[1]);
                            chars6.Add(digit[2]);
                            chars6.Add(digit[3]);
                            chars6.Add(digit[4]);
                            chars6.Add(digit[5]);
                            break;
                        }
                    }
                }

                // characters in 3: only 5-letter string that icludes both 1:s characters
                for (int j = 0; j < signalDigits.Length; j++)
                {
                    string digit = signalDigits[j];

                    if (digit.Length == 5)
                    {
                        int counter = 0;

                        for (int k = 0; k < digit.Length; k++)
                        {
                            if (digit[k] == chars1[0] || digit[k] == chars1[1])
                                counter++;
                        }

                        if (counter == 2)
                        {
                            chars3.Add(digit[0]);
                            chars3.Add(digit[1]);
                            chars3.Add(digit[2]);
                            chars3.Add(digit[3]);
                            chars3.Add(digit[4]);
                            break;
                        }
                    }
                }

                // characters in 5: only 5-character string that has all it's characters in 6
                for (int j = 0; j < signalDigits.Length; j++)
                {
                    string digit = signalDigits[j];

                    if (digit.Length == 5)
                    {
                        int counter = 0;

                        for (int k = 0; k < digit.Length; k++)
                        {
                            for (int m = 0; m < chars6.Count; m++)
                            {
                                if (digit[k] == chars6[m])
                                    counter++;
                            }
                        }

                        if (counter == 5)
                        {
                            chars5.Add(digit[0]);
                            chars5.Add(digit[1]);
                            chars5.Add(digit[2]);
                            chars5.Add(digit[3]);
                            chars5.Add(digit[4]);
                            break;
                        }
                    }
                }

                // segment E character: the character that appears in 6 but not in 5
                for (int j = 0; j < chars6.Count; j++)
                {
                    if (chars6[j] != chars5[0] && chars6[j] != chars5[1] && chars6[j] != chars5[2] && chars6[j] != chars5[3] && chars6[j] != chars5[4])
                        segE = chars6[j];
                }

                Console.WriteLine("line " + i + " seg E: " + segE);

                // characters in 2: only 5-character string that has segment E character
                for (int j = 0; j < signalDigits.Length; j++)
                {
                    string digit = signalDigits[j];

                    if (digit.Length == 5)
                    {
                        for (int k = 0; k < digit.Length; k++)
                        {
                            if (digit[k] == segE)
                            {
                                chars2.Add(digit[0]);
                                chars2.Add(digit[1]);
                                chars2.Add(digit[2]);
                                chars2.Add(digit[3]);
                                chars2.Add(digit[4]);
                                break;
                            }
                        }
                    }
                }

                // characters in 9: only 6-character string that doesn't have segment E character
                for (int j = 0; j < signalDigits.Length; j++)
                {
                    string digit = signalDigits[j];

                    if (digit.Length == 6)
                    {
                        int counter = 0;

                        for (int k = 0; k < digit.Length; k++)
                        {
                            if (digit[k] == segE)
                                counter++;
                        }

                        if (counter == 0)
                        {
                            chars9.Add(digit[0]);
                            chars9.Add(digit[1]);
                            chars9.Add(digit[2]);
                            chars9.Add(digit[3]);
                            chars9.Add(digit[4]);
                            chars9.Add(digit[5]);
                            break;
                        }
                    }
                }

                // segment C character: the character that appears in 8 but not in 6
                for (int j = 0; j < chars8.Count; j++)
                {
                    if (chars8[j] != chars6[0] && chars8[j] != chars6[1] && chars8[j] != chars6[2] && chars8[j] != chars6[3] && chars8[j] != chars6[4] && chars8[j] != chars6[5])
                        segC = chars8[j];
                }

                Console.WriteLine("line " + i + " seg C: " + segC);

                // segment B character: the character in 5 that doesn't appear in 3
                for (int j = 0; j < chars5.Count; j++)
                {
                    if (chars5[j] != chars3[0] && chars5[j] != chars3[1] && chars5[j] != chars3[2] && chars5[j] != chars3[3] && chars5[j] != chars3[4])
                        segB = chars5[j];
                }

                Console.WriteLine("line " + i + " seg B: " + segB);

                // segment F character: Segment C character is known, F is the other one in 1
                for (int j = 0; j < chars1.Count; j++)
                {
                    if (chars1[j] != segC)
                        segF = chars1[j];
                }

                Console.WriteLine("line " + i + " seg F: " + segF);

                // characters in 0: only 6-character string that has segment C and E characters
                for (int j = 0; j < signalDigits.Length; j++)
                {
                    string digit = signalDigits[j];

                    if (digit.Length == 6)
                    {
                        int counter = 0;

                        for (int k = 0; k < digit.Length; k++)
                        {
                            if (digit[k] == segE || digit[k] == segC)
                                counter++;
                        }

                        if (counter == 2)
                        {
                            chars0.Add(digit[0]);
                            chars0.Add(digit[1]);
                            chars0.Add(digit[2]);
                            chars0.Add(digit[3]);
                            chars0.Add(digit[4]);
                            chars0.Add(digit[5]);
                            break;
                        }
                    }
                }

                // segment D character: the character in 8 that doesn't appear in 0
                for (int j = 0; j < chars8.Count; j++)
                {
                    if (chars8[j] != chars0[0] && chars8[j] != chars0[1] && chars8[j] != chars0[2] && chars8[j] != chars0[3] && chars8[j] != chars0[4] && chars8[j] != chars0[5])
                        segD = chars8[j];
                }

                Console.WriteLine("line " + i + " seg D: " + segD);

                // segment G character: : the character in 8 that doesn't represent any other segment
                for (int j = 0; j < chars8.Count; j++)
                {
                    if (chars8[j] != segA && chars8[j] != segB && chars8[j] != segC && chars8[j] != segD && chars8[j] != segE && chars8[j] != segF)
                        segG = chars8[j];
                }

                Console.WriteLine("line " + i + " seg G: " + segG);

                // we solve output numbers one by one based on the letters
                string[] outputDigits = output[i].Split(new char[] { ' ' });
                string outputString = "";

                for (int j = 0; j < outputDigits.Length; j++)
                {
                    string digit = outputDigits[j];

                    if (digit.Length == 2)
                        outputString += '1';
                    else if (digit.Length == 3)
                        outputString += '7';
                    else if (digit.Length == 4)
                        outputString += '4';
                    else if (digit.Length == 7)
                        outputString += '8';
                    else if (digit.Length == 5 && digit.Contains(segC) && digit.Contains(segE))
                        outputString += '2';
                    else if (digit.Length == 5 && digit.Contains(segC) && digit.Contains(segF))
                        outputString += '3';
                    else if (digit.Length == 5 && digit.Contains(segB) && digit.Contains(segF))
                        outputString += '5';
                    else if (digit.Length == 6 && digit.Contains(segD) == false)
                        outputString += '0';
                    else if (digit.Length == 6 && digit.Contains(segD) && digit.Contains(segE))
                        outputString += '6';
                    else if (digit.Length == 6 && digit.Contains(segC) && digit.Contains(segD))
                        outputString += '9';
                }

                int outputInt = int.Parse(outputString);
                Console.WriteLine("line " + i + " output: " + outputInt);
                outputTotal += outputInt;
            }

            Console.WriteLine("\nSum of all output values: " + outputTotal);
            Console.ReadKey();
        }
    }
}
