using System;
using System.Collections.Generic;
using System.Text;

namespace CellularAutomataConsole
{
    public class CMGenerator
    {
        public static int width = 128;
        public static int height = 80;
        public static int randomize = 48;

        private static Random rng = new Random();
        private static int[,] mapGrid = new int[width, height];

        // DEFAULT CONSTRUCTOR
        public CMGenerator()
        {
            rng = new Random();
            mapGrid = new int[width, height];
        }

        // CONSTRUCTOR OVERLOAD 1
        public CMGenerator(int w, int h, int r)
        {
            width = w;
            height = h;
            randomize = r;

            rng = new Random();
            mapGrid = new int[width, height];
        }

        // DRAW GRID TO CONSOLE
        public void drawGrid()
        {
            Console.Clear();
            Console.WriteLine();

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    if (mapGrid[i, j] == 1)
                        Console.Write("* ");
                    else
                        Console.Write("  ");
                }

                // NEW LINE
                Console.WriteLine();
            }

            // NEW LINE END
            Console.WriteLine();
            for (int i = 0; i < width; i++)
            {
                Console.Write("==");
            }
            Console.WriteLine("\n");

        }

        // RANDOMIZE CELLS
        public void randomizeGrid()
        {
            int rnd1;

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    if ((i == 0) || (i == width - 1) || (j == 0) || (j == height - 1))
                    {
                        mapGrid[i, j] = 1;
                    }
                    else
                    {
                        rnd1 = rng.Next(101);
                        if (rnd1 < randomize)
                            mapGrid[i, j] = 1;
                        else
                            mapGrid[i, j] = 0;
                    }
                }
            }
        }

        // GET NEIGHBOURS 1
        private int CellR1(int x1, int y1)
        {
            int n = 0;

            for (int i = x1-1; i <= x1+1; i++)
            {
                for (int j = y1-1; j <= y1+1; j++)
                {
                    // OUT OF BOUNDS CHECK
                    if ((i < 0) || (i > width-1) || (j < 0) || (j > height-1) )
                    {
                        n++;
                    }
                    else
                    {
                        if (mapGrid[i, j] == 1)
                            n++;
                    }
                }
            }

            // RETURN N
            return n;
        }

        // SMOOTHING
        public void Smooth1()
        {
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    if (CellR1(i, j) >= 5)
                        mapGrid[i, j] = 1;
                    else
                        mapGrid[i, j] = 0;
                }
            }
        }
    }
}
