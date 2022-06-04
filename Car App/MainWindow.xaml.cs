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
            
            Car car1 = new Car("25006HRT",Make.Black,Model.SUV,2010,20000);
            Car car2 = new Car("34218JJT",Make.Grey,Model.Sedan,2005,10000);
            Car car3 = new Car("90045QER",Make.Red,Model.SportsCar,2020,200000);
            Car car4 = new Car("56738IHP",Make.Yellow,Model.Truck,1999,6000);
            Car car5 = new Car("45453KLA",Make.White,Model.Convertible,2021,50000);
            garage.TryAddCarByPosition(car1, 1);
            garage.TryAddCarByPosition(car2, 4);
            garage.TryAddCarByPosition(car3, 7);
            garage.TryAddCarByPosition(car4, 11);
            garage.TryAddCarByPosition(car5, 15);
            InitializeComponent();
            ListBoxCars.ItemsSource = garage.GetCarsFromLot();
            ComboboxMake.ItemsSource = Enum.GetValues(typeof(Make)).Cast<Make>();
            ComboboxMake.SelectedItem = Make.None;
            ComboboxModel.ItemsSource = Enum.GetValues(typeof(Model)).Cast<Model>();
            ComboboxModel.SelectedItem = Model.None;
        }

        private void ListBoxSelectionEvent(object sender, SelectionChangedEventArgs e)
        {

            if(ListBoxCars.SelectedItem != null)
            {
                CarImage.Source = new BitmapImage(new Uri(@"" + (ListBoxCars.SelectedItem as Car).photoFilename, UriKind.Relative));
            }
        }

        private void SearchButtonClicked(object sender, RoutedEventArgs e)
        {
            List<Car> search = garage.GetCarsFromLot();
            try
            {
                if (TextboxBudgetMin.Text != "" || TextboxBudgetMax.Text != "")
                {
                    search = garage.SearchbyBudget(search, TextboxBudgetMin.Text == "" ? 0 : Int32.Parse(TextboxBudgetMin.Text), TextboxBudgetMax.Text == "" ? Int32.MaxValue : Int32.Parse(TextboxBudgetMax.Text));
                }   
                if (TextboxYearMin.Text != "" || TextboxYearMax.Text != "")
                {
                    search = garage.SearchbyYear(search, TextboxYearMin.Text == "" ? 1900 : Int32.Parse(TextboxYearMin.Text), TextboxYearMax.Text == "" ? 2100 : Int32.Parse(TextboxYearMax.Text));
                }
                if (ComboboxMake.SelectedItem.ToString() != "None")
                {
                    search = garage.SearchbyMake(search, (Make)ComboboxMake.SelectedItem);
                }
                if (ComboboxModel.SelectedItem.ToString() != "None")
                {
                    search = garage.SearchbyModel(search, (Model)ComboboxModel.SelectedItem);
                }
                ListBoxCars.ItemsSource = search;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ResetButtonClicked(object sender, RoutedEventArgs e)
        {
            TextboxYearMin.Text = "";
            TextboxYearMax.Text = "";
            TextboxBudgetMin.Text = "";
            TextboxBudgetMax.Text = "";
            TextboxRego.Text = "";
            TextboxCarPosition.Text = "";
            ComboboxMake.SelectedItem = Make.None;
            ComboboxModel.SelectedItem = Model.None;
            ListBoxCars.ItemsSource = garage.GetCarsFromLot();
        }

        private void PositionSearchButtonClicked(object sender, RoutedEventArgs e)
        {
            List<Car> list = new List<Car>();
            try
            {
                if(TextboxCarPosition.Text != "")
                {
                    list.Add(garage.GetCarByPosition(Int32.Parse(TextboxCarPosition.Text)));
                    ListBoxCars.ItemsSource = list;
                }
                else
                {
                    ListBoxCars.ItemsSource = garage.GetCarsFromLot();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RegoSearchButtonCLicked(object sender, RoutedEventArgs e)
        {
            List<Car> list = new List<Car>();
            try
            {
                if(TextboxRego.Text != "")
                {
                    list.Add(garage.GetCarByRego(TextboxRego.Text));
                    ListBoxCars.ItemsSource = list;
                }
                else
                {
                    ListBoxCars.ItemsSource = garage.GetCarsFromLot();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
