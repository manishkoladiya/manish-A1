using System;

class VirtualPet
{
    private const int MaxStatValue = 10;
    private const int MinStatValue = 1;

    private string name;
    private int hunger;
    private int happiness;
    private int health;

    public VirtualPet(string petName)
    {
        name = petName;
        hunger = MaxStatValue / 2; // Starting hunger at 5
        happiness = MaxStatValue / 2; // Starting happiness at 5
        health = MaxStatValue / 2; // Starting health at 5
    }

    public void DisplayWelcomeMessage(string petType)
    {
        Console.WriteLine($"welcom buddy");
        Console.WriteLine($"You have a {petType} named {name}.");
        Console.WriteLine("Let's take good care of your virtual pet!");
    }

    public void DisplayStats()
    {
        Console.WriteLine("\nPet Stats:");
        Console.WriteLine($"Hunger: {hunger}/10");
        Console.WriteLine($"Happiness: {happiness}/10");
        Console.WriteLine($"Health: {health}/10");
    }

    public void Feed()
    {
        hunger -= 2; // Feeding decreases hunger by 2
        happiness++; // Feeding increases happiness
        Console.WriteLine($"You feed {name}. Hunger decreases and happiness increases.");
        PassTime();
    }

    public void Play()
    {
        if (hunger <= 3)
        {
            Console.WriteLine($"{name} is too hungry to play.");
        }
        else
        {
            happiness += 2; // Playing increases happiness by 2
            hunger++; // Playing increases hunger
            Console.WriteLine($"{name} plays happily.");
            PassTime();
        }
    }

    public void Rest()
    {
        health += 2; // Resting increases health by 2
        happiness--; // Resting decreases happiness
        Console.WriteLine($"{name} takes a rest. Health improves but happiness decreases.");
        PassTime();
    }

    private void PassTime()
    {
        hunger++; // Hunger increases over time
        happiness--; // Happiness decreases slightly over time
        if (hunger > MaxStatValue) hunger = MaxStatValue; // Cap hunger at max value
        if (happiness < MinStatValue) happiness = MinStatValue; // Cap happiness at min value
        if (health < MinStatValue) health = MinStatValue; // Cap health at min value
        if (hunger <= 3) health--; // If hunger is critically low, health deteriorates
    }

    public void CheckStatus()
    {
        if (hunger <= 3)
        {
            Console.WriteLine($"{name} is very hungry! Please feed {name}.");
        }
        if (happiness <= 3)
        {
            Console.WriteLine($"{name} is very unhappy! Play with {name} to increase happiness.");
        }
        if (health <= 3)
        {
            Console.WriteLine($"{name}'s health is deteriorating! Make sure {name} rests.");
        }
    }
}

class Program
{
    static void Main()
    {
        

        Console.WriteLine("\nPlease choose a type of pet:");
        Console.WriteLine("1. Dog");
        Console.WriteLine("2. Cat");
        Console.WriteLine("3. Rabbit");
        Console.Write("Enter your choice: ");
        string petType = Console.ReadLine();

        Console.Write("Enter your pet's name: ");
        string petName = Console.ReadLine();

        VirtualPet pet = new VirtualPet(petName);

        pet.DisplayWelcomeMessage(GetPetType(petType));

        while (true)
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Display Stats");
            Console.WriteLine("2. Feed");
            Console.WriteLine("3. Play");
            Console.WriteLine("4. Rest");
            Console.WriteLine("5. Quit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    pet.DisplayStats();
                    pet.CheckStatus();
                    break;
                case "2":
                    pet.Feed();
                    break;
                case "3":
                    pet.Play();
                    break;
                case "4":
                    pet.Rest();
                    break;
                case "5":
                    Console.WriteLine("Quitting the virtual pet simulation. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please choose a valid option.");
                    break;
            }
        }
    }

    static string GetPetType(string choice)
    {
        switch (choice)
        {
            case "1":
                return "Dog";
            case "2":
                return "Cat";
            case "3":
                return "Rabbit";
            default:
                return "Unknown";
        }
    }
}
