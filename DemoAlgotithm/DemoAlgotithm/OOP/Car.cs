using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAlgotithm.OOP
{
    abstract class Car
    {
        protected bool isSedan;
        protected string seats;

        public Car() { }

        public Car(bool isSedan, string seats)
        {
            this.isSedan = isSedan;
            this.seats = seats;
        }

        public bool getIsSedan()
        {
            return this.isSedan;
        }

        public string getSeats()
        {
            return this.seats;
        }

        abstract public string getMileage();

        public void printCar(string name)
        {
            Console.WriteLine("A {0} is{1} Sedan, is {2}-seater, and has a mileage of around {3}.",
            name,
            this.getIsSedan() ? "" : " not",
            this.getSeats(),
            this.getMileage());
        }
    }

    class WagonR : Car
    {
        public int Mileage { get; set; }

        public WagonR(int mileage) : base(false, "4")
        {
            Mileage = mileage;
        }

        public override string getMileage()
        {
            return $"{Mileage} kmpl";
        }
    }


    class HondaCity : Car
    {
        public int Mileage { get; set; }

        public HondaCity(int mileage) : base(true, "4")
        {
            Mileage = mileage;
        }
        public override string getMileage()
        {
            return $"{Mileage} kmpl";
        }
    }

    class InnovaCrysta : Car
    {
        public int Mileage { get; set; }

        public InnovaCrysta(int mileage) : base(false, "6")
        {
            Mileage = mileage;
        }

        public override string getMileage()
        {
            return $"{Mileage} kmpl";
        }
    }
}
