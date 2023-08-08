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
    private Aviary _aviary = new Aviary();

    public ZooLand()
    {
        Create(_aviary.CreateTigre, _aviary.Tigres);
        Create(_aviary.CreateMonkey, _aviary.Monkeys);
        Create(_aviary.CreateElephat, _aviary.Elephats);
        Create(_aviary.CreateCow, _aviary.Cows);
    }

    public void Play()
    {
        const string CommandAviaryTigers = "1";
        const string CommandAviaryMonkeys = "2";
        const string CommandAviaryElephats = "3";
        const string CommandAviaryCows = "4";
        const string CommandExit = "5";

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
                    ShowAnimals(_aviary.Tigres);

                    break;

                case CommandAviaryMonkeys:
                    ShowAnimals(_aviary.Monkeys);

                    break;

                case CommandAviaryElephats:
                    ShowAnimals(_aviary.Elephats);

                    break;

                case CommandAviaryCows:
                    ShowAnimals(_aviary.Cows);

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

    private void ShowAnimals(List<Animals> animals)
    {
        int shift = 1;

        for (int i = 0; i < animals.Count; i++)
        {
            Console.Write($"{i + shift} ");
            animals[i].ShowInfo();
        }
    }

    private void Create(int index, List<Animals> animals)
    {
        Random random = new Random();
        int min = 3;
        int max = 30;
        int numberAnimals;

        Animals[] arrayAnimals = { new Tigre(), new Monkey(), new Elephant(), new Cow() };

        numberAnimals = random.Next(min, max);

        for (int i = 0; i < numberAnimals; i++)
        {
            animals.Add(arrayAnimals[index].Clone());
        }
    }
}

class Aviary
{
    public List<Animals> Tigres { get; } = new List<Animals>();
    public List<Animals> Monkeys { get; } = new List<Animals>();
    public List<Animals> Elephats { get; } = new List<Animals>();
    public List<Animals> Cows { get; } = new List<Animals>();

    public int CreateTigre { get; } = 0;
    public int CreateMonkey { get; } = 1;
    public int CreateElephat { get; } = 2;
    public int CreateCow { get; } = 3;
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
