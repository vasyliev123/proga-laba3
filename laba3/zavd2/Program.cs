using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
namespace zavd2
{
    class Program
    {
        //Таксопарк. Визначити ієрархію легкових автомобілів. Створити таксопарк.
        //Підрахувати вартість автопарку. Провести сортування автомобілів парку по
        //витраті палива. Знайти автомобіль в компанії, що відповідає заданому діапазону параметрів швидкості.

        static void Main(string[] args)
        {
            Avto avto1 = new("Mazda", 9999, 60, 100);

            Avto avto2 = new("Honda", 2399, 450, 120);

            Avto avto3 = new("Bmb", 15999, 8, 200);

            Avto avto4 = new("Tesla", 24999, 0, 300);

            TaksoPark tp = new TaksoPark();

            tp.list.Add(avto1);
            tp.list.Add(avto2);
            tp.list.Add(avto3);
            tp.list.Add(avto4);

            tp.ShowList();

            tp.Vartist();

            tp.sortVytraty();

            tp.ShowList();

            tp.shv_search(100, 120);
        }
    }

    class TaksoPark
    {
        public List<Avto> list = new List<Avto>();
        

        public void Vartist()
        {

            double res = 0;
            foreach(Avto a in list)
            {
                res += a.Price;
            }
            Console.Write($"\nZagalna vartist takso parku: {res}\n");
           
        }

        public void sortVytraty()
        { 
            IEnumerable<Avto> q = list.OrderBy(a => a.VytratyPalyva);
            list = q.ToList();
            Console.WriteLine("\nSorted po vytraty palnogo\n");
        }
        public void ShowList()
        {
           
            foreach (Avto a in list)
            {
                Console.WriteLine($"{a.Name}\t{a.Price}\t{a.VytratyPalyva}\t{a.MaxShv}");
            }
        }
        public void shv_search(double c, double b)
        {
            Console.WriteLine("\nPoshuk po shvydkosti\n");
            List<Avto> newList = new List<Avto>();

            foreach(Avto a in list.Where(x=> x.MaxShv>=c&&x.MaxShv<=b))
            {
                Console.WriteLine($"{a.Name}\t{a.Price}\t{a.VytratyPalyva}\t{a.MaxShv}");
            }
        }

    }

    class Avto
    {

        
        public Avto(string n, double p, double vp, double ms)
        {
            Name = n;
            Price = p;
            VytratyPalyva = vp;
            MaxShv = ms;
        }
       
        public string Name
        {
            get;
            set;
        }
        public double Price
        {
            get;
            set;
        }
        public double VytratyPalyva
        {
            get;
            set;
        }
        public double MaxShv
        {
            get;
            set;
        }
    }
}
