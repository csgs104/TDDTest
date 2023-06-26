namespace TDDConsoleApp.Objects;

public class Product
{
	private readonly string _name;
	private readonly IList<Variant> _variants;
    public int? _price;

    public string Name { get => _name; }
    public IList<Variant> Variants { get => _variants; }
    public int? Price { get => _price; }

    public Product(string name, IList<Variant> variants)
	{
		_name = name;
		_variants = variants;
        SetPrice();
    }

    public Product(string name)
    {
        _name = name;
        _variants = new List<Variant>();
        _price = null;
    }

    public void SetPrice()
    {
        var price = Variants[0].Price;
        for (int i = 1; i < Variants.Count; i++)
        {
            var temp = Variants[i].Price;
            if (temp is null || temp < price)
            {
                price = temp;
            }
        }
        _price = price;
    }

    public Variant GetMaxVariant()
    {
        var variant = Variants[0];
        for (int i = 1; i < Variants.Count; i++)
        {
            var temp = Variants[i];
            if (variant.Price is null || (temp.Price is not null && temp.Price > variant.Price))
            {
                variant = temp;
            }
        }
        return variant;
    }

    public bool EqualPrices()
    {
        return Variants.All(g => g.Price == Price);
    }
}