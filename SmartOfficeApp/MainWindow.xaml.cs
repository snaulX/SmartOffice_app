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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartOfficeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow instance;
        private static IDevice current;

        private async void UpdateCurrentDevice()
        {
            DeviceName.Text = await current.Name;
            DeviceMenu = current.Menu;
            DeviceStatus.Text = await current.Status;
            DeviceStatusIcon.Source = new ImageSourceConverter().ConvertFromString(current.ImageStatus) as ImageSource;
        }

        public static IDevice Current 
        { 
            get => current; 
            set
            {
                current = value;
                instance.UpdateCurrentDevice();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            instance = this;
        }

        private void Button_UpdateCurrentDevice(object sender, RoutedEventArgs e)
        {
            UpdateCurrentDevice();
        }
    }
}
