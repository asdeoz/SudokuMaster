using System;

namespace SudokuMaster.TestData
{
    public static class TestData
    {
        public static int[,] GetTemplate(SudokuTemplates template)
        {
            switch (template)
            {
                case SudokuTemplates.Template1:
                    return CreateTemplate1();
                case SudokuTemplates.Template2:
                    return CreateTemplate2();
                default:
                    throw new IndexOutOfRangeException("No template exists for that index.");
            }
        }

        private static int[,] CreateTemplate1()
        {
            var template = new int[9, 9];

            template[0, 0] = 0;
            template[0, 1] = 0;
            template[0, 2] = 0;
            template[0, 3] = 1;
            template[0, 4] = 0;
            template[0, 5] = 5;
            template[0, 6] = 0;
            template[0, 7] = 6;
            template[0, 8] = 8;

            template[1, 0] = 0;
            template[1, 1] = 0;
            template[1, 2] = 0;
            template[1, 3] = 0;
            template[1, 4] = 0;
            template[1, 5] = 0;
            template[1, 6] = 7;
            template[1, 7] = 0;
            template[1, 8] = 1;

            template[2, 0] = 9;
            template[2, 1] = 0;
            template[2, 2] = 1;
            template[2, 3] = 0;
            template[2, 4] = 0;
            template[2, 5] = 0;
            template[2, 6] = 0;
            template[2, 7] = 3;
            template[2, 8] = 0;

            template[3, 0] = 0;
            template[3, 1] = 0;
            template[3, 2] = 7;
            template[3, 3] = 0;
            template[3, 4] = 2;
            template[3, 5] = 6;
            template[3, 6] = 0;
            template[3, 7] = 0;
            template[3, 8] = 0;

            template[4, 0] = 5;
            template[4, 1] = 0;
            template[4, 2] = 0;
            template[4, 3] = 0;
            template[4, 4] = 0;
            template[4, 5] = 0;
            template[4, 6] = 0;
            template[4, 7] = 0;
            template[4, 8] = 3;

            template[5, 0] = 0;
            template[5, 1] = 0;
            template[5, 2] = 0;
            template[5, 3] = 8;
            template[5, 4] = 7;
            template[5, 5] = 0;
            template[5, 6] = 4;
            template[5, 7] = 0;
            template[5, 8] = 0;

            template[6, 0] = 0;
            template[6, 1] = 3;
            template[6, 2] = 0;
            template[6, 3] = 0;
            template[6, 4] = 0;
            template[6, 5] = 0;
            template[6, 6] = 8;
            template[6, 7] = 0;
            template[6, 8] = 5;

            template[7, 0] = 1;
            template[7, 1] = 0;
            template[7, 2] = 5;
            template[7, 3] = 0;
            template[7, 4] = 0;
            template[7, 5] = 0;
            template[7, 6] = 0;
            template[7, 7] = 0;
            template[7, 8] = 0;

            template[8, 0] = 7;
            template[8, 1] = 9;
            template[8, 2] = 0;
            template[8, 3] = 4;
            template[8, 4] = 0;
            template[8, 5] = 1;
            template[8, 6] = 0;
            template[8, 7] = 0;
            template[8, 8] = 0;

            return template;
        }

        private static int[,] CreateTemplate2()
        {
            var template = new int[9, 9];

            template[0, 0] = 0;
            template[0, 1] = 1;
            template[0, 2] = 0;
            template[0, 3] = 0;
            template[0, 4] = 0;
            template[0, 5] = 0;
            template[0, 6] = 0;
            template[0, 7] = 6;
            template[0, 8] = 9;

            template[1, 0] = 4;
            template[1, 1] = 0;
            template[1, 2] = 6;
            template[1, 3] = 0;
            template[1, 4] = 0;
            template[1, 5] = 0;
            template[1, 6] = 0;
            template[1, 7] = 7;
            template[1, 8] = 5;

            template[2, 0] = 7;
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
            template[3, 4] = 7;
            template[3, 5] = 0;
            template[3, 6] = 4;
            template[3, 7] = 0;
            template[3, 8] = 0;

            template[4, 0] = 1;
            template[4, 1] = 0;
            template[4, 2] = 0;
            template[4, 3] = 0;
            template[4, 4] = 2;
            template[4, 5] = 0;
            template[4, 6] = 0;
            template[4, 7] = 0;
            template[4, 8] = 0;

            template[5, 0] = 3;
            template[5, 1] = 0;
            template[5, 2] = 0;
            template[5, 3] = 5;
            template[5, 4] = 0;
            template[5, 5] = 1;
            template[5, 6] = 9;
            template[5, 7] = 0;
            template[5, 8] = 0;

            template[6, 0] = 0;
            template[6, 1] = 2;
            template[6, 2] = 7;
            template[6, 3] = 0;
            template[6, 4] = 0;
            template[6, 5] = 3;
            template[6, 6] = 0;
            template[6, 7] = 0;
            template[6, 8] = 0;

            template[7, 0] = 0;
            template[7, 1] = 0;
            template[7, 2] = 0;
            template[7, 3] = 9;
            template[7, 4] = 0;
            template[7, 5] = 0;
            template[7, 6] = 0;
            template[7, 7] = 0;
            template[7, 8] = 7;

            template[8, 0] = 0;
            template[8, 1] = 0;
            template[8, 2] = 9;
            template[8, 3] = 0;
            template[8, 4] = 0;
            template[8, 5] = 0;
            template[8, 6] = 8;
            template[8, 7] = 0;
            template[8, 8] = 0;

            return template;
        }

    }
}
