using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uiscripts : MonoBehaviour
{
    public GameObject howtoplayscreen;
    public GameObject TitleScreen;
    public GameObject Title;
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
        coinCount = data.coinCount;
        coinCounttext.text = coinCount.ToString();
    }

    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
