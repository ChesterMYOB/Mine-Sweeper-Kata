using System.Collections.Generic;

namespace MineSweeper.Unit.Tests
{
    public class MineFieldSerialiser
    {
        public string MineFieldSeparator { get; set; }
        public MineFieldSerialiser(string separator)
        {
            MineFieldSeparator = separator;
        }
        public string SerialiseMineFields(List<string> mineFields)
        {
            var serialisedMineFields = MineFieldSeparator;
            for (int i = 0; i < mineFields.Count; i++)
            {
                serialisedMineFields = serialisedMineFields + MineFieldSeparator;
                // Add MineFieldSeparator
                // Field X
                // MineField
                // Add MineFieldSeparator
            }

            return serialisedMineFields;
        }
    }
}