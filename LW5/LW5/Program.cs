using System;
using System.Collections.Generic;
using System.Diagnostics;



namespace LW5
{
    partial class Program //partial класс
    {
        public enum dunno //перечисление
        {
            dunno_one,
            dunno_two
        }

        public struct a_za4em //структура
        {
            public string raz;
            public string dva;
            public dunno from_enum;
            public void ToConsole() //метод
            {
                Console.WriteLine($"struct: {this.raz}   {this.dva}   {this.from_enum}");
            }
            //можно не указывать конструктор
        }
        

        public class LabController//контроллер
        {
            Laboratory Lab;
            public LabController(Laboratory lab)
            {
                Lab = lab;
            }
            public void Older(int age)//выводит обьекты, старше заданного возраста
            {
                foreach (Stuff T in Lab.Objects)
                {
                    if (T.Age > age) T.ToString();
                }
            }

            public void EachTypeCol() //выводит количество каждого обьекта
            {
                int[] nums = new int[4];

                foreach (Stuff T in Lab.Objects)
                {
                    if (T.GetType() == typeof(Print_er)) nums[0]++;
                    if (T.GetType() == typeof(Personal_Computer)) nums[1]++;
                    if (T.GetType() == typeof(Scaner)) nums[2]++;
                    if (T.GetType() == typeof(Tablet)) nums[3]++;
                }

                Console.WriteLine($"Print_er: {nums[0]}");
                Console.WriteLine($"PC: {nums[1]}");
                Console.WriteLine($"Scaner: {nums[2]}");
                Console.WriteLine($"Tablet: {nums[3]}");

            }

            public void PriceDown()//сортирует по убыванию цены и выводит обьекты 
            {
                List<Stuff> buffer = new List<Stuff>();
                int k = 0;
                int[,] tmp = new int[2, 100];

                foreach (Stuff T in Lab.Objects)
                {
                    tmp[0, k] = T.Cost;
                    tmp[1, k] = k;
                    k++;
                }
                for (int i = 0; i < k - 1; i++) //сортировка пузырьком
                    for (int j = 0; j < k - 1; j++)
                        if (tmp[0, j] < tmp[0, j + 1])
                        {
                            int buf;
                            buf = tmp[0, j];
                            tmp[0, j] = tmp[0, j + 1];
                            tmp[0, j + 1] = buf;

                            buf = tmp[1, j];
                            tmp[1, j] = tmp[1, j + 1];
                            tmp[1, j + 1] = buf;
                        }
                for (int i = 0; i < k; i++)
                {
                    buffer.Add(Lab.Objects[tmp[1, i]]); //копирование в buffer элементов списка в порядке возрастания цены
                }
                Lab.Objects = buffer;
                foreach (Stuff T in Lab.Objects) T.ToString();

            }
        }
        public class Laboratory //класс лаборатория. Хранит в себе обьекты
        {

            public List<Stuff> Objects;

            public Laboratory()
            {
                Objects = new List<Stuff>();
            }
            public bool add(Tech obj) //метод добавления обьекта в список
            {
                bool flag = false;
                if (Objects.IndexOf(obj) == -1)
                {
                    Objects.Add(obj);
                    flag = true;
                }
                return flag;
            }

            public bool del(Tech obj) //удаление обьекта из списка
            {
                return Objects.Remove(obj);
            }

            public void WriteToConsole() //вывод всех обьектов в консоль
            {
                foreach (Tech a in Objects)
                {
                    Console.WriteLine($"{a.Model}\t{a.Cost}\t{a.Age}");
                }
            }


        }

        public class Printer //доп класс
        {
            public virtual int IAmPrinting(ref Stuff oleg) 
            {
                Console.WriteLine(oleg.GetType());
                oleg.ToString();
                return 0;
            }

        }

        interface IDunno //интерфейс
        {
            public void SomeCommonMethod()
            {
                Console.WriteLine("Interface Method");
               
            }
            
        }

        public abstract class Stuff:IDunno //абстрактный класс. главное отличие состоит в том,
                                    //что мы не можем использовать конструктор абстрактного класса для создания его объекта.
                                    //Нужен в основном для наследования
        {
            
            public int Cost;
            public int cost
              {
                  get
                  {

                      return Cost;
                  }
                  set
                  {
                      if (value < 1) throw new StuffExept("Cost<1");
                      
                  }
              }

            public int Age;
            public int age
            {
                get
                {
                    return Age;
                }
                set
                {
                    if (value < 0) throw new StuffExept("Age<0");
                }
            }


            public virtual int SomeCommonMethod() //виртуальный (доступный для перезаписи) метод
            {
                Console.WriteLine("Abstract Class Method");
                return 2 + 2;
            }

            public override bool Equals(object obj) //перезапись стандартных методов 
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

        public abstract class Tech : Stuff //наследование Tech от Stuff
        {
            public string Model;

            public int Power_consumption;
            public int p_c
            {
                get
                {
                    return Power_consumption;
                }
                set
                {
                    if (value < 0) throw new TechExept("power_consumption<0");
                    if (value == 4) throw new TechExept("sdgfhg");
                }
            }

            public int Complexity;
            public int complex
            {
                get
                {
                    return Complexity;
                }
                set
                {
                    if (value < 0) throw new TechExept("scan_speed<0");
                }
            }
            public override int ShowCost() //перезаписанная виртуальная функция
            {
                Console.WriteLine(this.Model);
                return this.Cost;
            }

            public abstract void ShowComplex();

          /* public Tech(int com)
            {
                Complexity = com;
            }*/
        }

        public class Print_er : Tech, IDunno
        {
            public int Print_Speed;

          /*  public Print_er(int com):base(com)
            {
                Complexity = com;
            }*/

            public Print_er(int cost, int wd, string mdl, int pc, int cmlx, int spd)
            {
                Cost = cost;
                Age = wd;
                Model = mdl;
                Power_consumption = pc;
                Complexity = cmlx;
                Print_Speed = spd;
            }
            public override void ShowComplex()
            {
                Console.WriteLine(this.Complexity);
            }
            public override string ToString()
            {
                Console.WriteLine($"{this.Cost}\t{this.Age}\t{this.Model}\t{this.Power_consumption}\t{this.Complexity}\t{this.Print_Speed}\t");
                return "0leg";
            }



            public override int SomeCommonMethod() //перезапись методов с одиновым именем
            {
                Console.WriteLine("Overriden Abstract Class Method ");
                return 5;
            }



        }



        static void Main()
        {
            //создание обьектов
            Tablet tablet = new Tablet(75, 3, "3 model", 300, 3, 500);
            Scaner scan = new Scaner(30, 5, "0 model", 150, 5, 400);
            Personal_Computer PC = new Personal_Computer(100, 3, "haha model", 300, 10, 2000, "mx250");
            Print_er print = new Print_er(50, 3, "3 model", 300, 3, 500);

            

            Console.WriteLine("------OBJECT.TOSTRING-------");
            //вывод обьектов
            tablet.ToString();
            scan.ToString();
            PC.ToString();
            print.ToString();

            Console.WriteLine("----IS OBJECT-----");

            Console.WriteLine(tablet is Tablet);//true
            Console.WriteLine(tablet is Personal_Computer);//false
            Console.WriteLine(tablet is Tech);//true
            Console.WriteLine(tablet is Stuff);//true

            Console.WriteLine("-----METHOD I_AM_PRINTING-------");
            //работа через ссылки 
            ref Tablet tablet_ref = ref tablet;
            ref Scaner scaner_ref = ref scan;
            ref Personal_Computer PC_ref = ref PC;
            ref Print_er print_ref = ref print;

            Stuff[] st = { tablet_ref, scaner_ref, PC_ref, print_ref };//массив ссылок на обьекты

            Printer printer = new Printer();

            printer.IAmPrinting(ref st[0]);
            printer.IAmPrinting(ref st[1]);
            printer.IAmPrinting(ref st[2]);
            printer.IAmPrinting(ref st[3]);

            //6
            Laboratory Lab = new Laboratory();//создание лаборатории
            Lab.add(tablet);//добавление в лабораторию техники
            Lab.add(scan);
            Lab.add(PC);
            Lab.add(print);
            LabController controller = new LabController(Lab);//создание контроллера

            //методы контроллера
            Console.WriteLine("-----METHOD OLDER-------");
            controller.Older(0);
            Console.WriteLine("-----METHOD PRICE_DOWN-------");
            controller.PriceDown();
            Console.WriteLine("-----METHOD EAC_TYPE_KOL-------");
            controller.EachTypeCol();

            Console.WriteLine("-----Struct+enum-----");
            a_za4em struc;//создание структуры без конструктора
            struc.raz = "dva";
            struc.dva = "raz";
            struc.from_enum = dunno.dunno_two;
            struc.ToConsole();

            tablet.SomeCommonMethod();
            ((IDunno)tablet).SomeCommonMethod();

            
            //7
            Console.WriteLine("-----Try_Catch-----");
            try
            {
                scan.sc = 200;//ScanExept
                scan.p_c = -1;//Tech
                scan.cost = -1;//Stuff
                scan.age = -1;//Stuff
                scan.complex = -1;//Tech
            }
            catch (StuffExept ex)
            {
                Console.WriteLine($"{ex.GetType()}\n {ex}  {ex.Message}\n {ex.Source} \n{ex.StackTrace} \n{ex.TargetSite}");
            }
            finally
            {
                Console.WriteLine("------Finally-------");
                Debug.Assert(1 > 2, "---DEBUG_ASSERT_MESSAGE");//проверяет условие, при false выдет сообщение и завершает работу программы
            }
            
        }
    }
}


