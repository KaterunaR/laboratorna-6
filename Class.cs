using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oop_lab6
{
    public class Car : IComparable<Car>
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Dealer { get; set; }
        private double price;

        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Ціна не може бути від'ємною.");
                price = value;
            }
        }

        public Car()
        {
        }

        public Car(string brand, string model, int year, string dealer, double price)
        {
            Brand = brand;
            Model = model;
            Year = year;
            Dealer = dealer;
            Price = price;
        }


        public void DecreasePriceForFordLastYear(int currentYear)
        {
            if (Brand == "Ford" && Year == currentYear - 1)
            {
                Price *= 0.8; 
            }
        }
        public int CompareTo(Car other)
        {
            return string.Compare(Dealer, other.Dealer);
        }
    }

    public class CarCollection
    {
        private List<Car> cars = new List<Car>();

        public void AddCar(Car car)
        {
            cars.Add(car);
        }

        public void DisplayCars()
        {
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Brand} {car.Model}, {car.Year}, {car.Dealer}, {car.Price}$");
            }
        }


        public void SortByDealer()
        {
            cars.Sort();
        }


        // Запис колекції автомобілів у файл
        public void WriteToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var car in cars)
                {
                    writer.WriteLine($"{car.Brand},{car.Model},{car.Year},{car.Dealer},{car.Price}");
                }
            }
        }

        // Зчитування колекції автомобілів з файлу
        public void ReadFromFile(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    Car car = new Car(parts[0], parts[1], int.Parse(parts[2]), parts[3], double.Parse(parts[4]));
                    cars.Add(car);
                }
            }
        }

    }
}






