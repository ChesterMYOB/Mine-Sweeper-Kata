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

        public MineSweeperGenerator()
        {
            MineFieldExtractor = new MineFieldExtractor("~~~");
            MineFieldPlotter = new MineFieldPlotter();
        }


        public string ParseMineFieldInput(string minefields)
        {
            var mineFieldCollection = MineFieldExtractor.ExtractMineFields(minefields);
            foreach (string mineField in mineFieldCollection)
            {
                PlotDigitsOnMineField(mineField);
            }
            return minefields;
        }

        public string PlotDigitsOnMineField(string mineField)
        {
            var dimensions = GetMineFieldDimensions(mineField);
            return MineFieldPlotter.PlotMineNumbers(dimensions.height, dimensions.width, mineField);
        }

        private (int height, int width) GetMineFieldDimensions(string mineField)
        {

            
            var height = int.Parse(mineField[0].ToString());
            var width = int.Parse(mineField[1].ToString());
            return (height, width);
        }
    }
}