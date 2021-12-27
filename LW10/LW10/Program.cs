using System;
using System.Collections.Generic;
using System.Collections;

namespace LW10
{
    public class Student
    {
        string Name;
        int group;
        int kurs;

        public Student()
        {
            Name = "name";
            group = 0;
            kurs = 0;
        }
    }

    
        
    
    class Program
    {
        
        static void Main(string[] args)
        {

            ArrayList arrayList = new ArrayList();
            arrayList.AddRange(new int[] { 1, 2, 3, 4, 5 });
            arrayList.Add("oleg");
            arrayList.Add(new Student());

            arrayList.Show();

            Console.WriteLine("Введите номер удаляемого элемента:   ");

            int n=0;
            n=Convert.ToInt32(Console.ReadLine());
            arrayList.RemoveAt(n);
            
            arrayList.Show();
            Console.WriteLine($"Кол-во элементов: {arrayList.Count}");
            Console.WriteLine(arrayList.IndexOf(2));

            Dictionary<double, double> dick = new Dictionary<double, double>();
            dick.Add(1, 2);
            dick.Add(2, 8);
            dick.Add(3, 10);
            dick.Add(4, 15);
            dick.Add(5, 20);
            for (int i = 0; i < n; i++)
                dick.Remove(i);
            dick.TryAdd(6, 2020);
            Queue<double> ne_dick = new Queue<double>();
            foreach (double k in dick.Keys)
                ne_dick.Enqueue(dick[k]);

            Console.WriteLine("Вторая коллекция: \n");
            foreach (double k in ne_dick)
                Console.WriteLine(k);

        }
    }
    static class ext
        {
            public static void Show(this ArrayList arr)
            {
            Console.WriteLine("\nСписок элементов:\n");
                foreach (var n in arr)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("\nКонец списка элементов:\n");
        }
        }
}
