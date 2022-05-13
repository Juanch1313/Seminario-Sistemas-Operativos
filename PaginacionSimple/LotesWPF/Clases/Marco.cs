using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotesWPF.Clases
{
    public class Marco
    {
        public int Id { get; set; }
        public int size = 5;

        public int ProcessID { get; set; }

        public int ActualSize { get; set; }

        public int RemainSize { get; set; }

        public string Data { get; set; }
        public Marco()
        {
            ActualSize = 0;
            RemainSize = 5;
        }
    }
}
