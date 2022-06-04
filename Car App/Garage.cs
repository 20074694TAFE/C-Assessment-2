using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_App
{
    public class Garage : IEnumerable
    {
        public Car[] parkingSpots = new Car[20];
        public List<Car> SoldCars = new List<Car>();

        /// <summary>
        /// <para>Adds car to first available position, returns true if successful, returns false if not.</para>
        /// <br>A false return indicates that there are no available positions left, or not unique rego.</br>
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public bool TryAddCar(Car car)
        {
            List<int> list = GetEmptySpots();
            if (list.Count > 0)
            {
                if (TryAddCarByPosition(car, list.First()))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// <para>Adds car by position, returns true if successful, returns false if not.</para>
        /// <br>A false return indicates that the current position is already taken, or not unique rego.</br>
        /// </summary>
        /// <param name="car"></param>
        /// <param name="position">Number between 1 and 20</param>
        /// <returns></returns>
        public bool TryAddCarByPosition(Car car, int position)
        {
            if (parkingSpots[position - 1] == null)
            {
                parkingSpots[position - 1] = car;
                return true;
            }
            return false;
        }

        public bool TryRemoveCarByPosition(int position)
        {
            if (parkingSpots[position - 1] != null)
            {
                SoldCars.Add(parkingSpots[position - 1]);
                parkingSpots[position - 1] = null;
                return true;
            }
            return false;
        }

        public bool ValidateUniqueRego(Car car)
        {
            
            foreach (Car parkedCar in parkingSpots)
            {
                if (parkedCar?.RegoNumber == car.RegoNumber)
                {
                    return false;
                }
            }
            if(SoldCars.Count() != 0)
            {
                foreach (Car soldCar in SoldCars)
                {
                    if (soldCar?.RegoNumber == car.RegoNumber)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

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
                if(car != null)
                {
                    cars.Add(car);
                }
            }
            return cars;
        }

        public Car GetCarByPosition(int position)
        {
            return parkingSpots[position - 1];
        }

        public bool HasCar(List<Car> list, Car car)
        {
           return list.Contains(car);
        }

        public List<Car> SearchbyBudget(List<Car> cars, float min = 0f, float max = float.MaxValue)
        {
            if (min > max)
            {
                throw new Exception("Minimum budget value cannot be greater than maximum budget value");
            }
            return cars.Where(car => car.Price >= min && car.Price <= max).ToList();
        }

        public List<Car> SearchbyModel(List<Car> cars, Model model)
        {
            return cars.Where(car => car.CarModel == model).ToList();
        }

        public List<Car> SearchbyMake(List<Car> cars, Make make)
        {
            return cars.Where(car => car.CarMake == make).ToList();
        }

        public List<Car> SearchbyYear(List<Car> cars, int min, int max)
        {
            if (min > max)
            {
                throw new Exception("Minimum year value cannot be greater than maximum year value");
            }
            return cars.Where(car => car.CarYear <= max && car.CarYear >= min).ToList();
        }

        public Car GetCarByRego(string rego)
        {
            try
            {
                Car found = null;
                if(parkingSpots.Cast<Car>().Any(car => car?.RegoNumber == rego.ToUpper()))
                {
                    found = parkingSpots.ToList().FirstOrDefault(car => car.RegoNumber == rego.ToUpper());
                }
                return found;
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        public int GetPositionOfCar(Car car)
        {
            return parkingSpots.ToList().IndexOf(car) + 1;
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

        public int GetEmptySpotsCount()
        {
            return GetEmptySpots().Count();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public GarageEnum GetEnumerator()
        {
            return new GarageEnum(parkingSpots);
        }
    }

    public class GarageEnum : IEnumerator
    {
        Car[] parkingSpots;
        int position = -1;

        public GarageEnum(Car[] list)
        {
            parkingSpots = list;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Car Current
        {
            get
            {
                try
                {
                    return parkingSpots[position];
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public bool MoveNext()
        {
            position++;
            return (position < parkingSpots.Length);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
