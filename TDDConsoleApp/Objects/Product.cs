using System;


namespace TDDConsoleApp.Objects;

public class Product
{
	private readonly string _name;
	private readonly IList<Variant> _variants;

	public string Name { get => _name; }
    public IList<Variant> Variants { get => _variants; }


    public Product(string name, IList<Variant> variants)
	{
		_name = name;
		_variants = variants;
	}

    public Product(string name)
    {
        _name = name;
        _variants = new List<Variant>();
    }


    public Variant GetMinPrice()
    {
        Variant variant = Variants[0];
        for (int i = 1; i < Variants.Count; i++)
        {
            var temp = Variants[i];
            var gtinTemp = temp.GetMinPrice().Price;
            if (gtinTemp is null || gtinTemp < variant.GetMinPrice().Price)
            {
                variant = temp;
            }
        }
        return variant;
    }


    public Variant GetMaxPrice()
    {
        Variant variant = Variants[0];
        for (int i = 1; i < Variants.Count; i++)
        {
            var temp = Variants[i];
            var gtinTemp = temp.GetMinPrice().Price;
            if (gtinTemp is not null && gtinTemp > variant.GetMinPrice().Price)
            {
                variant = temp;
            }
        }
        return variant;
    }


    public (bool, int?) EqualPrices()
    {
        var result = Variants[0].EqualPrices();
        if (Variants.All(v => v.EqualPrices().Item1 == true))
        {
            return Variants.All(v => v.EqualPrices().Item2 == result.Item2) 
		           ? (true, result.Item2) 
		           : (false, null);
        }
        else
        {
            return (false, null);
        }
    }
}