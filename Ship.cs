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
    
    public void removeContainer(string serial)
    {
        var kontener = kontenery.FirstOrDefault(k => k.serialNumber == serial);
        if (kontener == null)
        {
            Console.WriteLine("\nNie znaleziono kontenera: " + serial + " !!!!");
            return;
        }
        
        kontenery.Remove(kontener);
        Console.WriteLine("\nUsunięto kontener " + serial);

    }
    
    public void ReplaceContainer(string konToReplace, Kontener newContainer)
    {
        int index = kontenery.FindIndex(k => k.serialNumber == konToReplace);
        if (index == -1)
        {
            Console.WriteLine("\nNie znaleziono kontenera, którego chcieliśmy zastąpić: " + konToReplace);
            return;
        }

        kontenery[index] = newContainer;
        Console.WriteLine("\nZastąpiono kontener " +  konToReplace + " nowym " + newContainer.serialNumber);
    }

    public void moveKontener(string serial, Ship target)
    {
        var kontener = kontenery.FirstOrDefault(k => k.serialNumber == serial);

        if (kontener == null)
        {
            Console.WriteLine("Brak takiego kontenera " + serial);
            return;
        }
        if (target.addKontener(kontener))
        {
            kontenery.Remove(kontener);
            Console.WriteLine("Przeniesiono kontener " + serial + " na statek " + target.name);
        }
        else
        {
            Console.WriteLine("Błąd w trakcie przenoszenia kontenera " + serial + " na statek " + target.name);
        }
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
                          "\nPrędkość maksymalna: " + maxKontenerNumber + " węzłów" + 
                          "\nMaksymalna waga wszystkich kontenerów, które mogą być transportowane: " + maxShipWeight + " ton");
        Console.WriteLine("Łączna masa: " + kontenery.Sum(k => k.goodsWeight + k.konWeight) + " kg / " + maxShipWeight*1000 + " kg");
        //^^Musimy tutaj pomnożyć wartość maxShipWeight * 1000 żeby nam zgadzały się jednostki

        foreach (var i in kontenery)
        {
            Console.WriteLine(i.serialNumber + " : " + (i.goodsWeight + i.konWeight) + " kg");
        }
    }
}
