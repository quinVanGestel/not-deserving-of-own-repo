using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

SafeCracker reference = new();
Console.WriteLine("Amount of zeroes: " + reference.AmountOfZeroes().ToString());


public static class Settings
{
    public static string[] inputRaw = File.ReadAllLines("input.txt");
}

public class SafeCracker
{
    private string[] inputRaw = Settings.inputRaw;
    [MaybeNull]
    private Rotation[] rotations;
    private Dial dial = new();

    public int AmountOfZeroes()
    {
        rotations = new Rotation[inputRaw.Length];
        int zeroes = 0;

        for (int i = 0; i < rotations.Length; i++)
        {
            rotations[i] = new(inputRaw[i]);
            // Console.WriteLine(i.ToString() + ": " + inputRaw[i] + " " + rotations[i].distance.ToString());
        }

        for (int i = 0; i < rotations.Length; i++)
        {
            Console.Write("Pos: " + dial.position + " Rot: " + rotations[i].distance + " New: ");
            dial.MoveDial(rotations[i].distance);
            Console.Write(dial.position + "  ");
            if (dial.position == 0)
            {
                zeroes++;
                Console.WriteLine("The dial is 0 :)");
            }
        }

        return zeroes;
    }
}


public class Dial
{
    private static int minDialPosition = 0;
    private static int maxDialPosition = 99;

    [Range(0, 99)]
    public int position = 50;

    private int handleUnderflowRecursive(int value, int minValue, int maxValue)
    {
        if (value < minValue)
        {
            value += maxValue + 1;
        }

        if (value < minValue)
        {
            value = handleUnderflowRecursive(value, minValue, maxValue);
        }

        return value;
    }

    private int handleOverflowRecursive(int value, int maxValue)
    {
        if (value > maxValue)
        {
            value -= maxValue + 1;
        }

        if (value > maxValue)
        {
            value = handleOverflowRecursive(value, maxValue);
        }

        return value;
    }

    public void MoveDial(int distance)
    {
        int newPosition = position + distance;

        newPosition = handleUnderflowRecursive(newPosition, minDialPosition, maxDialPosition);
        if (newPosition < minDialPosition)
        {
            Console.Beep();
            Console.WriteLine("!! dial underload! position is now " + newPosition);
        }

        newPosition = handleOverflowRecursive(newPosition, maxDialPosition);
        if (newPosition > maxDialPosition)
        {
            Console.Beep();
            Console.WriteLine("!! dial overload! position is now " + newPosition);
        }

        position = newPosition;
    }
}


public class Rotation
{
    public int distance;

    public Rotation(string rawInput)
    {
        distance = convertInputToDistance(rawInput);
    }

    private int convertInputToDistance(string input)
    {
        int inputInt = int.Parse(input.Remove(0, 1));

        switch (input[0].ToString())
        {
            case "L":
                // Console.WriteLine(input + " goes to the left :)");
                return -inputInt;

            case "R":
                // Console.WriteLine(input + " goes to the right :)");
                return inputInt;

            default:
                // Console.WriteLine(input + "'s direction is immeasurable :o");
                return 0;
        }
    }
}








