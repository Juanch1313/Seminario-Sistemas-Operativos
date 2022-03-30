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
using System.Data.SqlClient;

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


        private static List<Process> ProcesosRegistrados = new List<Process>();
        private static List<Process> ProcesosFinalizados = new List<Process>();

        //FCFS
        private static Queue<Process> _RoundRobin = new Queue<Process>();
        private static Queue<Process> _Bloqueados = new Queue<Process>();
        private static Process ActualProcess;

        int NumProcesos = 1;
        int Time = 0;
        int Quantum = 0;
        bool Pausa = false;
        bool Error = false;
        bool Bloqueado = false;
        bool EnEjecucion = false;
        bool Tabla = false;

        private void BtnInicio_Click(object sender, RoutedEventArgs e)
        {
            if (TbNumProcesos.Text.All(c => Char.IsNumber(c)) && !String.IsNullOrEmpty(TbNumProcesos.Text) 
                && TbQuantum.Text.All(c => Char.IsNumber(c)) && !String.IsNullOrEmpty(TbQuantum.Text))
            {
                ProcesosFinalizados.Clear();
                BtnInicio.IsEnabled = false;
                TbQuantum.IsEnabled = false;
                TbNumProcesos.IsEnabled = false;
                //Generar procesos en lista
                for (int nP = 0; nP < Convert.ToInt32(TbNumProcesos.Text); nP++)
                {
                    //Se crean procesos, los cuales se les llenaran los datos mediante el siguiente switch
                    //Dicho switch asignara datos como lo son los valores, operacion y tiempo maximo
                    Process process = new Process();
                    process.AsignarValores();
                    process.ProcessID = NumProcesos;
                    NumProcesos++;
                    ProcesosRegistrados.Add(process);
                }
                Quantum = Convert.ToInt32(TbQuantum.Text);
                ProcesarRoundRobin();
            }
            else
            {
                MessageBox.Show("Rellene las casillas y asegurese que sean numeros");
                TbNumProcesos.Focus();
            }
        }

        //Funcion que realizara todo el trabajo 


        #region Ayudantes

        private void ProcesarRoundRobin()
        {
            //La lectura de teclas se hara mediante un hilo
            Thread Teclas = new Thread(() =>{
                while (true)
                {
                    Task.Delay(10).Wait();
                    if (Keyboard.GetKeyStates(Key.P) == KeyStates.Down)
                    {
                        Pausa = true;
                    }
                    if (Keyboard.GetKeyStates(Key.C) == KeyStates.Down && Pausa)
                    {
                        MessageBox.Show("Se reanudara");
                        Pausa = false;
                    }
                    if (Keyboard.GetKeyStates(Key.E) == KeyStates.Down)
                    {
                        Error = true;
                    }
                    if (Keyboard.GetKeyStates(Key.I) == KeyStates.Down)
                    {
                        Bloqueado = true;
                    }

                    if (Keyboard.GetKeyStates(Key.T) == KeyStates.Down)
                    {
                        Tabla = true;
                    }

                    //N para asigar un proceso nuevo
                    if(Keyboard.GetKeyStates(Key.N) == KeyStates.Down)
                    {
                        //Se crea proceso y se le asignan sus debidos valores
                        Process process = new Process();
                        process.AsignarValores();
                        process.ProcessID = NumProcesos++;
                        process.ComingTime = Time;

                        //Si hay un proceso en ejecucion
                        if (EnEjecucion)
                        {   //Se pregunta si ya hay 5 procesos en memoria
                            if(_RoundRobin.Count + _Bloqueados.Count == 4)
                            { 
                                //Si los hay se agrega a la lista de procesos registrados
                                ProcesosRegistrados.Add(process);
                                //(Se usa un dispatcher para modificar componentes UI mediante hilos multiples)
                                //Y se modifica el label de procesos nuevos al nuevo valor de la lista
                                Dispatcher.Invoke(new Action(() => { LbPendientes.Text = $"Procesos nuevos: {ProcesosRegistrados.Count}"; }));
                            }
                            else
                            {
                                //Si no hay 5 procesos en memoria se agrega a la cola _FCFS
                                _RoundRobin.Enqueue(process);
                                //Dispatcher para actualizar la tabla y asi mostrar los nuevos datos
                                Dispatcher.Invoke(new Action(() => {
                                    DgvListos.ItemsSource = null;
                                    DgvListos.ItemsSource = _RoundRobin; 
                                }));
                            }
                        }
                        else
                        {
                            //Si no se encuentra en ejecucion ningun proceso se agrega directamente a la cola
                            _RoundRobin.Enqueue(process);
                        }
                    }
                    Refresh();
                }
            });
            //Esto nos permitira modificar la interfaz en segundo plano 
            Teclas.IsBackground = true;
            Teclas.SetApartmentState(ApartmentState.STA);
            Teclas.Start();
            #region Round Robin
            do
            {
                //Se vacia la tabla de listos y se utiliza un while para llenar la memoria con los procesos correspondientes
                DgvListos.ItemsSource = null;
                while (ProcesosRegistrados.Count >= 1 && (_RoundRobin.Count + _Bloqueados.Count) != 5)
                {
                    //El sexto elemento que en realidad sera el 5to en memoria una vez colocado el primero
                    ProcesosRegistrados[0].ComingTime = Time;
                    _RoundRobin.Enqueue(ProcesosRegistrados[0]);
                    ProcesosRegistrados.RemoveAt(0);
                }
                //Se actualizan los procesos pendientes cuyos estan fuera de memoria
                LbPendientes.Text = $"Procesos nuevos: {ProcesosRegistrados.Count}";

                //Desencolamos el primer proceso para trabajarlo y actualizamos la tabla para que muestre los datos
                var proceso = _RoundRobin.Dequeue();
                DgvListos.ItemsSource = _RoundRobin;
                Refresh();
                //Actualizamos todas las etiquetas
                TbID.Text = "ID:" + proceso.ProcessID.ToString();
                TbValor1.Text = "Valor 1: " + proceso.FValue.ToString();
                TbOperator.Text = "Operador: " + proceso.Operator.ToString();
                TbValor2.Text = "Valor 2: " + proceso.SValue.ToString();
                TbTime.Text = "Tiempo maximo: " + proceso.MaxTime.ToString();
                EnEjecucion = true;
                //Comenzamos la ejecucion del proceso
                for (int Timer = 0; Timer < Quantum; Timer++)
                {
                    proceso.TransTime++;
                    proceso.MaxTime--;
                    if(proceso.TransTime >= proceso.MaxTime) {
                        proceso.IsFinish = true;
                        break;
                    }
                    if (!proceso.FirstTime)
                    {
                        proceso.FirstTime = true;
                        proceso.AswerTime = Time - proceso.ComingTime;
                    }
                    //Incrementamos el temporizador
                    Time++;
                    //Checamos los bloqueados y actualizamos sus datos como el tiempo de bloqueo
                    for(int pos = 0; pos < _Bloqueados.Count; pos++)
                    {
                        _Bloqueados.ElementAt(pos).BloqTimer++;
                        //Si el proceso cumple su tiempo de bloqueo saldra y entrara a memoria
                        if(_Bloqueados.ElementAt(pos).BloqTimer == 8)
                        {
                            DgvBloqueados.ItemsSource = null;
                            ProcesosRegistrados.Insert(0, _Bloqueados.Dequeue());
                            DgvBloqueados.ItemsSource = _Bloqueados;
                            DgvListos.ItemsSource = null;
                            while (ProcesosRegistrados.Count >= 1 && (_RoundRobin.Count + 1 + _Bloqueados.Count) < 5)
                            {
                                //El sexto elemento que en realidad sera el 5to en memoria una vez colocado el primero
                                //en ejecucion se le agrega un tiempo de llegada mayor
                                if (_RoundRobin.Count >= 5) { _RoundRobin.ElementAt(_RoundRobin.Count - 1).ComingTime++; break; }
                                ProcesosRegistrados[0].ComingTime += 8;
                                _RoundRobin.Enqueue(ProcesosRegistrados[0]);
                                ProcesosRegistrados.RemoveAt(0);
                            }
                            DgvListos.ItemsSource= _RoundRobin;
                        }
                        Refresh();
                    }
                    //Actualizamos la tabla de bloqueados
                    DgvBloqueados.ItemsSource = null;
                    DgvBloqueados.ItemsSource = _Bloqueados;

                    //Actualizamos las etiquetas de tiempo
                    TbTemporizador.Text = "Temporizador Global: " + Time.ToString();
                    TbTimeRes.Text = "Tiempo restante: " + (proceso.MaxTime - Timer).ToString();
                    TbTimeTrans.Text = "Tiempo transcurrido: " + Timer.ToString();
                    ActualProcess = proceso;
                    Task.Delay(500).Wait();
                    Refresh();
                    //Detectamos los errores, bloqueos o pausas
                    if (Error) {
                        proceso.IsFinish = true;
                        MessageBox.Show("Error en el proceso");
                        break; 
                    }
                    //En caso de bloqueo actualizamos el tiempo maximo a el cual deberia tener
                    if (Bloqueado) {
                        MessageBox.Show("Proceso bloqueado");
                        DgvBloqueados.ItemsSource = null;
                        proceso.BloqTime = Time;
                        proceso.MaxTime -= Timer;
                        _Bloqueados.Enqueue(proceso);
                        DgvBloqueados.ItemsSource = _Bloqueados;
                        Refresh();
                        break;
                    }
                    if(Pausa) { 
                        MessageBox.Show("Se pausara el programa");
                        while (Pausa) { Task.Delay(10).Wait(); }
                    }
                    if (Tabla)
                    {
                        TablaBCP _TablaBCP = new TablaBCP();
                        _TablaBCP.SetProcess(GetProcesses());
                        _TablaBCP.ShowDialog();
                        Refresh();
                        _TablaBCP = null;
                        Tabla = false;
                    }
                }
                if (!proceso.IsFinish && !Bloqueado)
                {
                    _RoundRobin.Enqueue(proceso);
                }
                Refresh();
                //Si se detecta el error mandamos de resultado un error ademas de sacar los tiempos
                if (Error && proceso.IsFinish)
                {
                    DgvFinalizados.ItemsSource = null;
                    proceso.Result = "Error";
                    proceso.FinishTime = Time;
                    proceso.SacarTiempos();
                    ProcesosFinalizados.Add(proceso);
                    DgvFinalizados.ItemsSource = ProcesosFinalizados;
                    Refresh();
                    Error = false;
                }
                else
                {
                    //El estado de bloque cambia
                    if (Bloqueado) { Bloqueado = false; }
                    else
                    {
                        if (proceso.IsFinish)
                        {
                            //En caso de no haber algun caso de falla se calcularan los debidos tiempos
                            //Se actualizara la tabla de finalizados para mostrar los resultados debidos
                            proceso.FinishTime = Time;
                            proceso.SacarTiempos();
                            proceso.SacarResultado();
                            ProcesosFinalizados.Add(proceso);
                            DgvFinalizados.ItemsSource = null;
                            DgvFinalizados.ItemsSource = ProcesosFinalizados;
                        }
                        Refresh();
                    }
                }
                EnEjecucion = false;

            } while (_RoundRobin.Count != 0);

            #endregion
            //Se acaba el programa y se limpian todos los elementos de control
            //Tambien terminamos nuestro hilo
            Teclas.Abort();
            LimpiarTodo();
        }

        private List<Process> GetProcesses()
        {
            List<Process> processes = new List<Process>();
            ActualProcess.Status = "Ejecución";
            ActualProcess.Result = "NULL";
            ActualProcess.BloqTimer = -1;
            processes.Add(ActualProcess);
            if(ProcesosRegistrados.Count > 0)
            {
                foreach (var process in ProcesosRegistrados)
                {
                    process.Status = "Nuevo";
                    process.ServiceTime = -1;
                    process.Result = "NULL";
                    process.TransTime = 0;
                    process.BloqTimer = -1;
                    process.ComingTime = -1;
                    processes.Add(process);
                }
            }
            if(_RoundRobin.Count > 0)
            {
                foreach (var process in _RoundRobin)
                {
                    process.Status = "Listo";
                    process.TransTime = -1;
                    process.Result = "NULL";
                    process.BloqTimer = -1;
                    processes.Add(process);
                }
            }
            if(_Bloqueados.Count > 0)
            {
                foreach (var process in _Bloqueados)
                {
                    process.Status = "Bloqueado";
                    process.Result = "NULL";
                    processes.Add(process);
                }
            }
            if(ProcesosFinalizados.Count > 0)
            {
                foreach (var process in ProcesosFinalizados)
                {
                    process.BloqTimer = -1;
                    process.Status = "Finalizado";
                    processes.Add(process);
                }
            }

            return processes.OrderBy((p) => p.ProcessID).ToList();
        }

        private void LimpiarTodo()
        {
            DgvListos.ItemsSource = null;
            TbID.Text = "ID: ";
            TbValor1.Text = "Numero 1: ";
            TbOperator.Text = "Operador: ";
            TbValor2.Text = "Numero 2: ";
            TbTime.Text = "Tiempo maximo: ";
            TbTimeRes.Text = "Tiempo restante:";
            TbTimeTrans.Text = "Tiempo transcurrido:";
            ProcesosRegistrados.Clear();
            _Bloqueados.Clear();
            TbNumProcesos.Clear();
            Time = 0;
            NumProcesos = 1;
            BtnInicio.IsEnabled = true;
            TbQuantum.IsEnabled = true;
            TbNumProcesos.IsEnabled = true;
            Refresh();
        }

        #endregion
    }
}
