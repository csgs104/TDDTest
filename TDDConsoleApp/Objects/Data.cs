using System;
using System.Text;


namespace TDDConsoleApp.Objects;

public class Data
{
    private readonly IList<Product> _products;


    public IList<Product> Products { get => _products; }


    public Data() 
    {
        _products = new List<Product>();
    }


    private void Build(string gtinName, string variantName, string productName, int? price)
	{
        Product product;
        if (Products.Any(p => p.Name == productName))
        {
            product = Products.Single(p => p.Name == productName);
        }
        else
        {
            product = new Product(productName);
            Products.Add(product);
        }

        Variant variant;
        if (product.Variants.Any(v => v.Name == variantName))
        {
            variant = product.Variants.Single(v => v.Name == variantName);
        }
        else
        {
            variant = new Variant(variantName);
            product.Variants.Add(variant);
        }

        Gtin gtin = new Gtin(gtinName, price);
        variant.Gtins.Add(gtin);
    }


    private void SetPrices()
    {
        foreach (var product in Products)
        {
            foreach (var variant in product.Variants)
            {
                variant.SetPrice();
            }
            product.SetPrice();
        }
    }


    public void Input(IList<string> list)
    {
        if (list.Count % 4 != 0) throw new Exception("Wrong Input Lenght");
        for (int i = 0; i < list.Count; i += 4)
        {
            if (list[i] is null) throw new Exception("Wrong Gtin Input");
            if (list[i + 1] is null) throw new Exception("Wrong Variant Input");
            if (list[i + 2] is null) throw new Exception("Wrong Product Input");
            if (list[i + 3] is null ? false : !int.TryParse(list[i + 3], out _)) throw new Exception("Wrong Price Input");
        }

        for (int i = 0; i < list.Count; i += 4) 
	    {
            Build(list[i], list[i + 1], list[i + 2], int.TryParse(list[i + 3], out int res) ? res : null);
        }
    }


    public string Output()
    {
        var output = new StringBuilder();
        output.Append($"Output{Environment.NewLine}");
        SetPrices();

        foreach (var product in Products)
        {
            foreach (var variant in product.Variants)
            {
                if (!variant.EqualPrices())
                {
                    var gtin = variant.GetMaxGtin();
                    output.Append($"Level: {gtin.Name}, Price: {gtin.Price}.");
                    output.Append($"{Environment.NewLine}");
                }
            }

            if (!product.EqualPrices()) 
            {
                var variant = product.GetMaxVariant();
                output.Append($"Level: {variant.Name}, Price: {variant.Price}.");
                output.Append($"{Environment.NewLine}");
            }

            if (product.Price is null)
            {
                output.Append(string.Empty);
            }
            else
            {
                output.Append($"Level: {product.Name}, Price: {product.Price}.");
                output.Append($"{Environment.NewLine}");
            }
        }
        output.Append($"End");
        return output.ToString();
    }
}