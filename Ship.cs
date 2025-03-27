using System.Collections.Generic;
using System.Linq;

namespace apbd_03.Properties;
using System;


public class Ship
{
    public string name { get; set; }
    public int maxKontenerNumber { get; set; }
    public double maxSpeedKnots { get; set; }
    public double maxShipWeight { get; set; }
    
    private List<Kontener> kontenery;

    public Ship(string name, int maxKontenerNumber,
        double maxSpeedKnots, double maxShipWeight)
    {
        this.name = name;
        this.maxKontenerNumber = maxKontenerNumber;
        this.maxSpeedKnots = maxSpeedKnots;
        this.maxShipWeight = maxShipWeight;
        kontenery = new List<Kontener>();
    }

    public bool addKontener(Kontener kontener)
    {
        if (kontenery.Count >= maxKontenerNumber)
        {
            Console.WriteLine("Za dużo kontenerów na statku.");
            return false;
        }

        double totalWeight = kontenery.Sum(k => k.goodsWeight + k.konWeight);

        if ((totalWeight + kontener.goodsWeight + kontener.konWeight) > maxShipWeight * 1000)
        {
            Console.WriteLine("Za duża waga kontenera.");
            return false;
        }
        kontenery.Add(kontener);
        Console.WriteLine("Kontener: " + kontener + " pomyślnie wprowadzony na statek.");
        return true;
    }

    public bool addKontenery(List<Kontener> list)
    {
        foreach (var kontener in list)
        {
            if (!addKontener(kontener))
                return false;
        }
        return true;
    }
    
    public bool removeContainer(string serial)
    {
        var kontener = kontenery.FirstOrDefault(k => k.serialNumber == serial);
        if (kontener == null) return false;
        kontenery.Remove(kontener);
        Console.WriteLine($"Usunięto kontener {serial}");
        return true;
    }
    
    public bool ReplaceContainer(string serialToReplace, Kontener newContainer)
    {
        int index = kontenery.FindIndex(k => k.serialNumber == serialToReplace);
        if (index == -1) return false;

        kontenery[index] = newContainer;
        Console.WriteLine($"Zastąpiono kontener {serialToReplace} nowym {newContainer.serialNumber}");
        return true;
    }

    public bool moveKontener(string serial, Ship target)
    {
        var kontener = kontenery.FirstOrDefault(k => k.serialNumber == serial);
        
        if (kontener == null) return false;

        if (target.addKontener(kontener))
        {
            kontenery.Remove(kontener);
            Console.WriteLine("Przeniesiono kontener " + serial + " na statek " + target.name);
            return true;
        }
        return false;
    }

    public void show(string serial)
    {
        var k = kontenery.FirstOrDefault(k => k.serialNumber == serial);
        if (k != null) k.show();
        else Console.WriteLine("Brak kontenera " + serial + "na statku");
    }

    public void showShip()
    {
        Console.WriteLine("\nInformacje o statku: " +
                          "\nNazwa: " + name +
                          "\nLiczba kontenerów: " + kontenery.Count +
                          "\nPrędkość maksymalna: " + maxKontenerNumber + $" węzłów");
        Console.WriteLine($"Łączna masa: {kontenery.Sum(k => k.goodsWeight + k.konWeight)} kg / {maxShipWeight * 1000} kg");

        foreach (var i in kontenery)
        {
            Console.WriteLine($" {i.serialNumber}: ({i.goodsWeight + i.konWeight} kg)");
        }
    }
}
