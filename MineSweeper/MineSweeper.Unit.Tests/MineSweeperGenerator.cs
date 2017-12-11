using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MineSweeper.Unit.Tests
{
    internal class MineSweeperGenerator
    {
        public MineFieldExtractor MineFieldExtractor { get; set; }


        public string ParseMineFieldInput(string minelessInput)
        {
            var mineFields = MineFieldExtractor.ExtractMineFields(minelessInput);
            foreach (var mineField in mineFields)
            {
                GenerateMineField(mineField);
            }
            return minelessInput;
        }

        public string GenerateMineField(string minelessInput)
        {
            throw new System.NotImplementedException();
        }
    }
}