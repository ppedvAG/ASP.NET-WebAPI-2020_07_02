using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new CarServiceV2();
            ICar car = new CarV2();
            ICar car2 = new DummyCar();


            carService.Insert(car2);

        }
    }


    #region Schlechter Still -> Abhängigkeitsproblem
    public class Car
    {
        public string Marke { get; set; }

        public DateTime Baujahr { get; set; }
    }


    public class CarService
    {
        public void InsertCar(Car car)
        {
            //...
        }
    }
    #endregion

    #region Gutes Beispiel

    public interface ICar
    {
        string Brand { get; set; }

        DateTime Baujahr { get; set; }
    }

    public interface ICarService
    {
        void Insert(ICar car);
    }


    /// <summary>
    /// Produktive Struktur
    /// </summary>
    public class CarV2 : ICar
    {
        public string Brand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime Baujahr { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    public class DummyCar : ICar
    {
        private string brand = string.Empty;
        private string baujahr = DateTime.Now.ToString();
        public string Brand
        {
            get
            {
                return "TestMarke";
            }
            set
            {
                brand = value;
            }
        }

        public DateTime Baujahr { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }


    public class CarServiceV2 : ICarService
    {
        public void Insert(ICar car)
        {
            
        }
    }

    public class DummyService : ICarService
    {
        public void Insert(ICar car)
        {

        }
    }



    #endregion
}
