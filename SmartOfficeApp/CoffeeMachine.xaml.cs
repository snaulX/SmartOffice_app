using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
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

namespace SmartOfficeApp
{
    /// <summary>
    /// Логика взаимодействия для CoffeeMachine.xaml
    /// </summary>
    public partial class CoffeeMachine : UserControl, IDevice
    {
        private static int lastIndex = 0;

        private int _index;

        private async void CreateCoffee() => await Client.Request("/coffee/create");

        public CoffeeMachine()
        {
            InitializeComponent();
            IconButton.Click += (object sender, RoutedEventArgs e) => MainWindow.Current = this;
            CreateCoffee();
            _index = lastIndex++;
        }

        public string Status => Client.Request($"coffee/{_index}/status").Result;

        public string ImageStatus => "Gut.png";

        public UserControl Menu => new CoffeeMachineMenu(this);

        public async void Update()
        {
            await Client.Request($"coffee/{_index}/update");
        }

        public async void MakeCoffee()
        {
            await Client.Request($"coffee/{_index}/make");
        }
    }
}
