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

        private static void UpdateCurrentDevice()
        {
            instance.DeviceName.Text = current.Name;
            instance.DeviceMenu = current.Menu;
            instance.DeviceStatus.Text = current.Status;
            instance.DeviceStatusIcon.Source = new ImageSourceConverter().ConvertFromString(current.ImageStatus) as ImageSource;
        }

        public static IDevice Current 
        { 
            get => current; 
            set
            {
                current = value;
                UpdateCurrentDevice();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            instance = this;
        }
    }
}
