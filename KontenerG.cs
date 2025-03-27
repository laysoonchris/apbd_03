namespace apbd_03.Properties;
using System;

public class KontenerG : Kontener, IHazardNotifier
{
    public double pressure { get; set; }

    public KontenerG(double height, double konWeight, 
        double depth, double maxWeight, double pressure)
        : base(height, konWeight, depth,'G', maxWeight)
    {
        this.pressure = pressure;
    }

    public override void fill(double mass)
    {

        if (goodsWeight + mass > maxWeight)
        {
            DangerousState("Przekroczono dopuszczalny limit w kontenerze", serialNumber);
            throw new OverflowException("Za duży ładunek w kontenerze gazowym.");
        }
        goodsWeight += mass;
    }

    public override void empty()
    {
        goodsWeight = 0.05 * goodsWeight;
    }

    public void DangerousState(string message, string serialNumber)
    {
        Console.WriteLine(message + " : " + serialNumber);
    }
}