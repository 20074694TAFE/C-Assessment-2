using System;
using System.Diagnostics;
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

namespace Car_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Garage garage = new Garage();
        public MainWindow()
        {
            InitializeComponent();
            Car car1 = new Car("25006HRT",Make.Black,Model.SUV,2010,20000);
            Car car2 = new Car("34218JJT",Make.Grey,Model.Sudan,2005,10000);
            Car car3 = new Car("90045QER",Make.Red,Model.SportsCar,2020,200000);
            Car car4 = new Car("56738IHP",Make.Yellow,Model.Truck,1999,6000);
            Car car5 = new Car("45453KLA",Make.White,Model.Convertible,2021,50000);
            garage.TryAddCarByPosition(car1, 1);
            garage.TryAddCarByPosition(car2, 4);
            garage.TryAddCarByPosition(car3, 7);
            garage.TryAddCarByPosition(car4, 11);
            garage.TryAddCarByPosition(car5, 15);
        }
    }
}
