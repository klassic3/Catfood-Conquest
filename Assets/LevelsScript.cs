using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelsScript : MonoBehaviour
{
    public GameObject MarsUnreachable;
    public GameObject MarsEnter;
    // Start is called before the first frame update
    void Start()
    {
        if (InventoryScript.Instance.ship1own == true)
        {
            MarsEnter.SetActive(true);
            MarsUnreachable.SetActive(false);
        }
        else
        {
            MarsEnter.SetActive(false);
            MarsUnreachable.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
