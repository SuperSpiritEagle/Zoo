﻿using System;
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

    private List<Animal> _tigres = new List<Animal>();
    private List<Animal> _monkeys = new List<Animal>();
    private List<Animal> _elephats = new List<Animal>();
    private List<Animal> _cows = new List<Animal>();

    private int _tigre = 0;
    private int _monkey = 1;
    private int _elephat = 2;
    private int _cow = 3;

    public ZooLand()
    {
        _aviary.Create(_tigre, _tigres);
        _aviary.Create(_monkey, _monkeys);
        _aviary.Create(_elephat, _elephats);
        _aviary.Create(_cow, _cows);
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
                    _aviary.ShowAnimals(_tigres,_tigres[_tigre].AnimalTigre);

                    break;

                case CommandAviaryMonkeys:
                    _aviary.ShowAnimals(_monkeys,_monkeys[_monkey].AnimalMonkey);

                    break;

                case CommandAviaryElephats:
                    _aviary.ShowAnimals(_elephats,_elephats[_elephat].AnimalElephant);

                    break;

                case CommandAviaryCows:
                    _aviary.ShowAnimals(_cows,_cows[_cow].AnimalCow);

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
    public void Create(int animal, List<Animal> animals)
    {
        Random random = new Random();

        int min = 3;
        int max = 30;
        int numberAnimals;

        Animal[] arrayAnimals = { new Tigre("", ""), new Monkey("", ""), new Elephant("", ""), new Cow("", "") };

        numberAnimals = random.Next(min, max);

        for (int i = 0; i < numberAnimals; i++)
        {
            animals.Add(arrayAnimals[animal].Clone());
        }
    }

    public void ShowAnimals(List<Animal> animals,string animal)
    {
        int shift = 1;

        for (int i = 0; i < animals.Count; i++)
        {
            Console.Write($"{i + shift} ");
            Console.Write($"Животное: {animal} ");
            animals[i].ShowInfo();
        }
    }
}

abstract class Animal
{
    protected string Gender;
    protected string MakesSound;

    protected static Random _random = new Random();

    protected string[] _arrayGender = { "Самец(Муж)", "Самка(Жен)" };

    public Animal(string gender, string makesSound)
    {
        Gender = _arrayGender[_random.Next(_arrayGender.Length)];
        MakesSound = makesSound;
    }

    public string AnimalTigre { get; } = "Тигр";
    public string AnimalMonkey { get; } = "Обезьяна";
    public string AnimalElephant { get; } = "Слон";
    public string AnimalCow { get; } = "Корова";

    public abstract Animal Clone();

    public void ShowInfo()
    {
        Console.WriteLine($"Пол: {Gender}, Звук: {MakesSound}");
    }
}

class Tigre : Animal
{
    public Tigre(string gender, string makesSound) : base(gender, makesSound) { }

    public override Animal Clone()=> new Tigre(_arrayGender[_random.Next(_arrayGender.Length)], "P-P-P");
}


class Monkey : Animal
{
    public Monkey(string gender, string makesSound) : base(gender, makesSound) { }

    public override Animal Clone()=> new Monkey(_arrayGender[_random.Next(_arrayGender.Length)], "У-А-А");
}

class Elephant : Animal
{
    public Elephant(string gender, string makesSound) : base(gender, makesSound) { }

    public override Animal Clone() => new Elephant(_arrayGender[_random.Next(_arrayGender.Length)], "У-У-У");
}

class Cow : Animal
{
    public Cow(string gender, string makesSound) : base(gender, makesSound) { }

    public override Animal Clone() => new Cow(_arrayGender[_random.Next(_arrayGender.Length)], "МУ");
}
