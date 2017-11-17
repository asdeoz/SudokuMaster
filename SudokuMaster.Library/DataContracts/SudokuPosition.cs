using System.Collections.Generic;

namespace SudokuMaster.Library.DataContracts
{
    public class SudokuPosition
    {
        public int? Selected { get; set; }
        public bool IsPredefined { get; set; }
        public List<int> Options { get; set; }
    }
}
