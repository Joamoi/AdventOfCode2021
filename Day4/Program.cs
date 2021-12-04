using System;
using System.Linq;
using System.IO;

namespace Day4
{
    class Program
    {
        static void Main()
        {
            // create int array from all draw numbers
            string drawsString = File.ReadAllText("input1.txt");
            string[] drawsArray = drawsString.Split(new char[] { ',' });

            int[] draws = new int[drawsArray.Length];

            for (int i = 0; i < drawsArray.Length; i++)
            {
                draws[i] = int.Parse(drawsArray[i]);

                Console.WriteLine("draw " + i + ": " + draws[i]);
            }

            // create int array from all board numbers
            string boardString = File.ReadAllText("input2.txt");
            string[] boardArray = boardString.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            int[] board = new int[boardArray.Length];

            for (int i = 0; i < boardArray.Length; i++)
            {
                board[i] = int.Parse(boardArray[i]);
            }

            // create variables for storing best board data
            int[] best = new int[2] { 1000, 1000 };

            int[] bestRow1 = new int[5] { 100, 100, 100, 100, 100 };
            int[] bestRow2 = new int[5] { 100, 100, 100, 100, 100 };
            int[] bestRow3 = new int[5] { 100, 100, 100, 100, 100 };
            int[] bestRow4 = new int[5] { 100, 100, 100, 100, 100 };
            int[] bestRow5 = new int[5] { 100, 100, 100, 100, 100 };

            int winningDraw = 100;

            // create variables for storing worst board data
            int[] worst = new int[2] { 1000, -1000 };

            int[] worstRow1 = new int[5] { 100, 100, 100, 100, 100 };
            int[] worstRow2 = new int[5] { 100, 100, 100, 100, 100 };
            int[] worstRow3 = new int[5] { 100, 100, 100, 100, 100 };
            int[] worstRow4 = new int[5] { 100, 100, 100, 100, 100 };
            int[] worstRow5 = new int[5] { 100, 100, 100, 100, 100 };

            int losingDraw = 100;

            int n = 0;

            // i increases by 25 for storing 5x5 board
            for (int i = 24; i < board.Length; i += 25)
            {
                bool columnWin = false;

                // create "empty" board for storing hits
                int[] hits1 = new int[5] { 100, 100, 100, 100, 100 };
                int[] hits2 = new int[5] { 100, 100, 100, 100, 100 };
                int[] hits3 = new int[5] { 100, 100, 100, 100, 100 };
                int[] hits4 = new int[5] { 100, 100, 100, 100, 100 };
                int[] hits5 = new int[5] { 100, 100, 100, 100, 100 };

                // set right numbers for current board from array with board numbers
                int[] row1 = new int[5] { board[i - 24], board[i - 23], board[i - 22], board[i - 21], board[i - 20] };
                int[] row2 = new int[5] { board[i - 19], board[i - 18], board[i - 17], board[i - 16], board[i - 15] };
                int[] row3 = new int[5] { board[i - 14], board[i - 13], board[i - 12], board[i - 11], board[i - 10] };
                int[] row4 = new int[5] { board[i - 9], board[i - 8], board[i - 7], board[i - 6], board[i - 5] };
                int[] row5 = new int[5] { board[i - 4], board[i - 3], board[i - 2], board[i - 1], board[i] };

                Console.WriteLine("\nboard " + n + ": \t" + row1[0] + "\t" + row1[1] + "\t" + row1[2] + "\t" + row1[3] + "\t" + row1[4]);
                Console.WriteLine("         \t" + row2[0] + "\t" + row2[1] + "\t" + row2[2] + "\t" + row2[3] + "\t" + row2[4]);
                Console.WriteLine("         \t" + row3[0] + "\t" + row3[1] + "\t" + row3[2] + "\t" + row3[3] + "\t" + row3[4]);
                Console.WriteLine("         \t" + row4[0] + "\t" + row4[1] + "\t" + row4[2] + "\t" + row4[3] + "\t" + row4[4]);
                Console.WriteLine("         \t" + row5[0] + "\t" + row5[1] + "\t" + row5[2] + "\t" + row5[3] + "\t" + row5[4]);

                // goes through drawn numbers for current board
                for (int j = 0; j < draws.Length; j++)
                {
                    Console.WriteLine("draw " + j + ": " + draws[j]);

                    // checks if current board contains drawn number
                    if (row1.Contains(draws[j]))
                    {
                        int index = Array.IndexOf(row1, draws[j]);
                        hits1[index] = draws[j];
                        Console.WriteLine("hit, row 1 column " + index);
                    }
                    if (row2.Contains(draws[j]))
                    {
                        int index = Array.IndexOf(row2, draws[j]);
                        hits2[index] = draws[j];
                        Console.WriteLine("hit, row 2 column " + index);
                    }
                    if (row3.Contains(draws[j]))
                    {
                        int index = Array.IndexOf(row3, draws[j]);
                        hits3[index] = draws[j];
                        Console.WriteLine("hit, row 3 column " + index);
                    }
                    if (row4.Contains(draws[j]))
                    {
                        int index = Array.IndexOf(row4, draws[j]);
                        hits4[index] = draws[j];
                        Console.WriteLine("hit, row 4 column " + index);
                    }
                    if (row5.Contains(draws[j]))
                    {
                        int index = Array.IndexOf(row5, draws[j]);
                        hits5[index] = draws[j];
                        Console.WriteLine("hit, row 5 column " + index);
                    }

                    // checks if any row is complete and stores board data if its best or worst board so far
                    if (hits1.Count(s => s == 100) == 0 || hits2.Count(s => s == 100) == 0 || hits3.Count(s => s == 100) == 0 || hits4.Count(s => s == 100) == 0 || hits5.Count(s => s == 100) == 0)
                    {
                        if(j < best[1])
                        {
                            best[0] = n;
                            best[1] = j;
                            bestRow1 = row1;
                            bestRow2 = row2;
                            bestRow3 = row3;
                            bestRow4 = row4;
                            bestRow5 = row5;
                            winningDraw = draws[j];

                            Console.WriteLine("\nnew best, row win, board " + n + ", draw " + j);
                        }
                        if(j > worst[1])
                        {
                            worst[0] = n;
                            worst[1] = j;
                            worstRow1 = row1;
                            worstRow2 = row2;
                            worstRow3 = row3;
                            worstRow4 = row4;
                            worstRow5 = row5;
                            losingDraw = draws[j];

                            Console.WriteLine("\nnew worst, row win, board " + n + ", draw " + j);
                        }
                        
                        
                        break;
                    }

                    // checks if any column is complete and stores board data if its best or worst board so far
                    for (int k = 0; k < 5; k++)
                    {
                        if (hits1[k] != 100 && hits2[k] != 100 && hits3[k] != 100 && hits4[k] != 100 && hits5[k] != 100)
                        {
                            if (j < best[1])
                            {
                                best[0] = n;
                                best[1] = j;
                                bestRow1 = row1;
                                bestRow2 = row2;
                                bestRow3 = row3;
                                bestRow4 = row4;
                                bestRow5 = row5;
                                winningDraw = draws[j];
                                columnWin = true;

                                Console.WriteLine("\nnew best, column win, board " + n + ", draw " + j);
                            }
                            if (j > worst[1])
                            {
                                worst[0] = n;
                                worst[1] = j;
                                worstRow1 = row1;
                                worstRow2 = row2;
                                worstRow3 = row3;
                                worstRow4 = row4;
                                worstRow5 = row5;
                                losingDraw = draws[j];
                                columnWin = true;

                                Console.WriteLine("\nnew worst, column win, board " + n + ", draw " + j);
                            }
                        }
                    }

                    if (columnWin)
                        break;
                }

                n++;
            }

            // part 1 end calculations and reports

            Console.WriteLine("\nbest board : " + best[0]);
            Console.WriteLine("number of draws: " + best[1]);

            Console.WriteLine("\nboard " + best[0] + ": \t" + bestRow1[0] + "\t" + bestRow1[1] + "\t" + bestRow1[2] + "\t" + bestRow1[3] + "\t" + bestRow1[4]);
            Console.WriteLine("         \t" + bestRow2[0] + "\t" + bestRow2[1] + "\t" + bestRow2[2] + "\t" + bestRow2[3] + "\t" + bestRow2[4]);
            Console.WriteLine("         \t" + bestRow3[0] + "\t" + bestRow3[1] + "\t" + bestRow3[2] + "\t" + bestRow3[3] + "\t" + bestRow3[4]);
            Console.WriteLine("         \t" + bestRow4[0] + "\t" + bestRow4[1] + "\t" + bestRow4[2] + "\t" + bestRow4[3] + "\t" + bestRow4[4]);
            Console.WriteLine("         \t" + bestRow5[0] + "\t" + bestRow5[1] + "\t" + bestRow5[2] + "\t" + bestRow5[3] + "\t" + bestRow5[4]);

            // puts all numbers from winning board to one array
            int[] bestRowArray = new int[25];
            bestRow1.CopyTo(bestRowArray, 0);
            bestRow2.CopyTo(bestRowArray, 5);
            bestRow3.CopyTo(bestRowArray, 10);
            bestRow4.CopyTo(bestRowArray, 15);
            bestRow5.CopyTo(bestRowArray, 20);

            // makes all hit numbers zero for sum counting
            for (int j = 0; j < best[1]+1; j++)
            {
                if (bestRowArray.Contains(draws[j]))
                {
                    int index2 = Array.IndexOf(bestRowArray, draws[j]);
                    bestRowArray[index2] = 0;
                }
            }

            int sum = bestRowArray.Sum();
            int score = sum * winningDraw;

            Console.WriteLine("\nsum of remaining numbers: " + sum);
            Console.WriteLine("winning number: " + winningDraw);
            Console.WriteLine("final score: " + score);

            // part 2 end calculations and reports

            Console.WriteLine("\nworst board : " + worst[0]);
            Console.WriteLine("number of draws: " + worst[1]);

            Console.WriteLine("\nboard " + worst[0] + ": \t" + worstRow1[0] + "\t" + worstRow1[1] + "\t" + worstRow1[2] + "\t" + worstRow1[3] + "\t" + worstRow1[4]);
            Console.WriteLine("         \t" + worstRow2[0] + "\t" + worstRow2[1] + "\t" + worstRow2[2] + "\t" + worstRow2[3] + "\t" + worstRow2[4]);
            Console.WriteLine("         \t" + worstRow3[0] + "\t" + worstRow3[1] + "\t" + worstRow3[2] + "\t" + worstRow3[3] + "\t" + worstRow3[4]);
            Console.WriteLine("         \t" + worstRow4[0] + "\t" + worstRow4[1] + "\t" + worstRow4[2] + "\t" + worstRow4[3] + "\t" + worstRow4[4]);
            Console.WriteLine("         \t" + worstRow5[0] + "\t" + worstRow5[1] + "\t" + worstRow5[2] + "\t" + worstRow5[3] + "\t" + worstRow5[4]);

            // puts all numbers from winning board to one array
            int[] worstRowArray = new int[25];
            worstRow1.CopyTo(worstRowArray, 0);
            worstRow2.CopyTo(worstRowArray, 5);
            worstRow3.CopyTo(worstRowArray, 10);
            worstRow4.CopyTo(worstRowArray, 15);
            worstRow5.CopyTo(worstRowArray, 20);

            // makes all hit numbers zero for sum counting
            for (int j = 0; j < worst[1] + 1; j++)
            {
                if (worstRowArray.Contains(draws[j]))
                {
                    int index2 = Array.IndexOf(worstRowArray, draws[j]);
                    worstRowArray[index2] = 0;
                }
            }

            int sum2 = worstRowArray.Sum();
            int score2 = sum2 * losingDraw;

            Console.WriteLine("\nsum of remaining numbers: " + sum2);
            Console.WriteLine("winning number: " + losingDraw);
            Console.WriteLine("final score: " + score2);
            Console.ReadKey();
        }
    }
}
