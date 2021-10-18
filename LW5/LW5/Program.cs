using System;


/*
5) Написать демонстрационную программу, в которой создаются объекты
различных классов. Поработать с объектами через ссылки на абстрактные
классы и интерфейсы. В этом случае для идентификации типов объектов
использовать операторы is или as.
7) Создайте дополнительный класс Printer c полиморфным методом
IAmPrinting( SomeAbstractClassorInterface someobj). Формальным
параметром метода должна быть ссылка на абстрактный класс или наиболее
общий интерфейс в вашей иерархии классов. В методе iIAmPrinting
определите тип объекта и вызовите ToString(). В демонстрационной
программе создайте массив, содержащий ссылки на разнотипные объекты
ваших классов по иерархии, а также объект класса Printer и последовательно
вызовите его метод IAmPrinting со всеми ссылками в качестве аргументов.
 */
namespace LW5
{
   
    class Program
    {
        public  class Printer
        {
            public  int IAmPrinting(ref Stuff oleg)
            {
                Console.WriteLine(oleg.GetType());
                Console.WriteLine(oleg.ToString());
                return 0;
            }
            
        }
        interface IDunno
        {
            public int SomeCommonMethod()
            {
                Console.WriteLine("Interface Method");
                return 2 + 2;
            }
        }
        public abstract class Stuff
        {
            public  int Cost;
            public  int Weight;

            
            public virtual int SomeCommonMethod()
            {
                Console.WriteLine("Abstract Class Method");
                return 2 + 2;
            }

            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
            public override string ToString()
            {
                return base.ToString();
            }
            public virtual int ShowCost()
            {
                return 0;
            }

        }

        public abstract class Tech: Stuff 
        {
            public  string Model;
            public  int Power_consumption;
            public  int Complexity;
            public override int ShowCost()
            {
                Console.WriteLine(this.Model);
                return this.Cost;
            }
        }

        public class Print_er : Tech, IDunno
        {
            public int Print_Speed;

            public Print_er(int cost, int wd, string mdl, int pc, int cmlx, int spd)
            {
                Cost = cost;
                Weight = wd;
                Model = mdl;
                Power_consumption = pc;
                Complexity = cmlx;
                Print_Speed = spd;
            }
            public override string ToString()
            {
                Console.WriteLine($"{this.Cost}\t{this.Weight}\t{this.Model}\t{this.Power_consumption}\t{this.Complexity}\t{this.Print_Speed}\t");
                return "0leg";
            }

            int IDunno.SomeCommonMethod()
            {
                Console.WriteLine("Overriden Interface Method ");
                return 4;
            }

            public override int SomeCommonMethod()
            {
                Console.WriteLine("Overriden Abstract Class Method ");
                return 5;
            }

        }

        public sealed class Grafic_Card
        {
            public string Model;
        }
        public class Personal_Computer : Tech
        {
            public int Performance;
            public Grafic_Card Card;

            public Personal_Computer(int cost, int wd, string mdl, int pc, int cmlx, int prf, string gc_model)
            {
                Cost = cost;
                Weight = wd;
                Model = mdl;
                Power_consumption = pc;
                Complexity = cmlx;
                Performance = prf;

                Card = new Grafic_Card
                {
                    Model = gc_model
                };
            }
            public override string ToString()
            {
                Console.WriteLine($"{this.Cost}\t{this.Weight}\t{this.Model}\t{this.Power_consumption}\t{this.Complexity}\t{this.Performance}\t{this.Card.Model}");
                return "0";
            }
        }

        public class Scaner : Tech
        {
            public int Scan_Speed;

            public Scaner(int cost, int wd, string mdl, int pc, int cmlx, int spd)
            {
                Cost = cost;
                Weight = wd;
                Model = mdl;
                Power_consumption = pc;
                Complexity = cmlx;
                Scan_Speed = spd;
            }
            public override string ToString()
            {
                Console.WriteLine($"{this.Cost}\t{this.Weight}\t{this.Model}\t{this.Power_consumption}\t{this.Complexity}\t{this.Scan_Speed}\t");
                return "0";
            }
        }

        public class Tablet : Tech
        {
            public int Performance;

            public Tablet(int cost, int wd, string mdl, int pc, int cmlx, int prf)
            {
                Cost = cost;
                Weight = wd;
                Model = mdl;
                Power_consumption = pc;
                Complexity = cmlx;
                Performance = prf;
            }
            public override string ToString()
            {
                Console.WriteLine($"{this.Cost}\t{this.Weight}\t{this.Model}\t{this.Power_consumption}\t{this.Complexity}\t{this.Performance}\t");
                return "0";
            }
        }

        static void Main()
        {
            Tablet tablet = new Tablet(50, 3, "3 model", 300, 3, 500);
            Scaner scan = new Scaner(30, 5, "0 model", 150, 5, 400);
            Personal_Computer PC = new Personal_Computer(50, 3, "haha model", 300, 10, 2000,"mx250");
            Print_er print = new Print_er(50, 3, "3 model", 300, 3, 500);

            tablet.ToString();
            scan.ToString();
            PC.ToString();
            print.ToString();

            Console.WriteLine(tablet is Tablet);
            Console.WriteLine(tablet is Personal_Computer);
            Console.WriteLine(tablet is Tech);
            Console.WriteLine(tablet is Stuff);

            ref Tablet tablet_ref = ref tablet;
            ref Scaner scaner_ref = ref scan;
            ref Personal_Computer PC_ref = ref PC;
            ref Print_er print_ref = ref print;

            Stuff[] st = { tablet_ref, scaner_ref, PC_ref, print_ref };

            Printer printer = new Printer();

            printer.IAmPrinting(ref st[0]);
            printer.IAmPrinting(ref st[1]);
            printer.IAmPrinting(ref st[2]);
            printer.IAmPrinting(ref st[3]);
        }   
    }
}
