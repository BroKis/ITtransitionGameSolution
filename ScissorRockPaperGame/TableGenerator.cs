using ConsoleTables;
using ScissorRockPaperGame.Auxillary;

namespace ScissorRockPaperGame
{
    public class TableGenerator
    {
        string[] _titles;

        public TableGenerator(string[] titles)
        {
            _titles = titles;
        }

        public void PrintTable()
        {
            var header = _titles.Prepend("v PC - User >");
            var table = new ConsoleTable(header.ToArray());
            var checker = new RuleChecker(_titles.Length);
            TableBodyGenerate(table, checker);
            table.Write(Format.Default);
        }

        private void TableBodyGenerate(ConsoleTable table, RuleChecker checker)
        {
            for (int i = 0; i < _titles.Length; i++)
            {
                var row = new string[_titles.Length + 1];
                row[0] = _titles[i];
                for (int j = 0; j < _titles.Length; j++)
                {
                    row[j + 1] = Enum.GetName(typeof(Verdict), checker.TurnCheck(i, j));
                }
                table.AddRow(row.ToArray());
            }
        }

    }
}
