using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SmokeLab
{
    class TobaccoSmoker
    {
        public AutoResetEvent Signal = new AutoResetEvent(false);

        public Table Table;

        public TobaccoSmoker(Table table)
        {
            Table = table;
        }

        public void Smoke()
        {
            while (true)
            {
                while (true)
                {
                    Signal.WaitOne();
                    Table.Mutex.WaitOne();
                    Console.WriteLine($"Smoker Tobacco is making Cigarette by Match and Paper .\n Match value now is : {--Table.Match} , Paper value now is : {--Table.Paper}");
                    Thread.Sleep(new Random().Next(100, 2000));
                    Signal.Reset();
                    Table.Mutex.ReleaseMutex();
                    Console.WriteLine("Smoker Tobacco is smoking  ....");
                    Thread.Sleep(new Random().Next(100, 2000));
                }
            }
        }
    }
}
