using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_App
{
    class Garage /*: IEnumerable*/
    {
        Car[] parkingSpots = new Car[20];
        public List<Car> SoldCars = new List<Car>();

        /// <summary>
        /// <para>Adds car to first available position, returns true if successful, returns false if not.</para>
        /// <br>A false return indicates that there are no available positions left.</br>
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public bool TryAddCar(Car car)
        {
            List<int> list = GetEmptySpots();
            if(list.Count > 0)
            {
                if(TryAddCarByPosition(car, list.First()))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// <para>Adds car by position, returns true if successful, returns false if not.</para>
        /// <br>A false return indicates that the current position is already taken.</br>
        /// </summary>
        /// <param name="car"></param>
        /// <param name="position">Number between 1 and 20</param>
        /// <returns></returns>
        public bool TryAddCarByPosition(Car car, int position)
        {
            if(parkingSpots[position - 1] == null)
            {
                parkingSpots[position - 1] = car;
                return true;
            }
            return false;
        }

        public bool TryRemoveCarByPosition(Car car, int position)
        {
            if (parkingSpots[position - 1] != null)
            {
                SoldCars.Add(car);
                parkingSpots[position - 1] = null;
                return true;
            }
            return false;
        }

        public bool ValidateUniqueRego(Car car)
        {
            foreach (Car parkedCar in parkingSpots)
            {
                if (parkedCar.RegoNumber == car.RegoNumber)
                {
                    return false;
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
                cars.Add(car);
            }
            return cars;
        }

        public Car GetCarByPosition(int position)
        {
            return parkingSpots[position - 1];
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

        public Car GetCarByRego(string rego)
        {
            return parkingSpots.ToList().Find(car => car.RegoNumber == rego.ToUpper());
        }

        //public bool TryGetCarByRego(string rego, out Car car)
        //{
        //    car = parkingSpots.ToList().Find(c => c.RegoNumber == rego.ToUpper());
        //    if(car != null)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        public bool TryGetCarByRego(string rego, out Car car)
        {
            try
            {
                car = parkingSpots.ToList().Find(c => c.RegoNumber == rego.ToUpper());
                return true;
            }
            catch (ArgumentNullException)
            {
                car = null;
                return false;
            }
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

        //public int GetEmptySpotsCount()
        //{
        //    return GetEmptySpots().Count();
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return (IEnumerator)GetEnumerator();
        //}

        //public GarageEnum GetEnumerator()
        //{
        //    return new GarageEnum(parkingSpots);
        //}
    }

   //class GarageEnum : IEnumerator
   // {
   //     Car[] parkingSpots;
   //     int position = -1;

   //     public GarageEnum(Car[] list)
   //     {
   //         parkingSpots = list;
   //     }

   //     object IEnumerator.Current
   //     {
   //         get
   //         {
   //             return Current;
   //         }
   //     }

   //     public Car Current
   //     {
   //         get
   //         {
   //             try
   //             {
   //                 return parkingSpots[position];
   //             }
   //             catch (ArgumentOutOfRangeException)
   //             {
   //                 throw new InvalidOperationException();
   //             }
   //         }
   //     }

   //     public bool MoveNext()
   //     {
   //         position++;
   //         return (position < parkingSpots.Length);
   //     }

   //     public void Reset()
   //     {
   //         position = -1;
   //     }
   // }
}
