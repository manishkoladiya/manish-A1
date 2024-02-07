using System.Xml.Linq;

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