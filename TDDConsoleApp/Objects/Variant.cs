using System;


namespace TDDConsoleApp.Objects;

public class Variant
{
    private readonly string _name;
    private readonly IList<Gtin> _gtins;

    public string Name { get => _name; }
    public IList<Gtin> Gtins { get => _gtins; }

    public Variant(string name, IList<Gtin> gtins)
    {
        _name = name;
        _gtins = gtins;
    }

    public Variant(string name)
    {
        _name = name;
        _gtins = new List<Gtin>();
    }


    public Gtin GetMinPrice()
    {
        Gtin gtin = Gtins[0];
        for (int i = 1; i < Gtins.Count; i++)
        {
            var temp = Gtins[i];
            if (temp.Price is null || temp.Price < gtin.Price) 
	        {
                gtin = temp;
	        }
        }
        return gtin;
    }


    public Gtin GetMaxPrice()
    {
        Gtin gtin = Gtins[0];
        for (int i = 1; i < Gtins.Count; i++)
        {
            var temp = Gtins[i];
            if (temp.Price is not null && temp.Price > gtin.Price)
            {
                gtin = temp;
            }
        }
        return gtin;
    }


    public (bool, int?) EqualPrices()
    {
        var gtin = Gtins[0];
        if (Gtins.All(g => g.Price == gtin.Price))
        {
            return (true, gtin.Price);
        }
        else
        {
            return (false, null);
        }
    }
}