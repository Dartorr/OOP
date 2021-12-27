using System;
using System.Collections.Generic;

namespace LW9
{
    class Program
    {
        
        public class Game
        {
            //обработчик событий
            private static void evenhandler(GameObject Interacted, GameObject WasInteractedBy, char AOrH)
            {
                Console.WriteLine("--------!!!--------");
                if (AOrH == 'A')
                    Console.WriteLine($"Object {WasInteractedBy.Name} was attacked by {Interacted.Name}!\n" +
                        $"HP lost: {Interacted.Atk}. Current HP: {WasInteractedBy.HP}.");
                else
                    Console.WriteLine($"Object {WasInteractedBy.Name} was healed by {Interacted.Name}!\n" +
                        $"HP gained: {Interacted.Atk}. Current HP: {WasInteractedBy.HP}.");
                Console.WriteLine("--------!!!--------");
            }

            //свойства и конструктор
            public List<GameObject> GameObjects_List { get; private set; }
            public Game()
            {
                GameObjects_List = new List<GameObject>();
            }
            //класс GameObject
            public class GameObject
            {
                //делегат и событие
                public delegate void GameEventDelegate(GameObject Interacted, GameObject WasInteractedBy, char AOrH);
                public event GameEventDelegate AttackEvent;
                public event GameEventDelegate HealEvent;
                //лямбда
                public delegate int AttackAndHeal(int atk,int hp);
                AttackAndHeal atk = (atk, hp) => hp - atk;
                AttackAndHeal hl = (atk, hp) => hp + atk;
                //свойства
                public string Name { get; set; }
                public int HP { get; set; }
                public int Atk { get; set; }
                //конструкторы
                public GameObject()
                {
                    Name = "NoName";
                    HP = 0;
                    Atk = 0;
                }

                public GameObject(int atk, int hp, string name)
                {
                    Name = name;
                    HP = hp;
                    Atk = atk;
                }
                //методы game object
                public void show()
                {
                    Console.Write($"Name: {this.Name}\t HP: {this.HP}\t ATK: {this.Atk}\n");
                }

                public void Attack(GameObject Attacked)
                {
                    Attacked.HP = atk(this.Atk, Attacked.HP);
                    AttackEvent(this, Attacked, 'A');
                }

                public void Heal(GameObject Healed)
                {
                    Healed.HP = hl(this.Atk, Healed.HP);
                    HealEvent(this, Healed, 'H');
                }
            }
            //методы Game
            public void Add(int atk, int hp, string name)
            {
                GameObject G = new GameObject(atk, hp, name);
                G.AttackEvent += evenhandler;
                G.HealEvent += evenhandler;
                this.GameObjects_List.Add(G);
            }

            public void Remove(int atk, int hp, string name)
            {
                GameObject G = new GameObject(atk, hp, name);
                this.GameObjects_List.Remove(G);
            }

            public void Show()
            {
                int n = 0;
                foreach (GameObject A in this.GameObjects_List)
                {
                    Console.Write($"{n}.\t");
                    A.show();
                    n++;
                }
            }
        }

        //методы польз.обработки строк
        static void WOSpace(string a)
        {
            
            for (int i = 0; i < a.Length; i++)
                if (a[i] == ' ')
                {
                    a = a.Remove(i, 1);
                    i--;
                }
            Console.WriteLine(a);
        }

        static int HowMuchSpace(string a)
        {
            int k = 0;
            for (int i = 0; i < a.Length; i++)
                if (a[i] == ' ')
                {
                    k++;
                }
            return k;
        }

        static void AllIsO(string a)
        {
            for (int i = 0; i < a.Length; i++)
                if (a[i] != ' ')
                {
                    a = a.Remove(i, 1);
                    a = a.Insert(i, "O");
                }
            Console.WriteLine(a);
        }

        static string RemoveOAndSpace(string a)
        {
            string b = a;
            b = b.Replace("O", "");
            b = b.Replace(" ", "");
            return b;
        }

        static string AllSpaceIsO(string b)
        {
            b = b.Replace(" ", "O");
            return b;
        }

        static void Main()
        {
            Game game = new Game();
            
            game.Add(3, 5, "murlock"); 
            game.Add(4, 5, "not a murlock");

            game.Show();

            game.GameObjects_List[0].Attack(game.GameObjects_List[1]);
            game.GameObjects_List[1].Heal(game.GameObjects_List[0]);

            game.Show();

            Console.WriteLine("\n\n\nПольз.обработка строк:");

            Action<string> fn = WOSpace;
            Func<string, int> hm = HowMuchSpace;
            Action<string> all_o = AllIsO;
            Func<string, string> RemO = RemoveOAndSpace;
            Func<string, string> all_s_O = AllSpaceIsO;

            string a = "o l e g";
            fn(a);
            int k = hm(a);
            Console.WriteLine(k);
            all_o(a);
            String b = "O O O a O aa";
            Console.WriteLine(RemO(b));
            Console.WriteLine(all_s_O(a));

        }
    }
}

//Создать класс Игра с событиями Атака и Лечить. В main создать
//некоторое количество игровых объектов. Подпишите объекты на
//события произвольным образом. Реакция на события у разных
//объектов может быть разной (без изменения,
//увеличивается/уменьшается уровень жизни). Проверить состояния
//игровых объектов после наступления событий, возможно не
//однократном.
