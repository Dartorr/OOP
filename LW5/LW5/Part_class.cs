using System;
using System.Collections.Generic;
using System.Text;

namespace LW5
{
    partial class Program //вторая часть partial класса
    {
        public sealed class Grafic_Card //sealed -- запрет переопределения методов и свойств
        {
            public string Model;
        }
        public class Personal_Computer : Tech
        {
            public override void ShowComplex()
            {
                Console.WriteLine(this.Complexity);
            }
            //вложенный обьект

            public int Performance;
            public Grafic_Card Card;

            public Personal_Computer(int cost, int wd, string mdl, int pc, int cmlx, int prf, string gc_model)
            {
                Cost = cost;
                Age = wd;
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
                Console.WriteLine($"{this.Cost}\t{this.Age}\t{this.Model}\t{this.Power_consumption}\t{this.Complexity}\t{this.Performance}\t{this.Card.Model}");
                //перезапись ToString в каждом методе
                return "0";
            }
        }

        public class Scaner : Tech
        {
            public override void ShowComplex()
            {
                Console.WriteLine(this.Complexity);
            }
            public int Scan_Speed;
            public int sc
            {
                get
                {
                    return Scan_Speed;
                }
                set
                {
                    if (value < 0) throw new ScanExept("scan_speed<0");
                    if (value > 100) throw new ScanExept("Invalid ScanSpeed");
                }
            }

            public Scaner(int cost, int wd, string mdl, int pc, int cmlx, int spd)
            {
                Cost = cost;
                Age = wd;
                Model = mdl;
                Power_consumption = pc;
                Complexity = cmlx;
                Scan_Speed = spd;
            }
            public override string ToString()
            {
                Console.WriteLine($"{this.Cost}\t{this.Age}\t{this.Model}\t{this.Power_consumption}\t{this.Complexity}\t{this.Scan_Speed}\t");
                return "0";
            }
        }

        public class Tablet : Tech
        {
            public override void ShowComplex()
            {
                Console.WriteLine(this.Complexity);
            }
            public int Performance;

            public Tablet(int cost, int wd, string mdl, int pc, int cmlx, int prf)
            {
                Cost = cost;
                Age = wd;
                Model = mdl;
                Power_consumption = pc;
                Complexity = cmlx;
                Performance = prf;
            }
            public override string ToString()
            {
                Console.WriteLine($"{this.Cost}\t{this.Age}\t{this.Model}\t{this.Power_consumption}\t{this.Complexity}\t{this.Performance}\t");
                return "0";
            }
        }

    }
}
