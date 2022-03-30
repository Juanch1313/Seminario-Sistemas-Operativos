using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotesWPF.Clases
{
    internal class Lote
    {
        public Queue<Process> process = new Queue<Process>();
        public Lote()
        {
        }
    }
}
