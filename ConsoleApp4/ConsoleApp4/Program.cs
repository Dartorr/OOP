using System;
using System.Collections.Generic;


namespace ConsoleApp4
{
    public class MN
    {
        
        public List<int> mn = new List<int>() { };
        public readonly Date date = new Date();
        public readonly Owner owner = new Owner();


        public class Owner
        {
            public int ID { get; }
            public string Author { get; }
            public string Organization { get; }

            public Owner()
            {
                this.ID = 123456789;
                this.Author = "Л.Ч.С.";
                this.Organization = "БГТУ";
            }
        }
        public class Date
        {
            public DateTime Time { get; }

            public Date()
            {
                Time = DateTime.Now;
            }
        }


        public MN(int[] a) //Конструктор основного MN
        {
            List<int> temp = new List<int>() { };
            temp.AddRange(a);
            mn = temp;
            owner = new Owner();
            date = new Date();
        }

        public MN() //конструктор буферного MN
        {
            
        }
        public static bool operator >>(MN mn, int s) //удаление элемента
        {
            bool a = mn.mn.Remove(s);
            foreach (int c in mn.mn) Console.Write($"{c}\t");
            Console.Write("\n");
            return a;
        }

        public int add ( int s) //метод добавления элемента
        {

            if (this.mn.IndexOf(s) == -1)
                this.mn.Add(s);
            
            return 0;
        }
        public static int operator <<(MN mn, int s) //добавление элемента
        {

            if (mn.mn.IndexOf(s) == -1)
                mn.mn.Add(s);
            foreach (int c in mn.mn) Console.Write($"{c}\t");
            Console.Write("\n");
            return 0;
        }
        public static bool operator >(MN mn, MN pod) //проверка на подмножество
        {
            bool flag = true;
            {
                foreach (int c in pod.mn)
                    if (mn.mn.IndexOf(c) == -1) flag = false;
            }
            
            return flag;
        }
        public static bool operator <(MN mn, MN mn2)
        {
            return false;
        }

        public static bool operator !=(MN mn, MN mn2) //проверка множеств на неравенство
        {
            bool flag = true;
            {
                foreach (int c in mn2.mn)
                    if (mn.mn.IndexOf(c) == -1) flag = false;
            }
            return flag;
        }
        public static bool operator ==(MN mn, MN mn2)
        {
            return false;
        }

        public static MN operator %(MN mn, MN mn2) //проверка на пересечение
        {
            MN per = new MN();
            foreach (int c in mn.mn)
            {
                if (mn2.mn.IndexOf(c) != -1)
                {
                    per.add(c);
                }
            }
            return per;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 1, 2, 3 };
            int[] b = new int[] { 2, 3, 4 };

            MN oleg = new MN(a);
            MN oleg2 = new MN(b);

            MN pod = new MN(new int[] { 1 });

            foreach (int c in oleg.mn) Console.Write($"{c}\t"); //вывод множества
            Console.Write("\n");
            foreach (int c in oleg2.mn) Console.Write($"{c}\t"); //вывод множества
            Console.Write("\n");
            Console.Write("\n");
            {
                Console.WriteLine(oleg >> (2));//удаление. True, если удалено успешно
                Console.WriteLine((oleg > pod));//проверка. True, если является подмножеством
                Console.WriteLine(oleg << (2));//добавление. 0, если операция прошла успешно
                Console.WriteLine(oleg != oleg2);//равенство. False, если множества не равны
            }

            MN mn = oleg % oleg2; //переменная с пересечением

            foreach (int c in mn.mn) Console.Write($"{c}\t"); //вывод пересечения
            Console.Write("\n");

            mn.sort(); //сортировка
            foreach (int c in mn.mn) Console.Write($"{c}\t");
            Console.Write("\n");
            Console.WriteLine(mn.smoller()); //наименьшее число

            Console.WriteLine($"{ oleg.owner.ID}\t{ oleg.owner.Author}\t{ oleg.owner.Organization}\t{oleg.date.Time}");//Данные о владельце и дата
            Console.WriteLine($"{mn.minus()}\t{mn.sum()}\t{mn.kol()}\t");//макс-мин, сумма всех элементов, количество элементов
        }
        
    }
    public static class MethodExtension //Методы расширения
    {
        public static string smoller(this MN mn)
        {
            int min = 1000000;
            foreach (int c in mn.mn)
            {
                if (c < min) min = c;
            }
            return min.ToString();
        }

        public static MN sort(this MN mn)
        {
            
            mn.mn.Sort();
            
            return mn;
        }
        public static int sum(this MN mn)
        {
            int sum = 0;
            foreach (int c in mn.mn) sum += c;
            return sum;
        }

        public static int minus(this MN mn)
        {
            int min = 10000;
            int max = 0;
            foreach (int c in mn.mn)
            {
                if (c < min) min = c;
                if (max < c) max = c;
            }
            return (max - min);
        }

        public static int kol(this MN mn)
        {
            int k = 0;
            foreach (int c in mn.mn)
            {
                k++;
            }
            return k;
        }
    }
}
