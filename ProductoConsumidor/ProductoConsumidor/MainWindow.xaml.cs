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
        //Variable diseñara para saber en que punto de inserccion de producto nos quedamos
        private int Ultimo = 0;

        //Variable diseñara para saber en que punto de consumo de producto nos quedamos
        private int ConsumidorUltimo = 0;

        private bool Inicio = false;
        private bool Final = true;
        private readonly Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Creamos una lista la cual controlara la modificacion del producto
            _Images = new List<Image>
            {
                D1, D2 , D3, D4, D5, D6, D7, D8, D9, D10,
                D11, D12, D13, D14, D15, D16, D17, D18, D19, D20
            };
        }

        private async void BtnIniciar_Click(object sender, RoutedEventArgs e)
        {
            //Desactivamos el boton para evitar errores
            BtnIniciar.Visibility = Visibility.Hidden;
            //Se llama la funcion para detectar la tecla ESC
            Teclaso();

            //Inicializamos las imagenes en estado oculto
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
            while (Final)
            {
                await IngresarProducto();

                await LlamarConsumidor();
            }
        }

        /// <summary>
        /// Encargada de hacer la animacion de agregar productos
        /// </summary>
        /// <returns>Nada</returns>
        private async Task IngresarProducto()
        {
            //Se crea la animacion para el productor
            var Animation = new DoubleAnimation();
            Animation.From = 1;
            Animation.To = 0;
            Animation.AutoReverse = true;
            Productor.BeginAnimation(Image.OpacityProperty, Animation);

            //Se genera un numero random el cual es el numero de productos que se agregaran
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
                        await Task.Delay(600);
                    }
                }
                else
                {
                    _Images[Ultimo].Visibility = Visibility.Visible;
                    await Task.Delay(600);
                }
                //Se incrementa el contador el cual registrara en que registro se quedo el ultimo
                //producto insertado
                Ultimo++;
            }
        }

        /// <summary>
        /// Encargada de detectar la presion de la tecla ESC y cerrar el programa
        /// </summary>
        private void Teclaso()
        {
            Dispatcher.Invoke(new Action(async () =>
           {
               while (true)
               {
                   await Task.Delay(10);
                   if (Keyboard.GetKeyStates(Key.Escape) == KeyStates.Down)
                   {
                       Final = false;
                   }
               }
           }));

        }

        /// <summary>
        /// Encargada de consumir los productos y despertar el consumidor
        /// </summary>
        /// <returns>Nada</returns>
        private async Task LlamarConsumidor()
        {
            //Se actualiza estado del consumidor
            ConsumidorEstado.Content = "Activo";
            await Task.Delay(100);
            //Se agrega una pequeña animacion a la imagen del consumidor
            var Animation = new DoubleAnimation();
            Animation.From = 1;
            Animation.To = 0;
            Animation.AutoReverse = true;
            Consumidor.BeginAnimation(Image.OpacityProperty, Animation);

            //Se saca un numero random el cual sera el numero de elementos
            //que se consumira
            var Consumo = random.Next(5, 20);
            for (int i = 0; i < Consumo; i++)
            {
                //Se validan la diferentes posibilidades existentes para que sea un
                //tipo de lista circular
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
                else
                {
                    _Images[ConsumidorUltimo].Visibility = Visibility.Hidden;
                }
                ConsumidorUltimo++;
                await Task.Delay(500);
            }
            //Actualizamos
            ConsumidorEstado.Content = "Dormido";
        }
    }
}
