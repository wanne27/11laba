using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _11laba
{
    partial class Airline
    {
        private string destination = "";
        private int number = 0;
        private string type = "";
        public void ShowDetail() => Console.WriteLine($"Dest: {DESTINATION}, number: {NUMBER}, type: {TYPE}, day: {DAY}");
        public enum weekDays
        {
            sun = 1, mon, thue, wen, thir, fri, sat
        }
        private weekDays wd = weekDays.mon;
        
        private static int size = 0;
        public static void sizeinfo()
        {
            Console.WriteLine("Size:" + size);
        }
        public int TIME { get; set; } = 0;
        public string DESTINATION
        {
            get { return this.destination; }
            set { this.destination = value; }

        }
        public int NUMBER
        {
            get { return this.number; }
            set { this.number = value; }

        }
        public string TYPE
        {
            get { return this.type; }
            set { this.type = value; }

        }
        public weekDays DAY
        {
            get { return this.wd; }
            set { this.wd = value; }

        }
       
        public Airline()
        {
            this.destination = "no";
            this.number = 0;
            this.type = "no";
            this.TIME = 0000;
            this.wd = weekDays.sun;
            
            size++;
           
        }

        public Airline(string des, int n, string ty, int t, weekDays day)
        {
            this.destination = des;
            this.number = n;
            this.type = ty;
            this.TIME = t;
            this.wd = day;
            
            size++;
            
        }

        static Airline()
        {
           
        }
        public Airline(string des, int n, string ty)
        {
            this.destination = des;
            this.number = n;
            this.type = ty;
            
            size++;
         
        }
        public int sum(int a, int b)
        {
            return a + b;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] months = { "January", "February", "Mart", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            int k = 4;
            Console.WriteLine("Месяцы с 4 буквами: ");
            IEnumerable<string> rezult1 = months
                .Where(n => n.Length == k)
                .Select(n => n);
            foreach (string a in rezult1) 
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("Зимние и летние месяцы: ");
            IEnumerable<string> rezult2 = months
                .Where(n => n.Equals("January") || n.Equals("February") || n.Equals("December") || n.Equals("June") || n.Equals("July") || n.Equals("August"))
                .Select(n => n);
            foreach(string a in rezult2)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("Упорядочивание по алфавиту: ");
            IEnumerable<string> rezult3 = months
                .OrderBy(n => n)
                .Select(n => n);
            foreach(string a in rezult3)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("Запросы содержащие букву «u» и длиной имени не менее 4-х");
            IEnumerable<string> rezult4 = months
                .Where(n=>n.Contains("u")&&n.Length>=4)
                .Select(n => n);
            foreach (string a in rezult4)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("Работа с коллекцией: ");
            List<Airline> airlines = new List<Airline>()
            {
                new Airline("Minsk", 2233,"Boing", 1045, Airline.weekDays.sat),
                new Airline("PRAGA", 1234,"AirBus", 1130, Airline.weekDays.wen),
                 new Airline("Minsk", 9721,"Boing", 2245, Airline.weekDays.sat),
                 new Airline("Brest", 1111,"Boing", 1945, Airline.weekDays.mon),
                 new Airline("Minsk", 3233,"Boing", 1200,Airline.weekDays.mon),
                 new Airline("Vitebsk", 4148,"AirBus", 1530,Airline.weekDays.mon),
            };
            Console.WriteLine("Список рейсов для Minsk:");
            string sity = "Minsk";
            IEnumerable<Airline> rezult5 = airlines
                .Where(n => (n.DESTINATION == sity))
                .Select(n => n);
            foreach (Airline flight in rezult5)
            {
                Console.WriteLine(flight.NUMBER + "\t" + flight.TYPE + "\t" + flight.DAY + "\t" + flight.TIME);
            }
            Console.WriteLine("Список рейсов в понедельник:");
            
            IEnumerable<Airline> rezult6 = airlines
                .Where(n => (n.DAY == Airline.weekDays.mon))
                .Select(n => n);
            foreach (Airline flight in rezult6)
            {
                Console.WriteLine(flight.DESTINATION + "\t" + flight.NUMBER + "\t" + flight.TYPE + "\t" + flight.TIME);
            }
            Console.WriteLine("все рейсы с  временем вылета после 10:00: ");

            var rezult7 = from i in airlines
                          where i.TIME > 1000
                          select i;
            foreach (Airline flight in rezult7)
            {
                Console.WriteLine(flight.DESTINATION + "\t" + flight.NUMBER + "\t" + flight.TYPE + "\t" + flight.TIME);
            }

            Console.WriteLine("упорядоченные по дню: ");
            var rezult8 = from i in airlines
                          orderby i.DAY
                          select i;
            foreach (Airline flight in rezult8)
            {
                Console.WriteLine(flight.DESTINATION + "\t" + flight.NUMBER + "\t" + flight.TYPE + "\t" + flight.TIME + "\t" + flight.DAY);
            }
            Console.WriteLine("упорядоченные по времени: ");
            var rezult9 = from i in airlines
                          orderby i.TIME
                          select i;
            foreach (Airline flight in rezult9)
            {
                Console.WriteLine(flight.DESTINATION + "\t" + flight.NUMBER + "\t" + flight.TYPE + "\t" + flight.TIME + "\t" + flight.DAY);
            }
            Console.WriteLine("Список рейсов для Airbus:");
            string type = "AirBus";
            IEnumerable<Airline> rezult10 = airlines
                .Where(n => (n.TYPE == type))
                .Select(n => n);
            foreach (Airline flight in rezult10)
            {
                Console.WriteLine(flight.DESTINATION + "\t" + flight.NUMBER + "\t" + flight.TYPE + "\t" + flight.TIME + "\t" + flight.DAY);
            }
            Console.WriteLine("Свой запрос: ");
            var rezult11 = airlines
                .Where(n => (n.sum(n.NUMBER, n.TIME) >= 10000))
                .OrderBy(n => n)
                .Select(n => n);
            foreach (Airline flight in rezult11)
            {

                Console.WriteLine(flight.DESTINATION + "\t" + flight.NUMBER + "\t" + flight.TYPE + "\t" + flight.TIME + "\t" + flight.DAY);
            }
            //с лекции
            Console.WriteLine("\nзапрос Join---------------------------------\n");
            string[] names = { " Анна", " Станислав", " Ольга", "Сева" };
            int[] key = { 1, 4, 5, 7 };
            var sometype = names
            .Join(
            key,// внутренняя
            w => w.Length, // внешний ключ выбора
            q => q,// внутренний ключ выбора
            (w, q) => new // результат
            {
                id = w,
                name = string.Format("{0} ", q),
            });
            foreach (var item in sometype)
                Console.WriteLine(item);
            Console.ReadLine();
        }        
    }
}
