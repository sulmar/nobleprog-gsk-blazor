namespace Domain.Models;

public class Measure
{
    public string Title { get; set; }
    public int Value { get; set; }
    public string Unit { get; set; }    

    public Measure(string title, int value, string unit)
    {
        Title = title;
        Value = value;
        Unit = unit;
    }
}
