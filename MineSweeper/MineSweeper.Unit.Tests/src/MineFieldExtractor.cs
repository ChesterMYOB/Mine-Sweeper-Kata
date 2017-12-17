using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MineSweeper.Unit.Tests
{
    public class MineFieldExtractor
    {
        public string MineFieldSeparator { get; }

        public MineFieldExtractor(string mineFieldSeparator)
        {
            MineFieldSeparator = mineFieldSeparator;
        }

        public List<string> ExtractMineFields(string mineFieldsBlob)
        {
            var mineFields = Regex.Split(mineFieldsBlob, MineFieldSeparator).ToList();
            return CleanUpMineFields(mineFields);
        }

        private List<string> CleanUpMineFields(IEnumerable<string> mineFields)
        {
            var cleanMineFields = mineFields.ToList();
            cleanMineFields.RemoveAll(string.IsNullOrWhiteSpace);
            cleanMineFields = RemoveEndOfInputLine(cleanMineFields);
            cleanMineFields = RemoveEnclosingNewLineCharacters(cleanMineFields);
            return cleanMineFields;
        }

        private List<string> RemoveEndOfInputLine(IReadOnlyCollection<string> mineFields)
        {
            var mineFieldsWithoutEOI = mineFields.ToList();
            mineFieldsWithoutEOI.Remove(mineFields.Last());
            return mineFieldsWithoutEOI;
        }

        private List<string> RemoveEnclosingNewLineCharacters(IList<string> mineFields)
        {
            var mineFieldsWithoutNewLines = mineFields.ToList();
            for (var i = 0; i < mineFieldsWithoutNewLines.Count; i++)
            {
                mineFieldsWithoutNewLines[i] = mineFieldsWithoutNewLines[i].TrimStart('\r', '\n');
                mineFieldsWithoutNewLines[i] = mineFieldsWithoutNewLines[i].TrimEnd('\r', '\n');
            }
            return mineFieldsWithoutNewLines;
        }
    }
}