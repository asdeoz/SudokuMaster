using SudokuMaster.Library.DataContracts;

namespace SudokuMaster.Library.ServiceContracts
{
    public interface ISolver
    {
        int[,] Solve(int[,] template);
        int[,] Solve(SudokuPosition[,] template);
    }
}
