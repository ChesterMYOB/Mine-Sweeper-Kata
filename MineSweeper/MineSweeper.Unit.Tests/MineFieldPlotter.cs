using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MineSweeper.Unit.Tests
{
    public class MineFieldPlotter
    {
        public string PlotMineNumbers(int height, int width, string mineField)
        {
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {                   
                    mineField = PlotMineNumber(i, j, height, width, mineField);
                }
            }
            return mineField;
        }

        private string PlotMineNumber(int x, int y, int height, int width, string mineField)
        {
            if (!mineField[width * y + x].Equals('*'))
            {
                var neighbours = GetNeighbours(x, y, height, width, mineField);
                var mineCount = neighbours.Select(n => n.Equals('*')).Count();

                var mineFieldWithNumber = new StringBuilder(mineField)
                {
                    [width * y + x] = (char) mineCount
                };
                return mineFieldWithNumber.ToString();

            }
            return mineField;
        }

        public string GetNeighbours(int x, int y, int height, int width, string mineField)
        {
            var mineFieldAsArray = Regex.Split(mineField, Environment.NewLine);

            var neighbours = 
                TopLeft(x, y, mineFieldAsArray) +
                TopMiddle(x, y, mineFieldAsArray) +
                TopRight(x, y, width, mineFieldAsArray) +
                MiddleLeft(x, y, mineFieldAsArray) +
                MiddleRight(x, y, width, mineFieldAsArray) +
                BottomLeft(x, y, height, mineFieldAsArray) +
                BottomMiddle(x, y, height, mineFieldAsArray) +
                BottomRight(x, y, width, height, mineFieldAsArray);

            return neighbours;
        }

        private string TopLeft(int x, int y, IReadOnlyList<string> mineField)
        {
            if (y - 1 < 0 || x - 1 < 0) return ".";
            return mineField[y - 1][x - 1].ToString();
        }

        private string TopMiddle(int x, int y, IReadOnlyList<string> mineField)
        {
            if (y - 1 < 0) return ".";
            return mineField[y - 1][x].ToString();
        }

        private string TopRight(int x, int y, int width, IReadOnlyList<string> mineField)
        {
            if (y - 1 < 0 || x + 1 > width - 1) return ".";
            return mineField[y - 1][x + 1].ToString();
        }

        private string MiddleLeft(int x, int y, IReadOnlyList<string> mineField)
        {
            if (x - 1 < 0) return ".";
            return mineField[y][x - 1].ToString();
        }

        private string MiddleRight(int x, int y, int width, IReadOnlyList<string> mineField)
        {
            if (x + 1 > width - 1) return ".";
            return mineField[y][x + 1].ToString();
        }

        private string BottomLeft(int x, int y, int height, IReadOnlyList<string> mineField)
        {
            if (y + 1 > height - 1 || x - 1 < 0) return ".";
            return mineField[y + 1][x - 1].ToString();
        }

        private string BottomMiddle(int x, int y, int height, IReadOnlyList<string> mineField)
        {
            if (y + 1 > height - 1) return ".";
            return mineField[y + 1][x].ToString();
        }

        private string BottomRight(int x, int y, int width, int height, IReadOnlyList<string> mineField)
        {
            if (y + 1 > height - 1 || x + 1 > width - 1) return ".";
            return mineField[y + 1][x + 1].ToString();
        }

        public void PlotMineNumbers(Dictionary<string, string> mineFieldDictionary)
        {
            throw new NotImplementedException();
        }


        public List<string> PlotMinesFieldNumbers(List<string> mineFieldCollection)
        {
            mineFieldCollection.Select(PlotMineFieldNumbers).ToList();
            mineFieldCollection.ToList<>()
            return new List<string>();
        }

        private Dictionary<string, string> PlotMineFieldNumbers(string mineField)
        {
            var mineFieldDictionary = ConvertMineFieldToDictionary(mineField);
            PlotMineNumbers(mineFieldDictionary);
            return mineFieldDictionary;
        }

        private Dictionary<string, string> ConvertMineFieldToDictionary(string mineField)
        {
            throw new NotImplementedException();
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
