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
    /// Логика взаимодействия для CoffeeMachineMenu.xaml
    /// </summary>
    public partial class CoffeeMachineMenu : UserControl
    {
        private readonly CoffeeMachine machine;

        public CoffeeMachineMenu()
        {
            InitializeComponent();
        }

        public CoffeeMachineMenu(CoffeeMachine machine) : this()
        {
            this.machine = machine;
            MakeLatte.Click += (s, e) => machine.MakeLatte();
            MakeCappucino.Click += (s, e) => machine.MakeCappucino();
        }
    }
}
