using System;
using System.Collections.Generic;
using System.Text;

namespace Lab11
{
    class Car
    {

        private long id;
        private string brand;
        private string model;
        private int production_year;
        private string color;
        private int price;
        private readonly int hash;

        private string registration;
        private static int carNumber = 0;

        public int Age
        {
            get => 2020 - production_year;
        }

        public override string ToString() => $"{color} {Brand} {Model} ({production_year}) {price} - {registration} ({id})";
        public Car(int id, string brand, string model, int production_year, int price, string registration, string color = "")
        {
            this.id = id;
            this.brand = brand;
            this.model = model;
            this.production_year = production_year;
            this.price = price;
            this.registration = registration;
            this.color = color;

            hash = id % 15;
            carNumber++;
        }

        public Car()
        {
            int newId = new Random().Next(1, 10);
            Id = newId;
            carNumber++;
            hash = GetHashCode();
        }

        ~Car()
        {
            carNumber--;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(base.GetHashCode());
            hash.Add(Id);
            hash.Add(Brand);
            hash.Add(Model);
            hash.Add(Production_year);
            hash.Add(Price);
            return hash.ToHashCode();
        }

        public override bool Equals(object o)
        {

            if ((o == null) || !GetType().Equals(o.GetType()))
            {
                return false;
            }
            else
            {
                Car s = (Car)o;
                return (s.Id == Id) && (s.Color == Color) && (s.Registration == Registration) && (s.Price == Price) && (s.Model == Model) && (s.Brand == Brand) && (s.Production_year == Production_year);
            }
        }

        public string Registration
        {
            get => registration;
            set => registration = value;
        }

        static public int CarNumber
        {
            get => carNumber;
        }

        public long Id
        {
            get => id;
            set => id = value;
        }

        public string Brand
        {
            get => brand;
            set => brand = value;
        }

        public string Model
        {
            get => model;
            set => model = value;
        }
        public int Production_year
        {
            get => production_year;
            set => production_year = value;
        }
        public string Color
        {
            get => color;
            set => color = value;
        }
        public int Price
        {
            get => price;
            set => price = value;
        }

        public int GetAge() => 2020 - production_year;

        //private Car() { }
        static public string Info => $"Класс {typeof(Car)}, включающий {carNumber} объектов";
        static Car() { }
    }
}
