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
        public MineFieldPlotter MineFieldPlotter { get; set; }

        public string MineFieldSeparator { get; set; }

        public MineSweeperGenerator()
        {
            MineFieldSeparator = "~~~";
            MineFieldExtractor = new MineFieldExtractor(MineFieldSeparator);
            MineFieldPlotter = new MineFieldPlotter();
        }


        public string ParseMineFieldInput(string input)
        {
            var mineFields = MineFieldExtractor.ExtractMineFields(input);
            var numberedMineFields = MineFieldPlotter.PlotMinesFieldNumbers(mineFields);
            return SerialiseMineFields(numberedMineFields);
        }

 
        private string SerialiseMineFields(List<string> mineFields)
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