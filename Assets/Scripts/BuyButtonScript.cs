using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButtonScript : MonoBehaviour
{
    public GameObject buyButton;
    public GameObject priceLabel;
    public GameObject ownedLabel;
    public bool owned;

    

    public int coinCount;
    // Start is called before the first frame update
    void Start()
    {
        if (owned == false)
        {
            buyButton.SetActive(true);
            priceLabel.SetActive(true);
            ownedLabel.SetActive(false);
        }
        else
        {
            buyButton.SetActive(false);
            priceLabel.SetActive(false);
            ownedLabel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateButton()
    {
            owned = true;
            buyButton.SetActive(false);
            priceLabel.SetActive(false);
            ownedLabel.SetActive(true);
        
    }

    [ContextMenu("Sell")]
    public void sellRocket()
    {
        owned = false;
    }
}
