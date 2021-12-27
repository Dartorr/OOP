using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace LR11
{
    class Program
    {

        partial class Abiturient
        {
            public readonly int id;
            public string LastName = "undefined";
            public string Name = "oleg";
            public string MiddleName = "undefined";
            public const string address = "Sverdlova";
            public string Number = "0";
            public int[] grades;
            public static int kol = 0;


            public Abiturient() //конструктор 1
            {


                LastName = ((new Random()).Next(1000000)).ToString();
                Name = ((new Random()).Next(1000000)).ToString();
                MiddleName = ((new Random()).Next(1000000)).ToString();
                Number = ((new Random()).Next(1000000)).ToString();
                LastName = ((new Random()).Next(1000000)).ToString();
                kol++;
            }
            public Abiturient(string n, int k) //кр2
            {
                id = k * 10;
                Name = n;
                LastName = n;
                kol++;
            }
            public Abiturient(string name, string mdname, int[] grad, int k) //кр3
            {
                id = k * 10;
                Name = name;
                LastName = name;
                MiddleName = mdname;
                grades = grad;
                kol++;
            }

        }
        static void Main(string[] args)
        {

            int n = 6;
            Console.WriteLine($"\nМесяцa длиной в {n} буквы");
            string[] mass = new string[] { "January", "February", "March", "April", "May",
                "June", "July", "August", "September", "October", "November", "December" };

            var LenN = from t in mass where t.Length == n select t;
            foreach (string t in LenN) Console.WriteLine(t);

            Console.WriteLine($"\nМесяцы лета и зимы");
            string[] sum_win_mon = new string[] { "January", "February",
                "June", "July", "August", "December" };
            var Summer_and_Winter = from t in mass where sum_win_mon.Contains(t) select t;
            foreach (string t in Summer_and_Winter) Console.WriteLine(t);

            Console.WriteLine($"\nМесяцa по алфавиту");
            var alp = from t in mass orderby t select t;
            foreach (string t in alp) Console.WriteLine(t);

            Console.WriteLine($"\nМесяцa с U и длиной в 4");
            var u_4 = from t in mass where (t.Contains('u')&&t.Length >= 6) select t;
            foreach (string t in u_4) Console.WriteLine(t);

            List<Abiturient> class_list = new List<Abiturient>();
            class_list.Add(new Abiturient());
            class_list.Add(new Abiturient());
            class_list.Add(new Abiturient());

            foreach (Abiturient k in class_list)
            {
                Console.WriteLine($"\t{k.Name} {k.LastName} {k.MiddleName}");
            }


            //количество строк длины n и т
            n = 6;
            int m = 5;

            int kol = (from t in class_list where t.Name.Length == n select t).Count();
            kol += (from t in class_list where t.Name.Length == m select t).Count();
            Console.WriteLine(kol);
            //список строк, которые содержат заданное слово.
            var list = from t in class_list where t.Name.Contains("5") select t.Name;
           
            foreach (string t in list) Console.WriteLine(t);


            //Максимальную строку
            var one = from t in class_list select (t.Name+t.LastName + t.MiddleName).ToString();
            var sss = from t in one select one.Max();
            foreach (string s in sss)
            { Console.WriteLine(s);
                break;
            }

            //Первую строку, содержащую точку или ?
            class_list[2].Name += '.';
            var fir = from t in class_list where (t.Name.Contains('.') || t.Name.Contains('?')) select t.Name;
            Console.WriteLine(fir.First());

            /*количество строк длины n и т
            список строк, которые содержат заданное слово.
            Максимальную строку
            Первую строку, содержащую точку или ?
            Последнюю строку с самым коротким словом
            Упорядоченный массив по первому слову*/


            // from название_переменной in список_или_массив условие_выборки select название_переменной


            int[] mas1 = new int[] { 1, 2, 3 };
            int[] mas2 = new int[] { 1, 2, 30 };
            int[] mas3 = new int[] { 1, 2, 300 };
            List<int[]> al = new List<int[]>();
            al.AddRange(new int[][] { mas1, mas2, mas3 });

            var three = from t in ((mas1.Union(mas2)).Union(mas3)).Distinct() orderby t where (t > mas1.Average()) select t;

            var hah = from t in mas1 join a in mas2 on t equals a select t;
            foreach (var t in hah) Console.WriteLine("join " + t);
        }
    }
}
