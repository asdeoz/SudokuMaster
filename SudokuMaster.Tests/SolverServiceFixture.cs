using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuMaster.Library.ServiceContracts;
using SudokuMaster.Library.Services;
using System;

namespace SudokuMaster.Tests
{
    [TestClass]
    public class SolverServiceFixture
    {
        private readonly ISolver _solver;
        private readonly int[,] _template1;
        private readonly int[,] _template2;

        public SolverServiceFixture()
        {
            _solver = new SolverService();
            _template1 = TestData.TestData.GetTemplate(TestData.SudokuTemplates.Template1);
            _template2 = TestData.TestData.GetTemplate(TestData.SudokuTemplates.Template2);
        }

        [TestMethod]
        public void SolverWorks()
        {
            var tSolved = _solver.Solve(_template1);

            Assert.IsTrue(CheckTemplate(tSolved), "The Sudoku couldn't be solved.");
        }

        [TestMethod]
        public void SolverDetectsBadFormattingInColumns()
        {
            var template1 = new int[10, 9];
            var template2 = new int[9, 10];

            Assert.ThrowsException<Exception>(() => _solver.Solve(template1), "It should throw an exception for template1");
            Assert.ThrowsException<Exception>(() => _solver.Solve(template2), "It should throw an exception for template2");
        }

        private bool CheckTemplate(int[,] template)
        {
            var isComplete = true;

            for (int i = 0; i < template.GetLength(0); i++)
            {
                for (int j = 0; j < template.GetLength(1); j++)
                {
                    if (template[i, j] == 0) isComplete = false;
                }
            }

            return isComplete;
        }
    }
}
