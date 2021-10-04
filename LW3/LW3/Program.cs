using System;

namespace ConsoleApp3
{
    class Program
    {
        
        partial class Abiturient
        {
            public readonly int id;
            private string LastName = "undefined";
            private string Name="undefined";
            private string MiddleName = "undefined";
            private const string address="Sverdlova";
            private string Number ="0";
            private int[] grades;
            private static int kol = 0;

            public string lastName
            {
                get
                {
                    return LastName;
                }
                set
                {
                    LastName = value;
                }
            }
            public string name
            {
                get
                {
                    return Name;
                }
                set
                {
                    Name = value;
                }
            }
            public string middleName
            {
                get
                {
                    return MiddleName;
                }
                set
                {
                    MiddleName = value;
                }
            }
            public string number
            {
                get
                {
                    return Number;
                }
            }
            

            public int Average (out float Av)
            {
                int sum=0;
                int k = 0;
                foreach (int i in this.grades)
                {
                    sum += i;
                    k++;
                }
                Av = sum / k;
                return sum;
            }

            public int Min()
            {
                int min = 100;
                
                foreach (int i in this.grades)
                {
                    if (i < min) min = i;
                    
                }
                return min;
               
            }

            public int Max()
            {
                
                int max = 0;
                foreach (int i in this.grades)
                {
                   
                    if (i > max) max = i;
                }
                return max;
            }

            public Abiturient() 
            {
        
                Name = "und."; 
                LastName = "und.";
                kol++;
            }
            public Abiturient(string n, int k) 
            {
                id = k*10;
                Name = n;
                LastName = n;
                kol++;
            }
            public Abiturient(string name, string mdname, int[] grad, int k) 
            {
                id = k*10;
                Name = name; 
                LastName = name;
                MiddleName = mdname; 
                grades = grad;
                kol++;
            }
            static Abiturient() 
            { 
                Console.WriteLine("Static const");
                Abiturient ab2 = new Abiturient("ab", "ba");
            }
            private Abiturient(string n, string nn)
            {
                Console.WriteLine("Private const");
            }
        }
        static void Main(string[] args)
        {
            var anon_ab = new { id = 130, Name = "Name", Lastname = "l", middlename = "m", adr = "adr", number = "+0", grad = new int[] { 1, 3, 4 } };

            int[] gr = { 1, 2, 3 };
            Abiturient ab1 = new Abiturient();
            Abiturient ab_out = new Abiturient("Name", "MiddleName", gr, 1);
            float av = 0;
            ab_out.Average(out av);
            Console.WriteLine(av);
            Abiturient.GetInfo();
            if (ab_out.Equals(ab1) == true)
            {
                Console.WriteLine("ab_out is equal to ab1");
            }
            else
            {
                Console.WriteLine("ab_out is non equal to ab1");
            }
            Console.WriteLine(ab_out.ToString());
            Console.WriteLine($"Min: {ab_out.Min()}");
            Console.WriteLine($"Max: {ab_out.Max()}\n");
            Console.WriteLine($"Id: {ab_out.GetHashCode()}");

            Abiturient ab_one = new Abiturient("Oleg", "Olegovich", new int[] { 3, 4, 5 }, 2);
            Abiturient ab_two = new Abiturient("Vitaliy", "Olegovich", new int[] { 4, 4, 5 }, 3);
            Abiturient ab_three = new Abiturient("Oleg", "Vitalevich", new int[] { 1, 4, 5 }, 4);
            Abiturient[] mass = new Abiturient[] {ab_one,ab_two,ab_three };

            Console.WriteLine("\nStudents with grades<4: \n");
            for (int i=0;i<mass.Length;i++)
            {
                if (mass[i].Min() < 4)
                    Console.WriteLine($"Name: {mass[i].name}\tLast name: {mass[i].lastName}\t middle name: {mass[i].middleName}");
            }

            int a;
            Console.WriteLine("\nEnter a number: ");
            a=int.Parse(Console.ReadLine());

            Console.WriteLine($"\nStudents with total points>{a}: \n");
            for (int i = 0; i < mass.Length; i++)
            {
                float avv;
                if ((mass[i].Average(out avv)>a))
                    Console.WriteLine($"Name: {mass[i].name}\tLast name: {mass[i].lastName}\t middle name: {mass[i].middleName}");
            }

            Console.WriteLine($"\nAnon.type:\n" +
                $"Id: {anon_ab.id}\n" +
                $"Name: {anon_ab.Name}\n" +
                $"Last name: {anon_ab.Lastname}\n" +
                $"Middle name: {anon_ab.middlename}\n" +
                $"Adress: {anon_ab.adr}\n" +
                $"Number: {anon_ab.number}");
            Console.Write("Grades:\t");
            foreach (int n in anon_ab.grad) Console.Write($"{n}\t");
        }
        public partial class Abiturient
        {
            public static void GetInfo()
            {
                Console.WriteLine($"Abiturients: {kol}");
            }
            public override bool Equals(object obj)
            {
                Abiturient temp = obj as Abiturient;

                if (temp != null)
                {
                    if (
                        temp.id == this.id && temp.Name == this.Name &&
                        temp.Number == this.Number && temp.LastName == this.LastName &&
                        temp.MiddleName == this.MiddleName
                    )
                        return true;
                    else return false;
                }
                else return false;
            }
            public override string ToString()
            {
                return $"{this.id} {this.Name} {this.LastName} {this.MiddleName} {this.Number}\n";
            }

            public override int GetHashCode()
            {
                return this.id;
            }
        }


    }
    }
