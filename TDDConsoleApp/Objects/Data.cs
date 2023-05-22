using System;


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
            product = Products.Single(v => v.Name == productName);
        }
        else
        {
            product = new Product(productName);
        }

        Variant variant;
        if (product.Variants.Any(v => v.Name == variantName))
        {
            variant = product.Variants.Single(v => v.Name == variantName);
        }
        else
        {
            variant = new Variant(variantName);
        }

        Gtin gitin = new Gtin(gtinName, price);

        variant.Gtins.Add(gitin);
        product.Variants.Add(variant);
        Products.Add(product);
    }

    public Data Input(IList<string> list)
    {
        var data = new Data();

        if (list.Count % 4 != 0) throw new Exception("Wrong Input");
        else for (int i = 0; i < list.Count / 4; i+=4) Build(list[i], list[i + 1], 
	                                                        list[i + 2], int.Parse(list[i+3]));
        return data;
    }


    public string OutputSimple() 
    {
        var str = string.Empty;

        string levelp = string.Empty;

        foreach (var p in Products) 
	    {
            var result = p.EqualPrices();
            if (p.EqualPrices().Item1) 
	        {
                str += $"Level: {p.Name}, Price: {result.Item2}.{Environment.NewLine}"; 
	        }
        }

        str += $"Fin.";
        return str;     
    }

    public string Output()
    {
        var str = string.Empty;

        foreach (var p in Products)
        {
            var pEquals = p.EqualPrices();
            if (p.EqualPrices().Item1)
            {
                str += $"Level: {p.Name}, Price: {pEquals.Item2}.{Environment.NewLine}";
            }
            else
            {
                var vMax = p.GetMaxPrice();
                var vMin = p.GetMaxPrice();

                str += $"Level: {p.Name}, Price: {vMin.Item1}.{Environment.NewLine}";

                foreach (var v in p.Variants)
                {
                    var vEquals = v.EqualPrices();
                    if (v.EqualPrices().Item1)
                    {
                        break;
                    }
                    else
                    {
                        var gMax = v.GetMaxPrice();
                        var gMin = v.GetMaxPrice();

                        str += $"Level: {v.Name}, Price: {gMax.Price}.{Environment.NewLine}";
                        str += $"Level: {v.Name}, Price: {gMax.Price}.{Environment.NewLine}";
                    }
                }
            }
        }

        str += $"Fin.";
        return str;
    }
}

