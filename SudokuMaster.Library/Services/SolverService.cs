using SudokuMaster.Library.DataContracts;
using SudokuMaster.Library.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuMaster.Library.Services
{
    public class SolverService : ISolver
    {
        public int[,] Solve(int[,] template)
        {
            var newTemplate = new SudokuPosition[9, 9];

            CheckLength(template);

            for (int i = 0; i < template.GetLength(0); i++)
            {
                for (int j = 0; j < template.GetLength(1); j++)
                {
                    var n = GetNumber(template[i, j]);
                    var position = new SudokuPosition { Selected = n, IsPredefined = n.HasValue, Options = new List<int>() };
                    newTemplate[i, j] = position;
                }
            }

            return Solve(newTemplate);
        }

        public int[,] Solve(SudokuPosition[,] template)
        {
            var isDone = true;

            do
            {
                for (int i = 0; i < template.GetLength(0); i++)
                {
                    for (int j = 0; j < template.GetLength(1); j++)
                    {
                        if (!template[i, j].Selected.HasValue)
                        {
                            //isDone = false;

                            for (int n = 1; n <= 9; n++)
                            {
                                if (!IsAlreadySelected(template, i, j, n) && !IsInSameSquare(template, i, j, n))
                                {
                                    template[i, j].Options.Add(n);
                                }
                            }

                            if (template[i, j].Options.Count == 1)
                            {
                                var onlyNumber = template[i, j].Options.First();
                                template[i, j].Selected = template[i, j].Options.First();
                                RemoveFromOptions(template, i, j, onlyNumber);
                            }
                        }
                    }
                }
            } while (!isDone);

            return CompileResult(template);
        }

        private int? GetNumber(int n)
        {
            return n == 0 ? (int?)null : n;
        }

        private void CheckLength(int[,] a)
        {
            if (a.GetLength(0) != 9 || a.GetLength(1) != 9) throw new Exception("Sudoku template is not formatted correctly.");
        }

        private bool IsAlreadySelected(SudokuPosition[,] template, int column, int row, int n)
        {
            for (int i = 0; i < template.GetLength(0); i++)
            {
                if (template[i, row].Selected.HasValue && template[i, row].Selected.Value == n) return true;
            }

            for (int j = 0; j < template.GetLength(1); j++)
            {
                if (template[column, j].Selected.HasValue && template[column, j].Selected.Value == n) return true;
            }

            return false;
        }

        private bool IsInSameSquare(SudokuPosition[,] template, int column, int row, int n)
        {
            var colSquare = column / 3;
            var rowSquare = row / 3;

            var iniCol = colSquare * 3;
            var iniRow = rowSquare * 3;

            for (int i = iniCol; i < iniCol + 3; i++)
            {
                for (int j = iniRow; j < iniRow + 3; j++)
                {
                    if (template[i, j].Selected.HasValue && template[i, j].Selected.Value == n) return true;
                }
            }

            return false;
        }

        private void RemoveFromOptions(SudokuPosition[,] template, int column, int row, int n)
        {
            var colSquare = column / 3;
            var rowSquare = row / 3;

            var iniCol = colSquare * 3;
            var iniRow = rowSquare * 3;

            for (int i = iniCol; i < iniCol + 3; i++)
            {
                for (int j = iniRow; j < iniRow + 3; j++)
                {
                    template[i, j].Options.Remove(n);
                }
            }

            for (int i = 0; i < template.GetLength(0); i++)
            {
                template[i, row].Options.Remove(n);
            }

            for (int i = 0; i < template.GetLength(1); i++)
            {
                template[column, i].Options.Remove(n);
            }
        }

        private int[,] CompileResult(SudokuPosition[,] template)
        {
            var result = new int[9, 9];

            for (int i = 0; i < template.GetLength(0); i++)
            {
                for (int j = 0; j < template.GetLength(1); j++)
                {
                    result[i, j] = template[i, j].Selected.HasValue ? template[i, j].Selected.Value : 0;
                }
            }

            return result;
        }
    }
}
