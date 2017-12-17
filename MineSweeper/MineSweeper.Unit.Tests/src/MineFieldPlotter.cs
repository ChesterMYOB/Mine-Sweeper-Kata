using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MineSweeper.Unit.Tests
{
    public class MineFieldPlotter
    {
        public List<string> PlotNumbersOnMineFields(List<string> mineFieldCollection)
        {
            return mineFieldCollection.Select(PlotMineFieldNumbers).ToList();
        }

        private string PlotMineFieldNumbers(string mineField)
        {
            var mineFieldDictionary = ConvertMineFieldToDictionary(mineField);
            var plottedMineField = PlotMineNumbers(mineFieldDictionary);
            return ConvertMineFieldFromDictionary(plottedMineField);
        }

        public Dictionary<string, string> ConvertMineFieldToDictionary(string mineField)
        {
            var dimensions = GetMineFieldDimensions(mineField);
            var mineFieldOnly = IsolateMineField(mineField);
            var mineFieldDictionary = new Dictionary<string, string>();

            for (var i = 0; i < dimensions.height; i++)
            for (var j = 0; j < dimensions.width; j++)
                mineFieldDictionary[i + "," + j] = mineFieldOnly[i * dimensions.width + j].ToString();
            return mineFieldDictionary;
        }

        private (int height, int width) GetMineFieldDimensions(string mineField)
        {
            var height = int.Parse(mineField[0].ToString());
            var width = int.Parse(mineField[1].ToString());
            return (height, width);
        }

        private string IsolateMineField(string mineField)
        {
            var mineFieldWithoutDimensions = mineField.Remove(0, 2);
            return Regex.Replace(mineFieldWithoutDimensions, @"\t|\n|\r", "");
        }

        public Dictionary<string, string> PlotMineNumbers(Dictionary<string, string> mineFieldDictionary)
        {
            var plottedMineFieldDictionary = new Dictionary<string, string>();
            foreach (var mineCell in mineFieldDictionary)
            {
                var neighbours = GetNeighbours(mineCell.Key, mineFieldDictionary);
                var mineCount = CountMines(neighbours);

                if(mineCount == 0) plottedMineFieldDictionary[mineCell.Key] = ".";
                if (mineCell.Value == "*") plottedMineFieldDictionary[mineCell.Key] = mineCell.Value;                
                else plottedMineFieldDictionary[mineCell.Key] = mineCount.ToString();
            }
            return plottedMineFieldDictionary;
        }

        public string GetNeighbours(string position, Dictionary<string, string> mineFieldDictionary)
        {
            var neighbours = "";
            var location = position.Split(',');
            var height = int.Parse(location[0]);
            var width = int.Parse(location[1]);

            for (var i = -1; i < 2; i++)
            {
                for (var j = -1; j < 2; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        /* Current location */
                    }
                    else
                    {
                        var y = height + i;
                        var x = width + j;
                        mineFieldDictionary.TryGetValue(y + "," + x, out var neighbour);
                        neighbours += neighbour;
                    }
                }
            }
            return neighbours;
        }

        private int CountMines(string neighbours)
        {
            return neighbours.Count(n => n == '*');
        }

        private string ConvertMineFieldFromDictionary(Dictionary<string, string> plottedMineField)
        {
            var mineField = "";
            var x = 0;
            var y = 0;
            while (plottedMineField.ContainsKey($"{y},{x}"))
            {
                while (plottedMineField.ContainsKey($"{y},{x}"))
                {
                    mineField += plottedMineField[$"{y},{x}"];
                    x++;
                }
                mineField += Environment.NewLine;
                x = 0;
                y++;
            }
            mineField = mineField.TrimEnd('\r', '\n');
            return mineField;
        }
    }
}