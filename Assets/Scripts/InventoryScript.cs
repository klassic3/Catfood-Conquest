using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public static InventoryScript Instance;


    public int coinCount;

    public int catfoodCount;

    public int milkCount;

    public float MoonhighScore;
    public float MarshighScore;

    public bool ship1own;
    public bool ship2own;

    void Start()
    {

        LoadCat();
    }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject); // If instance exists, destroy this duplicate
        }
        else
        {
            Instance = this; // Otherwise, set this as the instance
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
    }

    [ContextMenu("Save")]
    public void SaveCat()
    {
        // Save the data using the SaveScript
        SaveScript.SaveCat(this);
        Debug.Log("Inventory saved!");
    }

    // Method to load inventory data
    [ContextMenu("Load")]
    public void LoadCat()
    {
        CatDataScript data = SaveScript.LoadCat();

        if (data != null)
        {
            // Load the saved data into the inventory
            coinCount = data.coinCount;

            catfoodCount = data.catfoodCount;

            milkCount = data.milkCount;

            MoonhighScore = data.MoonhighScore;

            MarshighScore = data.MarshighScore;

            ship1own = data.ship1own;

            ship2own = data.ship2own;

            Debug.Log("Inventory loaded!");
        }
        else
        {
            Debug.LogWarning("No data found to load.");
        }
    }

    public void SpendCoin(int cost)
    {
        LoadCat();
        coinCount -= cost;
        SaveCat();
    }
    public void SaveShip(bool owned1, bool owned2)
    {
        ship1own = owned1;
        ship2own = owned2;
        SaveCat();
    }
}
