using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction first = new Fraction();
        Console.WriteLine();
        Console.WriteLine(first.GetTop());
        Console.WriteLine(first.GetBottom());
        Console.WriteLine(first.GetFractionString());
        Console.WriteLine(first.GetDecimalValue());

        Fraction second = new Fraction(10);
        Console.WriteLine();
        Console.WriteLine(second.GetTop());
        Console.WriteLine(second.GetBottom());
        Console.WriteLine(second.GetFractionString());
        Console.WriteLine(second.GetDecimalValue());

        Fraction third = new Fraction(1,2);
        Console.WriteLine();
        Console.WriteLine(third.GetTop());
        Console.WriteLine(third.GetBottom());
        Console.WriteLine(third.GetFractionString());
        Console.WriteLine(third.GetDecimalValue());
    }
}

class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }
    public int GetTop()
    {
        return _top;
    }
    public int GetBottom()
    {
        return _bottom;
    }
    public void SetTop(int top)
    {
        _top = top;
    }
    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }
    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }
}