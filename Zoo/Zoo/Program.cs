using System;
using System.Collections.Generic;

namespace Zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            ZooLand zooLand = new ZooLand();
            zooLand.Menu();
        }
    }

    class ZooLand
    {
        public void Menu()
        {
            const string CommandAviaryTigers = "1";
            const string CommandAviaryMonkeys = "2";
            const string CommandAviaryElephats = "3";
            const string CommandAviaryCows = "4";
            const string CommandExit = "5";

            Aviary aviary = new Aviary();

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine();
                Console.WriteLine($"[{CommandAviaryTigers}] Вольер с тиграми");
                Console.WriteLine($"[{CommandAviaryMonkeys}] Вольер с обезьянами");
                Console.WriteLine($"[{CommandAviaryElephats}] Вольер с слонами");
                Console.WriteLine($"[{CommandAviaryCows}] Вольер с коровами");
                Console.WriteLine($"[{CommandExit}] Выход");

                string userInput = Console.ReadLine();
                Console.Clear();

                switch (userInput)
                {
                    case CommandAviaryTigers:
                        aviary.ShowTigtes();

                        break;

                    case CommandAviaryMonkeys:
                        aviary.ShowMonkeys();

                        break;

                    case CommandAviaryElephats:
                        aviary.ShowElephats();

                        break;

                    case CommandAviaryCows:
                        aviary.ShowCows();

                        break;

                    case CommandExit:
                        Console.WriteLine("Выход из зоопарка");
                        isWork = false;

                        break;

                    default:
                        Console.WriteLine("Incorrect input");

                        break;
                }
            }
        }
    }

    class Aviary
    {
        private static Random _random = new Random();

        private List<Animals> tigres = new List<Animals>();
        private List<Animals> _monkeys = new List<Animals>();
        private List<Animals> _elephats = new List<Animals>();
        private List<Animals> _cows = new List<Animals>();

        private int _minAnimals = 3;
        private int _maxAnimals = 30;
        private int _count;
        private int _shift = 1;

        public Aviary()
        {
            Create(0, tigres);
            Create(1, _monkeys);
            Create(2, _elephats);
            Create(3, _cows);
        }

        public void ShowTigtes()
        {
            for (int i = 0; i < tigres.Count; i++)
            {
                Console.Write($"{i + _shift} ");
                tigres[i].ShowInfo();
            }
        }

        public void ShowMonkeys()
        {
            for (int i = 0; i < _monkeys.Count; i++)
            {
                Console.Write($"{i + _shift} ");
                _monkeys[i].ShowInfo();
            }
        }

        public void ShowElephats()
        {
            for (int i = 0; i < _elephats.Count; i++)
            {
                Console.Write($"{i + _shift} ");
                _elephats[i].ShowInfo();
            }
        }

        public void ShowCows()
        {
            for (int i = 0; i < _cows.Count; i++)
            {
                Console.Write($"{i + _shift} ");
                _cows[i].ShowInfo();
            }
        }

        private void Create(int index, List<Animals> animals)
        {
            Animals[] arrayAnimals = { new Tigre("", ""), new Monkey("", ""), new Elephant("", ""), new Cow("", "") };

            _count = _random.Next(_minAnimals, _maxAnimals);

            for (int i = 0; i < _count; i++)
            {
                animals.Add(arrayAnimals[index].Clone());
            }
        }
    }
}

abstract class Animals
{
    protected static Random Random = new Random();
    protected static string Male = "Самец(Муж)";
    protected static string Female = "Самка(Жен)";

    protected string Gender;
    protected string MakesSound;

    protected string[] ArrayGender = { Male, Female };

    protected int MaxValue = 2;

    public Animals(string gender, string makesSound)
    {
        Gender = gender;
        MakesSound = makesSound;
    }

    public abstract Animals Clone();

    public void ShowInfo()
    {
        Console.WriteLine($"Животное: {GetType().Name}, Пол: {Gender}, Звук: {MakesSound}");
    }
}

class Tigre : Animals
{
    public Tigre(string gender, string makesSound) : base(gender, makesSound) { }

    public override Animals Clone()
    {
        return new Tigre(ArrayGender[Random.Next(MaxValue)], "P-P-P");
    }
}

class Monkey : Animals
{
    public Monkey(string gender, string makesSound) : base(gender, makesSound) { }

    public override Animals Clone()
    {
        return new Monkey(ArrayGender[Random.Next(MaxValue)], "У-А-А");
    }
}

class Elephant : Animals
{
    public Elephant(string gender, string makesSound) : base(gender, makesSound) { }

    public override Animals Clone()
    {
        return new Elephant(ArrayGender[Random.Next(MaxValue)], "У-У-У");
    }
}

class Cow : Animals
{
    public Cow(string gender, string makesSound) : base(gender, makesSound) { }

    public override Animals Clone()
    {
        return new Cow(ArrayGender[Random.Next(MaxValue)], "Му-Му");
    }
}


