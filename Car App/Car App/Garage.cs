using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_App
{
    class Garage
    {
        Car[] parkingSpots = new Car[20];
        public List<Car> SoldCars = new List<Car>();

        public Dictionary<int, Car> GetDictCarsFromLot()
        {
            Dictionary<int, Car> dict = new Dictionary<int, Car>();
            foreach (Car car in parkingSpots)
            {
                dict.Add(Array.FindIndex(parkingSpots, spot => spot == car) + 1, car);
            }
            return dict;
        }

        public List<Car> GetCarsFromLot()
        {
            List<Car> cars = new List<Car>();
            foreach(Car car in parkingSpots)
            {
                cars.Add(car);
            }
            return cars;
        }

        public Car GetCarBySpot(int spot)
        {
            return parkingSpots[spot + 1];
        }

        public List<Car> SearchByBudget(List<Car> cars, float min = 0f, float max = float.MaxValue)
        {
            return cars.Where(car => car.Price >= min && car.Price <= max).ToList();
        }

        public List<Car> SearchbyModel(List<Car> cars, Model model)
        {
            return cars.Where(car => car.CarModel == model).ToList();
        }

        public List<Car> SearchByMake(List<Car> cars, Make make)
        {
            return cars.Where(car => car.CarMake == make).ToList();
        }

        public Car GetCarByRego(int rego)
        {
            return parkingSpots.ToList<Car>().Find(car => car.RegoNumber == rego);
        }

        public bool TryGetCarByRego(int rego, out Car car)
        {
            car = parkingSpots.ToList<Car>().Find(c => c.RegoNumber == rego);
            if(car != null)
            {
                return true;
            }
            return false;
        }

        public List<int> GetEmptySpots()
        {
            List<int> list = new List<int>();
            for(int i = 0; i < parkingSpots.Length; i++)
            {
                if(parkingSpots[i] == null)
                {
                    list.Add(i + 1);
                }
            }
            return list;
        }

    }
}
