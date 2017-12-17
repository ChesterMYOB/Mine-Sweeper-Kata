using System.Collections.Generic;
using System.Text;

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
            var serialiseBuilder = new StringBuilder();
            for (var i = 0; i < mineFields.Count; i++)
            {
                serialiseBuilder.Append(MineFieldSeparator).AppendLine();
                var field = $"Field #{i+1}:";
                serialiseBuilder.Append(field).AppendLine();
                serialiseBuilder.Append(mineFields[i]).AppendLine();
                serialiseBuilder.Append(MineFieldSeparator).AppendLine().AppendLine();         
            }
            var serializedMineField = serialiseBuilder.ToString();
            return serializedMineField.TrimEnd('\r', '\n'); 
        }
    }
}