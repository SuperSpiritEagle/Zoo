using System;
using System.Collections.Generic;

namespace Zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            ZooLand zooLand = new ZooLand();
            zooLand.Play();
        }
    }
}

class ZooLand
{
    public void Play()
    {
        const string CommandAviaryTigers = "1";
        const string CommandAviaryMonkeys = "2";
        const string CommandAviaryElephats = "3";
        const string CommandAviaryCows = "4";
        const string CommandExit = "5";

        AviaryTigre aviaryTigter = new AviaryTigre();
        AviaryMonkey aviaryMonkey = new AviaryMonkey();
        AviaryElephat aviaryElephat = new AviaryElephat();
        AviaryCow aviaryCow = new AviaryCow();

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
                    aviaryTigter.ShowAnimals(aviaryTigter.Tigres);

                    break;

                case CommandAviaryMonkeys:
                    aviaryMonkey.ShowAnimals(aviaryMonkey.Monkeys);

                    break;

                case CommandAviaryElephats:
                    aviaryElephat.ShowAnimals(aviaryElephat.Elephats);

                    break;

                case CommandAviaryCows:
                    aviaryCow.ShowAnimals(aviaryCow.Cows);

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

abstract class Aviary
{
    protected static Random _random = new Random();

    protected int _shift = 1;

    public void ShowAnimals(List<Animals> animals)
    {
        for (int i = 0; i < animals.Count; i++)
        {
            Console.Write($"{i + _shift} ");
            animals[i].ShowInfo();
        }
    }

    protected void Create(int index, List<Animals> animals)
    {
        int _minAnimals = 3;
        int _maxAnimals = 30;
        int _count;

        Animals[] arrayAnimals = { new Tigre(), new Monkey(), new Elephant(), new Cow() };

        _count = _random.Next(_minAnimals, _maxAnimals);

        for (int i = 0; i < _count; i++)
        {
            animals.Add(arrayAnimals[index].Clone());
        }
    }
}

class AviaryTigre : Aviary
{
    public AviaryTigre()
    {
        Create(0, Tigres);
    }

    public List<Animals> Tigres { get; } = new List<Animals>();
}

class AviaryMonkey : Aviary
{
    public AviaryMonkey()
    {
        Create(1, Monkeys);
    }

    public List<Animals> Monkeys { get; } = new List<Animals>();
}

class AviaryElephat : Aviary
{
    public AviaryElephat()
    {
        Create(2, Elephats);
    }

    public List<Animals> Elephats { get; } = new List<Animals>();
}

class AviaryCow : Aviary
{
    public AviaryCow()
    {
        Create(3, Cows);
    }

    public List<Animals> Cows { get; } = new List<Animals>();
}

abstract class Animals
{
    protected string Gender;
    protected string MakesSound;

    private static Random _random = new Random();

    private string[] _arrayGender = { "Самец(Муж)", "Самка(Жен)" };

    public Animals()
    {
        Gender = _arrayGender[_random.Next(_arrayGender.Length)];
    }

    public abstract Animals Clone();

    public void ShowInfo()
    {
        Console.WriteLine($"Животное: {GetType().Name}, Пол: {Gender}, Звук: {MakesSound}");
    }
}

class Tigre : Animals
{
    public Tigre()
    {
        MakesSound = "P-P-P";
    }

    public override Animals Clone() => new Tigre();
}

class Monkey : Animals
{
    public Monkey()
    {
        MakesSound = "У-А-А";
    }

    public override Animals Clone() => new Monkey();
}

class Elephant : Animals
{
    public Elephant()
    {
        MakesSound = "У-У-У";
    }

    public override Animals Clone() => new Elephant();
}

class Cow : Animals
{
    public Cow()
    {
        MakesSound = "МУ-МУ";
    }

    public override Animals Clone() => new Cow();
}


