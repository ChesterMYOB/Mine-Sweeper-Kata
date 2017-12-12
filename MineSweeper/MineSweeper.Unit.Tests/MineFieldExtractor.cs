using System.Collections;
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

        public List<string> ExtractMineFields(string minelessInput)
        {
            var mineFields = Regex.Split(minelessInput, MineFieldSeparator).ToList();
            return CleanUpMineFields(mineFields);
        }

        private List<string> CleanUpMineFields(List<string> mineFields)
        {
            var cleanMineFields = mineFields.ToList();
            cleanMineFields.RemoveAll(string.IsNullOrWhiteSpace);
            cleanMineFields = RemoveEndOfInput(mineFields);
            for (var i = 0; i < cleanMineFields.Count; i++)
            {
                cleanMineFields[i] = cleanMineFields[i].TrimStart('\r', '\n');
                cleanMineFields[i] = cleanMineFields[i].TrimEnd('\r', '\n');
            }
            return cleanMineFields;
        }

        private List<string> RemoveEndOfInput(List<string> mineFields)
        {
            var mineFieldsWithoutEoi = mineFields.ToList();
            mineFieldsWithoutEoi.Remove(mineFields.Last());
            return mineFieldsWithoutEoi;
        }

    }
}