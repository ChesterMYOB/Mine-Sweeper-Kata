﻿using System.Collections;
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

        public ICollection ExtractMineFields(string minelessInput)
        {
            var mineFields = Regex.Split(minelessInput, MineFieldSeparator).ToList();
            return CleanUpMineFields(mineFields);
        }

        private ICollection CleanUpMineFields(List<string> mineFields)
        {
            mineFields.RemoveAll(string.IsNullOrWhiteSpace);
            mineFields = RemoveEndOfInput(mineFields);
            for (var m = 0; m < mineFields.Count; m++)
            {
                mineFields[m] = mineFields[m].TrimStart('\r', '\n');
                mineFields[m] = mineFields[m].TrimEnd('\r', '\n');
            }
            return mineFields;
        }

        private List<string> RemoveEndOfInput(List<string> mineFields)
        {
            mineFields.Remove(mineFields.Last());
            return mineFields;
        }
    }
}