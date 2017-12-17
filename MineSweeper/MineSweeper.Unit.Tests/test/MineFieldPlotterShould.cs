using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Assert = Xunit.Assert;

namespace MineSweeper.Unit.Tests
{
    public class MineFieldPlotterShould
    {
        public MineFieldPlotter MineFieldPlotter { get; set; }
        public MineFieldPlotterShould()
        {
            MineFieldPlotter = new MineFieldPlotter();
        }
        [Fact]
        public void ConvertAStrangeSizedMineFieldToDictionary()
        {
            const string mineField = "46" + "\r\n" +
                                     "123123" + "\r\n" +
                                     "456456" + "\r\n" +
                                     "789789" + "\r\n" +
                                     "012012";

            var mineFieldDictionary = MineFieldPlotter.ConvertMineFieldToDictionary(mineField);

            var expectedDictionary = new Dictionary<string, string>
            {
                {"0,0", "1"},{"0,1", "2"},{"0,2", "3"},{"0,3", "1"},{"0,4", "2"},{"0,5", "3"},
                {"1,0", "4"},{"1,1", "5"},{"1,2", "6"},{"1,3", "4"},{"1,4", "5"},{"1,5", "6"},
                {"2,0", "7"},{"2,1", "8"},{"2,2", "9"},{"2,3", "7"},{"2,4", "8"},{"2,5", "9"},
                {"3,0", "0"},{"3,1", "1"},{"3,2", "2"},{"3,3", "0"},{"3,4", "1"},{"3,5", "2"}
            };
            CollectionAssert.AreEqual(expectedDictionary, mineFieldDictionary);
        }

        [Fact]
        public void ConvertSimpleMineFieldsToDictionary()
        {
            const string mineField = "33" + "\r\n" +
                                     "123" + "\r\n" +
                                     "456" + "\r\n" +
                                     "789";

            var mineFieldDictionary = MineFieldPlotter.ConvertMineFieldToDictionary(mineField);

            var expectedDictionary = new Dictionary<string, string>
            {
                {"0,0", "1"},{"0,1", "2"},{"0,2", "3"},
                {"1,0", "4"},{"1,1", "5"},{"1,2", "6"},
                {"2,0", "7"},{"2,1", "8"},{"2,2", "9"}
            };
            CollectionAssert.AreEqual(expectedDictionary, mineFieldDictionary);
        }

        [Theory]
        [InlineData("0,0", "245")]
        [InlineData("0,1", "13456")]
        [InlineData("0,2", "256")]
        [InlineData("1,0", "12578")]
        [InlineData("1,1", "12346789")]
        [InlineData("1,2", "23589")]
        [InlineData("2,0", "458")]
        [InlineData("2,1", "45679")]
        [InlineData("2,2", "568")]
        public void GetNeighboursForMineField(string position, string expectedNeighbours)
        {
            var mineField = new Dictionary<string, string>
            {
                {"0,0", "1"},{"0,1", "2"},{"0,2", "3"},
                {"1,0", "4"},{"1,1", "5"},{"1,2", "6"},
                {"2,0", "7"},{"2,1", "8"},{"2,2", "9"}
            };
            var neighbours = MineFieldPlotter.GetNeighbours(position, mineField);
            Assert.Equal(expectedNeighbours, neighbours);
        }


        [Fact]
        public void GetNeighboursForLongerMineField()
        {
            var mineField = new Dictionary<string, string>
            {
                {"0,0", "1"},{"0,1", "2"},{"0,2", "3"},
                {"1,0", "4"},{"1,1", "5"},{"1,2", "6"},
                {"2,0", "7"},{"2,1", "8"},{"2,2", "9"},
                {"3,0", "10"},{"3,1", "11"},{"3,2", "12"},
                {"4,0", "13"},{"4,1", "14"},{"4,2", "15"}
            };
            var neighbours = MineFieldPlotter.GetNeighbours("4,1", mineField);
            Assert.Equal("1011121315", neighbours);
        }
    }
}