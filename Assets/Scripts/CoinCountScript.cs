using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCountScript : MonoBehaviour
{
    public int coinCount;
    public Text coinCounttext;

    public GameObject alertDisplay;


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

