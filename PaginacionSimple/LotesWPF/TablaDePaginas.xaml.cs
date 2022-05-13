using LotesWPF.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LotesWPF
{
    /// <summary>
    /// Lógica de interacción para TablaDePaginas.xaml
    /// </summary>
    public partial class TablaDePaginas : Window
    {
        public TablaDePaginas()
        {
            InitializeComponent();
        }
        public class Paginas{
            public int ProcessID { get; set; }
            public int Size { get; set; }
            public int Marcos { get; set; }
            public string Frames { get; set; }
        }

        private List<Paginas> paginas;

        public void SetProcess(List<Marco> marcos, List<Process> processes)
        {
            paginas = new List<Paginas>();
            paginas.Clear();
            for (int i = 0; i < processes.Count; i++)
            {
                int count = 0;
                string frame = "";
                foreach (var marco in marcos)
                {
                    if(marco.ProcessID == processes[i].ProcessID)
                    {
                        count++;
                        frame += $"{marco.Id.ToString()}, ";
                    }
                }
                paginas.Add(new Paginas()
                {
                    ProcessID = processes[i].ProcessID,
                    Size = processes[i].Size,
                    Marcos = count,
                    Frames = frame
                });

            }
            DgvPaginas.ItemsSource = paginas;
        }
    }
}
