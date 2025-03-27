using System.Collections.Generic;

namespace apbd_03.Properties;
using System;

public class KontenerC : Kontener, IHazardNotifier
{
    public double temperature { get; set; }
    public string productType { get; set; }

    private static Dictionary<string, double> neededTemp = new()
    {
        { "bananas", 13.3 },
        {"chocolate", 18.0 },
        {"fish", 2.0 },
        {"meat", -15.0 },
        {"ice cream", -18.0 },
        {"frozen pizza", -30.0 },
        {"cheese", 7.2 },
        {"sausages", 5.0},
        {"butter", 20.5},
        {"eggs", 19.0}
    };

    public KontenerC(double height, double konWeight, 
        double depth, double maxWeight, string productType, double temperature)
        : base(height, konWeight, depth,'C', maxWeight)
    {
        this.productType = productType;
        this.temperature = temperature;

        if (!neededTemp.ContainsKey(productType))
        {
            throw new ArgumentException("Brak produktu takiego typu.");
        }

        if (temperature > neededTemp[productType])
        {
            DangerousState("Za wysoka temperatura dla produktu w kontenerze", serialNumber);
            throw new Exception("Produkt nie może być przechowywany w tej temperaturze.");
        }
    }
    public override void fill(double mass)
    {
        if (goodsWeight + mass > maxWeight)
        {
            DangerousState("Przekroczono dopuszczalny limit w kontenerze", serialNumber);
            throw new OverflowException("Za duży ładunek w kontenerze chłodniczym.");
        }
        goodsWeight += mass;
    }

    public override void empty()
    {
        goodsWeight = 0;
    }

    public void DangerousState(string message, string serialNumber)
    {
        Console.WriteLine(message + " : " + serialNumber);
    }
}