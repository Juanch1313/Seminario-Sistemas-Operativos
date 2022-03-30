using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using lotes.Clases;
using System.Windows.Input;
using System.Runtime.InteropServices;

namespace lotes
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        private List<Process> ProcesosRegistrados = new List<Process>();
        private List<Lote> lotes = new List<Lote>();
        private List<Process> ProcesosFinalizados = new List<Process>();
        int NumProcesos = 1;
        int Time = 0;
        bool Pausa = false;
        bool Error = false;
        bool Interrupcion = false;


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TbNumProcesos.Text.All(c => Char.IsNumber(c)))
            {
                Random number = new Random();
                //Generar procesos en lista
                for (int nP = 0; nP < Convert.ToInt32(TbNumProcesos.Text); nP++)
                {
                    //Se crean procesos, los cuales se les llenaran los datos mediante el siguiente switch
                    //Dicho switch asignara datos como lo son los valores, operacion y tiempo maximo
                    Process process = new Process();
                    switch (number.Next(1, 5))
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
            Thread Teclas = new Thread(Teclasos);
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
                    Refresh();
                    //Sacamos el proceso
                    Process process = lote.process.Dequeue();
                    //Actualizamos la tabla de procesos en espera
                    ActualizarTabla(lote.process, LoteActual);
                    //Colocamos los datos de el proceso en ejecucion
                    lbID.Text = "ID: " + process.ProcessID.ToString();
                    LbValor1.Text = "Numero 1: " + process.FValue.ToString();
                    LbOperator.Text = "Operador: " + process.Operator.ToString();
                    LbValor2.Text = "Numero 2: " + process.SValue.ToString();
                    LbTime.Text = "Tiempo maximo: " + process.MaxTime.ToString();
                    Refresh();
                    //Ciclo for para el tiempo de el proceso
                    for (int j = 0; j < process.MaxTime; j++)
                    {
                        //Si se detecta alguna discrepancia ya sea error interrupcion o pausa se hara saber
                        Thread.Sleep(500);
                        if (Interrupcion && !lote.process.Contains(process))
                        {
                            MessageBox.Show("Se interrumpio el proceso. Se volvera a encolar");
                            process.MaxTime -= j;
                            break;
                        }
                        Thread.Sleep(100);
                        if (Error) { MessageBox.Show("Error, se pasara al siguiente proceso"); break; }
                        Thread.Sleep(100);
                        if (Pausa) { MessageBox.Show("Se pausara el programa"); while (Pausa) { Thread.Sleep(100); } }
                        Time++;
                        LbReloj.Text = "Temporizador: " + Time;
                        LbTimeTrans.Text = "Tiempo transcurrido: " + j.ToString();
                        LbTimeRes.Text = "Tiempo restante: " + (process.MaxTime - j).ToString();
                        Refresh();
                    }

                    //Sacamos el resultado de la operacion
                    if (Error) { 
                        Error = false;
                        ActualizarTabla(lote.process, LoteActual);
                        process.Result = 0.0f;
                        process.Status = "ERROR";
                        process.NumeroLote = LoteActual;
                        ProcesosFinalizados.Add(process);
                        dgvFinalizados.DataSource = null;
                        //Añademos los procesos terminados a la tabla designada
                        dgvFinalizados.DataSource = ProcesosFinalizados;
                        CambiarTitulos();
                        Refresh();
                    }
                    else
                    {
                        if (Interrupcion)
                        {
                            lote.process.Enqueue(process);
                            Refresh();
                            i--;
                            Interrupcion = false;
                            ActualizarTabla(lote.process, LoteActual);
                            Refresh();
                        }
                        else
                        {
                            process.Status = "CORRECTO";
                            process.Result = SacarResultado(process);
                            process.NumeroLote = LoteActual;
                            ProcesosFinalizados.Add(process);
                            dgvFinalizados.DataSource = null;
                            //Añademos los procesos terminados a la tabla designada
                            dgvFinalizados.DataSource = ProcesosFinalizados;
                            CambiarTitulos();
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

        private void ActualizarTabla(Queue<Process> processes, int LoteActual)
        {
            //Limpiamos la tabla para evitar datos basura
            DgvLote.Rows.Clear();
            //Se agregan los procesos a la tabla de espera
            for (int i = 0; i < processes.Count; i++)
            {
                DgvLote.Rows.Add();
                DgvLote.Rows[i].Cells[0].Value = processes.ElementAt(i).ProcessID.ToString();
                DgvLote.Rows[i].Cells[1].Value = LoteActual.ToString();
                DgvLote.Rows[i].Cells[2].Value = processes.ElementAt(i).FValue.ToString();
                DgvLote.Rows[i].Cells[3].Value = processes.ElementAt(i).Operator;
                DgvLote.Rows[i].Cells[4].Value = processes.ElementAt(i).SValue.ToString();
                DgvLote.Rows[i].Cells[5].Value = processes.ElementAt(i).MaxTime.ToString();
                Refresh();
            }
            Refresh();
        }

        private void CambiarTitulos()
        {
            //Se cambian los titulos de la tabla de procesos finalizados
            Task.Run(() =>
            {
                dgvFinalizados.Columns[0].HeaderText = "ID";
                dgvFinalizados.Columns[1].HeaderText = "Estado";
                dgvFinalizados.Columns[2].HeaderText = "Valor 1";
                dgvFinalizados.Columns[3].HeaderText = "Valor 2";
                dgvFinalizados.Columns[4].HeaderText = "Operador";
                dgvFinalizados.Columns[5].HeaderText = "Resultado";
                dgvFinalizados.Columns[6].HeaderText = "Tiempo";
                dgvFinalizados.Columns[7].HeaderText = "No Lote";
            });
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

        //Funcion para resetear todo
        private void LimpiarTodo()
        {
            DgvLote.Rows.Clear();
            lbID.Text = "ID: ";
            LbValor1.Text = "Numero 1: ";
            LbOperator.Text = "Operador: ";
            LbValor2.Text = "Numero 2: ";
            LbTime.Text = "Tiempo maximo: ";
            LbTimeRes.Text = "Tiempo restante:";
            LbTimeTrans.Text = "Tiempo transcurrido:";
            ProcesosRegistrados.Clear();
            lotes.Clear();
            TbNumProcesos.Clear();
            Time = 0;
            NumProcesos = 0;
            TbNumProcesos.Enabled = true;
        }

        private void Teclasos()
        {
            //Aqui se leeran las teclas para poder asignar las debidas interrupciones
            //Tambien se añadieron alternativas dado que C# suele tener errores en lectura de teclas
            //(Por lo menos en Windows Forms (El tipo de proyecto))
            while (true)
            {
                Thread.Sleep(100);
                if (ModifierKeys == Keys.P || ModifierKeys == Keys.Control)
                {
                    Pausa = Pausa ? false : true;
                }
                if(ModifierKeys == Keys.Shift || ModifierKeys == Keys.E)
                {
                    Error = true;
                }
                if (ModifierKeys == Keys.Alt || ModifierKeys == Keys.I)
                {
                    Interrupcion = true;
                }
            }
        }
        #endregion
    }
}
