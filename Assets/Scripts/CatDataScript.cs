using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CatDataScript 
{
    public int coinCount;

    public int catfoodCount;

    public int milkCount;

    public float MoonhighScore;
    public float MarshighScore;

    public bool ship1own;
    public bool ship2own;

    public CatDataScript (InventoryScript cat)
    {
        coinCount = cat.coinCount;
        catfoodCount = cat.catfoodCount;
        milkCount = cat.milkCount;
        MoonhighScore = cat.MoonhighScore;
        MarshighScore = cat.MarshighScore;
        ship1own = cat.ship1own;
        ship2own = cat.ship2own;
    }
}
