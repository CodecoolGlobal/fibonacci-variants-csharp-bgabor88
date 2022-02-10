namespace Codecool.FibonacciVariants;

/// <summary>
/// Store results as objects.
/// </summary>
public class Result
{
    public string Name;
    public int Element;
    public int FibNumber;
    public int Additions;
    public double Time;


    public Result(string name, int element, int fibNumber, int additions, double time)
    {
        Name = name;
        Element = element;
        FibNumber = fibNumber;
        Additions = additions;
        Time = time;
    }
}