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
    /// Lógica de interacción para TablaBCP.xaml
    /// </summary>
    public partial class TablaBCP : Window
    {
        public TablaBCP()
        {
            InitializeComponent();
        }

        private List<Process> _ActualProcess;

        public void SetProcess(List<Process> ActualProcess)
        {
            _ActualProcess = ActualProcess;
            DgvBCP.ItemsSource = null;
            DgvBCP.ItemsSource = _ActualProcess;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.C)
            {
                Close();
            }
        }
    }
}
