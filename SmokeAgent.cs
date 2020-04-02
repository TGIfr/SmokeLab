using System;
using System.Threading;

namespace SmokeLab
{
    class SmokeAgent
    {
        public TobaccoSmoker TobaccoSmoker;
        public PaperSmoker PaperSmoker;
        public MatchSmoker MatchSmoker;
        
        public Table Table;


        public void StartSmoking()
        {

            Thread StartAgents = new Thread(startAgents);
            Thread smokerMatchFun = new Thread(MatchSmoker.Smoke);
            Thread smokerTbaccoFun = new Thread(TobaccoSmoker.Smoke);
            Thread smokerPaperFun = new Thread(PaperSmoker.Smoke);

            smokerMatchFun.Start();
            smokerTbaccoFun.Start();
            smokerPaperFun.Start();
            StartAgents.Start();
        }
        void startAgents()
        {
            while (true)
            {
                //waiting the mutex to be free
                Table.Mutex.WaitOne();
                int random = new Random().Next(1, 4);
                if (random == 1)
                {
                    Console.WriteLine("Now is Agent A with paper and tobacco .");
                    Console.WriteLine($"Tobacco is Active and its value is : {++Table.Tobacco} ");
                    Console.WriteLine($"Paper is Active and its value is : {++Table.Paper}");
                    Thread.Sleep(new Random().Next(100, 2000));
                    Console.WriteLine("Wakeup signal sent to Match Smokker");
                    MatchSmoker.Signal.Set();

                }
                else if (random == 2)
                {
                    Console.WriteLine("Now is agent B with paper and matches .");
                    Console.WriteLine($"Match is Active and its value is : {++Table.Match}"); ;
                    Console.WriteLine($"Paper is Active and its value is : {++Table.Paper}");
                    Thread.Sleep(new Random().Next(100, 2000));
                    Console.WriteLine("Wakeup signal sent to Tobacco Smokker");
                    TobaccoSmoker.Signal.Set();
                }
                else
                {
                    Console.WriteLine("Now is agent C with tobacco and matches .");
                    Console.WriteLine($"Match is Active and its value is : {++Table.Match}");
                    Console.WriteLine($"Tobacco is Active and its value is : {++Table.Tobacco}");
                    Thread.Sleep(new Random().Next(100, 2000));
                    Console.WriteLine("Wakeup signal sent to Paper Smokker");
                    PaperSmoker.Signal.Set();
                }
                Table.Mutex.ReleaseMutex();

            }


        }

        

    }
}