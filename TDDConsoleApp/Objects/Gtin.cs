namespace TDDConsoleApp.Objects;

public class Gtin
{
    private readonly string _name;
    private readonly int? _price;

    public string Name { get => _name; }
    public int? Price { get => _price; }

    public Gtin(string name, int? price)
    {
        _name = name;
        _price = price;
    }
}