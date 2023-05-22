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


    public (Variant, int?) GetMinPrice()
    {
        Variant variant = Variants[0];
        int? price = Variants[0].GetMinPrice().Price;
        for (int i = 1; i < Variants.Count; i++)
        {
            var variantTemp = Variants[i];
            var priceTemp = Variants[i].GetMinPrice().Price;
            if (priceTemp is null || priceTemp < price)
            {
                variant = variantTemp;
                price = priceTemp;
            }
        }
        return (variant, price);
    }


    public (Variant, int?) GetMaxPrice()
    {
        Variant variant = Variants[0];
        int? price = Variants[0].GetMaxPrice().Price;
        for (int i = 1; i < Variants.Count; i++)
        {
            var temp = Variants[i];
            var priceTemp = Variants[i].GetMaxPrice().Price;
            if (priceTemp is not null && priceTemp > price)
            {
                variant = temp;
                price = priceTemp;
            }
        }
        return (variant, price);
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