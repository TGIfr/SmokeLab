using System;

namespace SmokeLab
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new Table();

            var tobaccoSmoker = new TobaccoSmoker(table);
            var paperSmoker = new PaperSmoker(table);
            var matchSmoker = new MatchSmoker(table);

            var smokingAgent = new SmokeAgent()
            {
                TobaccoSmoker = tobaccoSmoker,
                PaperSmoker = paperSmoker,
                MatchSmoker = matchSmoker,
                Table = table,
            };

            smokingAgent.StartSmoking();

        }
    }
}
