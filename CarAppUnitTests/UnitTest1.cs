using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Car_App;

namespace CarAppUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetCarByRegoTest()
        {
            Garage garage = new Garage();
            Car car1 = new Car("25006HRT", Make.Black, Model.SUV, 2010, 20000);
            Car car2 = new Car("34218JJT", Make.Grey, Model.Sedan, 2005, 10000);
            Car car3 = new Car("90045QER", Make.Red, Model.SportsCar, 2020, 200000);
            Car car4 = new Car("56738IHP", Make.Yellow, Model.Truck, 1999, 6000);
            Car car5 = new Car("45453KLA", Make.White, Model.Convertible, 2021, 50000);
            
            garage.TryAddCarByPosition(car1, 1);
            garage.TryAddCarByPosition(car2, 4);
            garage.TryAddCarByPosition(car3, 7);
            garage.TryAddCarByPosition(car4, 11);
            garage.TryAddCarByPosition(car5, 15);
            
            Assert.AreEqual(car1, garage.GetCarByRego("25006hrt"));
            Assert.IsNull(garage.GetCarByRego("34534JJJ"));
            Assert.AreNotEqual(car2, garage.GetCarByRego("25006hrt"));
        }

        [TestMethod]
        public void TryAddCarByPostionTest()
        {
            Garage garage = new Garage();
            Car car1 = new Car("25006HRT", Make.Black, Model.SUV, 2010, 20000);
            Car car2 = new Car("34218JJT", Make.Grey, Model.Sedan, 2005, 10000);
            Car car3 = new Car("90045QER", Make.Red, Model.SportsCar, 2020, 200000);
            Car car4 = new Car("56738IHP", Make.Yellow, Model.Truck, 1999, 6000);
            Car car5 = new Car("45453KLA", Make.White, Model.Convertible, 2021, 50000);
            Car car6 = new Car("55555TYH", Make.Blue, Model.HatchBack, 2006, 7000);
            Car car7 = new Car("34561FFG", Make.White, Model.Truck, 2005, 8000);

            garage.TryAddCarByPosition(car1, 1);
            garage.TryAddCarByPosition(car2, 4);
            garage.TryAddCarByPosition(car3, 7);
            garage.TryAddCarByPosition(car4, 11);
            garage.TryAddCarByPosition(car5, 15);

            Assert.IsTrue(garage.TryAddCarByPosition(car6, 3));
            Assert.IsFalse(garage.TryAddCarByPosition(car7, 3));
            Assert.IsTrue(garage.TryAddCarByPosition(car7, 5));
            Assert.IsTrue(garage.GetCarsFromLot().Count == 7);
        }

        [TestMethod]
        public void TryRemoveCarByPostionTest()
        {
            Garage garage = new Garage();
            Car car1 = new Car("25006HRT", Make.Black, Model.SUV, 2010, 20000);
            Car car2 = new Car("34218JJT", Make.Grey, Model.Sedan, 2005, 10000);
            Car car3 = new Car("90045QER", Make.Red, Model.SportsCar, 2020, 200000);
            Car car4 = new Car("56738IHP", Make.Yellow, Model.Truck, 1999, 6000);
            Car car5 = new Car("45453KLA", Make.White, Model.Convertible, 2021, 50000);

            garage.TryAddCarByPosition(car1, 1);
            garage.TryAddCarByPosition(car2, 4);
            garage.TryAddCarByPosition(car3, 7);
            garage.TryAddCarByPosition(car4, 11);
            garage.TryAddCarByPosition(car5, 15);

            Assert.IsTrue(garage.TryRemoveCarByPosition(1));
            Assert.IsFalse(garage.TryRemoveCarByPosition(1));
            Assert.IsTrue(garage.TryRemoveCarByPosition(4));
            Assert.IsTrue(garage.SoldCars.Count == 2);
            Assert.IsFalse(garage.TryRemoveCarByPosition(4));
            Assert.IsTrue(garage.TryRemoveCarByPosition(7));
            Assert.IsTrue(garage.TryRemoveCarByPosition(11));
            Assert.IsTrue(garage.TryRemoveCarByPosition(15));
            Assert.IsTrue(garage.GetCarsFromLot().Count == 0);
            Assert.IsTrue(garage.SoldCars.Count == 5);
        }

        [TestMethod]
        public void GetPositionOfCarTest()
        {
            Garage garage = new Garage();
            Car car1 = new Car("25006HRT", Make.Black, Model.SUV, 2010, 20000);
            Car car2 = new Car("34218JJT", Make.Grey, Model.Sedan, 2005, 10000);
            Car car3 = new Car("90045QER", Make.Red, Model.SportsCar, 2020, 200000);
            Car car4 = new Car("56738IHP", Make.Yellow, Model.Truck, 1999, 6000);
            Car car5 = new Car("45453KLA", Make.White, Model.Convertible, 2021, 50000);
            Car car6 = new Car("55555TYH", Make.Blue, Model.HatchBack, 2006, 7000);

            garage.TryAddCarByPosition(car1, 1);
            garage.TryAddCarByPosition(car2, 4);
            garage.TryAddCarByPosition(car3, 7);
            garage.TryAddCarByPosition(car4, 11);
            garage.TryAddCarByPosition(car5, 15);

            Assert.AreEqual(1, garage.GetPositionOfCar(car1));
            Assert.AreEqual(4, garage.GetPositionOfCar(car2));
            Assert.AreNotEqual(4, garage.GetPositionOfCar(car3));
            Assert.AreEqual(0, garage.GetPositionOfCar(car6));
        }

        [TestMethod]
        public void GetCarByPositionTest()
        {
            Garage garage = new Garage();
            Car car1 = new Car("25006HRT", Make.Black, Model.SUV, 2010, 20000);
            Car car2 = new Car("34218JJT", Make.Grey, Model.Sedan, 2005, 10000);
            Car car3 = new Car("90045QER", Make.Red, Model.SportsCar, 2020, 200000);
            Car car4 = new Car("56738IHP", Make.Yellow, Model.Truck, 1999, 6000);
            Car car5 = new Car("45453KLA", Make.White, Model.Convertible, 2021, 50000);

            garage.TryAddCarByPosition(car1, 1);
            garage.TryAddCarByPosition(car2, 4);
            garage.TryAddCarByPosition(car3, 7);
            garage.TryAddCarByPosition(car4, 11);
            garage.TryAddCarByPosition(car5, 15);

            Assert.AreEqual(car1, garage.GetCarByPosition(1));
            Assert.AreEqual(car2, garage.GetCarByPosition(4));
            Assert.AreEqual(car3, garage.GetCarByPosition(7));
            Assert.IsNull(garage.GetCarByPosition(3));
        }

        [TestMethod]
        public void TryAddCarTest()
        {
            Garage garage = new Garage();
            Car car1 = new Car("25006HRT", Make.Black, Model.SUV, 2010, 20000);
            Car car2 = new Car("34218JJT", Make.Grey, Model.Sedan, 2005, 10000);
            Car car3 = new Car("90045QER", Make.Red, Model.SportsCar, 2020, 200000);
            Car car4 = new Car("56738IHP", Make.Yellow, Model.Truck, 1999, 6000);
            Car car5 = new Car("45453KLA", Make.White, Model.Convertible, 2021, 50000);
            Car car6 = new Car("55555TYH", Make.Blue, Model.HatchBack, 2006, 7000);
            Car car7 = new Car("34561FFG", Make.White, Model.Truck, 2005, 8000);
            Car car8 = new Car("67381YTE", Make.Black, Model.SportsCar, 2015, 300000);
            Car car9 = new Car("34562FFG", Make.White, Model.Truck, 2005, 8000);
            Car car10 = new Car("34563FFG", Make.White, Model.Truck, 2005, 8000);
            Car car11 = new Car("34564FFG", Make.White, Model.Truck, 2005, 8000);
            Car car12 = new Car("34565FFG", Make.White, Model.Truck, 2005, 8000);
            Car car13 = new Car("34566FFG", Make.White, Model.Truck, 2005, 8000);
            Car car14 = new Car("34567FFG", Make.White, Model.Truck, 2005, 8000);
            Car car15 = new Car("34568FFG", Make.White, Model.Truck, 2005, 8000);
            Car car16 = new Car("34569FFG", Make.White, Model.Truck, 2005, 8000);
            Car car17 = new Car("34570FFG", Make.White, Model.Truck, 2005, 8000);
            Car car18 = new Car("34571FFG", Make.White, Model.Truck, 2005, 8000);
            Car car19 = new Car("34572FFG", Make.White, Model.Truck, 2005, 8000);
            Car car20 = new Car("34573FFG", Make.White, Model.Truck, 2005, 8000);
            Car car21 = new Car("34574FFG", Make.White, Model.Truck, 2005, 8000);

            garage.TryAddCarByPosition(car1, 1);
            garage.TryAddCarByPosition(car2, 4);
            garage.TryAddCarByPosition(car3, 7);
            garage.TryAddCarByPosition(car4, 11);
            garage.TryAddCarByPosition(car5, 15);

            Assert.IsTrue(garage.TryAddCar(car6));
            Assert.IsTrue(garage.TryAddCar(car7));
            Assert.IsTrue(garage.TryAddCar(car8));
            Assert.IsTrue(garage.TryAddCar(car9));
            Assert.IsTrue(garage.TryAddCar(car10));
            Assert.IsTrue(garage.TryAddCar(car11));
            Assert.IsTrue(garage.TryAddCar(car12));
            Assert.IsTrue(garage.TryAddCar(car13));
            Assert.IsTrue(garage.TryAddCar(car14));
            Assert.IsTrue(garage.TryAddCar(car15));
            Assert.IsTrue(garage.TryAddCar(car16));
            Assert.IsTrue(garage.TryAddCar(car17));
            Assert.IsTrue(garage.TryAddCar(car18));
            Assert.IsTrue(garage.TryAddCar(car19));
            Assert.IsTrue(garage.TryAddCar(car20));
            Assert.IsFalse(garage.TryAddCar(car21));
        }

        [TestMethod]
        public void ValidateUniqueRegoTest()
        {
            Garage garage = new Garage();
            Car car1 = new Car("25006HRT", Make.Black, Model.SUV, 2010, 20000);
            Car car2 = new Car("34218JJT", Make.Grey, Model.Sedan, 2005, 10000);
            Car car3 = new Car("90045QER", Make.Red, Model.SportsCar, 2020, 200000);
            Car car4 = new Car("56738IHP", Make.Yellow, Model.Truck, 1999, 6000);
            Car car5 = new Car("45453KLA", Make.White, Model.Convertible, 2021, 50000);
            Car car6 = new Car("45453KLA", Make.Red, Model.Coupe, 2010, 50000);
            Car car7 = new Car("55453KLA", Make.Yellow, Model.SUV, 2011, 40000);

            garage.TryAddCarByPosition(car1, 1);
            garage.TryAddCarByPosition(car2, 4);
            garage.TryAddCarByPosition(car3, 7);
            garage.TryAddCarByPosition(car4, 11);
            garage.TryAddCarByPosition(car5, 15);

            Assert.IsTrue(garage.ValidateUniqueRego(car7));
            Assert.IsFalse(garage.ValidateUniqueRego(car6));
            //garage.TryRemoveCarByPosition(15);
            //Assert.IsFalse(garage.ValidateUniqueRego(car6));
        }

        [TestMethod]
        public void SearchByYearTest()
        {
            Garage garage = new Garage();
            Car car1 = new Car("25006HRT", Make.Black, Model.SUV, 2010, 20000);
            Car car2 = new Car("34218JJT", Make.Grey, Model.Sedan, 2005, 10000);
            Car car3 = new Car("90045QER", Make.Red, Model.SportsCar, 2020, 200000);
            Car car4 = new Car("56738IHP", Make.Yellow, Model.Truck, 1999, 6000);
            Car car5 = new Car("45453KLA", Make.White, Model.Convertible, 2021, 50000);
            Car car6 = new Car("55555TYH", Make.Blue, Model.HatchBack, 2006, 7000);
            Car car7 = new Car("34561FFG", Make.White, Model.Truck, 2005, 8000);

            garage.TryAddCarByPosition(car1, 1);
            garage.TryAddCarByPosition(car2, 4);
            garage.TryAddCarByPosition(car3, 7);
            garage.TryAddCarByPosition(car4, 11);
            garage.TryAddCarByPosition(car5, 15);
            garage.TryAddCarByPosition(car6, 17);
            garage.TryAddCarByPosition(car7, 19);

            List<Car> list = garage.SearchbyYear(garage.GetCarsFromLot(), 2010, 2021);

            Assert.AreEqual(3, list.Count);
            Assert.IsTrue(garage.HasCar(list, car1));
            Assert.IsTrue(garage.HasCar(list, car3));
            Assert.IsTrue(garage.HasCar(list, car5));
            Assert.IsFalse(garage.HasCar(list, car7));
        }

        [TestMethod]
        public void SearchByBudgetTest()
        {
            Garage garage = new Garage();
            Car car1 = new Car("25006HRT", Make.Black, Model.SUV, 2010, 20000);
            Car car2 = new Car("34218JJT", Make.Grey, Model.Sedan, 2005, 10000);
            Car car3 = new Car("90045QER", Make.Red, Model.SportsCar, 2020, 200000);
            Car car4 = new Car("56738IHP", Make.Yellow, Model.Truck, 1999, 6000);
            Car car5 = new Car("45453KLA", Make.White, Model.Convertible, 2021, 50000);
            Car car6 = new Car("55555TYH", Make.Blue, Model.HatchBack, 2006, 7000);
            Car car7 = new Car("34561FFG", Make.White, Model.Truck, 2005, 8000);

            garage.TryAddCarByPosition(car1, 1);
            garage.TryAddCarByPosition(car2, 4);
            garage.TryAddCarByPosition(car3, 7);
            garage.TryAddCarByPosition(car4, 11);
            garage.TryAddCarByPosition(car5, 15);
            garage.TryAddCarByPosition(car6, 17);
            garage.TryAddCarByPosition(car7, 19);

            List<Car> list = garage.SearchbyBudget(garage.GetCarsFromLot(), 0, 9000);
            
            Assert.AreEqual(3, list.Count);
            Assert.IsTrue(garage.HasCar(list, car4));
            Assert.IsTrue(garage.HasCar(list, car6));
            Assert.IsTrue(garage.HasCar(list, car7));
            Assert.IsFalse(garage.HasCar(list, car1));
        }

        [TestMethod]
        public void SearchByModelTest()
        {
            Garage garage = new Garage();
            Car car1 = new Car("25006HRT", Make.Black, Model.SUV, 2010, 20000);
            Car car2 = new Car("34218JJT", Make.Grey, Model.Sedan, 2005, 10000);
            Car car3 = new Car("90045QER", Make.Red, Model.SportsCar, 2020, 200000);
            Car car4 = new Car("56738IHP", Make.Yellow, Model.Truck, 1999, 6000);
            Car car5 = new Car("45453KLA", Make.White, Model.Convertible, 2021, 50000);
            Car car6 = new Car("55555TYH", Make.Blue, Model.HatchBack, 2006, 7000);
            Car car7 = new Car("34561FFG", Make.White, Model.Truck, 2005, 8000);

            garage.TryAddCarByPosition(car1, 1);
            garage.TryAddCarByPosition(car2, 4);
            garage.TryAddCarByPosition(car3, 7);
            garage.TryAddCarByPosition(car4, 11);
            garage.TryAddCarByPosition(car5, 15);
            garage.TryAddCarByPosition(car6, 17);
            garage.TryAddCarByPosition(car7, 19);

            List<Car> list = garage.SearchbyModel(garage.GetCarsFromLot(), Model.Truck);

            Assert.AreEqual(2, list.Count);
            Assert.IsTrue(garage.HasCar(list, car4));
            Assert.IsTrue(garage.HasCar(list, car7));
            Assert.IsFalse(garage.HasCar(list, car2));
        }

        [TestMethod]
        public void SearchByMakeTest()
        {
            Garage garage = new Garage();
            Car car1 = new Car("25006HRT", Make.Black, Model.SUV, 2010, 20000);
            Car car2 = new Car("34218JJT", Make.Grey, Model.Sedan, 2005, 10000);
            Car car3 = new Car("90045QER", Make.Red, Model.SportsCar, 2020, 200000);
            Car car4 = new Car("56738IHP", Make.Yellow, Model.Truck, 1999, 6000);
            Car car5 = new Car("45453KLA", Make.White, Model.Convertible, 2021, 50000);
            Car car6 = new Car("55555TYH", Make.Blue, Model.HatchBack, 2006, 7000);
            Car car7 = new Car("34561FFG", Make.White, Model.Truck, 2005, 8000);

            garage.TryAddCarByPosition(car1, 1);
            garage.TryAddCarByPosition(car2, 4);
            garage.TryAddCarByPosition(car3, 7);
            garage.TryAddCarByPosition(car4, 11);
            garage.TryAddCarByPosition(car5, 15);
            garage.TryAddCarByPosition(car6, 17);
            garage.TryAddCarByPosition(car7, 19);

            List<Car> list = garage.SearchbyMake(garage.GetCarsFromLot(), Make.White);

            Assert.AreEqual(2, list.Count);
            Assert.IsTrue(garage.HasCar(list, car5));
            Assert.IsTrue(garage.HasCar(list, car7));
            Assert.IsFalse(garage.HasCar(list, car2));
        }
    }
}
