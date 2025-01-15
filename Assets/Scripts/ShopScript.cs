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

    AudioManagerScript AudioManager;
    private void Awake()
    {
        AudioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        alertDisplay.SetActive(false);
        LoadCat();
        if (InventoryScript.Instance.ship1own == true)
        {
            page1.updateButton();
        }
        if (InventoryScript.Instance.ship2own == true)
        {
            page2.updateButton();
        }
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
            AudioManager.PlaySFX(AudioManager.yay);
            if (cost == 1000)
            {
                page1.updateButton();
                InventoryScript.Instance.SaveShip(true, InventoryScript.Instance.ship2own);
            }
            else if (cost == 2500)
            {
                page2.updateButton();
                InventoryScript.Instance.SaveShip(InventoryScript.Instance.ship1own, true);
            }
            
            LoadCat();
        }
        else
        {
            alertDisplay.SetActive(true);
            Invoke("hidealert", 2);
        }
    }

    [ContextMenu("Sell")]

    public void SellShip()
    {
        InventoryScript.Instance.SaveShip(false, false);
    }
    public void hidealert()
    {
        alertDisplay.SetActive(false);
    }


}

