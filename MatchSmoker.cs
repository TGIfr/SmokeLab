using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SmokeLab
{
    class MatchSmoker
    {
        public AutoResetEvent Signal = new AutoResetEvent(false);

        public Table Table;

        public MatchSmoker(Table table)
        {
            Table = table;
        }

        public void Smoke()
        {
            while (true)
            {
                Signal.WaitOne();
                Table.Mutex.WaitOne();

                Console.WriteLine($"Smoker Match is making Cigarette by Tobacco and Paper . \n Tobacco value now is : {--Table.Tobacco} , Paper value now is : {--Table.Paper}");
                Thread.Sleep(new Random().Next(100, 2000));

                Table.Mutex.ReleaseMutex();
                Signal.Reset();
                Console.WriteLine("Smoker Match is smoking  ....");
                Thread.Sleep(new Random().Next(100, 2000));
            }
        }
    }
}
