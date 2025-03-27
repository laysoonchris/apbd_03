namespace apbd_03.Properties;
using System;

public class KontenerL : Kontener, IHazardNotifier
{
    public bool isDangerous { get; set; }

    public KontenerL(double height, double konWeight, 
                     double depth, double maxWeight, bool isDangerous)
        : base(height, konWeight, depth,'L', maxWeight)
    {
        this.isDangerous = isDangerous;
    }

    public override void fill(double mass)
    {
        double max = isDangerous ? mass* 0.5 : mass * 0.9;

        if (goodsWeight + mass > max)
        {
            DangerousState("Przekroczono dopuszczalny limit w kontenerze", serialNumber);
            throw new OverflowException("Za duży ładunek.");
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