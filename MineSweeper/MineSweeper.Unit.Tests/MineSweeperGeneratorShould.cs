using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Xunit.Sdk;
using Assert = Xunit.Assert;


namespace MineSweeper.Unit.Tests
{

    public class MineSweeperGeneratorShould
    {
        [Fact]
        public void ConvertAcceptanceTests()
        {
            var inputBuilder = new StringBuilder();
            inputBuilder.Append("~~~").AppendLine();
            inputBuilder.Append("44").AppendLine();
            inputBuilder.Append("*...").AppendLine();
            inputBuilder.Append("....").AppendLine();
            inputBuilder.Append(".*..").AppendLine();
            inputBuilder.Append("....").AppendLine();
            inputBuilder.Append("~~~").AppendLine();
            inputBuilder.AppendLine();
            inputBuilder.Append("~~~").AppendLine();
            inputBuilder.Append("35").AppendLine();
            inputBuilder.Append("**...").AppendLine();
            inputBuilder.Append(".....").AppendLine();
            inputBuilder.Append(".*...").AppendLine();
            inputBuilder.Append("~~~").AppendLine();
            inputBuilder.AppendLine();
            inputBuilder.Append("~~~").AppendLine();
            inputBuilder.Append("00").AppendLine();
            inputBuilder.Append("~~~").AppendLine();
            var minelessInput = inputBuilder.ToString();

            var expectedBuilder = new StringBuilder();
            expectedBuilder.Append("~~~").AppendLine();
            expectedBuilder.Append("Field #1:").AppendLine();
            expectedBuilder.Append("*100").AppendLine();
            expectedBuilder.Append("2210").AppendLine();
            expectedBuilder.Append("1*10").AppendLine();
            expectedBuilder.Append("1110").AppendLine();
            expectedBuilder.Append("~~~").AppendLine();
            expectedBuilder.AppendLine();
            expectedBuilder.Append("~~~").AppendLine();
            expectedBuilder.Append("Field #2:").AppendLine();
            expectedBuilder.Append("**100").AppendLine();
            expectedBuilder.Append("33200").AppendLine();
            expectedBuilder.Append("1*100").AppendLine();
            expectedBuilder.Append("~~~").AppendLine();
            var expectedMineField = expectedBuilder.ToString();

            var mineSweeperGenerator = new MineSweeperGenerator();
            var mineField = mineSweeperGenerator.ParseMineFieldInput(minelessInput);

            Assert.Equal(expectedMineField, mineField);
        }

      
        [Fact]
        public void ConvertMinelessInputIntoEmptyMineField()
        {
            var inputBuilder = new StringBuilder();
            inputBuilder.Append("33").AppendLine();
            inputBuilder.Append("...").AppendLine();
            inputBuilder.Append("...").AppendLine();
            inputBuilder.Append("...").AppendLine();
            var minelessInput = inputBuilder.ToString();

            var expectedBuilder = new StringBuilder();
            expectedBuilder.Append("000").AppendLine();
            expectedBuilder.Append("000").AppendLine();
            expectedBuilder.Append("000").AppendLine();
            var expectedMineField = expectedBuilder.ToString();

            var mineSweeperGenerator = new MineSweeperGenerator();
            var mineField = mineSweeperGenerator.PlotDigitsOnMineField(minelessInput);

            Assert.Equal(expectedMineField, mineField);
        }
    }
}
