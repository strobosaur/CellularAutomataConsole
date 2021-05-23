using System;

namespace CellularAutomataConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int liveChance;
            bool runProgram = true;
            bool newIteration = true;

            while (runProgram)
            {
                Console.Write("\n\tLive cell chance (1-100): ");
                int.TryParse(Console.ReadLine(), out liveChance);
                Console.WriteLine();

                CMGenerator generator = new CMGenerator(80, 80, liveChance);

                generator.randomizeGrid();
                generator.drawGrid();
                Console.WriteLine("\n\tPress any key...");
                Console.ReadKey();

                do
                {
                    generator.Smooth1();
                    generator.drawGrid();
                    Console.Write("\tNew iteration? (y/n): ");
                    newIteration = (Console.ReadLine() != "n");
                    Console.WriteLine();
                } while (newIteration);

                Console.Clear();

                Console.Write("\n\tNew map? (y/n): ");
                runProgram = (Console.ReadLine() != "n");
                Console.WriteLine();
            }
        }
    }
}
