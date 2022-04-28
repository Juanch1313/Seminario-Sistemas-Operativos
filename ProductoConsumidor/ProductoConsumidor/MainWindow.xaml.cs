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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductoConsumidor
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Image> _Images;
        private int Ultimo = 0;
        private int ConsumidorUltimo = 0;
        private bool Inicio = false;
        private readonly Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _Images = new List<Image>
            {
                D1, D2 , D3, D4, D5, D6, D7, D8, D9, D10,
                D11, D12, D13, D14, D15, D16, D17, D18, D19, D20
            };
        }

        private async void BtnIniciar_Click(object sender, RoutedEventArgs e)
        {
            Teclaso();
            foreach (var imagen in _Images)
            {
                Dispatcher.Invoke(new Action(async () =>
               {
                   if(imagen.Visibility == Visibility.Visible && !Inicio) 
                   {
                       imagen.Visibility = Visibility.Hidden;
                   }
                   await Task.Delay(100);
               }));
            }
            Inicio = true;
            while (true)
            {
                await IngresarProducto();

                await LlamarConsumidor();
            }
        }

        private async Task IngresarProducto()
        {
            var Animation = new DoubleAnimation();
            Animation.From = 1;
            Animation.To = 0;
            Animation.AutoReverse = true;

            Productor.BeginAnimation(Image.OpacityProperty, Animation);

            var pos = random.Next(5, 20);
            await Task.Delay(100);
            for (int i = 0; i < pos; i++)
            {
                if (Ultimo == 20) { Ultimo = 0; }
                if (Ultimo + 1 < 20)
                {
                    if (_Images[Ultimo + 1].Visibility == Visibility.Visible)
                    {
                        break;
                    }
                    else
                    {
                        _Images[Ultimo].Visibility = Visibility.Visible;
                        Ultimo++;
                        await Task.Delay(600);
                    }
                }
            }
        }

        private void Teclaso()
        {
            Dispatcher.Invoke(new Action(async () =>
           {
               while (true)
               {
                   await Task.Delay(10);
                   if (Keyboard.GetKeyStates(Key.Escape) == KeyStates.Down)
                   {
                       Application.Current.Shutdown();
                   }
               }
           }));

        }

        private async Task LlamarConsumidor()
        {
            await Task.Delay(100);
            var Animation = new DoubleAnimation();
            Animation.From = 1;
            Animation.To = 0;
            Animation.AutoReverse = true;

            Consumidor.BeginAnimation(Image.OpacityProperty, Animation);

            var Consumo = random.Next(5, 20);
            for (int i = 0; i < Consumo; i++)
            {
                if (ConsumidorUltimo == 20) { ConsumidorUltimo = 0; }
                if (ConsumidorUltimo + 1 < 20)
                {
                    if (_Images[ConsumidorUltimo + 1].Visibility == Visibility.Hidden)
                    {
                        break;
                    }
                    else
                    {
                        _Images[ConsumidorUltimo].Visibility = Visibility.Hidden;
                    }
                    await Task.Delay(100);
                }
                ConsumidorUltimo++;
                await Task.Delay(500);
            }
        }
    }
}
