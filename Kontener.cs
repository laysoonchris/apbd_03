using System;
namespace apbd_03.Properties;

public abstract class Kontener
{
    public double goodsWeight { get; set; }
    public double height { get; set; }
    public double konWeight { get; set; }
    public double depth { get; set; }
    public double maxWeight { get; set; }
    public string serialNumber { get; set; }

    public Kontener(double height, 
        double konWeight, double depth, 
        char type, double maxWeight)
    {
        this.goodsWeight = 0;
        this.height = height;
        this.konWeight = konWeight;
        this.depth = depth;
        this.maxWeight = maxWeight;
        this.serialNumber = SerialNumbers.generateSerialNumber(type);
    }

    public void show()
    {
        Console.WriteLine("\nWaga ładunku: " + goodsWeight +
                          "\nWysokość kontenera: " + height +
                          "\nWaga kontenera: " + konWeight +
                          "\nGłębokość kontenera: " + depth +
                          "\nNumer seryjny: " + serialNumber +
                          "\nMaksymalna waga: " + maxWeight);
    }

    public abstract void empty();

    public abstract void fill(double mass);
    
    
    public class SerialNumbers
    {
        public static int idCount = 1;

        public static string generateSerialNumber(char type)
        {
            return $"KON-{char.ToUpper(type)}-{idCount++}";
        }
    }
    
}