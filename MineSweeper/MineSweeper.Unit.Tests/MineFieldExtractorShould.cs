using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace MineSweeper.Unit.Tests
{
    public class MineFieldExtractorShould
    {
        [Fact]
        public void ExtractAnIndividualMineField()
        {
            var inputBuilder = new StringBuilder();
            inputBuilder.Append("~~~").AppendLine();
            inputBuilder.Append("33").AppendLine();
            inputBuilder.Append("...").AppendLine();
            inputBuilder.Append("...").AppendLine();
            inputBuilder.Append("...").AppendLine();
            inputBuilder.Append("~~~").AppendLine();
            inputBuilder.AppendLine();
            inputBuilder.Append("~~~").AppendLine();
            inputBuilder.Append("00").AppendLine();
            inputBuilder.Append("~~~").AppendLine();
            var minelessInput = inputBuilder.ToString();

            var expectedBuilder = new StringBuilder();
            expectedBuilder.Append("33").AppendLine();
            expectedBuilder.Append("...").AppendLine();
            expectedBuilder.Append("...").AppendLine();
            expectedBuilder.Append("...");
            var expectedMineField = expectedBuilder.ToString();

            var expected = new List<string> { expectedMineField };

            var mineFieldExtractor = new MineFieldExtractor("~~~");
            var mineFields = mineFieldExtractor.ExtractMineFields(minelessInput);

            CollectionAssert.AreEqual(expected, mineFields);
        }

        [Fact]
        public void ExtractAnMultipleMineFields()
        {
            var inputBuilder = new StringBuilder();
            inputBuilder.Append("~~~").AppendLine();
            inputBuilder.Append("33").AppendLine();
            inputBuilder.Append("...").AppendLine();
            inputBuilder.Append("...").AppendLine();
            inputBuilder.Append("...").AppendLine();
            inputBuilder.Append("~~~").AppendLine();
            inputBuilder.AppendLine();
            inputBuilder.Append("~~~").AppendLine();
            inputBuilder.Append("44").AppendLine();
            inputBuilder.Append("....").AppendLine();
            inputBuilder.Append("....").AppendLine();
            inputBuilder.Append("....").AppendLine();
            inputBuilder.Append("....").AppendLine();
            inputBuilder.Append("~~~").AppendLine();
            inputBuilder.AppendLine();
            inputBuilder.Append("~~~").AppendLine();
            inputBuilder.Append("00").AppendLine();
            inputBuilder.Append("~~~").AppendLine();
            var minelessInput = inputBuilder.ToString();

            var expectedBuilder = new StringBuilder();
            expectedBuilder.Append("33").AppendLine();
            expectedBuilder.Append("...").AppendLine();
            expectedBuilder.Append("...").AppendLine();
            expectedBuilder.Append("...");
            var expectedMineField1 = expectedBuilder.ToString();

            expectedBuilder = new StringBuilder();
            expectedBuilder.Append("44").AppendLine();
            expectedBuilder.Append("....").AppendLine();
            expectedBuilder.Append("....").AppendLine();
            expectedBuilder.Append("....").AppendLine();
            expectedBuilder.Append("....");
            var expectedMineField2 = expectedBuilder.ToString();

            var expected = new List<string> { expectedMineField1, expectedMineField2 };

            var mineFieldExtractor = new MineFieldExtractor("~~~");
            var mineFields = mineFieldExtractor.ExtractMineFields(minelessInput);

            CollectionAssert.AreEqual(expected, mineFields);
        }
    }
}
