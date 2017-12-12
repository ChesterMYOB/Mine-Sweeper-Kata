using System;
using Xunit;

namespace MineSweeper.Unit.Tests
{
    public class MineFieldPlotterShould
    {
        [Theory]
        [InlineData("........", 1, 1, 3, 3,
            "..." + "\r\n" +
            ".X." + "\r\n" +
            "...")]
        [InlineData("*.*..*.*", 1, 1, 3, 3,
            "*.*" + "\r\n" +
            ".X." + "\r\n" +
            "*.*")]
        [InlineData(".*.**.*.", 1, 1, 3, 3,
            ".*." + "\r\n" +
            "*X*" + "\r\n" +
            ".*.")]
        [InlineData("01234567", 1, 1, 3, 3,
            "012" + "\r\n" +
            "3X4" + "\r\n" +
            "567")]
        [InlineData("....*.**", 0, 0, 3, 3,
            "X*." + "\r\n" +
            "**." + "\r\n" +
            "...")]
        [InlineData("...*.**.", 2, 0, 3, 3,
            ".*X" + "\r\n" +
            ".**" + "\r\n" +
            "...")]
        [InlineData("**.*....", 2, 2, 3, 3,
            "..." + "\r\n" +
            ".**" + "\r\n" +
            ".*X")]
        [InlineData(".**.*...", 0, 2, 3, 3,
            "..." + "\r\n" +
            "**." + "\r\n" +
            "X*.")]
        public void GetMinesNeighbours(string expectedNeighbours, int x, int y, int height, int width, string mineField)
        {
            var plotter = new MineFieldPlotter();
            var neighbours = plotter.GetNeighbours(x, y, height, width, mineField);
            Assert.Equal(expectedNeighbours, neighbours);
        }

        [Theory]
        [InlineData(
            "..." + "\r\n" +
            ".*." + "\r\n" +
            "...",
            3, 3,
            "111" + "\r\n" +
            "1*1" + "\r\n" +
            "111")]
        public void PlotMineNumbersOnTheMineField(string mineField, int height, int width, string expectedMineField)
        {
            var plotter = new MineFieldPlotter();
            var numberedMineField = plotter.PlotMineNumbers(height, width, mineField);
            Assert.Equal(expectedMineField, numberedMineField);
        }
    }
}