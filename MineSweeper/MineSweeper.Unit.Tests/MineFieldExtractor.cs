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
            cleanMineFields = RemoveNewLineCharacters(cleanMineFields);
            return cleanMineFields;
        }

        private List<string> RemoveEndOfInputLine(IReadOnlyCollection<string> mineFields)
        {
            var mineFieldsWithoutEOI = mineFields.ToList();
            mineFieldsWithoutEOI.Remove(mineFields.Last());
            return mineFieldsWithoutEOI;
        }

        private List<string> RemoveNewLineCharacters(IList<string> mineFields)
        {
            var mineFieldsWithoutNewLines = mineFields.ToList();
            for (var i = 0; i < mineFields.Count; i++)
            {
                mineFields[i] = mineFields[i].TrimStart('\r', '\n');
                mineFields[i] = mineFields[i].TrimEnd('\r', '\n');
            }
            return mineFieldsWithoutNewLines;
        }
    }
}