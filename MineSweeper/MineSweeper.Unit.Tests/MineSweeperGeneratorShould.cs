using System;
using System.Text;
using Xunit;
using Xunit.Sdk;


namespace MineSweeper.Unit.Tests
{

    public class MineSweeperGeneratorShould
    {

        [Fact]
        public void ConvertMinelessInputIntoEmptyMineField()
        {
            var inputBuilder = new StringBuilder();
            inputBuilder.Append("~~~").AppendLine();
            inputBuilder.Append("33").AppendLine();
            inputBuilder.Append("...").AppendLine();
            inputBuilder.Append("...").AppendLine();
            inputBuilder.Append("...").AppendLine();
            inputBuilder.Append("~~~").AppendLine();
            var minelessInput = inputBuilder.ToString();

            var expectedBuilder = new StringBuilder();
            expectedBuilder.Append("~~~").AppendLine();
            expectedBuilder.Append("Field #1").AppendLine();
            expectedBuilder.Append("000").AppendLine();
            expectedBuilder.Append("000").AppendLine();
            expectedBuilder.Append("000").AppendLine();
            expectedBuilder.Append("~~~").AppendLine();
            var expectedMineField = expectedBuilder.ToString();

            var mineSweeperGenerator = new MineSweeperGenerator();
            var mineField = mineSweeperGenerator.createNewMineField(minelessInput);

            Assert.Equal(expectedMineField, mineField);
        }



        [Theory]
        [InlineData("t")]
        public void TestMethod2(string t)
        {
        }
    }
}
