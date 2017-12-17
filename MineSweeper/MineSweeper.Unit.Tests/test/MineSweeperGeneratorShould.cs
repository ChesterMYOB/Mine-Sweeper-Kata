using System.Text;
using Xunit;

namespace MineSweeper.Unit.Tests.test
{
    public class MineSweeperGeneratorShould
    {
        [Fact]
        public void ConvertTheAcceptanceTest()
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
            inputBuilder.Append("~~~");
            var minefieldsInput = inputBuilder.ToString();

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
            expectedBuilder.Append("~~~");
            var expectedMineField = expectedBuilder.ToString();

            var mineSweeperGenerator = new MineSweeperGenerator();
            var mineField = mineSweeperGenerator.ParseMineFieldInput(minefieldsInput);

            Assert.Equal(expectedMineField, mineField);
        }
    }
}