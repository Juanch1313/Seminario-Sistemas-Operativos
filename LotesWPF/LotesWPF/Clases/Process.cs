using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotesWPF.Clases
{
    internal class Process
    {
        public int ProcessID { get; set; }
        public string Status { get; set; }

        public int FValue { get; set; }
        public int SValue { get; set; }
        public char Operator { get; set; }
        public double Result { get; set; }

        public int MaxTime { get; set; }
        public int NumeroLote { get; set; }
        public Process(int processID, string status, int fValue, int sValue, char @operator, double result, int maxTime)
        {
            ProcessID = processID;
            Status = status;
            FValue = fValue;
            SValue = sValue;
            Operator = @operator;
            Result = result;
            MaxTime = maxTime;

        }
        public Process()
        {

        }
    }
}
