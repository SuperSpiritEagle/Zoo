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
                        AviaryTigers();

                        break;

                    case CommandAviaryMonkeys:
                        AviaryMonkeys();

                        break;

                    case CommandAviaryElephats:
                        AviaryElephats();

                        break;

                    case CommandAviaryCows:
                        AviaryCows();

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

        private void AviaryTigers()
        {
            Console.WriteLine("Вольер с тиграми");
            Tiger tiger = new Tiger();
        }

        private void AviaryMonkeys()
        {
            Console.WriteLine("Вольер с обезьянами");
            Monkey monkey = new Monkey();
        }

        private void AviaryElephats()
        {
            Console.WriteLine("Вольер с слонами");
            Elephant elephant = new Elephant();
        }

        private void AviaryCows()
        {
            Console.WriteLine("Вольер с коровами");
            Cow cow = new Cow();
        }

    }

    abstract class Animals
    {
        protected Random _random = new Random();

        protected string _gender;
        protected string _makesSound;

        protected int _minAnimals = 3;
        protected int _maxAnimals = 30;
        protected int _countAnimals;
    }

    class Tiger : Animals
    {
        public Tiger()
        {
            Console.WriteLine($"Количество {GetType().Name}: {_countAnimals = _random.Next(_minAnimals, _maxAnimals)} пол: {_gender = "Муж"} {_gender = "Жен"} издает звук: {_makesSound = "P-P-P"}");
        }

    }

    class Monkey : Animals
    {
        public Monkey()
        {
            Console.WriteLine($"Количество {GetType().Name}: {_countAnimals = _random.Next(_minAnimals, _maxAnimals)} пол: {_gender = "Муж"} {_gender = "Жен"} издает звук: {_makesSound = "У-А-А"}");
        }
    }

    class Elephant : Animals
    {
        public Elephant()
        {
            Console.WriteLine($"Количество {GetType().Name}: {_countAnimals = _random.Next(_minAnimals, _maxAnimals)} пол: {_gender = "Муж"} {_gender = "Жен"} издает звук: {_makesSound = "У-У-У"}");
        }
    }

    class Cow : Animals
    {
        public Cow()
        {
            Console.WriteLine($"Количество {GetType().Name}: {_countAnimals = _random.Next(_minAnimals, _maxAnimals)} пол: {_gender = "Муж"} {_gender = "Жен"} издает звук: {_makesSound = "М-У"}");
        }
    }
}

