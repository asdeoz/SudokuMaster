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
            _template1 = CreateTemplate1();
            _template2 = CreateTemplate2();
        }

        [TestMethod]
        public void SolverWorks()
        {
            _solver.Solve(_template1);
        }

        [TestMethod]
        public void SolverDetectsBadFormattingInColumns()
        {
            var template1 = new int[10, 9];
            var template2 = new int[9, 10];

            Assert.ThrowsException<Exception>(() => _solver.Solve(template1), "It should throw an exception for template1");
            Assert.ThrowsException<Exception>(() => _solver.Solve(template2), "It should throw an exception for template2");
        }

        private int[,] CreateTemplate1()
        {
            var template = new int[9, 9];

            template[0, 0] = 0;
            template[0, 1] = 0;
            template[0, 2] = 9;
            template[0, 3] = 0;
            template[0, 4] = 5;
            template[0, 5] = 0;
            template[0, 6] = 0;
            template[0, 7] = 1;
            template[0, 8] = 7;

            template[1, 0] = 0;
            template[1, 1] = 0;
            template[1, 2] = 0;
            template[1, 3] = 0;
            template[1, 4] = 0;
            template[1, 5] = 0;
            template[1, 6] = 3;
            template[1, 7] = 0;
            template[1, 8] = 9;

            template[2, 0] = 0;
            template[2, 1] = 0;
            template[2, 2] = 1;
            template[2, 3] = 7;
            template[2, 4] = 0;
            template[2, 5] = 0;
            template[2, 6] = 0;
            template[2, 7] = 5;
            template[2, 8] = 0;

            template[3, 0] = 1;
            template[3, 1] = 0;
            template[3, 2] = 0;
            template[3, 3] = 0;
            template[3, 4] = 0;
            template[3, 5] = 8;
            template[3, 6] = 0;
            template[3, 7] = 0;
            template[3, 8] = 4;

            template[4, 0] = 0;
            template[4, 1] = 0;
            template[4, 2] = 0;
            template[4, 3] = 2;
            template[4, 4] = 0;
            template[4, 5] = 7;
            template[4, 6] = 0;
            template[4, 7] = 0;
            template[4, 8] = 0;

            template[5, 0] = 5;
            template[5, 1] = 0;
            template[5, 2] = 0;
            template[5, 3] = 6;
            template[5, 4] = 0;
            template[5, 5] = 0;
            template[5, 6] = 0;
            template[5, 7] = 0;
            template[5, 8] = 1;

            template[6, 0] = 0;
            template[6, 1] = 7;
            template[6, 2] = 0;
            template[6, 3] = 0;
            template[6, 4] = 0;
            template[6, 5] = 4;
            template[6, 6] = 8;
            template[6, 7] = 0;
            template[6, 8] = 0;

            template[7, 0] = 6;
            template[7, 1] = 0;
            template[7, 2] = 3;
            template[7, 3] = 0;
            template[7, 4] = 0;
            template[7, 5] = 0;
            template[7, 6] = 0;
            template[7, 7] = 0;
            template[7, 8] = 0;

            template[8, 0] = 8;
            template[8, 1] = 1;
            template[8, 2] = 0;
            template[8, 3] = 0;
            template[8, 4] = 3;
            template[8, 5] = 0;
            template[8, 6] = 5;
            template[8, 7] = 0;
            template[8, 8] = 0;

            return template;
        }

        private int[,] CreateTemplate2()
        {
            var template = new int[9, 9];

            template[0, 0] = 0;
            template[0, 1] = 0;
            template[0, 2] = 0;
            template[0, 3] = 0;
            template[0, 4] = 0;
            template[0, 5] = 0;
            template[0, 6] = 0;
            template[0, 7] = 0;
            template[0, 8] = 0;

            template[1, 0] = 0;
            template[1, 1] = 0;
            template[1, 2] = 0;
            template[1, 3] = 0;
            template[1, 4] = 0;
            template[1, 5] = 0;
            template[1, 6] = 0;
            template[1, 7] = 0;
            template[1, 8] = 0;

            template[2, 0] = 0;
            template[2, 1] = 0;
            template[2, 2] = 0;
            template[2, 3] = 0;
            template[2, 4] = 0;
            template[2, 5] = 0;
            template[2, 6] = 0;
            template[2, 7] = 0;
            template[2, 8] = 0;

            template[3, 0] = 0;
            template[3, 1] = 0;
            template[3, 2] = 0;
            template[3, 3] = 0;
            template[3, 4] = 0;
            template[3, 5] = 0;
            template[3, 6] = 0;
            template[3, 7] = 0;
            template[3, 8] = 0;

            template[4, 0] = 0;
            template[4, 1] = 0;
            template[4, 2] = 0;
            template[4, 3] = 0;
            template[4, 4] = 0;
            template[4, 5] = 0;
            template[4, 6] = 0;
            template[4, 7] = 0;
            template[4, 8] = 0;

            template[5, 0] = 0;
            template[5, 1] = 0;
            template[5, 2] = 0;
            template[5, 3] = 0;
            template[5, 4] = 0;
            template[5, 5] = 0;
            template[5, 6] = 0;
            template[5, 7] = 0;
            template[5, 8] = 0;

            template[6, 0] = 0;
            template[6, 1] = 0;
            template[6, 2] = 0;
            template[6, 3] = 0;
            template[6, 4] = 0;
            template[6, 5] = 0;
            template[6, 6] = 0;
            template[6, 7] = 0;
            template[6, 8] = 0;

            template[7, 0] = 0;
            template[7, 1] = 0;
            template[7, 2] = 0;
            template[7, 3] = 0;
            template[7, 4] = 0;
            template[7, 5] = 0;
            template[7, 6] = 0;
            template[7, 7] = 0;
            template[7, 8] = 0;

            template[8, 0] = 0;
            template[8, 1] = 0;
            template[8, 2] = 0;
            template[8, 3] = 0;
            template[8, 4] = 0;
            template[8, 5] = 0;
            template[8, 6] = 0;
            template[8, 7] = 0;
            template[8, 8] = 0;

            return template;
        }
    }
}
