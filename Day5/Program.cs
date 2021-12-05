using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;


namespace Day5
{
    class Program
    {
        static void Main()
        {
            string[] inputString = File.ReadAllLines("input.txt");

            // arrays for x and y coordinates
            int[] x1 = new int[inputString.Length];
            int[] y1 = new int[inputString.Length];
            int[] x2 = new int[inputString.Length];
            int[] y2 = new int[inputString.Length];

            // lists for storing all points in any line
            List<int> xHit = new List<int>();
            List<int> yHit = new List<int>();

            // lists for storing all unique points with multiple lines hitting the point
            List<int> xMultiHit = new List<int>();
            List<int> yMultiHit = new List<int>();

            for (int i = 0; i < inputString.Length; i++)
            {
                string[] inputLine = inputString[i].Split(new char[] {',', '>'});

                inputLine[1] = Regex.Replace(inputLine[1], @" -", string.Empty);
                inputLine[2] = Regex.Replace(inputLine[2], @" ", string.Empty);

                x1[i] = int.Parse(inputLine[0]);
                y1[i] = int.Parse(inputLine[1]);
                x2[i] = int.Parse(inputLine[2]);
                y2[i] = int.Parse(inputLine[3]);

                // vertical lines
                if(x1[i] == x2[i])
                {
                    int x = x1[i];
                    int ySmaller = Math.Min(y1[i], y2[i]);
                    int yBigger = Math.Max(y1[i], y2[i]);

                    for (int y = ySmaller ; y <= yBigger; y++)
                    {
                        // add every point in line to hit list
                        xHit.Add(x);
                        yHit.Add(y);

                        Console.WriteLine(x + "\t" + y);

                        for (int h = 0; h < xHit.Count -1; h++)
                        {
                            // check if this same point is already in hit list
                            if (x == xHit[h] && y == yHit[h])
                            {
                                int counter = 0;

                                for (int m = 0; m < Math.Max(xMultiHit.Count, 1); m++)
                                {
                                    if(xMultiHit.Count == 0)
                                    {
                                        xMultiHit.Add(x);
                                        yMultiHit.Add(y);

                                        break;
                                    }
                                    // if this multihit point doesn't match with any multihit point that is already in multihit list, then add this point to the list
                                    else if(!(x == xMultiHit[m] && y == yMultiHit[m]))
                                    {
                                        counter++;
                                    }
                                }

                                if (counter == xMultiHit.Count)
                                {
                                    xMultiHit.Add(x);
                                    yMultiHit.Add(y);
                                }
                            }
                        }
                    }
                }
                // horizontal lines
                else if (y1[i] == y2[i])
                {
                    int y = y1[i];
                    int xSmaller = Math.Min(x1[i], x2[i]);
                    int xBigger = Math.Max(x1[i], x2[i]);

                    for (int x = xSmaller; x <= xBigger; x++)
                    {
                        // add every point in line to hit list
                        xHit.Add(x);
                        yHit.Add(y);

                        Console.WriteLine(x + "\t" + y);

                        for (int h = 0; h < xHit.Count -1; h++)
                        {
                            // check if this same point is already in hit list
                            if (x == xHit[h] && y == yHit[h])
                            {
                                int counter = 0;

                                for (int m = 0; m < Math.Max(xMultiHit.Count, 1) ; m++)
                                {

                                    if (xMultiHit.Count == 0)
                                    {
                                        xMultiHit.Add(x);
                                        yMultiHit.Add(y);

                                        break;
                                    }
                                    // if this multihit point doesn't match with any multihit point that is already in multihit list, then add this point to the list
                                    else if (!(x == xMultiHit[m] && y == yMultiHit[m]))
                                    {
                                        counter++;
                                    }
                                }

                                if(counter == xMultiHit.Count)
                                {
                                    xMultiHit.Add(x);
                                    yMultiHit.Add(y);
                                }
                            }
                        }
                    }
                }
                // diagonal lines
                else
                {
                    // we get every point in a diagonal line using its length and plus/minus direction
                    int length = Math.Abs(x1[i] - x2[i]) + 1;
                    int xDir = (x1[i] - x2[i]) / (length - 1);
                    int yDir = (y1[i] - y2[i]) / (length - 1);

                    for (int z = 0; z < length; z++)
                    {
                        int x = x1[i] - z * xDir;
                        int y = y1[i] - z * yDir;

                        // add every point in line to hit list
                        xHit.Add(x);
                        yHit.Add(y);

                        Console.WriteLine(x + "\t" + y);

                        for (int h = 0; h < xHit.Count - 1; h++)
                        {
                            // check if this same point is already in hit list
                            if (x == xHit[h] && y == yHit[h])
                            {
                                int counter = 0;

                                for (int m = 0; m < Math.Max(xMultiHit.Count, 1); m++)
                                {

                                    if (xMultiHit.Count == 0)
                                    {
                                        xMultiHit.Add(x);
                                        yMultiHit.Add(y);

                                        break;
                                    }
                                    // if this multihit point doesn't match with any multihit point that is already in multihit list, then add this point to the list
                                    else if (!(x == xMultiHit[m] && y == yMultiHit[m]))
                                    {
                                        counter++;
                                    }
                                }

                                if (counter == xMultiHit.Count)
                                {
                                    xMultiHit.Add(x);
                                    yMultiHit.Add(y);
                                }
                            }
                        }
                    }
                }
            }

            for (int n = 0; n < xMultiHit.Count; n++)
            {
                Console.WriteLine("\nmultihit: " + xMultiHit[n] + "\t" + yMultiHit[n]);
            }

            Console.WriteLine("\nAmount of multihits: " + xMultiHit.Count);
            Console.ReadKey();
        }
    }
}
