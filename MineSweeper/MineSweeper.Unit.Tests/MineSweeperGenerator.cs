namespace MineSweeper.Unit.Tests
{
    internal class MineSweeperGenerator
    {
        public MineFieldExtractor MineFieldExtractor { get; set; }

        public MineFieldPlotter MineFieldPlotter { get; set; }

        public MineFieldSerialiser MineFieldSerialiser { get; set; }

        public string MineFieldSeparator { get; set; }

        public MineSweeperGenerator()
        {
            MineFieldSeparator = "~~~";
            MineFieldExtractor = new MineFieldExtractor(MineFieldSeparator);
            MineFieldPlotter = new MineFieldPlotter();
            MineFieldSerialiser = new MineFieldSerialiser(MineFieldSeparator);
        }

        public string ParseMineFieldInput(string input)
        {
            var mineFields = MineFieldExtractor.ExtractMineFields(input);
            var mineFieldsWithNumbers = MineFieldPlotter.PlotNumbersOnMineFields(mineFields);
            return MineFieldSerialiser.SerialiseMineFields(mineFieldsWithNumbers);
        }
    }
}