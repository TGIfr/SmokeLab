using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SmokeLab
{
    class PaperSmoker
    {
        public AutoResetEvent Signal = new AutoResetEvent(false);

        public Table Table;

        public PaperSmoker(Table table)
        {
            Table = table;
        }

        public void Smoke()
        {
            while (true)
            {
                Signal.WaitOne();
                Table.Mutex.WaitOne();
                Console.WriteLine($"Smoker Paper is making Cigarette by Match and Tobacco .\n Match value now is : {--Table.Match} , Tobacco value now is : {--Table.Tobacco}");
                Thread.Sleep(new Random().Next(100, 2000));
                Signal.Reset();
                Table.Mutex.ReleaseMutex();
                Console.WriteLine("Smoker Paper is smoking  ....");
                Thread.Sleep(new Random().Next(100, 2000));
            }
        }
    }
}
