using System;
using System.Text;
using System.Linq;

namespace LW1
{
    class Program
    {
        static void Main(string[] args)
        {
            //примитивные типы
            bool a = true;
            byte q = 240;
            sbyte qq = -100;
            short w = -32000;
            ushort ww = 65000;
            int e = -234234;
            uint ee = 2734873;
            long r = -98079698;
            ulong rr = 12312977;
            float t = 3.34234234f;
            double y = 3.39787;
            decimal u = 20347204.829384023M;
            char i = 'a';
            string ii = "aaa";
            Object hah = 2281337;

            //неявное преобр.
            y = t;
            r = e;
            w = qq;
            ww = q;
            rr = ee;

            //явное преобр.

            w = (short)q;
            r = (long)qq;
            t = (float)e;
            y = (double)t;
            ee = (uint)i;
            ee = Convert.ToUInt32(i);

            //Упаковка и распкаовка
            int f = 5;
            Object obj = f;
            int g = (int)obj;

            //работа с неяв.тип. переменной
            var ha = 123;
            Console.WriteLine($"Value: {ha}\nType: {ha.GetType()}\n");

            //работа с nullable
            int? x = null;
            Console.WriteLine($"{x.HasValue}\n");
            x = 1;
            Console.WriteLine($"{x.HasValue}\n");
            Console.WriteLine($"{x.Value}\n");

            /*
            //ошибка с var
            var xx = 1;
            xx = "1";
            */


            //строки

            //обьявить и сравнить строки
            string one = "haj";
            string two = "hih";
            if (one == two) Console.WriteLine("equal");
            else Console.WriteLine("non-equal");
            if (one == one) Console.WriteLine("equal\n");
            else Console.WriteLine("non-equal\n");

            /*операции со строками: сцепление*,
            копирование, выделение подстроки*, разделение строки на слова*,
            вставки подстроки в заданную позицию*, удаление заданной
            подстроки*/

            string one1 = "afas jlkjh waf";
            string two1 = ",l;mkkj hugiyuft ytuyi";
            string sus = "op[iui gjhbkj ,mk,nj";

            Console.WriteLine(String.Concat(sus, one1));

            string[] words = sus.Split(new char[] { ' ' });

            foreach (string s in words)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine(sus.Insert(3, two1));

            Console.WriteLine(two1.Remove(0, 5));

            Console.WriteLine(two1.Substring(0, 5));

            char[] copy = new char[10];
            one1.CopyTo(5, copy, 0, 5);
            Console.WriteLine(copy);

            Console.WriteLine("\n");
            //Пустая и Null строка
            string nullstring = null;
            string emptystring = String.Empty;
            Console.WriteLine(String.IsNullOrEmpty(nullstring));
            Console.WriteLine(String.IsNullOrEmpty(emptystring));
            if (nullstring == String.Empty) Console.WriteLine("\nEmpty\n");
            else Console.WriteLine("\nNull\n");

            //StringBuilder
            StringBuilder sb = new StringBuilder("text");
            sb = sb.Remove(1, 2);
            Console.WriteLine(sb);
            sb = sb.Insert(0, "tex");
            sb = sb.AppendFormat("ext");
            Console.WriteLine(sb);

            //Массивы
            int[,] mas = new int[3, 3] { { 0, 1, 2 }, { 2, 1, 0 }, { 2, 1, 2 } };

            for (int ind1 = 0; ind1 < 3; ind1++)
            {
                for (int ind2 = 0; ind2 < 3; ind2++)
                {
                    Console.Write($"{mas[ind1, ind2]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            string[] str = { "str_1", "str_2", "str_3" };
            Console.WriteLine(str.Length);
            foreach (string strr in str) Console.WriteLine(strr);

            Int32 pos = Int32.Parse(Console.ReadLine());
            str[pos] = Console.ReadLine();
            Console.WriteLine();

            foreach (string strr in str) Console.WriteLine(strr);

            //Ступенчатый массив
            int[][] st_mas = new int[3][];
            st_mas[0] = new int[2] { 1, 2 };
            st_mas[1] = new int[3] { 3, 4, 5 };
            st_mas[2] = new int[4] { 6, 7, 8, 9 };

            //неяв.тип. переменные для массива и строки
            var n_str = "oleg";
            var n_mas = mas;
            for (int ind1 = 0; ind1 < 3; ind1++)
            {
                for (int ind2 = 0; ind2 < 3; ind2++)
                {
                    Console.Write($"{n_mas[ind1, ind2]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //кортежи 
            (int, string, char, string, ulong) oleg = (1, "1", '1', "2", 554);
            Console.WriteLine(oleg);
            Console.WriteLine(oleg.Item1);
            Console.WriteLine(oleg.Item5);
            Console.WriteLine(oleg.Item3);
            (var N, var NN, var NNN, var NNNN, var NNNNN) = oleg;
            Console.WriteLine($"{N} {NN} {NNN} {NNNN} {NNNNN}");

            (int, string, char, string, ulong) oleg2 = (1, "1", '1', "2", 554);
            if (oleg == oleg2) Console.WriteLine("\nEqual\n");
            else Console.WriteLine("\nNon-equal\n");

            //функция
            (int, int, int, char) function(int[] mas, string stroke)
            {
                return (mas.Max(), mas.Min(), mas.Sum(), stroke.First());
            }
            int[] massss = { 1, 2, 3 };
            string st = "stroka";
            Console.WriteLine(function(massss, st));

        }
    }
}
