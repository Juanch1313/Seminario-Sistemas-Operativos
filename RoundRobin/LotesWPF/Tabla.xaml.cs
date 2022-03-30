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
    /// Lógica de interacción para Tabla.xaml
    /// </summary>
    public partial class Tabla : Window
    {
        public Tabla()
        {
            InitializeComponent();
        }

        private List<Process> processes = new List<Process>();
    }
}
