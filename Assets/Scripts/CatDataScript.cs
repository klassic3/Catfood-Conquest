using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CatDataScript 
{
    public int coinCount;

    public int catfoodCount;

    public int milkCount;

    public float highScore;

    public CatDataScript (GameScript cat)
    {
        coinCount = cat.coinCount;
        catfoodCount = cat.catfoodCount;
        milkCount = cat.milkCount;
        highScore = cat.highScore;
    }
}
