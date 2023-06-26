namespace TDDConsoleApp.Objects;

public class Variant
{
    private readonly string _name;
    private readonly IList<Gtin> _gtins;
    private int? _price;

    public string Name { get => _name; }
    public IList<Gtin> Gtins { get => _gtins; }
    public int? Price { get => _price; }

    public Variant(string name, IList<Gtin> gtins)
    {
        _name = name;
        _gtins = gtins;
        SetPrice();
    }

    public Variant(string name)
    {
        _name = name;
        _gtins = new List<Gtin>();
        _price = null;
    }

    public void SetPrice()
    {
        var price = Gtins[0].Price;
        for (int i = 1; i < Gtins.Count; i++)
        {
            var temp = Gtins[i].Price;
            if (temp is null || temp < price)
            {
                price = temp;
            }
        }
        _price = price;
    }

    public Gtin GetMaxGtin()
    {
        var gtin = Gtins[0];
        for (int i = 1; i < Gtins.Count; i++)
        {
            var temp = Gtins[i];
            if (gtin.Price is null || (temp.Price is not null && temp.Price > gtin.Price))
            {
                gtin = temp;
            }
        }
        return gtin;
    }

    public bool EqualPrices()
    {
        return Gtins.All(g => g.Price == Price);
    }
}