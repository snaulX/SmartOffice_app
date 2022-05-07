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

        private async void CreateCoffee() => await Client.Get("/coffee/create");

        public CoffeeMachine()
        {
            InitializeComponent();
            IconButton.Click += (object sender, RoutedEventArgs e) => MainWindow.Current = this;
            CreateCoffee();
            _index = lastIndex++;
        }

        public new Task<string> Name => Client.Get($"coffee/{_index}/name");

        public Task<string> Status => Client.Get($"coffee/{_index}/status");

        public string ImageStatus => "Image/Gut.png";

        public UserControl Menu => new CoffeeMachineMenu(this);

        public async void MakeLatte()
        {
            await Client.Post($"coffee/{_index}/make", "latte");
            MainWindow.Instance.UpdateCurrentDevice();
        }
        public async void MakeCappucino()
        {
            await Client.Post($"coffee/{_index}/make", "cappucino");
            MainWindow.Instance.UpdateCurrentDevice();
        }
    }
}
