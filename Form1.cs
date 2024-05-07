using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oop_lab6
{
    public partial class Form1 : Form
    {
        CarCollection collection = new CarCollection();
        public Form1()
        {
            InitializeComponent();
            collection.AddCar(new Car("Ford", "Focus", 2023, "Ford Dealer 1", 25000));
            collection.AddCar(new Car("Toyota", "Camry", 2022, "Toyota Dealer", 30000));
            collection.AddCar(new Car("Ford", "Fiesta", 2021, "Ford Dealer 2", 20000));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            collection.DisplayCars();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            collection.SortByDealer();
            Console.WriteLine($"---------------Sorted data------------------------$");
            collection.DisplayCars();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            collection.WriteToFile(@"D:\obdz 2024\oop_lab6\oop_lab6\cars.txt");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            collection.ReadFromFile(@"D:\obdz 2024\oop_lab6\oop_lab6\cars.txt");
            Console.WriteLine($"---------------Data was loaded------------------------$");
        }
    }
}
