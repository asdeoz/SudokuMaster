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

            SetOptions(template);
            CheckForLastOption(template);

            const int forceBreakLimit = 15;
            var forceBreakCounter = 0;

            do
            {
                isDone = true;

                for (int i = 0; i < template.GetLength(0); i++)
                {
                    for (int j = 0; j < template.GetLength(1); j++)
                    {
                        if (!template[i,j].Selected.HasValue)
                        {
                            isDone = false;

                            int? foundIndex = null;

                            foreach (var n in template[i, j].Options)
                            {
                                if (IsOnlyOption(template, i, j, n))
                                {
                                    foundIndex = n;
                                    break;
                                }
                            }

                            if (foundIndex.HasValue)
                            {
                                template[i, j].Selected = foundIndex;
                                RemoveFromOptions(template, i, j, foundIndex.Value);
                            }
                        }
                    }
                }

                CheckForLastOption(template);

                forceBreakCounter++;
            } while (!isDone && forceBreakCounter < forceBreakLimit);

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

        private bool IsInSameLine(SudokuPosition[,] template, int row, int column, int n)
        {
            for (int i = 0; i < template.GetLength(0); i++)
            {
                if (template[i, column].Selected.HasValue && template[i, column].Selected.Value == n) return true;
            }

            for (int j = 0; j < template.GetLength(1); j++)
            {
                if (template[row, j].Selected.HasValue && template[row, j].Selected.Value == n) return true;
            }

            return false;
        }

        private bool IsOnlyOptionInLine(SudokuPosition[,] template, int row, int column, int n)
        {
            for (int i = 0; i < template.GetLength(0); i++)
            {
                if (i != row && template[i, column].Options.Contains(n)) return false;
            }

            for (int j = 0; j < template.GetLength(1); j++)
            {
                if (j != column && template[row, j].Options.Contains(n)) return false;
            }

            return true;
        }

        private bool IsInSameSquare(SudokuPosition[,] template, int row, int column, int n)
        {
            var colSquare = column / 3;
            var rowSquare = row / 3;

            var iniCol = colSquare * 3;
            var iniRow = rowSquare * 3;

            for (int i = iniRow; i < iniRow + 3; i++)
            {
                for (int j = iniCol; j < iniCol + 3; j++)
                {
                    if (template[i, j].Selected.HasValue && template[i, j].Selected.Value == n) return true;
                }
            }

            return false;
        }

        private bool IsOnlyOptionInSquare(SudokuPosition[,] template, int row, int column, int n)
        {
            var colSquare = column / 3;
            var rowSquare = row / 3;

            var iniCol = colSquare * 3;
            var iniRow = rowSquare * 3;

            for (int i = iniRow; i < iniRow + 3; i++)
            {
                for (int j = iniCol; j < iniCol + 3; j++)
                {
                    if ((i != row || j != column) && template[i, j].Options.Contains(n)) return false;
                }
            }

            return true;
        }

        private void SetOptions(SudokuPosition[,] template)
        {
            for (int i = 0; i < template.GetLength(0); i++)
            {
                for (int j = 0; j < template.GetLength(1); j++)
                {
                    if (!template[i, j].Selected.HasValue)
                    {
                        for (int n = 1; n <= 9; n++)
                        {
                            if (!IsInSameLine(template, i, j, n) && !IsInSameSquare(template, i, j, n))
                            {
                                template[i, j].Options.Add(n);
                            }
                        }
                    }
                }
            }
        }

        private void CheckForLastOption(SudokuPosition[,] template)
        {
            for (int i = 0; i < template.GetLength(0); i++)
            {
                for (int j = 0; j < template.GetLength(1); j++)
                {
                    if (!template[i, j].Selected.HasValue)
                    {
                        if (template[i, j].Options.Count == 1)
                        {
                            var onlyNumber = template[i, j].Options.First();
                            template[i, j].Selected = onlyNumber;
                            RemoveFromOptions(template, i, j, onlyNumber);
                        }
                    }
                }
            }
        }

        private bool IsOnlyOption(SudokuPosition[,] template, int row, int column, int n)
        {
            return (IsOnlyOptionInLine(template, row, column, n) || IsOnlyOptionInSquare(template, row, column, n));
        }

        private void RemoveFromOptions(SudokuPosition[,] template, int row, int column, int n)
        {
            var colSquare = column / 3;
            var rowSquare = row / 3;

            var iniCol = colSquare * 3;
            var iniRow = rowSquare * 3;

            for (int i = iniRow; i < iniRow + 3; i++)
            {
                for (int j = iniCol; j < iniCol + 3; j++)
                {
                    template[i, j].Options.Remove(n);
                }
            }

            for (int i = 0; i < template.GetLength(0); i++)
            {
                template[i, column].Options.Remove(n);
            }

            for (int j = 0; j < template.GetLength(1); j++)
            {
                template[row, j].Options.Remove(n);
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
