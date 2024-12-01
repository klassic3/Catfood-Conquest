using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCountScript : MonoBehaviour
{
    public int coinCount;
    public Text coinCounttext;

    public GameObject alertDisplay;


    public BuyButtonScript page1;
    public BuyButtonScript page2;
    

    // Start is called before the first frame update
    void Start()
    {
        alertDisplay.SetActive(false);
        LoadCat();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadCat()
    {
        CatDataScript data = SaveScript.LoadCat();
        if (data != null)
        {
            coinCount = data.coinCount;
        }
        else
        {
            coinCount = 0;
        }
        coinCounttext.text = coinCount.ToString();

    }

    public void expense(int cost)
    {

        if (coinCount > cost)
        {
            InventoryScript.Instance.SpendCoin(cost);
            if (cost == 1000)
            {
                page1.updateButton();
            }
            else if (cost == 2500)
            {
                page2.updateButton();
            }
            
            LoadCat();
        }
        else
        {
            alertDisplay.SetActive(true);
            Invoke("hidealert", 2);
        }
    }
    public void hidealert()
    {
        alertDisplay.SetActive(false);
    }


}

