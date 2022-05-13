using PeanutButter.RandomGenerators;

namespace LotesWPF.Clases
{
    public class Process
    {
        public int ProcessID { get; set; }
        public bool FirstTime { get; set; }
        public bool IsFinish { get; set; }

        public string Status { get; set; }
        public int FValue { get; set; }
        public int SValue { get; set; }
        public char Operator { get; set; }
        public string Result { get; set; }

        public int MaxTime { get; set; }

        public int ComingTime { get; set; }
        public int FinishTime { get; set; }
        public int ReturnTime { get; set; }
        public int AswerTime { get; set; }
        public int WaitTime { get; set; }
        public int ServiceTime { get; set; }
        public int TransTime { get; set; }

        public int BloqTime { get; set; }
        public int BloqTimer { get; set; }

        public int Size { get; set; }

        public Process() 
        {
            FirstTime = false;
        }

        public Process(int processID, int fValue, int sValue, char @operator, string result, int maxTime, int comingTime, int finishTime, 
            int returnTime, int aswerTime, int waitTime, int serviceTime, int transTime, int bloqTime, int bloqTimer)
        {
            ProcessID = processID;
            FValue = fValue;
            SValue = sValue;
            Operator = @operator;
            Result = result;
            MaxTime = maxTime;
            ComingTime = comingTime;
            FinishTime = finishTime;
            ReturnTime = returnTime;
            AswerTime = aswerTime;
            WaitTime = waitTime;
            ServiceTime = serviceTime;
            TransTime = transTime;
            BloqTime = bloqTime;
            BloqTimer = bloqTimer;
            IsFinish = false;
        }

        public void SacarTiempos()
        {
            ServiceTime = TransTime;
            ReturnTime = FinishTime - ComingTime;
            WaitTime = ReturnTime - TransTime;
        }
        public void AsignarValores()
        {
            switch (RandomValueGen.GetRandomInt(1, 5))
            {
                case 1:
                    Operator = '+';

                    FValue = RandomValueGen.GetRandomInt(1, 20);
                    SValue = RandomValueGen.GetRandomInt(1, 20);
                    MaxTime = RandomValueGen.GetRandomInt(8, 17);
                    Size = RandomValueGen.GetRandomInt(5, 20);
                    break;
                case 2:
                    Operator = '-';
                    FValue = RandomValueGen.GetRandomInt(1, 20);
                    SValue = RandomValueGen.GetRandomInt(1, 20);
                    MaxTime = RandomValueGen.GetRandomInt(8, 17);
                    Size = RandomValueGen.GetRandomInt(5, 20);
                    break;
                case 3:
                    Operator = '*';
                    FValue = RandomValueGen.GetRandomInt(1, 20);
                    SValue = RandomValueGen.GetRandomInt(1, 20);
                    MaxTime = RandomValueGen.GetRandomInt(8, 17);
                    Size = RandomValueGen.GetRandomInt(5, 20);
                    break;
                case 4:
                    Operator = '/';
                    FValue = RandomValueGen.GetRandomInt(1, 20);
                    SValue = RandomValueGen.GetRandomInt(1, 20);
                    MaxTime = RandomValueGen.GetRandomInt(8, 17);
                    Size = RandomValueGen.GetRandomInt(5, 20);
                    break;
                case 5:
                    Operator = '%';
                    FValue = RandomValueGen.GetRandomInt(1, 20);
                    SValue = RandomValueGen.GetRandomInt(1, 20);
                    MaxTime = RandomValueGen.GetRandomInt(8, 17);
                    Size = RandomValueGen.GetRandomInt(5, 20);
                    break;
            }
        }

        public void SacarResultado()
        {
            //Sacamos el resultado de la operacion asiganada al proceso
            switch (Operator)
            {
                case '+':
                    { Result = $"{FValue} + {SValue} = {FValue + SValue}"; }
                    break;

                case '-':
                    { Result = $"{FValue} - {SValue} = {FValue + SValue}"; }
                    break;

                case '*':
                    { Result = $"{FValue} * {SValue} = {FValue + SValue}"; }
                    break;
                case '/':
                    { Result = $"{FValue} / {SValue} = {FValue + SValue}"; }
                    break;

                case '%':
                    { Result = $"{FValue} % {SValue} = {FValue + SValue}"; }
                    break;
            }
        }
    }
}
