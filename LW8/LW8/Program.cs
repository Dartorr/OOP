using System;
using System.Collections.Generic;

namespace LW8
{
    class Program
    {
        class FuncEx : Exception //исключение
        {
            public FuncEx(string Message) : base(Message)
            {

            }
        }

        

        public class Stuff //класс из ЛР5, взят в качестве ограничения
        {
            public int Cost;
            public string Name;
            public int Age;

            public Stuff()
            {
                Cost = 0;
                Name = "NoName";
                Age = 0;
            }
        }

        interface ICommon<T>//обощенный интерфейс
        {
            void AddElem(T elem);
            void RemoveElev(T elem);
            void Show();
        }
        public class ListOfElements<T> : ICommon<T>  //класс MN из ЛР4 (переименован в ListOfElements, чтобы дать классу более адекватное название)
            //ограничения на обобщение
            where T: new()
            //where T : struct
            //where T: Stuff
            // where T: Int32 //Ошибка, т.к. можно в качестве ограничения юзать только классы, структуры, интерфейсы и new()
        {
            public List<T> MainList = new List<T>() { };//список элементов
            public ListOfElements(T[] a) //Конструктор основного списка, принимает массив элементов типа Т
            {
                MainList.AddRange(a);


            }
            public void AddElem(T elem)//добавление эл-та
            {
                this.MainList.Add(elem);
                bool Flag = (this.MainList.IndexOf(elem) != -1);
                if (Flag == false) throw new FuncEx($"AddElem Exeption: Result of AddElem({elem}) is False");//если после добавления эл-нт не был найден - кидает исключение
                Console.WriteLine($"Result of AddElem: {Flag}");
            }
            public void RemoveElev(T elem) //удаляет элемент
            {
                bool Flag = this.MainList.Remove(elem);
                if (Flag == false) throw new FuncEx($"RemoveElem Exeption: Result of RemoveElem({elem}) is False");//кидает ошибку, если элемент не был удален или найден
                Console.WriteLine($"Result of RemoveElem: {Flag}");
            }
            public void Show() //выводит список элементов
            {
                int k = 0;
                Console.WriteLine("List:\n");
                foreach (T a in this.MainList)
                {
                    Console.WriteLine($"\t{a}");
                    k++;
                }
                Console.WriteLine($"\nTotal Count of Elems: {k}\n");
            }
        }

        static void Main()
        {
            try
            {
                ListOfElements<char> structs = new ListOfElements<char>(new char[] { 'a', 'b', 'c', });
                structs.AddElem('d');
                structs.Show();
                structs.RemoveElev('d');
                structs.Show();
               // structs.RemoveElev('d');//здесь вызывается исключение
                ListOfElements<Stuff> objects = new ListOfElements<Stuff>(new Stuff[] { new Stuff(), new Stuff(), new Stuff(), });
                objects.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}\t{ex.TargetSite}");
            }
            finally
            {
                Console.WriteLine("Finally");
            }
        }
    }
}