using LotesWPF.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace LotesWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        private delegate void EmptyDelegate();

        protected void Refresh()
        {
            Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Background, new EmptyDelegate(delegate { }));
        }


        private List<Process> ProcesosRegistrados = new List<Process>();
        private List<Lote> lotes = new List<Lote>();
        private List<Process> ProcesosFinalizados = new List<Process>();
        int NumProcesos = 1;
        int Time = 0;
        bool Pausa = false;
        bool Error = false;
        bool Interrupcion = false;

        private void BtnInicio_Click(object sender, RoutedEventArgs e)
        {
            if (TbNumProcesos.Text.All(c => Char.IsNumber(c)) && !String.IsNullOrEmpty(TbNumProcesos.Text))
            {
                BtnInicio.IsEnabled = false;
                Random number = new Random();
                //Generar procesos en lista
                for (int nP = 0; nP < Convert.ToInt32(TbNumProcesos.Text); nP++)
                {
                    //Se crean procesos, los cuales se les llenaran los datos mediante el siguiente switch
                    //Dicho switch asignara datos como lo son los valores, operacion y tiempo maximo
                    Process process = new Process();
                    switch (number.Next(1, 6))
                    {
                        case 1:
                            process.Operator = '+';

                            process.FValue = number.Next(1, 5);
                            process.SValue = number.Next(1, 5);
                            process.MaxTime = number.Next(6, 16);
                            break;
                        case 2:
                            process.Operator = '-';
                            process.FValue = number.Next(1, 5);
                            process.SValue = number.Next(1, 5);
                            process.MaxTime = number.Next(6, 16);
                            break;
                        case 3:
                            process.Operator = '*';
                            process.FValue = number.Next(1, 5);
                            process.SValue = number.Next(1, 5);
                            process.MaxTime = number.Next(6, 16);
                            break;
                        case 4:
                            process.Operator = '/';
                            process.FValue = number.Next(1, 5);
                            process.SValue = number.Next(1, 5);
                            process.MaxTime = number.Next(6, 16);
                            break;
                        case 5:
                            process.Operator = '%';
                            process.FValue = number.Next(1, 5);
                            process.SValue = number.Next(1, 5);
                            process.MaxTime = number.Next(6, 16);
                            break;
                    }
                    process.ProcessID = NumProcesos;
                    NumProcesos++;
                    ProcesosRegistrados.Add(process);
                }

                CrearLotes();
            }
            else
            {
                MessageBox.Show("Porfavor solo ingrese digitos numericos");
                TbNumProcesos.Focus();
            }
        }

        //Funcion que realizara todo el trabajo 
        private void CrearLotes()
        {

            //Se hace la operacion los lotes necesarios mediante la divicion de procesos creados
            float resultado = Convert.ToSingle(ProcesosRegistrados.Count) / 5.0f;
            LbPendientes.Text = "Lotes pendientes: " + Math.Ceiling(resultado);

            //Se hace un ciclo for el cual redondea forzosamente res para arriba
            //y crear los lotes necesarios
            for (int i = 0; i < Math.Ceiling(resultado); i++)
            {
                lotes.Add(new Lote());
            }

            //Metemos los procesos a los lotes previamente creados
            //Todo en orden de inserccion
            var pos = 0;
            while (ProcesosRegistrados.Count != 0)
            {
                //Cuando un lote se llene se empezara a llenar el siguiente
                //si es que existe
                if (lotes[pos].process.Count == 5) { pos++; }
                else
                {
                    //Encolamos el primero que se encuentre en la lista
                    ProcesosRegistrados.First().NumeroLote = pos + 1;
                    lotes[pos].process.Enqueue(ProcesosRegistrados.First());
                    //Removemos dicho proceso en la lista temporal
                    ProcesosRegistrados.RemoveAt(0);
                }
            }

            ProcesarLotes();
        }

        #region Ayudantes

        private void ProcesarLotes()
        {
            //La lectura de teclas se hara mediante un hilo
            Thread Teclas = new Thread(() =>{
                while (true)
                {
                    Task.Delay(50).Wait();
                    if ((Keyboard.GetKeyStates(Key.P) == KeyStates.Down))
                    {
                        Pausa = true;
                    }
                    if (Keyboard.GetKeyStates(Key.C) == KeyStates.Down && Pausa)
                    {
                        MessageBox.Show("Se reanudara");
                        Pausa = false;
                    }
                    if ((Keyboard.GetKeyStates(Key.E) == KeyStates.Down))
                    {
                        Error = true;
                    }
                    if ((Keyboard.GetKeyStates(Key.I) == KeyStates.Down))
                    {
                        Interrupcion = true;
                    }
                    Refresh();
                }
            });
            //Esto nos permitira modificar la interfaz en segundo plano 
            Teclas.SetApartmentState(ApartmentState.STA);
            Teclas.Start();
            //Se hace un ciclo for de la lista lotes el cual ejecuta cada lote dentro de la lista
            var LoteActual = 1;

            lotes.ForEach(lote =>
            {
                //Se hace el conte de cuantos lotes quedan
                LbPendientes.Text = $"Lotes pendientes: {lotes.Count - LoteActual}";
                //Se obtieen el numero de elementos en el lote (no siempre puede estar lleno)
                var NumElementos = lote.process.Count;
                //Ciclo por para cada proceso dentro del lote
                for (int i = 0; i < NumElementos; i++)
                {
                    //Sacamos el proceso
                    Process process = lote.process.Dequeue();

                    //Actualizamos la tabla de procesos en espera
                    ActualizarTabla(lote.process);
                    Refresh();
                    //Colocamos los datos de el proceso en ejecucion
                    TbID.Text = "ID: " + process.ProcessID.ToString();
                    TbValor1.Text = "Numero 1: " + process.FValue.ToString();
                    TbOperator.Text = "Operador: " + process.Operator.ToString();
                    TbValor2.Text = "Numero 2: " + process.SValue.ToString();
                    TbTime.Text = "Tiempo maximo: " + process.MaxTime.ToString();
                    //Ciclo for para el tiempo de el proceso
                    for (int j = 0; j < process.MaxTime; j++)
                    {
                        //Si se detecta alguna discrepancia ya sea error interrupcion o pausa se hara saber
                        if (Interrupcion && !lote.process.Contains(process))
                        {
                            MessageBox.Show("Se interrumpio el proceso. Se volvera a encolar");
                            process.MaxTime -= j;
                            Refresh();
                            break;
                        }
                        if (Error) { MessageBox.Show("Error, se pasara al siguiente proceso"); break; }
                        if (Pausa) { MessageBox.Show("Se pausara el programa"); while (Pausa) { Thread.Sleep(40); } }
                        Time++;
                        TbTemporizador.Text = "Temporizador: " + Time;
                        TbTimeTrans.Text = "Tiempo transcurrido: " + j.ToString();
                        TbTimeRes.Text = "Tiempo restante: " + (process.MaxTime - j).ToString();
                        Refresh();
                        Task.Delay(1000).Wait();
                    }


                    //Sacamos el resultado de la operacion
                    if (Error) {
                        Error = false;
                        ActualizarTabla(lote.process);
                        process.Result = 0.0f;
                        process.Status = "ERROR";
                        process.NumeroLote = LoteActual;
                        ProcesosFinalizados.Add(process);
                        DgvFinalizados.ItemsSource = null;
                        //Añademos los procesos terminados a la tabla designada
                        DgvFinalizados.ItemsSource = ProcesosFinalizados;
                        Refresh();
                    }
                    else
                    {
                        if (Interrupcion)
                        {
                            lote.process.Enqueue(process);
                            i--;
                            Interrupcion = false;
                            ActualizarTabla(lote.process);
                            Refresh();
                        }
                        else
                        {
                            process.Status = "CORRECTO";
                            process.Result = SacarResultado(process);
                            process.NumeroLote = LoteActual;
                            ProcesosFinalizados.Add(process);
                            DgvFinalizados.ItemsSource = null;
                            //Añademos los procesos terminados a la tabla designada
                            DgvFinalizados.ItemsSource = ProcesosFinalizados;
                            Refresh();
                        }
                    }
                }
                LoteActual++;
            });
            //Se acaba el programa y se limpian todos los elementos de control
            //Tambien terminamos nuestro hilo
            Teclas.Abort();
            LimpiarTodo();
        }

        private void ActualizarTabla(Queue<Process> processes)
        {
            DgvLotes.ItemsSource = null;
            DgvLotes.ItemsSource = processes.ToList();
            Refresh();
        }

        private double SacarResultado(Process process)
        {
            //Sacamos el resultado de la operacion asiganada al proceso
            switch (process.Operator)
            {
                case '+':
                    { return process.FValue + process.SValue; }

                case '-':
                    { return process.FValue - process.SValue; }

                case '*':
                    { return process.FValue * process.SValue; }

                case '/':
                    { return process.FValue / process.SValue; }

                case '%':
                    { return process.FValue % process.SValue; }
            }
            return 0.0;
        }

        private void LimpiarTodo()
        {
            DgvLotes.ItemsSource = null;
            TbID.Text = "ID: ";
            TbValor1.Text = "Numero 1: ";
            TbOperator.Text = "Operador: ";
            TbValor2.Text = "Numero 2: ";
            TbTime.Text = "Tiempo maximo: ";
            TbTimeRes.Text = "Tiempo restante:";
            TbTimeTrans.Text = "Tiempo transcurrido:";
            ProcesosRegistrados.Clear();
            lotes.Clear();
            TbNumProcesos.Clear();
            Time = 0;
            NumProcesos = 0;
            BtnInicio.IsEnabled = true;
            Refresh();
        }

        #endregion
    }
}
