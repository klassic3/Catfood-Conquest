using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uiscripts : MonoBehaviour
{
    public int coinCount;
    public Text coinCounttext;
    // Start is called before the first frame update
    void Start()
    {
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

        // Check if coinCounttext is assigned
        if (coinCounttext != null)
        {
            coinCounttext.text = coinCount.ToString();
        }
        else
        {
            Debug.LogError("coinCounttext is not assigned in the Inspector!");
        }
    }

    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
