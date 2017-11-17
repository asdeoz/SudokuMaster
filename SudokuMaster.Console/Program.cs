using SudokuMaster.Library.Services;
using System;

namespace SudokuMaster.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = TestData.TestData.GetTemplate(TestData.SudokuTemplates.Template2);

            PrintTemplate(t);

            var solver = new SolverService();

            t = solver.Solve(t);

            PrintTemplate(t);

            System.Console.ReadLine();
        }

        private static void PrintTemplate(int[,] t)
        {
            for (int i = 0; i < t.GetLength(0); i++)
            {
                for (int j = 0; j < t.GetLength(1); j++)
                {
                    System.Console.Write("[{0}]", t[i, j] == 0 ? " " : t[i, j].ToString());
                }
                System.Console.WriteLine();
            }

            System.Console.WriteLine();
        }
    }
}
