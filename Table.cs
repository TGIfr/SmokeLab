using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SmokeLab
{
    class Table
    {
        public int Tobacco = 0;
        public int Match = 0;
        public int Paper = 0;

        public Mutex Mutex = new Mutex(false);
    }
}
